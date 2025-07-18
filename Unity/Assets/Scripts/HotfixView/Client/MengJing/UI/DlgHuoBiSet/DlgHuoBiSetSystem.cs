using System;
using UnityEngine;

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

            self.DefaultTitleIconSprite = self.View.E_TitleIconImage.sprite;
            
            IPHoneHelper.SetPosition( self.View.E_TopLeftTitle.gameObject, new Vector2(220f, 0f) );

            self.InitShow();
        }

        public static void ShowWindow(this DlgHuoBiSet self, Entity contextData = null)
        {
        }

        private static  void OnAddGoldButton(this DlgHuoBiSet self)
        {
            // if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRecharge>() != null)
            // {
            //     return;
            // }

            ShowWindowData showWindowData = new ShowWindowData();
            showWindowData.ParamInfoInt = 3;
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMai, showWindowData).Coroutine();
        }

        private static void OnAddZuanShiButton(this DlgHuoBiSet self)
        {
            if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRecharge>() != null)
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
                self.View.EG_ZiJinSetRectTransform.gameObject.SetActive(Enum.GetName(typeof(WindowID), uiComponent.OpenUIList[0])
                        .Contains("JiaYuan"));
                self.View.EG_JiaZuSetRectTransform.gameObject.SetActive(Enum.GetName(typeof(WindowID), uiComponent.OpenUIList[0]).Contains("Union"));
                //self.View.EG_WeiJingSetRectTransform.gameObject.SetActive(
                //    Enum.GetName(typeof(WindowID), uiComponent.OpenUIList[0]).Contains("PaiMai"));
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
            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TiTleIcon, "Img_UIActivity");
            // Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            // self.View.E_TitleImage.sprite = sp;

            // 标题图标
            string titleIcon = windowID switch
            {
                WindowID.WindowID_Task => "Title_Task",
                WindowID.WindowID_Role => "Title_Rose",
                WindowID.WindowID_Pet => "Title_Pet",
                WindowID.WindowID_Skill => "Title_Skill",
                WindowID.WindowID_Friend => "Title_Friend",
                WindowID.WindowID_ChengJiu => "Title_ChengJiu",
                WindowID.WindowID_PetBar => "Title_Pet",
                WindowID.WindowID_ShouJi => "Title_Skill",

                WindowID.WindowID_MakeLearn => "Title_Make",
                WindowID.WindowID_GemMake => "Title_Make",
                WindowID.WindowID_RoleXiLian => "Title_Make",
                WindowID.WindowID_ShenQiMake => "Title_Make",
                WindowID.WindowID_PetEquipMake => "Title_Make",
                WindowID.WindowID_Rank => "Title_Rose",
                WindowID.WindowID_Warehouse => "Title_Rose",
                WindowID.WindowID_Mail => "Title_Rose",

                _ => "Default"
            };
            
            // 标题文字
            string title = windowID switch
            {
                WindowID.WindowID_Task => "任务系统",
                WindowID.WindowID_Role => "角色系统",
                WindowID.WindowID_Pet => "宠物系统",
                WindowID.WindowID_Skill => "技能系统",
                WindowID.WindowID_Friend => "好友系统",
                WindowID.WindowID_ChengJiu => "成就系统",
                WindowID.WindowID_PetBar => "宠物布阵",
                WindowID.WindowID_ShouJi => "拾光收集",
                WindowID.WindowID_Trial => "巅峰试炼",
                WindowID.WindowID_Tower => "勇者之境",
                WindowID.WindowID_Rank => "排行榜",
                WindowID.WindowID_TowerOfSeal=>"灵禁秘塔",
                WindowID.WindowID_GemMake=>"宝石制造",
                WindowID.WindowID_PaiMai=>"交易行",
                WindowID.WindowID_MakeLearn=>"学习制造",
                WindowID.WindowID_RoleXiLian=>"装备洗练",
                WindowID.WindowID_ShenQiMake=>"制造神器",
                WindowID.WindowID_Store =>"商店系统",
                WindowID.WindowID_Mail=>"邮件系统",
                WindowID.WindowID_Warehouse=>"我的仓库",
                WindowID.WindowID_ZuoQi=>"坐骑系统",
                WindowID.WindowID_ChouKa=>"幸运探宝",
                WindowID.WindowID_PetEgg=>"宠物探索",
                WindowID.WindowID_Season=>"赛季系统",
                WindowID.WindowID_Activity=>"游戏活动",
                WindowID.WindowID_Country=>"每日活跃",
                WindowID.WindowID_Recharge=>"游戏商城",
                WindowID.WindowID_PetEquipMake=>"宠装制造",
                WindowID.WindowID_ZhanQu=>"奖励系统",
                WindowID.WindowID_Setting=>"游戏设置",
                WindowID.WindowID_PetMeleeLevel=>"宠物挑战",
                WindowID.WindowID_DragonDungeon=>"游戏副本",
                WindowID.WindowID_DragonDungeonCreate=>"创建副本",
                _ => ""
            };

            if (titleIcon != "Default")
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TiTleIcon, titleIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.View.E_TitleIconImage.sprite = sp;
            }
            else
            {
                self.View.E_TitleIconImage.sprite = self.DefaultTitleIconSprite;
            }

            self.View.E_TitleTextText.text = title;
        }
    }
}
