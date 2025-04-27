using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_SkillTianFuItem))]
    [EntitySystemOf(typeof(ES_SkillTianFu))]
    [FriendOfAttribute(typeof(ES_SkillTianFu))]
    public static partial class ES_SkillTianFuSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillTianFu self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TextDesc1Text.gameObject.SetActive(false);
            self.E_ImageSelectImage.gameObject.SetActive(false);
            self.E_TitleSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_Btn_ActiveTianFuButton.AddListenerAsync(self.OnBtn_ActiveTianFuButton);
            self.E_ReSetTianFuButton.AddListener(self.OnReSetTianFu);

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

            ES_SkillTianFuItem itemIndex = self.Items[self.Position > 0 ? self.Position - 1 : 0];
            itemIndex.OnImageIcon();
        }

        public static void OnClickTianFuItem(this ES_SkillTianFu self, int position)
        {
            self.Position = position;
            int talentType = self.Root().GetComponent<SkillSetComponentC>().TianFuPlan + 1;
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            List<KeyValuePairInt> oldtalentlist = skillSetComponent.TianFuList();
            int talentId = TalentHelpter.GetTalentIdByPosition(self.Position, oldtalentlist);

            bool active = true;
            if (talentId == 0)
            {
                active = false;
                talentId = TalentConfigCategory.Instance.GetTalentIdByPosition(userInfo.Occ, talentType, self.Position);
                if (talentId == 0)
                {
                    return;
                }
            }

            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(talentId);
            self.uiTransform.gameObject.SetActive(true);

            int curlv = 0;
            foreach (KeyValuePairInt keyValuePairInt in oldtalentlist)
            {
                if (talentId == keyValuePairInt.KeyId)
                {
                    curlv = (int)keyValuePairInt.Value;
                }
            }
            
            int maxlv = talentConfig.Lv;

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

            using (zstring.Block())
            {
                if (active)
                {
                    self.E_Lab_TianFuLevelText.text = zstring.Format("天赋等级：{0}/{1}", curlv, maxlv);
                }
                else
                {
                    self.E_Lab_TianFuLevelText.text = zstring.Format("天赋等级：{0}/{1}", 0, maxlv);
                }
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
            CommonViewHelper.SetImageGray(self.Root(), self.E_TianFuIconImage.gameObject, !active);

            ES_SkillTianFuItem itemIndex = self.Items[self.Position - 1];
            self.E_ImageSelectImage.transform.SetParent(itemIndex.uiTransform);
            self.E_ImageSelectImage.transform.localPosition = Vector3.zero;
            self.E_ImageSelectImage.gameObject.SetActive(true);
        }

        private static async ETTask OnBtn_ActiveTianFuButton(this ES_SkillTianFu self)
        {
            if (self.Position == 0)
            {
                return;
            }

            int error = await SkillNetHelper.TalentActiveRequest(self.Root(), self.Position);
            if (error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("激活成功");
                self.RefreshTianFuList();
            }
        }

        private static void OnReSetTianFu(this ES_SkillTianFu self)
        {
            if (self.Position == 0)
            {
                return;
            }

            using (zstring.Block())
            {
                string tip = zstring.Format("消耗{0}钻石可以重置天赋", GlobalValueConfigCategory.Instance.Get(139).Value.Split(';')[1]);
                PopupTipHelp.OpenPopupTip(self.Root(), "重置天赋", tip, () => { Request().Coroutine(); }).Coroutine();
            }

            return;

            async ETTask Request()
            {
                int error = await SkillNetHelper.TalentReSetRequest(self.Root());
                if (error == ErrorCode.ERR_Success)
                {
                    FlyTipComponent.Instance.ShowFlyTip("重置成功");
                    self.RefreshTianFuList();
                }
            }
        }
    }
}