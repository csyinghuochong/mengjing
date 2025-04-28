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

        private EntityRef<LockTargetComponent> lockTargetComponent;
        public LockTargetComponent LockTargetComponent { get => this.lockTargetComponent; set => this.lockTargetComponent = value; }

        private EntityRef<SkillIndicatorComponent> skillIndicatorComponent;
        public SkillIndicatorComponent SkillIndicatorComponent { get => this.skillIndicatorComponent; set => this.skillIndicatorComponent = value; }

        public EntityRef<Unit> unit;
        public Unit MainUnit { get => this.unit; set => this.unit = value; }

        public List<TaskPro> ShowTaskPros = new();
        public Dictionary<int, EntityRef<Scroll_Item_MainTask>> ScrollItemMainTasks = new();
        public TeamInfo ShowTeamInfo;
        public Dictionary<int, EntityRef<Scroll_Item_MainTeamItem>> ScrollItemMainTeamItems = new();

        public List<ChatInfo> ShowChatInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_MainChatItem>> ScrollItemMainChatItems = new();
        
        public List<string> AssetList { get; set; } = new();

        public GameObject TianQiEffectObj;
        public string TianQiEffectPath;
        public long TimerFunctiuon;
        public long TimerPing;
        public int KillMonsterRewardKey;
        public int LevelRewardKey;
        public long MainPetSwitchTimer;
        public long MainPetSwitchEndTime;
    }
}