﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionRoleXiuLian : Entity,IAwake<Transform>,IDestroy
	{
		public List<EntityRef<ES_UnionXiuLianItem>> UIUnionXiuLianItemList = new();
		public int Position;
		
		public Text E_XiuLianNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiuLianNameText == null )
     			{
		    		this.m_E_XiuLianNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_XiuLianName");
     			}
     			return this.m_E_XiuLianNameText;
     		}
     	}

		public RectTransform EG_XiuLianImageIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_XiuLianImageIconRectTransform == null )
     			{
		    		this.m_EG_XiuLianImageIconRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_XiuLianImageIcon");
     			}
     			return this.m_EG_XiuLianImageIconRectTransform;
     		}
     	}

		public ES_UnionXiuLianItem ES_UnionXiuLianItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionXiuLianItem es = this.m_es_unionxiulianitem_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_UnionXiuLianItem_0");
		    	   this.m_es_unionxiulianitem_0 = this.AddChild<ES_UnionXiuLianItem,Transform>(subTrans);
     			}
     			return this.m_es_unionxiulianitem_0;
     		}
     	}

		public ES_UnionXiuLianItem ES_UnionXiuLianItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionXiuLianItem es = this.m_es_unionxiulianitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_UnionXiuLianItem_1");
		    	   this.m_es_unionxiulianitem_1 = this.AddChild<ES_UnionXiuLianItem,Transform>(subTrans);
     			}
     			return this.m_es_unionxiulianitem_1;
     		}
     	}

		public ES_UnionXiuLianItem ES_UnionXiuLianItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionXiuLianItem es = this.m_es_unionxiulianitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_UnionXiuLianItem_2");
		    	   this.m_es_unionxiulianitem_2 = this.AddChild<ES_UnionXiuLianItem,Transform>(subTrans);
     			}
     			return this.m_es_unionxiulianitem_2;
     		}
     	}

		public ES_UnionXiuLianItem ES_UnionXiuLianItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionXiuLianItem es = this.m_es_unionxiulianitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_UnionXiuLianItem_3");
		    	   this.m_es_unionxiulianitem_3 = this.AddChild<ES_UnionXiuLianItem,Transform>(subTrans);
     			}
     			return this.m_es_unionxiulianitem_3;
     		}
     	}

		public RectTransform EG_Pro_0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Pro_0RectTransform == null )
     			{
		    		this.m_EG_Pro_0RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Pro_0");
     			}
     			return this.m_EG_Pro_0RectTransform;
     		}
     	}

		public RectTransform EG_Pro_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Pro_1RectTransform == null )
     			{
		    		this.m_EG_Pro_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Pro_1");
     			}
     			return this.m_EG_Pro_1RectTransform;
     		}
     	}

		public Button E_Button_DonationButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DonationButton == null )
     			{
		    		this.m_E_Button_DonationButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Donation");
     			}
     			return this.m_E_Button_DonationButton;
     		}
     	}

		public Image E_Button_DonationImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DonationImage == null )
     			{
		    		this.m_E_Button_DonationImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Donation");
     			}
     			return this.m_E_Button_DonationImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
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
			this.m_E_XiuLianNameText = null;
			this.m_EG_XiuLianImageIconRectTransform = null;
			this.m_es_unionxiulianitem_0 = null;
			this.m_es_unionxiulianitem_1 = null;
			this.m_es_unionxiulianitem_2 = null;
			this.m_es_unionxiulianitem_3 = null;
			this.m_EG_Pro_0RectTransform = null;
			this.m_EG_Pro_1RectTransform = null;
			this.m_E_Button_DonationButton = null;
			this.m_E_Button_DonationImage = null;
			this.m_es_costlist = null;
			this.uiTransform = null;
		}

		private Text m_E_XiuLianNameText = null;
		private RectTransform m_EG_XiuLianImageIconRectTransform = null;
		private EntityRef<ES_UnionXiuLianItem> m_es_unionxiulianitem_0 = null;
		private EntityRef<ES_UnionXiuLianItem> m_es_unionxiulianitem_1 = null;
		private EntityRef<ES_UnionXiuLianItem> m_es_unionxiulianitem_2 = null;
		private EntityRef<ES_UnionXiuLianItem> m_es_unionxiulianitem_3 = null;
		private RectTransform m_EG_Pro_0RectTransform = null;
		private RectTransform m_EG_Pro_1RectTransform = null;
		private Button m_E_Button_DonationButton = null;
		private Image m_E_Button_DonationImage = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		public Transform uiTransform = null;
	}
}
