using System;
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
        FontNameList = new List<string> { "Default Console Font" };
        try
        {
            var osFonts = Font.GetOSInstalledFontNames();
            if (osFonts != null)
            {
                FontNameList.AddRange(osFonts.ToList());
            }
        }
        catch (Exception ex)
        {
            ConsoleBuddy.Log.Warning($"Failed to retrieve OS installed font names: {ex.Message}");
        }

        ConfigRegistry.Waiter.StatusChanged += (_, _) => RegisterConfigurationFile();
    }

    private static void RegisterConfigurationFile()
    {
        ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Size", 20,
            new ConfigDescription("Adjusts Console Font Size",
                new AcceptableValueRange<int>(5, 100),
                new ConfigurationManagerAttributes { Order = 1 }), ref ConsoleFontSize);

        ConsoleFontSize.SettingChanged += (_, _) => ApplyAppearanceSettings();

        ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Color", Color.grey,
            new ConfigDescription("Adjusts Console Font Color",
                null,
                new ConfigurationManagerAttributes { Order = 2 }), ref ConsoleFontColor);

        ConsoleFontColor.SettingChanged += (_, _) => ApplyAppearanceSettings();

        var acceptableValues = new AcceptableValueList<string>(FontNameList.ToArray());

        ConfigSyncBase.UnsyncedConfig("Console Appearance", "Font Name", "Default Console Font",
            new ConfigDescription("Selects Console Font",
                acceptableValues,
                new ConfigurationManagerAttributes { Order = 3 }), ref ConsoleFontName);

        ConsoleFontName.SettingChanged += (_, _) =>
        {
            UpdateFont();
            ApplyAppearanceSettings();
        };

        ConfigSyncBase.UnsyncedConfig("Console Appearance", "Console Background Color", new Color(0, 0, 0, 134 / 255.0F),
            new ConfigDescription("Adjusts Console Background Color",
                null,
                new ConfigurationManagerAttributes { Order = 4 }), ref ConsoleBackGroundColor);

        ConsoleBackGroundColor.SettingChanged += (_, _) => ApplyAppearanceSettings();

        ConfigSyncBase.UnsyncedConfig("Console Appearance", "Buffer Limit", 3000,
            new ConfigDescription("Adjusts Console maximum buffer limit",
                null,
                new ConfigurationManagerAttributes { Order = 5 }), ref ConsoleBufferLimit);

        ConfigSyncBase.UnsyncedConfig("Console Appearance", "Visible Lines Shown (Requires Restart)", 300,
            new ConfigDescription("Adjusts Console Visible Buffer Lines Shown - *Requires Game Restart*",
                null,
                new ConfigurationManagerAttributes { Order = 6 }), ref ConsoleVisibleBufferLimit);

        ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Left Offset", 0,
            new ConfigDescription("Adjusts Console Background Left Offset",
                new AcceptableValueRange<int>(0, 5000),
                new ConfigurationManagerAttributes { Order = 1 }), ref ConsoleBackgroundOffsetMinXPos);

        ConsoleBackgroundOffsetMinXPos.SettingChanged += (_, _) => ApplyAppearanceSettings();

        ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Right Offset", 0,
            new ConfigDescription("Adjusts Console Background Right Offset",
                new AcceptableValueRange<int>(-5000, 0),
                new ConfigurationManagerAttributes { Order = 2 }), ref ConsoleBackgroundOffsetMaxXPos);

        ConsoleBackgroundOffsetMaxXPos.SettingChanged += (_, _) => ApplyAppearanceSettings();

        ConfigSyncBase.UnsyncedConfig("Console Positioning", "Console Background Height", 0,
            new ConfigDescription("Adjusts Console Background Bottom/Height Offset",
                new AcceptableValueRange<int>(-500, 500),
                new ConfigurationManagerAttributes { Order = 3 }), ref ConsoleBackgroundOffsetMinYPos);

        ConsoleBackgroundOffsetMinYPos.SettingChanged += (_, _) => ApplyAppearanceSettings();
    }

    private static void UpdateFont()
    {
        if (ConsoleFontName == null || string.IsNullOrEmpty(ConsoleFontName.Value) || ConsoleFontName.Value == "Default Console Font")
        {
            _configuredFont = _defaultFont;
            return;
        }

        var fontIndex = FontNameList.IndexOf(ConsoleFontName.Value);
        if (fontIndex <= 0)
        {
            _configuredFont = _defaultFont;
            return;
        }

        try
        {
            var fontPaths = Font.GetPathsToOSFonts();
            var pathIndex = fontIndex - 1;
            if (fontPaths != null && pathIndex >= 0 && pathIndex < fontPaths.Length)
            {
                var fontType = new Font(fontPaths[pathIndex]);
                _configuredFont = TMP_FontAsset.CreateFontAsset(fontType) ?? _defaultFont;
            }
            else
            {
                _configuredFont = _defaultFont;
            }
        }
        catch (Exception ex)
        {
            ConsoleBuddy.Log.Warning($"Failed to load font '{ConsoleFontName.Value}': {ex.Message}");
            _configuredFont = _defaultFont;
        }
    }

    public static void ApplyAppearanceSettings()
    {
        if (_rect != null)
        {
            _rect.offsetMax = new Vector2(ConsoleBackgroundOffsetMaxXPos.Value, _rect.offsetMax.y);
            _rect.offsetMin = new Vector2(ConsoleBackgroundOffsetMinXPos.Value, ConsoleBackgroundOffsetMinYPos.Value);
        }

        if (_image != null)
        {
            _image.color = ConsoleBackGroundColor.Value;
        }

        if (_textComponent != null)
        {
            var fontToUse = _configuredFont ?? _defaultFont;
            if (fontToUse != null)
            {
                _textComponent.font = fontToUse;
            }
            _textComponent.fontSize = ConsoleFontSize.Value;
            _textComponent.color = ConsoleFontColor.Value;
        }
    }

    public static void AddString(Terminal instance, string text)
    {
        if (instance == null)
            return;

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
        private static void Postfix(Console __instance)
        {
            if (__instance == null)
                return;

            _textComponent = __instance.m_output;
            _rect = __instance.m_chatWindow;
            _image = __instance.m_chatWindow != null ? __instance.m_chatWindow.GetComponent<Image>() : null;

            if (_textComponent != null && _defaultFont == null)
            {
                _defaultFont = _textComponent.font;
            }

            UpdateFont();

            __instance.m_maxVisibleBufferLength = ConsoleVisibleBufferLimit.Value;

            ApplyAppearanceSettings();
        }
    }

    [HarmonyPatch(typeof(Terminal), nameof(Terminal.AddString), typeof(string))]
    public static class TerminalAddStringPatch
    {
        [HarmonyPrefix]
        private static bool Prefix(Terminal __instance, string text)
        {
            ConsoleFormatter.AddString(__instance, text);
            return false;
        }
    }
}
