using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using Websocket.Client;

namespace VNyanCommands
{
  [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
  public class Plugin : BaseUnityPlugin
  {
    private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
    public static ManualLogSource logger;
    public static WebsocketClient wsClient;

    public static ConfigEntry<string> vnyanUrl = null;
    public static ConfigEntry<string> prefix = null;

    private void StartWS()
    {
      try
      {
        var url = new Uri(vnyanUrl.Value);
        wsClient = new WebsocketClient(url)
        {
          ReconnectTimeout = TimeSpan.FromSeconds(30)
        };
        wsClient.ReconnectionHappened.Subscribe(info =>
        {
          if (info.Type == ReconnectionType.Initial) logger.LogInfo("Vnyan WebSocket started!");
          logger.LogDebug("Reconnection happened, type: " + info.Type);
        });

        wsClient.Start();
      }
      catch (Exception ex)
      {
        logger.LogError(ex.ToString());
      }
    }

    static public void sendWS(string message)
    {
      string fullMessage = $"{prefix.Value}{message}";
      logger.LogInfo($"Sending message: {fullMessage}");
      wsClient.Send(fullMessage);
    }

    private void Awake()
    {
      logger = Logger;
      vnyanUrl = Config.Bind("General", "VnyanUrl", "ws://localhost:8000/vnyan", "VNyan WebSocket server URL. It can be modified in `Menu -> Misc -> WebSockets` on VNyan");
      prefix = Config.Bind("General", "Prefix", "LC_", "Prefix added before every WS message");

      StartWS();
      logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
      harmony.PatchAll();
    }

    private void OnDestroy()
    {
      harmony.UnpatchSelf();
      wsClient.Dispose();
    }
  }
}
