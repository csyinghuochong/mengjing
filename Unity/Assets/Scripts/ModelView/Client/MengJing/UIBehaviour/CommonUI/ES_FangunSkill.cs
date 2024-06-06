
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FangunSkill : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image E_Img_SkillCDImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_SkillCDImage == null )
     			{
		    		this.m_E_Img_SkillCDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillCD");
     			}
     			return this.m_E_Img_SkillCDImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_EventTriggerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_EventTriggerImage == null )
     			{
		    		this.m_E_Img_EventTriggerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_EventTrigger");
     			}
     			return this.m_E_Img_EventTriggerImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Img_EventTriggerEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_EventTriggerEventTrigger == null )
     			{
		    		this.m_E_Img_EventTriggerEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Img_EventTrigger");
     			}
     			return this.m_E_Img_EventTriggerEventTrigger;
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
			this.m_E_Img_SkillCDImage = null;
			this.m_E_Img_EventTriggerImage = null;
			this.m_E_Img_EventTriggerEventTrigger = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_Img_SkillCDImage = null;
		private UnityEngine.UI.Image m_E_Img_EventTriggerImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Img_EventTriggerEventTrigger = null;
		public Transform uiTransform = null;
	}
}
