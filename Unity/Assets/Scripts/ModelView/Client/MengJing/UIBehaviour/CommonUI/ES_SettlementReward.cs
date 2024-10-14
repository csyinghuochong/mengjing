
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SettlementReward : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public RewardItem RewardItem;
		public Action<int> ClickHandler;
		public int Index = -1;
		public bool IsSelect;
		
		public UnityEngine.UI.Image E_Image_bgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_bgImage == null )
     			{
		    		this.m_E_Image_bgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_bg");
     			}
     			return this.m_E_Image_bgImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_bgOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_bgOpenImage == null )
     			{
		    		this.m_E_Image_bgOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_bgOpen");
     			}
     			return this.m_E_Image_bgOpenImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UIItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIItemRectTransform == null )
     			{
		    		this.m_EG_UIItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UIItem");
     			}
     			return this.m_EG_UIItemRectTransform;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_UIItem/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_Image_bgImage = null;
			this.m_E_Image_bgOpenImage = null;
			this.m_EG_UIItemRectTransform = null;
			this.m_es_commonitem = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_Image_bgImage = null;
		private UnityEngine.UI.Image m_E_Image_bgOpenImage = null;
		private UnityEngine.RectTransform m_EG_UIItemRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		public Transform uiTransform = null;
	}
}
