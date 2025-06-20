using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_OnRecvChat_ChatItemsRefresh : AEvent<Scene, OnRecvChat>
    {
        protected override async ETTask Run(Scene root, OnRecvChat args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgChat>()?.Refresh();
            await ETTask.CompletedTask;
        }
    }

  
    [FriendOf(typeof(Scroll_Item_ChatItem))]
    [FriendOf(typeof(PlayerInfoComponent))]
    [FriendOf(typeof(DlgChat))]
    public static class DlgChatSystem
    {
        public static void RegisterUIEvent(this DlgChat self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_SendButton.AddListenerAsync(self.OnSendButton);
            self.View.E_Button_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_ChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChatItemsRefresh);

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.WordChat, self.Reddot_WordChat);
            redPointComponent.RegisterReddot(ReddotType.TeamChat, self.Reddot_TeamChat);
            redPointComponent.RegisterReddot(ReddotType.UnionChat, self.Reddot_UnionChat);
            redPointComponent.RegisterReddot(ReddotType.SystemChat, self.Reddot_SystemChat);
            redPointComponent.RegisterReddot(ReddotType.PaiMaiChat, self.Reddot_PaiMaiChat);
        }

        public static void ShowWindow(this DlgChat self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void BeforeUnload(this DlgChat self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.WordChat, self.Reddot_WordChat);
            redPointComponent.UnRegisterReddot(ReddotType.TeamChat, self.Reddot_TeamChat);
            redPointComponent.UnRegisterReddot(ReddotType.UnionChat, self.Reddot_UnionChat);
            redPointComponent.UnRegisterReddot(ReddotType.SystemChat, self.Reddot_SystemChat);
            redPointComponent.UnRegisterReddot(ReddotType.PaiMaiChat, self.Reddot_PaiMaiChat);
        }

        private static void Reddot_WordChat(this DlgChat self, int num)
        {
            self.View.E_Type_0Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void Reddot_TeamChat(this DlgChat self, int num)
        {
            self.View.E_Type_1Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void Reddot_UnionChat(this DlgChat self, int num)
        {
            self.View.E_Type_2Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void Reddot_SystemChat(this DlgChat self, int num)
        {
            self.View.E_Type_3Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void Reddot_PaiMaiChat(this DlgChat self, int num)
        {
            self.View.E_Type_6Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void OnCloseButton(this DlgChat self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Chat);
        }

       
        private static async ETTask OnSendButton(this DlgChat self)
        {
            string text = self.View.E_ChatInputField.text;
            if (string.IsNullOrEmpty(text) || text.Length == 0)
            {
                Log.Error("请输入聊天内容！");
                return;
            }

            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();

            bool gm = ET.GMHelp.IsGmAccount(playerInfoComponent.Account);
            if(CommonHelp.IsBanHaoZone( playerInfoComponent.ServerItem.ServerId ))
            {
                gm = true;
            }

            bool mask = false;
            if (!gm)
            {
                // 替换敏感词
                mask = MaskWordHelper.Instance.IsContainSensitiveWords(text);
            }

            if (text.Equals("#etgm"))
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GM).Coroutine();
                return;
            }

            if (text.Equals("#blood"))
            {
                SettingData.ShowBlood = !SettingData.ShowBlood;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#guanghuan"))
            {
                SettingData.ShowGuangHuan = !SettingData.ShowGuangHuan;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#animation"))
            {
                SettingData.ShowAnimation = !SettingData.ShowAnimation;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#sound"))
            {
                SettingData.PlaySound = !SettingData.PlaySound;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#showsceneunit"))
            {
                SettingData.ShowSceneUnit = !SettingData.ShowSceneUnit;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#showmonster"))
            {
                SettingData.ShowMonster = !SettingData.ShowMonster;
                return;
            }

            if (text.Equals("#unloadasset"))
            {
                self.Root().GetComponent<SceneManagerComponent>().UnLoadAsset();
                return;
            }

            if (text.Equals("#light"))
            {
                GameObject T1errain = GameObject.Find("AdditiveHide/ScenceModelSet/Directional Light (1)");
                T1errain.gameObject.SetActive(!T1errain.gameObject.activeSelf);
                return;
            }

            if (text.Equals("#fps"))
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().ShowPing();
                return;
            }
            
            if (text.Equals("#fps60"))
            {
                CommonViewHelper.TargetFrameRate(60);
                return;
            }
            
            if (text.Equals("#resetall"))
            {
                bool svalue = !SettingData.ShowEffect;
                SettingData.ShowBlood = svalue;
                SettingData.ShowEffect = svalue;
                SettingData.ShowGuangHuan = svalue;
                SettingData.ShowAnimation = svalue;
                SettingData.PlaySound = svalue;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (mask)
            {
                Log.Error("请重新输入！");
                return;
            }

            int itemType = self.CurrentChatType;
            if (itemType == ChannelEnum.Team && !self.Root().GetComponent<TeamComponentC>().IsHaveTeam())
            {
                FlyTipComponent.Instance.ShowFlyTip("没有队伍！");
                return;
            }

            if (text.Contains("#"))
            {
                string[] commands = text.Split('#');
                if (commands[0] == "3")
                {
                    return;
                }

                if (commands[1].Contains("alltask"))
                {
                    List<TaskConfig> tasks = TaskConfigCategory.Instance.GetAll().Values.ToList();
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        if (tasks[i].TaskType != (int)TaskTargetType.ItemID_Number_2)
                        {
                            continue;
                        }

                        int monster = tasks[i].Target[0];
                        if (!MonsterConfigCategory.Instance.Contain(monster))
                        {
                            Log.Error($"任务ID: {tasks[i].Id} 错误怪物ID: {monster}");
                        }
                    }

                    return;
                }

                if (commands[1].Contains("chuji")
                    || commands[1].Contains("zhongji")
                    || commands[1].Contains("zhongji")
                   )
                {
                    GMNetHelp.SendGmCommands(self.Root(), text);
                    return;
                }

                GMNetHelp.SendGmCommand(self.Root(), text);
                
                if (text == "#hightest" || text == "#middletest")
                {
                    await UserInfoNetHelper.RequestUserInfoInit(self.Root());
                    await ChengJiuNetHelper.GetChengJiuList(self.Root());
                }
            }
            else
            {
                await ChatNetHelper.RequestSendChat(self.Root(), itemType, text);
            }

            if (self.IsDisposed)
            {
                return;
            }

            self.View.E_ChatInputField.GetComponent<InputField>().text = "";
        }

        private static void OnChatItemsRefresh(this DlgChat self, Transform transform, int index)
        {
            foreach (Scroll_Item_ChatItem item in self.ScrollItemChatItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ChatItem scrollItemChatItem = self.ScrollItemChatItems[index].BindTrans(transform);
            scrollItemChatItem.Refresh(self.ShowChatInfos[index]);
        }

        private static void OnFunctionSetBtn(this DlgChat self, int index)
        {
            self.CurrentChatType = index;

            ReddotComponentC reddotComponentC = self.Root().GetComponent<ReddotComponentC>();
            switch (index)
            {
                case 0:
                    reddotComponentC.RemoveReddont(ReddotType.WordChat);
                    break;
                case 1:
                    reddotComponentC.RemoveReddont(ReddotType.TeamChat);
                    break;
                case 2:
                    reddotComponentC.RemoveReddont(ReddotType.UnionChat);
                    break;
                case 3:
                    reddotComponentC.RemoveReddont(ReddotType.SystemChat);
                    break;
                case 6:
                    reddotComponentC.RemoveReddont(ReddotType.PaiMaiChat);
                    break;
            }

            self.Refresh();
        }

        public static void Refresh(this DlgChat self)
        {
            self.RefreshChatItems();
        }

        private static void RefreshChatItems(this DlgChat self)
        {
            List<ChatInfo> chatlist = self.Root().GetComponent<ChatComponent>().GetChatListByType(self.CurrentChatType);
            self.View.E_ChatItemsLoopVerticalScrollRect.gameObject.SetActive(self.CurrentChatType != ChannelEnum.System);

            self.ShowChatInfos.Clear();
            self.ShowChatInfos.AddRange(chatlist);

            self.AddUIScrollItems(ref self.ScrollItemChatItems, self.ShowChatInfos.Count);
            self.View.E_ChatItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChatInfos.Count);
            self.View.E_ChatItemsLoopVerticalScrollRect.RefillCellsFromEnd();

            Vector3 vector3 = self.View.E_ChatItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition;
            vector3.y = self.ShowChatInfos.Count * 200;
            self.View.E_ChatItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition = vector3;
        }
    }
}