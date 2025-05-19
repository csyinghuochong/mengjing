
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgAppraisalSelect))]
	[EnableMethod]
	public  class DlgAppraisalSelectViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CloseButton
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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_JianDingSetRectTransform
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
		    		this.m_EG_JianDingSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_JianDingSet");
     			}
     			return this.m_EG_JianDingSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_JianDingQualityText
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
		    		this.m_E_JianDingQualityText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_JianDingSet/E_JianDingQuality");
     			}
     			return this.m_E_JianDingQualityText;
     		}
     	}

		public UnityEngine.UI.Text E_JianDingShowText
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
		    		this.m_E_JianDingShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_JianDingSet/E_JianDingShow");
     			}
     			return this.m_E_JianDingShowText;
     		}
     	}

		public UnityEngine.UI.Text E_JianDingShowProText
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
		    		this.m_E_JianDingShowProText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_JianDingSet/E_JianDingShowPro");
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem_1");
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public UnityEngine.UI.Image E_CommonItemsImage
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
		    		this.m_E_CommonItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_CommonItems");
     			}
     			return this.m_E_CommonItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
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
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_CoinButton
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
		    		this.m_E_CoinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Coin");
     			}
     			return this.m_E_CoinButton;
     		}
     	}

		public UnityEngine.UI.Image E_CoinImage
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
		    		this.m_E_CoinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Coin");
     			}
     			return this.m_E_CoinImage;
     		}
     	}

		public UnityEngine.UI.Button E_ItemButton
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
		    		this.m_E_ItemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Item");
     			}
     			return this.m_E_ItemButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemImage
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
		    		this.m_E_ItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Item");
     			}
     			return this.m_E_ItemImage;
     		}
     	}

		public UnityEngine.UI.Text E_EquipLevelText
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
		    		this.m_E_EquipLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_EquipLevel");
     			}
     			return this.m_E_EquipLevelText;
     		}
     	}

		public UnityEngine.UI.Text E_Tip_1Text
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
		    		this.m_E_Tip_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Tip_1");
     			}
     			return this.m_E_Tip_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_CoinNumText
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
		    		this.m_E_CoinNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_CoinNum");
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

		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.RectTransform m_EG_JianDingSetRectTransform = null;
		private UnityEngine.UI.Text m_E_JianDingQualityText = null;
		private UnityEngine.UI.Text m_E_JianDingShowText = null;
		private UnityEngine.UI.Text m_E_JianDingShowProText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private UnityEngine.UI.Image m_E_CommonItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_CoinButton = null;
		private UnityEngine.UI.Image m_E_CoinImage = null;
		private UnityEngine.UI.Button m_E_ItemButton = null;
		private UnityEngine.UI.Image m_E_ItemImage = null;
		private UnityEngine.UI.Text m_E_EquipLevelText = null;
		private UnityEngine.UI.Text m_E_Tip_1Text = null;
		private UnityEngine.UI.Text m_E_CoinNumText = null;
		public Transform uiTransform = null;
	}
}
