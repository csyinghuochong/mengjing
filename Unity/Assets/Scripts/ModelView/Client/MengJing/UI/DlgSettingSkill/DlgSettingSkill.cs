using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgSettingSkill: Entity, IAwake, IUILogic
    {
        public DlgSettingSkillViewComponent View
        {
            get => this.GetComponent<DlgSettingSkillViewComponent>();
        }

        public List<KeyValuePair> GameSettingInfos = new();
        public List<int> SkillSet = new();
        public List<GameObject> SkillSetIconLeftList = new();
        public List<GameObject> SkillSetIconRightList = new();
        public Action CloseAction { get; set; }
        public long ClickTime;
    }
}