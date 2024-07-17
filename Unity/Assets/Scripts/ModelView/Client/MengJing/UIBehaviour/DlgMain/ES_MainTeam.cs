using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class ES_MainTeam: Entity,IAwake<Transform>,IDestroy
    {
        
        public Dictionary<int, EntityRef<Scroll_Item_MainTeamItem>> ScrollItemMainTeamItems;
        
        public Transform E_TeamNodeList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_TeamNodeList == null )
                {
                    this.m_e_TeamNodeList = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"TeamNodeList");
                }
                return this.m_e_TeamNodeList;
            }
        }
        
        public Transform E_Btn_RoseTeam
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Btn_RoseTeam == null )
                {
                    this.m_e_Btn_RoseTeam = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Btn_RoseTeam");
                }
                return this.m_e_Btn_RoseTeam;
            }
        }

        public Transform UITransform
        {
            get
            {
                return this.uiTransform;
            }
            set
            {
                this.uiTransform = value;
            }
        }
        
        public void DestroyWidget()
        {
            this.uiTransform = null;
            this.m_e_TeamNodeList = null;
            this.m_e_Btn_RoseTeam = null;
        }

        private Transform uiTransform = null;
        private Transform m_e_TeamNodeList = null;
        private Transform m_e_Btn_RoseTeam = null;
    }
}