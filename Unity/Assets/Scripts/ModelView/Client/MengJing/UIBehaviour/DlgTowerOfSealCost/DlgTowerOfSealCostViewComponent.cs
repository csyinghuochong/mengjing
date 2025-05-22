
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOfSealCost))]
	[EnableMethod]
	public  class DlgTowerOfSealCostViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CloseBtnButton
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
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_CloseBtn");
     			}
     			return this.m_E_CloseBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseBtnImage
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
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_CloseBtn");
     			}
     			return this.m_E_CloseBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_CostDiamondBtnButton
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
		    		this.m_E_CostDiamondBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_CostDiamondBtn");
     			}
     			return this.m_E_CostDiamondBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_CostDiamondBtnImage
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
		    		this.m_E_CostDiamondBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_CostDiamondBtn");
     			}
     			return this.m_E_CostDiamondBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_CostTicketBtnButton
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
		    		this.m_E_CostTicketBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_CostTicketBtn");
     			}
     			return this.m_E_CostTicketBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_CostTicketBtnImage
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
		    		this.m_E_CostTicketBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_CostTicketBtn");
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

		private UnityEngine.UI.Button m_E_CloseBtnButton = null;
		private UnityEngine.UI.Image m_E_CloseBtnImage = null;
		private UnityEngine.UI.Button m_E_CostDiamondBtnButton = null;
		private UnityEngine.UI.Image m_E_CostDiamondBtnImage = null;
		private UnityEngine.UI.Button m_E_CostTicketBtnButton = null;
		private UnityEngine.UI.Image m_E_CostTicketBtnImage = null;
		public Transform uiTransform = null;
	}
}
