
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanCooking : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public ES_CommonItem[] CostItemList = new ES_CommonItem[4];
		public bool IsHoldDown = false;
		public List<BagInfo> ShowBagInfos = new();
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
		
		public ES_CommonItem ES_CommonItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_0 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_0");
		    	   this.m_es_commonitem_0 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_0;
     		}
     	}

		public ES_CommonItem ES_CommonItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_1");
		    	   this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_1;
     		}
     	}

		public ES_CommonItem ES_CommonItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public ES_CommonItem ES_CommonItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_3");
		    	   this.m_es_commonitem_3 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_3;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonMakeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMakeButton == null )
     			{
		    		this.m_E_ButtonMakeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonMake");
     			}
     			return this.m_E_ButtonMakeButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMakeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMakeImage == null )
     			{
		    		this.m_E_ButtonMakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonMake");
     			}
     			return this.m_E_ButtonMakeImage;
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
			this.m_es_commonitem_0 = null;
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_es_commonitem_3 = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonMakeButton = null;
			this.m_E_ButtonMakeImage = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem_0 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_3 = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonMakeButton = null;
		private UnityEngine.UI.Image m_E_ButtonMakeImage = null;
		public Transform uiTransform = null;
	}
}
