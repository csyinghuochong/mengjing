using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_SettingGuaJi))]
    [FriendOfAttribute(typeof (ES_SettingGuaJi))]
    public static partial class ES_SettingGuaJiSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SettingGuaJi self, Transform transform)
        {
            self.uiTransform = transform;

            self.EG_SkillIconItemRectTransform.gameObject.SetActive(false);

            self.E_Btn_EditSkillButton.AddListenerAsync(self.OnBtn_EditSkillButton);
            self.E_Btn_StartGuajIButton.AddListener(self.OnBtn_StartGuajIButton);
            self.E_Btn_StopGuaJiButton.AddListener(self.OnBtn_StopGuaJiButton);
            self.E_Btn_Click_0Button.AddListener(self.OnBtn_Click_0Button);
            self.E_Btn_GuaJiRangeButton.AddListener(self.OnBtn_GuaJiRangeButton);
            self.E_Btn_GuaJiAutoUseItemButton.AddListener(self.OnBtn_GuaJiAutoUseItemButton);

            self.Init();
            self.UpdateGuaJiSell();
            self.UpdateGuaJiRange();
            self.UpdateGuaJiAutoUseItem();
            self.UpdataSkillSet();
        }

        [EntitySystem]
        private static void Destroy(this ES_SettingGuaJi self)
        {
            self.DestroyWidget();
        }

        public static void Init(this ES_SettingGuaJi self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            List<KeyValuePair> gameSettingInfos = userInfoComponent.UserInfo.GameSettingInfos;
            bool ifHaveGuaJiSell = false;
            bool ifHaveGuaJiRang = false;
            bool ifHaveGuaJiAutoUseItem = false;
            for (int i = 0; i < gameSettingInfos.Count; i++)
            {
                if (gameSettingInfos[i].KeyId == (int)GameSettingEnum.GuaJiSell)
                {
                    ifHaveGuaJiSell = true;
                    break;
                }

                if (gameSettingInfos[i].KeyId == (int)GameSettingEnum.GuaJiRang)
                {
                    ifHaveGuaJiRang = true;
                    break;
                }

                if (gameSettingInfos[i].KeyId == (int)GameSettingEnum.GuaJiAutoUseItem)
                {
                    ifHaveGuaJiAutoUseItem = true;
                    break;
                }
            }

            //找到没有的键值进行保存
            if (ifHaveGuaJiSell == false)
            {
                KeyValuePair pair = new();
                pair.KeyId = (int)GameSettingEnum.GuaJiSell;
                pair.Value = "0";
                pair.Value2 = "0";
                userInfoComponent.UserInfo.GameSettingInfos.Add(pair);
            }

            if (ifHaveGuaJiRang == false)
            {
                KeyValuePair pair = new();
                pair.KeyId = (int)GameSettingEnum.GuaJiRang;
                pair.Value = "0";
                pair.Value2 = "0";
                userInfoComponent.UserInfo.GameSettingInfos.Add(pair);
            }

            if (ifHaveGuaJiAutoUseItem == false)
            {
                KeyValuePair pair = new();
                pair.KeyId = (int)GameSettingEnum.GuaJiAutoUseItem;
                pair.Value = "0";
                pair.Value2 = "0";
                userInfoComponent.UserInfo.GameSettingInfos.Add(pair);
            }

            int childCount = self.EG_SkillIPositionSetRectTransform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.EG_SkillIconItemRectTransform.gameObject);
                go.SetActive(false);
                CommonViewHelper.SetParent(go, self.EG_SkillIPositionSetRectTransform.GetChild(i).gameObject);
                self.SkillSetIconRightList.Add(go);
            }
        }

        public static async ETTask OnBtn_EditSkillButton(this ES_SettingGuaJi self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SettingSkill);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSettingSkill>().CloseAction = self.UpdataSkillSet;
        }

        public static void UpdataSkillSet(this ES_SettingGuaJi self)
        {
            self.SkillSet.Clear();
            string[] skillIndexs = self.Root().GetComponent<UserInfoComponentC>().GetGameSettingValue(GameSettingEnum.GuaJiAutoUseSkill)
                    .Split('@');
            if (skillIndexs.Length > 0)
            {
                foreach (string skill in skillIndexs)
                {
                    if (skill == "")
                    {
                        continue;
                    }

                    self.SkillSet.Add(int.Parse(skill));
                }
            }

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.SkillSetIconRightList.Count; i++)
            {
                GameObject itemgo = self.SkillSetIconRightList[i];
                GameObject addImage = itemgo.transform.parent.GetChild(0).gameObject;

                itemgo.SetActive(false);
                addImage.GetComponent<Image>().fillAmount = 1;

                if (i >= self.SkillSet.Count)
                {
                    continue;
                }

                if (self.SkillSet[i] == -1)
                {
                    continue;
                }

                SkillPro skillPro = skillSetComponent.GetByPosition(self.SkillSet[i] + 1);

                if (skillPro == null)
                {
                    addImage.GetComponent<Image>().fillAmount = 1;
                    itemgo.SetActive(false);
                    continue;
                }

                addImage.GetComponent<Image>().fillAmount = 0;
                itemgo.SetActive(true);
                if (skillPro.SkillSetType == SkillSetEnum.Skill)
                {
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(SkillHelp.GetWeaponSkill(skillPro.SkillID,
                        UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList));
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    itemgo.transform.Find("Img_Mask/Img_SkillIcon").GetComponent<Image>().sprite = sp;
                }
            }
        }

        public static void OnBtn_StartGuajIButton(this ES_SettingGuaJi self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.LocalDungeon)
            {
                FlyTipComponent.Instance.ShowFlyTip("当前地图不能挂机!");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.Root().GetComponent<UserInfoComponentC>().UserInfo.PiLao <= 0)
            {
                if (self.Root().GetComponent<UnitGuaJiComponent>() != null)
                {
                    self.Root().RemoveComponent<UnitGuaJiComponent>();
                }

                FlyTipComponent.Instance.ShowFlyTip("体力已经消耗完毕，请确保体力充足喔!");
                return;
            }

            if (unit.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv < 12)
            {
                FlyTipComponent.Instance.ShowFlyTip("达到12级才能挂机哦!");
                return;
            }

            if (self.Root().GetComponent<UnitGuaJiComponent>() == null)
            {
                self.Root().AddComponent<UnitGuaJiComponent>();
                FlyTipComponent.Instance.ShowFlyTip("开始挂机!");
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTip("当前正在挂机，请确保周围是怪物刷新点!");
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Setting);
        }

        public static void OnBtn_StopGuaJiButton(this ES_SettingGuaJi self)
        {
            if (self.Root().GetComponent<UnitGuaJiComponent>() != null)
            {
                self.Root().RemoveComponent<UnitGuaJiComponent>();
                FlyTipComponent.Instance.ShowFlyTip("取消挂机!");
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.EG_GuaJiSetRectTransform.gameObject.SetActive(false);
        }

        public static void OnBtn_Click_0Button(this ES_SettingGuaJi self)
        {
            string acttype = self.Root().GetComponent<UserInfoComponentC>().GetGameSettingValue(GameSettingEnum.GuaJiSell);
            acttype = acttype == "0"? "1" : "0";

            List<KeyValuePair> gameSettingInfos = self.Root().GetComponent<UserInfoComponentC>().UserInfo.GameSettingInfos;

            for (int i = 0; i < gameSettingInfos.Count; i++)
            {
                if (gameSettingInfos[i].KeyId == (int)GameSettingEnum.GuaJiSell)
                {
                    gameSettingInfos[i].Value = acttype;
                    break;
                }
            }

            self.SetSettingValueToLocal(GameSettingEnum.GuaJiSell.ToString(), acttype);

            self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(gameSettingInfos);
            self.UpdateGuaJiSell();
        }

        public static void OnBtn_GuaJiRangeButton(this ES_SettingGuaJi self)
        {
            string acttype = self.Root().GetComponent<UserInfoComponentC>().GetGameSettingValue(GameSettingEnum.GuaJiRang);
            if (acttype == "0")
            {
                acttype = "1";
            }
            else
            {
                acttype = "0";
            }

            List<KeyValuePair> gameSettingInfos = self.Root().GetComponent<UserInfoComponentC>().UserInfo.GameSettingInfos;

            for (int i = 0; i < gameSettingInfos.Count; i++)
            {
                if (gameSettingInfos[i].KeyId == (int)GameSettingEnum.GuaJiRang)
                {
                    gameSettingInfos[i].Value = acttype;
                    break;
                }
            }

            self.SetSettingValueToLocal(GameSettingEnum.GuaJiRang.ToString(), acttype);

            self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(gameSettingInfos);
            self.UpdateGuaJiRange();
        }

        public static void OnBtn_GuaJiAutoUseItemButton(this ES_SettingGuaJi self)
        {
            string acttype = self.Root().GetComponent<UserInfoComponentC>().GetGameSettingValue(GameSettingEnum.GuaJiAutoUseItem);
            if (acttype == "0")
            {
                acttype = "1";
            }
            else
            {
                acttype = "0";
            }

            List<KeyValuePair> gameSettingInfos = self.Root().GetComponent<UserInfoComponentC>().UserInfo.GameSettingInfos;

            for (int i = 0; i < gameSettingInfos.Count; i++)
            {
                if (gameSettingInfos[i].KeyId == (int)GameSettingEnum.GuaJiAutoUseItem)
                {
                    gameSettingInfos[i].Value = acttype;
                    break;
                }
            }

            self.SetSettingValueToLocal(GameSettingEnum.GuaJiAutoUseItem.ToString(), acttype);

            self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(gameSettingInfos);
            self.UpdateGuaJiAutoUseItem();
        }

        public static void UpdateGuaJiSell(this ES_SettingGuaJi self)
        {
            string value = self.GetSettingValueFromLocal(GameSettingEnum.GuaJiSell.ToString());
            foreach (KeyValuePair valuePair in self.Root().GetComponent<UserInfoComponentC>().UserInfo.GameSettingInfos)
            {
                if (valuePair.KeyId == (int)GameSettingEnum.GuaJiSell)
                {
                    valuePair.Value = value;
                }
            }

            self.E_Image_Click_0Image.gameObject.gameObject.SetActive(value != "0");
        }

        public static void UpdateGuaJiRange(this ES_SettingGuaJi self)
        {
            string value = self.GetSettingValueFromLocal(GameSettingEnum.GuaJiRang.ToString());
            foreach (KeyValuePair valuePair in self.Root().GetComponent<UserInfoComponentC>().UserInfo.GameSettingInfos)
            {
                if (valuePair.KeyId == (int)GameSettingEnum.GuaJiRang)
                {
                    valuePair.Value = value;
                }
            }

            self.E_Click_GuaJiRangeImage.gameObject.SetActive(value != "0");
        }

        public static void UpdateGuaJiAutoUseItem(this ES_SettingGuaJi self)
        {
            string value = self.GetSettingValueFromLocal(GameSettingEnum.GuaJiAutoUseItem.ToString());
            foreach (KeyValuePair valuePair in self.Root().GetComponent<UserInfoComponentC>().UserInfo.GameSettingInfos)
            {
                if (valuePair.KeyId == (int)GameSettingEnum.GuaJiAutoUseItem)
                {
                    valuePair.Value = value;
                }
            }

            self.E_Click_GuaJiAutoUseItemImage.gameObject.SetActive(value != "0");
        }

        public static string GetSettingValueFromLocal(this ES_SettingGuaJi self, string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                return PlayerPrefs.GetString(key);
            }

            return "0";
        }

        public static void SetSettingValueToLocal(this ES_SettingGuaJi self, string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
    }
}
