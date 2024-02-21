
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

		public ES_EquipItem ES_EquipItemYifu
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemyifu == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemYifu");
		    	   this.m_es_equipitemyifu = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemyifu;
     		}
     	}

		public ES_EquipItem ES_EquipItemWuqi
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemwuqi == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemWuqi");
		    	   this.m_es_equipitemwuqi = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemwuqi;
     		}
     	}

		public ES_EquipItem ES_EquipItemFuhu
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemfuhu == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemFuhu");
		    	   this.m_es_equipitemfuhu = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemfuhu;
     		}
     	}

		public ES_EquipItem ES_EquipItemJiezhi
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemjiezhi == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemJiezhi");
		    	   this.m_es_equipitemjiezhi = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemjiezhi;
     		}
     	}

		public ES_EquipItem ES_EquipItemShiping1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshiping1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShiping1");
		    	   this.m_es_equipitemshiping1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshiping1;
     		}
     	}

		public ES_EquipItem ES_EquipItemShiping2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshiping2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShiping2");
		    	   this.m_es_equipitemshiping2 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshiping2;
     		}
     	}

		public ES_EquipItem ES_EquipItemShiping3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshiping3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShiping3");
		    	   this.m_es_equipitemshiping3 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshiping3;
     		}
     	}

		public ES_EquipItem ES_EquipItemXiezi
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemxiezi == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemXiezi");
		    	   this.m_es_equipitemxiezi = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemxiezi;
     		}
     	}

		public ES_EquipItem ES_EquipItemKuzi
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemkuzi == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemKuzi");
		    	   this.m_es_equipitemkuzi = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemkuzi;
     		}
     	}

		public ES_EquipItem ES_EquipItemYaodai
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemyaodai == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemYaodai");
		    	   this.m_es_equipitemyaodai = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemyaodai;
     		}
     	}

		public ES_EquipItem ES_EquipItemShouzhuo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemshouzhuo == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemShouzhuo");
		    	   this.m_es_equipitemshouzhuo = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshouzhuo;
     		}
     	}

		public ES_EquipItem ES_EquipItemToukui
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemtoukui == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemToukui");
		    	   this.m_es_equipitemtoukui = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemtoukui;
     		}
     	}

		public ES_EquipItem ES_EquipItemXianglian
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitemxianglian == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EquipSet/ES_EquipItemXianglian");
		    	   this.m_es_equipitemxianglian = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemxianglian;
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
			this.m_es_equipitemyifu = null;
			this.m_es_equipitemwuqi = null;
			this.m_es_equipitemfuhu = null;
			this.m_es_equipitemjiezhi = null;
			this.m_es_equipitemshiping1 = null;
			this.m_es_equipitemshiping2 = null;
			this.m_es_equipitemshiping3 = null;
			this.m_es_equipitemxiezi = null;
			this.m_es_equipitemkuzi = null;
			this.m_es_equipitemyaodai = null;
			this.m_es_equipitemshouzhuo = null;
			this.m_es_equipitemtoukui = null;
			this.m_es_equipitemxianglian = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_BagToggle = null;
			this.m_E_PropertyToggle = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_RoseNameText = null;
		private UnityEngine.UI.Text m_E_RoseLvText = null;
		private EntityRef<ES_EquipItem> m_es_equipitemyifu = null;
		private EntityRef<ES_EquipItem> m_es_equipitemwuqi = null;
		private EntityRef<ES_EquipItem> m_es_equipitemfuhu = null;
		private EntityRef<ES_EquipItem> m_es_equipitemjiezhi = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping2 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping3 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemxiezi = null;
		private EntityRef<ES_EquipItem> m_es_equipitemkuzi = null;
		private EntityRef<ES_EquipItem> m_es_equipitemyaodai = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshouzhuo = null;
		private EntityRef<ES_EquipItem> m_es_equipitemtoukui = null;
		private EntityRef<ES_EquipItem> m_es_equipitemxianglian = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_BagToggle = null;
		private UnityEngine.UI.Toggle m_E_PropertyToggle = null;
		public Transform uiTransform = null;
	}
}
