
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CommonItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_CommonItem> 
	{
		public int CurrentHouse { get; set; }
		public bool UseTextColor { get; set; }
		public ItemInfo Baginfo { get; set; }
		public string ItemNum { get; set; }
		public int ItemID { get; set; }
		public bool ShowTip { get; set; }
		public ItemOperateEnum ItemOperateEnum { get; set; }
		public Action<ItemInfo> ClickItemHandler { get; set; }
		public Action<ItemInfo, PointerEventData> BeginDragHandler { get; set; }
		public Action<ItemInfo, PointerEventData> DragingHandler { get; set; }
		public Action<ItemInfo, PointerEventData> EndDragHandler { get; set; }
		public Action<ItemInfo, PointerEventData> PointerDownHandler { get; set; }
		public Action<ItemInfo, PointerEventData> PointerUpHandler { get; set; }
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CommonItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_ItemDiButton
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
		    			this.m_E_ItemDiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ItemDi");
     				}
     				return this.m_E_ItemDiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ItemDi");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemDiImage
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
		    			this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemDi");
     				}
     				return this.m_E_ItemDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemDi");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ItemClickButton
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
		    			this.m_E_ItemClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ItemClick");
     				}
     				return this.m_E_ItemClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ItemClick");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemClickImage
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
		    			this.m_E_ItemClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemClick");
     				}
     				return this.m_E_ItemClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemClick");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ItemDragButton
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
		    			this.m_E_ItemDragButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ItemDrag");
     				}
     				return this.m_E_ItemDragButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ItemDrag");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemDragImage
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
		    			this.m_E_ItemDragImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemDrag");
     				}
     				return this.m_E_ItemDragImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemDrag");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ItemDragEventTrigger
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
		    			this.m_E_ItemDragEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_ItemDrag");
     				}
     				return this.m_E_ItemDragEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_ItemDrag");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemQualityImage
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
		    			this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemQuality");
     				}
     				return this.m_E_ItemQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemQuality");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemIconImage
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
		    			this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemIcon");
     				}
     				return this.m_E_ItemIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ItemNumText
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
		    			this.m_E_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemNum");
     				}
     				return this.m_E_ItemNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemNum");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ItemNameText
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
		    			this.m_E_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemName");
     				}
     				return this.m_E_ItemNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemName");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_XuanZhongImage
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
		    			this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_XuanZhong");
     				}
     				return this.m_E_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_XuanZhong");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_BindingImage
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
		    			this.m_E_BindingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Binding");
     				}
     				return this.m_E_BindingImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Binding");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_UpTipImage
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
		    			this.m_E_UpTipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_UpTip");
     				}
     				return this.m_E_UpTipImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_UpTip");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ProtectImage
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
		    			this.m_E_ProtectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Protect");
     				}
     				return this.m_E_ProtectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Protect");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_LockButton
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
		    			this.m_E_LockButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Lock");
     				}
     				return this.m_E_LockButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Lock");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_LockImage
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
		    			this.m_E_LockImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Lock");
     				}
     				return this.m_E_LockImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Lock");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageReceivedImage
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
     				if( this.m_E_ImageReceivedImage == null )
     				{
		    			this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageReceived");
     				}
     				return this.m_E_ImageReceivedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageReceived");
     			}
     		}
     	}

		public void DestroyWidget()
		{
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
			this.m_E_ImageReceivedImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ItemDiButton = null;
		private UnityEngine.UI.Image m_E_ItemDiImage = null;
		private UnityEngine.UI.Button m_E_ItemClickButton = null;
		private UnityEngine.UI.Image m_E_ItemClickImage = null;
		private UnityEngine.UI.Button m_E_ItemDragButton = null;
		private UnityEngine.UI.Image m_E_ItemDragImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ItemDragEventTrigger = null;
		private UnityEngine.UI.Image m_E_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_ItemNumText = null;
		private UnityEngine.UI.Text m_E_ItemNameText = null;
		private UnityEngine.UI.Image m_E_XuanZhongImage = null;
		private UnityEngine.UI.Image m_E_BindingImage = null;
		private UnityEngine.UI.Image m_E_UpTipImage = null;
		private UnityEngine.UI.Image m_E_ProtectImage = null;
		private UnityEngine.UI.Button m_E_LockButton = null;
		private UnityEngine.UI.Image m_E_LockImage = null;
		private UnityEngine.UI.Image m_E_ImageReceivedImage = null;
		public Transform uiTransform = null;
	}
}
