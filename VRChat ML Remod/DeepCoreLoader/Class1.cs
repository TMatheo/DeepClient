using System.Net.Http;
using System;
using MelonLoader;
using System.IO;
using System.Reflection;

namespace DeepCoreLoader
{
    public class Main : MelonPlugin
    {
        public override void OnPreModsLoaded()
        {
            string path = MelonUtils.BaseDirectory + "\\Mods\\DeepCore.dll";
            bool flag = File.Exists(path);
            if (flag)
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                }
            }
            _dllBytes = (this.DownloadMod(this._downloadUrl) ?? null);
            MelonLogger.Msg((_dllBytes != null) ? "Successfully loaded to memory" : "Failed to load in memory");
        }
        private byte[] DownloadMod(string downloadUrl)
        {
            byte[] result2;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage result = httpClient.GetAsync(downloadUrl).Result;
                    result.EnsureSuccessStatusCode();
                    result2 = result.Content.ReadAsByteArrayAsync().Result;
                }
                catch (Exception ex)
                {
                    MelonLogger.Error("Error downloading DeepCore: " + ex.Message);
                    result2 = null;
                }
            }
            return result2;
        }
        public override void OnApplicationStart()
        {
            bool flag = _dllBytes != null;
            if (flag)
            {
                try
                {
                    MelonHandler.LoadFromAssembly(Assembly.Load(_dllBytes), null);
                    return;
                }
                catch (Exception ex)
                {
                    MelonLogger.Error("Failed to load DeepCore: " + ex.Message);
                    return;
                }
            }
            MelonLogger.Error("DeepCore download failed or is null.");
        }
        private static byte[] _dllBytes;
        private string _downloadUrl = "https://github.com/TMatheo/FileHost/raw/refs/heads/main/DeepClient/DeepCore.dll";
    }
}