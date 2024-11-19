
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarUpgrade : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_PetBarIcon_0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarIcon_0Button == null )
     			{
		    		this.m_E_PetBarIcon_0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/PetUpgradeItem_0/E_PetBarIcon_0");
     			}
     			return this.m_E_PetBarIcon_0Button;
     		}
     	}

		public UnityEngine.UI.Image E_PetBarIcon_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarIcon_0Image == null )
     			{
		    		this.m_E_PetBarIcon_0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/PetUpgradeItem_0/E_PetBarIcon_0");
     			}
     			return this.m_E_PetBarIcon_0Image;
     		}
     	}

		public UnityEngine.UI.Text E_PetBarName_0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarName_0Text == null )
     			{
		    		this.m_E_PetBarName_0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/PetUpgradeItem_0/E_PetBarName_0");
     			}
     			return this.m_E_PetBarName_0Text;
     		}
     	}

		public UnityEngine.UI.Text E_PetBarLv_0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarLv_0Text == null )
     			{
		    		this.m_E_PetBarLv_0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/PetUpgradeItem_0/E_PetBarLv_0");
     			}
     			return this.m_E_PetBarLv_0Text;
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
		    		this.m_E_PetBarIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_PetBarIcon");
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
		    		this.m_E_PetBarNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_PetBarName");
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
		    		this.m_E_PetBarLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_PetBarLv");
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
		    		this.m_E_DesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Des");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CostList");
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
		    		this.m_E_UpgradeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Upgrade");
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
		    		this.m_E_UpgradeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Upgrade");
     			}
     			return this.m_E_UpgradeImage;
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
			this.m_E_PetBarIcon_0Button = null;
			this.m_E_PetBarIcon_0Image = null;
			this.m_E_PetBarName_0Text = null;
			this.m_E_PetBarLv_0Text = null;
			this.m_E_PetBarIconImage = null;
			this.m_E_PetBarNameText = null;
			this.m_E_PetBarLvText = null;
			this.m_E_DesText = null;
			this.m_es_costlist = null;
			this.m_E_UpgradeButton = null;
			this.m_E_UpgradeImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_PetBarIcon_0Button = null;
		private UnityEngine.UI.Image m_E_PetBarIcon_0Image = null;
		private UnityEngine.UI.Text m_E_PetBarName_0Text = null;
		private UnityEngine.UI.Text m_E_PetBarLv_0Text = null;
		private UnityEngine.UI.Image m_E_PetBarIconImage = null;
		private UnityEngine.UI.Text m_E_PetBarNameText = null;
		private UnityEngine.UI.Text m_E_PetBarLvText = null;
		private UnityEngine.UI.Text m_E_DesText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private UnityEngine.UI.Button m_E_UpgradeButton = null;
		private UnityEngine.UI.Image m_E_UpgradeImage = null;
		public Transform uiTransform = null;
	}
}
