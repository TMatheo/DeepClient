﻿using System;
using UnityEngine;
using VRC.Localization;
using Il2CppSystem.Collections.Generic;
using TMPro;

namespace DeepClient.Client.Misc
{
    internal class PopupHelper
    {
        public static void AlertPopup(string tittle, string content, int time)
        {
            VRCUiPopupManager.prop_MonoBehaviourPublicObBoObObObObObObObObUnique_0.Method_Public_Void_LocalizableString_LocalizableString_Single_0(LocalizableStringExtensions.Localize(tittle, null, null, null), LocalizableStringExtensions.Localize(content, null, null, null), time);
        }
        public static void PopupCall(string T, string S, string BT, bool IsNumpad, Action<string> onUserInputAction = null)
        {
            LocalizableString Tittle = LocalizableStringExtensions.Localize(T, null, null, null);
            LocalizableString Sub = LocalizableStringExtensions.Localize(S, null, null, null);
            LocalizableString ntg = LocalizableStringExtensions.Localize("", null, null, null);
            LocalizableString BText = LocalizableStringExtensions.Localize(BT, null, null, null);
            Action<string, List<KeyCode>, TextMeshProUGUIEx> action = (userInput, keyCodes, textComponent) =>
            {
                if (onUserInputAction != null)
                {
                    onUserInputAction(userInput);
                }
                else
                {
                }
            };
            Il2CppSystem.Action<string, List<KeyCode>, TextMeshProUGUIEx> logInputAction = action;
            Action action1 = () =>
            {
            };
            Il2CppSystem.Action onCloseAction = action1;
            VRCUiPopupManager.prop_MonoBehaviourPublicObBoObObObObObObObObUnique_0.Method_Public_Void_LocalizableString_LocalizableString_InputType_Boolean_LocalizableString_Action_3_String_List_1_KeyCode_TextMeshProUGUIPublicLo_l1LaLo_cStLoUnique_Action_LocalizableString_Boolean_Action_1_MonoBehaviour1PublicObImObBuSiAcSiCoBoSiUnique_Boolean_Int32_0(
            Tittle, ntg, TMP_InputField.InputType.Standard, IsNumpad, BText, logInputAction, onCloseAction, Sub, true, null, false, 0
            );
        }
    }
}
