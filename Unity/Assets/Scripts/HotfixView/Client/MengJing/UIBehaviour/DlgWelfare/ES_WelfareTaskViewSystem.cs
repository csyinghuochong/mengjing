using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_WelfareTaskItem))]
    [EntitySystemOf(typeof(ES_WelfareTask))]
    [FriendOfAttribute(typeof(ES_WelfareTask))]
    public static partial class ES_WelfareTaskSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WelfareTask self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ReceiveBtnButton.gameObject.SetActive(false);
            self.E_ReceivedImgImage.gameObject.SetActive(false);
            self.E_ReceiveBtnButton.AddListenerAsync(self.OnReceiveBtnButton);
            self.E_WelfareTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnWelfareTaskItemsRefresh);

            int currentDay = self.Root().GetComponent<UserInfoComponentC>().GetCrateDay() - 1;
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.EG_DayListNodeRectTransform.childCount; i++)
            {
                if (i <= currentDay)
                {
                    Image image = self.EG_DayListNodeRectTransform.GetChild(i).GetComponent<Image>();
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Img_82");
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    image.sprite = sp;
                    image.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1f);
                }
                else
                {
                    CommonViewHelper.SetImageGray(self.Root(), self.EG_DayListNodeRectTransform.GetChild(i).gameObject, true);
                }
            }

            Button[] buttons = self.EG_DayListNodeRectTransform.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                int i1 = i;
                buttons[i].onClick.AddListener(() => { self.UpdateInfo(i1); });
            }

            self.UpdateInfo(currentDay);
        }

        [EntitySystem]
        private static void Destroy(this ES_WelfareTask self)
        {
            self.DestroyWidget();
        }

        private static void OnWelfareTaskItemsRefresh(this ES_WelfareTask self, Transform transform, int index)
        {
            foreach (Scroll_Item_WelfareTaskItem item in self.ScrollItemWelfareTaskItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_WelfareTaskItem scrollItemWelfareTaskItem = self.ScrollItemWelfareTaskItems[index].BindTrans(transform);
            scrollItemWelfareTaskItem.OnUpdateData(self.ShowTaskPros[index], self.Day);
        }

        public static void UpdateInfo(this ES_WelfareTask self, int day)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();

            int currentDay = self.Root().GetComponent<UserInfoComponentC>().GetCrateDay() - 1;

            self.E_DayProgressImgImage.fillAmount = currentDay / 6f;

            if (day > currentDay)
            {
                return;
            }

            if (day > 6)
            {
                day = 6;
            }

            self.Day = day;

            self.ShowTaskPros.Clear();

            int commited = 0; // 完成并领取
            List<int> tasks = ConfigData.WelfareTaskList[day];
            List<int> roleComoleteTaskList = self.Root().GetComponent<TaskComponentC>().RoleComoleteTaskList;
            for (int i = 0; i < tasks.Count; i++)
            {
                TaskPro taskPro = taskComponent.GetTaskById(tasks[i]);
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(tasks[i]);
                if (taskPro == null && roleComoleteTaskList.Contains(tasks[i]))
                {
                    taskPro = TaskPro.Create();
                    taskPro.taskID = tasks[i];
                    taskPro.taskTargetNum_1 = taskConfig.TargetValue[0];
                    taskPro.taskStatus = (int)TaskStatuEnum.Commited;
                    using (zstring.Block())
                    {
                        Log.Debug(zstring.Format("已完成的任务 {0}", tasks[i]));
                    }
                }

                if (taskPro == null)
                {
                    using (zstring.Block())
                    {
                        Log.Error(zstring.Format("未领取的任务 {0}", tasks[i]));
                    }

                    taskPro = TaskPro.Create();
                    taskPro.taskID = tasks[i];
                    taskPro.taskTargetNum_1 = 0;
                    taskPro.taskStatus = (int)TaskStatuEnum.Accepted;
                }

                self.ShowTaskPros.Add(taskPro);

                if (roleComoleteTaskList.Contains(tasks[i]))
                {
                    commited++;
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemWelfareTaskItems, self.ShowTaskPros.Count);
            self.E_WelfareTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);

            using (zstring.Block())
            {
                self.E_CompletenessTextText.text = zstring.Format("当天完成度:{0}/{1}", commited, tasks.Count);
            }

            self.ES_RewardList.Refresh(ConfigData.WelfareTaskReward[day]);
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.WelfareTaskRewards.Contains(day))
            {
                self.E_ReceiveBtnButton.gameObject.SetActive(false);
                self.E_ReceivedImgImage.gameObject.SetActive(true);
            }
            else
            {
                self.E_ReceiveBtnButton.gameObject.SetActive(true);
                self.E_ReceivedImgImage.gameObject.SetActive(false);
            }
        }

        public static async ETTask OnReceiveBtnButton(this ES_WelfareTask self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();

            bool canget = TaskHelper.IsDayTaskComplete(taskComponent.RoleComoleteTaskList, self.Day);
            if (!canget)
            {
                FlyTipComponent.Instance.ShowFlyTip("所有任务还没有完成！");
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.WelfareTaskRewards.Contains(self.Day))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过奖励！");
                return;
            }

            await TaskClientNetHelper.WelfareTaskReward(self.Root(), self.Day);

            self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareTask);
            self.UpdateInfo(self.Day);
        }
    }
}
