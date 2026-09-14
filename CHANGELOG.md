# Console Buddy Patchnotes

## 2.0.0 - Valheim 1.0 Release
* **Valheim 1.0 Compatibility**: Updated and validated all hooks, patches, and references for Valheim 1.0.
* **Performance Optimizations**:
  * Removed per-frame UI updates in `Console.Update()`, converting console formatting to an event-driven system triggered only upon Awake or when settings change.
  * Replaced custom transpiler with a clean Harmony prefix hook.
* **Font Loading & Cross-Platform Stability**:
  * Added bounds and null checks to prevent `IndexOutOfRangeException` when configured fonts are missing, uninstalled, or unavailable.
  * Improved font resolution resilience on Linux, Proton, and Steam Deck environments.
* **Configuration & UI Fixes**:
  * Corrected all copy-pasted configuration descriptions across font, color, and positioning settings.
  * Switched console UI element binding to direct references from `Terminal`, avoiding brittle recursive hierarchy searches.
* **Framework Updates**:
  * Updated to Jotunn 2.30.0 and Vapok.Valheim.Common 3.2.1012.

<details>
<summary><b>Changelog History</b> (<i>click to expand</i>)</summary>

## 1.1.2 - Updating Dependencies
* Updating to latest version of dependencies.

## 1.1.1 - Fixing Dedicated Server Config Syncing
* A regression issue was introduced when switching to Jotunn preventing servers from dictating configs to clients.
  * This has been resolved.
* Appropriately added the BepInDependency Flags for graceful mod exit if missing dependencies.

## 1.1.0 - Removes ServerSync, Adds JotunnVL   
* Updates for Valheim 0.221.4

## 1.0.7 - Valheim 0.217.28 Updates
* Updates for Valheim 0.217.28

## 1.0.6 - Valheim 0.217.24 Updates
* Updates for Valheim 0.217.24

## 1.0.5 - Valheim 0.217.14 Updates
* Updates for Valheim 0.217.14

## 1.0.4 - Valheim 0.216.9 Updates
* Updates for Valheim 0.216.9

## 1.0.3 - Additional Features
* Adds settings for adjusting Console Buffer Limit and Visible Lines Shown

## 1.0.2 - Additional Features
* Fixed Font Saving Incorrectly.

## 1.0.1 - Additional Features
* Adjust the Font Face Type
* Adjust Console Positioning
* Adjust Console Width
* Adjust Console Height
* Adjust Console Background Color and Transparency

## 1.0.0 - Initial Release
* Adjust Font Size
* Adjust Font Color

</details>
