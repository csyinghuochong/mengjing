using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgOccTwo: Entity, IAwake, IUILogic
    {
        public DlgOccTwoViewComponent View
        {
            get => this.GetComponent<DlgOccTwoViewComponent>();
        }

        public List<GameObject> Button_ZhiYe_List = new();
        public int OccTwoId;

        public Dictionary<int, string> showType = new()
        {
            { 1, GameSettingLanguge.LoadLocalization("剑类") },
            { 2, GameSettingLanguge.LoadLocalization("刀类") },
            { 3, GameSettingLanguge.LoadLocalization("法杖") },
            { 4, GameSettingLanguge.LoadLocalization("魔法书") },
            { 5, GameSettingLanguge.LoadLocalization("弓箭") },
            { 11, GameSettingLanguge.LoadLocalization("布甲") },
            { 12, GameSettingLanguge.LoadLocalization("轻甲") },
            { 13, GameSettingLanguge.LoadLocalization("重甲") },
        };
    }
}