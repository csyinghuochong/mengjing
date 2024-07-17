using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class DlgFriendList: Entity,IAwake<Transform>,IDestroy,IUILogic
    {
        public void DestroyWidget()
        {
            this.uiTransform = null;
        }
        
        public Transform uiTransform = null;
    }
}
