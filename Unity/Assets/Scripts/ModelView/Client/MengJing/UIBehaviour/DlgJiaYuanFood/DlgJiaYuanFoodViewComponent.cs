using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanFood))]
	[EnableMethod]
	public  class DlgJiaYuanFoodViewComponent : Entity,IAwake,IDestroy 
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

		public ES_JiaYuanPurchase ES_JiaYuanPurchase
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_JiaYuanPurchase es = this.m_es_jiayuanpurchase;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_JiaYuanPurchase");
		    	   this.m_es_jiayuanpurchase = this.AddChild<ES_JiaYuanPurchase,Transform>(subTrans);
     			}
     			return this.m_es_jiayuanpurchase;
     		}
     	}

		public ES_JiaYuanCooking ES_JiaYuanCooking
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_JiaYuanCooking es = this.m_es_jiayuancooking;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_JiaYuanCooking");
		    	   this.m_es_jiayuancooking = this.AddChild<ES_JiaYuanCooking,Transform>(subTrans);
     			}
     			return this.m_es_jiayuancooking;
     		}
     	}

		public ES_JiaYuanCookbook ES_JiaYuanCookbook
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_JiaYuanCookbook es = this.m_es_jiayuancookbook;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_JiaYuanCookbook");
		    	   this.m_es_jiayuancookbook = this.AddChild<ES_JiaYuanCookbook,Transform>(subTrans);
     			}
     			return this.m_es_jiayuancookbook;
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
			this.m_es_jiayuanpurchase = null;
			this.m_es_jiayuancooking = null;
			this.m_es_jiayuancookbook = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_JiaYuanPurchase> m_es_jiayuanpurchase = null;
		private EntityRef<ES_JiaYuanCooking> m_es_jiayuancooking = null;
		private EntityRef<ES_JiaYuanCookbook> m_es_jiayuancookbook = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
