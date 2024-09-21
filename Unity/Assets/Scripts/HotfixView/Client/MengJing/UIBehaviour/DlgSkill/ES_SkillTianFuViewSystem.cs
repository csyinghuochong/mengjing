using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SkillTianFuItem))]
    [EntitySystemOf(typeof(ES_SkillTianFu))]
    [FriendOfAttribute(typeof(ES_SkillTianFu))]
    public static partial class ES_SkillTianFuSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillTianFu self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SkillTianFuItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSkillTianFuItemsRefresh);

            self.E_TextDesc1Text.gameObject.SetActive(false);
            self.E_Btn_TianFu_2Button.AddListener(() => { self.OnBtn_TianFuPlan(1).Coroutine(); });
            self.E_Btn_TianFu_1Button.AddListener(() => { self.OnBtn_TianFuPlan(0).Coroutine(); });
            self.E_Btn_ActiveTianFuButton.AddListener(self.OnBtn_ActiveTianFuButton);

            self.InitTianFuList();
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillTianFu self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnBtn_TianFuPlan(this ES_SkillTianFu self, int plan)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            if (skillSetComponent.TianFuPlan == plan)
            {
                return;
            }

            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv < 35)
            {
                FlyTipComponent.Instance.ShowFlyTip("35级开启天赋方案,可自由切换天赋!");
                return;
            }

            await SkillNetHelper.TianFuPlan(self.Root(), plan);
            skillSetComponent.UpdateTianFuPlan(plan);

            self.OnActiveTianFu();
            self.UpdatePlanButton();

            FlyTipComponent.Instance.ShowFlyTip("已切换为当前天赋!");
        }

        public static void UpdatePlanButton(this ES_SkillTianFu self)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            self.E_Btn_TianFu_1Button.transform.Find("Image").gameObject.SetActive(skillSetComponent.TianFuPlan == 0);
            self.E_Btn_TianFu_2Button.transform.Find("Image").gameObject.SetActive(skillSetComponent.TianFuPlan == 1);
        }

        public static void InitTianFuList(this ES_SkillTianFu self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int occTwo = OccupationConfigCategory.Instance.Get(userInfo.Occ).OccTwoID[0];
            //int occTwo = userInfo.OccTwo;
            //if (occTwo == 0)
            //{
            //    //战士天赋
            //    occTwo = 101;

            //    //法师天赋
            //    if (userInfo.Occ == 2)
            //    {
            //        occTwo = 201;
            //    }
            //    //猎人天赋
            //    if (userInfo.Occ == 3)
            //    {
            //        occTwo = 301;
            //    }
            //}
            Dictionary<int, List<int>> TianFuToLevel = new Dictionary<int, List<int>>();
            //int[] TalentList = OccupationTwoConfigCategory.Instance.Get(occTwo).Talent;
            
            int[] TalentList = new int[]{};
            for (int i = 0; i < TalentList.Length; i++)
            {
                int talentId = TalentList[i];
                TalentConfig talentConfig = TalentConfigCategory.Instance.Get(talentId);
                if (!TianFuToLevel.ContainsKey(talentConfig.LearnRoseLv))
                {
                    TianFuToLevel.Add(talentConfig.LearnRoseLv, new List<int>());
                }

                TianFuToLevel[talentConfig.LearnRoseLv].Add(talentId);
            }

            self.ShowTianFu.Clear();
            foreach (var item in TianFuToLevel)
            {
                self.ShowTianFu.Add(item.Value);
            }

            self.AddUIScrollItems(ref self.ScrollItemSkillTianFuItems, self.ShowTianFu.Count);
            self.E_SkillTianFuItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTianFu.Count);

            self.OnActiveTianFu();
            self.UpdatePlanButton();

            Scroll_Item_SkillTianFuItem scrollItemSkillTianFuItem = self.ScrollItemSkillTianFuItems[0];
            scrollItemSkillTianFuItem.OnClickTianFu(0);
        }

        private static void OnSkillTianFuItemsRefresh(this ES_SkillTianFu self, Transform transform, int index)
        {
            Scroll_Item_SkillTianFuItem scrollItemSkillTianFuItem = self.ScrollItemSkillTianFuItems[index].BindTrans(transform);
            scrollItemSkillTianFuItem.SetClickHanlder((int tid) => { self.OnClickTianFuItem(tid); });
            scrollItemSkillTianFuItem.InitTianFuList(self.ShowTianFu[index]);
        }

        public static void OnActiveTianFu(this ES_SkillTianFu self)
        {
            for (int i = 0; i < self.ScrollItemSkillTianFuItems.Count; i++)
            {
                Scroll_Item_SkillTianFuItem scrollItemSkillTianFuItem = self.ScrollItemSkillTianFuItems[i];
                if (scrollItemSkillTianFuItem.uiTransform != null)
                {
                    scrollItemSkillTianFuItem.OnActiveTianFu();
                }
            }
        }

        public static void OnClickTianFuItem(this ES_SkillTianFu self, int tianfuId)
        {
            self.TianFuId = tianfuId;

            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(tianfuId);

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
            self.E_Text_NeedLvText.text = talentConfig.LearnRoseLv.ToString();

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, talentConfig.Icon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_TianFuIconImage.sprite = sp;

            for (int i = 0; i < self.ScrollItemSkillTianFuItems.Count; i++)
            {
                Scroll_Item_SkillTianFuItem scrollItemSkillTianFuItem = self.ScrollItemSkillTianFuItems[i];

                if (scrollItemSkillTianFuItem.uiTransform == null)
                {
                    continue;
                }

                Scroll_Item_SkillTianFuItem uISkillTianFuItem = self.ScrollItemSkillTianFuItems[i];
                List<int> TianFuList = uISkillTianFuItem.TianFuList;
                int index = TianFuList.IndexOf(tianfuId);
                if (index >= 0)
                {
                    self.E_ImageSelectImage.gameObject.SetActive(true);
                    CommonViewHelper.SetParent(self.E_ImageSelectImage.gameObject, uISkillTianFuItem.GetKuangByIndex(index));
                }
            }
        }

        public static void OnBtn_ActiveTianFuButton(this ES_SkillTianFu self)
        {
            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(self.TianFuId);
            if (playerLv < talentConfig.LearnRoseLv)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            int oldId = skillSetComponent.HaveSameTianFu(self.TianFuId);
            if (oldId != 0 && oldId != self.TianFuId)
            {
                // GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(48);
                // string itemdesc = UICommonHelper.GetNeedItemDesc(globalValueConfig.Value);
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "重置专精",
                        zstring.Format("是否花费{0}金币重置专精", 50000 + talentConfig.LearnRoseLv * 100),
                        () => { SkillNetHelper.ActiveTianFu(self.Root(), self.TianFuId).Coroutine(); }).Coroutine();
                }

                return;
            }

            SkillNetHelper.ActiveTianFu(self.Root(), self.TianFuId).Coroutine();
        }
    }
}
