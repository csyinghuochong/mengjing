using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_DonationShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<RankingInfo> ShowRankingInfos;
		public Dictionary<int, EntityRef<Scroll_Item_DonationShowItem>> ScrollItemDonationShowItems;
        
		public LoopVerticalScrollRect E_DonationShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DonationShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_DonationShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_DonationShowItems");
     			}
     			return this.m_E_DonationShowItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_Donation_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Donation_1Button == null )
     			{
		    		this.m_E_Btn_Donation_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Donation_1");
     			}
     			return this.m_E_Btn_Donation_1Button;
     		}
     	}

		public Image E_Btn_Donation_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Donation_1Image == null )
     			{
		    		this.m_E_Btn_Donation_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Donation_1");
     			}
     			return this.m_E_Btn_Donation_1Image;
     		}
     	}

		public Text E_Text_MyDonationText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_MyDonationText == null )
     			{
		    		this.m_E_Text_MyDonationText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_MyDonation");
     			}
     			return this.m_E_Text_MyDonationText;
     		}
     	}

		public RectTransform EG_UIDonationPriceRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIDonationPriceRectTransform == null )
     			{
		    		this.m_EG_UIDonationPriceRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UIDonationPrice");
     			}
     			return this.m_EG_UIDonationPriceRectTransform;
     		}
     	}

		public Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public InputField E_InputFieldNumberInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNumberInputField == null )
     			{
		    		this.m_E_InputFieldNumberInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_InputFieldNumber");
     			}
     			return this.m_E_InputFieldNumberInputField;
     		}
     	}

		public Image E_InputFieldNumberImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNumberImage == null )
     			{
		    		this.m_E_InputFieldNumberImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_InputFieldNumber");
     			}
     			return this.m_E_InputFieldNumberImage;
     		}
     	}

		public Button E_Btn_Donation_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Donation_2Button == null )
     			{
		    		this.m_E_Btn_Donation_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_Btn_Donation_2");
     			}
     			return this.m_E_Btn_Donation_2Button;
     		}
     	}

		public Image E_Btn_Donation_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Donation_2Image == null )
     			{
		    		this.m_E_Btn_Donation_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_Btn_Donation_2");
     			}
     			return this.m_E_Btn_Donation_2Image;
     		}
     	}

		public Button E_BtnCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCloseButton == null )
     			{
		    		this.m_E_BtnCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_BtnClose");
     			}
     			return this.m_E_BtnCloseButton;
     		}
     	}

		public Image E_BtnCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCloseImage == null )
     			{
		    		this.m_E_BtnCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_BtnClose");
     			}
     			return this.m_E_BtnCloseImage;
     		}
     	}

		public Text E_TextMyDonationText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextMyDonationText == null )
     			{
		    		this.m_E_TextMyDonationText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_TextMyDonation");
     			}
     			return this.m_E_TextMyDonationText;
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
			this.m_E_DonationShowItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_Donation_1Button = null;
			this.m_E_Btn_Donation_1Image = null;
			this.m_E_Text_MyDonationText = null;
			this.m_EG_UIDonationPriceRectTransform = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_InputFieldNumberInputField = null;
			this.m_E_InputFieldNumberImage = null;
			this.m_E_Btn_Donation_2Button = null;
			this.m_E_Btn_Donation_2Image = null;
			this.m_E_BtnCloseButton = null;
			this.m_E_BtnCloseImage = null;
			this.m_E_TextMyDonationText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_DonationShowItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_Donation_1Button = null;
		private Image m_E_Btn_Donation_1Image = null;
		private Text m_E_Text_MyDonationText = null;
		private RectTransform m_EG_UIDonationPriceRectTransform = null;
		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private InputField m_E_InputFieldNumberInputField = null;
		private Image m_E_InputFieldNumberImage = null;
		private Button m_E_Btn_Donation_2Button = null;
		private Image m_E_Btn_Donation_2Image = null;
		private Button m_E_BtnCloseButton = null;
		private Image m_E_BtnCloseImage = null;
		private Text m_E_TextMyDonationText = null;
		public Transform uiTransform = null;
	}
}
