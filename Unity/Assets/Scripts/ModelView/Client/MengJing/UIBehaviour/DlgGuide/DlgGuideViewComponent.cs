using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgGuide))]
	[EnableMethod]
	public  class DlgGuideViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public Text E_Text1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text1Text == null )
     			{
		    		this.m_E_Text1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PositionSet/E_Text1");
     			}
     			return this.m_E_Text1Text;
     		}
     	}

		public Image E_ShowLabSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowLabSetImage == null )
     			{
		    		this.m_E_ShowLabSetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ShowLabSet");
     			}
     			return this.m_E_ShowLabSetImage;
     		}
     	}

		public Text E_ShowLabText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowLabText == null )
     			{
		    		this.m_E_ShowLabText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ShowLabSet/E_ShowLab");
     			}
     			return this.m_E_ShowLabText;
     		}
     	}

		public Image E_ImageButtonImage
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PositionSetRectTransform = null;
			this.m_E_ImageDiImage = null;
			this.m_E_Text1Text = null;
			this.m_E_ShowLabSetImage = null;
			this.m_E_ShowLabText = null;
			this.m_E_ImageButtonImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_PositionSetRectTransform = null;
		private Image m_E_ImageDiImage = null;
		private Text m_E_Text1Text = null;
		private Image m_E_ShowLabSetImage = null;
		private Text m_E_ShowLabText = null;
		private Image m_E_ImageButtonImage = null;
		public Transform uiTransform = null;
	}
}
