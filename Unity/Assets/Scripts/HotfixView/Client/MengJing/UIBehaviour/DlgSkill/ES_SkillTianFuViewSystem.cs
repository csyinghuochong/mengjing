using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_SkillTianFu))]
    [FriendOfAttribute(typeof(ES_SkillTianFu))]
    public static partial class ES_SkillTianFuSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillTianFu self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TextDesc1Text.gameObject.SetActive(false);
            self.E_TitleSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_Btn_ActiveTianFuButton.AddListener(self.OnBtn_ActiveTianFuButton);

            self.E_TitleSetToggleGroup.OnSelectIndex(self.Root().GetComponent<SkillSetComponentC>().TianFuPlan);

            ReferenceCollector rc = self.uiTransform.GetComponent<ReferenceCollector>();
            self.RefreshTianFuList();
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillTianFu self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_SkillTianFu self, int index)
        {
            if (index == 0)
            {
                self.OnBtn_TianFuPlan(0).Coroutine();
            }
            else
            {
                self.OnBtn_TianFuPlan(1).Coroutine();
            }
        }

        private static async ETTask OnBtn_TianFuPlan(this ES_SkillTianFu self, int plan)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            if (skillSetComponent.TianFuPlan == plan)
            {
                return;
            }

            int error = await SkillNetHelper.TianFuPlan(self.Root(), plan);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            skillSetComponent.UpdateTianFuPlan(plan);
            self.RefreshTianFuList();

            FlyTipComponent.Instance.ShowFlyTip("已切换为当前天赋!");
        }

        public static void RefreshTianFuList(this ES_SkillTianFu self)
        {
            if (self.Items.Count == 0)
            {
                ReferenceCollector rc = self.uiTransform.GetComponent<ReferenceCollector>();
                Transform content = rc.Get<GameObject>("Content").GetComponent<Transform>();
                for (int i = 0; i < content.childCount; i++)
                {
                    Transform subTrans = content.GetChild(i);
                    ES_SkillTianFuItem item = self.AddChild<ES_SkillTianFuItem, Transform>(subTrans);
                    item.Init(i + 1);
                    self.Items.Add(item);
                }
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int tianFuType = self.Root().GetComponent<SkillSetComponentC>().TianFuPlan + 1;
            Dictionary<int, List<int>> talentList = TalentConfigCategory.Instance.GetTalentListByOcc(userInfo.Occ, tianFuType);
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            skillSetComponent.TianFuList();
            
            foreach (ES_SkillTianFuItem item in self.Items)
            {
                item.Refresh(tianFuType);
            }
        }

        public static void OnClickTianFuItem(this ES_SkillTianFu self, int tianfuId)
        {
            // self.TianFuId = tianfuId;
            //
            // TalentConfig talentConfig = TalentConfigCategory.Instance.Get(tianfuId);
            //
            // string[] descList = talentConfig.talentDes.Split(';');
            // CommonViewHelper.DestoryChild(self.EG_DescListNodeRectTransform.gameObject);
            // for (int i = 0; i < descList.Length; i++)
            // {
            //     if (string.IsNullOrEmpty(descList[i]))
            //     {
            //         continue;
            //     }
            //
            //     GameObject gameObject = UnityEngine.Object.Instantiate(self.E_TextDesc1Text.gameObject);
            //     CommonViewHelper.SetParent(gameObject, self.EG_DescListNodeRectTransform.gameObject);
            //     gameObject.SetActive(true);
            //     gameObject.GetComponent<Text>().text = descList[i];
            //     gameObject.GetComponent<Text>().text = gameObject.GetComponent<Text>().text.Replace("\\n", "\n");
            //     gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(600f, gameObject.GetComponent<Text>().preferredHeight);
            // }
            //
            // self.E_Lab_SkillNameText.text = talentConfig.Name;
            // self.E_Text_NeedLvText.text = talentConfig.LearnRoseLv.ToString();
            //
            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, talentConfig.Icon.ToString());
            // Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            //
            // self.E_TianFuIconImage.sprite = sp;
        }

        public static void OnBtn_ActiveTianFuButton(this ES_SkillTianFu self)
        {
            // int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            // TalentConfig talentConfig = TalentConfigCategory.Instance.Get(self.TianFuId);
            // if (playerLv < talentConfig.LearnRoseLv)
            // {
            //     FlyTipComponent.Instance.ShowFlyTip("等级不足！");
            //     return;
            // }
            //
            // SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            // int oldId = skillSetComponent.HaveSameTianFu(self.TianFuId);
            // if (oldId != 0 && oldId != self.TianFuId)
            // {
            //     using (zstring.Block())
            //     {
            //         PopupTipHelp.OpenPopupTip(self.Root(), "重置专精",
            //             zstring.Format("是否花费{0}金币重置专精", 50000 + talentConfig.LearnRoseLv * 100),
            //             () => { SkillNetHelper.ActiveTianFu(self.Root(), self.TianFuId).Coroutine(); }).Coroutine();
            //     }
            //
            //     return;
            // }
            //
            // SkillNetHelper.ActiveTianFu(self.Root(), self.TianFuId).Coroutine();
        }
    }
}