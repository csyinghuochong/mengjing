using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CommonItem : Entity,IAwake<Transform>,IDestroy
	{
		public int CurrentHouse { get; set; }
		public bool UseTextColor { get; set; }
		
		private EntityRef<ItemInfo> baginfo;
		public ItemInfo Baginfo { get => this.baginfo; set => this.baginfo = value; }
		public string ItemNum { get; set; }
		public int ItemID { get; set; }
		public bool ShowTip { get; set; }
		public ItemOperateEnum ItemOperateEnum { get; set; }
		public Action<ItemInfo> ClickItemHandler { get; set; }
		public Action<ItemInfo, PointerEventData> BeginDragHandler { get; set; }
		public Action<ItemInfo, PointerEventData> DragingHandler { get; set; }
		public Action<ItemInfo, PointerEventData> EndDragHandler { get; set; }
		public Action<ItemInfo, PointerEventData> PointerDownHandler { get; set; }
		public Action<ItemInfo, PointerEventData> PointerUpHandler { get; set; }
		
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
		    		this.m_E_ItemDiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ItemDi");
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
		    		this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemDi");
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
		    		this.m_E_ItemClickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ItemClick");
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
		    		this.m_E_ItemClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemClick");
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
		    		this.m_E_ItemDragButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ItemDrag");
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
		    		this.m_E_ItemDragImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemDrag");
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
		    		this.m_E_ItemDragEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_ItemDrag");
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
		    		this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemQuality");
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
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemIcon");
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
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ItemNum");
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
		    		this.m_E_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ItemName");
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
		    		this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_XuanZhong");
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
		    		this.m_E_BindingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Binding");
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
		    		this.m_E_UpTipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_UpTip");
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
		    		this.m_E_ProtectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Protect");
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
		    		this.m_E_LockButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Lock");
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
		    		this.m_E_LockImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Lock");
     			}
     			return this.m_E_LockImage;
     		}
     	}

		public Image E_ImageReceived
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_ImageReceived == null )
				{
					this.m_E_ImageReceived = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageReceived");
				}
				return this.m_E_ImageReceived;
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
			this.m_E_ImageReceived = null;
			this.uiTransform = null;
		}

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
		private Image m_E_ImageReceived = null;
		public Transform uiTransform = null;
	}
}
