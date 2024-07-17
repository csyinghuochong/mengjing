using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSeasonJingHeZhuru))]
	[EnableMethod]
	public  class DlgSeasonJingHeZhuruViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CloseBtn");
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
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnImage;
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

		public Text E_ItemNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNameTextText == null )
     			{
		    		this.m_E_ItemNameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ItemNameText");
     			}
     			return this.m_E_ItemNameTextText;
     		}
     	}

		public Text E_NowQualityTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NowQualityTextText == null )
     			{
		    		this.m_E_NowQualityTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NowQualityText");
     			}
     			return this.m_E_NowQualityTextText;
     		}
     	}

		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_AddQualityTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddQualityTextText == null )
     			{
		    		this.m_E_AddQualityTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_AddQualityText");
     			}
     			return this.m_E_AddQualityTextText;
     		}
     	}

		public Button E_ZhuRuBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhuRuBtnButton == null )
     			{
		    		this.m_E_ZhuRuBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ZhuRuBtn");
     			}
     			return this.m_E_ZhuRuBtnButton;
     		}
     	}

		public Image E_ZhuRuBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhuRuBtnImage == null )
     			{
		    		this.m_E_ZhuRuBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ZhuRuBtn");
     			}
     			return this.m_E_ZhuRuBtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseBtnButton = null;
			this.m_E_CloseBtnImage = null;
			this.m_es_commonitem = null;
			this.m_E_ItemNameTextText = null;
			this.m_E_NowQualityTextText = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_AddQualityTextText = null;
			this.m_E_ZhuRuBtnButton = null;
			this.m_E_ZhuRuBtnImage = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseBtnButton = null;
		private Image m_E_CloseBtnImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Text m_E_ItemNameTextText = null;
		private Text m_E_NowQualityTextText = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private Text m_E_AddQualityTextText = null;
		private Button m_E_ZhuRuBtnButton = null;
		private Image m_E_ZhuRuBtnImage = null;
		public Transform uiTransform = null;
	}
}
