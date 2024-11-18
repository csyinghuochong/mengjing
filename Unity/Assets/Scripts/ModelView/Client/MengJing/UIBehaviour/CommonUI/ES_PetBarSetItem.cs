
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarSetItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		public PetBarInfo PetBarInfo;
		
		public UnityEngine.UI.Image E_SkillIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillIconImage == null )
     			{
		    		this.m_E_SkillIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_SkillIcon");
     			}
     			return this.m_E_SkillIconImage;
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

		public UnityEngine.UI.Button E_Skill_0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill_0Button == null )
     			{
		    		this.m_E_Skill_0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Skill_0");
     			}
     			return this.m_E_Skill_0Button;
     		}
     	}

		public UnityEngine.UI.Image E_Skill_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill_0Image == null )
     			{
		    		this.m_E_Skill_0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Skill_0");
     			}
     			return this.m_E_Skill_0Image;
     		}
     	}

		public UnityEngine.UI.Image E_Skill_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill_1Image == null )
     			{
		    		this.m_E_Skill_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Skill_1");
     			}
     			return this.m_E_Skill_1Image;
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
			this.m_E_SkillIconImage = null;
			this.m_E_LvText = null;
			this.m_E_Skill_0Button = null;
			this.m_E_Skill_0Image = null;
			this.m_E_Skill_1Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_SkillIconImage = null;
		private UnityEngine.UI.Text m_E_LvText = null;
		private UnityEngine.UI.Button m_E_Skill_0Button = null;
		private UnityEngine.UI.Image m_E_Skill_0Image = null;
		private UnityEngine.UI.Image m_E_Skill_1Image = null;
		public Transform uiTransform = null;
	}
}
