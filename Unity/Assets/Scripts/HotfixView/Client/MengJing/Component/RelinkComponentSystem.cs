namespace ET.Client
{
    [FriendOf(typeof(RelinkComponent))]
    [EntitySystemOf(typeof(RelinkComponent))]
    public static partial class RelinkComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RelinkComponent self)
        {
            self.Relink = false;
            // GameObject.Find("Global").GetComponent<Init>().OnApplicationFocusHandler = (bool value) => { self.OnApplicationFocusHandler(value); };
            // GameObject.Find("Global").GetComponent<Init>().OnApplicationQuitHandler = () => { self.OnApplicationQuitHandler().Coroutine(); };
        }

        [EntitySystem]
        private static void Destroy(this RelinkComponent self)
        {
            self.Relink = false;
        }

        public static void OnIosPaySuccessedCallback(this RelinkComponent self, string info)
        {
            //掉线
            // SessionComponent sessionComponent = self.Root().GetComponent<SessionComponent>();
            // AccountInfoComponent accountInfoComponent = self.Root().GetComponent<AccountInfoComponent>();
            // if (sessionComponent == null)
            // {
            //     PlayerPrefsHelp.SetString("IOS_" + accountInfoComponent.CurrentRoleId.ToString(), info);
            //     return;
            // }
            //
            // Session session = sessionComponent.Session;
            // if (session == null || session.IsDisposed)
            // {
            //     PlayerPrefsHelp.SetString("IOS_" + accountInfoComponent.CurrentRoleId.ToString(), info);
            //     return;
            // }
            //
            // MapComponent mapComponent = self.DomainScene().GetComponent<MapComponent>();
            // if (mapComponent.SceneTypeEnum < (int)SceneTypeEnum.MainCityScene)
            // {
            //     PlayerPrefsHelp.SetString("IOS_" + accountInfoComponent.CurrentRoleId.ToString(), info);
            //     return;
            // }
            //
            // Receipt receipt = JsonHelper.FromJson<Receipt>(info);
            // Log.Debug("payload[内购成功]:" + receipt.Payload);
            //
            // Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // C2R_IOSPayVerifyRequest request = new C2R_IOSPayVerifyRequest() { UnitId = unit.Id, payMessage = receipt.Payload };
            // session.Call(request).Coroutine();
            //
            // UI uirecharget = UIHelper.GetUI(self.ZoneScene(), UIType.UIRecharge);
            // if (uirecharget != null)
            // {
            //     uirecharget.GetComponent<UIRechargeComponent>().Loading.SetActive(false);
            // }
        }

        public static void OnIosPayFailCallback(this RelinkComponent self)
        {
            DlgRecharge dlgRecharge = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRecharge>();
            if (dlgRecharge != null)
            {
                dlgRecharge.View.EG_LoadingRectTransform.gameObject.SetActive(false);
            }
        }

        // public static async ETTask OnApplicationQuitHandler(this RelinkComponent self)
        // {
        //     SessionComponent sessionComponent = self.DomainScene().GetComponent<SessionComponent>();
        //     if (sessionComponent == null)
        //     {
        //         return;
        //     }
        //     
        //     if (sessionComponent.Session == null || sessionComponent.Session.IsDisposed)
        //     {
        //         return;
        //     }
        //     
        //     try
        //     {
        //         await ETTask.CompletedTask;
        //     }
        //     catch (Exception e)
        //     {
        //         Log.Debug(e.ToString());
        //     }
        // }

        public static void OnApplicationFocusHandler(this RelinkComponent self, bool value)
        {
            // if (value)
            // {
            //     MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            //     if (mapComponent.SceneType == (int)SceneTypeEnum.LoginScene)
            //     {
            //         return;
            //     }
            //
            //     SessionComponent sessionComponent = self.DomainScene().GetComponent<SessionComponent>();
            //     if (sessionComponent == null)
            //     {
            //         return;
            //     }
            //
            //     if (sessionComponent.Session == null || sessionComponent.Session.IsDisposed)
            //     {
            //         self.CheckRelink().Coroutine();
            //     }
            // }
            // else
            // {
            //     DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            //     if (dlgMain != null)
            //     {
            //         dlgMain.OnStopAction();
            //     }
            // }
        }

        // public static async ETTask CheckRelink(this RelinkComponent self)
        // {
        //     if (self.Relink)
        //     {
        //         return;
        //     }
        //     
        //     self.Relink = true;
        //     Log.Debug($"重连请求！！");
        //     UIHelper.Create(self.DomainScene(), UIType.UIRelink).Coroutine();
        //     for (int i = 0; i < 5; i++)
        //     {
        //         long instanceid = self.InstanceId;
        //         Log.Debug($"重连请求11！！ {self.Relink}");
        //         if (TimerComponent.Instance == null || !self.Relink)
        //         {
        //             break;
        //         }
        //     
        //         await TimerComponent.Instance.WaitAsync(3000);
        //         if (instanceid != self.InstanceId)
        //         {
        //             break;
        //         }
        //     
        //         if (TimerComponent.Instance == null || !self.Relink)
        //         {
        //             break;
        //         }
        //     
        //         Log.ILog.Debug($"重连请求22！！ {self.Relink}");
        //         self.SendLogin().Coroutine();
        //         if (i == 4)
        //         {
        //             UIHelper.Remove(self.DomainScene(), UIType.UIRelink);
        //             EventType.ReturnLogin.Instance.ZoneScene = self.DomainScene();
        //             Game.EventSystem.PublishClass(EventType.ReturnLogin.Instance);
        //             break;
        //         }
        //     }
        // }

        public static void OnModifyData(this RelinkComponent self)
        {
            // self.ModifyDataNumber++;
            //
            // if (self.ModifyDataNumber > 10)
            // {
            //     return;
            // }
            //
            // if (self.ModifyDataNumber == 10)
            // {
            //     PlayerPrefsHelp.SetString(PlayerPrefsHelp.LoginErrorTime, (TimeHelper.ServerNow() + TimeHelper.Hour).ToString());
            //     EventType.ReturnLogin.Instance.ZoneScene = self.DomainScene();
            //     Game.EventSystem.PublishClass(EventType.ReturnLogin.Instance);
            // }
        }

        // public static async ETTask OnRelinkSucess(this RelinkComponent self)
        // {
        //     self.Relink = false;
        //     Log.ILog.Debug($"重连成功！！ {self.Relink}");
        //     Scene zoneScene = self.ZoneScene();
        //     UIHelper.Remove(self.DomainScene(), UIType.UIRelink);
        //     
        //     zoneScene.GetComponent<SessionComponent>().Session.Send(new C2M_RefreshUnitRequest());
        //     await NetHelper.RequestUserInfo(zoneScene, true);
        //     await NetHelper.RequestUnitInfo(zoneScene, true);
        //     await NetHelper.RequestAllPets(zoneScene);
        //     await NetHelper.RequestFriendInfo(zoneScene);
        //     
        //     AccountInfoComponent accountInfoComponent = zoneScene.GetComponent<AccountInfoComponent>();
        //     string info = PlayerPrefsHelp.GetString("IOS_" + accountInfoComponent.CurrentRoleId.ToString());
        //     if (!string.IsNullOrEmpty(info))
        //     {
        //         NetHelper.SendIOSPayVerifyRequest(zoneScene, info);
        //         PlayerPrefsHelp.SetString("IOS_" + accountInfoComponent.CurrentRoleId.ToString(), string.Empty);
        //         FloatTipManager.Instance.ShowFloatTip("重连成功_IOS！");
        //     }
        //     else
        //     {
        //         FloatTipManager.Instance.ShowFloatTip("重连成功！");
        //     }
        //     
        //     UI uIMain = UIHelper.GetUI(zoneScene, UIType.UIMain);
        //     if (uIMain != null)
        //     {
        //         uIMain.GetComponent<UIMainComponent>().OnRelinkUpdate();
        //     }
        //     
        //     Unit unit = UnitHelper.GetMyUnitFromZoneScene(zoneScene);
        //     
        //     NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
        //     int nowhp = numericComponent.GetAsInt(NumericType.Now_Hp);
        //     int nowdead = numericComponent.GetAsInt(NumericType.Now_Dead);
        //     
        //     if (nowdead == 1)
        //     {
        //         unit.GetComponent<UIUnitHpComponent>().UpdateBlood();
        //         unit.GetComponent<HeroDataComponent>().OnDead(null);
        //         EventType.UnitDead.Instance.Unit = unit;
        //         Game.EventSystem.PublishClass(EventType.UnitDead.Instance);
        //     }
        // }

