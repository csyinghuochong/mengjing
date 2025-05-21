
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgOccTwo))]
	[EnableMethod]
	public  class DlgOccTwoViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_closeButtonButton
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
		    		this.m_E_closeButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_closeButtonImage
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
		    		this.m_E_closeButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_OccLine_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccLine_1RectTransform == null )
     			{
		    		this.m_EG_OccLine_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_OccLine_1");
     			}
     			return this.m_EG_OccLine_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_OccLine_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccLine_2RectTransform == null )
     			{
		    		this.m_EG_OccLine_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_OccLine_2");
     			}
     			return this.m_EG_OccLine_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_OccLine_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccLine_3RectTransform == null )
     			{
		    		this.m_EG_OccLine_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_OccLine_3");
     			}
     			return this.m_EG_OccLine_3RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Image_ZhiYeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_ZhiYeImage == null )
     			{
		    		this.m_E_Image_ZhiYeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Image_ZhiYe");
     			}
     			return this.m_E_Image_ZhiYeImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhiYeSelect_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYeSelect_1Button == null )
     			{
		    		this.m_E_Button_ZhiYeSelect_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_ZhiYeSelect_1");
     			}
     			return this.m_E_Button_ZhiYeSelect_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhiYeSelect_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYeSelect_1Image == null )
     			{
		    		this.m_E_Button_ZhiYeSelect_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_ZhiYeSelect_1");
     			}
     			return this.m_E_Button_ZhiYeSelect_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhiYeSelect_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYeSelect_2Button == null )
     			{
		    		this.m_E_Button_ZhiYeSelect_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_ZhiYeSelect_2");
     			}
     			return this.m_E_Button_ZhiYeSelect_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhiYeSelect_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYeSelect_2Image == null )
     			{
		    		this.m_E_Button_ZhiYeSelect_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_ZhiYeSelect_2");
     			}
     			return this.m_E_Button_ZhiYeSelect_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhiYeSelect_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYeSelect_3Button == null )
     			{
		    		this.m_E_Button_ZhiYeSelect_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_ZhiYeSelect_3");
     			}
     			return this.m_E_Button_ZhiYeSelect_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhiYeSelect_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYeSelect_3Image == null )
     			{
		    		this.m_E_Button_ZhiYeSelect_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_ZhiYeSelect_3");
     			}
     			return this.m_E_Button_ZhiYeSelect_3Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhiYe_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYe_1Button == null )
     			{
		    		this.m_E_Button_ZhiYe_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_ZhiYe_1");
     			}
     			return this.m_E_Button_ZhiYe_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhiYe_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYe_1Image == null )
     			{
		    		this.m_E_Button_ZhiYe_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_ZhiYe_1");
     			}
     			return this.m_E_Button_ZhiYe_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhiYe_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYe_2Button == null )
     			{
		    		this.m_E_Button_ZhiYe_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_ZhiYe_2");
     			}
     			return this.m_E_Button_ZhiYe_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhiYe_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYe_2Image == null )
     			{
		    		this.m_E_Button_ZhiYe_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_ZhiYe_2");
     			}
     			return this.m_E_Button_ZhiYe_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhiYe_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYe_3Button == null )
     			{
		    		this.m_E_Button_ZhiYe_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_ZhiYe_3");
     			}
     			return this.m_E_Button_ZhiYe_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhiYe_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhiYe_3Image == null )
     			{
		    		this.m_E_Button_ZhiYe_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_ZhiYe_3");
     			}
     			return this.m_E_Button_ZhiYe_3Image;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ZhiYeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ZhiYeText == null )
     			{
		    		this.m_E_Text_ZhiYeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_ZhiYe");
     			}
     			return this.m_E_Text_ZhiYeText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ZhiYe_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ZhiYe_1Text == null )
     			{
		    		this.m_E_Text_ZhiYe_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_ZhiYe_1");
     			}
     			return this.m_E_Text_ZhiYe_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ZhiYe_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ZhiYe_2Text == null )
     			{
		    		this.m_E_Text_ZhiYe_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_ZhiYe_2");
     			}
     			return this.m_E_Text_ZhiYe_2Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ZhiYe_3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ZhiYe_3Text == null )
     			{
		    		this.m_E_Text_ZhiYe_3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_ZhiYe_3");
     			}
     			return this.m_E_Text_ZhiYe_3Text;
     		}
     	}

		public UnityEngine.UI.Image E_Image_ZhiYe_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_ZhiYe_4Image == null )
     			{
		    		this.m_E_Image_ZhiYe_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Image_ZhiYe_4");
     			}
     			return this.m_E_Image_ZhiYe_4Image;
     		}
     	}

		public UnityEngine.UI.Image E_Image_WuQi_TypeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_WuQi_TypeImage == null )
     			{
		    		this.m_E_Image_WuQi_TypeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Image_WuQi_Type");
     			}
     			return this.m_E_Image_WuQi_TypeImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_WuQi_ZhuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_WuQi_ZhuanImage == null )
     			{
		    		this.m_E_Image_WuQi_ZhuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Image_WuQi_Zhuan");
     			}
     			return this.m_E_Image_WuQi_ZhuanImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillContainerRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillContainerRectTransform == null )
     			{
		    		this.m_EG_SkillContainerRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillContainer");
     			}
     			return this.m_EG_SkillContainerRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOccTwoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOccTwoButton == null )
     			{
		    		this.m_E_ButtonOccTwoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonOccTwo");
     			}
     			return this.m_E_ButtonOccTwoButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOccTwoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOccTwoImage == null )
     			{
		    		this.m_E_ButtonOccTwoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonOccTwo");
     			}
     			return this.m_E_ButtonOccTwoImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOccResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOccResetButton == null )
     			{
		    		this.m_E_ButtonOccResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonOccReset");
     			}
     			return this.m_E_ButtonOccResetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOccResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOccResetImage == null )
     			{
		    		this.m_E_ButtonOccResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonOccReset");
     			}
     			return this.m_E_ButtonOccResetImage;
     		}
     	}

		public UnityEngine.RectTransform EG_OccNengLi_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccNengLi_1RectTransform == null )
     			{
		    		this.m_EG_OccNengLi_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_OccNengLi_1");
     			}
     			return this.m_EG_OccNengLi_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_OccNengLi_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccNengLi_2RectTransform == null )
     			{
		    		this.m_EG_OccNengLi_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_OccNengLi_2");
     			}
     			return this.m_EG_OccNengLi_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_OccNengLi_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccNengLi_3RectTransform == null )
     			{
		    		this.m_EG_OccNengLi_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_OccNengLi_3");
     			}
     			return this.m_EG_OccNengLi_3RectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ZhiYe_4Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ZhiYe_4Text == null )
     			{
		    		this.m_E_Text_ZhiYe_4Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_ZhiYe_4");
     			}
     			return this.m_E_Text_ZhiYe_4Text;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_WuQiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_WuQiText == null )
     			{
		    		this.m_E_Lab_WuQiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_WuQi");
     			}
     			return this.m_E_Lab_WuQiText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_HuJiaText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_HuJiaText == null )
     			{
		    		this.m_E_Lab_HuJiaText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_HuJia");
     			}
     			return this.m_E_Lab_HuJiaText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_HintText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_HintText == null )
     			{
		    		this.m_E_Lab_HintText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_Hint");
     			}
     			return this.m_E_Lab_HintText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_closeButtonButton = null;
			this.m_E_closeButtonImage = null;
			this.m_EG_OccLine_1RectTransform = null;
			this.m_EG_OccLine_2RectTransform = null;
			this.m_EG_OccLine_3RectTransform = null;
			this.m_E_Image_ZhiYeImage = null;
			this.m_E_Button_ZhiYeSelect_1Button = null;
			this.m_E_Button_ZhiYeSelect_1Image = null;
			this.m_E_Button_ZhiYeSelect_2Button = null;
			this.m_E_Button_ZhiYeSelect_2Image = null;
			this.m_E_Button_ZhiYeSelect_3Button = null;
			this.m_E_Button_ZhiYeSelect_3Image = null;
			this.m_E_Button_ZhiYe_1Button = null;
			this.m_E_Button_ZhiYe_1Image = null;
			this.m_E_Button_ZhiYe_2Button = null;
			this.m_E_Button_ZhiYe_2Image = null;
			this.m_E_Button_ZhiYe_3Button = null;
			this.m_E_Button_ZhiYe_3Image = null;
			this.m_E_Text_ZhiYeText = null;
			this.m_E_Text_ZhiYe_1Text = null;
			this.m_E_Text_ZhiYe_2Text = null;
			this.m_E_Text_ZhiYe_3Text = null;
			this.m_E_Image_ZhiYe_4Image = null;
			this.m_E_Image_WuQi_TypeImage = null;
			this.m_E_Image_WuQi_ZhuanImage = null;
			this.m_EG_SkillContainerRectTransform = null;
			this.m_E_ButtonOccTwoButton = null;
			this.m_E_ButtonOccTwoImage = null;
			this.m_E_ButtonOccResetButton = null;
			this.m_E_ButtonOccResetImage = null;
			this.m_EG_OccNengLi_1RectTransform = null;
			this.m_EG_OccNengLi_2RectTransform = null;
			this.m_EG_OccNengLi_3RectTransform = null;
			this.m_E_Text_ZhiYe_4Text = null;
			this.m_E_Lab_WuQiText = null;
			this.m_E_Lab_HuJiaText = null;
			this.m_E_Lab_HintText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_closeButtonButton = null;
		private UnityEngine.UI.Image m_E_closeButtonImage = null;
		private UnityEngine.RectTransform m_EG_OccLine_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_OccLine_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_OccLine_3RectTransform = null;
		private UnityEngine.UI.Image m_E_Image_ZhiYeImage = null;
		private UnityEngine.UI.Button m_E_Button_ZhiYeSelect_1Button = null;
		private UnityEngine.UI.Image m_E_Button_ZhiYeSelect_1Image = null;
		private UnityEngine.UI.Button m_E_Button_ZhiYeSelect_2Button = null;
		private UnityEngine.UI.Image m_E_Button_ZhiYeSelect_2Image = null;
		private UnityEngine.UI.Button m_E_Button_ZhiYeSelect_3Button = null;
		private UnityEngine.UI.Image m_E_Button_ZhiYeSelect_3Image = null;
		private UnityEngine.UI.Button m_E_Button_ZhiYe_1Button = null;
		private UnityEngine.UI.Image m_E_Button_ZhiYe_1Image = null;
		private UnityEngine.UI.Button m_E_Button_ZhiYe_2Button = null;
		private UnityEngine.UI.Image m_E_Button_ZhiYe_2Image = null;
		private UnityEngine.UI.Button m_E_Button_ZhiYe_3Button = null;
		private UnityEngine.UI.Image m_E_Button_ZhiYe_3Image = null;
		private UnityEngine.UI.Text m_E_Text_ZhiYeText = null;
		private UnityEngine.UI.Text m_E_Text_ZhiYe_1Text = null;
		private UnityEngine.UI.Text m_E_Text_ZhiYe_2Text = null;
		private UnityEngine.UI.Text m_E_Text_ZhiYe_3Text = null;
		private UnityEngine.UI.Image m_E_Image_ZhiYe_4Image = null;
		private UnityEngine.UI.Image m_E_Image_WuQi_TypeImage = null;
		private UnityEngine.UI.Image m_E_Image_WuQi_ZhuanImage = null;
		private UnityEngine.RectTransform m_EG_SkillContainerRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonOccTwoButton = null;
		private UnityEngine.UI.Image m_E_ButtonOccTwoImage = null;
		private UnityEngine.UI.Button m_E_ButtonOccResetButton = null;
		private UnityEngine.UI.Image m_E_ButtonOccResetImage = null;
		private UnityEngine.RectTransform m_EG_OccNengLi_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_OccNengLi_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_OccNengLi_3RectTransform = null;
		private UnityEngine.UI.Text m_E_Text_ZhiYe_4Text = null;
		private UnityEngine.UI.Text m_E_Lab_WuQiText = null;
		private UnityEngine.UI.Text m_E_Lab_HuJiaText = null;
		private UnityEngine.UI.Text m_E_Lab_HintText = null;
		public Transform uiTransform = null;
	}
}
