
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WelfareInvest : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public DateTime EndTime;
		public Dictionary<int, Scroll_Item_WelfareInvestItem> ScrollItemWelfareInvestItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_WelfareInvestItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WelfareInvestItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_WelfareInvestItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_WelfareInvestItems");
     			}
     			return this.m_E_WelfareInvestItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_InvestNumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InvestNumTextText == null )
     			{
		    		this.m_E_InvestNumTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/Invest/E_InvestNumText");
     			}
     			return this.m_E_InvestNumTextText;
     		}
     	}

		public UnityEngine.UI.Text E_ProfitNumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProfitNumTextText == null )
     			{
		    		this.m_E_ProfitNumTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/Profit/E_ProfitNumText");
     			}
     			return this.m_E_ProfitNumTextText;
     		}
     	}

		public UnityEngine.UI.Text E_TotalReturnNumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TotalReturnNumTextText == null )
     			{
		    		this.m_E_TotalReturnNumTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/TotalReturn/E_TotalReturnNumText");
     			}
     			return this.m_E_TotalReturnNumTextText;
     		}
     	}

		public UnityEngine.UI.Text E_TimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimeTextText == null )
     			{
		    		this.m_E_TimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TimeText");
     			}
     			return this.m_E_TimeTextText;
     		}
     	}

		public UnityEngine.UI.Button E_ReceiveBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceiveBtnButton == null )
     			{
		    		this.m_E_ReceiveBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ReceiveBtn");
     			}
     			return this.m_E_ReceiveBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReceiveBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceiveBtnImage == null )
     			{
		    		this.m_E_ReceiveBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ReceiveBtn");
     			}
     			return this.m_E_ReceiveBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_ReceivedImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceivedImgImage == null )
     			{
		    		this.m_E_ReceivedImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ReceivedImg");
     			}
     			return this.m_E_ReceivedImgImage;
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
			this.m_E_WelfareInvestItemsLoopVerticalScrollRect = null;
			this.m_E_InvestNumTextText = null;
			this.m_E_ProfitNumTextText = null;
			this.m_E_TotalReturnNumTextText = null;
			this.m_E_TimeTextText = null;
			this.m_E_ReceiveBtnButton = null;
			this.m_E_ReceiveBtnImage = null;
			this.m_E_ReceivedImgImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_WelfareInvestItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_InvestNumTextText = null;
		private UnityEngine.UI.Text m_E_ProfitNumTextText = null;
		private UnityEngine.UI.Text m_E_TotalReturnNumTextText = null;
		private UnityEngine.UI.Text m_E_TimeTextText = null;
		private UnityEngine.UI.Button m_E_ReceiveBtnButton = null;
		private UnityEngine.UI.Image m_E_ReceiveBtnImage = null;
		private UnityEngine.UI.Image m_E_ReceivedImgImage = null;
		public Transform uiTransform = null;
	}
}
