
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarSetItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_PetBarSetIconButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarSetIconButton == null )
     			{
		    		this.m_E_PetBarSetIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_PetBarSetIcon");
     			}
     			return this.m_E_PetBarSetIconButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetBarSetIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarSetIconImage == null )
     			{
		    		this.m_E_PetBarSetIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_PetBarSetIcon");
     			}
     			return this.m_E_PetBarSetIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_LvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LvText == null )
     			{
		    		this.m_E_LvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lv");
     			}
     			return this.m_E_LvText;
     		}
     	}

		public UnityEngine.UI.Button E_AppearSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AppearSkillButton == null )
     			{
		    		this.m_E_AppearSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_AppearSkill");
     			}
     			return this.m_E_AppearSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_AppearSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AppearSkillImage == null )
     			{
		    		this.m_E_AppearSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_AppearSkill");
     			}
     			return this.m_E_AppearSkillImage;
     		}
     	}

		public UnityEngine.UI.Button E_ActiveSkill_0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveSkill_0Button == null )
     			{
		    		this.m_E_ActiveSkill_0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ActiveSkill_0");
     			}
     			return this.m_E_ActiveSkill_0Button;
     		}
     	}

		public UnityEngine.UI.Image E_ActiveSkill_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveSkill_0Image == null )
     			{
		    		this.m_E_ActiveSkill_0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ActiveSkill_0");
     			}
     			return this.m_E_ActiveSkill_0Image;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_PetBarSetIconButton = null;
			this.m_E_PetBarSetIconImage = null;
			this.m_E_LvText = null;
			this.m_E_AppearSkillButton = null;
			this.m_E_AppearSkillImage = null;
			this.m_E_ActiveSkill_0Button = null;
			this.m_E_ActiveSkill_0Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_PetBarSetIconButton = null;
		private UnityEngine.UI.Image m_E_PetBarSetIconImage = null;
		private UnityEngine.UI.Text m_E_LvText = null;
		private UnityEngine.UI.Button m_E_AppearSkillButton = null;
		private UnityEngine.UI.Image m_E_AppearSkillImage = null;
		private UnityEngine.UI.Button m_E_ActiveSkill_0Button = null;
		private UnityEngine.UI.Image m_E_ActiveSkill_0Image = null;
		public Transform uiTransform = null;
	}
}
