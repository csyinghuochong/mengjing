using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionDonation))]
	[EnableMethod]
	public  class DlgUnionDonationViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Button_DiamondDonationButton
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
		    		this.m_E_Button_DiamondDonationButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_DiamondDonation");
     			}
     			return this.m_E_Button_DiamondDonationButton;
     		}
     	}

		public Image E_Button_DiamondDonationImage
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
		    		this.m_E_Button_DiamondDonationImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_DiamondDonation");
     			}
     			return this.m_E_Button_DiamondDonationImage;
     		}
     	}

		public Button E_Button_DonationButton
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
		    		this.m_E_Button_DonationButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Donation");
     			}
     			return this.m_E_Button_DonationButton;
     		}
     	}

		public Image E_Button_DonationImage
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
		    		this.m_E_Button_DonationImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Donation");
     			}
     			return this.m_E_Button_DonationImage;
     		}
     	}

		public Button E_Button_RecordButton
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
		    		this.m_E_Button_RecordButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Record");
     			}
     			return this.m_E_Button_RecordButton;
     		}
     	}

		public Image E_Button_RecordImage
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
		    		this.m_E_Button_RecordImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Record");
     			}
     			return this.m_E_Button_RecordImage;
     		}
     	}

		public Text E_Text_Tip_3Text
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
		    		this.m_E_Text_Tip_3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Tip_3");
     			}
     			return this.m_E_Text_Tip_3Text;
     		}
     	}

		public Text E_Text_Tip_4Text
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
		    		this.m_E_Text_Tip_4Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Tip_4");
     			}
     			return this.m_E_Text_Tip_4Text;
     		}
     	}

		public Text E_Text_Tip_5Text
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
		    		this.m_E_Text_Tip_5Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Tip_5");
     			}
     			return this.m_E_Text_Tip_5Text;
     		}
     	}

		public Text E_Text_Tip_6Text
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
		    		this.m_E_Text_Tip_6Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Tip_6");
     			}
     			return this.m_E_Text_Tip_6Text;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Button_DiamondDonationButton = null;
			this.m_E_Button_DiamondDonationImage = null;
			this.m_E_Button_DonationButton = null;
			this.m_E_Button_DonationImage = null;
			this.m_E_Button_RecordButton = null;
			this.m_E_Button_RecordImage = null;
			this.m_E_Text_Tip_3Text = null;
			this.m_E_Text_Tip_4Text = null;
			this.m_E_Text_Tip_5Text = null;
			this.m_E_Text_Tip_6Text = null;
			this.uiTransform = null;
		}

		private Button m_E_Button_DiamondDonationButton = null;
		private Image m_E_Button_DiamondDonationImage = null;
		private Button m_E_Button_DonationButton = null;
		private Image m_E_Button_DonationImage = null;
		private Button m_E_Button_RecordButton = null;
		private Image m_E_Button_RecordImage = null;
		private Text m_E_Text_Tip_3Text = null;
		private Text m_E_Text_Tip_4Text = null;
		private Text m_E_Text_Tip_5Text = null;
		private Text m_E_Text_Tip_6Text = null;
		public Transform uiTransform = null;
	}
}
