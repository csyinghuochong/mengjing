using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_AttackGrid : Entity,IAwake<Transform>,IDestroy 
	{
		public bool InitEffect;
		public long MoveAttackId;
		
		public Button E_Btn_SkillStartButton
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
		    		this.m_E_Btn_SkillStartButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_SkillStart");
     			}
     			return this.m_E_Btn_SkillStartButton;
     		}
     	}

		public Image E_Btn_SkillStartImage
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
		    		this.m_E_Btn_SkillStartImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_SkillStart");
     			}
     			return this.m_E_Btn_SkillStartImage;
     		}
     	}

		public EventTrigger E_Btn_SkillStartEventTrigger
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
		    		this.m_E_Btn_SkillStartEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Btn_SkillStart");
     			}
     			return this.m_E_Btn_SkillStartEventTrigger;
     		}
     	}

		public RectTransform EG_FightEffectRectTransform
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
		    		this.m_EG_FightEffectRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_FightEffect");
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

		private Button m_E_Btn_SkillStartButton = null;
		private Image m_E_Btn_SkillStartImage = null;
		private EventTrigger m_E_Btn_SkillStartEventTrigger = null;
		private RectTransform m_EG_FightEffectRectTransform = null;
		public Transform uiTransform = null;
	}
}
