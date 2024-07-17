using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMaiAuction))]
	[EnableMethod]
	public  class DlgPaiMaiAuctionViewComponent : Entity,IAwake,IDestroy 
	{
		public InputField E_Lab_RmbNumInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_RmbNumInputField == null )
     			{
		    		this.m_E_Lab_RmbNumInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumInputField;
     		}
     	}

		public Image E_Lab_RmbNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_RmbNumImage == null )
     			{
		    		this.m_E_Lab_RmbNumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumImage;
     		}
     	}

		public Button E_Btn_BuyNum_jia1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jia1Button == null )
     			{
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Button;
     		}
     	}

		public Image E_Btn_BuyNum_jia1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jia1Image == null )
     			{
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Image;
     		}
     	}

		public Button E_Btn_BuyNum_jian1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jian1Button == null )
     			{
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Button;
     		}
     	}

		public Image E_Btn_BuyNum_jian1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jian1Image == null )
     			{
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Image;
     		}
     	}

		public Button E_Btn_AuctionButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AuctionButton == null )
     			{
		    		this.m_E_Btn_AuctionButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionButton;
     		}
     	}

		public Image E_Btn_AuctionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AuctionImage == null )
     			{
		    		this.m_E_Btn_AuctionImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionImage;
     		}
     	}

		public Button E_Btn_CanYuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CanYuButton == null )
     			{
		    		this.m_E_Btn_CanYuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_CanYu");
     			}
     			return this.m_E_Btn_CanYuButton;
     		}
     	}

		public Image E_Btn_CanYuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CanYuImage == null )
     			{
		    		this.m_E_Btn_CanYuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_CanYu");
     			}
     			return this.m_E_Btn_CanYuImage;
     		}
     	}

		public Button E_Btn_RecordButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RecordButton == null )
     			{
		    		this.m_E_Btn_RecordButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Record");
     			}
     			return this.m_E_Btn_RecordButton;
     		}
     	}

		public Image E_Btn_RecordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RecordImage == null )
     			{
		    		this.m_E_Btn_RecordImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Record");
     			}
     			return this.m_E_Btn_RecordImage;
     		}
     	}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Text E_Text_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_2Text == null )
     			{
		    		this.m_E_Text_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_2");
     			}
     			return this.m_E_Text_2Text;
     		}
     	}

		public Text E_TextPriceText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPriceText == null )
     			{
		    		this.m_E_TextPriceText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextPrice");
     			}
     			return this.m_E_TextPriceText;
     		}
     	}

		public Text E_TextAuctionPlayerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextAuctionPlayerText == null )
     			{
		    		this.m_E_TextAuctionPlayerText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextAuctionPlayer");
     			}
     			return this.m_E_TextAuctionPlayerText;
     		}
     	}

		public Text E_TextBaoZhenJinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextBaoZhenJinText == null )
     			{
		    		this.m_E_TextBaoZhenJinText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextBaoZhenJin");
     			}
     			return this.m_E_TextBaoZhenJinText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Lab_RmbNumInputField = null;
			this.m_E_Lab_RmbNumImage = null;
			this.m_E_Btn_BuyNum_jia1Button = null;
			this.m_E_Btn_BuyNum_jia1Image = null;
			this.m_E_Btn_BuyNum_jian1Button = null;
			this.m_E_Btn_BuyNum_jian1Image = null;
			this.m_E_Btn_AuctionButton = null;
			this.m_E_Btn_AuctionImage = null;
			this.m_E_Btn_CanYuButton = null;
			this.m_E_Btn_CanYuImage = null;
			this.m_E_Btn_RecordButton = null;
			this.m_E_Btn_RecordImage = null;
			this.m_es_commonitem = null;
			this.m_E_Text_2Text = null;
			this.m_E_TextPriceText = null;
			this.m_E_TextAuctionPlayerText = null;
			this.m_E_TextBaoZhenJinText = null;
			this.uiTransform = null;
		}

		private InputField m_E_Lab_RmbNumInputField = null;
		private Image m_E_Lab_RmbNumImage = null;
		private Button m_E_Btn_BuyNum_jia1Button = null;
		private Image m_E_Btn_BuyNum_jia1Image = null;
		private Button m_E_Btn_BuyNum_jian1Button = null;
		private Image m_E_Btn_BuyNum_jian1Image = null;
		private Button m_E_Btn_AuctionButton = null;
		private Image m_E_Btn_AuctionImage = null;
		private Button m_E_Btn_CanYuButton = null;
		private Image m_E_Btn_CanYuImage = null;
		private Button m_E_Btn_RecordButton = null;
		private Image m_E_Btn_RecordImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Text m_E_Text_2Text = null;
		private Text m_E_TextPriceText = null;
		private Text m_E_TextAuctionPlayerText = null;
		private Text m_E_TextBaoZhenJinText = null;
		public Transform uiTransform = null;
	}
}
