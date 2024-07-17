using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggDuiHuan : Entity,IAwake<Transform>,IDestroy 
	{
		public Button E_Btn_ChouKaCoin0Button
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
		    		this.m_E_Btn_ChouKaCoin0Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIPetEggDuiHuan/E_Btn_ChouKaCoin0");
     			}
     			return this.m_E_Btn_ChouKaCoin0Button;
     		}
     	}

		public Image E_Btn_ChouKaCoin0Image
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
		    		this.m_E_Btn_ChouKaCoin0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetEggDuiHuan/E_Btn_ChouKaCoin0");
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"UIPetEggDuiHuan/ES_CostItem_0");
		    	   this.m_es_costitem_0 = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem_0;
     		}
     	}

		public Button E_Btn_ChouKaCoin1Button
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
		    		this.m_E_Btn_ChouKaCoin1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIPetEggDuiHuan1/E_Btn_ChouKaCoin1");
     			}
     			return this.m_E_Btn_ChouKaCoin1Button;
     		}
     	}

		public Image E_Btn_ChouKaCoin1Image
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
		    		this.m_E_Btn_ChouKaCoin1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetEggDuiHuan1/E_Btn_ChouKaCoin1");
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"UIPetEggDuiHuan1/ES_CostItem_1");
		    	   this.m_es_costitem_1 = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem_1;
     		}
     	}

		public Button E_Btn_ChouKaCoin2Button
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
		    		this.m_E_Btn_ChouKaCoin2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIPetEggDuiHuan2/E_Btn_ChouKaCoin2");
     			}
     			return this.m_E_Btn_ChouKaCoin2Button;
     		}
     	}

		public Image E_Btn_ChouKaCoin2Image
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
		    		this.m_E_Btn_ChouKaCoin2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetEggDuiHuan2/E_Btn_ChouKaCoin2");
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"UIPetEggDuiHuan2/ES_CostItem_2");
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

		private Button m_E_Btn_ChouKaCoin0Button = null;
		private Image m_E_Btn_ChouKaCoin0Image = null;
		private EntityRef<ES_CostItem> m_es_costitem_0 = null;
		private Button m_E_Btn_ChouKaCoin1Button = null;
		private Image m_E_Btn_ChouKaCoin1Image = null;
		private EntityRef<ES_CostItem> m_es_costitem_1 = null;
		private Button m_E_Btn_ChouKaCoin2Button = null;
		private Image m_E_Btn_ChouKaCoin2Image = null;
		private EntityRef<ES_CostItem> m_es_costitem_2 = null;
		public Transform uiTransform = null;
	}
}
