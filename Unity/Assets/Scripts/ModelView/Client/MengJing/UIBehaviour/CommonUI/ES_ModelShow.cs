using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class ES_ModelShow: Entity, ET.IAwake<UnityEngine.Transform>, IDestroy
    {
        public GameObject UnitModel;
        public Transform ModelParent;
        public Vector2 StartPosition;
        public bool Draged = false;
        private EntityRef<ChangeEquipComponent> changeEquipComponent;

        public ChangeEquipComponent ChangeEquipComponent
        {
            get => this.changeEquipComponent;
            set => this.changeEquipComponent = value;
        }

        public UnityEngine.UI.Button E_RenderButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_RenderButton == null)
                {
                    this.m_E_RenderButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "E_Render");
                }

                return this.m_E_RenderButton;
            }
        }

        public UnityEngine.UI.RawImage E_RenderRawImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_RenderRawImage == null)
                {
                    this.m_E_RenderRawImage = UIFindHelper.FindDeepChild<UnityEngine.UI.RawImage>(this.uiTransform.gameObject, "E_Render");
                }

                return this.m_E_RenderRawImage;
            }
        }

        public UnityEngine.EventSystems.EventTrigger E_RenderEventTrigger
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_RenderEventTrigger == null)
                {
                    this.m_E_RenderEventTrigger =
                            UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject, "E_Render");
                }

                return this.m_E_RenderEventTrigger;
            }
        }

        public UnityEngine.RectTransform EG_RootRectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_RootRectTransform == null)
                {
                    this.m_EG_RootRectTransform =
                            UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject, "E_Render/EG_Root");
                }

                return this.m_EG_RootRectTransform;
            }
        }

        public void DestroyWidget()
        {
            this.m_E_RenderButton = null;
            this.m_E_RenderRawImage = null;
            this.m_E_RenderEventTrigger = null;
            this.m_EG_RootRectTransform = null;
            this.uiTransform = null;
        }

        private UnityEngine.UI.Button m_E_RenderButton = null;
        private UnityEngine.UI.RawImage m_E_RenderRawImage = null;
        private UnityEngine.EventSystems.EventTrigger m_E_RenderEventTrigger = null;
        private UnityEngine.RectTransform m_EG_RootRectTransform = null;
        public Transform uiTransform = null;
    }
}