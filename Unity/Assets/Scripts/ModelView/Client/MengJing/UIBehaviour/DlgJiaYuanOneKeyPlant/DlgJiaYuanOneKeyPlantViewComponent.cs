
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanOneKeyPlant))]
	[EnableMethod]
	public  class DlgJiaYuanOneKeyPlantViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_ItemListNodeRectTransform
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
		    		this.m_EG_ItemListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode");
     			}
     			return this.m_EG_ItemListNodeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SeedToggleRectTransform
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
		    		this.m_EG_SeedToggleRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle");
     			}
     			return this.m_EG_SeedToggleRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ItemDiButton
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
		    		this.m_E_ItemDiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDiImage
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
		    		this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiImage;
     		}
     	}

		public UnityEngine.UI.Button E_ItemClickButton
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
		    		this.m_E_ItemClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemClick");
     			}
     			return this.m_E_ItemClickButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemClickImage
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
		    		this.m_E_ItemClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemClick");
     			}
     			return this.m_E_ItemClickImage;
     		}
     	}

		public UnityEngine.UI.Button E_ItemDragButton
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
		    		this.m_E_ItemDragButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDragImage
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
		    		this.m_E_ItemDragImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ItemDragEventTrigger
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
		    		this.m_E_ItemDragEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_ItemQualityImage
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
		    		this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemQuality");
     			}
     			return this.m_E_ItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_ItemIconImage
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
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemIcon");
     			}
     			return this.m_E_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNumText
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
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemNum");
     			}
     			return this.m_E_ItemNumText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNameText
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
		    		this.m_E_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_ItemName");
     			}
     			return this.m_E_ItemNameText;
     		}
     	}

		public UnityEngine.UI.Image E_XuanZhongImage
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
		    		this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_XuanZhong");
     			}
     			return this.m_E_XuanZhongImage;
     		}
     	}

		public UnityEngine.UI.Image E_BindingImage
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
		    		this.m_E_BindingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Binding");
     			}
     			return this.m_E_BindingImage;
     		}
     	}

		public UnityEngine.UI.Image E_UpTipImage
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
		    		this.m_E_UpTipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_UpTip");
     			}
     			return this.m_E_UpTipImage;
     		}
     	}

		public UnityEngine.UI.Image E_ProtectImage
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
		    		this.m_E_ProtectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Protect");
     			}
     			return this.m_E_ProtectImage;
     		}
     	}

		public UnityEngine.UI.Button E_LockButton
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
		    		this.m_E_LockButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Lock");
     			}
     			return this.m_E_LockButton;
     		}
     	}

		public UnityEngine.UI.Image E_LockImage
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
		    		this.m_E_LockImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_ItemListNode/EG_SeedToggle/UICommonItem/E_Lock");
     			}
     			return this.m_E_LockImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_OnePlantButton
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
		    		this.m_E_Btn_OnePlantButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_OnePlant");
     			}
     			return this.m_E_Btn_OnePlantButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_OnePlantImage
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
		    		this.m_E_Btn_OnePlantImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_OnePlant");
     			}
     			return this.m_E_Btn_OnePlantImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CloseButton
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.UI.Text E_NumTextText
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
		    		this.m_E_NumTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NumText");
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

		private UnityEngine.RectTransform m_EG_ItemListNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_SeedToggleRectTransform = null;
		private UnityEngine.UI.Button m_E_ItemDiButton = null;
		private UnityEngine.UI.Image m_E_ItemDiImage = null;
		private UnityEngine.UI.Button m_E_ItemClickButton = null;
		private UnityEngine.UI.Image m_E_ItemClickImage = null;
		private UnityEngine.UI.Button m_E_ItemDragButton = null;
		private UnityEngine.UI.Image m_E_ItemDragImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ItemDragEventTrigger = null;
		private UnityEngine.UI.Image m_E_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_ItemNumText = null;
		private UnityEngine.UI.Text m_E_ItemNameText = null;
		private UnityEngine.UI.Image m_E_XuanZhongImage = null;
		private UnityEngine.UI.Image m_E_BindingImage = null;
		private UnityEngine.UI.Image m_E_UpTipImage = null;
		private UnityEngine.UI.Image m_E_ProtectImage = null;
		private UnityEngine.UI.Button m_E_LockButton = null;
		private UnityEngine.UI.Image m_E_LockImage = null;
		private UnityEngine.UI.Button m_E_Btn_OnePlantButton = null;
		private UnityEngine.UI.Image m_E_Btn_OnePlantImage = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.UI.Text m_E_NumTextText = null;
		public Transform uiTransform = null;
	}
}
