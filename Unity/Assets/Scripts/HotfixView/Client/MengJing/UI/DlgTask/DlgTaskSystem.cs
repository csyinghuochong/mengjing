using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class TaskTypeItemClick_RefreshTaskInfo: AEvent<Scene, TaskTypeItemClick>
    {
        protected override async ETTask Run(Scene scene, TaskTypeItemClick args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTask>()?.View.ES_TaskDetail.RefreshTaskInfo(args.TaskPro);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (ES_TaskGrowUp))]
    [FriendOf(typeof (ES_TaskDetail))]
    [FriendOf(typeof (DlgTask))]
    public static class DlgTaskSystem
    {
        public static void RegisterUIEvent(this DlgTask self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgTask self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgTask self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_TaskDetail.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_TaskGrowUp.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}