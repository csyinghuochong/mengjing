using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgMain: Entity, IAwake, IUILogic
    {
        public DlgMainViewComponent View
        {
            get => this.GetComponent<DlgMainViewComponent>();
        }

        public float DRAG_TO_ANGLE = 0.5f;
        public Vector2 PreviousPressPosition;
        public float AngleX;
        public float AngleY;

        public Unit MainUnit { get; set; }

        public List<TaskPro> ShowTaskPros = new();
        public Dictionary<int, Scroll_Item_MainTask> ScrollItemMainTasks;
        public List<ChatInfo> ShowChatInfos = new();
        public Dictionary<int, Scroll_Item_MainChatItem> ScrollItemMainChatItems;

        public long TimerPing;
    }
}