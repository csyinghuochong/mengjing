using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_MainSkillFangun: Entity,IAwake<Transform>,IDestroy
    {

        public Image E_Img_SkillCD
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Img_SkillCD == null )
                {
                    this.m_e_Img_SkillCD = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Img_SkillCD");
                }
                return this.m_e_Img_SkillCD;
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
            this.m_e_Img_SkillCD = null;
        }
        
        private Image m_e_Img_SkillCD;
        public float LastSkillTime;
        public int SkillId { get; set; } = 0;
        public Transform uiTransform = null;
    }
}