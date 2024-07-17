using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_MainSkillGrid: Entity,IAwake<Transform>,IDestroy
    {

        public Transform E_SkillYanGan
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_SkillYanGan == null )
                {
                    this.m_e_SkillYanGan = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"SkillYanGan");
                }
                return this.m_e_SkillYanGan;
            }
        }

        public Transform E_Button_Cancle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Button_Cancle == null )
                {
                    this.m_e_Button_Cancle = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Button_Cancle");
                }
                return this.m_e_Button_Cancle;
            }
        }

        public Transform E_SkillDi
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_SkillDi == null )
                {
                    this.m_e_SkillDi = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"SkillDi");
                }
                return this.m_e_SkillDi;
            }
        }

        public Transform E_Btn_SkillStart
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Btn_SkillStart == null )
                {
                    this.m_e_Btn_SkillStart = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Btn_SkillStart");
                }
                return this.m_e_Btn_SkillStart;
            }
        }

        public Transform E_Img_SkillIcon
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Img_SkillIcon == null )
                {
                    this.m_e_Img_SkillIcon = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Img_Mask/Img_SkillIcon");
                }
                return this.m_e_Img_SkillIcon;
            }
        }

        public Transform E_Text_SkillItemNum
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Text_SkillItemNum == null )
                {
                    this.m_e_Text_SkillItemNum = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Text_SkillItemNum");
                }
                return this.m_e_Text_SkillItemNum;
            }
        }

        public Transform E_Img_Mask
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Img_Mask == null )
                {
                    this.m_e_Img_Mask = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Img_Mask");
                }
                return this.m_e_Img_Mask;
            }
        }

        public Image E_SkillSecondCD
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_SkillSecondCD == null )
                {
                    this.m_e_SkillSecondCD = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"SkillSecondCD");
                }
                return this.m_e_SkillSecondCD;
            }
        }

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

        public Image E_Img_PublicSkillCD
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Img_PublicSkillCD == null )
                {
                    this.m_e_Img_PublicSkillCD = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Img_PublicSkillCD");
                }
                return this.m_e_Img_PublicSkillCD;
            }
        }

        public Text E_Text_SkillCD
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_e_Text_SkillCD == null )
                {
                    this.m_e_Text_SkillCD = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Text_SkillCD");
                }
                return this.m_e_Text_SkillCD;
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
            this.m_e_SkillYanGan = null;
            this.m_e_Button_Cancle = null;
            this.m_e_SkillDi = null;
            this.m_e_Btn_SkillStart = null;
            this.m_e_Img_SkillIcon = null;
            this.m_e_Text_SkillItemNum = null;
            this.m_e_Img_SkillCD = null;
            this.m_e_Text_SkillCD = null;
            this.m_e_Img_PublicSkillCD = null;
            this.m_e_Img_Mask = null;
            this.m_e_SkillSecondCD = null;
        }
        
        private Transform m_e_SkillYanGan;
        private Transform m_e_Button_Cancle;
        private Transform m_e_SkillDi;
        private Transform m_e_Btn_SkillStart;
        private Transform m_e_Img_SkillIcon;
        private Transform m_e_Text_SkillItemNum;
        private Transform m_e_Img_Mask;
        private Image m_e_SkillSecondCD;
        private Image m_e_Img_SkillCD;
        private Image m_e_Img_PublicSkillCD;
        private Text m_e_Text_SkillCD;

        public SkillConfig SkillWuqiConfig{ get; set; }
        public SkillConfig SkillBaseConfig{ get; set; }
        public LockTargetComponent LockTargetComponent { get; set; }
        public SkillIndicatorComponent SkillIndicatorComponent{ get; set; }
      
        public Action<int> UseSkillHandler{ get; set; }
        public List<string> AssetPath { get; set; }= new List<string>();
        public SkillPro SkillPro{ get; set; }
        public long SkillInfoShowTimer = 0;
        public bool UseSkill{ get; set; }
        public bool CancelSkill{ get; set; }
        public int SkillSecond { get; set; } //1 可以二段 
        public int Index{ get; set; }
        
        public Action<bool> SkillCancelHandler{ get; set; }
        public Transform uiTransform = null;
    }
    
}