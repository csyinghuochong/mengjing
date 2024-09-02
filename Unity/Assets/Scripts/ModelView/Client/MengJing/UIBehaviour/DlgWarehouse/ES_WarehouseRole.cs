using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WarehouseRole : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<GameObject> LockList = new();
		public List<GameObject> NoLockList = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemHouseItems;
		public List<ItemInfo> ShowHouseBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemBagItems;
		public List<ItemInfo> ShowBagBagInfos { get; set; } = new();

		public LoopVerticalScrollRect E_BagItems2LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItems2LoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItems2LoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems2");
     			}
     			return this.m_E_BagItems2LoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonPackButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPackButton == null )
     			{
		    		this.m_E_ButtonPackButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonPack");
     			}
     			return this.m_E_ButtonPackButton;
     		}
     	}

		public Image E_ButtonPackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPackImage == null )
     			{
		    		this.m_E_ButtonPackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonPack");
     			}
     			return this.m_E_ButtonPackImage;
     		}
     	}

		public Button E_ButtonQuickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonQuickButton == null )
     			{
		    		this.m_E_ButtonQuickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonQuick");
     			}
     			return this.m_E_ButtonQuickButton;
     		}
     	}

		public Image E_ButtonQuickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonQuickImage == null )
     			{
		    		this.m_E_ButtonQuickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonQuick");
     			}
     			return this.m_E_ButtonQuickImage;
     		}
     	}

		public LoopVerticalScrollRect E_BagItems1LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItems1LoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItems1LoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_BagItems1");
     			}
     			return this.m_E_BagItems1LoopVerticalScrollRect;
     		}
     	}

		public ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public Image E_NoLock_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_1Image == null )
     			{
		    		this.m_E_NoLock_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_1");
     			}
     			return this.m_E_NoLock_1Image;
     		}
     	}

		public Image E_NoLock_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_2Image == null )
     			{
		    		this.m_E_NoLock_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_2");
     			}
     			return this.m_E_NoLock_2Image;
     		}
     	}

		public Image E_NoLock_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_3Image == null )
     			{
		    		this.m_E_NoLock_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_3");
     			}
     			return this.m_E_NoLock_3Image;
     		}
     	}

		public Image E_NoLock_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_4Image == null )
     			{
		    		this.m_E_NoLock_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_4");
     			}
     			return this.m_E_NoLock_4Image;
     		}
     	}

		public Image E_Lock_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_1Image == null )
     			{
		    		this.m_E_Lock_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_1");
     			}
     			return this.m_E_Lock_1Image;
     		}
     	}

		public Image E_Lock_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_2Image == null )
     			{
		    		this.m_E_Lock_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_2");
     			}
     			return this.m_E_Lock_2Image;
     		}
     	}

		public Image E_Lock_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_3Image == null )
     			{
		    		this.m_E_Lock_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_3");
     			}
     			return this.m_E_Lock_3Image;
     		}
     	}

		public Image E_Lock_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_4Image == null )
     			{
		    		this.m_E_Lock_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_4");
     			}
     			return this.m_E_Lock_4Image;
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
			this.m_E_BagItems2LoopVerticalScrollRect = null;
			this.m_E_ButtonPackButton = null;
			this.m_E_ButtonPackImage = null;
			this.m_E_ButtonQuickButton = null;
			this.m_E_ButtonQuickImage = null;
			this.m_E_BagItems1LoopVerticalScrollRect = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_NoLock_1Image = null;
			this.m_E_NoLock_2Image = null;
			this.m_E_NoLock_3Image = null;
			this.m_E_NoLock_4Image = null;
			this.m_E_Lock_1Image = null;
			this.m_E_Lock_2Image = null;
			this.m_E_Lock_3Image = null;
			this.m_E_Lock_4Image = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_BagItems2LoopVerticalScrollRect = null;
		private Button m_E_ButtonPackButton = null;
		private Image m_E_ButtonPackImage = null;
		private Button m_E_ButtonQuickButton = null;
		private Image m_E_ButtonQuickImage = null;
		private LoopVerticalScrollRect m_E_BagItems1LoopVerticalScrollRect = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private Image m_E_NoLock_1Image = null;
		private Image m_E_NoLock_2Image = null;
		private Image m_E_NoLock_3Image = null;
		private Image m_E_NoLock_4Image = null;
		private Image m_E_Lock_1Image = null;
		private Image m_E_Lock_2Image = null;
		private Image m_E_Lock_3Image = null;
		private Image m_E_Lock_4Image = null;
		public Transform uiTransform = null;
	}
}
