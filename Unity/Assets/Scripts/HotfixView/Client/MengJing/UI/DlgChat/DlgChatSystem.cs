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

    [Invoke(TimerInvokeType.FindPathTimer)]
    [FriendOf(typeof(DlgChat))]
    public class FindPathTimer : ATimer<DlgChat>
    {
        protected override void Run(DlgChat self)
        {
            try
            {
                if(SettingData.ShowFindPath)
                {
                    if (SettingData.FindPathList.ContainsKey(self.FindPathIndex))
                    {
                        Log.Debug($"FrameIndex.ShowFindPath:    {self.FindPathIndex}");
                        Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
                        if (unit == null)
                        {
                            return;
                        }
                        float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
                        unit.GetComponent<MoveComponent>().MoveToAsync(SettingData.FindPathList[self.FindPathIndex].Points, speed).Coroutine();
                    }
                    self.FindPathIndex++;
                }
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
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
        }

        public static void ShowWindow(this DlgChat self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnCloseButton(this DlgChat self)
        {
            if(SettingData.ShowFindPath)
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
                unit.Position_2 = SettingData.FindPathEnd;
            }
            
            self.Root().GetComponent<TimerComponent>().Remove(ref self.FindPathTimer);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Chat);
        }

        private static void ShowFindPath(this DlgChat self)
        {
            self.FindPathIndex = SettingData.FindPathList.Keys.ToList()[0];
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            SettingData.FindPathEnd = unit.Position;
            unit.Position_2 = SettingData.FindPathInit;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.FindPathTimer);
            self.FindPathTimer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.FindPathTimer, self);
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
                GameObject  T1errain = GameObject.Find("AdditiveHide/ScenceModelSet/Directional Light (1)");
                T1errain.gameObject.SetActive(!T1errain.gameObject.activeSelf);
                return;
            }
            
            if (text.Equals("#showpath"))
            {
                self.ShowFindPath();
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
                //点击宠物按钮自身可以切换到对应的宠物上进行控制(摄像机跟随, 右下角也需要显示宠物的技能，被动技能不显示，主动技能超过格子数也不显示)  
                await PetNetHelper.RequestPetFightSwitch(self.Root(), 1);  //切换到第二个宠物
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
