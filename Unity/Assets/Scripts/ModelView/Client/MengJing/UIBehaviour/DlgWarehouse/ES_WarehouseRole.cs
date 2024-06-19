
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WarehouseRole : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int CurrentItemType;
		public List<GameObject> LockList = new();
		public List<GameObject> NoLockList = new();
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemHouseItems;
		public List<BagInfo> ShowHouseBagInfos = new();
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemBagItems;
		public List<BagInfo> ShowBagBagInfos = new();

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItems2LoopVerticalScrollRect
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
		    		this.m_E_BagItems2LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems2");
     			}
     			return this.m_E_BagItems2LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonPackButton
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
		    		this.m_E_ButtonPackButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonPack");
     			}
     			return this.m_E_ButtonPackButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonPackImage
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
		    		this.m_E_ButtonPackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonPack");
     			}
     			return this.m_E_ButtonPackImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonQuickButton
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
		    		this.m_E_ButtonQuickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonQuick");
     			}
     			return this.m_E_ButtonQuickButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonQuickImage
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
		    		this.m_E_ButtonQuickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonQuick");
     			}
     			return this.m_E_ButtonQuickImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItems1LoopVerticalScrollRect
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
		    		this.m_E_BagItems1LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_BagItems1");
     			}
     			return this.m_E_BagItems1LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_NoLock_1Image
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
		    		this.m_E_NoLock_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_NoLock_1");
     			}
     			return this.m_E_NoLock_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_NoLock_2Image
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
		    		this.m_E_NoLock_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_NoLock_2");
     			}
     			return this.m_E_NoLock_2Image;
     		}
     	}

		public UnityEngine.UI.Image E_NoLock_3Image
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
		    		this.m_E_NoLock_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_NoLock_3");
     			}
     			return this.m_E_NoLock_3Image;
     		}
     	}

		public UnityEngine.UI.Image E_NoLock_4Image
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
		    		this.m_E_NoLock_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_NoLock_4");
     			}
     			return this.m_E_NoLock_4Image;
     		}
     	}

		public UnityEngine.UI.Image E_Lock_1Image
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
		    		this.m_E_Lock_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Lock_1");
     			}
     			return this.m_E_Lock_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_Lock_2Image
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
		    		this.m_E_Lock_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Lock_2");
     			}
     			return this.m_E_Lock_2Image;
     		}
     	}

		public UnityEngine.UI.Image E_Lock_3Image
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
		    		this.m_E_Lock_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Lock_3");
     			}
     			return this.m_E_Lock_3Image;
     		}
     	}

		public UnityEngine.UI.Image E_Lock_4Image
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
		    		this.m_E_Lock_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Lock_4");
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

		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItems2LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonPackButton = null;
		private UnityEngine.UI.Image m_E_ButtonPackImage = null;
		private UnityEngine.UI.Button m_E_ButtonQuickButton = null;
		private UnityEngine.UI.Image m_E_ButtonQuickImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItems1LoopVerticalScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_NoLock_1Image = null;
		private UnityEngine.UI.Image m_E_NoLock_2Image = null;
		private UnityEngine.UI.Image m_E_NoLock_3Image = null;
		private UnityEngine.UI.Image m_E_NoLock_4Image = null;
		private UnityEngine.UI.Image m_E_Lock_1Image = null;
		private UnityEngine.UI.Image m_E_Lock_2Image = null;
		private UnityEngine.UI.Image m_E_Lock_3Image = null;
		private UnityEngine.UI.Image m_E_Lock_4Image = null;
		public Transform uiTransform = null;
	}
}
