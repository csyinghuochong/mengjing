
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleGem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
		public List<BagInfo> ShowBagInfos = new();
		public int CurrentItemType;
		public List<ES_RoleGemHole> GemHoleList = new();
		public BagInfo XiangQianItem;
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
     			if( this.m_es_rolegemhole_0 .Equals(null))
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
     			if( this.m_es_rolegemhole_1 .Equals(null) )
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
     			if( this.m_es_rolegemhole_2 .Equals(null) )
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
     			if( this.m_es_rolegemhole_3 .Equals(null) )
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
     			if( this.m_es_commonitem .Equals(null))
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Gem/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_AllToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AllToggle == null )
     			{
		    		this.m_E_AllToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_All");
     			}
     			return this.m_E_AllToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_EquipToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipToggle == null )
     			{
		    		this.m_E_EquipToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_Equip");
     			}
     			return this.m_E_EquipToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_CaiLiaoToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CaiLiaoToggle == null )
     			{
		    		this.m_E_CaiLiaoToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_CaiLiao");
     			}
     			return this.m_E_CaiLiaoToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_XiaoHaoToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiaoHaoToggle == null )
     			{
		    		this.m_E_XiaoHaoToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_XiaoHao");
     			}
     			return this.m_E_XiaoHaoToggle;
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
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
			this.m_E_AllToggle = null;
			this.m_E_EquipToggle = null;
			this.m_E_CaiLiaoToggle = null;
			this.m_E_XiaoHaoToggle = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_0 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_1 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_2 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_3 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_AllToggle = null;
		private UnityEngine.UI.Toggle m_E_EquipToggle = null;
		private UnityEngine.UI.Toggle m_E_CaiLiaoToggle = null;
		private UnityEngine.UI.Toggle m_E_XiaoHaoToggle = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
