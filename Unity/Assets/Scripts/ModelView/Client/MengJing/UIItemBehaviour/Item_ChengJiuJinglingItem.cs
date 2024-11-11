
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuJinglingItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ChengJiuJinglingItem>
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

		public UnityEngine.UI.Text E_ActivatedText
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
     				if( this.m_E_ActivatedText == null )
     				{
		    			this.m_E_ActivatedText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Activated");
     				}
     				return this.m_E_ActivatedText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Activated");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_NameText
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
     				if( this.m_E_NameText == null )
     				{
		    			this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Name");
     				}
     				return this.m_E_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Name");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_E_ActivatedText = null;
			this.m_E_NameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_ActivatedText = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		public Transform uiTransform = null;
	}
}
