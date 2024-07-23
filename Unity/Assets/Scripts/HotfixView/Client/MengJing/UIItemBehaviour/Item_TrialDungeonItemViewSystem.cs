using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TrialDungeonItem))]
    [EntitySystemOf(typeof(Scroll_Item_TrialDungeonItem))]
    public static partial class Scroll_Item_TrialDungeonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TrialDungeonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TrialDungeonItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_TrialDungeonItem self, TowerConfig towerConfig, Action<int> action)
        {
            self.TowerConfig = towerConfig;

            self.E_Btn_XuanZhongImage.color = new Color(255, 255, 255, 0);
            self.E_Btn_XuanZhongButton.AddListener(self.OnBtn_XuanZhong);

            self.E_Hint_1Image.gameObject.SetActive(false);
            self.E_Hint_2Image.gameObject.SetActive(false);
            self.E_Hint_3Image.gameObject.SetActive(false);

            self.E_Lab_NameText.text = towerConfig.Name;
            self.ClickHandle = action;

            //1;0,0,3;72000001;1
            string monsterSet = towerConfig.MonsterSet;
            string[] monsterInfo = monsterSet.Split(';');
            int monster = int.Parse(monsterInfo[2]);
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monster);
            using (zstring.Block())
            {
                self.E_Lab_LvText.text = zstring.Format("等级: {0}", monsterConfig.Lv);
                self.E_Lab_HPText.text = zstring.Format("生命: {0}", monsterConfig.Hp);
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            NumericComponentC numcom = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            int towerid = numcom.GetAsInt(NumericType.TrialDungeonId); // 
            // 已经打完
            if (towerid >= towerConfig.Id)
            {
                //是否领取
                if (userInfo.TowerRewardIds.Contains(towerConfig.Id))
                {
                    //包含
                    self.E_Hint_2Image.gameObject.SetActive(true);
                }
                else
                {
                    //不包含
                    self.E_Hint_3Image.gameObject.SetActive(true);
                }
            }
            else
            {
                if (towerid + 1 == towerConfig.Id)
                {
                    self.E_Hint_1Image.gameObject.SetActive(true);
                }
            }
        }

        public static void OnBtn_XuanZhong(this Scroll_Item_TrialDungeonItem self)
        {
            self.ClickHandle(self.TowerConfig.Id);
        }

        public static void OnSelected(this Scroll_Item_TrialDungeonItem self, int towerId)
        {
            self.E_Btn_XuanZhongImage.color = new Color(255, 255, 255, towerId == self.TowerConfig.Id ? 255 : 0);
        }
    }
}