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
            { 1, GameSettingLanguge.Instance.LoadLocalization("剑类") },
            { 2, GameSettingLanguge.Instance.LoadLocalization("刀类") },
            { 3, GameSettingLanguge.Instance.LoadLocalization("法杖") },
            { 4, GameSettingLanguge.Instance.LoadLocalization("魔法书") },
            { 5, GameSettingLanguge.Instance.LoadLocalization("弓箭") },
            { 11, GameSettingLanguge.Instance.LoadLocalization("布甲") },
            { 12, GameSettingLanguge.Instance.LoadLocalization("轻甲") },
            { 13, GameSettingLanguge.Instance.LoadLocalization("重甲") },
        };
    }
}