# 2.0.1 - Dependency & Compatibility Maintenance
* **Runtime & Dependency Updates**:
  * Synchronized package manifest and project references with Jotunn `2.30.0` and BepInEx `5.4.2350`.
  * Verified build pipeline and ILRepack bundling with `Vapok.Valheim.Common` `3.2.1012`.
* **Compatibility & Documentation**:
  * Validated console GUI intercept hooks and terminal styling events against current Valheim 1.0 builds.
  * Standardized mod documentation, changelog tiers, and release staging.

# 2.0.0 - Valheim 1.0 Update & Terminal Enhancements
* **Valheim 1.0 Compatibility**:
  * Updated assembly references for Valheim 1.0 (`1.0.12`), BepInEx 5.4.2350, and Jotunn 2.30.0.
  * Rebuilt on .NET Framework 4.8.
  * Bundled latest `Vapok.Valheim.Common` 3.2.1012 via ILRepack.
* **Terminal & Console Command Hooks**:
  * Updated Harmony patches on `Terminal.TryRunCommand`, `Terminal.InitTerminal`, and `Terminal.AddString`.
  * Resolved parameter parsing changes introduced in Valheim 1.0's updated console architecture.
  * Enhanced autocomplete caching for custom mod commands and native cheats (`devcommands`).
* **Stability & Command History**:
  * Fixed command history navigation and string buffer indexing edge cases.
  * Added defensive null checks when terminal inputs are executed before world initialization is complete.

# 1.1.0 - Command History Persistence & Autocomplete Overhaul
* Added persistent command history saved across sessions.
* Refactored autocomplete engine for improved performance and responsiveness.

# 1.0.0 - Initial Release of ConsoleBuddy
* Initial release of developer and debugging console enhancements for Valheim.
* Added custom command alias support, colorized output, and enhanced history navigation.
