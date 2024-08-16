using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JueXingShow : Entity,IAwake<Transform>,IDestroy
	{
		public List<ES_JueXingShowItem> UIJueXingShowItems { get; set; } = new();
		public int JueXingId;
		
		public ES_JueXingShowItem ES_JueXingShowItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_0");
		    	   this.m_es_juexingshowitem_0 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_0;
     		}
     	}

		public ES_JueXingShowItem ES_JueXingShowItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_1");
		    	   this.m_es_juexingshowitem_1 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_1;
     		}
     	}

		public ES_JueXingShowItem ES_JueXingShowItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_2");
		    	   this.m_es_juexingshowitem_2 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_2;
     		}
     	}

		public ES_JueXingShowItem ES_JueXingShowItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_3");
		    	   this.m_es_juexingshowitem_3 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_3;
     		}
     	}

		public ES_JueXingShowItem ES_JueXingShowItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_4;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_4");
		    	   this.m_es_juexingshowitem_4 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_4;
     		}
     	}

		public ES_JueXingShowItem ES_JueXingShowItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_5;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_5");
		    	   this.m_es_juexingshowitem_5 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_5;
     		}
     	}

		public ES_JueXingShowItem ES_JueXingShowItem_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_6;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_6");
		    	   this.m_es_juexingshowitem_6 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_6;
     		}
     	}

		public ES_JueXingShowItem ES_JueXingShowItem_7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JueXingShowItem es = this.m_es_juexingshowitem_7;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JueXingShowItem_7");
		    	   this.m_es_juexingshowitem_7 = this.AddChild<ES_JueXingShowItem,Transform>(subTrans);
     			}
     			return this.m_es_juexingshowitem_7;
     		}
     	}

		public Image E_ImageSkillIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSkillIconImage == null )
     			{
		    		this.m_E_ImageSkillIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/SkillItem/ImageMask/E_ImageSkillIcon");
     			}
     			return this.m_E_ImageSkillIconImage;
     		}
     	}

		public EventTrigger E_ImageSkillIconEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSkillIconEventTrigger == null )
     			{
		    		this.m_E_ImageSkillIconEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/SkillItem/ImageMask/E_ImageSkillIcon");
     			}
     			return this.m_E_ImageSkillIconEventTrigger;
     		}
     	}

		public Text E_TextSkillNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextSkillNameText == null )
     			{
		    		this.m_E_TextSkillNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/SkillItem/E_TextSkillName");
     			}
     			return this.m_E_TextSkillNameText;
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

		public Button E_ButtonActiveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonActiveButton == null )
     			{
		    		this.m_E_ButtonActiveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ButtonActive");
     			}
     			return this.m_E_ButtonActiveButton;
     		}
     	}

		public Image E_ButtonActiveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonActiveImage == null )
     			{
		    		this.m_E_ButtonActiveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ButtonActive");
     			}
     			return this.m_E_ButtonActiveImage;
     		}
     	}

		public Image E_ImageJueXingExpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageJueXingExpImage == null )
     			{
		    		this.m_E_ImageJueXingExpImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ImageJueXingExp");
     			}
     			return this.m_E_ImageJueXingExpImage;
     		}
     	}

		public Text E_Text_11Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_11Text == null )
     			{
		    		this.m_E_Text_11Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_11");
     			}
     			return this.m_E_Text_11Text;
     		}
     	}

		public Text E_Text_GoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_GoldText == null )
     			{
		    		this.m_E_Text_GoldText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Gold");
     			}
     			return this.m_E_Text_GoldText;
     		}
     	}

		public Text E_Text_JueXingExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_JueXingExpText == null )
     			{
		    		this.m_E_Text_JueXingExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_JueXingExp");
     			}
     			return this.m_E_Text_JueXingExpText;
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
			this.m_es_juexingshowitem_0 = null;
			this.m_es_juexingshowitem_1 = null;
			this.m_es_juexingshowitem_2 = null;
			this.m_es_juexingshowitem_3 = null;
			this.m_es_juexingshowitem_4 = null;
			this.m_es_juexingshowitem_5 = null;
			this.m_es_juexingshowitem_6 = null;
			this.m_es_juexingshowitem_7 = null;
			this.m_E_ImageSkillIconImage = null;
			this.m_E_ImageSkillIconEventTrigger = null;
			this.m_E_TextSkillNameText = null;
			this.m_es_costlist = null;
			this.m_E_ButtonActiveButton = null;
			this.m_E_ButtonActiveImage = null;
			this.m_E_ImageJueXingExpImage = null;
			this.m_E_Text_11Text = null;
			this.m_E_Text_GoldText = null;
			this.m_E_Text_JueXingExpText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_0 = null;
		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_1 = null;
		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_2 = null;
		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_3 = null;
		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_4 = null;
		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_5 = null;
		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_6 = null;
		private EntityRef<ES_JueXingShowItem> m_es_juexingshowitem_7 = null;
		private Image m_E_ImageSkillIconImage = null;
		private EventTrigger m_E_ImageSkillIconEventTrigger = null;
		private Text m_E_TextSkillNameText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private Button m_E_ButtonActiveButton = null;
		private Image m_E_ButtonActiveImage = null;
		private Image m_E_ImageJueXingExpImage = null;
		private Text m_E_Text_11Text = null;
		private Text m_E_Text_GoldText = null;
		private Text m_E_Text_JueXingExpText = null;
		public Transform uiTransform = null;
	}
}
