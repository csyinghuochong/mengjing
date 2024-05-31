
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgWatchPaiMai))]
	[EnableMethod]
	public  class DlgWatchPaiMaiViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageBgButton
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
		    		this.m_E_ImageBgButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageBgImage
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
		    		this.m_E_ImageBgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageDiImage
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
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PositionSetRectTransform
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
		    		this.m_EG_PositionSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PositionSet");
     			}
     			return this.m_EG_PositionSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_FastSearchBtnButton
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
		    		this.m_E_FastSearchBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_FastSearchBtn");
     			}
     			return this.m_E_FastSearchBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_FastSearchBtnImage
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
		    		this.m_E_FastSearchBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_FastSearchBtn");
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

		private UnityEngine.UI.Button m_E_ImageBgButton = null;
		private UnityEngine.UI.Image m_E_ImageBgImage = null;
		private UnityEngine.UI.Image m_E_ImageDiImage = null;
		private UnityEngine.RectTransform m_EG_PositionSetRectTransform = null;
		private UnityEngine.UI.Button m_E_FastSearchBtnButton = null;
		private UnityEngine.UI.Image m_E_FastSearchBtnImage = null;
		public Transform uiTransform = null;
	}
}
