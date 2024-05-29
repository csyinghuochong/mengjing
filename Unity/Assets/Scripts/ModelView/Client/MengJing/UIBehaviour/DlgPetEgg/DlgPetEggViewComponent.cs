
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
     			if( this.m_es_petegglist == null )
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
     			if( this.m_es_peteggduihuan == null )
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
     			if( this.m_es_peteggchouka == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetEggChouKa");
		    	   this.m_es_peteggchouka = this.AddChild<ES_PetEggChouKa,Transform>(subTrans);
     			}
     			return this.m_es_peteggchouka;
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

		public UnityEngine.UI.Toggle E_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_1Toggle == null )
     			{
		    		this.m_E_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_1");
     			}
     			return this.m_E_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_2Toggle == null )
     			{
		    		this.m_E_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_2");
     			}
     			return this.m_E_2Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_3Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_3Toggle == null )
     			{
		    		this.m_E_3Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_3");
     			}
     			return this.m_E_3Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_4Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_4Toggle == null )
     			{
		    		this.m_E_4Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_4");
     			}
     			return this.m_E_4Toggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_petegglist = null;
			this.m_es_peteggduihuan = null;
			this.m_es_peteggchouka = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_1Toggle = null;
			this.m_E_2Toggle = null;
			this.m_E_3Toggle = null;
			this.m_E_4Toggle = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_PetEggList> m_es_petegglist = null;
		private EntityRef<ES_PetEggDuiHuan> m_es_peteggduihuan = null;
		private EntityRef<ES_PetEggChouKa> m_es_peteggchouka = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_2Toggle = null;
		private UnityEngine.UI.Toggle m_E_3Toggle = null;
		private UnityEngine.UI.Toggle m_E_4Toggle = null;
		public Transform uiTransform = null;
	}
}
