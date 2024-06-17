
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ZuoQiShowItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public ZuoQiShowConfig ZuoQiConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ZuoQiShowItem BindTrans(Transform trans)
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
     			if (this.isCacheNode)
     			{
     				if( this.m_es_modelshow .Equals(null) )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     			else
     			{
     				if( !this.m_es_modelshow .Equals(null) )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			ES_ModelShow es = this.m_es_modelshow;
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

		public UnityEngine.RectTransform EG_StarListRectTransform
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
     				if( this.m_EG_StarListRectTransform == null )
     				{
		    			this.m_EG_StarListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_StarList");
     				}
     				return this.m_EG_StarListRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_StarList");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonFightButton
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
     				if( this.m_E_ButtonFightButton == null )
     				{
		    			this.m_E_ButtonFightButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonFight");
     				}
     				return this.m_E_ButtonFightButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonFight");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonFightImage
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
     				if( this.m_E_ButtonFightImage == null )
     				{
		    			this.m_E_ButtonFightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonFight");
     				}
     				return this.m_E_ButtonFightImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonFight");
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

		public UnityEngine.UI.Text E_Text_Attribute_1Text
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
     				if( this.m_E_Text_Attribute_1Text == null )
     				{
		    			this.m_E_Text_Attribute_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Attribute_1");
     				}
     				return this.m_E_Text_Attribute_1Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Attribute_1");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_LaiYuanText
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
     				if( this.m_E_Lab_LaiYuanText == null )
     				{
		    			this.m_E_Lab_LaiYuanText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_LaiYuan");
     				}
     				return this.m_E_Lab_LaiYuanText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_LaiYuan");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_LabDesText
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
     				if( this.m_E_LabDesText == null )
     				{
		    			this.m_E_LabDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LabDes");
     				}
     				return this.m_E_LabDesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LabDes");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_LabProDesText
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
     				if( this.m_E_LabProDesText == null )
     				{
		    			this.m_E_LabProDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LabProDes");
     				}
     				return this.m_E_LabProDesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LabProDes");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_EG_StarListRectTransform = null;
			this.m_E_ButtonFightButton = null;
			this.m_E_ButtonFightImage = null;
			this.m_E_TextNameText = null;
			this.m_E_Text_Attribute_1Text = null;
			this.m_E_Lab_LaiYuanText = null;
			this.m_E_LabDesText = null;
			this.m_E_LabProDesText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.RectTransform m_EG_StarListRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonFightButton = null;
		private UnityEngine.UI.Image m_E_ButtonFightImage = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		private UnityEngine.UI.Text m_E_Text_Attribute_1Text = null;
		private UnityEngine.UI.Text m_E_Lab_LaiYuanText = null;
		private UnityEngine.UI.Text m_E_LabDesText = null;
		private UnityEngine.UI.Text m_E_LabProDesText = null;
		public Transform uiTransform = null;
	}
}
