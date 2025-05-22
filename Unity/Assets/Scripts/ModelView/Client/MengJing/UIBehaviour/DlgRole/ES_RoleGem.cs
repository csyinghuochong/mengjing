
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleGem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public int CurrentItemType;
		public List<GameObject> ItemDiList = new();
		public List<EntityRef<ES_RoleGemHole>> GemHoleList = new();
		public long ItemBagInfoID;
		private EntityRef<ItemInfo> xiangQianItem;
		public ItemInfo XiangQianItem { get => this.xiangQianItem; set => this.xiangQianItem = value; }
		public int XiangQianIndex;
		
		public UnityEngine.UI.Button E_ItemDi_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_1Button == null )
     			{
		    		this.m_E_ItemDi_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ItemDi_1");
     			}
     			return this.m_E_ItemDi_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDi_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_1Image == null )
     			{
		    		this.m_E_ItemDi_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ItemDi_1");
     			}
     			return this.m_E_ItemDi_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_ItemDi_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_2Button == null )
     			{
		    		this.m_E_ItemDi_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ItemDi_2");
     			}
     			return this.m_E_ItemDi_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDi_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_2Image == null )
     			{
		    		this.m_E_ItemDi_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ItemDi_2");
     			}
     			return this.m_E_ItemDi_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_ItemDi_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_3Button == null )
     			{
		    		this.m_E_ItemDi_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ItemDi_3");
     			}
     			return this.m_E_ItemDi_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDi_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_3Image == null )
     			{
		    		this.m_E_ItemDi_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ItemDi_3");
     			}
     			return this.m_E_ItemDi_3Image;
     		}
     	}

		public UnityEngine.UI.Button E_ItemDi_4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_4Button == null )
     			{
		    		this.m_E_ItemDi_4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ItemDi_4");
     			}
     			return this.m_E_ItemDi_4Button;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDi_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDi_4Image == null )
     			{
		    		this.m_E_ItemDi_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ItemDi_4");
     			}
     			return this.m_E_ItemDi_4Image;
     		}
     	}

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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_RoleGemHole_0");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_RoleGemHole_1");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_RoleGemHole_2");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_RoleGemHole_3");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_CommonItem");
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

		public UnityEngine.UI.Image E_BagItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsImage == null )
     			{
		    		this.m_E_BagItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_BagItems");
     			}
     			return this.m_E_BagItemsImage;
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
			this.m_E_ItemDi_1Button = null;
			this.m_E_ItemDi_1Image = null;
			this.m_E_ItemDi_2Button = null;
			this.m_E_ItemDi_2Image = null;
			this.m_E_ItemDi_3Button = null;
			this.m_E_ItemDi_3Image = null;
			this.m_E_ItemDi_4Button = null;
			this.m_E_ItemDi_4Image = null;
			this.m_es_rolegemhole_0 = null;
			this.m_es_rolegemhole_1 = null;
			this.m_es_rolegemhole_2 = null;
			this.m_es_rolegemhole_3 = null;
			this.m_es_commonitem = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_BagItemsImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ItemDi_1Button = null;
		private UnityEngine.UI.Image m_E_ItemDi_1Image = null;
		private UnityEngine.UI.Button m_E_ItemDi_2Button = null;
		private UnityEngine.UI.Image m_E_ItemDi_2Image = null;
		private UnityEngine.UI.Button m_E_ItemDi_3Button = null;
		private UnityEngine.UI.Image m_E_ItemDi_3Image = null;
		private UnityEngine.UI.Button m_E_ItemDi_4Button = null;
		private UnityEngine.UI.Image m_E_ItemDi_4Image = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_0 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_1 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_2 = null;
		private EntityRef<ES_RoleGemHole> m_es_rolegemhole_3 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_BagItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
