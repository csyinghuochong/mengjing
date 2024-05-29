using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRolePetBag))]
    public static class DlgRolePetBagSystem
    {
        public static void RegisterUIEvent(this DlgRolePetBag self)
        {
            self.View.E_PetTuJianItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetTuJianItemsRefresh);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
        }

        public static void ShowWindow(this DlgRolePetBag self, Entity contextData = null)
        {
            self.PetZiZhiItemList[0] = self.View.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.View.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.View.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.View.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.View.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.View.EG_PetZiZhiItem6RectTransform.gameObject;

            foreach (GameObject go in self.PetZiZhiItemList)
            {
                go.SetActive(false);
            }

            self.View.E_TakeOutBagBtnButton.AddListenerAsync(self.OnTakeOutBagBtn);
            self.View.E_FenjieBtnButton.AddListenerAsync(self.OnFenjieBtn);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);

            self.OnUpdatePetList();
        }

        private static void OnCommonSkillItemsRefresh(this DlgRolePetBag self, Transform transform, int index)
        {
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdateUI(self.ShowSkill[index], ABAtlasTypes.PetSkillIcon);
        }

        private static void OnPetTuJianItemsRefresh(this DlgRolePetBag self, Transform transform, int index)
        {
            Scroll_Item_PetTuJianItem scrollItemPetTuJianItem = self.ScrollItemPetTuJianItems[index].BindTrans(transform);
            scrollItemPetTuJianItem.OnUpdateUI(self.ShowSkill[index], ABAtlasTypes.PetSkillIcon);
            scrollItemPetTuJianItem.OnInitUI(self.ShowRolePetInfos[index]);
            scrollItemPetTuJianItem.SetClickHandler((petId) => { self.OnClickPetHandler(petId); });
        }

        public static async ETTask OnTakeOutBagBtn(this DlgRolePetBag self)
        {
            if (self.RolePetInfo == null)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("未选中宠物");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int maxNum = PetHelper.GetPetMaxNumber(self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv, userInfo.Lv);
            if (PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos) >= maxNum)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("已达到宠物最大数量");
                return;
            }

            int error = await PetNetHelper.RequestPetTakeOutBag(self.Root(), self.RolePetInfo.Id);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdatePetList();
        }

        public static async ETTask OnFenjieBtn(this DlgRolePetBag self)
        {
            if (self.RolePetInfo == null)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("未选中宠物");
                return;
            }

            int error = await PetNetHelper.RequestRolePetFenjie(self.Root(), self.RolePetInfo.Id);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdatePetList();
        }

        public static void OnBtn_Close(this DlgRolePetBag self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RolePetBag);
        }

        public static void OnUpdatePetList(this DlgRolePetBag self)
        {
            self.RolePetInfo = null;

            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetBag;

            self.ShowRolePetInfos.Clear();
            self.ShowRolePetInfos.AddRange(rolePetInfos);
            int num = 0;
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                UIRolePetBagItemComponent itemComponent = null;

                if (i < self.UIRolePetBagItemComponents.Count)
                {
                    itemComponent = self.UIRolePetBagItemComponents[i];
                    itemComponent.GameObject.SetActive(true);
                }
                else
                {
                    GameObject go = UnityEngine.Object.Instantiate(self.UIRolePetBagItem);
                    itemComponent = self.AddChild<UIRolePetBagItemComponent, GameObject>(go);
                    self.UIRolePetBagItemComponents.Add(itemComponent);
                    UICommonHelper.SetParent(go, self.PetListNode);
                    go.SetActive(true);
                }

                itemComponent.OnInitUI(rolePetInfos[i]);
                itemComponent.SetClickHandler((petId) => { self.OnClickPetHandler(petId); });
                num++;
            }

            for (int i = num; i < self.UIRolePetBagItemComponents.Count; i++)
            {
                self.UIRolePetBagItemComponents[i].GameObject.SetActive(false);
            }

            if (num > 0)
            {
                foreach (GameObject go in self.PetZiZhiItemList)
                {
                    go.SetActive(true);
                }

                self.UIRolePetBagItemComponents[0].OnImage_ItemButton();
            }

            self.View.E_TextNumberText.text = $"宠物数量： {rolePetInfos.Count}/{GlobalValueConfigCategory.Instance.Get(119).Value2}";
        }

        public static void OnClickPetHandler(this DlgRolePetBag self, RolePetInfo rolePetInfo)
        {
            self.RolePetInfo = rolePetInfo;

            for (int i = 0; i < self.UIRolePetBagItemComponents.Count; i++)
            {
                self.UIRolePetBagItemComponents[i].SetSelected(rolePetInfo.Id);
            }

            self.UpdatePetZizhi(rolePetInfo);
            self.UpdateSkillList(rolePetInfo);
        }

        public static void UpdatePetZizhi(this DlgRolePetBag self, RolePetInfo rolePetInfo)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Hp}/{petConfig.ZiZhi_Hp_Max}";
            self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Act}/{petConfig.ZiZhi_Act_Max}";
            self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Def}/{petConfig.ZiZhi_Def_Max}";
            self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Adf}/{petConfig.ZiZhi_Adf_Max}";
            self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_MageAct}/{petConfig.ZiZhi_MageAct_Max}";
            self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{UICommonHelper.ShowFloatValue(rolePetInfo.ZiZhi_ChengZhang)}/{UICommonHelper.ShowFloatValue((float)petConfig.ZiZhi_ChengZhang_Max)}";

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            Sprite sprite16 = resourcesLoaderComponent.LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_16.png");
            Sprite sprite17 = resourcesLoaderComponent.LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_17.png");

            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Hp >= petConfig.ZiZhi_Hp_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Hp / (float)petConfig.ZiZhi_Hp_Max, 0f, 1f);

            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Act >= petConfig.ZiZhi_Act_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Act / (float)petConfig.ZiZhi_Act_Max, 0f, 1f);

            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Def >= petConfig.ZiZhi_Def_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Def / (float)petConfig.ZiZhi_Def_Max, 0f, 1f);

            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Adf >= petConfig.ZiZhi_Adf_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Adf / (float)petConfig.ZiZhi_Adf_Max, 0f, 1f);

            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_MageAct >= petConfig.ZiZhi_MageAct_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_MageAct / (float)petConfig.ZiZhi_MageAct_Max, 0f, 1f);

            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_ChengZhang >= petConfig.ZiZhi_ChengZhang_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_ChengZhang / (float)petConfig.ZiZhi_ChengZhang_Max, 0f, 1f);
        }

        public static void UpdateSkillList(this DlgRolePetBag self, RolePetInfo rolePetInfo)
        {
            var path = ABPathHelper.GetUGUIPath("Main/Common/UICommonSkillItem");
            var bundleGameObject = ResourcesComponent.Instance.LoadAsset<GameObject>(path);

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            List<int> zhuanzhuids = new List<int>();
            string[] zhuanzhuskills = petConfig.ZhuanZhuSkillID.Split(';');
            for (int i = 0; i < zhuanzhuskills.Length; i++)
            {
                if (zhuanzhuskills[i].Length > 1)
                {
                    zhuanzhuids.Add(int.Parse(zhuanzhuskills[i]));
                }
            }

            List<int> skills = new List<int>();
            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                if (zhuanzhuids.Contains(rolePetInfo.PetSkill[i]))
                {
                    skills.Insert(0, rolePetInfo.PetSkill[i]);
                }
                else
                {
                    skills.Add(rolePetInfo.PetSkill[i]);
                }
            }

            for (int i = 0; i < skills.Count; i++)
            {
                UICommonSkillItemComponent ui_item = null;
                if (i < self.UICommonSkillItemComponents.Count)
                {
                    ui_item = self.UICommonSkillItemComponents[i];
                    ui_item.GameObject.SetActive(true);
                }
                else
                {
                    GameObject bagSpace = GameObject.Instantiate(bundleGameObject);
                    UICommonHelper.SetParent(bagSpace, self.PetSkillListNode);
                    ui_item = self.AddChild<UICommonSkillItemComponent, GameObject>(bagSpace);
                    self.UICommonSkillItemComponents.Add(ui_item);
                }

                ui_item.OnUpdateUI(skills[i], ABAtlasTypes.PetSkillIcon, rolePetInfo.LockSkill.Contains(skills[i]));
            }

            for (int i = skills.Count; i < self.UICommonSkillItemComponents.Count; i++)
            {
                self.UICommonSkillItemComponents[i].GameObject.SetActive(false);
            }
        }
    }
}