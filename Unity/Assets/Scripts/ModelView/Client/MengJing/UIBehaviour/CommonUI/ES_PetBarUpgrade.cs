
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarUpgrade : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int Index;
		
		public ES_PetUpgradeItem ES_PetUpgradeItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetUpgradeItem es = this.m_es_petupgradeitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetUpgradeItem_1");
		    	   this.m_es_petupgradeitem_1 = this.AddChild<ES_PetUpgradeItem,Transform>(subTrans);
     			}
     			return this.m_es_petupgradeitem_1;
     		}
     	}

		public ES_PetUpgradeItem ES_PetUpgradeItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetUpgradeItem es = this.m_es_petupgradeitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetUpgradeItem_2");
		    	   this.m_es_petupgradeitem_2 = this.AddChild<ES_PetUpgradeItem,Transform>(subTrans);
     			}
     			return this.m_es_petupgradeitem_2;
     		}
     	}

		public ES_PetUpgradeItem ES_PetUpgradeItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetUpgradeItem es = this.m_es_petupgradeitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetUpgradeItem_3");
		    	   this.m_es_petupgradeitem_3 = this.AddChild<ES_PetUpgradeItem,Transform>(subTrans);
     			}
     			return this.m_es_petupgradeitem_3;
     		}
     	}

		public UnityEngine.RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_PetBarIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarIconImage == null )
     			{
		    		this.m_E_PetBarIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_PetBarIcon");
     			}
     			return this.m_E_PetBarIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_PetBarNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarNameText == null )
     			{
		    		this.m_E_PetBarNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_PetBarName");
     			}
     			return this.m_E_PetBarNameText;
     		}
     	}

		public UnityEngine.UI.Text E_PetBarLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarLvText == null )
     			{
		    		this.m_E_PetBarLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_PetBarLv");
     			}
     			return this.m_E_PetBarLvText;
     		}
     	}

		public UnityEngine.UI.Text E_DesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DesText == null )
     			{
		    		this.m_E_DesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Des");
     			}
     			return this.m_E_DesText;
     		}
     	}

		public ES_CostList ES_CostList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostList es = this.m_es_costlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Right/ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
     		}
     	}

		public UnityEngine.UI.Button E_UpgradeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpgradeButton == null )
     			{
		    		this.m_E_UpgradeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/E_Upgrade");
     			}
     			return this.m_E_UpgradeButton;
     		}
     	}

		public UnityEngine.UI.Image E_UpgradeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpgradeImage == null )
     			{
		    		this.m_E_UpgradeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_Upgrade");
     			}
     			return this.m_E_UpgradeImage;
     		}
     	}

		public UnityEngine.UI.Text E_MaxText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MaxText == null )
     			{
		    		this.m_E_MaxText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Max");
     			}
     			return this.m_E_MaxText;
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
			this.m_es_petupgradeitem_1 = null;
			this.m_es_petupgradeitem_2 = null;
			this.m_es_petupgradeitem_3 = null;
			this.m_EG_RightRectTransform = null;
			this.m_E_PetBarIconImage = null;
			this.m_E_PetBarNameText = null;
			this.m_E_PetBarLvText = null;
			this.m_E_DesText = null;
			this.m_es_costlist = null;
			this.m_E_UpgradeButton = null;
			this.m_E_UpgradeImage = null;
			this.m_E_MaxText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_PetUpgradeItem> m_es_petupgradeitem_1 = null;
		private EntityRef<ES_PetUpgradeItem> m_es_petupgradeitem_2 = null;
		private EntityRef<ES_PetUpgradeItem> m_es_petupgradeitem_3 = null;
		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private UnityEngine.UI.Image m_E_PetBarIconImage = null;
		private UnityEngine.UI.Text m_E_PetBarNameText = null;
		private UnityEngine.UI.Text m_E_PetBarLvText = null;
		private UnityEngine.UI.Text m_E_DesText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private UnityEngine.UI.Button m_E_UpgradeButton = null;
		private UnityEngine.UI.Image m_E_UpgradeImage = null;
		private UnityEngine.UI.Text m_E_MaxText = null;
		public Transform uiTransform = null;
	}
}
