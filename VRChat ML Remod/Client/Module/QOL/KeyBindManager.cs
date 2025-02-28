using UnityEngine;

namespace DeepCore.Client.Module.QOL
{
    internal class KeyBindManager
    {
        public static void OnUpdate()
        {
            if (ConfManager.FlyKeyBind.Value)
            {
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F))
                {
                    Movement.Flight.FlyToggle();
                }
            }
            if (Visual.FlipScreen.IsEnabled)
            {
                Visual.FlipScreen.OnUpdate();
            }
        }
    }
}
