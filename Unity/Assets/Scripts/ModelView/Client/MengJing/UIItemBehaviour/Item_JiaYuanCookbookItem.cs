using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanCookbookItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanCookbookItem> 
	{
		public int MakeItemId = 0;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanCookbookItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
     			if (this.isCacheNode)
     			{
     				if( es == null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( es != null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			es = this.m_es_commonitem;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem = null;
		    				this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     		}
     	}

		public RectTransform EG_MakeItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EG_MakeItemRectTransform == null )
     				{
		    			this.m_EG_MakeItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MakeItem");
     				}
     				return this.m_EG_MakeItemRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MakeItem");
     			}
     		}
     	}

		public Button E_ItemDiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemDiButton == null )
     				{
		    			this.m_E_ItemDiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDi");
     				}
     				return this.m_E_ItemDiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDi");
     			}
     		}
     	}

		public Image E_ItemDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemDiImage == null )
     				{
		    			this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDi");
     				}
     				return this.m_E_ItemDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDi");
     			}
     		}
     	}

		public Button E_ItemClickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemClickButton == null )
     				{
		    			this.m_E_ItemClickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemClick");
     				}
     				return this.m_E_ItemClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemClick");
     			}
     		}
     	}

		public Image E_ItemClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemClickImage == null )
     				{
		    			this.m_E_ItemClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemClick");
     				}
     				return this.m_E_ItemClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemClick");
     			}
     		}
     	}

		public Button E_ItemDragButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemDragButton == null )
     				{
		    			this.m_E_ItemDragButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDrag");
     				}
     				return this.m_E_ItemDragButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDrag");
     			}
     		}
     	}

		public Image E_ItemDragImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemDragImage == null )
     				{
		    			this.m_E_ItemDragImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDrag");
     				}
     				return this.m_E_ItemDragImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDrag");
     			}
     		}
     	}

		public EventTrigger E_ItemDragEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemDragEventTrigger == null )
     				{
		    			this.m_E_ItemDragEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDrag");
     				}
     				return this.m_E_ItemDragEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemDrag");
     			}
     		}
     	}

		public Image E_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemQualityImage == null )
     				{
		    			this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemQuality");
     				}
     				return this.m_E_ItemQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemQuality");
     			}
     		}
     	}

		public Image E_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemIconImage == null )
     				{
		    			this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemIcon");
     				}
     				return this.m_E_ItemIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemIcon");
     			}
     		}
     	}

		public Text E_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemNumText == null )
     				{
		    			this.m_E_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemNum");
     				}
     				return this.m_E_ItemNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemNum");
     			}
     		}
     	}

		public Text E_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ItemNameText == null )
     				{
		    			this.m_E_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemName");
     				}
     				return this.m_E_ItemNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MakeItem/E_ItemName");
     			}
     		}
     	}

		public Image E_XuanZhongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_XuanZhongImage == null )
     				{
		    			this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_XuanZhong");
     				}
     				return this.m_E_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_XuanZhong");
     			}
     		}
     	}

		public Image E_BindingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_BindingImage == null )
     				{
		    			this.m_E_BindingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_Binding");
     				}
     				return this.m_E_BindingImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_Binding");
     			}
     		}
     	}

		public Image E_UpTipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_UpTipImage == null )
     				{
		    			this.m_E_UpTipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_UpTip");
     				}
     				return this.m_E_UpTipImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_UpTip");
     			}
     		}
     	}

		public Image E_ProtectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ProtectImage == null )
     				{
		    			this.m_E_ProtectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_Protect");
     				}
     				return this.m_E_ProtectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_Protect");
     			}
     		}
     	}

		public Button E_LockButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_LockButton == null )
     				{
		    			this.m_E_LockButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_Lock");
     				}
     				return this.m_E_LockButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeItem/E_Lock");
     			}
     		}
     	}

		public Image E_LockImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_LockImage == null )
     				{
		    			this.m_E_LockImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_Lock");
     				}
     				return this.m_E_LockImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeItem/E_Lock");
     			}
     		}
     	}

		public RectTransform EG_MakeItemListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EG_MakeItemListRectTransform == null )
     				{
		    			this.m_EG_MakeItemListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MakeItemList");
     				}
     				return this.m_EG_MakeItemListRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MakeItemList");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem = null;
			this.m_EG_MakeItemRectTransform = null;
			this.m_E_ItemDiButton = null;
			this.m_E_ItemDiImage = null;
			this.m_E_ItemClickButton = null;
			this.m_E_ItemClickImage = null;
			this.m_E_ItemDragButton = null;
			this.m_E_ItemDragImage = null;
			this.m_E_ItemDragEventTrigger = null;
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_ItemNumText = null;
			this.m_E_ItemNameText = null;
			this.m_E_XuanZhongImage = null;
			this.m_E_BindingImage = null;
			this.m_E_UpTipImage = null;
			this.m_E_ProtectImage = null;
			this.m_E_LockButton = null;
			this.m_E_LockImage = null;
			this.m_EG_MakeItemListRectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private RectTransform m_EG_MakeItemRectTransform = null;
		private Button m_E_ItemDiButton = null;
		private Image m_E_ItemDiImage = null;
		private Button m_E_ItemClickButton = null;
		private Image m_E_ItemClickImage = null;
		private Button m_E_ItemDragButton = null;
		private Image m_E_ItemDragImage = null;
		private EventTrigger m_E_ItemDragEventTrigger = null;
		private Image m_E_ItemQualityImage = null;
		private Image m_E_ItemIconImage = null;
		private Text m_E_ItemNumText = null;
		private Text m_E_ItemNameText = null;
		private Image m_E_XuanZhongImage = null;
		private Image m_E_BindingImage = null;
		private Image m_E_UpTipImage = null;
		private Image m_E_ProtectImage = null;
		private Button m_E_LockButton = null;
		private Image m_E_LockImage = null;
		private RectTransform m_EG_MakeItemListRectTransform = null;
		public Transform uiTransform = null;
	}
}
