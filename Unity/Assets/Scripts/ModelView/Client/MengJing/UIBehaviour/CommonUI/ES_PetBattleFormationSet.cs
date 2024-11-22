
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBattleFormationSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.ToggleGroup E_PlanSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlanSetToggleGroup == null )
     			{
		    		this.m_E_PlanSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_PlanSet");
     			}
     			return this.m_E_PlanSetToggleGroup;
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
			this.m_E_PlanSetToggleGroup = null;
			this.m_es_petbarsetitem_1 = null;
			this.m_es_petbarsetitem_2 = null;
			this.m_es_petbarsetitem_3 = null;
			this.m_EG_PetPanelRectTransform = null;
			this.m_E_PetTypeSetToggleGroup = null;
			this.m_E_PetbarSetPetItemsImage = null;
			this.m_E_PetbarSetPetItemsLoopVerticalScrollRect = null;
			this.m_EG_SkillPanelRectTransform = null;
			this.m_E_SkillTypeSetToggleGroup = null;
			this.m_E_PetbarSetSkillItemsImage = null;
			this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.m_E_ReSetButton = null;
			this.m_E_ReSetImage = null;
			this.m_EG_PetIconRectTransform = null;
			this.m_EG_SkillIconRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		public Transform uiTransform = null;
	}
}
