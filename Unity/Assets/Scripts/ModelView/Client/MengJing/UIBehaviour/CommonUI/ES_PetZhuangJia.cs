
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetZhuangJia : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<EntityRef<ES_PetZhuangJiaItem>> UIPetZhuangJiaItemList = new();
		public int Position;
		
		public ES_PetZhuangJiaItem ES_PetZhuangJiaItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetZhuangJiaItem es = this.m_es_petzhuangjiaitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetZhuangJiaItem_1");
		    	   this.m_es_petzhuangjiaitem_1 = this.AddChild<ES_PetZhuangJiaItem,Transform>(subTrans);
     			}
     			return this.m_es_petzhuangjiaitem_1;
     		}
     	}

		public ES_PetZhuangJiaItem ES_PetZhuangJiaItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetZhuangJiaItem es = this.m_es_petzhuangjiaitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetZhuangJiaItem_2");
		    	   this.m_es_petzhuangjiaitem_2 = this.AddChild<ES_PetZhuangJiaItem,Transform>(subTrans);
     			}
     			return this.m_es_petzhuangjiaitem_2;
     		}
     	}

		public ES_PetZhuangJiaItem ES_PetZhuangJiaItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetZhuangJiaItem es = this.m_es_petzhuangjiaitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetZhuangJiaItem_3");
		    	   this.m_es_petzhuangjiaitem_3 = this.AddChild<ES_PetZhuangJiaItem,Transform>(subTrans);
     			}
     			return this.m_es_petzhuangjiaitem_3;
     		}
     	}

		public ES_PetZhuangJiaItem ES_PetZhuangJiaItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetZhuangJiaItem es = this.m_es_petzhuangjiaitem_4;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetZhuangJiaItem_4");
		    	   this.m_es_petzhuangjiaitem_4 = this.AddChild<ES_PetZhuangJiaItem,Transform>(subTrans);
     			}
     			return this.m_es_petzhuangjiaitem_4;
     		}
     	}

		public ES_PetZhuangJiaItem ES_PetZhuangJiaItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetZhuangJiaItem es = this.m_es_petzhuangjiaitem_5;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetZhuangJiaItem_5");
		    	   this.m_es_petzhuangjiaitem_5 = this.AddChild<ES_PetZhuangJiaItem,Transform>(subTrans);
     			}
     			return this.m_es_petzhuangjiaitem_5;
     		}
     	}

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Icon");
     			}
     			return this.m_E_IconImage;
     		}
     	}

		public UnityEngine.UI.Text E_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameText == null )
     			{
		    		this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Name");
     			}
     			return this.m_E_NameText;
     		}
     	}

		public UnityEngine.UI.Text E_NowLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NowLvText == null )
     			{
		    		this.m_E_NowLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_NowLv");
     			}
     			return this.m_E_NowLvText;
     		}
     	}

		public UnityEngine.RectTransform EG_ProListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ProListRectTransform == null )
     			{
		    		this.m_EG_ProListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_ProList");
     			}
     			return this.m_EG_ProListRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_ProText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProText == null )
     			{
		    		this.m_E_ProText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Pro");
     			}
     			return this.m_E_ProText;
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

		public UnityEngine.UI.Button E_UpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpButton == null )
     			{
		    		this.m_E_UpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Up");
     			}
     			return this.m_E_UpButton;
     		}
     	}

		public UnityEngine.UI.Image E_UpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpImage == null )
     			{
		    		this.m_E_UpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Up");
     			}
     			return this.m_E_UpImage;
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
			this.m_es_petzhuangjiaitem_1 = null;
			this.m_es_petzhuangjiaitem_2 = null;
			this.m_es_petzhuangjiaitem_3 = null;
			this.m_es_petzhuangjiaitem_4 = null;
			this.m_es_petzhuangjiaitem_5 = null;
			this.m_E_IconImage = null;
			this.m_E_NameText = null;
			this.m_E_NowLvText = null;
			this.m_EG_ProListRectTransform = null;
			this.m_E_ProText = null;
			this.m_es_costlist = null;
			this.m_E_UpButton = null;
			this.m_E_UpImage = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_PetZhuangJiaItem> m_es_petzhuangjiaitem_1 = null;
		private EntityRef<ES_PetZhuangJiaItem> m_es_petzhuangjiaitem_2 = null;
		private EntityRef<ES_PetZhuangJiaItem> m_es_petzhuangjiaitem_3 = null;
		private EntityRef<ES_PetZhuangJiaItem> m_es_petzhuangjiaitem_4 = null;
		private EntityRef<ES_PetZhuangJiaItem> m_es_petzhuangjiaitem_5 = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		private UnityEngine.UI.Text m_E_NowLvText = null;
		private UnityEngine.RectTransform m_EG_ProListRectTransform = null;
		private UnityEngine.UI.Text m_E_ProText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private UnityEngine.UI.Button m_E_UpButton = null;
		private UnityEngine.UI.Image m_E_UpImage = null;
		public Transform uiTransform = null;
	}
}
