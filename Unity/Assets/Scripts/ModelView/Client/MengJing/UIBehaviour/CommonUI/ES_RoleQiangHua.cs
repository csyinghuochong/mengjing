﻿
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleQiangHua : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int ItemSubType;
		public List<ES_RoleQiangHuaItem> QiangHuaItemList = new();
		
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EquipSet/E_ImageSelect");
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
     			if( this.m_es_roleqianghuaitem_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_1");
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
     			if( this.m_es_roleqianghuaitem_2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_2");
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
     			if( this.m_es_roleqianghuaitem_3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_3");
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
     			if( this.m_es_roleqianghuaitem_4 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_4");
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
     			if( this.m_es_roleqianghuaitem_5 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_5");
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
     			if( this.m_es_roleqianghuaitem_6 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_6");
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
     			if( this.m_es_roleqianghuaitem_7 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_7");
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
     			if( this.m_es_roleqianghuaitem_8 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_8");
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
     			if( this.m_es_roleqianghuaitem_9 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_9");
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
     			if( this.m_es_roleqianghuaitem_10 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_10");
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
     			if( this.m_es_roleqianghuaitem_11 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_RoleQiangHuaItem_11");
		    	   this.m_es_roleqianghuaitem_11 = this.AddChild<ES_RoleQiangHuaItem,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghuaitem_11;
     		}
     	}

		public UnityEngine.RectTransform EG_QiangHuaLevelListRectTransform
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
		    		this.m_EG_QiangHuaLevelListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_QiangHuaLevelList");
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
     			if( this.m_es_equipsetitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_EquipSetItem");
		    	   this.m_es_equipsetitem = this.AddChild<ES_EquipSetItem,Transform>(subTrans);
     			}
     			return this.m_es_equipsetitem;
     		}
     	}

		public UnityEngine.RectTransform EG_MaxNodeRectTransform
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
		    		this.m_EG_MaxNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_MaxNode");
     			}
     			return this.m_EG_MaxNodeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_NextNodeRectTransform
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
		    		this.m_EG_NextNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_NextNode");
     			}
     			return this.m_EG_NextNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_QiangHuaButton
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
		    		this.m_E_QiangHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_NextNode/E_QiangHua");
     			}
     			return this.m_E_QiangHuaButton;
     		}
     	}

		public UnityEngine.UI.Image E_QiangHuaImage
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
		    		this.m_E_QiangHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_NextNode/E_QiangHua");
     			}
     			return this.m_E_QiangHuaImage;
     		}
     	}

		public UnityEngine.UI.Text E_Attribute2Text
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
		    		this.m_E_Attribute2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_Attribute2");
     			}
     			return this.m_E_Attribute2Text;
     		}
     	}

		public UnityEngine.UI.Text E_SuccessRateText
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
		    		this.m_E_SuccessRateText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_SuccessRate");
     			}
     			return this.m_E_SuccessRateText;
     		}
     	}

		public UnityEngine.UI.Text E_SuccessAdditionText
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
		    		this.m_E_SuccessAdditionText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_SuccessAddition");
     			}
     			return this.m_E_SuccessAdditionText;
     		}
     	}

		public UnityEngine.UI.Text E_CostTipText
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
		    		this.m_E_CostTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_CostTip");
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
     			if( this.m_es_costlist == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_NextNode/ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
     		}
     	}

		public UnityEngine.UI.Text E_Attribute1Text
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
		    		this.m_E_Attribute1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Attribute1");
     			}
     			return this.m_E_Attribute1Text;
     		}
     	}

		public UnityEngine.UI.Text E_QiangHuaNameText
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
		    		this.m_E_QiangHuaNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_QiangHuaName");
     			}
     			return this.m_E_QiangHuaNameText;
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
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
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
		private UnityEngine.RectTransform m_EG_QiangHuaLevelListRectTransform = null;
		private EntityRef<ES_EquipSetItem> m_es_equipsetitem = null;
		private UnityEngine.RectTransform m_EG_MaxNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_NextNodeRectTransform = null;
		private UnityEngine.UI.Button m_E_QiangHuaButton = null;
		private UnityEngine.UI.Image m_E_QiangHuaImage = null;
		private UnityEngine.UI.Text m_E_Attribute2Text = null;
		private UnityEngine.UI.Text m_E_SuccessRateText = null;
		private UnityEngine.UI.Text m_E_SuccessAdditionText = null;
		private UnityEngine.UI.Text m_E_CostTipText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private UnityEngine.UI.Text m_E_Attribute1Text = null;
		private UnityEngine.UI.Text m_E_QiangHuaNameText = null;
		public Transform uiTransform = null;
	}
}
