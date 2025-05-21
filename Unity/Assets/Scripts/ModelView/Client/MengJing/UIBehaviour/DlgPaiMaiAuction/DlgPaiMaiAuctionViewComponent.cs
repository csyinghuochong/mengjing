
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMaiAuction))]
	[EnableMethod]
	public  class DlgPaiMaiAuctionViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.InputField E_Lab_RmbNumInputField
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
		    		this.m_E_Lab_RmbNumInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Right/E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumInputField;
     		}
     	}

		public UnityEngine.UI.Image E_Lab_RmbNumImage
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
		    		this.m_E_Lab_RmbNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyNum_jia1Button
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
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyNum_jia1Image
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
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyNum_jian1Button
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
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyNum_jian1Image
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
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AuctionButton
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
		    		this.m_E_Btn_AuctionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AuctionImage
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
		    		this.m_E_Btn_AuctionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CanYuButton
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
		    		this.m_E_Btn_CanYuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_CanYu");
     			}
     			return this.m_E_Btn_CanYuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CanYuImage
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
		    		this.m_E_Btn_CanYuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_CanYu");
     			}
     			return this.m_E_Btn_CanYuImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RecordButton
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
		    		this.m_E_Btn_RecordButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Record");
     			}
     			return this.m_E_Btn_RecordButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RecordImage
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
		    		this.m_E_Btn_RecordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Record");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Text E_Text_2Text
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
		    		this.m_E_Text_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_2");
     			}
     			return this.m_E_Text_2Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextPriceText
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
		    		this.m_E_TextPriceText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextPrice");
     			}
     			return this.m_E_TextPriceText;
     		}
     	}

		public UnityEngine.UI.Text E_TextAuctionPlayerText
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
		    		this.m_E_TextAuctionPlayerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextAuctionPlayer");
     			}
     			return this.m_E_TextAuctionPlayerText;
     		}
     	}

		public UnityEngine.UI.Text E_TextBaoZhenJinText
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
		    		this.m_E_TextBaoZhenJinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextBaoZhenJin");
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

		private UnityEngine.UI.InputField m_E_Lab_RmbNumInputField = null;
		private UnityEngine.UI.Image m_E_Lab_RmbNumImage = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jia1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jia1Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jian1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jian1Image = null;
		private UnityEngine.UI.Button m_E_Btn_AuctionButton = null;
		private UnityEngine.UI.Image m_E_Btn_AuctionImage = null;
		private UnityEngine.UI.Button m_E_Btn_CanYuButton = null;
		private UnityEngine.UI.Image m_E_Btn_CanYuImage = null;
		private UnityEngine.UI.Button m_E_Btn_RecordButton = null;
		private UnityEngine.UI.Image m_E_Btn_RecordImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Text m_E_Text_2Text = null;
		private UnityEngine.UI.Text m_E_TextPriceText = null;
		private UnityEngine.UI.Text m_E_TextAuctionPlayerText = null;
		private UnityEngine.UI.Text m_E_TextBaoZhenJinText = null;
		public Transform uiTransform = null;
	}
}
