using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillLifeShield : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<EntityRef<ES_Shield>> ShieldUIList = new();
		public List<long> HuiShoulist = new ();
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public bool IsDrag;
		public long ClickTime;
		public int ShieldType;
		public bool IsHoldDown;

		public ES_Shield ES_Shield_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_Shield es = this.m_es_shield_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_1");
		    	   this.m_es_shield_1 = this.AddChild<ES_Shield,Transform>(subTrans);
     			}
     			return this.m_es_shield_1;
     		}
     	}

		public ES_Shield ES_Shield_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_Shield es = this.m_es_shield_2;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_2");
		    	   this.m_es_shield_2 = this.AddChild<ES_Shield,Transform>(subTrans);
     			}
     			return this.m_es_shield_2;
     		}
     	}

		public ES_Shield ES_Shield_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_Shield es = this.m_es_shield_3;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_3");
		    	   this.m_es_shield_3 = this.AddChild<ES_Shield,Transform>(subTrans);
     			}
     			return this.m_es_shield_3;
     		}
     	}

		public ES_Shield ES_Shield_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_Shield es = this.m_es_shield_4;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_4");
		    	   this.m_es_shield_4 = this.AddChild<ES_Shield,Transform>(subTrans);
     			}
     			return this.m_es_shield_4;
     		}
     	}

		public ES_Shield ES_Shield_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_Shield es = this.m_es_shield_5;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_5");
		    	   this.m_es_shield_5 = this.AddChild<ES_Shield,Transform>(subTrans);
     			}
     			return this.m_es_shield_5;
     		}
     	}

		public ES_Shield ES_Shield_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_Shield es = this.m_es_shield_6;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_6");
		    	   this.m_es_shield_6 = this.AddChild<ES_Shield,Transform>(subTrans);
     			}
     			return this.m_es_shield_6;
     		}
     	}
		
		public ES_Shield ES_Shield_7
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}

				ES_Shield es = this.m_es_shield_7;
				if( es ==null )
				{
					Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_7");
					this.m_es_shield_7 = this.AddChild<ES_Shield,Transform>(subTrans);
				}
				return this.m_es_shield_7;
			}
		}

		public LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_ZhuRuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhuRuButton == null )
     			{
		    		this.m_E_Btn_ZhuRuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Btn_ZhuRu");
     			}
     			return this.m_E_Btn_ZhuRuButton;
     		}
     	}

		public Image E_Btn_ZhuRuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhuRuImage == null )
     			{
		    		this.m_E_Btn_ZhuRuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Btn_ZhuRu");
     			}
     			return this.m_E_Btn_ZhuRuImage;
     		}
     	}

		public Image E_ImageProgessImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageProgessImage == null )
     			{
		    		this.m_E_ImageProgessImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ImageProgess");
     			}
     			return this.m_E_ImageProgessImage;
     		}
     	}

		public Text E_Text_ShieldNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ShieldNameText == null )
     			{
		    		this.m_E_Text_ShieldNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_ShieldName");
     			}
     			return this.m_E_Text_ShieldNameText;
     		}
     	}

		public Text E_Text_ProgessText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ProgessText == null )
     			{
		    		this.m_E_Text_ProgessText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Progess");
     			}
     			return this.m_E_Text_ProgessText;
     		}
     	}

		public Text E_Text_ShieldDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ShieldDescText == null )
     			{
		    		this.m_E_Text_ShieldDescText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_ShieldDesc");
     			}
     			return this.m_E_Text_ShieldDescText;
     		}
     	}

		public Text E_Text_Zhuru_ExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Zhuru_ExpText == null )
     			{
		    		this.m_E_Text_Zhuru_ExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Zhuru_Exp");
     			}
     			return this.m_E_Text_Zhuru_ExpText;
     		}
     	}

		public Text E_Text_ShieldLevel
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_ShieldLevel == null )
				{
					this.m_E_Text_ShieldLevel = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_ShieldLevel");
				}
				return this.m_E_Text_ShieldLevel;
			}
		}

		public Text E_Text_TotalLevel
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_TotalLevel == null )
				{
					this.m_E_Text_TotalLevel = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_TotalLevel");
				}
				return this.m_E_Text_TotalLevel;
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
			this.m_es_shield_1 = null;
			this.m_es_shield_2 = null;
			this.m_es_shield_3 = null;
			this.m_es_shield_4 = null;
			this.m_es_shield_5 = null;
			this.m_es_shield_6 = null;
			this.m_es_shield_7 = null;
			this.m_E_CommonItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_ZhuRuButton = null;
			this.m_E_Btn_ZhuRuImage = null;
			this.m_E_ImageProgessImage = null;
			this.m_E_Text_ShieldNameText = null;
			this.m_E_Text_ProgessText = null;
			this.m_E_Text_ShieldDescText = null;
			this.m_E_Text_Zhuru_ExpText = null;
			this.m_E_Text_ShieldLevel = null;
			this.m_E_Text_TotalLevel = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_Shield> m_es_shield_1 = null;
		private EntityRef<ES_Shield> m_es_shield_2 = null;
		private EntityRef<ES_Shield> m_es_shield_3 = null;
		private EntityRef<ES_Shield> m_es_shield_4 = null;
		private EntityRef<ES_Shield> m_es_shield_5 = null;
		private EntityRef<ES_Shield> m_es_shield_6 = null;
		private EntityRef<ES_Shield> m_es_shield_7 = null;
		private LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_ZhuRuButton = null;
		private Image m_E_Btn_ZhuRuImage = null;
		private Image m_E_ImageProgessImage = null;
		private Text m_E_Text_ShieldNameText = null;
		private Text m_E_Text_ProgessText = null;
		private Text m_E_Text_ShieldDescText = null;
		private Text m_E_Text_Zhuru_ExpText = null;
		private Text m_E_Text_ShieldLevel = null;
		private Text m_E_Text_TotalLevel = null;
		public Transform uiTransform = null;
	}
}
