
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgButtonPositionSet))]
	[EnableMethod]
	public  class DlgButtonPositionSetViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_SkillPositionSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillPositionSetImage == null )
     			{
		    		this.m_E_SkillPositionSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SkillPositionSet");
     			}
     			return this.m_E_SkillPositionSetImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSkillPositionSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSkillPositionSetImage == null )
     			{
		    		this.m_E_ImageSkillPositionSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SkillPositionSet/E_ImageSkillPositionSet");
     			}
     			return this.m_E_ImageSkillPositionSetImage;
     		}
     	}

		public UnityEngine.UI.Image E_LeftBottomBtnsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LeftBottomBtnsImage == null )
     			{
		    		this.m_E_LeftBottomBtnsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LeftBottomBtns");
     			}
     			return this.m_E_LeftBottomBtnsImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageLeftBottomBtnsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageLeftBottomBtnsImage == null )
     			{
		    		this.m_E_ImageLeftBottomBtnsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_LeftBottomBtns/E_ImageLeftBottomBtns");
     			}
     			return this.m_E_ImageLeftBottomBtnsImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SkilPositionSaveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionSaveButton == null )
     			{
		    		this.m_E_Btn_SkilPositionSaveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_SkilPositionSave");
     			}
     			return this.m_E_Btn_SkilPositionSaveButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SkilPositionSaveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionSaveImage == null )
     			{
		    		this.m_E_Btn_SkilPositionSaveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_SkilPositionSave");
     			}
     			return this.m_E_Btn_SkilPositionSaveImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SkilPositionCancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionCancelButton == null )
     			{
		    		this.m_E_Btn_SkilPositionCancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_SkilPositionCancel");
     			}
     			return this.m_E_Btn_SkilPositionCancelButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SkilPositionCancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionCancelImage == null )
     			{
		    		this.m_E_Btn_SkilPositionCancelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_SkilPositionCancel");
     			}
     			return this.m_E_Btn_SkilPositionCancelImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SkilPositionResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionResetButton == null )
     			{
		    		this.m_E_Btn_SkilPositionResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_SkilPositionReset");
     			}
     			return this.m_E_Btn_SkilPositionResetButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SkilPositionResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionResetImage == null )
     			{
		    		this.m_E_Btn_SkilPositionResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_SkilPositionReset");
     			}
     			return this.m_E_Btn_SkilPositionResetImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SkillPositionSetImage = null;
			this.m_E_ImageSkillPositionSetImage = null;
			this.m_E_LeftBottomBtnsImage = null;
			this.m_E_ImageLeftBottomBtnsImage = null;
			this.m_E_Btn_SkilPositionSaveButton = null;
			this.m_E_Btn_SkilPositionSaveImage = null;
			this.m_E_Btn_SkilPositionCancelButton = null;
			this.m_E_Btn_SkilPositionCancelImage = null;
			this.m_E_Btn_SkilPositionResetButton = null;
			this.m_E_Btn_SkilPositionResetImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_SkillPositionSetImage = null;
		private UnityEngine.UI.Image m_E_ImageSkillPositionSetImage = null;
		private UnityEngine.UI.Image m_E_LeftBottomBtnsImage = null;
		private UnityEngine.UI.Image m_E_ImageLeftBottomBtnsImage = null;
		private UnityEngine.UI.Button m_E_Btn_SkilPositionSaveButton = null;
		private UnityEngine.UI.Image m_E_Btn_SkilPositionSaveImage = null;
		private UnityEngine.UI.Button m_E_Btn_SkilPositionCancelButton = null;
		private UnityEngine.UI.Image m_E_Btn_SkilPositionCancelImage = null;
		private UnityEngine.UI.Button m_E_Btn_SkilPositionResetButton = null;
		private UnityEngine.UI.Image m_E_Btn_SkilPositionResetImage = null;
		public Transform uiTransform = null;
	}
}
