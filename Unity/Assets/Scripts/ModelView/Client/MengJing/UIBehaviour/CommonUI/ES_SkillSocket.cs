
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillSocket : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Dictionary<int, EntityRef<Scroll_Item_SkillSocketItem>> ScrollItemSkillSocketItems = new();
		public List<string> AssetList { get; set; } = new();
		public int SelectedBaseSkillId;

		public UnityEngine.UI.ScrollRect E_SkillSocketItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillSocketItemsScrollRect == null )
     			{
		    		this.m_E_SkillSocketItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/E_SkillSocketItems");
     			}
     			return this.m_E_SkillSocketItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_SkillSocketItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillSocketItemsImage == null )
     			{
		    		this.m_E_SkillSocketItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SkillSocketItems");
     			}
     			return this.m_E_SkillSocketItemsImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetButton == null )
     			{
		    		this.m_E_ButtonResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetImage == null )
     			{
		    		this.m_E_ButtonResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillInfoPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillInfoPanelRectTransform == null )
     			{
		    		this.m_EG_SkillInfoPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel");
     			}
     			return this.m_EG_SkillInfoPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_SkillDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillDesText == null )
     			{
		    		this.m_E_SkillDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillDes");
     			}
     			return this.m_E_SkillDesText;
     		}
     	}

		public UnityEngine.UI.Text E_SkillPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillPointText == null )
     			{
		    		this.m_E_SkillPointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillPoint");
     			}
     			return this.m_E_SkillPointText;
     		}
     	}

		public UnityEngine.UI.Button E_SkillLearnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnButton == null )
     			{
		    		this.m_E_SkillLearnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLearn");
     			}
     			return this.m_E_SkillLearnButton;
     		}
     	}

		public UnityEngine.UI.Image E_SkillLearnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnImage == null )
     			{
		    		this.m_E_SkillLearnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLearn");
     			}
     			return this.m_E_SkillLearnImage;
     		}
     	}

		public UnityEngine.UI.Image E_WheelHitArea_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WheelHitArea_2Image == null )
     			{
		    		this.m_E_WheelHitArea_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_2");
     			}
     			return this.m_E_WheelHitArea_2Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_WheelHitArea_2EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WheelHitArea_2EventTrigger == null )
     			{
		    		this.m_E_WheelHitArea_2EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_2");
     			}
     			return this.m_E_WheelHitArea_2EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_RotatingRoot_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RotatingRoot_2RectTransform == null )
     			{
		    		this.m_EG_RotatingRoot_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_2/EG_RotatingRoot_2");
     			}
     			return this.m_EG_RotatingRoot_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillAugmentItem_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillAugmentItem_2RectTransform == null )
     			{
		    		this.m_EG_SkillAugmentItem_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_2/EG_RotatingRoot_2/EG_SkillAugmentItem_2");
     			}
     			return this.m_EG_SkillAugmentItem_2RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_WheelHitArea_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WheelHitArea_3Image == null )
     			{
		    		this.m_E_WheelHitArea_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_3");
     			}
     			return this.m_E_WheelHitArea_3Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_WheelHitArea_3EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WheelHitArea_3EventTrigger == null )
     			{
		    		this.m_E_WheelHitArea_3EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_3");
     			}
     			return this.m_E_WheelHitArea_3EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_RotatingRoot_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RotatingRoot_3RectTransform == null )
     			{
		    		this.m_EG_RotatingRoot_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_3/EG_RotatingRoot_3");
     			}
     			return this.m_EG_RotatingRoot_3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillAugmentItem_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillAugmentItem_3RectTransform == null )
     			{
		    		this.m_EG_SkillAugmentItem_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_WheelHitArea_3/EG_RotatingRoot_3/EG_SkillAugmentItem_3");
     			}
     			return this.m_EG_SkillAugmentItem_3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillAugmentItem_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillAugmentItem_1RectTransform == null )
     			{
		    		this.m_EG_SkillAugmentItem_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/EG_SkillAugmentItem_1");
     			}
     			return this.m_EG_SkillAugmentItem_1RectTransform;
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
			this.m_E_SkillSocketItemsScrollRect = null;
			this.m_E_SkillSocketItemsImage = null;
			this.m_E_ButtonResetButton = null;
			this.m_E_ButtonResetImage = null;
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_EG_SkillInfoPanelRectTransform = null;
			this.m_E_SkillDesText = null;
			this.m_E_SkillPointText = null;
			this.m_E_SkillLearnButton = null;
			this.m_E_SkillLearnImage = null;
			this.m_E_WheelHitArea_2Image = null;
			this.m_E_WheelHitArea_2EventTrigger = null;
			this.m_EG_RotatingRoot_2RectTransform = null;
			this.m_EG_SkillAugmentItem_2RectTransform = null;
			this.m_E_WheelHitArea_3Image = null;
			this.m_E_WheelHitArea_3EventTrigger = null;
			this.m_EG_RotatingRoot_3RectTransform = null;
			this.m_EG_SkillAugmentItem_3RectTransform = null;
			this.m_EG_SkillAugmentItem_1RectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_SkillSocketItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_SkillSocketItemsImage = null;
		private UnityEngine.UI.Button m_E_ButtonResetButton = null;
		private UnityEngine.UI.Image m_E_ButtonResetImage = null;
		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_SkillInfoPanelRectTransform = null;
		private UnityEngine.UI.Text m_E_SkillDesText = null;
		private UnityEngine.UI.Text m_E_SkillPointText = null;
		private UnityEngine.UI.Button m_E_SkillLearnButton = null;
		private UnityEngine.UI.Image m_E_SkillLearnImage = null;
		private UnityEngine.UI.Image m_E_WheelHitArea_2Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_WheelHitArea_2EventTrigger = null;
		private UnityEngine.RectTransform m_EG_RotatingRoot_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillAugmentItem_2RectTransform = null;
		private UnityEngine.UI.Image m_E_WheelHitArea_3Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_WheelHitArea_3EventTrigger = null;
		private UnityEngine.RectTransform m_EG_RotatingRoot_3RectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillAugmentItem_3RectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillAugmentItem_1RectTransform = null;
		public Transform uiTransform = null;
	}
}
