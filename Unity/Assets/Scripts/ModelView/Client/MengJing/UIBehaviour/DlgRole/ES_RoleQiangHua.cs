using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleQiangHua : Entity,IAwake<Transform>,IDestroy 
	{
		public int ItemSubType;
		public List<EntityRef<ES_RoleQiangHuaItem>> QiangHuaItemList = new();
		
		public Image E_ImageSelectImage
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EquipSet/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemWuqi_1");
		    	   this.m_es_roleqianghuaitem_1 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_1;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_2;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemYifu_1");
		    	   this.m_es_roleqianghuaitem_2 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_2;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_3;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemFuhu_1");
		    	   this.m_es_roleqianghuaitem_3 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_3;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_4;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemJiezhi_1");
		    	   this.m_es_roleqianghuaitem_4 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_4;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_5;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemShiping1_1");
		    	   this.m_es_roleqianghuaitem_5 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_5;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_6;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemXiezi_1");
		    	   this.m_es_roleqianghuaitem_6 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_6;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_7;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemKuzi_1");
		    	   this.m_es_roleqianghuaitem_7 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_7;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_8
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_8;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemYaodai_1");
		    	   this.m_es_roleqianghuaitem_8 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_8;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_9
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_9;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemShouzhuo_1");
		    	   this.m_es_roleqianghuaitem_9 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_9;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_10
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_10;
     			if( es==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemToukui_1");
		    	   this.m_es_roleqianghuaitem_10 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_10;
     		}
     	}

		public ES_RoleQiangHuaItem ES_RoleQiangHuaItem_11
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RoleQiangHuaItem es = this.m_es_roleqianghuaitem_11;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EquipSet/ES_EquipItemXianglian_1");
		    	   this.m_es_roleqianghuaitem_11 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_11;
     		}
     	}

		public RectTransform EG_QiangHuaLevelListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_QiangHuaLevelListRectTransform == null )
     			{
		    		this.m_EG_QiangHuaLevelListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_QiangHuaLevelList");
     			}
     			return this.m_EG_QiangHuaLevelListRectTransform;
     		}
     	}

		public ES_EquipSetItem ES_EquipSetItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipSetItem es = this.m_es_equipsetitem;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_EquipSetItem");
		    	   this.m_es_equipsetitem = this.AddChild<ES_EquipSetItem,Transform>(subTrans);
     			}
     			return this.m_es_equipsetitem;
     		}
     	}

		public RectTransform EG_MaxNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MaxNodeRectTransform == null )
     			{
		    		this.m_EG_MaxNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_MaxNode");
     			}
     			return this.m_EG_MaxNodeRectTransform;
     		}
     	}

		public RectTransform EG_NextNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_NextNodeRectTransform == null )
     			{
		    		this.m_EG_NextNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_NextNode");
     			}
     			return this.m_EG_NextNodeRectTransform;
     		}
     	}

		public Button E_QiangHuaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaButton == null )
     			{
		    		this.m_E_QiangHuaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_NextNode/E_QiangHua");
     			}
     			return this.m_E_QiangHuaButton;
     		}
     	}

		public Image E_QiangHuaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaImage == null )
     			{
		    		this.m_E_QiangHuaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_NextNode/E_QiangHua");
     			}
     			return this.m_E_QiangHuaImage;
     		}
     	}

		public Text E_Attribute2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Attribute2Text == null )
     			{
		    		this.m_E_Attribute2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_Attribute2");
     			}
     			return this.m_E_Attribute2Text;
     		}
     	}

		public Text E_SuccessRateText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SuccessRateText == null )
     			{
		    		this.m_E_SuccessRateText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_SuccessRate");
     			}
     			return this.m_E_SuccessRateText;
     		}
     	}

		public Text E_SuccessAdditionText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SuccessAdditionText == null )
     			{
		    		this.m_E_SuccessAdditionText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_SuccessAddition");
     			}
     			return this.m_E_SuccessAdditionText;
     		}
     	}

		public Text E_CostTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostTipText == null )
     			{
		    		this.m_E_CostTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_CostTip");
     			}
     			return this.m_E_CostTipText;
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_NextNode/ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
     		}
     	}
		
		

		public Text E_Attribute1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Attribute1Text == null )
     			{
		    		this.m_E_Attribute1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Attribute1");
     			}
     			return this.m_E_Attribute1Text;
     		}
     	}

		public Toggle E_ToggleLucky
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_ToggleLucky == null )
				{
					this.m_E_ToggleLucky = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"Right/EG_NextNode/E_ToggleLucky");
				}
				return this.m_E_ToggleLucky;
			}
		}

		public Image E_Img_LodingValue
        {
        	get
        	{
        		if (this.uiTransform == null)		
        		{
        			Log.Error("uiTransform is null.");
        			return null;
        		}
        		if( this.m_E_Img_LodingValue == null )
        		{
        			this.m_E_Img_LodingValue = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_NextNode/E_Img_LodingValue");
        		}
        		return this.m_E_Img_LodingValue;
        	}
        }

		public Text E_QiangHuaNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaNameText == null )
     			{
		    		this.m_E_QiangHuaNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_QiangHuaName");
     			}
     			return this.m_E_QiangHuaNameText;
     		}
     	}

		public Text E_QiangItemNameText
     	{
	        get
	        {
		        if (this.uiTransform == null)
		        {
			        Log.Error("uiTransform is null.");
			        return null;
		        }
		        if( this.m_E_QiangItemNameText == null )
		        {
			        this.m_E_QiangItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_QiangItemName");
		        }
		        return this.m_E_QiangItemNameText;
	        }
     	}

		public Text E_TextGold
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_TextGold == null )
				{
					this.m_E_TextGold = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_TextGold");
				}
				return this.m_E_TextGold;
			}
		}

		public Text E_QiangHuaLevel
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_QiangHuaLevel == null )
				{
					this.m_E_QiangHuaLevel = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_QiangHuaLevel");
				}
				return this.m_E_QiangHuaLevel;
			}
		}

		public Text E_QiangHuaProgress
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_QiangHuaProgress == null )
				{
					this.m_E_QiangHuaProgress = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_QiangHuaProgress");
				}
				return this.m_E_QiangHuaProgress;
			}
		}

		public void DestroyWidget()
		{
			this.m_E_ImageSelectImage = null;
			this.m_es_roleqianghuaitem_1 = null;
			this.m_es_roleqianghuaitem_2 = null;
			this.m_es_roleqianghuaitem_3 = null;
			this.m_es_roleqianghuaitem_4 = null;
			this.m_es_roleqianghuaitem_5 = null;
			this.m_es_roleqianghuaitem_6 = null;
			this.m_es_roleqianghuaitem_7 = null;
			this.m_es_roleqianghuaitem_8 = null;
			this.m_es_roleqianghuaitem_9 = null;
			this.m_es_roleqianghuaitem_10 = null;
			this.m_es_roleqianghuaitem_11 = null;
			this.m_EG_QiangHuaLevelListRectTransform = null;
			this.m_es_equipsetitem = null;
			this.m_EG_MaxNodeRectTransform = null;
			this.m_EG_NextNodeRectTransform = null;
			this.m_E_QiangHuaButton = null;
			this.m_E_QiangHuaImage = null;
			this.m_E_Attribute2Text = null;
			this.m_E_SuccessRateText = null;
			this.m_E_SuccessAdditionText = null;
			this.m_E_CostTipText = null;
			this.m_es_costlist = null;
			this.m_E_Attribute1Text = null;
			this.m_E_QiangHuaNameText = null;
			this.m_E_QiangItemNameText = null;
			this.m_E_TextGold = null;
			this.m_E_ToggleLucky = null;
			this.m_E_QiangHuaLevel = null;
			this.m_E_Img_LodingValue = null;
			this.m_E_QiangHuaProgress = null;
			this.uiTransform = null;
		}

		private Image m_E_ImageSelectImage = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_1 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_2 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_3 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_4 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_5 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_6 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_7 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_8 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_9 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_10 = null;
		private EntityRef<ES_RoleQiangHuaItem> m_es_roleqianghuaitem_11 = null;
		private RectTransform m_EG_QiangHuaLevelListRectTransform = null;
		private EntityRef<ES_EquipSetItem> m_es_equipsetitem = null;
		private RectTransform m_EG_MaxNodeRectTransform = null;
		private RectTransform m_EG_NextNodeRectTransform = null;
		private Button m_E_QiangHuaButton = null;
		private Image m_E_QiangHuaImage = null;
		private Text m_E_Attribute2Text = null;
		private Text m_E_SuccessRateText = null;
		private Text m_E_SuccessAdditionText = null;
		private Text m_E_CostTipText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private Text m_E_Attribute1Text = null;
		private Text m_E_QiangHuaNameText = null;
		private Text m_E_QiangItemNameText = null;
		private Text m_E_TextGold = null;
		private Text m_E_QiangHuaLevel = null;
		private Toggle m_E_ToggleLucky= null;
		private Image m_E_Img_LodingValue = null;
		private Text m_E_QiangHuaProgress = null;
		public Transform uiTransform = null;
	}
}
