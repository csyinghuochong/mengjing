using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WarehouseAccount : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		private EntityRef<ItemInfo> bagInfoPutIn;
		public ItemInfo BagInfoPutIn { get => this.bagInfoPutIn; set => this.bagInfoPutIn = value; }
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemHouseItems;
		public List<ItemInfo> AccountBagInfos { get; set; } = new();
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
			this.m_E_BagItems1LoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_BagItems2LoopVerticalScrollRect = null;
		private Button m_E_ButtonPackButton = null;
		private Image m_E_ButtonPackImage = null;
		private LoopVerticalScrollRect m_E_BagItems1LoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
