using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_BattleRecruitItem))]
    [EntitySystemOf(typeof(Scroll_Item_BattleRecruitItem))]
    public static partial class Scroll_Item_BattleRecruitItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_BattleRecruitItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_BattleRecruitItem self)
        {
            self.DestroyWidget();
        }

        public static void OnRecruitItemBtn(this Scroll_Item_BattleRecruitItem self)
        {
            if (self.CostGold > 0)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "战场招募", $"是否消耗{self.CostGold}金币召唤{self.BattleSummonConfig.ItemName}?",
                    () => { self.OnRecruitAction?.Invoke(self.BattleSummonConfig.Id, self.CostGold); }).Coroutine();
            }
            else
            {
                self.OnRecruitAction?.Invoke(self.BattleSummonConfig.Id, self.CostGold);
            }
        }

        public static void InitUI(this Scroll_Item_BattleRecruitItem self, BattleSummonConfig battleSummonConfig)
        {
            self.E_PropertiesText_0Text.gameObject.SetActive(false);
            self.E_PropertiesText_1Text.gameObject.SetActive(false);
            self.E_PropertiesText_2Text.gameObject.SetActive(false);
            self.E_RecruitItemBtnButton.AddListener(self.OnRecruitItemBtn);

            self.BattleSummonConfig = battleSummonConfig;
            self.CostGold = battleSummonConfig.CostGold;

            self.E_NameTextText.text = battleSummonConfig.ItemName;

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(battleSummonConfig.MonsterIds[0]);

            // self.ES_ModelShow.ShowOtherModel("Monster/" + monsterConfig.MonsterModelID).Coroutine();
            self.ES_ModelShow.ShowOtherModel("Monster/70001001").Coroutine();
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 100f, 450f));
            self.ES_ModelShow.Camera.fieldOfView = 30;
            // self.ES_ModelShow.SetRootPosition(new Vector2(1000 + 1000, 0));
            self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            //显示属性
            self.E_PropertiesText_0Text.gameObject.SetActive(true);
            self.E_PropertiesText_0Text.text = monsterConfig.Hp.ToString();

            self.E_PropertiesText_1Text.gameObject.SetActive(true);
            self.E_PropertiesText_1Text.text = monsterConfig.Act.ToString();

            self.E_PropertiesText_2Text.gameObject.SetActive(true);
            self.E_PropertiesText_2Text.text = monsterConfig.Def.ToString();

            //显示人口
            self.E_MonsterNumberTextText.text = battleSummonConfig.MonsterNumber.ToString();
            using (zstring.Block())
            {
                self.E_CostTextText.text = zstring.Format("{0}金币", self.CostGold);
            }
        }

        public static void UpdateUI(this Scroll_Item_BattleRecruitItem self, long nowTime)
        {
            if (nowTime - self.SummonTime >= self.BattleSummonConfig.FreeResetTime * TimeHelper.Second)
            {
                self.CostGold = 0;
                self.E_BtnTextText.text = "免费召唤";
                self.E_TimeTextText.text = "免费:0分0秒";
            }
            else
            {
                self.CostGold = self.BattleSummonConfig.CostGold;
                self.E_BtnTextText.text = "召唤魔物";
                long time = self.SummonTime + self.BattleSummonConfig.FreeResetTime * TimeHelper.Second - TimeHelper.ClientNow();
                time /= 1000;
                int hour = (int)time / 3600;
                int min = (int)((time - (hour * 3600)) / 60);
                int sec = (int)(time - (hour * 3600) - (min * 60));
                using (zstring.Block())
                {
                    self.E_TimeTextText.text = zstring.Format("免费:{0}分{1}秒", min, sec);
                }
            }
        }

        public static void UpdateDate(this Scroll_Item_BattleRecruitItem self, long summonTime)
        {
            self.SummonTime = summonTime;
        }
    }
}