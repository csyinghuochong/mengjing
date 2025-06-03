using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgTeamDungeonPrepare))]
    public static class DlgTeamDungeonPrepareSystem
    {
        public static void RegisterUIEvent(this DlgTeamDungeonPrepare self)
        {
            self.TeamPlayerItemList[0] = self.View.EG_TeamPlayerItem0RectTransform.gameObject;
            self.TeamPlayerItemList[1] = self.View.EG_TeamPlayerItem1RectTransform.gameObject;
            self.TeamPlayerItemList[2] = self.View.EG_TeamPlayerItem2RectTransform.gameObject;

            self.View.E_Button_RefuseButton.AddListener(() => { self.OnButton_Agree(2).Coroutine(); });
            self.View.E_Button_AgreeButton.AddListener(() => { self.OnButton_Agree(1).Coroutine(); });

            self.ShowCountDount().Coroutine();
        }

        public static void ShowWindow(this DlgTeamDungeonPrepare self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgTeamDungeonPrepare self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static async ETTask ShowCountDount(this DlgTeamDungeonPrepare self)
        {
            long instanceid = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.Timer);
            for (int i = 20; i >= 0; i--)
            {
                using (zstring.Block())
                {
                    self.View.E_TextCountDownText.text = zstring.Format("倒计时:{0}", i);
                }

                await timerComponent.WaitAsync(1000);
                if (instanceid != self.InstanceId)
                {
                    return;
                }
            }

            await self.OnButton_Agree(2);
            if (instanceid == self.InstanceId && self.Root() != null)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonPrepare);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="preare">0没选择 1 同意 2拒绝</param>
        /// <returns></returns>
        public static async ETTask OnButton_Agree(this DlgTeamDungeonPrepare self, int preare)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (preare == 1
                && mapComponent.MapType != MapTypeEnum.MainCityScene
                && mapComponent.MapType != MapTypeEnum.LocalDungeon)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先退出当前副本！");
                return;
            }

            int errorCode = ErrorCode.ERR_Success;

            switch (self.TeamInfo.SceneType)
            {
                case MapTypeEnum.TeamDungeon:
                    errorCode =  TeamHelper.CheckTimesAndLevel(UnitHelper.GetMyUnitFromClientScene(self.Root()), self.TeamInfo);
                    if (preare == 1 && errorCode != ErrorCode.ERR_Success)
                    {
                        HintHelp.ShowErrorHint(self.Root(), errorCode);
                        return;
                    }
                    break; 
                case MapTypeEnum.DragonDungeon:
                    break;
                default:
                    break;
            }
            
            long unitid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            for (int i = 0; i < self.TeamInfo.PlayerList.Count; i++)
            {
                if (self.TeamInfo.PlayerList[i].UserID != unitid)
                {
                    continue;
                }

                if (self.TeamInfo.PlayerList[i].Prepare != 0)
                {
                    return;
                }
            }

            await TeamNetHelper.TeamDungeonPrepareRequest(self.Root(), self.TeamInfo, preare);
        }

        public static void OnUpdateUI(this DlgTeamDungeonPrepare self, TeamInfo teamInfo, int error)
        {
            self.TeamInfo = teamInfo;
            for (int i = 0; i < 3; i++)
            {
                self.TeamPlayerItemList[i].SetActive(false);
            }

            string haverefuse = string.Empty;
            for (int i = 0; i < self.TeamInfo.PlayerList.Count; i++)
            {
                TeamPlayerInfo teamPlayerInfo = self.TeamInfo.PlayerList[i];
                GameObject gameObject = self.TeamPlayerItemList[i];
                gameObject.SetActive(true);
                gameObject.transform.Find("Text_WaitHint").gameObject.SetActive(teamPlayerInfo.Prepare == 0);
                gameObject.transform.Find("Image_Agree").gameObject.SetActive(teamPlayerInfo.Prepare == 1);
                gameObject.transform.Find("Image_Refuse").gameObject.SetActive(teamPlayerInfo.Prepare == 2);
                gameObject.transform.Find("Text_Name").GetComponent<Text>().text = teamPlayerInfo.PlayerName;
                gameObject.transform.Find("ImagePlayer/Text_Level").GetComponent<Text>().text = $"{teamPlayerInfo.PlayerLv}级";
                CommonViewHelper.ShowOccIcon(self.Root(), gameObject.transform.Find("ImagePlayer/ImageMask/ImageHead").gameObject,
                    teamPlayerInfo.Occ);
                if (teamPlayerInfo.Prepare == 2)
                {
                    haverefuse = teamPlayerInfo.PlayerName;
                }
            }

            if (!string.IsNullOrEmpty(haverefuse))
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0} 不同意进入副本", haverefuse));
                }

                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonPrepare);

                return;
            }

            if (error != ErrorCode.Err_HaveNotPrepare)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeon);
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DragonDungeon);
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonPrepare);
            }

            if (self.IsDisposed)
            {
                return;
            }

            if (self.TeamInfo.PlayerList.Count == 1)
            {
                TeamNetHelper.TeamDungeonPrepareRequest(self.Root(), self.TeamInfo, 1).Coroutine();
            }
        }
    }
}
