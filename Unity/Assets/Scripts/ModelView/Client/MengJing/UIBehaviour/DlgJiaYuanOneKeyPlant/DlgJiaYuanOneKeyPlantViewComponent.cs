using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanOneKeyPlant))]
	[EnableMethod]
	public  class DlgJiaYuanOneKeyPlantViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_ItemListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ItemListNodeRectTransform == null )
     			{
		    		this.m_EG_ItemListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode");
     			}
     			return this.m_EG_ItemListNodeRectTransform;
     		}
     	}

		public RectTransform EG_SeedToggleRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SeedToggleRectTransform == null )
     			{
		    		this.m_EG_SeedToggleRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle");
     			}
     			return this.m_EG_SeedToggleRectTransform;
     		}
     	}

		public Button E_ItemDiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDiButton == null )
     			{
		    		this.m_E_ItemDiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiButton;
     		}
     	}

		public Image E_ItemDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDiImage == null )
     			{
		    		this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiImage;
     		}
     	}

		public Button E_ItemClickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemClickButton == null )
     			{
		    		this.m_E_ItemClickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemClick");
     			}
     			return this.m_E_ItemClickButton;
     		}
     	}

		public Image E_ItemClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemClickImage == null )
     			{
		    		this.m_E_ItemClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemClick");
     			}
     			return this.m_E_ItemClickImage;
     		}
     	}

		public Button E_ItemDragButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDragButton == null )
     			{
		    		this.m_E_ItemDragButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragButton;
     		}
     	}

		public Image E_ItemDragImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDragImage == null )
     			{
		    		this.m_E_ItemDragImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragImage;
     		}
     	}

		public EventTrigger E_ItemDragEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDragEventTrigger == null )
     			{
		    		this.m_E_ItemDragEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragEventTrigger;
     		}
     	}

		public Image E_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemQualityImage == null )
     			{
		    		this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemQuality");
     			}
     			return this.m_E_ItemQualityImage;
     		}
     	}

		public Image E_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemIconImage == null )
     			{
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemIcon");
     			}
     			return this.m_E_ItemIconImage;
     		}
     	}

		public Text E_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNumText == null )
     			{
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemNum");
     			}
     			return this.m_E_ItemNumText;
     		}
     	}

		public Text E_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNameText == null )
     			{
		    		this.m_E_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemName");
     			}
     			return this.m_E_ItemNameText;
     		}
     	}

		public Image E_XuanZhongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XuanZhongImage == null )
     			{
		    		this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_XuanZhong");
     			}
     			return this.m_E_XuanZhongImage;
     		}
     	}

		public Image E_BindingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BindingImage == null )
     			{
		    		this.m_E_BindingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Binding");
     			}
     			return this.m_E_BindingImage;
     		}
     	}

		public Image E_UpTipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpTipImage == null )
     			{
		    		this.m_E_UpTipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_UpTip");
     			}
     			return this.m_E_UpTipImage;
     		}
     	}

		public Image E_ProtectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProtectImage == null )
     			{
		    		this.m_E_ProtectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Protect");
     			}
     			return this.m_E_ProtectImage;
     		}
     	}

		public Button E_LockButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LockButton == null )
     			{
		    		this.m_E_LockButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Lock");
     			}
     			return this.m_E_LockButton;
     		}
     	}

		public Image E_LockImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LockImage == null )
     			{
		    		this.m_E_LockImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Lock");
     			}
     			return this.m_E_LockImage;
     		}
     	}

		public Button E_Btn_OnePlantButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OnePlantButton == null )
     			{
		    		this.m_E_Btn_OnePlantButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_OnePlant");
     			}
     			return this.m_E_Btn_OnePlantButton;
     		}
     	}

		public Image E_Btn_OnePlantImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OnePlantImage == null )
     			{
		    		this.m_E_Btn_OnePlantImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_OnePlant");
     			}
     			return this.m_E_Btn_OnePlantImage;
     		}
     	}

		public Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public Text E_NumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NumTextText == null )
     			{
		    		this.m_E_NumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NumText");
     			}
     			return this.m_E_NumTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_ItemListNodeRectTransform = null;
			this.m_EG_SeedToggleRectTransform = null;
			this.m_E_ItemDiButton = null;
			this.m_E_ItemDiImage = null;
			this.m_E_ItemClickButton = null;
			this.m_E_ItemClickImage = null;
			this.m_E_ItemDragButton = null;
			this.m_E_ItemDragImage = null;
			this.m_E_ItemDragEventTrigger = null;
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_ItemNumText = null;
			this.m_E_ItemNameText = null;
			this.m_E_XuanZhongImage = null;
			this.m_E_BindingImage = null;
			this.m_E_UpTipImage = null;
			this.m_E_ProtectImage = null;
			this.m_E_LockButton = null;
			this.m_E_LockImage = null;
			this.m_E_Btn_OnePlantButton = null;
			this.m_E_Btn_OnePlantImage = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_NumTextText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_ItemListNodeRectTransform = null;
		private RectTransform m_EG_SeedToggleRectTransform = null;
		private Button m_E_ItemDiButton = null;
		private Image m_E_ItemDiImage = null;
		private Button m_E_ItemClickButton = null;
		private Image m_E_ItemClickImage = null;
		private Button m_E_ItemDragButton = null;
		private Image m_E_ItemDragImage = null;
		private EventTrigger m_E_ItemDragEventTrigger = null;
		private Image m_E_ItemQualityImage = null;
		private Image m_E_ItemIconImage = null;
		private Text m_E_ItemNumText = null;
		private Text m_E_ItemNameText = null;
		private Image m_E_XuanZhongImage = null;
		private Image m_E_BindingImage = null;
		private Image m_E_UpTipImage = null;
		private Image m_E_ProtectImage = null;
		private Button m_E_LockButton = null;
		private Image m_E_LockImage = null;
		private Button m_E_Btn_OnePlantButton = null;
		private Image m_E_Btn_OnePlantImage = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private Text m_E_NumTextText = null;
		public Transform uiTransform = null;
	}
}
