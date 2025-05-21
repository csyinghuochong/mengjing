
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSettingSkill))]
	[EnableMethod]
	public  class DlgSettingSkillViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CloseBtnButton
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
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_CloseBtn");
     			}
     			return this.m_E_CloseBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseBtnImage
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
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_CloseBtn");
     			}
     			return this.m_E_CloseBtnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIPositionSetLeftRectTransform
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
		    		this.m_EG_SkillIPositionSetLeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_SkillIPositionSetLeft");
     			}
     			return this.m_EG_SkillIPositionSetLeftRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIPositionSetRightRectTransform
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
		    		this.m_EG_SkillIPositionSetRightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillIPositionSetRight");
     			}
     			return this.m_EG_SkillIPositionSetRightRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ResetBtnButton
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
		    		this.m_E_ResetBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ResetBtn");
     			}
     			return this.m_E_ResetBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ResetBtnImage
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
		    		this.m_E_ResetBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ResetBtn");
     			}
     			return this.m_E_ResetBtnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIconItemRectTransform
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
		    		this.m_EG_SkillIconItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillIconItem");
     			}
     			return this.m_EG_SkillIconItemRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Img_MaskImage
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
		    		this.m_E_Img_MaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_Mask");
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

		private UnityEngine.UI.Button m_E_CloseBtnButton = null;
		private UnityEngine.UI.Image m_E_CloseBtnImage = null;
		private UnityEngine.RectTransform m_EG_SkillIPositionSetLeftRectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillIPositionSetRightRectTransform = null;
		private UnityEngine.UI.Button m_E_ResetBtnButton = null;
		private UnityEngine.UI.Image m_E_ResetBtnImage = null;
		private UnityEngine.RectTransform m_EG_SkillIconItemRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_MaskImage = null;
		public Transform uiTransform = null;
	}
}
