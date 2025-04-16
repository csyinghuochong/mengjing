
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSkillTips))]
	[EnableMethod]
	public  class DlgSkillTipsViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

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
		    		this.m_EG_PositionNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PositionNode");
     			}
     			return this.m_EG_PositionNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_BGImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BGImage == null )
     			{
		    		this.m_E_BGImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionNode/E_BG");
     			}
     			return this.m_E_BGImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UnActiveTipRectTransform
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
		    		this.m_EG_UnActiveTipRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PositionNode/E_BG/EG_UnActiveTip");
     			}
     			return this.m_EG_UnActiveTipRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextTip2Text
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
		    		this.m_E_TextTip2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PositionNode/E_BG/EG_UnActiveTip/E_TextTip2");
     			}
     			return this.m_E_TextTip2Text;
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
		    		this.m_E_Image_SkillIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionNode/Image_SkillIcon (1)/E_Image_SkillIcon");
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
		    		this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_SkillName");
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
		    		this.m_E_Lab_SkillDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_SkillDes");
     			}
     			return this.m_E_Lab_SkillDesText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillTypeText
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
		    		this.m_E_Lab_SkillTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PositionNode/E_Lab_SkillType");
     			}
     			return this.m_E_Lab_SkillTypeText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_EG_PositionNodeRectTransform = null;
			this.m_E_BGImage = null;
			this.m_EG_UnActiveTipRectTransform = null;
			this.m_E_TextTip2Text = null;
			this.m_E_Image_SkillIconImage = null;
			this.m_E_Lab_SkillNameText = null;
			this.m_E_Lab_SkillDesText = null;
			this.m_E_Lab_SkillTypeText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.RectTransform m_EG_PositionNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_BGImage = null;
		private UnityEngine.RectTransform m_EG_UnActiveTipRectTransform = null;
		private UnityEngine.UI.Text m_E_TextTip2Text = null;
		private UnityEngine.UI.Image m_E_Image_SkillIconImage = null;
		private UnityEngine.UI.Text m_E_Lab_SkillNameText = null;
		private UnityEngine.UI.Text m_E_Lab_SkillDesText = null;
		private UnityEngine.UI.Text m_E_Lab_SkillTypeText = null;
		public Transform uiTransform = null;
	}
}
