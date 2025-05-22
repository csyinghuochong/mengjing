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
		
		public UnityEngine.RectTransform EG_UIDonationPriceRectTransform
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
		    		this.m_EG_UIDonationPriceRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UIDonationPrice");
     			}
     			return this.m_EG_UIDonationPriceRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldNumberInputField
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
		    		this.m_E_InputFieldNumberInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_InputFieldNumber");
     			}
     			return this.m_E_InputFieldNumberInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldNumberImage
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
		    		this.m_E_InputFieldNumberImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_InputFieldNumber");
     			}
     			return this.m_E_InputFieldNumberImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_Donation_2Button
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
		    		this.m_E_Btn_Donation_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_Btn_Donation_2");
     			}
     			return this.m_E_Btn_Donation_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_Donation_2Image
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
		    		this.m_E_Btn_Donation_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_Btn_Donation_2");
     			}
     			return this.m_E_Btn_Donation_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_BtnCloseButton
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
		    		this.m_E_BtnCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_BtnClose");
     			}
     			return this.m_E_BtnCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_BtnCloseImage
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
		    		this.m_E_BtnCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_BtnClose");
     			}
     			return this.m_E_BtnCloseImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextMyDonationText
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
		    		this.m_E_TextMyDonationText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UIDonationPrice/E_TextMyDonation");
     			}
     			return this.m_E_TextMyDonationText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_DonationShowItemsLoopVerticalScrollRect
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
		    		this.m_E_DonationShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_DonationShowItems");
     			}
     			return this.m_E_DonationShowItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_Donation_1Button
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
		    		this.m_E_Btn_Donation_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Donation_1");
     			}
     			return this.m_E_Btn_Donation_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_Donation_1Image
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
		    		this.m_E_Btn_Donation_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Donation_1");
     			}
     			return this.m_E_Btn_Donation_1Image;
     		}
     	}

		public UnityEngine.UI.Text E_Text_MyDonationText
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
		    		this.m_E_Text_MyDonationText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_MyDonation");
     			}
     			return this.m_E_Text_MyDonationText;
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
			this.m_E_DonationShowItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_Donation_1Button = null;
			this.m_E_Btn_Donation_1Image = null;
			this.m_E_Text_MyDonationText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_UIDonationPriceRectTransform = null;
		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.InputField m_E_InputFieldNumberInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldNumberImage = null;
		private UnityEngine.UI.Button m_E_Btn_Donation_2Button = null;
		private UnityEngine.UI.Image m_E_Btn_Donation_2Image = null;
		private UnityEngine.UI.Button m_E_BtnCloseButton = null;
		private UnityEngine.UI.Image m_E_BtnCloseImage = null;
		private UnityEngine.UI.Text m_E_TextMyDonationText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_DonationShowItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_Donation_1Button = null;
		private UnityEngine.UI.Image m_E_Btn_Donation_1Image = null;
		private UnityEngine.UI.Text m_E_Text_MyDonationText = null;
		public Transform uiTransform = null;
	}
}
