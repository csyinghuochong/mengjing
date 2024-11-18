
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarSetItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_PetlIconButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetlIconButton == null )
     			{
		    		this.m_E_PetlIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_PetlIcon");
     			}
     			return this.m_E_PetlIconButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetlIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetlIconImage == null )
     			{
		    		this.m_E_PetlIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_PetlIcon");
     			}
     			return this.m_E_PetlIconImage;
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
			this.m_E_PetlIconButton = null;
			this.m_E_PetlIconImage = null;
			this.m_E_LvText = null;
			this.m_E_AppearSkillButton = null;
			this.m_E_AppearSkillImage = null;
			this.m_E_ActiveSkill_0Button = null;
			this.m_E_ActiveSkill_0Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_PetlIconButton = null;
		private UnityEngine.UI.Image m_E_PetlIconImage = null;
		private UnityEngine.UI.Text m_E_LvText = null;
		private UnityEngine.UI.Button m_E_AppearSkillButton = null;
		private UnityEngine.UI.Image m_E_AppearSkillImage = null;
		private UnityEngine.UI.Button m_E_ActiveSkill_0Button = null;
		private UnityEngine.UI.Image m_E_ActiveSkill_0Image = null;
		public Transform uiTransform = null;
	}
}
