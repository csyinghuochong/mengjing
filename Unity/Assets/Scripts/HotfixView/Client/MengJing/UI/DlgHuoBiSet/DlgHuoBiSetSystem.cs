using System;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UpdateUserData_HuoBiSetRefresh : AEvent<Scene, UpdateUserData>
    {
        protected override async ETTask Run(Scene root, UpdateUserData args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgHuoBiSet>()?.InitShow();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(DlgHuoBiSet))]
    public static class DlgHuoBiSetSystem
    {
        public static void RegisterUIEvent(this DlgHuoBiSet self)
        {
            self.View.E_AddGoldButton.AddListener(self.OnAddGoldButton);
            self.View.E_AddZuanShiButton.AddListener(self.OnAddZuanShiButton);

            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_Close2Button.AddListener(self.OnCloseButton);
            self.View.E_Btn_AddGoldButton.AddListener(self.OnBtn_AddGoldButton);
        }

        public static void ShowWindow(this DlgHuoBiSet self, Entity contextData = null)
        {
            self.InitShow();
        }

        private static void OnAddGoldButton(this DlgHuoBiSet self)
        {
            if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRecharge>() != null)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        private static void OnAddZuanShiButton(this DlgHuoBiSet self)
        {
            if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMai>() != null)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        public static void InitShow(this DlgHuoBiSet self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.View.E_GoldText.text = userInfo.Gold.ToString();
            self.View.E_ZuanShiText.text = userInfo.Diamond.ToString();
            self.View.E_Lab_RongYuText.text = userInfo.RongYu.ToString();
            self.View.E_Lab_ZiJinText.text = userInfo.JiaYuanFund.ToString();
            self.View.E_JiaZu_ZiJinText.text = userInfo.UnionZiJin.ToString();
            // self.View.E_WeiJing_ZiJinText.text = userInfo.WeiJingGold.ToString();

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            if (uiComponent.OpenUIList.Count > 0)
            {
                self.OnUpdateTitle(uiComponent.OpenUIList[0]);
                self.View.EG_ZiJinSetRectTransform.gameObject.SetActive(Enum.GetName(typeof(WindowID), uiComponent.OpenUIList[0]).Contains("JiaYuan"));
                self.View.EG_JiaZuSetRectTransform.gameObject.SetActive(Enum.GetName(typeof(WindowID), uiComponent.OpenUIList[0]).Contains("Union"));
                self.View.EG_WeiJingSetRectTransform.gameObject.SetActive(Enum.GetName(typeof(WindowID), uiComponent.OpenUIList[0]).Contains("PaiMai"));
            }
        }

        private static void OnCloseButton(this DlgHuoBiSet self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_ItemTips);
            uiComponent.CloseWindow(WindowID.WindowID_EquipDuiBiTips);

            if (uiComponent.OpenUIList.Count > 0)
            {
                if (uiComponent.OpenUIList[0] == WindowID.WindowID_Setting)
                {
                    DlgSetting dlgSetting = uiComponent.GetDlgLogic<DlgSetting>();
                    dlgSetting?.OnBeforeClose();
                }

                if (uiComponent.OpenUIList[0] == WindowID.WindowID_Role)
                {
                    uiComponent.CloseWindow(WindowID.WindowID_RoleZodiac);
                }

                uiComponent.CloseWindow(uiComponent.OpenUIList[0]);
            }
        }

        public static void OnUpdateTitle(this DlgHuoBiSet self, WindowID windowID)
        {
            // string[] paths = uiType.Split('/');
            // string titlePath = paths[paths.Length - 1];
            // if (uiType.Contains("UITeamDungeon"))
            // {
            //     titlePath = "UITeamDungeon";
            // }
            //
            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TiTleIcon, "Img_" + titlePath);
            // Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAsset<Sprite>(path);
            // if (!self.AssetPath.Contains(path))
            // {
            //     self.AssetPath.Add(path);
            // }
            //
            // self.Img_Back_Title.GetComponent<Image>().sprite = sp;
        }
        public static void OnBtn_AddGoldButton(this DlgHuoBiSet self)
        {
        }
    }
}
