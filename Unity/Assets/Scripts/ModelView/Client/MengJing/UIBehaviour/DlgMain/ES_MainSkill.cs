using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_MainSkill: Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
    {

        public Image E_Button_Switch_CD
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Button_Switch_CD == null )
                {
                    this.m_e_Button_Switch_CD = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList/Button_Switch_0/Button_Switch_CD");
                }
                return this.m_e_Button_Switch_CD;
            }
        }

        public Button E_Btn_PetTarget
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Btn_PetTarget == null )
                {
                    this.m_e_Btn_PetTarget = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/Btn_PetTarget");
                }
                return this.m_e_Btn_PetTarget;
            }
        }

        public Button E_Button_Switch_0
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Button_Switch_0 == null )
                {
                    this.m_e_Button_Switch_0 = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList/Button_Switch_0");
                }
                return this.m_e_Button_Switch_0;
            }
        }

        public Button E_Btn_NpcDuiHua
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Btn_NpcDuiHua == null )
                {
                    this.m_e_Btn_NpcDuiHua = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList/Btn_NpcDuiHua");
                }
                return this.m_e_Btn_NpcDuiHua;
            }
        }

        public Transform E_Transforms
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Transforms == null )
                {
                    this.m_e_Transforms = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"ButtonList/Btn_NpcDuiHua");
                }
                return this.m_e_Transforms;
            }
        }

        public Transform E_Normal
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Normal == null )
                {
                    this.m_e_Normal = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"ButtonList/Normal");
                }
                return this.m_e_Normal;
            }
        }

        public Button E_Btn_JingLing
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Btn_JingLing == null )
                {
                    this.m_e_Btn_JingLing = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList/Normal");
                }
                return this.m_e_Btn_JingLing;
            }
        }

        public Button E_Button_ZhuaPu
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Button_ZhuaPu == null )
                {
                    this.m_e_Button_ZhuaPu = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/Button_ZhuaPu");
                }
                return this.m_e_Button_ZhuaPu;
            }
        }

        public Button E_shiquButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_shiquButton == null )
                {
                    this.m_e_shiquButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/Btn_ShiQu");
                }
                return this.m_e_shiquButton;
            }
        }

        public Button E_Btn_Target
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Btn_Target == null )
                {
                    this.m_e_Btn_Target = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/Btn_Target");
                }
                return this.m_e_Btn_Target;
            }
        }

        public Button E_Btn_CancleSkill
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Btn_CancleSkill == null )
                {
                    this.m_e_Btn_CancleSkill = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Btn_CancleSkill");
                }
                return this.m_e_Btn_CancleSkill;
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
            this.m_e_Button_Switch_CD = null;
            this.m_e_Btn_PetTarget = null;
            this.m_e_Button_Switch_0 = null;
            this.m_e_Transforms = null;
            this.m_e_Normal = null;
            this.m_e_Btn_NpcDuiHua = null;
            this.m_e_Btn_JingLing = null;
            this.m_e_Button_ZhuaPu = null;
            this.m_e_shiquButton = null;
            this.m_e_Btn_Target = null;
            this.m_e_Btn_CancleSkill = null;
        }
        
        private Image m_e_Button_Switch_CD;
        private UnityEngine.UI.Button m_e_Btn_PetTarget;
        private UnityEngine.UI.Button m_e_Button_Switch_0;
        private Transform m_e_Transforms;
        private Transform m_e_Normal;
        private UnityEngine.UI.Button m_e_Btn_NpcDuiHua;
        private UnityEngine.UI.Button m_e_Btn_JingLing;
        private UnityEngine.UI.Button m_e_Button_ZhuaPu;
        private UnityEngine.UI.Button m_e_shiquButton;
        private UnityEngine.UI.Button m_e_Btn_Target;
        private UnityEngine.UI.Button m_e_Btn_CancleSkill;
        
        //private UIFangunSkillComponent m_e_UI_MainRose_FanGun;
        //private UIAttackGridComponent m_e_UI_MainRose_attack;
        private Transform uiTransform = null;
    }
    
}