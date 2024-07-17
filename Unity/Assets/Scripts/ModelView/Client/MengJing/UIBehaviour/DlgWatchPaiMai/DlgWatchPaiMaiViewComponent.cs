using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWatchPaiMai))]
	[EnableMethod]
	public  class DlgWatchPaiMaiViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageBgButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBgButton == null )
     			{
		    		this.m_E_ImageBgButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgButton;
     		}
     	}

		public Image E_ImageBgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBgImage == null )
     			{
		    		this.m_E_ImageBgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgImage;
     		}
     	}

		public Image E_ImageDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageDiImage == null )
     			{
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public RectTransform EG_PositionSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PositionSetRectTransform == null )
     			{
		    		this.m_EG_PositionSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PositionSet");
     			}
     			return this.m_EG_PositionSetRectTransform;
     		}
     	}

		public Button E_FastSearchBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FastSearchBtnButton == null )
     			{
		    		this.m_E_FastSearchBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_FastSearchBtn");
     			}
     			return this.m_E_FastSearchBtnButton;
     		}
     	}

		public Image E_FastSearchBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FastSearchBtnImage == null )
     			{
		    		this.m_E_FastSearchBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_FastSearchBtn");
     			}
     			return this.m_E_FastSearchBtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageBgButton = null;
			this.m_E_ImageBgImage = null;
			this.m_E_ImageDiImage = null;
			this.m_EG_PositionSetRectTransform = null;
			this.m_E_FastSearchBtnButton = null;
			this.m_E_FastSearchBtnImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageBgButton = null;
		private Image m_E_ImageBgImage = null;
		private Image m_E_ImageDiImage = null;
		private RectTransform m_EG_PositionSetRectTransform = null;
		private Button m_E_FastSearchBtnButton = null;
		private Image m_E_FastSearchBtnImage = null;
		public Transform uiTransform = null;
	}
}
