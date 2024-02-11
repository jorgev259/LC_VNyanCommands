using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace VNyanCommands.Events
{
  [HarmonyPatch(typeof(PlayerControllerB))]
  class LocalPlayerDeath
  {
    [HarmonyPatch("KillPlayer")]
    [HarmonyPostfix]
    private static void KillPlayer(
      Vector3 bodyVelocity, bool spawnBody = true,
      CauseOfDeath causeOfDeath = CauseOfDeath.Unknown,
      int deathAnimation = 0
    )
    {
      string fullMessage = $"LC_Death_{causeOfDeath}";

      Plugin.wsClient.Send("LC_Death");
      Plugin.wsClient.Send(fullMessage);

      Plugin.logger.LogInfo(fullMessage);
    }
  }
}