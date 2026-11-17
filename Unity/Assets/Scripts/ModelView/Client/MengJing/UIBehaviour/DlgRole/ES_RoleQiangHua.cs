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
		public List<EntityRef<ES_RoleQiangHuaItem>> QiangHuaItemList = new();
		
		public UnityEngine.RectTransform EG_RoleQiangHuaItem_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_1RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_1");
     			}
     			return this.m_EG_RoleQiangHuaItem_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_2RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_2");
     			}
     			return this.m_EG_RoleQiangHuaItem_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_3RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_3");
     			}
     			return this.m_EG_RoleQiangHuaItem_3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_4RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_4");
     			}
     			return this.m_EG_RoleQiangHuaItem_4RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_5RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_5RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_5");
     			}
     			return this.m_EG_RoleQiangHuaItem_5RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_6RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_6RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_6RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_6");
     			}
     			return this.m_EG_RoleQiangHuaItem_6RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_7RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_7RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_7RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_7");
     			}
     			return this.m_EG_RoleQiangHuaItem_7RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_8RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_8RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_8RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_8");
     			}
     			return this.m_EG_RoleQiangHuaItem_8RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_9RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_9RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_9RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_9");
     			}
     			return this.m_EG_RoleQiangHuaItem_9RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleQiangHuaItem_10RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleQiangHuaItem_10RectTransform == null )
     			{
		    		this.m_EG_RoleQiangHuaItem_10RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_RoleQiangHuaItem_10");
     			}
     			return this.m_EG_RoleQiangHuaItem_10RectTransform;
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

		public UnityEngine.UI.Text E_TextGoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextGoldText == null )
     			{
		    		this.m_E_TextGoldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_TextGold");
     			}
     			return this.m_E_TextGoldText;
     		}
     	}

		public UnityEngine.UI.Text E_TextGoldDiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextGoldDiText == null )
     			{
		    		this.m_E_TextGoldDiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_NextNode/E_TextGoldDi");
     			}
     			return this.m_E_TextGoldDiText;
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

		public UnityEngine.UI.Text E_QiangHuaTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaTipText == null )
     			{
		    		this.m_E_QiangHuaTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_QiangHuaTip");
     			}
     			return this.m_E_QiangHuaTipText;
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
		    		this.m_E_SuccessRateText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_SuccessRate");
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
		    		this.m_E_SuccessAdditionText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_SuccessAddition");
     			}
     			return this.m_E_SuccessAdditionText;
     		}
     	}

		public UnityEngine.UI.Image EquipBack1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EquipBack1Image == null )
     			{
		    		this.m_EquipBack1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EquipBack (1)");
     			}
     			return this.m_EquipBack1Image;
     		}
     	}

		public UnityEngine.UI.Image EquipBack9Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EquipBack9Image == null )
     			{
		    		this.m_EquipBack9Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EquipBack (9)");
     			}
     			return this.m_EquipBack9Image;
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
		    		this.m_E_QiangHuaNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_QiangHuaName");
     			}
     			return this.m_E_QiangHuaNameText;
     		}
     	}

		public UnityEngine.UI.Image E_EquipIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipIconImage == null )
     			{
		    		this.m_E_EquipIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_EquipIcon");
     			}
     			return this.m_E_EquipIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_QiangHuaLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaLvText == null )
     			{
		    		this.m_E_QiangHuaLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_QiangHuaLv");
     			}
     			return this.m_E_QiangHuaLvText;
     		}
     	}

		public UnityEngine.UI.Toggle E_ToggleLuckyToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ToggleLuckyToggle == null )
     			{
		    		this.m_E_ToggleLuckyToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Center/E_ToggleLucky");
     			}
     			return this.m_E_ToggleLuckyToggle;
     		}
     	}

		public UnityEngine.UI.Image E_Img_LodingValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LodingValueImage == null )
     			{
		    		this.m_E_Img_LodingValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Img_LodingValue");
     			}
     			return this.m_E_Img_LodingValueImage;
     		}
     	}

		public UnityEngine.UI.Text E_CostTip2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostTip2Text == null )
     			{
		    		this.m_E_CostTip2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_CostTip2");
     			}
     			return this.m_E_CostTip2Text;
     		}
     	}

		public UnityEngine.UI.Text E_QiangHuaLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaLevelText == null )
     			{
		    		this.m_E_QiangHuaLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_QiangHuaLevel");
     			}
     			return this.m_E_QiangHuaLevelText;
     		}
     	}

		public UnityEngine.UI.Text E_QiangHuaProgressText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaProgressText == null )
     			{
		    		this.m_E_QiangHuaProgressText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_QiangHuaProgress");
     			}
     			return this.m_E_QiangHuaProgressText;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CostList");
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
			this.m_EG_RoleQiangHuaItem_1RectTransform = null;
			this.m_EG_RoleQiangHuaItem_2RectTransform = null;
			this.m_EG_RoleQiangHuaItem_3RectTransform = null;
			this.m_EG_RoleQiangHuaItem_4RectTransform = null;
			this.m_EG_RoleQiangHuaItem_5RectTransform = null;
			this.m_EG_RoleQiangHuaItem_6RectTransform = null;
			this.m_EG_RoleQiangHuaItem_7RectTransform = null;
			this.m_EG_RoleQiangHuaItem_8RectTransform = null;
			this.m_EG_RoleQiangHuaItem_9RectTransform = null;
			this.m_EG_RoleQiangHuaItem_10RectTransform = null;
			this.m_EG_QiangHuaLevelListRectTransform = null;
			this.m_EG_MaxNodeRectTransform = null;
			this.m_EG_NextNodeRectTransform = null;
			this.m_E_QiangHuaButton = null;
			this.m_E_QiangHuaImage = null;
			this.m_E_Attribute2Text = null;
			this.m_E_CostTipText = null;
			this.m_E_TextGoldText = null;
			this.m_E_TextGoldDiText = null;
			this.m_E_Attribute1Text = null;
			this.m_E_QiangHuaTipText = null;
			this.m_E_SuccessRateText = null;
			this.m_E_SuccessAdditionText = null;
			this.m_EquipBack1Image = null;
			this.m_EquipBack9Image = null;
			this.m_E_QiangHuaNameText = null;
			this.m_E_EquipIconImage = null;
			this.m_E_QiangHuaLvText = null;
			this.m_E_ToggleLuckyToggle = null;
			this.m_E_Img_LodingValueImage = null;
			this.m_E_CostTip2Text = null;
			this.m_E_QiangHuaLevelText = null;
			this.m_E_QiangHuaProgressText = null;
			this.m_es_costlist = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_3RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_4RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_5RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_6RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_7RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_8RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_9RectTransform = null;
		private UnityEngine.RectTransform m_EG_RoleQiangHuaItem_10RectTransform = null;
		private UnityEngine.RectTransform m_EG_QiangHuaLevelListRectTransform = null;
		private UnityEngine.RectTransform m_EG_MaxNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_NextNodeRectTransform = null;
		private UnityEngine.UI.Button m_E_QiangHuaButton = null;
		private UnityEngine.UI.Image m_E_QiangHuaImage = null;
		private UnityEngine.UI.Text m_E_Attribute2Text = null;
		private UnityEngine.UI.Text m_E_CostTipText = null;
		private UnityEngine.UI.Text m_E_TextGoldText = null;
		private UnityEngine.UI.Text m_E_TextGoldDiText = null;
		private UnityEngine.UI.Text m_E_Attribute1Text = null;
		private UnityEngine.UI.Text m_E_QiangHuaTipText = null;
		private UnityEngine.UI.Text m_E_SuccessRateText = null;
		private UnityEngine.UI.Text m_E_SuccessAdditionText = null;
		private UnityEngine.UI.Image m_EquipBack1Image = null;
		private UnityEngine.UI.Image m_EquipBack9Image = null;
		private UnityEngine.UI.Text m_E_QiangHuaNameText = null;
		private UnityEngine.UI.Image m_E_EquipIconImage = null;
		private UnityEngine.UI.Text m_E_QiangHuaLvText = null;
		private UnityEngine.UI.Toggle m_E_ToggleLuckyToggle = null;
		private UnityEngine.UI.Image m_E_Img_LodingValueImage = null;
		private UnityEngine.UI.Text m_E_CostTip2Text = null;
		private UnityEngine.UI.Text m_E_QiangHuaLevelText = null;
		private UnityEngine.UI.Text m_E_QiangHuaProgressText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		public Transform uiTransform = null;
	}
}
