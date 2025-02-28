using System;
using MelonLoader;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DeepCore.Client.API
{
    internal static class LoadImage
    {
        internal static IEnumerator LoadIMGTSprite(Image Instance, string url)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            DownloadHandler downloadHandler = www.downloadHandler;
            UnityWebRequestAsyncOperation asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            bool flag = www.isHttpError || www.isNetworkError;
            if (flag)
            {
                MelonLogger.Msg(www.error);
                yield break;
            }
            Texture2D content = DownloadHandlerTexture.GetContent(www);
            Instance.sprite = (Instance.sprite = Sprite.CreateSprite(content, new Rect(0f, 0f, (float)content.width, (float)content.height), new Vector2(0f, 0f), 100000f, 1000U, 0, Vector4.zero, false, null));
            www.Dispose();
            yield break;
        }
        internal static void Loadfrombytes(this GameObject gmj, string img, bool isimage = true, Color? color = null)
        {
            gmj.Loadfrombytes(Convert.FromBase64String(img), isimage, color);
        }
        internal static void Loadfrombytes(this GameObject gmj, byte[] img, bool isimage = true, Color? color = null)
        {
            new ImageHandler(gmj, img, isimage, color);
        }
        internal class ImageHandler : IDisposable
        {
            private Image ImageComponent { get; set; }
            private Texture2D Texture2d { get; set; }
            private ImageThreeSlice ImageThreeSliceCompnent { get; set; }

            ~ImageHandler()
            {
                this.Dispose();
            }
            public void Dispose()
            {
                this.ImageComponent = null;
                this.Texture2d = null;
                this.ImageThreeSliceCompnent = null;
            }
            public ImageHandler(GameObject gmj, byte[] img, bool isimage = true, Color? color = null)
            {
                if (isimage)
                {
                    this.ImageComponent = gmj.GetComponent<Image>();
                    this.Texture2d = new Texture2D(256, 256);
                    ImageConversion.LoadImage(this.Texture2d, img);
                    this.Texture2d.Apply();
                    this.ImageComponent.sprite = Sprite.CreateSprite(this.Texture2d, new Rect(0f, 0f, (float)this.Texture2d.width, (float)this.Texture2d.height), new Vector2(0f, 0f), 100000f, 1000U, 0, Vector4.zero, false, null);
                    bool flag = color != null;
                    if (flag)
                    {
                        this.ImageComponent.color = Color.white;
                    }
                }
                else
                {
                    this.ImageThreeSliceCompnent = gmj.GetComponent<ImageThreeSlice>();
                    this.Texture2d = new Texture2D(256, 256);
                    ImageConversion.LoadImage(this.Texture2d, img);
                    this.Texture2d.Apply();
                    this.ImageThreeSliceCompnent.Method_Public_Virtual_Final_New_Void_Sprite_0(Sprite.CreateSprite(this.Texture2d, new Rect(0f, 0f, (float)this.Texture2d.width, (float)this.Texture2d.height), new Vector2(0f, 0f), 100000f, 1000U, 0, new Vector4(255f, 0f, 255f, 0f), false, null));
                    bool flag2 = color != null;
                    if (flag2)
                    {
                        this.ImageThreeSliceCompnent.color = Color.white;
                    }
                }
            }
        }
    }
}
