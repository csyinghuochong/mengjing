using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_OnRecvChat_ChatItemsRefresh: AEvent<Scene, DataUpdate_OnRecvChat>
    {
        protected override async ETTask Run(Scene root, DataUpdate_OnRecvChat args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgChat>()?.Refresh();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (PlayerComponent))]
    [FriendOf(typeof (DlgChat))]
    public static class DlgChatSystem
    {
        public static void RegisterUIEvent(this DlgChat self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_SendButton.AddListenerAsync(self.OnSendButton);
            self.View.E_ChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChatItemsRefresh);
        }

        public static void ShowWindow(this DlgChat self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
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

            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();

            if (playerComponent != null)
            {
                Log.Debug("playerComponent != null");
            }
            else
            {
                Log.Debug("playerComponent == null");
            }

            bool mask = false;
            if (!ET.GMHelp.IsGmAccount(playerComponent.Account))
            {
                // 替换敏感词
                // mask = MaskWordHelper.Instance.IsContainSensitiveWords(text);
            }

            if (text.Equals("#etgm"))
            {
                // UIHelper.Create(self.DomainScene(), UIType.UIGM).Coroutine();
                return;
            }

            if (text.Equals("#blood"))
            {
                // SettingHelper.ShowBlood = !SettingHelper.ShowBlood;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#guanghuan"))
            {
                // SettingHelper.ShowGuangHuan = !SettingHelper.ShowGuangHuan;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#animation"))
            {
                // SettingHelper.ShowAnimation = !SettingHelper.ShowAnimation;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#sound"))
            {
                // SettingHelper.PlaySound = !SettingHelper.PlaySound;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#pool"))
            {
                // SettingHelper.UsePool = !SettingHelper.UsePool;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#openall"))
            {
                // SettingHelper.ShowBlood = true;
                // SettingHelper.ShowEffect = true;
                // SettingHelper.ShowGuangHuan = true;
                // SettingHelper.ShowAnimation = true;
                // SettingHelper.PlaySound = true;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#resetall"))
            {
                // SettingHelper.ShowBlood = false;
                // SettingHelper.ShowEffect = false;
                // SettingHelper.ShowGuangHuan = false;
                // SettingHelper.ShowAnimation = false;
                // SettingHelper.PlaySound = false;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (mask)
            {
                Log.Error("请重新输入！");
                return;
            }

            int itemType = self.CurrentChatType;
            // if (itemType == (int)ChannelEnum.Team && !self.Root().GetComponent<TeamComponent>().IsHaveTeam())
            // {
            //     FloatTipManager.Instance.ShowFloatTip("没有队伍！");
            //     return;
            // }

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
                    GMHelp.SendGmCommands(self.Root(), text);
                    return;
                }

                GMHelp.SendGmCommand(self.Root(), text);
            }
            else
            {
                await ChatNetHelper.RequestSendChat(self.Root(), itemType, text);
            }

            self.View.E_ChatInputField.GetComponent<InputField>().text = "";
        }

        private static void OnChatItemsRefresh(this DlgChat self, Transform transform, int index)
        {
            Scroll_Item_ChatItem scrollItemChatItem = self.ScrollItemChatItems[index].BindTrans(transform);
            scrollItemChatItem.Refresh(self.ShowChatInfos[index]);
        }

        private static void OnFunctionSetBtn(this DlgChat self, int index)
        {
            self.CurrentChatType = index;
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