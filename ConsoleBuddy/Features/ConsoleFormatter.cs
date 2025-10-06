using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using BepInEx.Configuration;
using ConsoleBuddy.Configuration;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Shared;

namespace ConsoleBuddy.Features;

public class ConsoleFormatter
{
    public static bool FeatureInitialized = false;
    public static List<string> FontNameList;
    private static GameObject TextGameObject = null;
    private static GameObject ImageGameObject = null;
    public static ConfigEntry<int> ConsoleFontSize;
    public static ConfigEntry<Color> ConsoleFontColor;
    public static ConfigEntry<Color> ConsoleBackGroundColor;
    public static ConfigEntry<string> ConsoleFontName;
    public static ConfigEntry<int> ConsoleBackgroundOffsetMaxXPos;
    public static ConfigEntry<int> ConsoleBackgroundOffsetMinYPos;
    public static ConfigEntry<int> ConsoleBackgroundOffsetMinXPos;
    public static ConfigEntry<int> ConsoleBufferLimit;
    public static ConfigEntry<int> ConsoleVisibleBufferLimit;
    private static TextMeshProUGUI _textComponent;
    private static RectTransform _rect;
    private static Image _image;
    private static TMP_FontAsset _configuredFont;
    private static TMP_FontAsset _defaultFont;
    

    static ConsoleFormatter()
    {
        FontNameList = new List<string>();
        FontNameList.Add("Default Console Font");
        FontNameList.AddRange(Font.GetOSInstalledFontNames().ToList());
        
        ConfigRegistry.Waiter.StatusChanged += (_, _) => RegisterConfigurationFile();
    }

