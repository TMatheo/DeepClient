using UnityEngine;
using VRC.SDKBase;

namespace DeepClient.Client.Module.Visuals
{
    internal class OptifineZoom
    {
        public static bool IsEnabled = false;
        public static void Update()
        {
            if (IsEnabled)
            {
                if (Networking.LocalPlayer != null)
                {
                    if (Input.GetKey(KeyCode.LeftAlt))
                    {
                        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 10, Time.deltaTime * 5f);
                    }
                    else
                    {
                        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime * 5f);
                    }
                }
            }
        }
    }
}
