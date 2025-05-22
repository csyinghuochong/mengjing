
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionDonation))]
	[EnableMethod]
	public  class DlgUnionDonationViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Button_DiamondDonationButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DiamondDonationButton == null )
     			{
		    		this.m_E_Button_DiamondDonationButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_DiamondDonation");
     			}
     			return this.m_E_Button_DiamondDonationButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_DiamondDonationImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DiamondDonationImage == null )
     			{
		    		this.m_E_Button_DiamondDonationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_DiamondDonation");
     			}
     			return this.m_E_Button_DiamondDonationImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_DonationButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DonationButton == null )
     			{
		    		this.m_E_Button_DonationButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Donation");
     			}
     			return this.m_E_Button_DonationButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_DonationImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DonationImage == null )
     			{
		    		this.m_E_Button_DonationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Donation");
     			}
     			return this.m_E_Button_DonationImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Tip_3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Tip_3Text == null )
     			{
		    		this.m_E_Text_Tip_3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Tip_3");
     			}
     			return this.m_E_Text_Tip_3Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Tip_4Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Tip_4Text == null )
     			{
		    		this.m_E_Text_Tip_4Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Tip_4");
     			}
     			return this.m_E_Text_Tip_4Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Tip_5Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Tip_5Text == null )
     			{
		    		this.m_E_Text_Tip_5Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Tip_5");
     			}
     			return this.m_E_Text_Tip_5Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Tip_6Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Tip_6Text == null )
     			{
		    		this.m_E_Text_Tip_6Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Tip_6");
     			}
     			return this.m_E_Text_Tip_6Text;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RecordButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RecordButton == null )
     			{
		    		this.m_E_Button_RecordButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Record");
     			}
     			return this.m_E_Button_RecordButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RecordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RecordImage == null )
     			{
		    		this.m_E_Button_RecordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Record");
     			}
     			return this.m_E_Button_RecordImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Button_DiamondDonationButton = null;
			this.m_E_Button_DiamondDonationImage = null;
			this.m_E_Button_DonationButton = null;
			this.m_E_Button_DonationImage = null;
			this.m_E_Text_Tip_3Text = null;
			this.m_E_Text_Tip_4Text = null;
			this.m_E_Text_Tip_5Text = null;
			this.m_E_Text_Tip_6Text = null;
			this.m_E_Button_RecordButton = null;
			this.m_E_Button_RecordImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Button_DiamondDonationButton = null;
		private UnityEngine.UI.Image m_E_Button_DiamondDonationImage = null;
		private UnityEngine.UI.Button m_E_Button_DonationButton = null;
		private UnityEngine.UI.Image m_E_Button_DonationImage = null;
		private UnityEngine.UI.Text m_E_Text_Tip_3Text = null;
		private UnityEngine.UI.Text m_E_Text_Tip_4Text = null;
		private UnityEngine.UI.Text m_E_Text_Tip_5Text = null;
		private UnityEngine.UI.Text m_E_Text_Tip_6Text = null;
		private UnityEngine.UI.Button m_E_Button_RecordButton = null;
		private UnityEngine.UI.Image m_E_Button_RecordImage = null;
		public Transform uiTransform = null;
	}
}
