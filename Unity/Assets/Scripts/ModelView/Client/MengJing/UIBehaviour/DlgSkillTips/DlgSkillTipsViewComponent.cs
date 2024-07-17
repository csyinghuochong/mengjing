using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSkillTips))]
	[EnableMethod]
	public  class DlgSkillTipsViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
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

		public RectTransform EG_PositionNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PositionNodeRectTransform == null )
     			{
		    		this.m_EG_PositionNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PositionNode");
     			}
     			return this.m_EG_PositionNodeRectTransform;
     		}
     	}

		public Image E_Image_SkillIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_SkillIconImage == null )
     			{
		    		this.m_E_Image_SkillIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionNode/Image_SkillIcon (1)/E_Image_SkillIcon");
     			}
     			return this.m_E_Image_SkillIconImage;
     		}
     	}

		public Text E_Lab_SkillNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_SkillNameText == null )
     			{
		    		this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_SkillName");
     			}
     			return this.m_E_Lab_SkillNameText;
     		}
     	}

		public Text E_Lab_SkillDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_SkillDesText == null )
     			{
		    		this.m_E_Lab_SkillDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_SkillDes");
     			}
     			return this.m_E_Lab_SkillDesText;
     		}
     	}

		public Text E_Lab_SkillTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_SkillTypeText == null )
     			{
		    		this.m_E_Lab_SkillTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_SkillType");
     			}
     			return this.m_E_Lab_SkillTypeText;
     		}
     	}

		public RectTransform EG_UnActiveTipRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UnActiveTipRectTransform == null )
     			{
		    		this.m_EG_UnActiveTipRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PositionNode/EG_UnActiveTip");
     			}
     			return this.m_EG_UnActiveTipRectTransform;
     		}
     	}

		public Text E_TextTip2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTip2Text == null )
     			{
		    		this.m_E_TextTip2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PositionNode/EG_UnActiveTip/E_TextTip2");
     			}
     			return this.m_E_TextTip2Text;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_EG_PositionNodeRectTransform = null;
			this.m_E_Image_SkillIconImage = null;
			this.m_E_Lab_SkillNameText = null;
			this.m_E_Lab_SkillDesText = null;
			this.m_E_Lab_SkillTypeText = null;
			this.m_EG_UnActiveTipRectTransform = null;
			this.m_E_TextTip2Text = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private RectTransform m_EG_PositionNodeRectTransform = null;
		private Image m_E_Image_SkillIconImage = null;
		private Text m_E_Lab_SkillNameText = null;
		private Text m_E_Lab_SkillDesText = null;
		private Text m_E_Lab_SkillTypeText = null;
		private RectTransform m_EG_UnActiveTipRectTransform = null;
		private Text m_E_TextTip2Text = null;
		public Transform uiTransform = null;
	}
}
