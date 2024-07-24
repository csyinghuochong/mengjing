using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgOneSellSet : Entity, IAwake, IUILogic
    {
        public DlgOneSellSetViewComponent View { get => this.GetComponent<DlgOneSellSetViewComponent>(); }

        public List<KeyValuePair> GameSettingInfos = new();
    }
}