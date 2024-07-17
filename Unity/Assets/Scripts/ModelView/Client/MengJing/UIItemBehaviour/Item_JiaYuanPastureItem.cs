using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanPastureItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanPastureItem>
	{
		public MysteryItemInfo MysteryItemInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanPastureItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ModelShow es = this.m_es_modelshow;
     			if (this.isCacheNode)
     			{
     				if( es == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     			else
     			{
     				if( es != null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			es = this.m_es_modelshow;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_modelshow = null;
		    				this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     		}
     	}

		public Button E_ButtonBuyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ButtonBuyButton == null )
     				{
		    			this.m_E_ButtonBuyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonBuy");
     				}
     				return this.m_E_ButtonBuyButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     		}
     	}

		public Image E_ButtonBuyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ButtonBuyImage == null )
     				{
		    			this.m_E_ButtonBuyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonBuy");
     				}
     				return this.m_E_ButtonBuyImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     		}
     	}

		public Text E_Text_valueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_valueText == null )
     				{
		    			this.m_E_Text_valueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value");
     				}
     				return this.m_E_Text_valueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value");
     			}
     		}
     	}

		public Text E_Text_value2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_value2Text == null )
     				{
		    			this.m_E_Text_value2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value2");
     				}
     				return this.m_E_Text_value2Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value2");
     			}
     		}
     	}

		public Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public Text E_Text_RenKouText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_RenKouText == null )
     				{
		    			this.m_E_Text_RenKouText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_RenKou");
     				}
     				return this.m_E_Text_RenKouText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_RenKou");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.m_E_Text_valueText = null;
			this.m_E_Text_value2Text = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_RenKouText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Button m_E_ButtonBuyButton = null;
		private Image m_E_ButtonBuyImage = null;
		private Text m_E_Text_valueText = null;
		private Text m_E_Text_value2Text = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_RenKouText = null;
		public Transform uiTransform = null;
	}
}
