
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetCangKuDefend : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public RolePetInfo RolePetInfo;
		public Action PetCangKuAction;
		public int Index;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetCangKuDefend BindTrans(Transform trans)
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
     				if( this.m_es_modelshow == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     			else
     			{
     				if( this.m_es_modelshow != null )
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

		public UnityEngine.UI.Text E_Text_NameText
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
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonQuHuiButton
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
     				if( this.m_E_ButtonQuHuiButton == null )
     				{
		    			this.m_E_ButtonQuHuiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonQuHui");
     				}
     				return this.m_E_ButtonQuHuiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonQuHui");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonQuHuiImage
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
     				if( this.m_E_ButtonQuHuiImage == null )
     				{
		    			this.m_E_ButtonQuHuiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonQuHui");
     				}
     				return this.m_E_ButtonQuHuiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonQuHui");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOpenButton
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
     				if( this.m_E_ButtonOpenButton == null )
     				{
		    			this.m_E_ButtonOpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonOpen");
     				}
     				return this.m_E_ButtonOpenButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonOpen");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOpenImage
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
     				if( this.m_E_ButtonOpenImage == null )
     				{
		    			this.m_E_ButtonOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonOpen");
     				}
     				return this.m_E_ButtonOpenImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonOpen");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_E_Text_NameText = null;
			this.m_E_ButtonQuHuiButton = null;
			this.m_E_ButtonQuHuiImage = null;
			this.m_E_ButtonOpenButton = null;
			this.m_E_ButtonOpenImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Button m_E_ButtonQuHuiButton = null;
		private UnityEngine.UI.Image m_E_ButtonQuHuiImage = null;
		private UnityEngine.UI.Button m_E_ButtonOpenButton = null;
		private UnityEngine.UI.Image m_E_ButtonOpenImage = null;
		public Transform uiTransform = null;
	}
}
