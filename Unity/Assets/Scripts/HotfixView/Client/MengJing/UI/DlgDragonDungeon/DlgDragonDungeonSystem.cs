using UnityEngine;

namespace ET.Client
{
	
	[Event(SceneType.Demo)]
	public class DataUpdate_TeamUpdate_DlgDragonDungeonRefresh : AEvent<Scene, RecvTeamUpdate>
	{
		protected override async ETTask Run(Scene scene, RecvTeamUpdate args)
		{
			scene.GetComponent<UIComponent>().GetDlgLogic<DlgDragonDungeon>()?.OnTeamUpdate();
			await ETTask.CompletedTask;
		}
	}
	
	[FriendOf(typeof(ES_DragonDungeonList))]
	[FriendOf(typeof(ES_DragonDungeonMy))]
	[FriendOf(typeof(ES_DragonDungeonShop))]
	[FriendOf(typeof(DlgDragonDungeon))]
	public static  class DlgDragonDungeonSystem
	{

		public static void RegisterUIEvent(this DlgDragonDungeon self)
		{
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn, self.CheckPageButton_1);
			self.View.E_FunctionSetBtnToggleGroup.SetClickEnabled(false);
            
			self.RequestTeamDungeonInfo().Coroutine();
			//IOS适配
			IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0));
		}

		public static void ShowWindow(this DlgDragonDungeon self, Entity contextData = null)
		{
		}

		private static void OnFunctionSetBtn(this DlgDragonDungeon self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_DragonDungeonList.uiTransform.gameObject.SetActive(true);
                    self.View.ES_DragonDungeonList.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_DragonDungeonMy.uiTransform.gameObject.SetActive(true);
                    self.View.ES_DragonDungeonMy.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_DragonDungeonShop.uiTransform.gameObject.SetActive(true);
                    self.View.ES_DragonDungeonShop.UpdateInfo();
                    break;
            }
        }

        public static async ETTask RequestTeamDungeonInfo(this DlgDragonDungeon self)
        {
            await TeamNetHelper.RequestTeamDungeonList(self.Root(),MapTypeEnum.DragonDungeon);

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

        public static void OnTeamUpdate(this DlgDragonDungeon self)
        {
            self.View.ES_DragonDungeonMy.OnUpdateUI();

            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            if (teamInfo == null && self.View.E_FunctionSetBtnToggleGroup.GetCurrentIndex() != 0)
            {
                self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            }
        }

        public static bool CheckPageButton_1(this DlgDragonDungeon self, int page)
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
