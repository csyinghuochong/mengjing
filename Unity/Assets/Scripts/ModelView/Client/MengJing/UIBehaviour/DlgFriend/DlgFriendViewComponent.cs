
using UnityEngine;
using UnityEngine.UI;

namespace  ET.Client
{
    
    [ComponentOf(typeof(DlgFriend))]
    [EnableMethod]
    public class DlgFriendViewComponent: Entity,IAwake,IDestroy 
    {

        public DlgFriendBlack ES_DlgFriendBlack
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_DlgFriendBlack == null )
                {
                    Log.Debug(("this.m_DlgFriendBlack == null"));
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"SubViewNode/ES_FriendBlack");
                    this.m_DlgFriendBlack = this.AddChild<DlgFriendBlack,Transform>(subTrans);
                }
                return this.m_DlgFriendBlack;
                
            }
        }

        public DlgFriendList ES_DlgFriendList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_DlgFriendList == null )
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"SubViewNode/ES_FriendList");
                    this.m_DlgFriendList = this.AddChild<DlgFriendList,Transform>(subTrans);
                }
                return this.m_DlgFriendList;
                
            }
        }

        public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_FunctionSetBtnToggleGroup == null)
                {
                    this.m_E_FunctionSetBtnToggleGroup =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject, "E_FunctionSetBtn");
                }

                return this.m_E_FunctionSetBtnToggleGroup;
            }
        }

        public void DestroyWidget()
        {
            this.uiTransform = null;
        }
        
        
        public Transform uiTransform = null;
        
        private EntityRef<DlgFriendBlack> m_DlgFriendBlack = null;
        private EntityRef<DlgFriendList> m_DlgFriendList = null;
        private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
    }
}
