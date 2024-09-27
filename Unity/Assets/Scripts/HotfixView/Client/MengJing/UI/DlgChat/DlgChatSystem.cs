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

  
    [FriendOf(typeof(PlayerComponent))]
    [FriendOf(typeof(DlgChat))]
    public static class DlgChatSystem
    {
        public static void RegisterUIEvent(this DlgChat self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_SendButton.AddListenerAsync(self.OnSendButton);
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

            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();

            bool mask = false;
            if (!ET.GMHelp.IsGmAccount(playerComponent.Account))
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

            if (text.Equals("#pool"))
            {
                SettingData.UsePool = !SettingData.UsePool;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#showmonster"))
            {
                SettingData.ShowMonster = !SettingData.ShowMonster;
                return;
            }

            if (text.Equals("#showterrain"))
            {
                SettingData.ShowTerrain = !SettingData.ShowTerrain;
                return;
            }

            if (text.Equals("#light"))
            {
                GameObject T1errain = GameObject.Find("AdditiveHide/ScenceModelSet/Directional Light (1)");
                T1errain.gameObject.SetActive(!T1errain.gameObject.activeSelf);
                return;
            }

            if (text.Equals("#petfight"))
            {
                //宠物出战列表 后期需要通过布阵界面去设置
                List<long> fightpets = self.Root().GetComponent<PetComponentC>().GetCanFightPetList();
                for (int i = fightpets.Count; i < 3; i++)
                {
                    fightpets.Add(0);
                }

                await PetNetHelper.RequestRolePetFormationSet(self.Root(), SceneTypeEnum.MainCityScene, fightpets, null);
                //刷新主界面下方的出战ui
                //点击宠物按钮自身可以切换到对应的宠物上进行控制(摄像机跟随)  
                return;
            }

            if (text.Equals("#petfightswitch"))
            {
                //宠物没有前冲技能  两个药瓶栏需要保留
                //其他逻辑都需要跟玩家一直，  需要测试一下吟唱技能之类的看看表现有没有问题。
                //模拟点击下方的三个宠物头像111
                //点击宠物按钮自身可以切换到对应的宠物上进行控制(摄像机跟随, 右下角也需要显示宠物的技能，被动技能不显示，主动技能超过格子数也不显示)  
                await PetNetHelper.RequestPetFightSwitch(self.Root(), RandomHelper.RandomNumber(0, 4)); //切换到第二个宠物

                //获取玩家或者宠物技能CD，  也可以保存在本地
                await PetNetHelper.RequestRolePetSkillCD(self.Root(), 0);
                //播放切换特效
                FunctionEffect.PlaySelfEffect(UnitHelper.GetMyUnitFromClientScene(self.Root()), 200004);
                //0自身 123对应的宠物， 切换后需要刷新技能
                return;
            }

            if (text.Equals("#openall"))
            {
                SettingData.ShowBlood = true;
                SettingData.ShowEffect = true;
                SettingData.ShowGuangHuan = true;
                SettingData.ShowAnimation = true;
                SettingData.PlaySound = true;
                self.View.E_ChatInputField.GetComponent<InputField>().text = "";
                return;
            }

            if (text.Equals("#resetall"))
            {
                SettingData.ShowBlood = false;
                SettingData.ShowEffect = false;
                SettingData.ShowGuangHuan = false;
                SettingData.ShowAnimation = false;
                SettingData.PlaySound = false;
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