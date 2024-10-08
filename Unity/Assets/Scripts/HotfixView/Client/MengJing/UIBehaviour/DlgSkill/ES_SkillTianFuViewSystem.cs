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

            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("切换天赋 {0}", plan));
            }
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

            foreach (ES_SkillTianFuItem item in self.Items)
            {
                item.Refresh();
            }

            ES_SkillTianFuItem item0 = self.Items[0];
            item0.OnImageIcon();
        }

        public static void OnClickTianFuItem(this ES_SkillTianFu self, int position, int talentId)
        {
            self.TalentId = talentId;

            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(talentId);

            string[] descList = talentConfig.talentDes.Split(';');
            CommonViewHelper.DestoryChild(self.EG_DescListNodeRectTransform.gameObject);
            for (int i = 0; i < descList.Length; i++)
            {
                if (string.IsNullOrEmpty(descList[i]))
                {
                    continue;
                }

                GameObject gameObject = UnityEngine.Object.Instantiate(self.E_TextDesc1Text.gameObject);
                CommonViewHelper.SetParent(gameObject, self.EG_DescListNodeRectTransform.gameObject);
                gameObject.SetActive(true);
                gameObject.GetComponent<Text>().text = descList[i];
                gameObject.GetComponent<Text>().text = gameObject.GetComponent<Text>().text.Replace("\\n", "\n");
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(600f, gameObject.GetComponent<Text>().preferredHeight);
            }

            self.E_Lab_SkillNameText.text = talentConfig.Name;

            int talentType = self.Root().GetComponent<SkillSetComponentC>().TianFuPlan + 1;
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int curlv = TalentHelpter.GetTalentCurLevel(userInfo.Occ, talentType, position, talentId);
            int maxlv = TalentHelpter.GetTalentMaxLevel(userInfo.Occ, talentType, position);
            using (zstring.Block())
            {
                self.E_Lab_TianFuLevelText.text = zstring.Format("天赋等级：{0}/{1}", curlv, maxlv);
            }

            if (curlv >= maxlv)
            {
                self.E_Btn_ActiveTianFuButton.GetComponentInChildren<Text>().text = "已满级";
            }
            else
            {
                self.E_Btn_ActiveTianFuButton.GetComponentInChildren<Text>().text = "激活";
            }

            self.E_Text_NeedLvText.text = talentConfig.LearnRoseLv.ToString();

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, talentConfig.Icon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_TianFuIconImage.sprite = sp;
        }

        private static void OnBtn_ActiveTianFuButton(this ES_SkillTianFu self)
        {
            if (self.TalentId == 0)
            {
                return;
            }

            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(self.TalentId);
            SkillNetHelper.TalentActiveRequest(self.Root(), talentConfig.Position).Coroutine();
        }
    }
}