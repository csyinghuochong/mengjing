using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WelfareInvest : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public DateTime EndTime;
		public Dictionary<int, EntityRef<Scroll_Item_WelfareInvestItem>> ScrollItemWelfareInvestItems;
		
		public LoopVerticalScrollRect E_WelfareInvestItemsLoopVerticalScrollRect
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
		    		this.m_E_WelfareInvestItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_WelfareInvestItems");
     			}
     			return this.m_E_WelfareInvestItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_InvestNumTextText
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
		    		this.m_E_InvestNumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/Invest/E_InvestNumText");
     			}
     			return this.m_E_InvestNumTextText;
     		}
     	}

		public Text E_ProfitNumTextText
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
		    		this.m_E_ProfitNumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/Profit/E_ProfitNumText");
     			}
     			return this.m_E_ProfitNumTextText;
     		}
     	}

		public Text E_TotalReturnNumTextText
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
		    		this.m_E_TotalReturnNumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/TotalReturn/E_TotalReturnNumText");
     			}
     			return this.m_E_TotalReturnNumTextText;
     		}
     	}

		public Text E_TimeTextText
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
		    		this.m_E_TimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_TimeText");
     			}
     			return this.m_E_TimeTextText;
     		}
     	}

		public Button E_ReceiveBtnButton
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
		    		this.m_E_ReceiveBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ReceiveBtn");
     			}
     			return this.m_E_ReceiveBtnButton;
     		}
     	}

		public Image E_ReceiveBtnImage
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
		    		this.m_E_ReceiveBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ReceiveBtn");
     			}
     			return this.m_E_ReceiveBtnImage;
     		}
     	}

		public Image E_ReceivedImgImage
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
		    		this.m_E_ReceivedImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ReceivedImg");
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

		private LoopVerticalScrollRect m_E_WelfareInvestItemsLoopVerticalScrollRect = null;
		private Text m_E_InvestNumTextText = null;
		private Text m_E_ProfitNumTextText = null;
		private Text m_E_TotalReturnNumTextText = null;
		private Text m_E_TimeTextText = null;
		private Button m_E_ReceiveBtnButton = null;
		private Image m_E_ReceiveBtnImage = null;
		private Image m_E_ReceivedImgImage = null;
		public Transform uiTransform = null;
	}
}
