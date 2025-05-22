using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TeamDungeonItem))]
    [EntitySystemOf(typeof(ES_DragonDungeonList))]
    [FriendOfAttribute(typeof(ES_DragonDungeonList))]
    public static partial class ES_DragonDungeonListSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_DragonDungeonList self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;
            self.E_DragonDungeonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTeamDungeonItemsRefresh);
            self.E_Button_CreateButton.AddListener(self.OnButton_CreateButton);
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_DragonDungeonList self)
        {
            self.DestroyWidget();
        }
        
        public static void OnButton_CreateButton(this ES_DragonDungeonList self)
        {
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            if (teamInfo != null && teamInfo.SceneId != 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经有队伍了");
                return;
            }
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DragonDungeonCreate).Coroutine();
        }

        private static void OnTeamDungeonItemsRefresh(this ES_DragonDungeonList self, Transform transform, int index)
        {
            foreach (Scroll_Item_TeamDungeonItem item in self.ScrollItemTeamDungeonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_TeamDungeonItem scrollItemTeamDungeonItem = self.ScrollItemTeamDungeonItems[index].BindTrans(transform);
            scrollItemTeamDungeonItem.OnUpdateUI(self.ShowTeamInfos[index], MapTypeEnum.DragonDungeon);
        }

        public static void OnUpdateUI(this ES_DragonDungeonList self)
        {
            TeamComponentC teamComponent = self.Root().GetComponent<TeamComponentC>();
            List<TeamInfo> teamList = teamComponent.TeamList;

            self.ShowTeamInfos.Clear();
            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i].SceneId == 0)
                {
                    continue;
                }

                self.ShowTeamInfos.Add(teamList[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemTeamDungeonItems, self.ShowTeamInfos.Count);
            self.E_DragonDungeonItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTeamInfos.Count);

            int totalTimes = GlobalValueConfigCategory.Instance.MaxTeamDungeonsPerDay;
            int times = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetTeamDungeonTimes();
            self.E_Text_LeftTimeText.gameObject.SetActive(true);
            using (zstring.Block())
            {
                self.E_Text_LeftTimeText.text = zstring.Format("副本次数：{0}/{1}", totalTimes - times, totalTimes);
            }

            totalTimes = GlobalValueConfigCategory.Instance.MaxDailyXieZhuFubens;
            times = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetTeamDungeonXieZhu();
            using (zstring.Block())
            {
                self.E_Text_XieZhuNumText.text = zstring.Format("帮助次数：{0}/{1}", totalTimes - times, totalTimes);
            }
        }
    }

}