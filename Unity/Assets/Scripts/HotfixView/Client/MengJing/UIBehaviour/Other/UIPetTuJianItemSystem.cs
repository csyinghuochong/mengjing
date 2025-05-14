using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIPetTuJianItem))]
    [EntitySystemOf(typeof(UIPetTuJianItem))]
    public static partial class UIPetTuJianItemSystem
    {
        [EntitySystem]
        private static void Awake(this UIPetTuJianItem self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            self.E_Image_ItemButton = rc.Get<GameObject>("E_Image_ItemButton");
            self.E_Image_EventTrigger = rc.Get<GameObject>("E_Image_EventTrigger");
            self.E_Image_ItemQuality = rc.Get<GameObject>("E_Image_ItemQuality");
            self.E_Image_XuanZhong = rc.Get<GameObject>("E_Image_XuanZhong");
            self.E_Image_ItemIcon = rc.Get<GameObject>("E_Image_ItemIcon");
            self.E_Label_ItemNum = rc.Get<GameObject>("E_Label_ItemNum");
            self.E_Label_ItemName_Active = rc.Get<GameObject>("E_Label_ItemName_Active");
            self.E_Label_ItemName_InActive = rc.Get<GameObject>("E_Label_ItemName_InActive");
            self.E_Label_Active = rc.Get<GameObject>("E_Label_Active");
            self.E_Label_InActive = rc.Get<GameObject>("E_Label_InActive");
            self.E_Image_ItemButton.GetComponent<Button>().AddListener(self.OnIma_Di);
        }

        public static void Init(this UIPetTuJianItem self, int petId, Action<int> onAction)
        {
            self.PetId = petId;
            self.ClickHandler = onAction;

            PetConfig petConfig = PetConfigCategory.Instance.Get(petId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_ItemIcon.GetComponent<Image>().sprite = sp;
            self.E_Label_ItemName_Active.GetComponent<Text>().text = petConfig.PetName;
            self.E_Label_ItemName_InActive.GetComponent<Text>().text = petConfig.PetName;

            ChengJiuComponentC chengJiuComponentC = self.Root().GetComponent<ChengJiuComponentC>();
            bool isActivate = chengJiuComponentC.PetTuJianActives.Contains(petId);

            self.E_Label_ItemName_Active.SetActive(isActivate);
            self.E_Label_ItemName_InActive.SetActive(!isActivate);

            CommonViewHelper.SetImageGray(self.Root(), self.E_Image_ItemIcon.gameObject, !isActivate);
            self.E_Label_Active.SetActive(isActivate);
            self.E_Label_InActive.SetActive(!isActivate);

            self.E_Image_XuanZhong.gameObject.SetActive(false);
        }

        public static void OnIma_Di(this UIPetTuJianItem self)
        {
            self.ClickHandler?.Invoke(self.PetId);
        }

        public static void SetSelected(this UIPetTuJianItem self, int petid)
        {
            self.E_Image_XuanZhong.gameObject.SetActive(self.PetId == petid);
        }
    }
}