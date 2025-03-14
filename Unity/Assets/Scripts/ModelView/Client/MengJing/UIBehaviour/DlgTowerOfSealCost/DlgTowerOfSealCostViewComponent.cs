﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOfSealCost))]
	[EnableMethod]
	public  class DlgTowerOfSealCostViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_CloseBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnButton == null )
     			{
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"CostPanel/E_CloseBtn");
     			}
     			return this.m_E_CloseBtnButton;
     		}
     	}

		public Image E_CloseBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnImage == null )
     			{
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"CostPanel/E_CloseBtn");
     			}
     			return this.m_E_CloseBtnImage;
     		}
     	}

		public Button E_CostDiamondBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostDiamondBtnButton == null )
     			{
		    		this.m_E_CostDiamondBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"CostPanel/E_CostDiamondBtn");
     			}
     			return this.m_E_CostDiamondBtnButton;
     		}
     	}

		public Image E_CostDiamondBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostDiamondBtnImage == null )
     			{
		    		this.m_E_CostDiamondBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"CostPanel/E_CostDiamondBtn");
     			}
     			return this.m_E_CostDiamondBtnImage;
     		}
     	}

		public Button E_CostTicketBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostTicketBtnButton == null )
     			{
		    		this.m_E_CostTicketBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"CostPanel/E_CostTicketBtn");
     			}
     			return this.m_E_CostTicketBtnButton;
     		}
     	}

		public Image E_CostTicketBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostTicketBtnImage == null )
     			{
		    		this.m_E_CostTicketBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"CostPanel/E_CostTicketBtn");
     			}
     			return this.m_E_CostTicketBtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseBtnButton = null;
			this.m_E_CloseBtnImage = null;
			this.m_E_CostDiamondBtnButton = null;
			this.m_E_CostDiamondBtnImage = null;
			this.m_E_CostTicketBtnButton = null;
			this.m_E_CostTicketBtnImage = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseBtnButton = null;
		private Image m_E_CloseBtnImage = null;
		private Button m_E_CostDiamondBtnButton = null;
		private Image m_E_CostDiamondBtnImage = null;
		private Button m_E_CostTicketBtnButton = null;
		private Image m_E_CostTicketBtnImage = null;
		public Transform uiTransform = null;
	}
}
