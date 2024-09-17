using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSkill))]
	[EnableMethod]
	public  class DlgSkillViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_SubViewNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewNodeRectTransform == null )
     			{
		    		this.m_EG_SubViewNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SubViewNode");
     			}
     			return this.m_EG_SubViewNodeRectTransform;
     		}
     	}

		public ES_SkillLearn ES_SkillLearn
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillLearn es = this.m_es_skilllearn;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_SkillLearn");
		    	   this.m_es_skilllearn = this.AddChild<ES_SkillLearn,Transform>(subTrans);
     			}
     			return this.m_es_skilllearn;
     		}
     	}

		public ES_SkillSet ES_SkillSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillSet es = this.m_es_skillset;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_SkillSet");
		    	   this.m_es_skillset = this.AddChild<ES_SkillSet,Transform>(subTrans);
     			}
     			return this.m_es_skillset;
     		}
     	}

		public ES_SkillTianFu ES_SkillTianFu
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFu es = this.m_es_skilltianfu;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_SkillTianFu");
		    	   this.m_es_skilltianfu = this.AddChild<ES_SkillTianFu,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfu;
     		}
     	}

		public ES_SkillMake ES_SkillMake
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillMake es = this.m_es_skillmake;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_SkillMake");
		    	   this.m_es_skillmake = this.AddChild<ES_SkillMake,Transform>(subTrans);
     			}
     			return this.m_es_skillmake;
     		}
     	}

		public ES_SkillLifeShield ES_SkillLifeShield
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillLifeShield es = this.m_es_skilllifeshield;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_SkillLifeShield");
		    	   this.m_es_skilllifeshield = this.AddChild<ES_SkillLifeShield,Transform>(subTrans);
     			}
     			return this.m_es_skilllifeshield;
     		}
     	}

		public ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public Toggle E_Type_0Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_0Toggle == null )
     			{
		    		this.m_E_Type_0Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_0");
     			}
     			return this.m_E_Type_0Toggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_es_skilllearn = null;
			this.m_es_skillset = null;
			this.m_es_skilltianfu = null;
			this.m_es_skillmake = null;
			this.m_es_skilllifeshield = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_0Toggle = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewNodeRectTransform = null;
		private EntityRef<ES_SkillLearn> m_es_skilllearn = null;
		private EntityRef<ES_SkillSet> m_es_skillset = null;
		private EntityRef<ES_SkillTianFu> m_es_skilltianfu = null;
		private EntityRef<ES_SkillMake> m_es_skillmake = null;
		private EntityRef<ES_SkillLifeShield> m_es_skilllifeshield = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Toggle m_E_Type_0Toggle = null;
		public Transform uiTransform = null;
	}
}
