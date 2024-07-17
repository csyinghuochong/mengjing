using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgEquipDuiBiTips))]
	[EnableMethod]
	public  class DlgEquipDuiBiTipsViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public RectTransform EG_Tips1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Tips1RectTransform == null )
     			{
		    		this.m_EG_Tips1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Tips1");
     			}
     			return this.m_EG_Tips1RectTransform;
     		}
     	}

		public ES_ItemAppraisalTips ES_ItemAppraisalTips_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ItemAppraisalTips es = this.m_es_itemappraisaltips_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Tips1/ES_ItemAppraisalTips_1");
		    	   this.m_es_itemappraisaltips_1 = this.AddChild<ES_ItemAppraisalTips,Transform>(subTrans);
     			}
     			return this.m_es_itemappraisaltips_1;
     		}
     	}

		public ES_EquipTips ES_EquipTips_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_EquipTips es = this.m_es_equiptips_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Tips1/ES_EquipTips_1");
		    	   this.m_es_equiptips_1 = this.AddChild<ES_EquipTips,Transform>(subTrans);
     			}
     			return this.m_es_equiptips_1;
     		}
     	}

		public RectTransform EG_Tips2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Tips2RectTransform == null )
     			{
		    		this.m_EG_Tips2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Tips2");
     			}
     			return this.m_EG_Tips2RectTransform;
     		}
     	}

		public ES_ItemAppraisalTips ES_ItemAppraisalTips_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ItemAppraisalTips es = this.m_es_itemappraisaltips_2;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Tips2/ES_ItemAppraisalTips_2");
		    	   this.m_es_itemappraisaltips_2 = this.AddChild<ES_ItemAppraisalTips,Transform>(subTrans);
     			}
     			return this.m_es_itemappraisaltips_2;
     		}
     	}

		public ES_EquipTips ES_EquipTips_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_EquipTips es = this.m_es_equiptips_2;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Tips2/ES_EquipTips_2");
		    	   this.m_es_equiptips_2 = this.AddChild<ES_EquipTips,Transform>(subTrans);
     			}
     			return this.m_es_equiptips_2;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_EG_Tips1RectTransform = null;
			this.m_es_itemappraisaltips_1 = null;
			this.m_es_equiptips_1 = null;
			this.m_EG_Tips2RectTransform = null;
			this.m_es_itemappraisaltips_2 = null;
			this.m_es_equiptips_2 = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseButton = null;
		private Image m_E_CloseImage = null;
		private RectTransform m_EG_Tips1RectTransform = null;
		private EntityRef<ES_ItemAppraisalTips> m_es_itemappraisaltips_1 = null;
		private EntityRef<ES_EquipTips> m_es_equiptips_1 = null;
		private RectTransform m_EG_Tips2RectTransform = null;
		private EntityRef<ES_ItemAppraisalTips> m_es_itemappraisaltips_2 = null;
		private EntityRef<ES_EquipTips> m_es_equiptips_2 = null;
		public Transform uiTransform = null;
	}
}
