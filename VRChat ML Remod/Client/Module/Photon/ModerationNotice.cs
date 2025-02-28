﻿using DeepCore.Client.Misc;
using ExitGames.Client.Photon;
using Il2CppSystem.Collections.Generic;
using VRC;

namespace DeepCore.Client.Module.Photon
{
    internal class ModerationNotice
    {
        public static List<string> knownBlocks = new List<string>();
        public static List<string> knownMutes = new List<string>();

        public static void ClearCachedData()
        {
            if (ConfManager.antiBlock.Value)
            {
                knownBlocks.Clear();
                knownMutes.Clear();
                DeepConsole.Log("AntiBlock", "Cleared cached data.");
            }
        }
        public static bool OnEventPatch(EventData __0)
        {
            bool antiBlock = ConfManager.antiBlock.Value;
            if (antiBlock)
            {
                bool flag = __0.Code == 33;
                if (flag)
                {
                    try
                    {
                        Dictionary<byte, Il2CppSystem.Object> dictionary = __0.Parameters[__0.CustomDataKey].Cast<Dictionary<byte, Il2CppSystem.Object>>();
                        byte b = dictionary[0].Unbox<byte>();
                        byte b2 = b;
                        byte b3 = b2;
                        if (b3 == 21)
                        {
                            bool flag2 = dictionary.ContainsKey(1);
                            if (flag2)
                            {
                                bool flag3 = dictionary[10].Unbox<bool>();
                                bool flag4 = dictionary[11].Unbox<bool>();
                                int id = dictionary[1].Unbox<int>();
                                Player playerNewtworkedId = VrcExtensions.GetPlayerNewtworkedId(id);
                                bool flag5 = playerNewtworkedId != null;
                                if (flag5)
                                {
                                    bool flag6 = flag3;
                                    if (flag6)
                                    {
                                        VrcExtensions.HudNotif($"{playerNewtworkedId.field_Private_APIUser_0.displayName} has blocked you.");
                                        knownBlocks.Add(playerNewtworkedId.field_Private_APIUser_0.displayName);
                                        return false;
                                    }
                                    bool flag7 = flag4;
                                    if (flag7)
                                    {
                                        VrcExtensions.HudNotif($"{playerNewtworkedId.field_Private_APIUser_0.displayName} has muted you.");
                                        knownMutes.Add(playerNewtworkedId.field_Private_APIUser_0.displayName);
                                        return false;
                                    }
                                    bool flag8 = knownMutes.Contains(playerNewtworkedId.field_Private_APIUser_0.displayName);
                                    if (flag8)
                                    {
                                        bool flag9 = playerNewtworkedId.field_Private_APIUser_0.displayName != VrcExtensions.GetLocalVRCPlayer().field_Private_VRCPlayerApi_0.displayName;
                                        if (flag9)
                                        {
                                            knownMutes.Remove(playerNewtworkedId.field_Private_APIUser_0.displayName);
                                            VrcExtensions.HudNotif($"{playerNewtworkedId.field_Private_APIUser_0.displayName} has unmuted you.");
                                        }
                                    }
                                    bool flag10 = knownBlocks.Contains(playerNewtworkedId.field_Private_APIUser_0.displayName);
                                    if (flag10)
                                    {
                                        bool flag11 = playerNewtworkedId.field_Private_APIUser_0.displayName != VrcExtensions.GetLocalVRCPlayer().field_Private_VRCPlayerApi_0.displayName;
                                        if (flag11)
                                        {
                                            knownBlocks.Remove(playerNewtworkedId.field_Private_APIUser_0.displayName);
                                            VrcExtensions.HudNotif($"{playerNewtworkedId.field_Private_APIUser_0.displayName} has unblocked you.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return true;
        }
    }
}