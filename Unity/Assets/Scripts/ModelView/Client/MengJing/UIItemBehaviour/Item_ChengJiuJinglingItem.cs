
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuJinglingItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public int JingLingId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChengJiuJinglingItem BindTrans(Transform trans)
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
     				if( this.m_es_modelshow ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     			else
     			{
     				if(! this.m_es_modelshow ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			ES_ModelShow es = this.m_es_modelshow;
     					if( es.EG_RootRectTransform != subTrans )
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

		public UnityEngine.UI.Button E_ButtonActiviteButton
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
     				if( this.m_E_ButtonActiviteButton == null )
     				{
		    			this.m_E_ButtonActiviteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonActivite");
     				}
     				return this.m_E_ButtonActiviteButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonActivite");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonActiviteImage
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
     				if( this.m_E_ButtonActiviteImage == null )
     				{
		    			this.m_E_ButtonActiviteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonActivite");
     				}
     				return this.m_E_ButtonActiviteImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonActivite");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonShouHuiButton
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
     				if( this.m_E_ButtonShouHuiButton == null )
     				{
		    			this.m_E_ButtonShouHuiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonShouHui");
     				}
     				return this.m_E_ButtonShouHuiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonShouHui");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonShouHuiImage
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
     				if( this.m_E_ButtonShouHuiImage == null )
     				{
		    			this.m_E_ButtonShouHuiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonShouHui");
     				}
     				return this.m_E_ButtonShouHuiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonShouHui");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_UseSetRectTransform
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
     				if( this.m_EG_UseSetRectTransform == null )
     				{
		    			this.m_EG_UseSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UseSet");
     				}
     				return this.m_EG_UseSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UseSet");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ChengHaoNameText
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
     				if( this.m_E_ChengHaoNameText == null )
     				{
		    			this.m_E_ChengHaoNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ChengHaoName");
     				}
     				return this.m_E_ChengHaoNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ChengHaoName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_valueText
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
		    			this.m_E_Text_valueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_value");
     				}
     				return this.m_E_Text_valueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_value");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_JingLingDesText
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
     				if( this.m_E_JingLingDesText == null )
     				{
		    			this.m_E_JingLingDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_JingLingDes");
     				}
     				return this.m_E_JingLingDesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_JingLingDes");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ObjGetTextText
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
     				if( this.m_E_ObjGetTextText == null )
     				{
		    			this.m_E_ObjGetTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ObjGetText");
     				}
     				return this.m_E_ObjGetTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ObjGetText");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_E_ButtonActiviteButton = null;
			this.m_E_ButtonActiviteImage = null;
			this.m_E_ButtonShouHuiButton = null;
			this.m_E_ButtonShouHuiImage = null;
			this.m_EG_UseSetRectTransform = null;
			this.m_E_ChengHaoNameText = null;
			this.m_E_Text_valueText = null;
			this.m_E_JingLingDesText = null;
			this.m_E_ObjGetTextText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Button m_E_ButtonActiviteButton = null;
		private UnityEngine.UI.Image m_E_ButtonActiviteImage = null;
		private UnityEngine.UI.Button m_E_ButtonShouHuiButton = null;
		private UnityEngine.UI.Image m_E_ButtonShouHuiImage = null;
		private UnityEngine.RectTransform m_EG_UseSetRectTransform = null;
		private UnityEngine.UI.Text m_E_ChengHaoNameText = null;
		private UnityEngine.UI.Text m_E_Text_valueText = null;
		private UnityEngine.UI.Text m_E_JingLingDesText = null;
		private UnityEngine.UI.Text m_E_ObjGetTextText = null;
		public Transform uiTransform = null;
	}
}
