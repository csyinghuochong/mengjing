using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanDaShiPro : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<string> ShowProlist = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanDaShiProItem>> ScrollItemJiaYuanDaShiProItems;
		
		
		public LoopVerticalScrollRect E_JiaYuanDaShiProItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanDaShiProItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanDaShiProItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_JiaYuanDaShiProItems");
     			}
     			return this.m_E_JiaYuanDaShiProItemsLoopVerticalScrollRect;
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

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Button E_ButtonEatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEatButton == null )
     			{
		    		this.m_E_ButtonEatButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ButtonEat");
     			}
     			return this.m_E_ButtonEatButton;
     		}
     	}

		public Image E_ButtonEatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEatImage == null )
     			{
		    		this.m_E_ButtonEatImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ButtonEat");
     			}
     			return this.m_E_ButtonEatImage;
     		}
     	}

		public Text E_Label_TipsText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_TipsText == null )
     			{
		    		this.m_E_Label_TipsText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Label_Tips");
     			}
     			return this.m_E_Label_TipsText;
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
			this.m_E_JiaYuanDaShiProItemsLoopVerticalScrollRect = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_es_commonitem = null;
			this.m_E_ButtonEatButton = null;
			this.m_E_ButtonEatImage = null;
			this.m_E_Label_TipsText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_JiaYuanDaShiProItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_ButtonEatButton = null;
		private Image m_E_ButtonEatImage = null;
		private Text m_E_Label_TipsText = null;
		public Transform uiTransform = null;
	}
}
