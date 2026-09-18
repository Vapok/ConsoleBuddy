<div align="center">

# 💻 ConsoleBuddy

### *Developer and player console enhancements, styling, and customization for Valheim.*

[![GitHub Release](https://img.shields.io/github/v/release/Vapok/ConsoleBuddy?include_prereleases&logo=github&style=for-the-badge)](https://github.com/Vapok/ConsoleBuddy/releases)
[![Thunderstore Version](https://img.shields.io/thunderstore/v/Vapok/ConsoleBuddy?logo=thunderstore&style=for-the-badge)](https://thunderstore.io/c/valheim/p/Vapok/ConsoleBuddy/)
[![Nexus Mods](https://img.shields.io/badge/Nexus_Mods-Available-da8e35?logo=nexusmods&style=for-the-badge)](https://www.nexusmods.com/valheim/mods/2315)
<br>
[![Discord](https://img.shields.io/badge/Discord-Join%20Community-7289da?logo=discord&logoColor=white&style=for-the-badge)](https://discord.gg/5YAJkRFBXt)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

---

</div>

Take full command over your Valheim console! **ConsoleBuddy** empowers developers, server administrators, and players to fully customize the in-game terminal with custom font faces, font sizes, colors, console dimensions, positioning, transparency, and expanded buffer history.

---

<div align="center">

<br>

[![Survival Servers](https://raw.githubusercontent.com/Vapok/ConsoleBuddy/main/images/survivalservers_banner.png)](https://www.survivalservers.com/services/game_servers/valheim/?ref=vapok)

</div>

## ✨ Features

* 🔤 **Custom Fonts & Styling**: Select any installed system font (with automatic cross-platform fallbacks for Linux, Steam Deck, and Windows) and customize font size and color.
* 📐 **Custom Size & Positioning**: Adjust console window width, height, and screen alignment to fit your display resolution and preference.
* 🎨 **Background Customization**: Set custom background colors and transparency levels to keep gameplay visible behind the terminal.
* 📜 **Expanded Buffer History**: View and retain hundreds of log lines with configurable visible lines and buffer capacity.
* ⚡ **Zero Performance Impact**: Operates purely on event triggers when the console opens or settings change—no per-frame overhead.

---

## 🕹️ Controls & Keybinds

| Input | Default Action |
| :--- | :--- |
| <kbd>F5</kbd> | Toggle the in-game console open and closed. |
| <kbd>↑</kbd> / <kbd>↓</kbd> | Navigate through prior command history. |
| <kbd>Tab</kbd> | Autocomplete commands and arguments. |
| <kbd>Page Up</kbd> / <kbd>Page Down</kbd> | Scroll through console log buffer history. |

---

## ⚙️ Configuration & Settings

Tailor all visual settings in real time via the in-game [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) (<kbd>F1</kbd>):

| Setting | Default | Description |
| :--- | :--- | :--- |
| **Font Size** | `14` | The text size in points rendered in the console window. |
| **Font Color** | `White` | Color of output text (accepts Hex colors or standard names). |
| **Font Face** | `Consolas` | Name of the font face to render. |
| **Console Width** | `800` | Width of the console window in pixels. |
| **Console Height** | `400` | Height of the console window in pixels. |
| **Console Position X/Y** | `(0, 0)` | Screen offset position for the console window. |
| **Background Color** | `Black` | Background color of the terminal panel. |
| **Background Alpha** | `0.75` | Transparency level of the console background (`0.0` = transparent, `1.0` = solid). |
| **Buffer Limit** | `1000` | Maximum number of log lines preserved in memory buffer. |
| **Visible Lines** | `25` | Number of log lines displayed simultaneously on screen. |

---

## 🛡️ Advanced Safeguards

* 🐧 **Cross-Platform Resilience**: Gracefully falls back to default Unity font rendering if a configured font is missing on Steam Deck or Linux.
* 🔒 **Client-Side Module**: Safe for multiplayer servers; runs strictly on the client without modifying server game rules.

---

## 🌐 Available Translations

<div align="center">

🇺🇸 **English** (Default)

</div>

*Want to help translate Console Buddy? Community translations are welcome! Please submit a PR on [GitHub](https://github.com/Vapok/ConsoleBuddy) or stop by our [Discord](https://discord.gg/5YAJkRFBXt).*

---

## 📥 Installation

### Mod Manager (Recommended)
1. Install via **R2ModMan** or **Thunderstore Mod Manager**.
2. Dependencies (`BepInExPack`, `Jotunn (JVL)`) are installed automatically.

### Manual Installation
* Copy `ConsoleBuddy.dll` to your `Valheim/BepInEx/plugins` directory.

---

## 🔒 Anonymous Telemetry, Error Reporting & Privacy

Console Buddy includes lightweight, privacy-first telemetry and error reporting to help monitor mod stability, diagnose unhandled bugs, and track active version adoption across game updates.

* **100% Anonymous**: We never collect personal data, Steam IDs, IP addresses, character/world names, or file system paths. Stack traces from errors are automatically sanitized to strip local user directories.
* **Granular Player Control**:
  * **Anonymous Telemetry (Opt-In)**: Tracks version adoption and session launches. Defaults to **unchecked / disabled** when first loaded (`Enable Anonymous Telemetry = false`).
  * **Error Reporting (Opt-Out)**: Captures sanitized mod crash diagnostics to rapidly identify and fix bugs. Defaults to **enabled** (`Send Error Reports = true`) with one-click opt-out.
  * **Data Disclaimers**: Hover over any toggle in the startup modal for interactive tooltip disclaimers detailing exactly what data is transmitted.
* **In-Game & Online Privacy Policy**: The full privacy policy can be viewed directly in-game by clicking **`[ PRIVACY POLICY ]`** on the startup splash modal, or online at [vapok.io/privacy-policy](https://vapok.io/privacy-policy/).
* **Configuration Files**: Settings can be managed in-game via the startup modal, through the BepInEx Configuration Manager, or under `[Local Config]` in `BepInEx/config/vapok.mods.consolebuddy.cfg`.

---

<div align="center">

### 👨‍💻 Created by Vapok Gaming

[![Vapok Gaming](https://avatars.githubusercontent.com/u/1264136?s=120&v=4)](https://github.com/Vapok)

**Author**: [Vapok](https://github.com/Vapok)  
**Source Code**: [GitHub Repository](https://github.com/Vapok/ConsoleBuddy)  
**Community & Support**: [Discord Server](https://discord.gg/5YAJkRFBXt)  
**Changelog**: [Release Notes](https://github.com/Vapok/ConsoleBuddy/blob/main/CHANGELOG.md)

</div>
