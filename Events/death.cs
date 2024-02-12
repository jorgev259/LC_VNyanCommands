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
    private static void KillPlayer(PlayerControllerB __instance, CauseOfDeath causeOfDeath = CauseOfDeath.Unknown)
    {
      try
      {
        PlayerControllerB localPlayerController = StartOfRound.Instance.localPlayerController;
        if (localPlayerController != __instance) return;

        string fullMessage = $"Death_{causeOfDeath}";
        DeadBodyInfo deadBody = __instance.deadBody;

        if (deadBody != null)
        {

          if (deadBody.detachedHead)
          {
            if (deadBody.name.Contains("RagdollSpring"))
            {
              Plugin.sendWS("Death_Spring");
            }
          }

          if (deadBody?.attachedTo != null && deadBody.attachedTo.parent.name.Contains("WebHanger"))
          {
            Plugin.sendWS("Death_Spider");
          }
        }

        Plugin.sendWS("Death");
        Plugin.sendWS(fullMessage);
      }
      catch (Exception ex)
      {
        Plugin.logger.LogError("Error in PlayerControllerB.killPlayer.Postfix: " + ex);
        Plugin.logger.LogError(ex.StackTrace);
      }
    }
  }

    }
  }
}