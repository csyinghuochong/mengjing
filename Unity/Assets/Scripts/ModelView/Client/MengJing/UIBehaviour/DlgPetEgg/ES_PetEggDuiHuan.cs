
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggDuiHuan : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_ChouKaCoin0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaCoin0Button == null )
     			{
		    		this.m_E_Btn_ChouKaCoin0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan/E_Btn_ChouKaCoin0");
     			}
     			return this.m_E_Btn_ChouKaCoin0Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaCoin0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaCoin0Image == null )
     			{
		    		this.m_E_Btn_ChouKaCoin0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan/E_Btn_ChouKaCoin0");
     			}
     			return this.m_E_Btn_ChouKaCoin0Image;
     		}
     	}

		public ES_CostItem ES_CostItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostItem es = this.m_es_costitem_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan/ES_CostItem_0");
		    	   this.m_es_costitem_0 = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem_0;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaCoin1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaCoin1Button == null )
     			{
		    		this.m_E_Btn_ChouKaCoin1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan1/E_Btn_ChouKaCoin1");
     			}
     			return this.m_E_Btn_ChouKaCoin1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaCoin1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaCoin1Image == null )
     			{
		    		this.m_E_Btn_ChouKaCoin1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan1/E_Btn_ChouKaCoin1");
     			}
     			return this.m_E_Btn_ChouKaCoin1Image;
     		}
     	}

		public ES_CostItem ES_CostItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostItem es = this.m_es_costitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan1/ES_CostItem_1");
		    	   this.m_es_costitem_1 = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem_1;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaCoin2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaCoin2Button == null )
     			{
		    		this.m_E_Btn_ChouKaCoin2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan2/E_Btn_ChouKaCoin2");
     			}
     			return this.m_E_Btn_ChouKaCoin2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaCoin2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaCoin2Image == null )
     			{
		    		this.m_E_Btn_ChouKaCoin2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan2/E_Btn_ChouKaCoin2");
     			}
     			return this.m_E_Btn_ChouKaCoin2Image;
     		}
     	}

		public ES_CostItem ES_CostItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostItem es = this.m_es_costitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/UIPetEggDuiHuan2/ES_CostItem_2");
		    	   this.m_es_costitem_2 = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem_2;
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
			this.m_E_Btn_ChouKaCoin0Button = null;
			this.m_E_Btn_ChouKaCoin0Image = null;
			this.m_es_costitem_0 = null;
			this.m_E_Btn_ChouKaCoin1Button = null;
			this.m_E_Btn_ChouKaCoin1Image = null;
			this.m_es_costitem_1 = null;
			this.m_E_Btn_ChouKaCoin2Button = null;
			this.m_E_Btn_ChouKaCoin2Image = null;
			this.m_es_costitem_2 = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_ChouKaCoin0Button = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaCoin0Image = null;
		private EntityRef<ES_CostItem> m_es_costitem_0 = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaCoin1Button = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaCoin1Image = null;
		private EntityRef<ES_CostItem> m_es_costitem_1 = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaCoin2Button = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaCoin2Image = null;
		private EntityRef<ES_CostItem> m_es_costitem_2 = null;
		public Transform uiTransform = null;
	}
}
