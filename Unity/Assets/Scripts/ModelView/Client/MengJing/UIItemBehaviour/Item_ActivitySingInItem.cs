
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_ActivitySingInItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ActivitySingInItem>
	{
		public ItemInfo ItemInfo { get; set; }
		public long Time = 250;
		public Transform ScrollRect;
		public long ClickTime;
		public bool IsDrag;
		public bool IsClick;
		public Action<int> ClickHandler;
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ActivitySingInItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_LightImage
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
     				if( this.m_E_LightImage == null )
     				{
		    			this.m_E_LightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Light");
     				}
     				return this.m_E_LightImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Light");
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

		public UnityEngine.UI.Text E_DayText
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
     				if( this.m_E_DayText == null )
     				{
		    			this.m_E_DayText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Day");
     				}
     				return this.m_E_DayText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Day");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_LingQuImage
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
     				if( this.m_E_LingQuImage == null )
     				{
		    			this.m_E_LingQuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQu");
     				}
     				return this.m_E_LingQuImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQu");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemButtonImage
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
     				if( this.m_E_ItemButtonImage == null )
     				{
		    			this.m_E_ItemButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemButton");
     				}
     				return this.m_E_ItemButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemButton");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ItemButtonEventTrigger
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
     				if( this.m_E_ItemButtonEventTrigger == null )
     				{
		    			this.m_E_ItemButtonEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_ItemButton");
     				}
     				return this.m_E_ItemButtonEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_ItemButton");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_LightImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_ItemNumText = null;
			this.m_E_XuanZhongImage = null;
			this.m_E_DayText = null;
			this.m_E_LingQuImage = null;
			this.m_E_ItemButtonImage = null;
			this.m_E_ItemButtonEventTrigger = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_LightImage = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_ItemNumText = null;
		private UnityEngine.UI.Image m_E_XuanZhongImage = null;
		private UnityEngine.UI.Text m_E_DayText = null;
		private UnityEngine.UI.Image m_E_LingQuImage = null;
		private UnityEngine.UI.Image m_E_ItemButtonImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ItemButtonEventTrigger = null;
		public Transform uiTransform = null;
	}
}
