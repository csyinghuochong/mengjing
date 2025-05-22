using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianLevel : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<EntityRef<ES_RoleXiLianLevelItem>> UIRoleXiLianLevels = new();
		public int EquipXilianId;
		public long Timer;

		public float ItemWidth = 1400f;
		public float MoveSpeed = 100f;
		
		public UnityEngine.RectTransform EG_LevelListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LevelListNodeRectTransform == null )
     			{
		    		this.m_EG_LevelListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_LevelListNode");
     			}
     			return this.m_EG_LevelListNodeRectTransform;
     		}
     	}

		public ES_RoleXiLianLevelItem ES_RoleXiLianLevelItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RoleXiLianLevelItem es = this.m_es_rolexilianlevelitem_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/EG_LevelListNode/ES_RoleXiLianLevelItem_0");
		    	   this.m_es_rolexilianlevelitem_0 = this.AddChild<ES_RoleXiLianLevelItem,Transform>(subTrans);
     			}
     			return this.m_es_rolexilianlevelitem_0;
     		}
     	}

		public ES_RoleXiLianLevelItem ES_RoleXiLianLevelItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RoleXiLianLevelItem es = this.m_es_rolexilianlevelitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/EG_LevelListNode/ES_RoleXiLianLevelItem_1");
		    	   this.m_es_rolexilianlevelitem_1 = this.AddChild<ES_RoleXiLianLevelItem,Transform>(subTrans);
     			}
     			return this.m_es_rolexilianlevelitem_1;
     		}
     	}

		public ES_RoleXiLianLevelItem ES_RoleXiLianLevelItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RoleXiLianLevelItem es = this.m_es_rolexilianlevelitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/EG_LevelListNode/ES_RoleXiLianLevelItem_2");
		    	   this.m_es_rolexilianlevelitem_2 = this.AddChild<ES_RoleXiLianLevelItem,Transform>(subTrans);
     			}
     			return this.m_es_rolexilianlevelitem_2;
     		}
     	}

		public UnityEngine.UI.Button E_Button_LeftButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_LeftButton == null )
     			{
		    		this.m_E_Button_LeftButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_Left");
     			}
     			return this.m_E_Button_LeftButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_LeftImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_LeftImage == null )
     			{
		    		this.m_E_Button_LeftImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_Left");
     			}
     			return this.m_E_Button_LeftImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RightButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RightButton == null )
     			{
		    		this.m_E_Button_RightButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_Right");
     			}
     			return this.m_E_Button_RightButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RightImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RightImage == null )
     			{
		    		this.m_E_Button_RightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_Right");
     			}
     			return this.m_E_Button_RightImage;
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
			this.m_EG_LevelListNodeRectTransform = null;
			this.m_es_rolexilianlevelitem_0 = null;
			this.m_es_rolexilianlevelitem_1 = null;
			this.m_es_rolexilianlevelitem_2 = null;
			this.m_E_Button_LeftButton = null;
			this.m_E_Button_LeftImage = null;
			this.m_E_Button_RightButton = null;
			this.m_E_Button_RightImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LevelListNodeRectTransform = null;
		private EntityRef<ES_RoleXiLianLevelItem> m_es_rolexilianlevelitem_0 = null;
		private EntityRef<ES_RoleXiLianLevelItem> m_es_rolexilianlevelitem_1 = null;
		private EntityRef<ES_RoleXiLianLevelItem> m_es_rolexilianlevelitem_2 = null;
		private UnityEngine.UI.Button m_E_Button_LeftButton = null;
		private UnityEngine.UI.Image m_E_Button_LeftImage = null;
		private UnityEngine.UI.Button m_E_Button_RightButton = null;
		private UnityEngine.UI.Image m_E_Button_RightImage = null;
		public Transform uiTransform = null;
	}
}
