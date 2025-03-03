﻿using UnityEngine.Networking;
using UnityEngine;
using System.IO;
using System.Collections;
using DeepClient.Client.Misc.DeepClient.Client.Misc;

namespace DeepClient.Client.Coroutines
{
    internal class CustomLoadingAudios
    {
        public static AudioClip clip;
        public static IEnumerator Init()
        {
            while (GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound") == null)
            {
                yield return null;
            }
            string path = Path.Combine(Directory.CreateDirectory("DeepClient/LoadingMusic").FullName, "LoginScreenMusic.ogg");
            if (!File.Exists(path))
            {
                var download = new UnityWebRequest("https://github.com/TMatheo/FileHost/raw/refs/heads/main/DeepClient/LoginScreenMusic.ogg", UnityWebRequest.kHttpVerbGET);
                download.downloadHandler = new DownloadHandlerFile(path);
                yield return download.SendWebRequest();
            }
            UnityWebRequest localfile = UnityWebRequest.Get("file://" + path);
            yield return localfile.SendWebRequest();
            clip = WebRequestWWW.InternalCreateAudioClipUsingDH(localfile.downloadHandler, localfile.url, false, false, 0);
            AudioSource musicObj = GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound").GetComponent<AudioSource>();
            while (GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound") == null) yield return new WaitForEndOfFrame();
            musicObj.clip = clip;
            musicObj.volume = 100;
            musicObj.Play();
            if (false)
            {
                musicObj.gameObject.SetActive(false);
            }
            MInit().Start();
            yield break;
        }
        public static IEnumerator MInit()
        {
            while (GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSound") == null)
            {
                yield return null;
            }
            yield return new WaitForSeconds(2);
            GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSound").SetActive(false);
            new GameObject("LoadingSounds").transform.parent = GameObject.Find("MenuContent/Popups/LoadingPopup/").transform;
            GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSounds").AddComponent<AudioSource>();
            GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSounds").GetComponent<AudioSource>().loop = true;
            string path = Path.Combine(Directory.CreateDirectory("DeepClient/LoadingMusic").FullName, "LoginScreenMusic.ogg");
            if (!File.Exists(path))
            {
                var download = new UnityWebRequest("https://github.com/TMatheo/FileHost/raw/refs/heads/main/DeepClient/LoginScreenMusic.ogg", UnityWebRequest.kHttpVerbGET);
                download.downloadHandler = new DownloadHandlerFile(path);
                yield return download.SendWebRequest();
            }
            UnityWebRequest localfile = UnityWebRequest.Get("file://" + path);
            yield return localfile.SendWebRequest();
            clip = WebRequestWWW.InternalCreateAudioClipUsingDH(localfile.downloadHandler, localfile.url, false, false, 0);
            AudioSource musicObj = GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSounds").GetComponent<AudioSource>();
            while (GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSounds") == null) yield return new WaitForEndOfFrame();
            musicObj.clip = clip;
            musicObj.volume = 100;
            musicObj.Play();
            if (false)
            {
                musicObj.gameObject.SetActive(false);
            }
            yield break;
        }
    }
}