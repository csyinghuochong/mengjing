using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGet_DlgTaskGetRefresh : AEvent<Scene, TaskGet>
    {
        protected override async ETTask Run(Scene scene, TaskGet args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTaskGet>()?.OnTaskGet();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_TaskRewardItem))]
    [FriendOf(typeof(Scroll_Item_TaskFubenItem))]
    [FriendOf(typeof(Scroll_Item_TaskGetItem))]
    [FriendOf(typeof(DlgTaskGet))]
    public static class DlgTaskGetSystem
    {
        public static void RegisterUIEvent(this DlgTaskGet self)
        {
            // self.View.E_TaskGetItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTaskGetItemsRefresh);
            // self.View.E_TaskFubenItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTaskFubenItemsRefresh);
            // self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);

            self.View.E_Btn_EnergyDuihuanButton.AddListenerAsync(self.OnBtn_EnergyDuihuanButton);
            self.View.E_ButtonGetButton.AddListenerAsync(self.OnButtonGetButton);
            self.View.E_BtnCommitTask1Button.AddListenerAsync(self.OnBtnCommitTask1Button);
            self.View.E_ButtonJieRiRewardButton.AddListener(self.OnButtonJieRiRewardButton);
            self.View.E_ButtonExpDuiHuanButton.AddListenerAsync(self.OnButtonExpDuiHuanButton);
            self.View.E_Img_buttonButton.AddListener(self.OnImg_buttonButton);
            self.View.E_ButtonPetFragmentButton.AddListener(self.OnButtonPetFragmentButton);
            self.View.E_ButtonGiveTaskButton.AddListenerAsync(self.OnButtonGiveTaskButton);
            self.View.E_ButtonMysteryButton.AddListener(self.OnButtonMysteryButton);
            self.View.E_ButtonReturnButton.AddListener(self.OnButtonReturnButton);
            self.View.E_CancelNpcSpeakButton.AddListener(() => { self.CancellationToken?.Cancel(); });
        }

        public static void ShowWindow(this DlgTaskGet self, Entity contextData = null)
        {
            self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Main);
        }
        
        public static void BeforeUnload(this DlgTaskGet self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
            
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }
            self.AssetList.Clear();
            self.AssetList = null;
            self.CancellationToken?.Cancel();
        }

        private static void OnTaskFubenItemsRefresh(this DlgTaskGet self, Transform transform, int index)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.NpcID);
            List<int> fubenList = new List<int>(npcConfig.NpcPar);

            Scroll_Item_TaskFubenItem scrollItemTaskFubenItem = self.ScrollItemTaskFubenItems[index].BindTrans(transform);
            scrollItemTaskFubenItem.OnInitData((npcType, fubenId) => { self.OnClickFubenItem(npcType, fubenId); }, npcConfig.NpcType,
                fubenList[index]);
        }

        public static void OnTaskGet(this DlgTaskGet self)
        {
            bool update = self.UpdataTask();
            if (!update)
            {
                self.OnImg_buttonButton();
            }
        }

        public static void OnImg_buttonButton(this DlgTaskGet self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Guide);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TaskGet);
        }

        public static async ETTask OnButtonExpDuiHuanButton(this DlgTaskGet self)
        {
            await UserInfoNetHelper.ExpToGoldRequest(self.Root(), 2);
            await ETTask.CompletedTask;
        }

        public static void OnButtonJieRiRewardButton(this DlgTaskGet self)
        {
            int activityId = ActivityHelper.GetJieRiActivityId();
            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);
            if (activityConfig == null)
            {
                return;
            }

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (activityComponent.ActivityReceiveIds.Contains(activityId))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过奖励！");
            }

            ActivityNetHelper.ActivityReceive(self.Root(), activityConfig.ActivityType, activityId).Coroutine();
            self.View.E_ButtonJieRiRewardButton.gameObject.SetActive(false);
        }

        public static void InitData(this DlgTaskGet self, int npcID)
        {
            self.NpcID = npcID;
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcID);

            //显示Npc对话   
            self.CancellationToken?.Cancel();
            self.CancellationToken = new ETCancellationToken();
            CommonViewHelper.TextPrinter(self.Root(), self.View.E_Lab_NpcSpeakText, "   " + npcConfig.SpeakText, self.CancellationToken, 20)
                    .Coroutine();
            
            self.View.E_Lab_NpcNameText.text = npcConfig.Name;
            self.View.E_BtnCommitTask1Button.gameObject.SetActive(false);
            self.View.E_ButtonGetButton.gameObject.SetActive(false);
            self.View.E_TaskFubenItemsScrollRect.gameObject.SetActive(false);
            self.View.E_TaskGetItemsScrollRect.gameObject.SetActive(false);
            self.View.EG_EnergySkillRectTransform.gameObject.SetActive(false);
            self.View.E_ButtonJieRiRewardImage.gameObject.SetActive(false);
            self.View.E_ButtonExpDuiHuanButton.gameObject.SetActive(false);
            self.View.E_ButtonPetFragmentButton.gameObject.SetActive(false);
            self.View.E_ButtonGiveTaskButton.gameObject.SetActive(false);
            self.View.E_ButtonMysteryButton.gameObject.SetActive(false);
            self.View.EG_TaskDescRectTransform.gameObject.SetActive(false);
            self.View.E_ButtonReturnButton.gameObject.SetActive(false);  
            
            switch (npcConfig.NpcType)
            {
                case 1: //神兽兑换
                case 2: //挑戰之地
                {
                    self.View.E_TaskFubenItemsScrollRect.gameObject.SetActive(true);
                    if (npcConfig.NpcPar != null)
                    {
                        List<int> fubenList = new List<int>(npcConfig.NpcPar);

                        ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
                        for (int i = 0; i < npcConfig.NpcPar.Length; i++)
                        {
                            if (!self.ScrollItemTaskFubenItems.ContainsKey(i))
                            {
                                Scroll_Item_TaskFubenItem item = self.AddChild<Scroll_Item_TaskFubenItem>();
                                string prefabPath = "Assets/Bundles/UI/Item/Item_TaskFubenItem.prefab";
                                if (!self.AssetList.Contains(prefabPath))
                                {
                                    self.AssetList.Add(prefabPath);
                                }

                                GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(prefabPath);
                                GameObject gameObject = UnityEngine.Object.Instantiate(prefab, self.View.E_TaskFubenItemsScrollRect.transform.Find("Content").gameObject.transform);
                                item.BindTrans(gameObject.transform);
                                self.ScrollItemTaskFubenItems.Add(i, item);
                            }

                            Scroll_Item_TaskFubenItem scrollItemTaskFubenItem = self.ScrollItemTaskFubenItems[i];
                            scrollItemTaskFubenItem.uiTransform.gameObject.SetActive(true);
                            scrollItemTaskFubenItem.OnInitData((npcType, fubenId) => { self.OnClickFubenItem(npcType, fubenId); }, npcConfig.NpcType,
                                fubenList[i]);
                        }

                        if (self.ScrollItemTaskFubenItems.Count > fubenList.Count)
                        {
                            for (int i = fubenList.Count; i < self.ScrollItemTaskFubenItems.Count; i++)
                            {
                                Scroll_Item_TaskFubenItem scrollItemTaskFubenItem = self.ScrollItemTaskFubenItems[i];
                                scrollItemTaskFubenItem.uiTransform.gameObject.SetActive(false);
                            }
                        }

                        // self.AddUIScrollItems(ref self.ScrollItemTaskFubenItems, fubenList.Count);
                        // self.View.E_TaskFubenItemsLoopVerticalScrollRect.SetVisible(true, fubenList.Count);
                    }

                    break;
                }
                case 3: //循环任务 周任务 支线任务 藏宝图任务
                    bool update = self.UpdataTask();
                    self.View.E_TaskGetItemsScrollRect.gameObject.SetActive(update);
                    break;
                case 4: //魔能老人
                    int costItemID = int.Parse(ConfigData.EnergySkillCost.Split(';')[0]);
                    long itemNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(costItemID);
                    self.View.EG_EnergySkillRectTransform.gameObject.SetActive(true);
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(costItemID);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                    self.View.E_EnergySkillImageImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    //获取
                    using (zstring.Block())
                    {
                        self.View.E_Lab_MoNnengHintText.text =
                                zstring.Format("{0}  {1}/5", ItemConfigCategory.Instance.Get(costItemID).ItemName, itemNum);
                    }

                    break;
                case 5: //补偿大师
                    self.View.E_TaskFubenItemsScrollRect.gameObject.SetActive(true);
                    PlayerInfoComponent accountInfo = self.Root().GetComponent<PlayerInfoComponent>();
                    int buchangNumber = BuChangHelper.ShowNewBuChang(accountInfo.PlayerInfo, accountInfo.CurrentRoleId, accountInfo.ServerItem.ServerId);
                    GameObject go = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Item/Item_TaskFubenItem.prefab");
                    if (buchangNumber > 0)
                    {
                        GameObject goitem = UnityEngine.Object.Instantiate(go);
                        goitem.SetActive(true);
                        CommonViewHelper.SetParent(goitem, self.View.E_TaskFubenItemsScrollRect.transform.Find("Content").gameObject);
                        Scroll_Item_TaskFubenItem uIBuChangItem = self.AddChild<Scroll_Item_TaskFubenItem>();
                        uIBuChangItem.uiTransform = goitem.transform;
                        uIBuChangItem.OnInitUI_2((long userid) => { self.OnClickBuChangItem(userid); }, buchangNumber);
                    }
                    else
                    {
                        for (int i = 0; i < accountInfo.PlayerInfo.DeleteUserList.Count; i++)
                        {
                            GameObject goitem = UnityEngine.Object.Instantiate(go);
                            goitem.SetActive(true);
                            CommonViewHelper.SetParent(goitem, self.View.E_TaskFubenItemsScrollRect.transform.Find("Content").gameObject);
                            Scroll_Item_TaskFubenItem uIBuChangItem = self.AddChild<Scroll_Item_TaskFubenItem>();
                            uIBuChangItem.uiTransform = goitem.transform;
                            uIBuChangItem.OnInitUI((long userid) => { self.OnClickBuChangItem(userid); }, accountInfo.PlayerInfo.DeleteUserList[i]);
                        }
                    }

                    break;
                case 6: //节日使者
                    int activityId = ActivityHelper.GetJieRiActivityId();
                    ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
                    self.View.E_ButtonJieRiRewardButton.gameObject.SetActive(activityId > 0 &&
                        !activityComponent.ActivityReceiveIds.Contains(activityId));

                    if (activityId == 0)
                    {
                        int nextid = ActivityHelper.GetNextRiActivityId();
                        ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(nextid);
                        string[] riqi = activityConfig.Par_1.Split(';');
                        string speek = self.View.E_Lab_NpcSpeakText.text;
                        using (zstring.Block())
                        {
                            self.View.E_Lab_NpcSpeakText.text =
                                    zstring.Format("{0} 下次领取时间:{1}月{2}日 {3}", speek, riqi[0], riqi[1], activityConfig.Par_4);
                        }
                    }

                    break;
                case 8: //经验兑换
                    self.View.E_ButtonExpDuiHuanButton.gameObject.SetActive(true);
                    break;
                case 9:
                    self.View.E_ButtonPetFragmentButton.gameObject.SetActive(true);
                    break;
                case 10: //神秘之门
                    self.View.E_ButtonMysteryButton.gameObject.SetActive(true);
                    break;
                default:
                    self.View.E_TaskGetItemsScrollRect.gameObject.SetActive(true);
                    self.UpdataTask();
                    break;
            }
        }

        public static async ETTask ShowGuide(this DlgTaskGet self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(100);
            if (self.IsDisposed)
            {
                return;
            }

            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UITaskGet");
        }

        public static void OnButtonWeeklyCommit(this DlgTaskGet self)
        {
            self.OnBtnCommitTask1Button().Coroutine();
        }

        public static void OnButtonWeeklyGet(this DlgTaskGet self)
        {
            TaskClientNetHelper.RequestGetTask(self.Root(), self.TaskId).Coroutine();
        }

        public static void OnButtonPetFragmentButton(this DlgTaskGet self)
        {
            if (!PetHelper.IsShenShouFull(self.Root().GetComponent<PetComponentC>().RolePetInfos))
            {
                FlyTipComponent.Instance.ShowFlyTip("神兽未满不能对话！");
                return;
            }

            if (self.Root().GetComponent<BagComponentC>().GetItemNumber(10000136) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("神兽碎片不足！");
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(ConfigData.PetFramgeItemId);
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "碎片兑换", zstring.Format("是否消耗一个神兽碎片兑换一个{0}", itemConfig.ItemName),
                    () => { self.RequestFramegeDuiHuan().Coroutine(); }, null).Coroutine();
            }
        }

        public static async ETTask RequestFramegeDuiHuan(this DlgTaskGet self)
        {
            await PetNetHelper.PetFragmentDuiHuan(self.Root());
        }

        public static void OnClickBuChangItem(this DlgTaskGet self, long userid)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "补偿大师", "请求补偿", () => { self.RequestBuChangItem(userid).Coroutine(); }).Coroutine();
        }

        public static async ETTask RequestBuChangItem(this DlgTaskGet self, long userid)
        {
            M2C_BuChangeResponse response = await UserInfoNetHelper.BuChangeRequest(self.Root(), userid);
            PlayerInfoComponent accountInfoInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            accountInfoInfoComponent.PlayerInfo = response.PlayerInfo;

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TaskGet);
            await ETTask.CompletedTask;
        }

        public static void OnClickFubenItem(this DlgTaskGet self, int npcType, int configId)
        {
            if (configId == 0)
            {
                return;
            }

            if (npcType == 1)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "神兽兑换", ItemViewHelp.ShowDuiHuanPet(configId),
                    () => { self.ReqestPetDuiHuan(configId).Coroutine(); }).Coroutine();
            }

            if (npcType == 2)
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(configId);

                using (zstring.Block())
                {
                    zstring desStr = zstring.Format("是否进入{0}?", sceneConfig.Name);
                    if (sceneConfig.DayEnterNum >= 1)
                    {
                        desStr += zstring.Format("\n提示:每天只能进入{0}次", sceneConfig.DayEnterNum);
                    }

                    PopupTipHelp.OpenPopupTip(self.Root(), "进入地图", desStr, () => { self.RequestEnterFuben(configId).Coroutine(); }).Coroutine();
                }
            }
        }

        public static async ETTask ReqestPetDuiHuan(this DlgTaskGet self, int configId)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int petexpendNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber);

            if (PetHelper.GetBagPetNum(petComponent.RolePetInfos) >=
                PetHelper.GetPetMaxNumber(self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv, petexpendNumber))
            {
                FlyTipComponent.Instance.ShowFlyTip("已达到最大宠物数量！");
                return;
            }

            M2C_PetDuiHuanResponse response = await PetNetHelper.PetDuiHuanRequest(self.Root(), configId);
            if (response.RolePetInfo == null)
            {
                return;
            }
        }

        public static async ETTask RequestEnterFuben(this DlgTaskGet self, int sceneId)
        {
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            int sceneType = sceneConfig.MapType;
            if (sceneType == MapTypeEnum.Arena)
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                if (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.ArenaNumber) > 0)
                {
                    FlyTipComponent.Instance.ShowFlyTip("次数不足！");
                    return;
                }

                if (!FunctionHelp.IsInTime(1031))
                {
                    FlyTipComponent.Instance.ShowFlyTip("不在活动时间内！");
                    return;
                }
            }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), sceneType, sceneId);
            if (errorCode == ErrorCode.ERR_Success && !self.IsDisposed)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TaskGet);
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask OnBtn_EnergyDuihuanButton(this DlgTaskGet self)
        {
            Actor_FubenEnergySkillRequest request = new();
            Actor_FubenEnergySkillResponse response =
                    (Actor_FubenEnergySkillResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == 0)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TaskGet);
            }
            else
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNotEnoughError);
            }

            await ETTask.CompletedTask;
        }

        public static List<int> GetAddtionTaskId(this DlgTaskGet self, int npcId)
        {
            List<int> addTaskids = new List<int>();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            if (npcId == 1008) //主城任务公告面板
            {
                // int weeklyTask = numericComponent.GetAsInt(NumericType.WeeklyTaskId);
                // if (weeklyTask > 0 && taskComponent.GetTaskTypeList(TaskTypeEnum.Weekly).Count == 0)
                // {
                //     addTaskids.Add(weeklyTask);
                // }

                int dailyTaskId = numericComponent.GetAsInt(NumericType.DailyTaskID);
                if (dailyTaskId > 0 && taskComponent.GetTaskById(dailyTaskId) == null)
                {
                    addTaskids.Add(dailyTaskId);
                }
            }

            if (npcId == 2002) //公会任务
            {
                int unionTaskId = numericComponent.GetAsInt(NumericType.UnionTaskId);
                if (unionTaskId > 0 && taskComponent.GetTaskById(unionTaskId) == null)
                {
                    addTaskids.Add(unionTaskId);
                }

                int ringTaskId = numericComponent.GetAsInt(NumericType.RingTaskId);
                if (ringTaskId > 0 && taskComponent.GetTaskById(ringTaskId) == null)
                {
                    addTaskids.Add(ringTaskId);
                }
            }

            return addTaskids;
        }

        //如果当前有任务接取了还没完成，则什么都不显示
        public static bool UpdataTask(this DlgTaskGet self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();

            //获取npc任务
            List<int> taskids = new List<int>();

            List<TaskPro> taskProCompleted = taskComponent.GetCompltedTaskByNpc(self.NpcID);
            for (int i = 0; i < taskProCompleted.Count; i++)
            {
                taskids.Add(taskProCompleted[i].taskID);
            }

            taskids.AddRange(taskComponent.GetOpenTaskIds(self.NpcID));
            taskids.AddRange(self.GetAddtionTaskId(self.NpcID));

            //给予任务
            List<TaskPro> taskPros = taskComponent.RoleTaskList;
            for (int i = 0; i < taskPros.Count; i++)
            {
                if (taskids.Contains(taskPros[i].taskID))
                {
                    continue;
                }

                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if ((taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 || taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
                    && taskConfig.CompleteNpcID == self.NpcID)
                {
                    taskids.Add(taskPros[i].taskID);
                }
                else if ((taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 || taskConfig.TargetType == (int)TaskTargetType.GivePet_25) &&
                         taskConfig.TaskType == TaskTypeEnum.Ring && self.NpcID == 20000102)
                {
                    // 公会给予任务可以CompleteNpcID==0，找公会任务NPC提交
                    taskids.Add(taskPros[i].taskID);
                }
            }

            //当前没有接取任务
            self.ShowTaskId.Clear();
            self.ShowTaskId.AddRange(taskids);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowTaskId.Count; i++)
            {
                if (!self.ScrollItemTaskGetItems.ContainsKey(i))
                {
                    Scroll_Item_TaskGetItem item = self.AddChild<Scroll_Item_TaskGetItem>();
                    string path = "Assets/Bundles/UI/Item/Item_TaskGetItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab,self.View.E_TaskGetItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemTaskGetItems.Add(i, item);
                }
                
                Scroll_Item_TaskGetItem scrollItemTaskGetItem = self.ScrollItemTaskGetItems[i];
                scrollItemTaskGetItem.uiTransform.gameObject.SetActive(true);
                scrollItemTaskGetItem.InitData(self.ShowTaskId[i]);
                scrollItemTaskGetItem.SetClickHandler((int taskid) => { self.OnSelectTaskHandler(taskid); });
            }

            if (self.ScrollItemTaskGetItems.Count > self.ShowTaskId.Count)
            {
                for (int i = self.ShowTaskId.Count; i < self.ScrollItemTaskGetItems.Count; i++)
                {
                    Scroll_Item_TaskGetItem scrollItemTaskGetItem = self.ScrollItemTaskGetItems[i];
                    scrollItemTaskGetItem.uiTransform.gameObject.SetActive(false);
                }
            }

            self.ShowGuide().Coroutine();
            // self.AddUIScrollItems(ref self.ScrollItemTaskGetItems, self.ShowTaskId.Count);
            // self.View.E_TaskGetItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskId.Count);

            if (self.ShowTaskId.Count > 0)
            {
                //Scroll_Item_TaskGetItem scrollItemTaskGetItem = self.ScrollItemTaskGetItems[0];
                //scrollItemTaskGetItem.OnClickSelectTask();
                return true;
            }

            return false;
        }

        private static void OnTaskGetItemsRefresh(this DlgTaskGet self, Transform transform, int index)
        {
            Scroll_Item_TaskGetItem scrollItemTaskGetItem = self.ScrollItemTaskGetItems[index].BindTrans(transform);
            scrollItemTaskGetItem.InitData(self.ShowTaskId[index]);
            scrollItemTaskGetItem.SetClickHandler((int taskid) => { self.OnSelectTaskHandler(taskid); });
        }
        
        public static void OnSelectTaskHandler(this DlgTaskGet self, int taskid)
        {
            self.TaskId = taskid;

            for (int i = 0; i < self.ScrollItemTaskGetItems.Count; i++)
            {
                Scroll_Item_TaskGetItem scrollItemTaskGetItem = self.ScrollItemTaskGetItems[i];

                if (scrollItemTaskGetItem.uiTransform == null)
                {
                    continue;
                }

                scrollItemTaskGetItem.SetSelected(taskid);
            }

            TaskPro taskPro = self.Root().GetComponent<TaskComponentC>().GetTaskById(taskid);
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            if (taskConfig.TargetType == TaskTargetType.GiveItem_10 || taskConfig.TargetType == TaskTargetType.GivePet_25)
            {
                self.View.E_ButtonGiveTaskButton.gameObject.SetActive(taskPro != null);
                self.View.E_ButtonGetButton.gameObject.SetActive(taskPro == null);
            }
            else
            {
                bool isCompleted = taskPro != null && taskPro.taskStatus == (int)TaskStatuEnum.Completed;
                Log.Info($"是否完成 {isCompleted}");
                self.View.E_BtnCommitTask1Button.gameObject.SetActive(isCompleted);
                self.View.E_ButtonGiveTaskButton.gameObject.SetActive(false);
                self.View.E_ButtonGetButton.gameObject.SetActive(!isCompleted);
            }
            self.View.EG_TaskDescRectTransform.gameObject.SetActive(true);
            
            self.CancellationToken?.Cancel();
            self.CancellationToken = new ETCancellationToken();
            CommonViewHelper.TextPrinter(self.Root(), self.View.E_Lab_NpcSpeakText, taskConfig.TaskDes, self.CancellationToken, 20)
                    .Coroutine();
            
            self.View.E_Lab_NpcNameText.text = taskConfig.TaskName;    
            
            string rewardStr = taskConfig.RewardItem;
            int taskExp = (int)(taskConfig.TaskExp * 1);
            int taskCoin = (int)(taskConfig.TaskCoin * 1);
            if (CommonHelp.IfNull(rewardStr))
            {
                using (zstring.Block())
                {
                    rewardStr = zstring.Format("1;{0}@2;{1}", taskCoin, taskExp);
                }
            }
            else
            {
                using (zstring.Block())
                {
                    //rewardStr = 
                    rewardStr = zstring.Format("1;{0}@2;{1}@{2}", taskCoin, taskExp, rewardStr);
                }
            }
            List<RewardItem> rewardItems = ItemHelper.GetRewardItems(rewardStr);
            self.ShowBagInfos.Clear();
            foreach (RewardItem item in rewardItems)
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = item.ItemID;
                bagInfo.ItemNum = item.ItemNum;
                self.ShowBagInfos.Add(bagInfo);
            }
            
            self.View.ES_RewardList.Refresh(rewardItems);

            // self.AddUIScrollItems(ref self.ScrollItemTaskRewardItems, rewardItems.Count);
            // self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, rewardItems.Count);
            
            self.View.E_ButtonReturnButton.gameObject.SetActive(true);  
            self.View.E_TaskGetItemsScrollRect.gameObject.SetActive(false);
            
            self.ShowGuide().Coroutine();
        }
        
        private static void OnBagItemsRefresh(this DlgTaskGet self, Transform transform, int index)
        {
            foreach (Scroll_Item_TaskRewardItem item in self.ScrollItemTaskRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_TaskRewardItem scrollItemTaskGetItem = self.ScrollItemTaskRewardItems[index].BindTrans(transform);
            scrollItemTaskGetItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None);
        }

        public static void OnButtonReturnButton(this DlgTaskGet self)
        {
            if (self.IsDisposed)
            {
                return;
            }
            self.View.E_ButtonReturnButton.gameObject.SetActive(false);  
            self.View.E_TaskGetItemsScrollRect.gameObject.SetActive(true);
            self.UpdataTask();
            self.View.EG_TaskDescRectTransform.gameObject.SetActive(false);
            self.View.E_BtnCommitTask1Button.gameObject.SetActive(false);
            self.View.E_ButtonGetButton.gameObject.SetActive(false);
            
            self.CancellationToken?.Cancel();
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.NpcID);
            self.View.E_Lab_NpcNameText.text = npcConfig.Name;
            self.View.E_Lab_NpcSpeakText.text = "   " + npcConfig.SpeakText;
        }

        public static void OnButtonMysteryButton(this DlgTaskGet self)
        {
            int sceneId = self.Root().GetComponent<MapComponent>().SceneId;
            int chapterid = DungeonConfigCategory.Instance.DungeonToChapter[sceneId];
            int mysterDungeonid = DungeonSectionConfigCategory.Instance.GetMysteryDungeon(chapterid);
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, mysterDungeonid, 0, "0").Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TaskGet);
        }

        /// <summary>
        /// 给予道具任务
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnButtonGiveTaskButton(this DlgTaskGet self)
        {
            //打开界面选择道具。
            //给予道具和给予宠物界面分开
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskId);
            if (taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
            {
                // 给予宠物界面
                // 参考一下宠物界面 不能放生的宠物此处也不同提交。 添加道具检测一遍。  
                // 加个任务测试
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GivePet);
                DlgGivePet dlgGivePet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>();
                dlgGivePet.InitTask(self.TaskId);
                dlgGivePet.OnUpdateUI();
            }
            else
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GiveTask);
                DlgGiveTask dlgGiveTask = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGiveTask>();
                dlgGiveTask.InitTask(self.TaskId);
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GiveTask);
        }

        public static async ETTask OnButtonGetButton(this DlgTaskGet self)
        {
            if (self.TaskId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择一个任务");
                return;
            }

            await TaskClientNetHelper.RequestGetTask(self.Root(), self.TaskId);
            self.OnButtonReturnButton();
        }

        public static async ETTask OnBtnCommitTask1Button(this DlgTaskGet self)
        {
            long instanceid = self.InstanceId;
            Scene root = self.Root();
            int errorCode = await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskId, 0);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (errorCode == ErrorCode.ERR_Success)
            {
                FunctionEffect.PlaySelfEffect(UnitHelper.GetMyUnitFromClientScene(root), 200006);
                self.OnTaskGet();
                self.OnButtonReturnButton();
            }
            else
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
            }
        }
    }
}