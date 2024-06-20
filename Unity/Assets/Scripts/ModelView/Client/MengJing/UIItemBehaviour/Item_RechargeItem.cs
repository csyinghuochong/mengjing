
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RechargeItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public int RechargeNumber;
		public Action<int> ClickHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RechargeItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_ImageIconImage
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
     				if( this.m_E_ImageIconImage == null )
     				{
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ZengSongRectTransform
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
     				if( this.m_EG_ZengSongRectTransform == null )
     				{
		    			this.m_EG_ZengSongRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_ZengSong");
     				}
     				return this.m_EG_ZengSongRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_ZengSong");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_giveText
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
     				if( this.m_E_Text_giveText == null )
     				{
		    			this.m_E_Text_giveText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_ZengSong/E_Text_give");
     				}
     				return this.m_E_Text_giveText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_ZengSong/E_Text_give");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonChargeButton
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
     				if( this.m_E_ButtonChargeButton == null )
     				{
		    			this.m_E_ButtonChargeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonCharge");
     				}
     				return this.m_E_ButtonChargeButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonCharge");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonChargeImage
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
     				if( this.m_E_ButtonChargeImage == null )
     				{
		    			this.m_E_ButtonChargeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonCharge");
     				}
     				return this.m_E_ButtonChargeImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonCharge");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_RMBText
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
     				if( this.m_E_Text_RMBText == null )
     				{
		    			this.m_E_Text_RMBText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ButtonCharge/E_Text_RMB");
     				}
     				return this.m_E_Text_RMBText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ButtonCharge/E_Text_RMB");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_ZuanShiText
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
     				if( this.m_E_Text_ZuanShiText == null )
     				{
		    			this.m_E_Text_ZuanShiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_ZuanShi");
     				}
     				return this.m_E_Text_ZuanShiText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_ZuanShi");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageIconImage = null;
			this.m_EG_ZengSongRectTransform = null;
			this.m_E_Text_giveText = null;
			this.m_E_ButtonChargeButton = null;
			this.m_E_ButtonChargeImage = null;
			this.m_E_Text_RMBText = null;
			this.m_E_Text_ZuanShiText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.RectTransform m_EG_ZengSongRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_giveText = null;
		private UnityEngine.UI.Button m_E_ButtonChargeButton = null;
		private UnityEngine.UI.Image m_E_ButtonChargeImage = null;
		private UnityEngine.UI.Text m_E_Text_RMBText = null;
		private UnityEngine.UI.Text m_E_Text_ZuanShiText = null;
		public Transform uiTransform = null;
	}
}
