using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleBag : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public int CurrentItemType;

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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Right/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public Button E_ZhengLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhengLiButton == null )
     			{
		    		this.m_E_ZhengLiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ZhengLi");
     			}
     			return this.m_E_ZhengLiButton;
     		}
     	}

		public Image E_ZhengLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhengLiImage == null )
     			{
		    		this.m_E_ZhengLiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ZhengLi");
     			}
     			return this.m_E_ZhengLiImage;
     		}
     	}

		public Button E_OneSellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneSellButton == null )
     			{
		    		this.m_E_OneSellButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_OneSell");
     			}
     			return this.m_E_OneSellButton;
     		}
     	}

		public Image E_OneSellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneSellImage == null )
     			{
		    		this.m_E_OneSellImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_OneSell");
     			}
     			return this.m_E_OneSellImage;
     		}
     	}

		public Button E_OneGemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneGemButton == null )
     			{
		    		this.m_E_OneGemButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_OneGem");
     			}
     			return this.m_E_OneGemButton;
     		}
     	}

		public Image E_OneGemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneGemImage == null )
     			{
		    		this.m_E_OneGemImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_OneGem");
     			}
     			return this.m_E_OneGemImage;
     		}
     	}

		public Button E_OpenOneSellSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenOneSellSetButton == null )
     			{
		    		this.m_E_OpenOneSellSetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_OpenOneSellSet");
     			}
     			return this.m_E_OpenOneSellSetButton;
     		}
     	}

		public Image E_OpenOneSellSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenOneSellSetImage == null )
     			{
		    		this.m_E_OpenOneSellSetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_OpenOneSellSet");
     			}
     			return this.m_E_OpenOneSellSetImage;
     		}
     	}

		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
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
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_ZhengLiButton = null;
			this.m_E_ZhengLiImage = null;
			this.m_E_OneSellButton = null;
			this.m_E_OneSellImage = null;
			this.m_E_OneGemButton = null;
			this.m_E_OneGemImage = null;
			this.m_E_OpenOneSellSetButton = null;
			this.m_E_OpenOneSellSetImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private Button m_E_ZhengLiButton = null;
		private Image m_E_ZhengLiImage = null;
		private Button m_E_OneSellButton = null;
		private Image m_E_OneSellImage = null;
		private Button m_E_OneGemButton = null;
		private Image m_E_OneGemImage = null;
		private Button m_E_OpenOneSellSetButton = null;
		private Image m_E_OpenOneSellSetImage = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
