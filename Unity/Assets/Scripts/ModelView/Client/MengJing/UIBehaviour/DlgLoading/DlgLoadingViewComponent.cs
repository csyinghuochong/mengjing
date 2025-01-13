using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgLoading))]
	[EnableMethod]
	public  class DlgLoadingViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_BackSetRectTransform
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
		    		this.m_EG_BackSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_BackSet");
     			}
     			return this.m_EG_BackSetRectTransform;
     		}
     	}

		public Image E_Back_1Image
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
		    		this.m_E_Back_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_BackSet/E_Back_1");
     			}
     			return this.m_E_Back_1Image;
     		}
     	}

		public Image E_Img_LodingValueImage
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
		    		this.m_E_Img_LodingValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"GameObject/E_Img_LodingValue");
     			}
     			return this.m_E_Img_LodingValueImage;
     		}
     	}

		public Image E_ImageImage
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
		    		this.m_E_ImageImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"GameObject/E_Image");
     			}
     			return this.m_E_ImageImage;
     		}
     	}

		public Text E_Lab_TextText
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
		    		this.m_E_Lab_TextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"GameObject/E_Lab_Text");
     			}
     			return this.m_E_Lab_TextText;
     		}
     	}

		public Transform E_ImageEffect
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_e_E_ImageEffect == null )
				{
					this.m_e_E_ImageEffect = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"GameObject/E_ImageEffect");
				}
				return this.m_e_E_ImageEffect;
			}
		}

		public void DestroyWidget()
		{
			this.m_EG_BackSetRectTransform = null;
			this.m_E_Back_1Image = null;
			this.m_E_Img_LodingValueImage = null;
			this.m_E_ImageImage = null;
			this.m_E_Lab_TextText = null;
			this.m_e_E_ImageEffect = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_BackSetRectTransform = null;
		private Image m_E_Back_1Image = null;
		private Image m_E_Img_LodingValueImage = null;
		private Image m_E_ImageImage = null;
		private Transform m_e_E_ImageEffect = null;
		private Text m_E_Lab_TextText = null;
		public Transform uiTransform = null;
	}
}
