
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_AttackGrid : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_SkillStartButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkillStartButton == null )
     			{
		    		this.m_E_Btn_SkillStartButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_SkillStart");
     			}
     			return this.m_E_Btn_SkillStartButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SkillStartImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkillStartImage == null )
     			{
		    		this.m_E_Btn_SkillStartImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_SkillStart");
     			}
     			return this.m_E_Btn_SkillStartImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_SkillStartEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkillStartEventTrigger == null )
     			{
		    		this.m_E_Btn_SkillStartEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Btn_SkillStart");
     			}
     			return this.m_E_Btn_SkillStartEventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_FightEffectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FightEffectRectTransform == null )
     			{
		    		this.m_EG_FightEffectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_FightEffect");
     			}
     			return this.m_EG_FightEffectRectTransform;
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
			this.m_E_Btn_SkillStartButton = null;
			this.m_E_Btn_SkillStartImage = null;
			this.m_E_Btn_SkillStartEventTrigger = null;
			this.m_EG_FightEffectRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_SkillStartButton = null;
		private UnityEngine.UI.Image m_E_Btn_SkillStartImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_SkillStartEventTrigger = null;
		private UnityEngine.RectTransform m_EG_FightEffectRectTransform = null;
		public Transform uiTransform = null;
	}
}