    private static void RegisterConfigurationFile()
    {
        ConsoleFontSize = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Size", 20,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(5,100),
                new ConfigurationManagerAttributes { Order = 1 }),ref ConsoleFontSize);

        ConsoleFontColor = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Color", Color.grey,
            new ConfigDescription("Adjusts Console Font Size",
                null,
                new ConfigurationManagerAttributes { Order = 2 }),ref ConsoleFontColor);

        var acceptableValues = new AcceptableValueList<string>(FontNameList.ToArray());
        
        ConsoleFontName = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Name", "Default Console Font",
            new ConfigDescription("Adjusts Console Font Size",
                acceptableValues,
                new ConfigurationManagerAttributes { Order = 3 }),ref ConsoleFontName);
        
        ConsoleFontName.SettingChanged += (_, _) => UpdateFont();

        ConsoleBackGroundColor = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Console Background Color", new Color(0,0,0,134/255.0F),
            new ConfigDescription("Adjusts Console Font Size",
                null,
                new ConfigurationManagerAttributes { Order = 4 }),ref ConsoleBackGroundColor);

        ConsoleBufferLimit = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Buffer Limit", 3000,
            new ConfigDescription("Adjusts Console maximum buffer limit",
                null,
                new ConfigurationManagerAttributes { Order = 5 }),ref ConsoleBufferLimit);

        ConsoleVisibleBufferLimit = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Visible Lines Shown (Requires Restart)", 300,
            new ConfigDescription("Adjusts Console Visible Buffer Lines Shown - *Requires Game Restart*",
                null,
                new ConfigurationManagerAttributes { Order = 5 }),ref ConsoleVisibleBufferLimit);


        ConsoleBackgroundOffsetMinXPos = ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Left Offset", 0,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(0,5000),
                new ConfigurationManagerAttributes { Order = 1 }),ref ConsoleBackgroundOffsetMinXPos);

        ConsoleBackgroundOffsetMaxXPos = ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Right Offset", 0,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(-5000,0),
                new ConfigurationManagerAttributes { Order = 2 }),ref ConsoleBackgroundOffsetMaxXPos);

        ConsoleBackgroundOffsetMinYPos = ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Height", 0,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(-500,500),
                new ConfigurationManagerAttributes { Order = 3 }),ref ConsoleBackgroundOffsetMinYPos);
    }

    private static void UpdateFont()
    {
        var fontIndex = FontNameList.IndexOf(ConsoleFontName.Value);
        if (fontIndex == 0)
        {
            _configuredFont = _defaultFont;
            return;
        }
        
        var fontType = new Font(Font.GetPathsToOSFonts()[fontIndex-1]);
        _configuredFont = TMP_FontAsset.CreateFontAsset(fontType);
    }

    public static void AddString(Terminal instance, string text)
    {
        while (instance.m_maxVisibleBufferLength > 1)
        {
            try
            {
                instance.m_chatBuffer.Add(text);
                while (instance.m_chatBuffer.Count > ConsoleBufferLimit.Value)
                    instance.m_chatBuffer.RemoveAt(0);
                instance.UpdateChat();
                break;
            }
            catch (Exception)
            {
                --instance.m_maxVisibleBufferLength;
            }
        }
    }

    [HarmonyPatch(typeof(Console), nameof(Console.Awake))]
    public static class ConsoleAwakePatch
    {
        [HarmonyPriority(Priority.First)]
        private static void Postfix(ref Console __instance)
        {
            void GetChildren(Transform parent)
            {
                for (var i = 0; i < parent.transform.childCount; i++)
                {
                    var childTransform = parent.transform.GetChild(i);
                    if (childTransform.childCount > 0)
                    {
                        if (childTransform.name.Equals("Image"))
                        {
                            ImageGameObject = childTransform.gameObject;
                            var textTransform = childTransform.Find("Text");
                            if (textTransform != null)
                                TextGameObject = textTransform.gameObject;
                            return;
                        }

                        GetChildren(childTransform);
                    }
                }
            }

            if (__instance.transform.childCount > 0)
            {
                GetChildren(__instance.transform);
            }
            
            __instance.m_terminalInstance.m_maxVisibleBufferLength = ConsoleVisibleBufferLimit.Value;

            _textComponent = TextGameObject.GetComponent<TextMeshProUGUI>();
            _rect = ImageGameObject.GetComponent<RectTransform>();
            _image = ImageGameObject.GetComponent<Image>();
            _defaultFont = _textComponent.font;

            var fontIndex = FontNameList.IndexOf(ConsoleFontName.Value);
            if (fontIndex == 0)
            {
                _configuredFont = _defaultFont;
                return;
            }

            var fontType = new Font(Font.GetPathsToOSFonts()[fontIndex - 1]);
            _configuredFont = TMP_FontAsset.CreateFontAsset(fontType);


        }

        [HarmonyPatch(typeof(Console), nameof(Console.Update))]
        public static class ConsoleUpdatePatch
        {
            [HarmonyPriority(Priority.First)]
            private static void Postfix(ref Console __instance)
            {
                if (TextGameObject == null)
                    return;

                _rect.offsetMax = new Vector2(ConsoleBackgroundOffsetMaxXPos.Value, _rect.offsetMax.y);
                _rect.offsetMin = new Vector2(ConsoleBackgroundOffsetMinXPos.Value,
                    ConsoleBackgroundOffsetMinYPos.Value);
                _image.color = ConsoleBackGroundColor.Value;
                _textComponent.font = _configuredFont;
                _textComponent.fontSize = ConsoleFontSize.Value;
                _textComponent.color = ConsoleFontColor.Value;
            }

        }

        [HarmonyPatch(typeof(Terminal), nameof(Terminal.AddString), new []{typeof(string)})]
        static class TerminalAddStringPatch
        {
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var instrs = new List<CodeInstruction>();

                var counter = 0;

                CodeInstruction LogMessage(CodeInstruction instruction)
                {
                    ConsoleBuddy.Log.Debug($"IL_{counter}: Opcode: {instruction.opcode} Operand: {instruction.operand}");
                    return instruction;
                }
                
                instrs.Add(LogMessage(new CodeInstruction(OpCodes.Ldarg_0)));
                instrs.Add(LogMessage(new CodeInstruction(OpCodes.Ldarg_1)));
                instrs.Add(LogMessage(new CodeInstruction(OpCodes.Call, AccessTools.DeclaredMethod(typeof(ConsoleFormatter),nameof(ConsoleFormatter.AddString)))));
                instrs.Add(LogMessage(new CodeInstruction(OpCodes.Ret)));

                return instrs;
            }
        }
    }
}