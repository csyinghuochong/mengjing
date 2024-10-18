using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleGem : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public int CurrentItemType;
		public List<EntityRef<ES_RoleGemHole>> GemHoleList = new();
		private EntityRef<ItemInfo> xiangQianItem;
		public ItemInfo XiangQianItem { get => this.xiangQianItem; set => this.xiangQianItem = value; }
		public int XiangQianIndex;

		public ES_RoleGemHole ES_RoleGemHole_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleGemHole es = this.m_es_rolegemhole_0;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Gem/ES_RoleGemHole_0");
		    	   this.m_es_rolegemhole_0 = this.AddChild<ES_RoleGemHole,Transform>(subTrans);
     			}
     			return this.m_es_rolegemhole_0;
     		}
     	}

		public ES_RoleGemHole ES_RoleGemHole_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RoleGemHole es = this.m_es_rolegemhole_1;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Gem/ES_RoleGemHole_1");
		    	   this.m_es_rolegemhole_1 = this.AddChild<ES_RoleGemHole,Transform>(subTrans);
     			}
     			return this.m_es_rolegemhole_1;
     		}
     	}

		public ES_RoleGemHole ES_RoleGemHole_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RoleGemHole es = this.m_es_rolegemhole_2;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Gem/ES_RoleGemHole_2");
		    	   this.m_es_rolegemhole_2 = this.AddChild<ES_RoleGemHole,Transform>(subTrans);
     			}
     			return this.m_es_rolegemhole_2;
     		}
     	}

		public ES_RoleGemHole ES_RoleGemHole_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RoleGemHole es = this.m_es_rolegemhole_3;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Gem/ES_RoleGemHole_3");
		    	   this.m_es_rolegemhole_3 = this.AddChild<ES_RoleGemHole,Transform>(subTrans);
     			}
     			return this.m_es_rolegemhole_3;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Gem/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Right/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
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
			this.m_es_rolegemhole_0 = null;
			this.m_es_rolegemhole_1 = null;
			this.m_es_rolegemhole_2 = null;
			this.m_es_rolegemhole_3 = null;
			this.m_es_commonitem = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_0 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_1 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_2 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_3 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
