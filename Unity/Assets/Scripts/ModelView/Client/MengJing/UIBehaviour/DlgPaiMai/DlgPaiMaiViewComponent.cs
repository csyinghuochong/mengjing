
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMai))]
	[EnableMethod]
	public  class DlgPaiMaiViewComponent : Entity,IAwake,IDestroy 
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

		public ES_PaiMaiShop ES_PaiMaiShop
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_paimaishop == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PaiMaiShop");
		    	   this.m_es_paimaishop = this.AddChild<ES_PaiMaiShop,Transform>(subTrans);
     			}
     			return this.m_es_paimaishop;
     		}
     	}

		public ES_PaiMaiBuy ES_PaiMaiBuy
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_paimaibuy == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PaiMaiBuy");
		    	   this.m_es_paimaibuy = this.AddChild<ES_PaiMaiBuy,Transform>(subTrans);
     			}
     			return this.m_es_paimaibuy;
     		}
     	}

		public ES_PaiMaiSell ES_PaiMaiSell
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_paimaisell == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PaiMaiSell");
		    	   this.m_es_paimaisell = this.AddChild<ES_PaiMaiSell,Transform>(subTrans);
     			}
     			return this.m_es_paimaisell;
     		}
     	}

		public ES_PaiMaiDuiHuan ES_PaiMaiDuiHuan
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_paimaiduihuan == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PaiMaiDuiHuan");
		    	   this.m_es_paimaiduihuan = this.AddChild<ES_PaiMaiDuiHuan,Transform>(subTrans);
     			}
     			return this.m_es_paimaiduihuan;
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
			this.m_es_paimaishop = null;
			this.m_es_paimaibuy = null;
			this.m_es_paimaisell = null;
			this.m_es_paimaiduihuan = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_PaiMaiShop> m_es_paimaishop = null;
		private EntityRef<ES_PaiMaiBuy> m_es_paimaibuy = null;
		private EntityRef<ES_PaiMaiSell> m_es_paimaisell = null;
		private EntityRef<ES_PaiMaiDuiHuan> m_es_paimaiduihuan = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
