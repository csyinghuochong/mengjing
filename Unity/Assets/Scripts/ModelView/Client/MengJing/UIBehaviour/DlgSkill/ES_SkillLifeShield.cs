
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillLifeShield : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<ES_Shield> ShieldUIList = new();
		public List<ES_CommonItem> HuiShoulist = new ();
		public List<BagInfo> ShowBagInfos = new();
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
		public bool IsDrag;
		public long ClickTime;
		public int ShieldType;
		public bool IsHoldDown;
		
		public ES_CommonItem ES_CommonItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_1.Equals(null) )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem_1");
		    	   this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_1;
     		}
     	}

		public ES_CommonItem ES_CommonItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_2 .Equals(null) )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public ES_CommonItem ES_CommonItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_3.Equals(null))
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem_3");
		    	   this.m_es_commonitem_3 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_3;
     		}
     	}

		public ES_CommonItem ES_CommonItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_4 .Equals(null) )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem_4");
		    	   this.m_es_commonitem_4 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_4;
     		}
     	}

		public ES_CommonItem ES_CommonItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem_5 .Equals(null)  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem_5");
		    	   this.m_es_commonitem_5 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_5;
     		}
     	}

		public ES_Shield ES_Shield_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_shield_1 .Equals(null) )
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
     			if( this.m_es_shield_2 .Equals(null))
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
     			if( this.m_es_shield_3.Equals(null) )
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
     			if( this.m_es_shield_4 .Equals(null))
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
     			if( this.m_es_shield_5 .Equals(null) )
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
     			if( this.m_es_shield_6 .Equals(null) )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_Shield_6");
		    	   this.m_es_shield_6 = this.AddChild<ES_Shield,Transform>(subTrans);
     			}
     			return this.m_es_shield_6;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
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
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ZhuRuButton
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
		    		this.m_E_Btn_ZhuRuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ZhuRu");
     			}
     			return this.m_E_Btn_ZhuRuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhuRuImage
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
		    		this.m_E_Btn_ZhuRuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ZhuRu");
     			}
     			return this.m_E_Btn_ZhuRuImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageProgessImage
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
		    		this.m_E_ImageProgessImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ImageProgess");
     			}
     			return this.m_E_ImageProgessImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ShieldNameText
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
		    		this.m_E_Text_ShieldNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_ShieldName");
     			}
     			return this.m_E_Text_ShieldNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ProgessText
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
		    		this.m_E_Text_ProgessText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Progess");
     			}
     			return this.m_E_Text_ProgessText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ShieldDescText
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
		    		this.m_E_Text_ShieldDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_ShieldDesc");
     			}
     			return this.m_E_Text_ShieldDescText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Zhuru_ExpText
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
		    		this.m_E_Text_Zhuru_ExpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Zhuru_Exp");
     			}
     			return this.m_E_Text_Zhuru_ExpText;
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
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_es_commonitem_3 = null;
			this.m_es_commonitem_4 = null;
			this.m_es_commonitem_5 = null;
			this.m_es_shield_1 = null;
			this.m_es_shield_2 = null;
			this.m_es_shield_3 = null;
			this.m_es_shield_4 = null;
			this.m_es_shield_5 = null;
			this.m_es_shield_6 = null;
			this.m_E_CommonItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_ZhuRuButton = null;
			this.m_E_Btn_ZhuRuImage = null;
			this.m_E_ImageProgessImage = null;
			this.m_E_Text_ShieldNameText = null;
			this.m_E_Text_ProgessText = null;
			this.m_E_Text_ShieldDescText = null;
			this.m_E_Text_Zhuru_ExpText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_3 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_4 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_5 = null;
		private EntityRef<ES_Shield> m_es_shield_1 = null;
		private EntityRef<ES_Shield> m_es_shield_2 = null;
		private EntityRef<ES_Shield> m_es_shield_3 = null;
		private EntityRef<ES_Shield> m_es_shield_4 = null;
		private EntityRef<ES_Shield> m_es_shield_5 = null;
		private EntityRef<ES_Shield> m_es_shield_6 = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_ZhuRuButton = null;
		private UnityEngine.UI.Image m_E_Btn_ZhuRuImage = null;
		private UnityEngine.UI.Image m_E_ImageProgessImage = null;
		private UnityEngine.UI.Text m_E_Text_ShieldNameText = null;
		private UnityEngine.UI.Text m_E_Text_ProgessText = null;
		private UnityEngine.UI.Text m_E_Text_ShieldDescText = null;
		private UnityEngine.UI.Text m_E_Text_Zhuru_ExpText = null;
		public Transform uiTransform = null;
	}
}
