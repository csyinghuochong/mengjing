
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgBuffTips))]
	[EnableMethod]
	public  class DlgBuffTipsViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_PositionNodeRectTransform
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
		    		this.m_EG_PositionNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_PositionNode");
     			}
     			return this.m_EG_PositionNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_PositionNode/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PositionNode/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_SkillIconImage
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
		    		this.m_E_Image_SkillIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PositionNode/Image_SkillIcon (1)/E_Image_SkillIcon");
     			}
     			return this.m_E_Image_SkillIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillNameText
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
		    		this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_PositionNode/E_Lab_SkillName");
     			}
     			return this.m_E_Lab_SkillNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillDesText
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
		    		this.m_E_Lab_SkillDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_PositionNode/E_Lab_SkillDes");
     			}
     			return this.m_E_Lab_SkillDesText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_BuffTimeText
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
		    		this.m_E_Lab_BuffTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_PositionNode/E_Lab_BuffTime");
     			}
     			return this.m_E_Lab_BuffTimeText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SpellcasterText
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
		    		this.m_E_Lab_SpellcasterText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_PositionNode/E_Lab_Spellcaster");
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

		private UnityEngine.RectTransform m_EG_PositionNodeRectTransform = null;
		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Image m_E_Image_SkillIconImage = null;
		private UnityEngine.UI.Text m_E_Lab_SkillNameText = null;
		private UnityEngine.UI.Text m_E_Lab_SkillDesText = null;
		private UnityEngine.UI.Text m_E_Lab_BuffTimeText = null;
		private UnityEngine.UI.Text m_E_Lab_SpellcasterText = null;
		public Transform uiTransform = null;
	}
}
