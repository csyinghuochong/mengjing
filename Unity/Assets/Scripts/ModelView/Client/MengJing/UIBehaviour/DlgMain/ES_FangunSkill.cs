using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FangunSkill : Entity,IAwake<Transform>,IDestroy 
	{
		public float LastSkillTime;
		public int SkillId;
		
		public Image E_Img_SkillCDImage
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
		    		this.m_E_Img_SkillCDImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_SkillCD");
     			}
     			return this.m_E_Img_SkillCDImage;
     		}
     	}

		public Image E_Img_EventTriggerImage
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
		    		this.m_E_Img_EventTriggerImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_EventTrigger");
     			}
     			return this.m_E_Img_EventTriggerImage;
     		}
     	}

		public EventTrigger E_Img_EventTriggerEventTrigger
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
		    		this.m_E_Img_EventTriggerEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Img_EventTrigger");
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

		private Image m_E_Img_SkillCDImage = null;
		private Image m_E_Img_EventTriggerImage = null;
		private EventTrigger m_E_Img_EventTriggerEventTrigger = null;
		public Transform uiTransform = null;
	}
}
