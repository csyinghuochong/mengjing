
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLoading))]
	[EnableMethod]
	public  class DlgLoadingViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_BackSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BackSetRectTransform == null )
     			{
		    		this.m_EG_BackSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_BackSet");
     			}
     			return this.m_EG_BackSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Back_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Back_1Image == null )
     			{
		    		this.m_E_Back_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BackSet/E_Back_1");
     			}
     			return this.m_E_Back_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_Img_LodingValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LodingValueImage == null )
     			{
		    		this.m_E_Img_LodingValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"GameObject/E_Img_LodingValue");
     			}
     			return this.m_E_Img_LodingValueImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageImage == null )
     			{
		    		this.m_E_ImageImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"GameObject/E_Image");
     			}
     			return this.m_E_ImageImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TextText == null )
     			{
		    		this.m_E_Lab_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"GameObject/E_Lab_Text");
     			}
     			return this.m_E_Lab_TextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_BackSetRectTransform = null;
			this.m_E_Back_1Image = null;
			this.m_E_Img_LodingValueImage = null;
			this.m_E_ImageImage = null;
			this.m_E_Lab_TextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_BackSetRectTransform = null;
		private UnityEngine.UI.Image m_E_Back_1Image = null;
		private UnityEngine.UI.Image m_E_Img_LodingValueImage = null;
		private UnityEngine.UI.Image m_E_ImageImage = null;
		private UnityEngine.UI.Text m_E_Lab_TextText = null;
		public Transform uiTransform = null;
	}
}
