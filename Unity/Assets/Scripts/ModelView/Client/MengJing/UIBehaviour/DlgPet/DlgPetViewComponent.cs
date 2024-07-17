using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPet))]
	[EnableMethod]
	public  class DlgPetViewComponent : Entity,IAwake,IDestroy 
	{
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

		public RectTransform EG_SubViewRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewRectTransform == null )
     			{
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
     		}
     	}

		public ES_PetList ES_PetList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetList es = this.m_es_petlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetList");
		    	   this.m_es_petlist = this.AddChild<ES_PetList,Transform>(subTrans);
     			}
     			return this.m_es_petlist;
     		}
     	}

		public ES_PetHeCheng ES_PetHeCheng
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetHeCheng es = this.m_es_pethecheng;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetHeCheng");
		    	   this.m_es_pethecheng = this.AddChild<ES_PetHeCheng,Transform>(subTrans);
     			}
     			return this.m_es_pethecheng;
     		}
     	}

		public ES_PetXiLian ES_PetXiLian
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetXiLian es = this.m_es_petxilian;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetXiLian");
		    	   this.m_es_petxilian = this.AddChild<ES_PetXiLian,Transform>(subTrans);
     			}
     			return this.m_es_petxilian;
     		}
     	}

		public ES_PetShouHu ES_PetShouHu
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetShouHu es = this.m_es_petshouhu;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetShouHu");
		    	   this.m_es_petshouhu = this.AddChild<ES_PetShouHu,Transform>(subTrans);
     			}
     			return this.m_es_petshouhu;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_petlist = null;
			this.m_es_pethecheng = null;
			this.m_es_petxilian = null;
			this.m_es_petshouhu = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_PetList> m_es_petlist = null;
		private EntityRef<ES_PetHeCheng> m_es_pethecheng = null;
		private EntityRef<ES_PetXiLian> m_es_petxilian = null;
		private EntityRef<ES_PetShouHu> m_es_petshouhu = null;
		public Transform uiTransform = null;
	}
}