//         /// <summary>
//         /// 断线重连，重新走登录流程
//         /// </summary>
//         /// <param name="self"></param>
//         public static async ETTask<int> SendLogin(this RelinkComponent self)
//         {
//             long instanceid = self.InstanceId;
//             AccountInfoComponent PlayerComponent = self.DomainScene().GetComponent<AccountInfoComponent>();
//
//             int code = await LoginHelper.Login(self.DomainScene(),
//                 PlayerComponent.ServerIp,
//                 PlayerComponent.Account,
//                 PlayerComponent.Password, true, string.Empty, PlayerComponent.LoginType);
//             if (code != ErrorCode.ERR_Success)
//             {
//                 return code;
//             }
//
//             code = await LoginHelper.GetRealmKey(self.DomainScene());
//             if (code != ErrorCode.ERR_Success)
//             {
//                 return code;
//             }
//
//             await TimerComponent.Instance.WaitAsync(1500);
//             if (instanceid != self.InstanceId)
//             {
//                 return ErrorCode.ERR_NetWorkError;
//             }
//
// #if TikTok5
//             string deviveInfo = $"tiktok";
// #else
//             string deviveInfo = $"{UnityEngine.SystemInfo.deviceModel}_{UnityEngine.Screen.width}:{UnityEngine.Screen.height}";
// #endif
//             code = await LoginHelper.EnterGame(self.ZoneScene(), deviveInfo, true, GlobalHelp.GetPlatform());
//             return code;
//         }
    }
}