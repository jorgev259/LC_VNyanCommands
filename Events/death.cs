using System;
using GameNetcodeStuff;
using HarmonyLib;

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

  [HarmonyPatch(typeof(BlobAI))]
  [HarmonyPatch("SlimeKillPlayerEffectClientRpc")]
  class SlimeDeath
  {
    public static void Postfix(int playerKilled)
    {
      try
      {
        PlayerControllerB localPlayerController = StartOfRound.Instance.localPlayerController;
        PlayerControllerB killedPlayerController = StartOfRound.Instance.allPlayerScripts[playerKilled];

        if (killedPlayerController == null || localPlayerController != killedPlayerController) return;
        if (killedPlayerController.isPlayerDead) Plugin.sendWS("Death_Slime");
      }
      catch (Exception ex)
      {
        Plugin.logger.LogError("Error in BlobAISlimeKillPlayerEffectServerRpcPatch.Postfix: " + ex);
        Plugin.logger.LogError(ex.StackTrace);
      }
    }
  }

    }
  }
}