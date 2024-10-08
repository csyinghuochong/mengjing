
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillTianFu : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<EntityRef<ES_SkillTianFuItem>> Items = new();
		public int Position;
		
		public UnityEngine.UI.ToggleGroup E_TitleSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleSetToggleGroup == null )
     			{
		    		this.m_E_TitleSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_TitleSet");
     			}
     			return this.m_E_TitleSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_Btn_TianFu_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Toggle == null )
     			{
		    		this.m_E_Btn_TianFu_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Btn_TianFu_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Toggle == null )
     			{
		    		this.m_E_Btn_TianFu_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Toggle;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public ES_SkillTianFuItem ES_SkillTianFuItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFuItem es = this.m_es_skilltianfuitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/Content/ES_SkillTianFuItem_1");
		    	   this.m_es_skilltianfuitem_1 = this.AddChild<ES_SkillTianFuItem,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfuitem_1;
     		}
     	}

		public ES_SkillTianFuItem ES_SkillTianFuItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFuItem es = this.m_es_skilltianfuitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/Content/ES_SkillTianFuItem_2");
		    	   this.m_es_skilltianfuitem_2 = this.AddChild<ES_SkillTianFuItem,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfuitem_2;
     		}
     	}

		public ES_SkillTianFuItem ES_SkillTianFuItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFuItem es = this.m_es_skilltianfuitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/Content/ES_SkillTianFuItem_3");
		    	   this.m_es_skilltianfuitem_3 = this.AddChild<ES_SkillTianFuItem,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfuitem_3;
     		}
     	}

		public ES_SkillTianFuItem ES_SkillTianFuItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFuItem es = this.m_es_skilltianfuitem_4;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/Content/ES_SkillTianFuItem_4");
		    	   this.m_es_skilltianfuitem_4 = this.AddChild<ES_SkillTianFuItem,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfuitem_4;
     		}
     	}

		public ES_SkillTianFuItem ES_SkillTianFuItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFuItem es = this.m_es_skilltianfuitem_5;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/Content/ES_SkillTianFuItem_5");
		    	   this.m_es_skilltianfuitem_5 = this.AddChild<ES_SkillTianFuItem,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfuitem_5;
     		}
     	}

		public ES_SkillTianFuItem ES_SkillTianFuItem_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFuItem es = this.m_es_skilltianfuitem_6;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/Content/ES_SkillTianFuItem_6");
		    	   this.m_es_skilltianfuitem_6 = this.AddChild<ES_SkillTianFuItem,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfuitem_6;
     		}
     	}

		public ES_SkillTianFuItem ES_SkillTianFuItem_7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillTianFuItem es = this.m_es_skilltianfuitem_7;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/Content/ES_SkillTianFuItem_7");
		    	   this.m_es_skilltianfuitem_7 = this.AddChild<ES_SkillTianFuItem,Transform>(subTrans);
     			}
     			return this.m_es_skilltianfuitem_7;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ActiveTianFuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ActiveTianFuButton == null )
     			{
		    		this.m_E_Btn_ActiveTianFuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ActiveTianFu");
     			}
     			return this.m_E_Btn_ActiveTianFuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ActiveTianFuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ActiveTianFuImage == null )
     			{
		    		this.m_E_Btn_ActiveTianFuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ActiveTianFu");
     			}
     			return this.m_E_Btn_ActiveTianFuImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextDesc1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextDesc1Text == null )
     			{
		    		this.m_E_TextDesc1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextDesc1");
     			}
     			return this.m_E_TextDesc1Text;
     		}
     	}

		public UnityEngine.RectTransform EG_DescListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DescListNodeRectTransform == null )
     			{
		    		this.m_EG_DescListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_DescListNode");
     			}
     			return this.m_EG_DescListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_SkillNameText == null )
     			{
		    		this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_SkillName");
     			}
     			return this.m_E_Lab_SkillNameText;
     		}
     	}

		public UnityEngine.UI.Image E_TianFuIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TianFuIconImage == null )
     			{
		    		this.m_E_TianFuIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_TianFuIcon");
     			}
     			return this.m_E_TianFuIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NeedLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NeedLvText == null )
     			{
		    		this.m_E_Text_NeedLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_NeedLv");
     			}
     			return this.m_E_Text_NeedLvText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TianFuLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TianFuLevelText == null )
     			{
		    		this.m_E_Lab_TianFuLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_TianFuLevel");
     			}
     			return this.m_E_Lab_TianFuLevelText;
     		}
     	}

		public UnityEngine.UI.Button E_ReSetTianFuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetTianFuButton == null )
     			{
		    		this.m_E_ReSetTianFuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ReSetTianFu");
     			}
     			return this.m_E_ReSetTianFuButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReSetTianFuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetTianFuImage == null )
     			{
		    		this.m_E_ReSetTianFuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ReSetTianFu");
     			}
     			return this.m_E_ReSetTianFuImage;
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
			this.m_E_TitleSetToggleGroup = null;
			this.m_E_Btn_TianFu_1Toggle = null;
			this.m_E_Btn_TianFu_2Toggle = null;
			this.m_E_ImageSelectImage = null;
			this.m_es_skilltianfuitem_1 = null;
			this.m_es_skilltianfuitem_2 = null;
			this.m_es_skilltianfuitem_3 = null;
			this.m_es_skilltianfuitem_4 = null;
			this.m_es_skilltianfuitem_5 = null;
			this.m_es_skilltianfuitem_6 = null;
			this.m_es_skilltianfuitem_7 = null;
			this.m_E_Btn_ActiveTianFuButton = null;
			this.m_E_Btn_ActiveTianFuImage = null;
			this.m_E_TextDesc1Text = null;
			this.m_EG_DescListNodeRectTransform = null;
			this.m_E_Lab_SkillNameText = null;
			this.m_E_TianFuIconImage = null;
			this.m_E_Text_NeedLvText = null;
			this.m_E_Lab_TianFuLevelText = null;
			this.m_E_ReSetTianFuButton = null;
			this.m_E_ReSetTianFuImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_TitleSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Btn_TianFu_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_Btn_TianFu_2Toggle = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private EntityRef<ES_SkillTianFuItem> m_es_skilltianfuitem_1 = null;
		private EntityRef<ES_SkillTianFuItem> m_es_skilltianfuitem_2 = null;
		private EntityRef<ES_SkillTianFuItem> m_es_skilltianfuitem_3 = null;
		private EntityRef<ES_SkillTianFuItem> m_es_skilltianfuitem_4 = null;
		private EntityRef<ES_SkillTianFuItem> m_es_skilltianfuitem_5 = null;
		private EntityRef<ES_SkillTianFuItem> m_es_skilltianfuitem_6 = null;
		private EntityRef<ES_SkillTianFuItem> m_es_skilltianfuitem_7 = null;
		private UnityEngine.UI.Button m_E_Btn_ActiveTianFuButton = null;
		private UnityEngine.UI.Image m_E_Btn_ActiveTianFuImage = null;
		private UnityEngine.UI.Text m_E_TextDesc1Text = null;
		private UnityEngine.RectTransform m_EG_DescListNodeRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_SkillNameText = null;
		private UnityEngine.UI.Image m_E_TianFuIconImage = null;
		private UnityEngine.UI.Text m_E_Text_NeedLvText = null;
		private UnityEngine.UI.Text m_E_Lab_TianFuLevelText = null;
		private UnityEngine.UI.Button m_E_ReSetTianFuButton = null;
		private UnityEngine.UI.Image m_E_ReSetTianFuImage = null;
		public Transform uiTransform = null;
	}
}
