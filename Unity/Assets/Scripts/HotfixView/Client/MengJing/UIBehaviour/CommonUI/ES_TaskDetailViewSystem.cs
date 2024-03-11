using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_TaskDetail))]
    [FriendOf(typeof (ES_TaskDetail))]
    public static partial class ES_TaskDetailSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskDetail self, Transform transform)
        {
            self.uiTransform = transform;

            self.ES_TaskType_0.InitData(TaskTypeEnum.Main, self.SetTalkUp);
            self.ES_TaskType_1.InitData(TaskTypeEnum.Branch, self.SetTalkUp);
            self.ES_TaskType_2.InitData(TaskTypeEnum.Daily, self.SetTalkUp);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskDetail self)
        {
            self.DestroyWidget();
        }

        private static void SetTalkUp(this ES_TaskDetail self, int taskType)
        {
            if (taskType != TaskTypeEnum.Main)
            {
                self.ES_TaskType_0.TalkUp();
            }

            if (taskType != TaskTypeEnum.Branch)
            {
                self.ES_TaskType_1.TalkUp();
            }

            if (taskType != TaskTypeEnum.Daily)
            {
                self.ES_TaskType_2.TalkUp();
            }
        }
    }
}