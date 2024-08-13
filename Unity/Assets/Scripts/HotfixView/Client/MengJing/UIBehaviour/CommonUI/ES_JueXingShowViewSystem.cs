using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_JueXingShow))]
    [FriendOfAttribute(typeof(ES_JueXingShow))]
    public static partial class ES_JueXingShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JueXingShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonActiveButton.AddListenerAsync(self.OnButtonActiveButton);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_JueXingShow self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_JueXingShow self)
        {
            int occtweo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
            if (occtweo == 0)
            {
                return;
            }

            OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtweo);
            int[] juexingids = occupationConfig.JueXingSkill;

            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_0);
            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_1);
            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_2);
            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_3);
            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_4);
            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_5);
            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_6);
            self.UIJueXingShowItems.Add(self.ES_JueXingShowItem_7);

            for (int i = 0; i < juexingids.Length; i++)
            {
                self.UIJueXingShowItems[i].OnInitUI(self.OnClickHandler, juexingids[i]);
            }

            self.UIJueXingShowItems[0].OnClickImageIcon();
        }

        public static async ETTask OnButtonActiveButton(this ES_JueXingShow self)
        {
            if (self.JueXingId == 0)
            {
                return;
            }

            long instanceid = self.InstanceId;

            int error = await SkillNetHelper.SkillJueXingRequest(self.Root(), self.JueXingId);
            if (instanceid != self.InstanceId || error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnClickHandler(self.JueXingId);
            for (int i = 0; i < self.UIJueXingShowItems.Count; i++)
            {
                self.UIJueXingShowItems[i].OnUpdateUI();
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            unit.GetComponent<UIPlayerHpComponent>()?.ShowJueXingAnger();
        }

        public static void OnClickHandler(this ES_JueXingShow self, int juexingid)
        {
            self.JueXingId = juexingid;
            for (int i = 0; i < self.UIJueXingShowItems.Count; i++)
            {
                self.UIJueXingShowItems[i].SetSelected(juexingid);
            }

            OccupationJueXingConfig occupationJueXingConfig = OccupationJueXingConfigCategory.Instance.Get(juexingid);
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(juexingid);

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageSkillIconImage.sprite = sp;

            using (zstring.Block())
            {
                self.E_Text_GoldText.text = zstring.Format("消耗：{0}金币", occupationJueXingConfig.costGold);
            }

            self.E_TextSkillNameText.GetComponentInChildren<Text>().text = skillConfig.SkillName;

            self.E_Text_11Text.text = skillConfig.SkillDescribe;

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int juexingexp = numericComponent.GetAsInt(NumericType.JueXingExp);

            float value = 1f * juexingexp / occupationJueXingConfig.costExp;
            value = Math.Max(value, 1f);

            using (zstring.Block())
            {
                self.E_Text_JueXingExpText.text = zstring.Format("{0}/{1}", juexingexp, occupationJueXingConfig.costExp);
            }

            self.E_ImageJueXingExpImage.fillAmount = Math.Min(value, 1f);

            self.ES_CostList.Refresh(occupationJueXingConfig.costItem);

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            self.E_ButtonActiveButton.gameObject.SetActive(skillSetComponent.GetBySkillID(juexingid) == null);
        }
    }
}
