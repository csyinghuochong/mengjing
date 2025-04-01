using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ZuoQiShowItem))]
    [EntitySystemOf(typeof (Scroll_Item_ZuoQiShowItem))]
    public static partial class Scroll_Item_ZuoQiShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ZuoQiShowItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ZuoQiShowItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonFight(this Scroll_Item_ZuoQiShowItem self)
        {
            if (!self.IsHaveZuoQi(self.ZuoQiConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("请先激活当前坐骑！");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (self.ZuoQiConfig.Id == 10001 && userInfo.Lv < 25)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级达到25级才可以骑乘坐骑喔！");
                return;
            }

            M2C_HorseFightResponse response = await BagClientNetHelper.HorseFight(self.Root(), self.ZuoQiConfig.Id);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("激活坐骑成功,清在主界面点击骑乘按钮即可喔！");
            }
        }

        public static bool IsHaveZuoQi(this Scroll_Item_ZuoQiShowItem self, int zuoqiId)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            return userInfo.HorseIds.Contains(zuoqiId);
        }

        public static void OnInitUI(this Scroll_Item_ZuoQiShowItem self, ZuoQiShowConfig zuoQiConfig)
        {
            self.E_ButtonFightButton.AddListenerAsync(self.OnButtonFight);

            self.ZuoQiConfig = zuoQiConfig;
            self.E_TextNameText.text = zuoQiConfig.Name;

            // 虚空龙的在UI上无法显示，这里暂时替换
            string modelID = zuoQiConfig.ModelID;
            if (zuoQiConfig.ModelID == "10010")
            {
                modelID = "10010Show";
            }

            // self.ES_ModelShow.ShowOtherModel("ZuoQi/" + modelID).Coroutine();
            self.ES_ModelShow.ShowOtherModel("Monster/70001001").Coroutine();
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 112f, 450f));
            // self.ES_ModelShow.SetRootPosition(new Vector2(zuoQiConfig.Id % 20 * 1000, 0));
            self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            //显示属性和来源
            self.E_LabProDesText.text = self.ZuoQiConfig.Des;
            self.E_Lab_LaiYuanText.text = self.ZuoQiConfig.GetDes;
            //获取技能Buff
            SkillBuffConfig buffCof = SkillBuffConfigCategory.Instance.Get(self.ZuoQiConfig.MoveBuffID);
            self.E_LabDesText.text = buffCof.BuffDescribe;

            CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, !self.IsHaveZuoQi(zuoQiConfig.Id));

            self.E_ButtonFightButton.gameObject.SetActive(self.IsHaveZuoQi(zuoQiConfig.Id));
            self.E_Lab_LaiYuanText.gameObject.SetActive(!self.IsHaveZuoQi(zuoQiConfig.Id));
            int quility = zuoQiConfig.Quality;
            for (int i = 0; i < self.EG_StarListRectTransform.childCount; i++)
            {
                self.EG_StarListRectTransform.GetChild(i).gameObject.SetActive(quility > i);
            }
        }
    }
}