using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgStore))]
	[EnableMethod]
	public  class DlgStoreViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_closeButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_closeButtonButton == null )
     			{
		    		this.m_E_closeButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonButton;
     		}
     	}

		public Image E_closeButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_closeButtonImage == null )
     			{
		    		this.m_E_closeButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonImage;
     		}
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
     			if( es==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public LoopVerticalScrollRect E_StoreItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_StoreItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_StoreItems");
     			}
     			return this.m_E_StoreItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_closeButtonButton = null;
			this.m_E_closeButtonImage = null;
			this.m_es_modelshow = null;
			this.m_E_StoreItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_closeButtonButton = null;
		private Image m_E_closeButtonImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private LoopVerticalScrollRect m_E_StoreItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
