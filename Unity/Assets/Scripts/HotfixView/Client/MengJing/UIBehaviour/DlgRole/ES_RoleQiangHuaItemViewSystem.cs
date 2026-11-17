using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_RoleQiangHuaItem))]
    [FriendOfAttribute(typeof(ES_RoleQiangHuaItem))]
    public static partial class ES_RoleQiangHuaItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleQiangHuaItem self, Transform transform)
        {
            self.Image_EquipIconImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "Image_EquipIcon");
            self.Image_SelectImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "Image_Select");
            self.Text_QiangHuaText = UIFindHelper.FindDeepChild<Text>(transform.gameObject, "Text_QiangHua");
            Button equipButton = UIFindHelper.FindDeepChild<Button>(transform.gameObject, "Button_Equip");
            equipButton.AddListener(self.OnEquipButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleQiangHuaItem self)
        {
            self.Image_EquipIconImage = null;
            self.Image_SelectImage = null;
            self.Text_QiangHuaText = null;
            self.ClickHandler = null;
        }

        public static void OnEquipButton(this ES_RoleQiangHuaItem self)
        {
            self.ClickHandler(self.ItemSubType);
        }

        public static void SetClickHandler(this ES_RoleQiangHuaItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnUpdateUI(this ES_RoleQiangHuaItem self, int qianghuaLevel)
        {
            self.Text_QiangHuaText.text = $"+{qianghuaLevel}";
        }
    }
}
