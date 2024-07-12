
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetEgg))]
	[EnableMethod]
	public  class DlgPetEggViewComponent : Entity,IAwake,IDestroy 
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

		public ES_PetEggList ES_PetEggList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetEggList es = this.m_es_petegglist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetEggList");
		    	   this.m_es_petegglist = this.AddChild<ES_PetEggList,Transform>(subTrans);
     			}
     			return this.m_es_petegglist;
     		}
     	}

		public ES_PetEggDuiHuan ES_PetEggDuiHuan
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetEggDuiHuan es = this.m_es_peteggduihuan;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetEggDuiHuan");
		    	   this.m_es_peteggduihuan = this.AddChild<ES_PetEggDuiHuan,Transform>(subTrans);
     			}
     			return this.m_es_peteggduihuan;
     		}
     	}

		public ES_PetEggChouKa ES_PetEggChouKa
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetEggChouKa es = this.m_es_peteggchouka;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetEggChouKa");
		    	   this.m_es_peteggchouka = this.AddChild<ES_PetEggChouKa,Transform>(subTrans);
     			}
     			return this.m_es_peteggchouka;
     		}
     	}

		public ES_PetHeXinChouKa ES_PetHeXinChouKa
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetHeXinChouKa es = this.m_es_pethexinchouka;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetHeXinChouKa");
		    	   this.m_es_pethexinchouka = this.AddChild<ES_PetHeXinChouKa,Transform>(subTrans);
     			}
     			return this.m_es_pethexinchouka;
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

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_petegglist = null;
			this.m_es_peteggduihuan = null;
			this.m_es_peteggchouka = null;
			this.m_es_pethexinchouka = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_PetEggList> m_es_petegglist = null;
		private EntityRef<ES_PetEggDuiHuan> m_es_peteggduihuan = null;
		private EntityRef<ES_PetEggChouKa> m_es_peteggchouka = null;
		private EntityRef<ES_PetHeXinChouKa> m_es_pethexinchouka = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
