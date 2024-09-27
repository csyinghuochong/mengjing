using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgMain : Entity, IAwake, IUILogic
    {
        public DlgMainViewComponent View
        {
            get => this.GetComponent<DlgMainViewComponent>();
        }

        public float DRAG_TO_ANGLE = 0.5f;
        public Vector2 PreviousPressPosition;
        public float AngleX;
        public float AngleY;

        public LockTargetComponent LockTargetComponent { get; set; }
        public SkillIndicatorComponent SkillIndicatorComponent { get; set; }

        public Unit MainUnit { get; set; }

        public List<TaskPro> ShowTaskPros = new();
        public Dictionary<int, EntityRef<Scroll_Item_MainTask>> ScrollItemMainTasks;
        public TeamInfo ShowTeamInfo;
        public Dictionary<int, EntityRef<Scroll_Item_MainTeamItem>> ScrollItemMainTeamItems;

        public List<ChatInfo> ShowChatInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_MainChatItem>> ScrollItemMainChatItems;

        public GameObject TianQiEffectObj;
        public string TianQiEffectPath;
        public long TimerFunctiuon;
        public long TimerPing;
        public int KillMonsterRewardKey;
        public int LevelRewardKey;

        public int PetFightindex { get; set; }
    }
}