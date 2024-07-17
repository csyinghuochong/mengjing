using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgBuffTips))]
	[EnableMethod]
	public  class DlgBuffTipsViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionNode/E_ImageButton");
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionNode/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
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

		public Text E_Lab_BuffTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_BuffTimeText == null )
     			{
		    		this.m_E_Lab_BuffTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_BuffTime");
     			}
     			return this.m_E_Lab_BuffTimeText;
     		}
     	}

		public Text E_Lab_SpellcasterText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_SpellcasterText == null )
     			{
		    		this.m_E_Lab_SpellcasterText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_Spellcaster");
     			}
     			return this.m_E_Lab_SpellcasterText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PositionNodeRectTransform = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Image_SkillIconImage = null;
			this.m_E_Lab_SkillNameText = null;
			this.m_E_Lab_SkillDesText = null;
			this.m_E_Lab_BuffTimeText = null;
			this.m_E_Lab_SpellcasterText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_PositionNodeRectTransform = null;
		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Image m_E_Image_SkillIconImage = null;
		private Text m_E_Lab_SkillNameText = null;
		private Text m_E_Lab_SkillDesText = null;
		private Text m_E_Lab_BuffTimeText = null;
		private Text m_E_Lab_SpellcasterText = null;
		public Transform uiTransform = null;
	}
}
