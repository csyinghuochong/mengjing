
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MapMini : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int Lab_TimeIndex = 0;
		public GameObject MapCamera;
		public float ScaleRateX;
		public float ScaleRateY;
		public int SceneTypeEnum;
		public long MapMiniTimer;
		public Dictionary<long, GameObject> AllPointList = new();
		public List<GameObject> CachePointList = new();	
		public Vector3 NoVector3 = new(-10000, -10000, 0);
		
		public UnityEngine.RectTransform EG_MainCityShowRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainCityShowRectTransform == null )
     			{
		    		this.m_EG_MainCityShowRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MainCityShow");
     			}
     			return this.m_EG_MainCityShowRectTransform;
     		}
     	}

		public UnityEngine.UI.RawImage E_RawImageRawImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RawImageRawImage == null )
     			{
		    		this.m_E_RawImageRawImage = UIFindHelper.FindDeepChild<UnityEngine.UI.RawImage>(this.uiTransform.gameObject,"EG_MainCityShow/ImageDi_1/E_RawImage");
     			}
     			return this.m_E_RawImageRawImage;
     		}
     	}

		public UnityEngine.RectTransform EG_HeadListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HeadListRectTransform == null )
     			{
		    		this.m_EG_HeadListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MainCityShow/ImageDi_1/EG_HeadList");
     			}
     			return this.m_EG_HeadListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_HeadItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HeadItemRectTransform == null )
     			{
		    		this.m_EG_HeadItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MainCityShow/ImageDi_1/EG_HeadList/EG_HeadItem");
     			}
     			return this.m_EG_HeadItemRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_MapNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapNameText == null )
     			{
		    		this.m_E_MapNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_MapName");
     			}
     			return this.m_E_MapNameText;
     		}
     	}

		public UnityEngine.UI.Text E_TianQiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TianQiText == null )
     			{
		    		this.m_E_TianQiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TianQi");
     			}
     			return this.m_E_TianQiText;
     		}
     	}

		public UnityEngine.UI.Text E_TimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimeText == null )
     			{
		    		this.m_E_TimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Time");
     			}
     			return this.m_E_TimeText;
     		}
     	}

		public UnityEngine.UI.Button E_MiniMapButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MiniMapButtonButton == null )
     			{
		    		this.m_E_MiniMapButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MiniMapButton");
     			}
     			return this.m_E_MiniMapButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_MiniMapButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MiniMapButtonImage == null )
     			{
		    		this.m_E_MiniMapButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MiniMapButton");
     			}
     			return this.m_E_MiniMapButtonImage;
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
			this.m_EG_MainCityShowRectTransform = null;
			this.m_E_RawImageRawImage = null;
			this.m_EG_HeadListRectTransform = null;
			this.m_EG_HeadItemRectTransform = null;
			this.m_E_MapNameText = null;
			this.m_E_TianQiText = null;
			this.m_E_TimeText = null;
			this.m_E_MiniMapButtonButton = null;
			this.m_E_MiniMapButtonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_MainCityShowRectTransform = null;
		private UnityEngine.UI.RawImage m_E_RawImageRawImage = null;
		private UnityEngine.RectTransform m_EG_HeadListRectTransform = null;
		private UnityEngine.RectTransform m_EG_HeadItemRectTransform = null;
		private UnityEngine.UI.Text m_E_MapNameText = null;
		private UnityEngine.UI.Text m_E_TianQiText = null;
		private UnityEngine.UI.Text m_E_TimeText = null;
		private UnityEngine.UI.Button m_E_MiniMapButtonButton = null;
		private UnityEngine.UI.Image m_E_MiniMapButtonImage = null;
		public Transform uiTransform = null;
	}
}
