using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSettingSkill))]
	[EnableMethod]
	public  class DlgSettingSkillViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_CloseBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnButton == null )
     			{
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnButton;
     		}
     	}

		public Image E_CloseBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnImage == null )
     			{
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnImage;
     		}
     	}

		public RectTransform EG_SkillIPositionSetLeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIPositionSetLeftRectTransform == null )
     			{
		    		this.m_EG_SkillIPositionSetLeftRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SkillIPositionSetLeft");
     			}
     			return this.m_EG_SkillIPositionSetLeftRectTransform;
     		}
     	}

		public RectTransform EG_SkillIPositionSetRightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIPositionSetRightRectTransform == null )
     			{
		    		this.m_EG_SkillIPositionSetRightRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SkillIPositionSetRight");
     			}
     			return this.m_EG_SkillIPositionSetRightRectTransform;
     		}
     	}

		public Button E_ResetBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ResetBtnButton == null )
     			{
		    		this.m_E_ResetBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ResetBtn");
     			}
     			return this.m_E_ResetBtnButton;
     		}
     	}

		public Image E_ResetBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ResetBtnImage == null )
     			{
		    		this.m_E_ResetBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ResetBtn");
     			}
     			return this.m_E_ResetBtnImage;
     		}
     	}

		public RectTransform EG_SkillIconItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIconItemRectTransform == null )
     			{
		    		this.m_EG_SkillIconItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SkillIconItem");
     			}
     			return this.m_EG_SkillIconItemRectTransform;
     		}
     	}

		public Image E_Img_MaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_MaskImage == null )
     			{
		    		this.m_E_Img_MaskImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Mask");
     			}
     			return this.m_E_Img_MaskImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseBtnButton = null;
			this.m_E_CloseBtnImage = null;
			this.m_EG_SkillIPositionSetLeftRectTransform = null;
			this.m_EG_SkillIPositionSetRightRectTransform = null;
			this.m_E_ResetBtnButton = null;
			this.m_E_ResetBtnImage = null;
			this.m_EG_SkillIconItemRectTransform = null;
			this.m_E_Img_MaskImage = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseBtnButton = null;
		private Image m_E_CloseBtnImage = null;
		private RectTransform m_EG_SkillIPositionSetLeftRectTransform = null;
		private RectTransform m_EG_SkillIPositionSetRightRectTransform = null;
		private Button m_E_ResetBtnButton = null;
		private Image m_E_ResetBtnImage = null;
		private RectTransform m_EG_SkillIconItemRectTransform = null;
		private Image m_E_Img_MaskImage = null;
		public Transform uiTransform = null;
	}
}
