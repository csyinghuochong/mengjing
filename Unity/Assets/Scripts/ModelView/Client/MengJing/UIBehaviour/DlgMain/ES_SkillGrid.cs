using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class ES_SkillGrid: Entity, ET.IAwake<UnityEngine.Transform>, IDestroy
    {
        public SkillConfig SkillWuqiConfig;
        public SkillConfig SkillBaseConfig;

        public bool UseSkill;
        public bool CancelSkill;
        public SkillPro SkillPro { get; set; }
        public Action<bool> SkillCancelHandler;

        public LockTargetComponent LockTargetComponent { get; set; }
        public SkillIndicatorComponent SkillIndicatorComponent { get; set; }
        public long SkillInfoShowTimer;
        public int Index;
        public Action<int> UseSkillHandler;
        public int SkillSecond = 0; //1 可以二段 

        public UnityEngine.UI.Image E_E_SkillDiImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_E_SkillDiImage == null)
                {
                    this.m_E_E_SkillDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_E_SkillDi");
                }

                return this.m_E_E_SkillDiImage;
            }
        }

        public UnityEngine.UI.Image E_Img_MaskImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Img_MaskImage == null)
                {
                    this.m_E_Img_MaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Img_Mask");
                }

                return this.m_E_Img_MaskImage;
            }
        }

        public UnityEngine.UI.Image E_Img_SkillIconImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Img_SkillIconImage == null)
                {
                    this.m_E_Img_SkillIconImage =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Img_Mask/E_Img_SkillIcon");
                }

                return this.m_E_Img_SkillIconImage;
            }
        }

        public UnityEngine.UI.Image E_Img_SkillCDImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Img_SkillCDImage == null)
                {
                    this.m_E_Img_SkillCDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Img_SkillCD");
                }

                return this.m_E_Img_SkillCDImage;
            }
        }

        public UnityEngine.UI.Image E_Img_PublicSkillCDImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Img_PublicSkillCDImage == null)
                {
                    this.m_E_Img_PublicSkillCDImage =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Img_PublicSkillCD");
                }

                return this.m_E_Img_PublicSkillCDImage;
            }
        }

        public UnityEngine.UI.Image E_SkillYanGanImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_SkillYanGanImage == null)
                {
                    this.m_E_SkillYanGanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_SkillYanGan");
                }

                return this.m_E_SkillYanGanImage;
            }
        }

        public UnityEngine.UI.Button E_Btn_SkillStartButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Btn_SkillStartButton == null)
                {
                    this.m_E_Btn_SkillStartButton =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "E_Btn_SkillStart");
                }

                return this.m_E_Btn_SkillStartButton;
            }
        }

        public UnityEngine.UI.Image E_Btn_SkillStartImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Btn_SkillStartImage == null)
                {
                    this.m_E_Btn_SkillStartImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Btn_SkillStart");
                }

                return this.m_E_Btn_SkillStartImage;
            }
        }

        public UnityEngine.EventSystems.EventTrigger E_Btn_SkillStartEventTrigger
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Btn_SkillStartEventTrigger == null)
                {
                    this.m_E_Btn_SkillStartEventTrigger =
                            UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject, "E_Btn_SkillStart");
                }

                return this.m_E_Btn_SkillStartEventTrigger;
            }
        }

        public UnityEngine.UI.Button E_Button_CancleButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Button_CancleButton == null)
                {
                    this.m_E_Button_CancleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "E_Button_Cancle");
                }

                return this.m_E_Button_CancleButton;
            }
        }

        public UnityEngine.UI.Image E_Button_CancleImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Button_CancleImage == null)
                {
                    this.m_E_Button_CancleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Button_Cancle");
                }

                return this.m_E_Button_CancleImage;
            }
        }

        public UnityEngine.UI.Image E_Img_EventTriggerImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Img_EventTriggerImage == null)
                {
                    this.m_E_Img_EventTriggerImage =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Img_EventTrigger");
                }

                return this.m_E_Img_EventTriggerImage;
            }
        }

        public UnityEngine.EventSystems.EventTrigger E_Img_EventTriggerEventTrigger
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Img_EventTriggerEventTrigger == null)
                {
                    this.m_E_Img_EventTriggerEventTrigger =
                            UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject, "E_Img_EventTrigger");
                }

                return this.m_E_Img_EventTriggerEventTrigger;
            }
        }

        public UnityEngine.UI.Image E_SkillSecondCDImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_SkillSecondCDImage == null)
                {
                    this.m_E_SkillSecondCDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_SkillSecondCD");
                }

                return this.m_E_SkillSecondCDImage;
            }
        }

        public UnityEngine.UI.Text E_Text_SkillItemNumText
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Text_SkillItemNumText == null)
                {
                    this.m_E_Text_SkillItemNumText =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject, "E_Text_SkillItemNum");
                }

                return this.m_E_Text_SkillItemNumText;
            }
        }

        public UnityEngine.UI.Text E_Text_SkillCDText
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_Text_SkillCDText == null)
                {
                    this.m_E_Text_SkillCDText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject, "E_Text_SkillCD");
                }

                return this.m_E_Text_SkillCDText;
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
            this.m_E_E_SkillDiImage = null;
            this.m_E_Img_MaskImage = null;
            this.m_E_Img_SkillIconImage = null;
            this.m_E_Img_SkillCDImage = null;
            this.m_E_Img_PublicSkillCDImage = null;
            this.m_E_SkillYanGanImage = null;
            this.m_E_Btn_SkillStartButton = null;
            this.m_E_Btn_SkillStartImage = null;
            this.m_E_Btn_SkillStartEventTrigger = null;
            this.m_E_Button_CancleButton = null;
            this.m_E_Button_CancleImage = null;
            this.m_E_Img_EventTriggerImage = null;
            this.m_E_Img_EventTriggerEventTrigger = null;
            this.m_E_SkillSecondCDImage = null;
            this.m_E_Text_SkillItemNumText = null;
            this.m_E_Text_SkillCDText = null;
            this.uiTransform = null;
        }

        private UnityEngine.UI.Image m_E_E_SkillDiImage = null;
        private UnityEngine.UI.Image m_E_Img_MaskImage = null;
        private UnityEngine.UI.Image m_E_Img_SkillIconImage = null;
        private UnityEngine.UI.Image m_E_Img_SkillCDImage = null;
        private UnityEngine.UI.Image m_E_Img_PublicSkillCDImage = null;
        private UnityEngine.UI.Image m_E_SkillYanGanImage = null;
        private UnityEngine.UI.Button m_E_Btn_SkillStartButton = null;
        private UnityEngine.UI.Image m_E_Btn_SkillStartImage = null;
        private UnityEngine.EventSystems.EventTrigger m_E_Btn_SkillStartEventTrigger = null;
        private UnityEngine.UI.Button m_E_Button_CancleButton = null;
        private UnityEngine.UI.Image m_E_Button_CancleImage = null;
        private UnityEngine.UI.Image m_E_Img_EventTriggerImage = null;
        private UnityEngine.EventSystems.EventTrigger m_E_Img_EventTriggerEventTrigger = null;
        private UnityEngine.UI.Image m_E_SkillSecondCDImage = null;
        private UnityEngine.UI.Text m_E_Text_SkillItemNumText = null;
        private UnityEngine.UI.Text m_E_Text_SkillCDText = null;
        public Transform uiTransform = null;
    }
}