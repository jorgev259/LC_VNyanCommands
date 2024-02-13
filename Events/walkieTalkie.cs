using GameNetcodeStuff;
using HarmonyLib;

namespace VNyanCommands.Events
{
  [HarmonyPatch(typeof(WalkieTalkie))]
  class WalkieTalkieEvents
  {
    [HarmonyPatch("EquipItem")]
    [HarmonyPostfix]
    private static void EquipItem(WalkieTalkie __instance)
    {
      PlayerControllerB localPlayerController = StartOfRound.Instance.localPlayerController;
      PlayerControllerB playerHeldBy = __instance.playerHeldBy;

      if (localPlayerController == playerHeldBy) Plugin.sendWS("WalkieTalkie_Hold_On");
    }

    [HarmonyPatch("PocketItem")]
    [HarmonyPostfix]
    private static void PocketItem(WalkieTalkie __instance)
    {
      PlayerControllerB localPlayerController = StartOfRound.Instance.localPlayerController;
      PlayerControllerB playerHeldBy = __instance.playerHeldBy;

      if (localPlayerController == playerHeldBy) Plugin.sendWS("WalkieTalkie_Hold_Off");
    }

    [HarmonyPatch("SwitchWalkieTalkieOn")]
    [HarmonyPostfix]
    private static void SwitchWalkieTalkieOn(WalkieTalkie __instance, bool on)
    {
      PlayerControllerB localPlayerController = StartOfRound.Instance.localPlayerController;
      PlayerControllerB playerHeldBy = __instance.playerHeldBy;

      if (localPlayerController == playerHeldBy)
      {
        Plugin.sendWS($"WalkieTalkie_Power_{(on ? "On" : "Off")}");
      }
    }

    [HarmonyPatch("SetLocalClientSpeaking")]
    [HarmonyPostfix]
    private static void SetLocalClientSpeaking(WalkieTalkie __instance, bool speaking)
    {
      PlayerControllerB localPlayerController = StartOfRound.Instance.localPlayerController;
      PlayerControllerB playerHeldBy = __instance.playerHeldBy;

      if (localPlayerController == playerHeldBy)
      {
        Plugin.sendWS($"WalkieTalkie_Speak_{(speaking ? "On" : "Off")}");
      }
    }
  }
}