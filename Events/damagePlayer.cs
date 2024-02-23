using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace VNyanCommands.Events
{
  [HarmonyPatch(typeof(PlayerControllerB))]
  class DamagePlayerEvents
  {
    [HarmonyPatch("DamagePlayer")]
    [HarmonyPrefix]
    private static void DamagePlayer(PlayerControllerB __instance, int damageNumber, CauseOfDeath causeOfDeath = CauseOfDeath.Unknown)
    {
      PlayerControllerB localPlayerController = StartOfRound.Instance.localPlayerController;
      if (localPlayerController != __instance) return;

      int startHealth = __instance.health;
      int newHealth;
      int localDamage = (__instance.isPlayerDead || !__instance.AllowPlayerDeath()) ? 0 : damageNumber;


      if (__instance.health - localDamage <= 0 && !__instance.criticallyInjured && localDamage < 50)
      {
        newHealth = 5;
      }
      else
      {
        newHealth = Mathf.Clamp(__instance.health - localDamage, 0, 100);
      }

      bool isLethal = startHealth > 0 && newHealth <= 0 && startHealth != newHealth;

      if (!isLethal)
      {
        Plugin.sendWS("PlayerDamage");
        if (causeOfDeath == CauseOfDeath.Bludgeoning) Plugin.sendWS("PlayerDamage_Shovel");
      }
    }
  }
}