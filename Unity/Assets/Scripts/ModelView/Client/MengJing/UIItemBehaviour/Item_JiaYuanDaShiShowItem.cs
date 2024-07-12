
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanDaShiShowItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanDaShiShowItem> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanDaShiShowItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.RectTransform EG_Item_0RectTransform
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
     				if( this.m_EG_Item_0RectTransform == null )
     				{
		    			this.m_EG_Item_0RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item_0");
     				}
     				return this.m_EG_Item_0RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item_0");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_Item_1RectTransform
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
     				if( this.m_EG_Item_1RectTransform == null )
     				{
		    			this.m_EG_Item_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item_1");
     				}
     				return this.m_EG_Item_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item_1");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_Item_2RectTransform
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
     				if( this.m_EG_Item_2RectTransform == null )
     				{
		    			this.m_EG_Item_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item_2");
     				}
     				return this.m_EG_Item_2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item_2");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_Item_0RectTransform = null;
			this.m_EG_Item_1RectTransform = null;
			this.m_EG_Item_2RectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.RectTransform m_EG_Item_0RectTransform = null;
		private UnityEngine.RectTransform m_EG_Item_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_Item_2RectTransform = null;
		public Transform uiTransform = null;
	}
}
