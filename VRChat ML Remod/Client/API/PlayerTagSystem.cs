using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VRC;

namespace DeepCore.Client.API
{
    internal class PlayerTagSystem
    {
        public static void CheckPlayer(Player player)
        {
            if (!allowedPlayers.TryGetValue(player.field_Private_APIUser_0.id, out var playerInfo))
            {
                return;
            }
            Color myColor;
            ColorUtility.TryParseHtmlString(playerInfo.Color, out myColor);
            AddTag(playerInfo.Tag, myColor, player);
        }
        public static void AddTag(string CustomTag, Color color, Player player)
        {
            PlayerNameplate nameplate2 = player.prop_VRCPlayer_0.field_Public_PlayerNameplate_0;
            Transform transform = GameObject.Instantiate<Transform>(nameplate2.gameObject.transform.Find("Contents/Quick Stats"), nameplate2.gameObject.transform.Find("Contents"));
            transform.parent = nameplate2.gameObject.transform.Find("Contents");
            transform.gameObject.SetActive(true);
            TextMeshProUGUI component = transform.Find("Trust Text").GetComponent<TextMeshProUGUI>();
            component.color = color;
            transform.Find("Trust Icon").gameObject.SetActive(false);
            transform.Find("Performance Icon").gameObject.SetActive(false);
            transform.Find("Performance Text").gameObject.SetActive(false);
            transform.Find("Friend Anchor Stats").gameObject.SetActive(false);
            transform.name = "DC Info Tag";
            transform.gameObject.transform.localPosition = new Vector3(0f, 145f, 0f);
            transform.GetComponent<ImageThreeSlice>().color = color;
            component.text = CustomTag;
        }
        private static Dictionary<string, (string Tag, string Color)> allowedPlayers = new Dictionary<string, (string, string)>
        {
        {"usr_a7d59ec0-4e6a-4f94-ad37-972602b72958", ("DC Dev", "#570f96")},
        {"usr_fc152d76-e45a-448e-b90a-860da7ea8b3e", ("Débiteur Premium", "#00ff44")},
        {"usr_7dd8c2f2-6884-44c6-b9b2-490770b64a49", ("<size=120%>HORNY FURRY<size=90%>LTG Member", "#ff0000")},
        {"usr_f28c7d0d-2051-4bc4-9b94-03a68cb217bf", ("ERP Premium", "#00ff44")}
        };
    }
}
