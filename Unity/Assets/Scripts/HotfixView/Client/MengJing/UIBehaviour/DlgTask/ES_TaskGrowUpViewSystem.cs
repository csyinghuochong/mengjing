using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TaskGrowUpItem))]
    [EntitySystemOf(typeof(ES_TaskGrowUp))]
    [FriendOfAttribute(typeof(ES_TaskGrowUp))]
    public static partial class ES_TaskGrowUpSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskGrowUp self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TaskGrowUpItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTaskGrowUpItemsRefresh);
            self.E_GetBtnButton.AddListenerAsync(self.OnGetBtnButton);
            self.E_GiveBtnButton.AddListenerAsync(self.OnGiveBtnButton);
            self.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            int page = 0;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            self.CompeletTaskId = numericComponentC.GetAsInt(NumericType.SystemTask);
            
            if (self.CompeletTaskId > 0)
            {
                float fff = (self.CompeletTaskId - ConfigData.TaskGrowUpInitId) / 10f;
                page = Mathf.FloorToInt(fff);
            }
            Log.Debug($"page:{page}  self.CompeletTaskId:{self.CompeletTaskId}  ");
            self.E_FunctionSetBtnToggleGroup.OnSelectIndex(page);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskGrowUp self)
        {
            self.DestroyWidget();
        }

        private static void OnFunctionSetBtn(this ES_TaskGrowUp self, int index)
        {
              Log.Debug($"OnFunctionSetBtn: {index}");
              self.SelectIndex = index;
              self.UpdateTask(index);
              self.UpdateReward(index);
        }

        private static void UpdateReward(this ES_TaskGrowUp self, int index)
        {
            List<int> skillids = ConfigData.TaskGrowUpRewardConfig.Values.ToList();
            self.ES_CommonSkillItem_0.OnUpdateUI(skillids[3 * index + 0]);
            self.ES_CommonSkillItem_1.OnUpdateUI(skillids[3 * index + 1]);
            self.ES_CommonSkillItem_2.OnUpdateUI(skillids[3 * index + 2]);
            self.ES_CommonSkillItem_0.SetSelectAction(self.OnBeginDragHandler);
            self.ES_CommonSkillItem_1.SetSelectAction(self.OnBeginDragHandler);
            self.ES_CommonSkillItem_2.SetSelectAction(self.OnBeginDragHandler);
            
            List<int> keyids = ConfigData.TaskGrowUpRewardConfig.Keys.ToList();
            int completeNum = self.CompeletTaskId - ConfigData.TaskGrowUpInitId;
            completeNum = Mathf.Max(0, completeNum);
            if (completeNum < keyids[3 * index + 0] )
            {
                self.ES_CommonSkillItem_0.SetImageGray(true);
            }
            if (completeNum < keyids[3 * index + 1] )
            {
                self.ES_CommonSkillItem_1.SetImageGray(true);
            }
            if (completeNum < keyids[3 * index + 2] )
            {
                self.ES_CommonSkillItem_2.SetImageGray(true);
            }

            using (zstring.Block())
            {
                self.E_TextProgress.text = zstring.Format("{0}/{1}", completeNum, keyids[3 * index + 2]);
            }

            self.E_Img_LodingValue.fillAmount = (float)completeNum / (float)keyids[3 * index + 2];  
        }

        private static void OnBeginDragHandler(this ES_TaskGrowUp self, int skillid)
        {
            int keyid = 0;
            var keys = ConfigData.TaskGrowUpRewardConfig.Where(pair => pair.Value == skillid).Select(pair => pair.Key);
            foreach (var key in keys)
            {
                keyid = key;
                break;
            }

            if (keyid == 0)
            {
                return;
            }
            
            int completeNum = self.CompeletTaskId - ConfigData.TaskGrowUpInitId;   
            completeNum = Mathf.Max(0, completeNum);
            if (completeNum < keyid)
            {
                FlyTipComponent.Instance.ShowFlyTip("未达到领取条件！"); 
                return;
            }

            TaskComponentC taskComponentC = self.Root().GetComponent<TaskComponentC>(); 
            if (taskComponentC.ReceiveGrowUpRewardIds.Contains(keyid))
            {
                FlyTipComponent.Instance.ShowFlyTip("奖励已领取！"); 
            }
            else
            {
                //领取奖励
                TaskClientNetHelper.TaskGrowUpRewardRequest(self.Root(), keyid).Coroutine();
            }

            Log.Debug($"keyid:  {keyid}  skillid: {skillid}");
        }

        private static void OnTaskGrowUpItemsRefresh(this ES_TaskGrowUp self, Transform transform, int index)
        {
            foreach (Scroll_Item_TaskGrowUpItem item in self.ScrollItemTaskGrowUpItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_TaskGrowUpItem scrollItemTaskGrowUpItem = self.ScrollItemTaskGrowUpItems[index].BindTrans(transform);
            int i = index % 4;
            Vector3 posi = Vector3.zero;
            int dre = 1;
            if (i == 0)
            {
                posi = new Vector3(-250, 0, 0);
                dre = 1;
            }
            else if (i == 1)
            {
                posi = new Vector3(0, 0, 0);
                dre = 1;
            }
            else if (i == 2)
            {
                posi = new Vector3(250, 0, 0);
                dre = -1;
            }
            else if (i == 3)
            {
                posi = new Vector3(0, 0, 0);
                dre = -1;
            }

           
            if (dre == 1)
            {
              
            }
            else
            {
                
            }

            scrollItemTaskGrowUpItem.OnUpdateData(self.ShowTaskConfigIds[index]);
            scrollItemTaskGrowUpItem.SetCurId( self.TaskPro.taskID );
        }

        public static void UpdateTask(this ES_TaskGrowUp self, int page)
        {
            if(page < 0)
            {
                return;
            }
            
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            self.CompeletTaskId = numericComponentC.GetAsInt(NumericType.SystemTask);
            // 测试
            //self.CompeletTaskId = 82000014;
            
            int minId = ConfigData.TaskGrowUpInitId + page * 10 + 1;
            int maxId = minId + 9;
            
            Log.Debug($"minid: {minId}  maxid:{maxId}");

            List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().RoleTaskList;
            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if (taskConfig.TaskType != TaskTypeEnum.System)
                {
                    continue;
                }

                self.TaskPro = taskPros[i];
                break;
            }

            if (self.TaskPro == null && self.CompeletTaskId > 0)
            {
                TaskPro taskPro = TaskPro.Create();
                taskPro.taskID = self.CompeletTaskId;
                self.TaskPro = taskPro;
            }

            Log.Debug($"taskPro:  {self.TaskPro.taskID}");
            
            int index = 0;

            self.ShowTaskConfigIds.Clear();
            foreach (TaskConfig taskConfig in TaskConfigCategory.Instance.GetAll().Values)
            {
                if (taskConfig.TaskType != TaskTypeEnum.System)
                {
                    continue;
                }
                
                if (taskConfig.Id < minId || taskConfig.Id > maxId)
                {
                    continue;
                }
                
                self.ShowTaskConfigIds.Add(taskConfig.Id);

                if (taskConfig.Id == self.TaskPro.taskID)
                {
                    index = self.ShowTaskConfigIds.Count;
                }
            }
            
            RectTransform Content = self.E_TaskGrowUpItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>();
            Content.anchoredPosition = Vector3.zero;
            Content.gameObject.SetActive(false);
            Content.gameObject.SetActive(true); 
            
            self.AddUIScrollItems(ref self.ScrollItemTaskGrowUpItems, self.ShowTaskConfigIds.Count);
            self.E_TaskGrowUpItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskConfigIds.Count);

            self.UpdateInfo(self.TaskPro.taskID);

            // 滑动到对应位置
           
            //Vector3 vector3 = self.E_TaskGrowUpItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition;
            //vector3.y = index * 160;
            //self.E_TaskGrowUpItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition = vector3;
        }

        
         public static void OnRecvReward(this ES_TaskGrowUp self, int page)
        {
            if(page < 0)
            {
                return;
            }
            
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            self.CompeletTaskId = numericComponentC.GetAsInt(NumericType.SystemTask);
            // 测试
            //self.CompeletTaskId = 82000014;
            
            List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().RoleTaskList;
            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if (taskConfig.TaskType != TaskTypeEnum.System)
                {
                    continue;
                }

                self.TaskPro = taskPros[i];
                break;
            }

            if (self.TaskPro == null && self.CompeletTaskId > 0)
            {
                TaskPro taskPro = TaskPro.Create();
                taskPro.taskID = self.CompeletTaskId;
                self.TaskPro = taskPro;
            }

            Log.Debug($"taskPro:  {self.TaskPro.taskID}");
            for (int i = 0; i < self.ScrollItemTaskGrowUpItems.Count; i++)
            {
                Scroll_Item_TaskGrowUpItem scrollItemTaskGrowUpItem = self.ScrollItemTaskGrowUpItems[i];
                if (scrollItemTaskGrowUpItem.uiTransform == null)
                {
                    continue;
                }

                scrollItemTaskGrowUpItem.SetCurId( self.TaskPro.taskID );
            }
        }
        
        public static void UpdateInfo(this ES_TaskGrowUp self, int taskId)
        {
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            self.E_TaskNameTextText.text = taskConfig.TaskName;
            if (taskId < self.TaskPro.taskID || (taskId == self.TaskPro.taskID && taskId == self.CompeletTaskId))
            {
                // 已经完成
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 ||
                    taskConfig.TargetType == (int)TaskTargetType.GivePet_25 ||
                    taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                    taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                    taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = "1/1";
                        self.E_Img_LodingValue_22.fillAmount = 1;   
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}/{1}",taskConfig.TargetValue[0], taskConfig.TargetValue[0]);
                        self.E_Img_LodingValue_22.fillAmount = taskConfig.TargetValue[0] * 1f/taskConfig.TargetValue[0] ;   
                    }
                }

                self.E_AcvityedImgImage.gameObject.SetActive(true);
                self.E_GetBtnButton.gameObject.SetActive(false);
                self.E_GiveBtnButton.gameObject.SetActive(false);
            }
            else
            {
                // 进行中
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 || taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = "0/1";
                        self.E_Img_LodingValue_22.fillAmount = 0f;   
                    }

                    self.E_GetBtnButton.gameObject.SetActive(false);
                    self.E_GiveBtnButton.gameObject.SetActive(true);
                }
                else if (taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                         taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                         taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Completed)
                    {
                        using (zstring.Block())
                        {
                            self.E_ProgressTextText.text = "1/1";
                            self.E_Img_LodingValue_22.fillAmount = 1f;   
                        }

                        self.E_GetBtnButton.gameObject.SetActive(true);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        using (zstring.Block())
                        {
                            self.E_ProgressTextText.text = "0/1";
                            self.E_Img_LodingValue_22.fillAmount = 0f;   
                        }

                        self.E_GetBtnButton.gameObject.SetActive(true);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}/{1}",self.TaskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
                        self.E_Img_LodingValue_22.fillAmount = self.TaskPro.taskTargetNum_1 * 1f/taskConfig.TargetValue[0];   
                    }

                    self.E_GetBtnButton.gameObject.SetActive(true);
                    self.E_GiveBtnButton.gameObject.SetActive(false);
                }

                if (taskId > self.TaskPro.taskID)
                {
                    self.E_GetBtnButton.gameObject.SetActive(false);
                    self.E_GiveBtnButton.gameObject.SetActive(false);
                }

                self.E_AcvityedImgImage.gameObject.SetActive(false);
            }

            self.E_TaskDescTextText.text = taskConfig.TaskDes;

            List<RewardItem> rewardItems = new List<RewardItem>();
            if (taskConfig.TaskCoin != 0)
            {
                rewardItems.Add(new RewardItem() { ItemID = 1, ItemNum = taskConfig.TaskCoin });
            }

            if (taskConfig.TaskExp != 0)
            {
                rewardItems.Add(new RewardItem() { ItemID = 2, ItemNum = taskConfig.TaskExp });
            }

            rewardItems.AddRange(TaskHelper.GetTaskRewards(taskId));
            self.ES_RewardList.Refresh(rewardItems);

            for (int i = 0; i < self.ScrollItemTaskGrowUpItems.Count; i++)
            {
                Scroll_Item_TaskGrowUpItem scrollItemTaskGrowUpItem = self.ScrollItemTaskGrowUpItems[i];
                if (scrollItemTaskGrowUpItem.uiTransform != null)
                {
                    scrollItemTaskGrowUpItem.Selected(taskId);
                }
            }
        }

        public static async ETTask OnGetBtnButton(this ES_TaskGrowUp self)
        {
            if (self.TaskPro.taskStatus < (int)TaskStatuEnum.Completed)
            {
                FlyTipComponent.Instance.ShowFlyTip("任务还没有完成！");
                return;
            }

            if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过奖励！");
                return;
            }

            await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskPro.taskID, 0);
            self.OnRecvReward(self.SelectIndex);
            self.UpdateReward(self.SelectIndex);
        }

        public static async ETTask OnGiveBtnButton(this ES_TaskGrowUp self)
        {
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskPro.taskID);
            if (taskConfig.TargetType == TaskTargetType.GiveItem_10)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GiveTask);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGiveTask>().InitTask(self.TaskPro.taskID);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGiveTask>().OnGiveAction = self.UpdateTaskB;
            }
            else if (taskConfig.TargetType == TaskTargetType.GivePet_25)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GiveTask);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>().InitTask(self.TaskPro.taskID);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>().OnGiveAction = self.UpdateTaskB;
            }
        }

        public static void UpdateTaskB(this ES_TaskGrowUp self)
        {
            self.UpdateTask(self.SelectIndex);
        }
    }
}
