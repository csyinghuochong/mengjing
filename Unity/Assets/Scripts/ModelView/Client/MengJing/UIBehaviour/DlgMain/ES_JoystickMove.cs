using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class ES_JoystickMove: Entity, IAwake<Transform>, IDestroy
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

        private EntityRef<Unit> unit;
        public Unit MainUnit { get => this.unit; set => this.unit = value; }
        
        private EntityRef<NumericComponentC> numericComponent;
        public NumericComponentC NumericComponent { get => this.numericComponent; set => this.numericComponent = value; }

        private EntityRef<AttackComponent> attackComponent;
        public AttackComponent AttackComponent { get => this.attackComponent; set => this.attackComponent = value; }

        private EntityRef<BattleMessageComponent> battleMessageComponent;
        public BattleMessageComponent BattleMessageComponent { get => this.battleMessageComponent; set => this.battleMessageComponent = value; }
        
        public int ObstructLayer;
        public int BuildingLayer;
        public int MapLayer;
        public long JoystickTimer;

        public int OperateMode;
        public bool IsDrag;// 当一直拖拽摇杆时，场景进行切换后松开鼠标不会触发取消拖拽的回调，会一直处于拖拽中状态，且一直触发拖拽中回调，只有重新点击再松开才行。
                           // 试着清空EventTrigger.triggers后再从新添加回调，仍然会一直触发拖拽中回调。可能是UGUI的Bug??，所以此变量用来处理这种情况。

        public Image E_YaoGanDiMoveImage
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
                    this.m_E_YaoGanDiMoveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "E_YaoGanDiMove");
                }

                return this.m_E_YaoGanDiMoveImage;
            }
        }

        public EventTrigger E_YaoGanDiMoveEventTrigger
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
                            UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject, "E_YaoGanDiMove");
                }

                return this.m_E_YaoGanDiMoveEventTrigger;
            }
        }

        public Image E_YaoGanDiFixImage
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
                    this.m_E_YaoGanDiFixImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "E_YaoGanDiFix");
                }

                return this.m_E_YaoGanDiFixImage;
            }
        }

        public EventTrigger E_YaoGanDiFixEventTrigger
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
                            UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject, "E_YaoGanDiFix");
                }

                return this.m_E_YaoGanDiFixEventTrigger;
            }
        }

        public Image E_CenterShowImage
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
                            UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "E_YaoGanDiFix/E_CenterShow");
                }

                return this.m_E_CenterShowImage;
            }
        }

        public Image E_ThumbImage
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
                    this.m_E_ThumbImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "E_YaoGanDiFix/E_Thumb");
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

        private Image m_E_YaoGanDiMoveImage = null;
        private EventTrigger m_E_YaoGanDiMoveEventTrigger = null;
        private Image m_E_YaoGanDiFixImage = null;
        private EventTrigger m_E_YaoGanDiFixEventTrigger = null;
        private Image m_E_CenterShowImage = null;
        private Image m_E_ThumbImage = null;
        public Transform uiTransform = null;
       
    }
}