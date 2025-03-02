using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;

namespace DeepClient.Client.GUI
{
    internal class MainGUI
    {
        public static void RenderMenu()
        {
            GUIStyle.RenderMenu();
            if (DearImGuiInjection.DearImGuiInjection.IsCursorVisible)
            {
                #region yay
                var io = ImGui.GetIO();
                var foregroundDrawList = ImGui.GetForegroundDrawList();
                float mouseSize = 15f;
                #endregion
                ImGui.Begin("DeepClient");
                if (ImGui.BeginTabBar("TabsBar"))
                {
                    if (ImGui.BeginTabItem("Visuals"))
                    {
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mouvements"))
                    {
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Exploits"))
                    {
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("World Hacks"))
                    {
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PlayerList"))
                    {
                        ImGui.EndTabItem();
                    }
                    ImGui.EndTabBar();
                }
                ImGui.End();
            }
        }
    }
}