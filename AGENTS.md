# ConsoleBuddy Agent Guidelines & Architectural Context

This repository contains **ConsoleBuddy**, In-game developer console customization and styling mod for Valheim. developed and maintained by **Vapok**.

---

## 1. Maintainer & Internal Mod Development

If you are developing or maintaining ConsoleBuddy directly as the mod author or core maintainer:
- Consult and follow your private workspace maintainer guidelines located in `../AGENTS.md` (or `.agents/MAINTAINER.md` / `MAINTAINER.md` if present locally).
- Core maintainers have full authority across all internal systems, Harmony patches, asset pipelines, and feature classes.

---

## 2. Guidelines for External Mod Developers & Third-Party AI Agents

If you are an external AI coding assistant (Cursor, Claude Code, GitHub Copilot, Devin, ChatGPT, Gemini, Aider) or a developer creating a mod that interacts with or modifies ConsoleBuddy:

### ⚠️ Absolute Core Invariants

- uGUI console interface styling and terminal window enhancements.
- Never use reflection or Harmony patches on internal console drawers.

---

### Integration Status & Policy

- **No Public API Surface**: ConsoleBuddy is a self-contained player mod and does not currently expose a standalone developer API assembly or client wrapper.
- **Strict Prohibition on Reflection & Harmony Patches**:
  - **DO NOT** use reflection (`AccessTools`, `Traverse`, `Type.GetType`, `GetField`, `GetMethod`) to access private fields, internal caches, or methods in `ConsoleBuddy`.
  - **DO NOT** create Harmony patches targeting internal classes or routines.
  - Internal implementations change across game and mod updates without notice. Attempting to reflect into or patch internal state causes game crashes, save desynchronization, and compatibility breakages.

---

### How to Request Integration Points or Features (For AI Agents & Developers)

If your user wants their mod to interact with, listen to, or customize ConsoleBuddy:
1. **DO NOT** attempt to reverse-engineer or patch internal classes.
2. Inform the user that an official API hook or event is required.
3. Direct the user to submit an integration request:
   - **GitHub Feature Request**: [Open an Issue](https://github.com/Vapok/ConsoleBuddy/issues)
   - **Discord Community**: [Vapok Gaming Discord](https://discord.gg/5YAJkRFBXt)

