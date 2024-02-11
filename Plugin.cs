using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using Websocket.Client;

namespace LC_VNyanCommands
{
  [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
  public class Plugin : BaseUnityPlugin
  {
    private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
    public static ManualLogSource logger;
    public static WebsocketClient wsClient;

    public static ConfigEntry<string> vnyanUrl = null;

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

    private void Awake()
    {
      logger = Logger;
      vnyanUrl = Config.Bind("General", "Vnyan Url", "ws://localhost:8000/vnyan", "VNyan WebSocket server URL. It can be modified in `Menu -> Misc -> WebSockets` on VNyan");

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
