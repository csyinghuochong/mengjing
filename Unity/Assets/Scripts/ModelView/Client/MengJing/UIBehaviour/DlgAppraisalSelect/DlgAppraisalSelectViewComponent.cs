using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgAppraisalSelect))]
	[EnableMethod]
	public  class DlgAppraisalSelectViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public RectTransform EG_JianDingSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_JianDingSetRectTransform == null )
     			{
		    		this.m_EG_JianDingSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_JianDingSet");
     			}
     			return this.m_EG_JianDingSetRectTransform;
     		}
     	}

		public Text E_JianDingQualityText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JianDingQualityText == null )
     			{
		    		this.m_E_JianDingQualityText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_JianDingSet/E_JianDingQuality");
     			}
     			return this.m_E_JianDingQualityText;
     		}
     	}

		public Text E_JianDingShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JianDingShowText == null )
     			{
		    		this.m_E_JianDingShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_JianDingSet/E_JianDingShow");
     			}
     			return this.m_E_JianDingShowText;
     		}
     	}

		public Text E_JianDingShowProText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JianDingShowProText == null )
     			{
		    		this.m_E_JianDingShowProText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_JianDingSet/E_JianDingShowPro");
     			}
     			return this.m_E_JianDingShowProText;
     		}
     	}

		public ES_CommonItem ES_CommonItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CommonItem es = this.m_es_commonitem_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_1");
		    	   this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_1;
     		}
     	}

		public ES_CommonItem ES_CommonItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CommonItem es = this.m_es_commonitem_2;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public Image E_CommonItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonItemsImage == null )
     			{
		    		this.m_E_CommonItemsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CommonItems");
     			}
     			return this.m_E_CommonItemsImage;
     		}
     	}

		public LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_CoinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CoinButton == null )
     			{
		    		this.m_E_CoinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Coin");
     			}
     			return this.m_E_CoinButton;
     		}
     	}

		public Image E_CoinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CoinImage == null )
     			{
		    		this.m_E_CoinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Coin");
     			}
     			return this.m_E_CoinImage;
     		}
     	}

		public Button E_ItemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemButton == null )
     			{
		    		this.m_E_ItemButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Item");
     			}
     			return this.m_E_ItemButton;
     		}
     	}

		public Image E_ItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemImage == null )
     			{
		    		this.m_E_ItemImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Item");
     			}
     			return this.m_E_ItemImage;
     		}
     	}

		public Text E_EquipLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipLevelText == null )
     			{
		    		this.m_E_EquipLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_EquipLevel");
     			}
     			return this.m_E_EquipLevelText;
     		}
     	}

		public Text E_Tip_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Tip_1Text == null )
     			{
		    		this.m_E_Tip_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Tip_1");
     			}
     			return this.m_E_Tip_1Text;
     		}
     	}

		public Text E_CoinNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CoinNumText == null )
     			{
		    		this.m_E_CoinNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_CoinNum");
     			}
     			return this.m_E_CoinNumText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_EG_JianDingSetRectTransform = null;
			this.m_E_JianDingQualityText = null;
			this.m_E_JianDingShowText = null;
			this.m_E_JianDingShowProText = null;
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_E_CommonItemsImage = null;
			this.m_E_CommonItemsLoopVerticalScrollRect = null;
			this.m_E_CoinButton = null;
			this.m_E_CoinImage = null;
			this.m_E_ItemButton = null;
			this.m_E_ItemImage = null;
			this.m_E_EquipLevelText = null;
			this.m_E_Tip_1Text = null;
			this.m_E_CoinNumText = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseButton = null;
		private Image m_E_CloseImage = null;
		private RectTransform m_EG_JianDingSetRectTransform = null;
		private Text m_E_JianDingQualityText = null;
		private Text m_E_JianDingShowText = null;
		private Text m_E_JianDingShowProText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private Image m_E_CommonItemsImage = null;
		private LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private Button m_E_CoinButton = null;
		private Image m_E_CoinImage = null;
		private Button m_E_ItemButton = null;
		private Image m_E_ItemImage = null;
		private Text m_E_EquipLevelText = null;
		private Text m_E_Tip_1Text = null;
		private Text m_E_CoinNumText = null;
		public Transform uiTransform = null;
	}
}
