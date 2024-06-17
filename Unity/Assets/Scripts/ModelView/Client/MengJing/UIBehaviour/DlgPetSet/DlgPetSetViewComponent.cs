using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof( DlgPetSet))]
    [EnableMethod]
    public class DlgPetSetViewComponent: Entity,IAwake,IDestroy 
    {
        
        public UnityEngine.RectTransform EG_SubViewRectTransform
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
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
     		}
     	}
        

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type1Toggle == null )
     			{
		    		this.m_E_Type1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type1");
     			}
     			return this.m_E_Type1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type2Toggle == null )
     			{
		    		this.m_E_Type2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type2");
     			}
     			return this.m_E_Type2Toggle;
     		}
     	}
        
        public ES_PetMining ES_PetMining
        {
	        get
	        {
		        if (this.uiTransform == null)
		        {
			        Log.Error("uiTransform is null.");
			        return null;
		        }
		        if( this.m_es_petming ==null )
		        {
			        Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetMining");
			        this.m_es_petming = this.AddChild<ES_PetMining,Transform>(subTrans);
		        }
		        return this.m_es_petming;
	        }
        }
		
        public ES_PetChallenge ES_PetChallenge
        {
	        get
	        {
		        if (this.uiTransform == null)
		        {
			        Log.Error("uiTransform is null.");
			        return null;
		        }
		        if( this.m_es_petming ==null )
		        {
			        Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetChallenge");
			        this.m_es_petchallenge = this.AddChild<ES_PetChallenge,Transform>(subTrans);
		        }
		        return this.m_es_petchallenge;
	        }
        }
        
        public void DestroyWidget()
        {
            this.m_EG_SubViewRectTransform = null;
            this.m_E_FunctionSetBtnToggleGroup = null;
            this.m_E_Type1Toggle = null;
            this.m_E_Type2Toggle = null;
            this.uiTransform = null;
        }
        
        private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
        private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
        private UnityEngine.UI.Toggle m_E_Type1Toggle = null;
        private UnityEngine.UI.Toggle m_E_Type2Toggle = null;
        
        private EntityRef<ES_PetMining> m_es_petming = null;
        private EntityRef<ES_PetChallenge> m_es_petchallenge = null;
        public Transform uiTransform = null;
    }
}