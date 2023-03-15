using System.Collections.Generic;
using System.Linq;
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
    public static ConfigEntry<int> ConsoleFontSize { get; private set; }
    public static ConfigEntry<Color> ConsoleFontColor { get; private set; }
    public static ConfigEntry<Color> ConsoleBackGroundColor { get; private set; }
    public static ConfigEntry<string> ConsoleFontName { get; private set; }
    public static ConfigEntry<int> ConsoleBackgroundOffsetMaxXPos { get; private set; }
    public static ConfigEntry<int> ConsoleBackgroundOffsetMinYPos { get; private set; }
    public static ConfigEntry<int> ConsoleBackgroundOffsetMinXPos { get; private set; }
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
                new ConfigurationManagerAttributes { Order = 1 }));

        ConsoleFontColor = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Color", Color.grey,
            new ConfigDescription("Adjusts Console Font Size",
                null,
                new ConfigurationManagerAttributes { Order = 2 }));

        var acceptableValues = new AcceptableValueList<string>(FontNameList.ToArray());
        
        ConsoleFontName = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Name", "Default Console Font",
            new ConfigDescription("Adjusts Console Font Size",
                acceptableValues,
                new ConfigurationManagerAttributes { Order = 3 }));
        
        ConsoleFontName.SettingChanged += (_, _) => UpdateFont();

        ConsoleBackGroundColor = ConfigSyncBase.UnsyncedConfig("Console Appearance", "Console Background Color", new Color(0,0,0,134/255.0F),
            new ConfigDescription("Adjusts Console Font Size",
                null,
                new ConfigurationManagerAttributes { Order = 4 }));

        ConsoleBackgroundOffsetMinXPos = ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Left Offset", 0,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(0,5000),
                new ConfigurationManagerAttributes { Order = 1 }));

        ConsoleBackgroundOffsetMaxXPos = ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Right Offset", 0,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(-5000,0),
                new ConfigurationManagerAttributes { Order = 2 }));

        ConsoleBackgroundOffsetMinYPos = ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Height", 0,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(-500,500),
                new ConfigurationManagerAttributes { Order = 3 }));
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
            var fontType = new Font(Font.GetPathsToOSFonts()[fontIndex-1]);
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
                _rect.offsetMin = new Vector2(ConsoleBackgroundOffsetMinXPos.Value, ConsoleBackgroundOffsetMinYPos.Value);
                _image.color = ConsoleBackGroundColor.Value;
                _textComponent.font = _configuredFont;    
                _textComponent.fontSize = ConsoleFontSize.Value;
                _textComponent.color = ConsoleFontColor.Value;
            }

        }

    }
}