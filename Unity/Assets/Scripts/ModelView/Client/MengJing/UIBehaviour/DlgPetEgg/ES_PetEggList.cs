using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggList : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<EntityRef<ES_PetEggListItem>> PetList = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();

		public RectTransform EG_PetNodeListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetNodeListRectTransform == null )
     			{
		    		this.m_EG_PetNodeListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetNodeList");
     			}
     			return this.m_EG_PetNodeListRectTransform;
     		}
     	}

		public ES_PetEggListItem ES_PetEggListItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_PetEggListItem es = this.m_es_petegglistitem_0;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetNodeList/ES_PetEggListItem_0");
		    	   this.m_es_petegglistitem_0 = this.AddChild<ES_PetEggListItem,Transform>(subTrans);
     			}
     			return this.m_es_petegglistitem_0;
     		}
     	}

		public ES_PetEggListItem ES_PetEggListItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_PetEggListItem es = this.m_es_petegglistitem_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetNodeList/ES_PetEggListItem_1");
		    	   this.m_es_petegglistitem_1 = this.AddChild<ES_PetEggListItem,Transform>(subTrans);
     			}
     			return this.m_es_petegglistitem_1;
     		}
     	}

		public ES_PetEggListItem ES_PetEggListItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetEggListItem es = this.m_es_petegglistitem_2;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetNodeList/ES_PetEggListItem_2");
		    	   this.m_es_petegglistitem_2 = this.AddChild<ES_PetEggListItem,Transform>(subTrans);
     			}
     			return this.m_es_petegglistitem_2;
     		}
     	}

		public RectTransform EG_IconItemDargRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_IconItemDargRectTransform == null )
     			{
		    		this.m_EG_IconItemDargRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ShowSet/EG_IconItemDarg");
     			}
     			return this.m_EG_IconItemDargRectTransform;
     		}
     	}

		public LoopHorizontalScrollRect E_BagItemsLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<LoopHorizontalScrollRect>(this.uiTransform.gameObject,"ShowSet/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopHorizontalScrollRect;
     		}
     	}

		public Text E_TextTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTipText == null )
     			{
		    		this.m_E_TextTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ShowSet/E_TextTip");
     			}
     			return this.m_E_TextTipText;
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
			this.m_EG_PetNodeListRectTransform = null;
			this.m_es_petegglistitem_0 = null;
			this.m_es_petegglistitem_1 = null;
			this.m_es_petegglistitem_2 = null;
			this.m_EG_IconItemDargRectTransform = null;
			this.m_E_BagItemsLoopHorizontalScrollRect = null;
			this.m_E_TextTipText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_PetNodeListRectTransform = null;
		private EntityRef<ES_PetEggListItem> m_es_petegglistitem_0 = null;
		private EntityRef<ES_PetEggListItem> m_es_petegglistitem_1 = null;
		private EntityRef<ES_PetEggListItem> m_es_petegglistitem_2 = null;
		private RectTransform m_EG_IconItemDargRectTransform = null;
		private LoopHorizontalScrollRect m_E_BagItemsLoopHorizontalScrollRect = null;
		private Text m_E_TextTipText = null;
		public Transform uiTransform = null;
	}
}
