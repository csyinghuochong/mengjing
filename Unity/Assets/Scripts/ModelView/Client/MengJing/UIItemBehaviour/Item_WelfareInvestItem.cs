using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_WelfareInvestItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_WelfareInvestItem>
	{
		public int Day;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_WelfareInvestItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_DayTextText
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
     				if( this.m_E_DayTextText == null )
     				{
		    			this.m_E_DayTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_DayText");
     				}
     				return this.m_E_DayTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_DayText");
     			}
     		}
     	}

		public Text E_InvestTextText
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
     				if( this.m_E_InvestTextText == null )
     				{
		    			this.m_E_InvestTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_InvestText");
     				}
     				return this.m_E_InvestTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_InvestText");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( es ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( es !=null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			es = this.m_es_commonitem;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem = null;
		    				this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     		}
     	}

		public Button E_InvestBtnButton
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
     				if( this.m_E_InvestBtnButton == null )
     				{
		    			this.m_E_InvestBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_InvestBtn");
     				}
     				return this.m_E_InvestBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_InvestBtn");
     			}
     		}
     	}

		public Image E_InvestBtnImage
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
     				if( this.m_E_InvestBtnImage == null )
     				{
		    			this.m_E_InvestBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InvestBtn");
     				}
     				return this.m_E_InvestBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InvestBtn");
     			}
     		}
     	}

		public Image E_InvestedImgImage
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
     				if( this.m_E_InvestedImgImage == null )
     				{
		    			this.m_E_InvestedImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InvestedImg");
     				}
     				return this.m_E_InvestedImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InvestedImg");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_DayTextText = null;
			this.m_E_InvestTextText = null;
			this.m_es_commonitem = null;
			this.m_E_InvestBtnButton = null;
			this.m_E_InvestBtnImage = null;
			this.m_E_InvestedImgImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_DayTextText = null;
		private Text m_E_InvestTextText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_InvestBtnButton = null;
		private Image m_E_InvestBtnImage = null;
		private Image m_E_InvestedImgImage = null;
		public Transform uiTransform = null;
	}
}
