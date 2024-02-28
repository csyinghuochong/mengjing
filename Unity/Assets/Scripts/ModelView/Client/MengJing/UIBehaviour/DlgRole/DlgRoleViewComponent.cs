
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRole))]
	[EnableMethod]
	public  class DlgRoleViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_modelshow == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/EquipSetHide/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Text E_RoseNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseNameText == null )
     			{
		    		this.m_E_RoseNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EquipSet/EquipSetHide/RoseNameLv/E_RoseName");
     			}
     			return this.m_E_RoseNameText;
     		}
     	}

		public UnityEngine.UI.Text E_RoseLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseLvText == null )
     			{
		    		this.m_E_RoseLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EquipSet/EquipSetHide/RoseNameLv/E_RoseLv");
     			}
     			return this.m_E_RoseLvText;
     		}
     	}

		public ES_EquipItem ES_EquipItemWuqi_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemwuqi_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemWuqi_1");
		    	   this.m_es_equipitemwuqi_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemwuqi_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemYifu_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemyifu_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemYifu_1");
		    	   this.m_es_equipitemyifu_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemyifu_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemFuhu_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemfuhu_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemFuhu_1");
		    	   this.m_es_equipitemfuhu_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemfuhu_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemJiezhi_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemjiezhi_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemJiezhi_1");
		    	   this.m_es_equipitemjiezhi_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemjiezhi_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemShiping1_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshiping1_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShiping1_1");
		    	   this.m_es_equipitemshiping1_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshiping1_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemShiping2_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshiping2_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShiping2_1");
		    	   this.m_es_equipitemshiping2_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshiping2_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemShiping3_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshiping3_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShiping3_1");
		    	   this.m_es_equipitemshiping3_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshiping3_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemXiezi_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemxiezi_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemXiezi_1");
		    	   this.m_es_equipitemxiezi_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemxiezi_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemKuzi_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemkuzi_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemKuzi_1");
		    	   this.m_es_equipitemkuzi_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemkuzi_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemYaodai_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemyaodai_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemYaodai_1");
		    	   this.m_es_equipitemyaodai_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemyaodai_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemShouzhuo_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshouzhuo_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShouzhuo_1");
		    	   this.m_es_equipitemshouzhuo_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshouzhuo_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemToukui_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemtoukui_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemToukui_1");
		    	   this.m_es_equipitemtoukui_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemtoukui_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemXianglian_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemxianglian_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemXianglian_1");
		    	   this.m_es_equipitemxianglian_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemxianglian_1;
     		}
     	}

		public ES_EquipItem ES_EquipItemWuqi_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemwuqi_2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemWuqi_2");
		    	   this.m_es_equipitemwuqi_2 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemwuqi_2;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_BagToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagToggle == null )
     			{
		    		this.m_E_BagToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Bag");
     			}
     			return this.m_E_BagToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_PropertyToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PropertyToggle == null )
     			{
		    		this.m_E_PropertyToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Property");
     			}
     			return this.m_E_PropertyToggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_E_RoseNameText = null;
			this.m_E_RoseLvText = null;
			this.m_es_equipitemwuqi_1 = null;
			this.m_es_equipitemyifu_1 = null;
			this.m_es_equipitemfuhu_1 = null;
			this.m_es_equipitemjiezhi_1 = null;
			this.m_es_equipitemshiping1_1 = null;
			this.m_es_equipitemshiping2_1 = null;
			this.m_es_equipitemshiping3_1 = null;
			this.m_es_equipitemxiezi_1 = null;
			this.m_es_equipitemkuzi_1 = null;
			this.m_es_equipitemyaodai_1 = null;
			this.m_es_equipitemshouzhuo_1 = null;
			this.m_es_equipitemtoukui_1 = null;
			this.m_es_equipitemxianglian_1 = null;
			this.m_es_equipitemwuqi_2 = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_BagToggle = null;
			this.m_E_PropertyToggle = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_RoseNameText = null;
		private UnityEngine.UI.Text m_E_RoseLvText = null;
		private EntityRef<ES_EquipItem> m_es_equipitemwuqi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemyifu_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemfuhu_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemjiezhi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping1_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping2_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping3_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemxiezi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemkuzi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemyaodai_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshouzhuo_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemtoukui_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemxianglian_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemwuqi_2 = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_BagToggle = null;
		private UnityEngine.UI.Toggle m_E_PropertyToggle = null;
		public Transform uiTransform = null;
	}
}
