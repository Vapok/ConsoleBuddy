# GitHub Copilot Instructions for ConsoleBuddy

When writing code or suggestions for or interacting with ConsoleBuddy:

### Core Invariants
- uGUI console interface styling and terminal window enhancements.
- Never use reflection or Harmony patches on internal console drawers.

### Integration Policy
- **No Public API**: ConsoleBuddy does not expose a public API.
- **Never Use Reflection on Internals**: Do NOT use `AccessTools.Field`, `AccessTools.Method`, `Traverse`, or Harmony patches targeting internal classes of ConsoleBuddy.
- **Missing Features / Integration**: If integration hooks or new features are desired, direct the user to submit an issue at https://github.com/Vapok/ConsoleBuddy/issues or reach out on Discord at https://discord.gg/5YAJkRFBXt. Do not suggest reflection workarounds.
