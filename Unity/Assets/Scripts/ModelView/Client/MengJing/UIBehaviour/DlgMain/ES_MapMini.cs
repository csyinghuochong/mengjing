using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MapMini : Entity,IAwake<Transform>,IDestroy 
	{
		public int Lab_TimeIndex = 0;
		public GameObject MapCamera;
		public float ScaleRateX;
		public float ScaleRateY;
		public int SceneTypeEnum;
		public long MapMiniTimer;
		public List<GameObject> AllPointList = new();
		public Vector3 NoVector3 = new(-10000, -10000, 0);
		
		public Image E_MainCityShowImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainCityShowImage == null )
     			{
		    		this.m_E_MainCityShowImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_MainCityShow");
     			}
     			return this.m_E_MainCityShowImage;
     		}
     	}

		public RawImage E_RawImageRawImage
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
		    		this.m_E_RawImageRawImage = UIFindHelper.FindDeepChild<RawImage>(this.uiTransform.gameObject,"E_MainCityShow/ImageDi_1/E_RawImage");
     			}
     			return this.m_E_RawImageRawImage;
     		}
     	}

		public RectTransform EG_HeadListRectTransform
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
		    		this.m_EG_HeadListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_MainCityShow/ImageDi_1/EG_HeadList");
     			}
     			return this.m_EG_HeadListRectTransform;
     		}
     	}

		public RectTransform EG_HeadItemRectTransform
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
		    		this.m_EG_HeadItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_MainCityShow/ImageDi_1/EG_HeadList/EG_HeadItem");
     			}
     			return this.m_EG_HeadItemRectTransform;
     		}
     	}

		public Text E_MapNameText
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
		    		this.m_E_MapNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_MapName");
     			}
     			return this.m_E_MapNameText;
     		}
     	}

		public Text E_TianQiText
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
		    		this.m_E_TianQiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TianQi");
     			}
     			return this.m_E_TianQiText;
     		}
     	}

		public Text E_TimeText
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
		    		this.m_E_TimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Time");
     			}
     			return this.m_E_TimeText;
     		}
     	}

		public Button E_MiniMapButtonButton
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
		    		this.m_E_MiniMapButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_MiniMapButton");
     			}
     			return this.m_E_MiniMapButtonButton;
     		}
     	}

		public Image E_MiniMapButtonImage
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
		    		this.m_E_MiniMapButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_MiniMapButton");
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
			this.m_E_MainCityShowImage = null;
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

		private Image m_E_MainCityShowImage = null;
		private RawImage m_E_RawImageRawImage = null;
		private RectTransform m_EG_HeadListRectTransform = null;
		private RectTransform m_EG_HeadItemRectTransform = null;
		private Text m_E_MapNameText = null;
		private Text m_E_TianQiText = null;
		private Text m_E_TimeText = null;
		private Button m_E_MiniMapButtonButton = null;
		private Image m_E_MiniMapButtonImage = null;
		public Transform uiTransform = null;
	}
}
