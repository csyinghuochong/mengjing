using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuRewardItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ChengJiuRewardItem>
	{
		public Action<int> ClickHandler;
		public int ChengJiuRewardId;
		
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

		public Button E_DiButtonButton
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
		    			this.m_E_DiButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_DiButton");
     				}
     				return this.m_E_DiButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_DiButton");
     			}
     		}
     	}

		public Image E_DiButtonImage
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
		    			this.m_E_DiButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_DiButton");
     				}
     				return this.m_E_DiButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_DiButton");
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
		    			this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_XuanZhong");
     				}
     				return this.m_E_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_XuanZhong");
     			}
     		}
     	}

		public Image E_ChengJiuIconImage
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
		    			this.m_E_ChengJiuIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ChengJiuIcon");
     				}
     				return this.m_E_ChengJiuIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ChengJiuIcon");
     			}
     		}
     	}

		public Text E_ChengJiuNumText
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
		    			this.m_E_ChengJiuNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ChengJiuNum");
     				}
     				return this.m_E_ChengJiuNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ChengJiuNum");
     			}
     		}
     	}

		public Button E_ReceivedButton
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
		    			this.m_E_ReceivedButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Received");
     				}
     				return this.m_E_ReceivedButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Received");
     			}
     		}
     	}

		public Image E_ReceivedImage
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
		    			this.m_E_ReceivedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Received");
     				}
     				return this.m_E_ReceivedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Received");
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

		private Button m_E_DiButtonButton = null;
		private Image m_E_DiButtonImage = null;
		private Image m_E_XuanZhongImage = null;
		private Image m_E_ChengJiuIconImage = null;
		private Text m_E_ChengJiuNumText = null;
		private Button m_E_ReceivedButton = null;
		private Image m_E_ReceivedImage = null;
		public Transform uiTransform = null;
	}
}
