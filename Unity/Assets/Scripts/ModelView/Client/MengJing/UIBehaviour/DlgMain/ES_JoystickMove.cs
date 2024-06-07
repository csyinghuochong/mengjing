using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class ES_JoystickMove: Entity, ET.IAwake<UnityEngine.Transform>, IDestroy
    {
        public Vector2 OldPoint;
        public Vector2 NewPoint;
        public float Distance = 110;
        public long lastSendTime;
        public long checkTime;

        public int direction;
        public int lastDirection;

        public Camera UICamera;
        public Camera MainCamera;
        public float LastShowTip;

        public Unit MainUnit { get; set; }
        public NumericComponentC NumericComponent { get; set; }
        public AttackComponent AttackComponent { get; set; }

        public int ObstructLayer;
        public int BuildingLayer;
        public long JoystickTimer;

        public int OperateMode;

        public UnityEngine.UI.Image E_YaoGanDiMoveImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_YaoGanDiMoveImage == null)
                {
                    this.m_E_YaoGanDiMoveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_YaoGanDiMove");
                }

                return this.m_E_YaoGanDiMoveImage;
            }
        }

        public UnityEngine.EventSystems.EventTrigger E_YaoGanDiMoveEventTrigger
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_YaoGanDiMoveEventTrigger == null)
                {
                    this.m_E_YaoGanDiMoveEventTrigger =
                            UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject, "E_YaoGanDiMove");
                }

                return this.m_E_YaoGanDiMoveEventTrigger;
            }
        }

        public UnityEngine.UI.Image E_YaoGanDiFixImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_YaoGanDiFixImage == null)
                {
                    this.m_E_YaoGanDiFixImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_YaoGanDiFix");
                }

                return this.m_E_YaoGanDiFixImage;
            }
        }

        public UnityEngine.EventSystems.EventTrigger E_YaoGanDiFixEventTrigger
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_YaoGanDiFixEventTrigger == null)
                {
                    this.m_E_YaoGanDiFixEventTrigger =
                            UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject, "E_YaoGanDiFix");
                }

                return this.m_E_YaoGanDiFixEventTrigger;
            }
        }

        public UnityEngine.UI.Image E_CenterShowImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_CenterShowImage == null)
                {
                    this.m_E_CenterShowImage =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_YaoGanDiFix/E_CenterShow");
                }

                return this.m_E_CenterShowImage;
            }
        }

        public UnityEngine.UI.Image E_ThumbImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_ThumbImage == null)
                {
                    this.m_E_ThumbImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_YaoGanDiFix/E_Thumb");
                }

                return this.m_E_ThumbImage;
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
            this.m_E_YaoGanDiMoveImage = null;
            this.m_E_YaoGanDiMoveEventTrigger = null;
            this.m_E_YaoGanDiFixImage = null;
            this.m_E_YaoGanDiFixEventTrigger = null;
            this.m_E_CenterShowImage = null;
            this.m_E_ThumbImage = null;
            this.uiTransform = null;
        }

        private UnityEngine.UI.Image m_E_YaoGanDiMoveImage = null;
        private UnityEngine.EventSystems.EventTrigger m_E_YaoGanDiMoveEventTrigger = null;
        private UnityEngine.UI.Image m_E_YaoGanDiFixImage = null;
        private UnityEngine.EventSystems.EventTrigger m_E_YaoGanDiFixEventTrigger = null;
        private UnityEngine.UI.Image m_E_CenterShowImage = null;
        private UnityEngine.UI.Image m_E_ThumbImage = null;
        public Transform uiTransform = null;
    }
}