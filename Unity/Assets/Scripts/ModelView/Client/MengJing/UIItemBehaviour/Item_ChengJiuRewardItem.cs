
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuRewardItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChengJiuRewardItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_DiButtonButton
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
     				if( this.m_E_DiButtonButton == null )
     				{
		    			this.m_E_DiButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_DiButton");
     				}
     				return this.m_E_DiButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_DiButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_DiButtonImage
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
     				if( this.m_E_DiButtonImage == null )
     				{
		    			this.m_E_DiButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_DiButton");
     				}
     				return this.m_E_DiButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_DiButton");
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

		public UnityEngine.UI.Image E_ChengJiuIconImage
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
     				if( this.m_E_ChengJiuIconImage == null )
     				{
		    			this.m_E_ChengJiuIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ChengJiuIcon");
     				}
     				return this.m_E_ChengJiuIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ChengJiuIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ChengJiuNumText
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
     				if( this.m_E_ChengJiuNumText == null )
     				{
		    			this.m_E_ChengJiuNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ChengJiuNum");
     				}
     				return this.m_E_ChengJiuNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ChengJiuNum");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ReceivedButton
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
     				if( this.m_E_ReceivedButton == null )
     				{
		    			this.m_E_ReceivedButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Received");
     				}
     				return this.m_E_ReceivedButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Received");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ReceivedImage
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
     				if( this.m_E_ReceivedImage == null )
     				{
		    			this.m_E_ReceivedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Received");
     				}
     				return this.m_E_ReceivedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Received");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_DiButtonButton = null;
			this.m_E_DiButtonImage = null;
			this.m_E_XuanZhongImage = null;
			this.m_E_ChengJiuIconImage = null;
			this.m_E_ChengJiuNumText = null;
			this.m_E_ReceivedButton = null;
			this.m_E_ReceivedImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_DiButtonButton = null;
		private UnityEngine.UI.Image m_E_DiButtonImage = null;
		private UnityEngine.UI.Image m_E_XuanZhongImage = null;
		private UnityEngine.UI.Image m_E_ChengJiuIconImage = null;
		private UnityEngine.UI.Text m_E_ChengJiuNumText = null;
		private UnityEngine.UI.Button m_E_ReceivedButton = null;
		private UnityEngine.UI.Image m_E_ReceivedImage = null;
		public Transform uiTransform = null;
	}
}
