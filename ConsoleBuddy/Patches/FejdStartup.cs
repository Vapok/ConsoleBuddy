using HarmonyLib;

namespace ConsoleBuddy.Patches;

public class FejdStartupPatches
{

    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.Awake))]
    [HarmonyAfter("vapok.common.LocalizationManager", "org.bepinex.helpers.LocalizationManager")]
    [HarmonyBefore("vapok.common.ItemManager", "org.bepinex.helpers.ItemManager")]
    public static class FejdStartupAwakePatch
    {
        static void Prefix()
        {
            ConsoleBuddy.Waiter.ValheimIsAwake(true);
        }
    }

}