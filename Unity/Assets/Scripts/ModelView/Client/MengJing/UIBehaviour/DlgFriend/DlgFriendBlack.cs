using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class DlgFriendBlack: Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
    {
        public void DestroyWidget()
        {
            this.uiTransform = null;
        }
        
        public Transform uiTransform = null;
    }
}
