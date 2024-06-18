
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ActivityTokenItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ActivityTokenItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
     			if (this.isCacheNode)
     			{
     				if( this.m_es_commonitem_1 == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_1");
		    			this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_1;
     			}
     			else
     			{
     				if( this.m_es_commonitem_1 != null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_1");
		    			ES_CommonItem es = this.m_es_commonitem_1;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem_1 = null;
		    				this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_1");
		    			this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_1;
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_es_commonitem_2 == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_2");
		    			this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_2;
     			}
     			else
     			{
     				if( this.m_es_commonitem_2 != null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_2");
		    			ES_CommonItem es = this.m_es_commonitem_2;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem_2 = null;
		    				this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_2");
		    			this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_2;
     			}
     		}
     	}

		public ES_CommonItem ES_CommonItem_3
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
     				if( this.m_es_commonitem_3 == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_3");
		    			this.m_es_commonitem_3 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_3;
     			}
     			else
     			{
     				if( this.m_es_commonitem_3 != null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_3");
		    			ES_CommonItem es = this.m_es_commonitem_3;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem_3 = null;
		    				this.m_es_commonitem_3 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_3");
		    			this.m_es_commonitem_3 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_3;
     			}
     		}
     	}

		public UnityEngine.UI.Image E_LingQuHint_1Image
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
     				if( this.m_E_LingQuHint_1Image == null )
     				{
		    			this.m_E_LingQuHint_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQuHint_1");
     				}
     				return this.m_E_LingQuHint_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQuHint_1");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_LingQuHint_2Image
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
     				if( this.m_E_LingQuHint_2Image == null )
     				{
		    			this.m_E_LingQuHint_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQuHint_2");
     				}
     				return this.m_E_LingQuHint_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQuHint_2");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_LingQuHint_3Image
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
     				if( this.m_E_LingQuHint_3Image == null )
     				{
		    			this.m_E_LingQuHint_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQuHint_3");
     				}
     				return this.m_E_LingQuHint_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LingQuHint_3");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Btn_LingQu_1Button
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
     				if( this.m_E_Btn_LingQu_1Button == null )
     				{
		    			this.m_E_Btn_LingQu_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_LingQu_1");
     				}
     				return this.m_E_Btn_LingQu_1Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_LingQu_1");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Btn_LingQu_1Image
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
     				if( this.m_E_Btn_LingQu_1Image == null )
     				{
		    			this.m_E_Btn_LingQu_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_LingQu_1");
     				}
     				return this.m_E_Btn_LingQu_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_LingQu_1");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Btn_LingQu_2Button
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
     				if( this.m_E_Btn_LingQu_2Button == null )
     				{
		    			this.m_E_Btn_LingQu_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_LingQu_2");
     				}
     				return this.m_E_Btn_LingQu_2Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_LingQu_2");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Btn_LingQu_2Image
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
     				if( this.m_E_Btn_LingQu_2Image == null )
     				{
		    			this.m_E_Btn_LingQu_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_LingQu_2");
     				}
     				return this.m_E_Btn_LingQu_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_LingQu_2");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Btn_LingQu_3Button
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
     				if( this.m_E_Btn_LingQu_3Button == null )
     				{
		    			this.m_E_Btn_LingQu_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_LingQu_3");
     				}
     				return this.m_E_Btn_LingQu_3Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_LingQu_3");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Btn_LingQu_3Image
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
     				if( this.m_E_Btn_LingQu_3Image == null )
     				{
		    			this.m_E_Btn_LingQu_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_LingQu_3");
     				}
     				return this.m_E_Btn_LingQu_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_LingQu_3");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextNameText
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
     				if( this.m_E_TextNameText == null )
     				{
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_es_commonitem_3 = null;
			this.m_E_LingQuHint_1Image = null;
			this.m_E_LingQuHint_2Image = null;
			this.m_E_LingQuHint_3Image = null;
			this.m_E_Btn_LingQu_1Button = null;
			this.m_E_Btn_LingQu_1Image = null;
			this.m_E_Btn_LingQu_2Button = null;
			this.m_E_Btn_LingQu_2Image = null;
			this.m_E_Btn_LingQu_3Button = null;
			this.m_E_Btn_LingQu_3Image = null;
			this.m_E_TextNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_3 = null;
		private UnityEngine.UI.Image m_E_LingQuHint_1Image = null;
		private UnityEngine.UI.Image m_E_LingQuHint_2Image = null;
		private UnityEngine.UI.Image m_E_LingQuHint_3Image = null;
		private UnityEngine.UI.Button m_E_Btn_LingQu_1Button = null;
		private UnityEngine.UI.Image m_E_Btn_LingQu_1Image = null;
		private UnityEngine.UI.Button m_E_Btn_LingQu_2Button = null;
		private UnityEngine.UI.Image m_E_Btn_LingQu_2Image = null;
		private UnityEngine.UI.Button m_E_Btn_LingQu_3Button = null;
		private UnityEngine.UI.Image m_E_Btn_LingQu_3Image = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		public Transform uiTransform = null;
	}
}
