using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgCellDungeonRevive))]
	[EnableMethod]
	public  class DlgCellDungeonReviveViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_ImageCostImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCostImage == null )
     			{
		    		this.m_E_ImageCostImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageCost");
     			}
     			return this.m_E_ImageCostImage;
     		}
     	}

		public Button E_Button_ExitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ExitButton == null )
     			{
		    		this.m_E_Button_ExitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Exit");
     			}
     			return this.m_E_Button_ExitButton;
     		}
     	}

		public Image E_Button_ExitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ExitImage == null )
     			{
		    		this.m_E_Button_ExitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Exit");
     			}
     			return this.m_E_Button_ExitImage;
     		}
     	}

		public Text E_Text_ExitDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ExitDesText == null )
     			{
		    		this.m_E_Text_ExitDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Button_Exit/E_Text_ExitDes");
     			}
     			return this.m_E_Text_ExitDesText;
     		}
     	}

		public Button E_Button_ReviveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ReviveButton == null )
     			{
		    		this.m_E_Button_ReviveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Revive");
     			}
     			return this.m_E_Button_ReviveButton;
     		}
     	}

		public Image E_Button_ReviveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ReviveImage == null )
     			{
		    		this.m_E_Button_ReviveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Revive");
     			}
     			return this.m_E_Button_ReviveImage;
     		}
     	}

		public Text E_Text_ExitTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ExitTipText == null )
     			{
		    		this.m_E_Text_ExitTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_ExitTip");
     			}
     			return this.m_E_Text_ExitTipText;
     		}
     	}

		public Text E_Text_CostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostText == null )
     			{
		    		this.m_E_Text_CostText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Cost");
     			}
     			return this.m_E_Text_CostText;
     		}
     	}

		public Text E_Text_CostNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostNameText == null )
     			{
		    		this.m_E_Text_CostNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_CostName");
     			}
     			return this.m_E_Text_CostNameText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageCostImage = null;
			this.m_E_Button_ExitButton = null;
			this.m_E_Button_ExitImage = null;
			this.m_E_Text_ExitDesText = null;
			this.m_E_Button_ReviveButton = null;
			this.m_E_Button_ReviveImage = null;
			this.m_E_Text_ExitTipText = null;
			this.m_E_Text_CostText = null;
			this.m_E_Text_CostNameText = null;
			this.uiTransform = null;
		}

		private Image m_E_ImageCostImage = null;
		private Button m_E_Button_ExitButton = null;
		private Image m_E_Button_ExitImage = null;
		private Text m_E_Text_ExitDesText = null;
		private Button m_E_Button_ReviveButton = null;
		private Image m_E_Button_ReviveImage = null;
		private Text m_E_Text_ExitTipText = null;
		private Text m_E_Text_CostText = null;
		private Text m_E_Text_CostNameText = null;
		public Transform uiTransform = null;
	}
}
