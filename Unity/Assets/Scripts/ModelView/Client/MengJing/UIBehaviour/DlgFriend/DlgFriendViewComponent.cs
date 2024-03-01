
using UnityEngine;
using UnityEngine.UI;

namespace  ET.Client
{
    
    [ComponentOf(typeof(DlgFriend))]
    [EnableMethod]
    public class DlgFriendViewComponent: Entity,IAwake,IDestroy 
    {
        public void DestroyWidget()
        {
            this.uiTransform = null;
        }
        
        
        public Transform uiTransform = null;
    }
}
