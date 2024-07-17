using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgFenXiang))]
	[EnableMethod]
	public  class DlgFenXiangViewComponent : Entity,IAwake,IDestroy 
	{
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

		public ES_FenXiangSet ES_FenXiangSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_FenXiangSet es = this.m_es_fenxiangset;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_FenXiangSet");
		    	   this.m_es_fenxiangset = this.AddChild<ES_FenXiangSet,Transform>(subTrans);
     			}
     			return this.m_es_fenxiangset;
     		}
     	}

		public ES_Popularize ES_Popularize
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_Popularize es = this.m_es_popularize;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_Popularize");
		    	   this.m_es_popularize = this.AddChild<ES_Popularize,Transform>(subTrans);
     			}
     			return this.m_es_popularize;
     		}
     	}

		public ES_Serial ES_Serial
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_Serial es = this.m_es_serial;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_Serial");
		    	   this.m_es_serial = this.AddChild<ES_Serial,Transform>(subTrans);
     			}
     			return this.m_es_serial;
     		}
     	}

		public ES_LunTan ES_LunTan
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_LunTan es = this.m_es_luntan;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_LunTan");
		    	   this.m_es_luntan = this.AddChild<ES_LunTan,Transform>(subTrans);
     			}
     			return this.m_es_luntan;
     		}
     	}

		public ES_FenXiangQQAddSet ES_FenXiangQQAddSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_FenXiangQQAddSet es = this.m_es_fenxiangqqaddset;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_FenXiangQQAddSet");
		    	   this.m_es_fenxiangqqaddset = this.AddChild<ES_FenXiangQQAddSet,Transform>(subTrans);
     			}
     			return this.m_es_fenxiangqqaddset;
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

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_fenxiangset = null;
			this.m_es_popularize = null;
			this.m_es_serial = null;
			this.m_es_luntan = null;
			this.m_es_fenxiangqqaddset = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_FenXiangSet> m_es_fenxiangset = null;
		private EntityRef<ES_Popularize> m_es_popularize = null;
		private EntityRef<ES_Serial> m_es_serial = null;
		private EntityRef<ES_LunTan> m_es_luntan = null;
		private EntityRef<ES_FenXiangQQAddSet> m_es_fenxiangqqaddset = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
