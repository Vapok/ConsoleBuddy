# Console Buddy

A lightweight, performance-friendly quality-of-life mod for Valheim that allows you to fully customize the look, feel, size, positioning, and buffer capacity of the in-game developer console window.

---

## Features

* **Custom Fonts**: Choose any font installed on your system or use the default game font.
* **Custom Typography**: Adjust font size and font color with ease.
* **Console Styling**: Customize background tint and opacity/transparency.
* **Flexible Positioning**: Adjust horizontal offsets and vertical height/margins to fit any screen resolution or UI layout.
* **Expanded History & Buffer**: Increase the console scrollback limit and visible history lines so you never lose command logs or debug output.
* **High Performance**: Event-driven formatting updates ensure zero frame rate impact during gameplay.

---

## Configuration Options

Console Buddy generates a configuration file at `BepInEx/config/vapok.mods.consolebuddy.cfg` upon first run. All settings can be tweaked directly in the config file or adjusted in real time in-game using the **BepInEx Configuration Manager** (`F1`).

### 🎨 Console Appearance

| Setting | Type | Default | Description |
| :--- | :--- | :--- | :--- |
| **`Font Size`** | `Integer (5–100)` | `20` | Sets the font size of the text rendered in the console window. |
| **`Font Color`** | `Color (RGBA)` | `Grey` | Sets the text color of console logs and output. |
| **`Font Name`** | `String (Dropdown)` | `Default Console Font` | Selects which font family to render console text with. Lists all fonts installed on your operating system alongside the default game font. |
| **`Console Background Color`** | `Color (RGBA)` | `#00000086` *(Semi-Transparent Black)* | Sets the background tint color and transparency (alpha) of the console window. |
| **`Buffer Limit`** | `Integer` | `3000` | Sets the maximum number of history/log lines retained in the console buffer before old lines are discarded. |
| **`Visible Lines Shown`** | `Integer` | `300` | Sets the maximum number of visible lines rendered in the active console output viewport. *(Note: Requires game restart to change).* |

### 📐 Console Positioning

| Setting | Type | Default | Description |
| :--- | :--- | :--- | :--- |
| **`Console Background Left Offset`** | `Integer (0–5000)` | `0` | Adjusts the left horizontal offset/margin of the console background window. |
| **`Console Background Right Offset`** | `Integer (-5000–0)` | `0` | Adjusts the right horizontal offset/margin of the console background window. |
| **`Console Background Height`** | `Integer (-500–500)` | `0` | Adjusts the bottom/vertical height offset of the console window. |

---

## Installation

### Using a Mod Manager (Recommended)
1. Install via **Thunderstore Mod Manager**, **r2modman**, or **Gale**.
2. Launch the game through your mod manager.

### Manual Installation
1. Ensure [BepInEx for Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/) and [Jötunn (ValheimLib)](https://valheim.thunderstore.io/package/ValheimModding/Jotunn/) are installed.
2. Download the latest release from [Thunderstore](https://valheim.thunderstore.io/package/Vapok/ConsoleBuddy/) or [GitHub Releases](https://github.com/Vapok/ConsoleBuddy/releases).
3. Extract the `ConsoleBuddy.dll` file into your `Valheim/BepInEx/plugins/` directory.

---

## Mod Author Details

![Vapok Gaming](https://avatars.githubusercontent.com/u/1264136?s=180&v=4)

* **Author**: [Vapok](https://github.com/Vapok)
* **Source Code**: [GitHub](https://github.com/Vapok/ConsoleBuddy)
* **Discord**: [Vapok's Mod Community](https://discord.gg/5YAJkRFBXt)
* **Patch Notes**: [Changelog](https://github.com/Vapok/ConsoleBuddy/blob/main/CHANGELOG.md)
