# 2.0.8 - Dedicated Server Bypass & Library Alignment
* Disabled console styling on headless dedicated servers to save performance.
* Updated Jotunn to 2.30.2 and internal dependencies for stability.

<details>
<summary><b>2.0 Changelog History (Valheim Release)</b> (<i>click to expand</i>)</summary>

### 2.0.7 - Valheim 1.0.15 Alignment & Internalized Dependency Updates
* **Valheim 1.0.15 Alignment**: Updated game assembly references and internalized `Vapok.Valheim.Common` 3.13.1015.
* **Localization & Stability**: Re-synchronized 35-language splash localizations and verified patch compatibility.

### 2.0.6 - Splash Window Updates & Valheim 1.0.14 Alignment
* **Splash Window Updates**:
  * Telemetry is now unchecked when first loaded (Opt-In visibility)
  * Added Send Error Logs (Opt-Out)
  * Privacy Policy is now available directly in-game
  * Added Data Disclaimers on hover over checkboxes for transparency on what data is sent
* **Valheim 1.0.14 Alignment**: Updated game assembly references and internalized `Vapok.Valheim.Common` 3.12.1014.


### 2.0.5 - Jewelcrafting Font Compatibility
* Fixed: Jewelcrafting packages it's own font which was overriding part of a vanilla font, causing the Splash screen to appear blank.
### 2.0.4 - Updated README with Telemetry Information
* Updated the README.md with Anonymous Telemetry information per request of mod stores.

### 2.0.3 - Unified Splash Screen & Telemetry Controls
* **Unified Startup Splash Screen**: Integrated with a centralized startup splash screen.
  * Added configurable `Show on Game Startup` which can be enabled or disabled in the configuration file.
* **Anonymous Telemetry**: 
  * Added configurable `Enable Anonymous Telemetry` configuration which can be enabled or disabled in the configuration file.
    * Defaults to enabled with auto-opt-in on launch. Uncheck to Opt-Out
    * ANONYMOUS DATA ONLY - I track version number and usage data. No personal data is ever collected. For more information, see the [Privacy Policy](https://vapok.io/privacy-policy/).

### 2.0.1 - Dependency & Compatibility Maintenance
* **Dependency Updates**: Updated Jotunn and BepInEx runtime package bindings.
* **Compatibility Maintenance**: Verified compatibility against the latest Valheim 1.0 release.
* **Documentation Improvements**: Standardized README, user guides, and technical patch documentation.

### 2.0.0 - Valheim 1.0 Release
* **Valheim 1.0 Compatibility**: Updated and validated all console hooks and game references for Valheim 1.0.
* **Performance Optimizations**: Converted console styling from per-frame updates to an efficient event-driven system triggered only upon changes.
* **Font Loading & Cross-Platform Stability**: Added fallback handling to prevent errors when configured custom fonts are missing or unavailable on Linux/Steam Deck.
* **Configuration & UI Fixes**: Clarified configuration tooltips and streamlined console element binding.
* **Framework Updates**: Updated to Jotunn 2.30.0 and Vapok.Valheim.Common 3.2.1012.

</details>

<details>
<summary><b>1.0 Changelog History (Valheim Early Access)</b> (<i>click to expand</i>)</summary>

### 1.1.2 - Updating Dependencies
* Updated all dependencies to latest versions.

### 1.1.1 - Dedicated Server Config Syncing Fix
* Resolved an issue preventing dedicated servers from properly enforcing configuration settings on connected clients.
* Added graceful dependency handling and notifications.

### 1.1.0 - Jotunn Migration
* Updated for Valheim 0.221.4 and transitioned to Jotunn library.

### 1.0.7 - Valheim 0.217.28 Updates
* Updated for Valheim 0.217.28.

### 1.0.6 - Valheim 0.217.24 Updates
* Updated for Valheim 0.217.24.

### 1.0.5 - Valheim 0.217.14 Updates
* Updated for Valheim 0.217.14.

### 1.0.4 - Valheim 0.216.9 Updates
* Updated for Valheim 0.216.9.

### 1.0.3 - Buffer Limit and Visible Line Settings
* Added configuration settings for Console Buffer Limit and Visible Lines shown.

### 1.0.2 - Font Saving Fix
* Fixed font setting persistence when saving configurations.

### 1.0.1 - Custom Console Styling & Sizing
* Added settings for Font Face Type, Console Positioning, Width, Height, and Background Color/Transparency.

### 1.0.0 - Initial Release
* Initial release allowing Font Size and Font Color customization for Valheim's in-game console.

</details>
