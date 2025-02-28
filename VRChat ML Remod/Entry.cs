using System;
using MelonLoader;
using DeepCore.Client;
using UnhollowerRuntimeLib;
using System.Linq;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.XR;

namespace DeepCore
{
    public class Entry : MelonMod
    {
        [Obsolete]
        public static bool IsBot = false;
        public static bool IsLoaded = false;
        public static bool IsInVR = false;
        public static string NumberBot = "0";
        public static string ProfileNumber = "0";

        [Obsolete]
        public override void OnInitializeMelon()
        {
            //ClientUtils.CheckIfLoadedByLoader();
            var args = Environment.GetCommandLineArgs().ToList();
            foreach (string text in args)
            {
                if (text.Contains("DCDaddyUwU"))
                {
                    IsBot = true;
                    Application.targetFrameRate = 10;
                }
                else if (text.StartsWith("--Number="))
                {
                    NumberBot = text.Replace("--Number=", "");
                }
                else if (text.StartsWith("--profile="))
                {
                    ProfileNumber = text.Replace("--profile=", "").ToLower();
                }
            }
            try
            {
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            }
            catch (Exception ex)
            {}
            StartClient();
        }
        public static void StartClient()
        {
            try
            {
                DeepConsole.Alloc();
                if (IsBot)
                {
                    Client.Module.ApplicationBot.SocketConnection.Client();
                    DeepConsole.ChangeTittle($"DeepBot - Bot:{NumberBot} - Profile:{ProfileNumber}");
                }
                ConfManager.initConfig();
                MelonPreferences.Load();
                DeepConsole.Art(IsBot);
                DeepConsole.Log("Startup", "Starting Client...");
                Client.Patching.Initpatches.Start();
                Injectories();
                QOLThings();
                Client.Coroutine.CoroutineManager.Init();
                Client.Misc.SpriteManager.LoadSprite();
                DeepConsole.Log("Startup", "Waiting for QM...");
                MelonCoroutines.Start(Client.UI.QM.Init.WaitForQM());
                IsLoaded = true;
            }
            catch (Exception ex)
            {
                DeepConsole.Log("ERROR", $"Starting Client failed: {ex.Message}");
                Client.Misc.WMessageBox.HandleInternalFailure($"Client Startup failed: {ex.Message}",true);
            }
        }
        protected static void Injectories()
        {
            DeepConsole.Log("Startup", "Starting Injectories...");
            ClassInjector.RegisterTypeInIl2Cpp<Client.Mono.CustomNameplate>();
        }
        protected static void QOLThings()
        {
            DeepConsole.Log("Startup", "Starting QOLThings...");
            Client.Module.QOL.NoSteamAtAll.Start();
            Client.Module.QOL.CoreLimiter.Start();
            if (ConfManager.BLSEnabled.Value)
            {
                Client.Module.QOL.OldLoadingScreenMod.OnApplicationStart();
            }
        }
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            Client.Module.Photon.ModerationNotice.ClearCachedData();
        }
        public override void OnUpdate()
        {
            if (IsLoaded)
            {
                Client.Module.QOL.KeyBindManager.OnUpdate();
                Client.Module.Exploits.ItemLagger.OnUpdate();
                Client.Module.Movement.Jetpack.Update();
                Client.Module.Movement.SpinBot.Update();
                Client.Module.Movement.Flight.FlyUpdate();
                Client.Module.Movement.RayCastTP.Update();
                Client.Module.Visual.OptifineZoom.Update();
                Client.Module.QOL.ThirdPersonView.Update();
                if (IsBot == true)
                {
                    Client.Module.ApplicationBot.Bot.OnUpdate();
                }
            }
        }
        public override void OnApplicationQuit()
        {
            MelonPreferences.Save();
        }
    }
}