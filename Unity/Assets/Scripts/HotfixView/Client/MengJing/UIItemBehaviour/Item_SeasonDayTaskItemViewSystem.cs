namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SeasonDayTaskItem))]
    [EntitySystemOf(typeof(Scroll_Item_SeasonDayTaskItem))]
    public static partial class Scroll_Item_SeasonDayTaskItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SeasonDayTaskItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SeasonDayTaskItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_SeasonDayTaskItem self, TaskPro taskPro)
        {
            self.TaskPro = taskPro;
            self.E_ClickBtnButton.AddListener(() => { self.GetParent<ES_SeasonTask>().UpdateInfo(self.TaskPro); });
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

            self.E_TaskNameTextText.text = taskConfig.TaskName;
            self.E_TaskDescTextText.text = taskConfig.TaskDes;

            // 已经完成
            if (taskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 ||
                    taskConfig.TargetType == (int)TaskTargetType.GivePet_25 ||
                    taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                    taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                    taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}:1/1", LanguageComponent.Instance.LoadLocalization("进度"));
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}:{1}/{2}", LanguageComponent.Instance.LoadLocalization("进度"),
                            taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
                    }
                }

                self.E_AcvityedImgImage.gameObject.SetActive(true);
            }
            else
            {
                // 进行中
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 || taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}:0/1", LanguageComponent.Instance.LoadLocalization("进度"));
                    }
                }
                else if (taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                         taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                         taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Completed)
                    {
                        using (zstring.Block())
                        {
                            self.E_ProgressTextText.text = zstring.Format("{0}:1/1", LanguageComponent.Instance.LoadLocalization("进度"));
                        }
                    }
                    else
                    {
                        using (zstring.Block())
                        {
                            self.E_ProgressTextText.text = zstring.Format("{0}:0/1", LanguageComponent.Instance.LoadLocalization("进度"));
                        }
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}:{1}/{2}", LanguageComponent.Instance.LoadLocalization("进度"),
                            self.TaskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
                    }
                }

                self.E_AcvityedImgImage.gameObject.SetActive(false);
            }
        }
    }
}