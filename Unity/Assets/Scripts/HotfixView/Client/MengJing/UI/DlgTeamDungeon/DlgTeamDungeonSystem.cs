using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_TeamUpdate_DlgTeamDungeonRefresh : AEvent<Scene, RecvTeamUpdate>
    {
        protected override async ETTask Run(Scene scene, RecvTeamUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamDungeon>()?.OnTeamUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_BagItemUpdate_DlgTeamDungeonRefresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamDungeon>()?.View.ES_TeamDungeonShop.OnUpdateUI();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_TeamDungeonList))]
    [FriendOf(typeof(ES_TeamDungeonMy))]
    [FriendOf(typeof(ES_TeamDungeonShop))]
    [FriendOf(typeof(DlgTeamDungeon))]
    public static class DlgTeamDungeonSystem
    {
        public static void RegisterUIEvent(this DlgTeamDungeon self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn, self.CheckPageButton_1);
            self.View.E_FunctionSetBtnToggleGroup.SetClickEnabled(false);
            
            self.RequestTeamDungeonInfo().Coroutine();
            //IOS适配
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0));
        }

        public static void ShowWindow(this DlgTeamDungeon self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgTeamDungeon self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_TeamDungeonList.uiTransform.gameObject.SetActive(true);
                    self.View.ES_TeamDungeonList.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_TeamDungeonMy.uiTransform.gameObject.SetActive(true);
                    self.View.ES_TeamDungeonMy.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_TeamDungeonShop.uiTransform.gameObject.SetActive(true);
                    self.View.ES_TeamDungeonShop.OnUpdateUI();
                    break;
            }
        }

        public static async ETTask RequestTeamDungeonInfo(this DlgTeamDungeon self)
        {
            await TeamNetHelper.RequestTeamDungeonList(self.Root(), MapTypeEnum.TeamDungeon);

            if (self.IsDisposed)
            {
                return;
            }

            self.View.E_FunctionSetBtnToggleGroup.SetClickEnabled(true);
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            if (teamInfo == null || teamInfo.SceneId == 0)
            {
                //无副本队伍
                self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            }
            else
            {
                //有副本队伍
                self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(1);
            }
        }

        public static void OnTeamUpdate(this DlgTeamDungeon self)
        {
            self.View.ES_TeamDungeonMy.OnUpdateUI();

            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            if (teamInfo == null && self.View.E_FunctionSetBtnToggleGroup.GetCurrentIndex() != 0)
            {
                self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            }
        }

        public static bool CheckPageButton_1(this DlgTeamDungeon self, int page)
        {
            if (page != 1)
            {
                return true;
            }

            //判断当前是否有队伍
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            if (teamInfo == null || teamInfo.SceneId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先创建或加入副本队伍");
                return false;
            }

            return true;
        }
    }
}
