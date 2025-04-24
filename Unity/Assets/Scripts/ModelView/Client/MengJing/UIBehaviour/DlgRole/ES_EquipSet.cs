using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipSet : Entity,IAwake<Transform>,IDestroy 
	{
		public int Occ;
		public ItemOperateEnum ItemOperateEnum;
		public List<EntityRef<ES_EquipItem>> ESEquipItems_1 = new();
		public List<EntityRef<ES_EquipItem>> ESEquipItems_2 = new();
		public List<ItemInfo> EquipInfoList { get; set; } = new();
		
		public RectTransform EG_EquipSetHideRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipSetHideRectTransform == null )
     			{
		    		this.m_EG_EquipSetHideRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_EquipSetHide");
     			}
     			return this.m_EG_EquipSetHideRectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ModelShow es = this.m_es_modelshow;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_EquipSetHide/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Text E_RoseNameText
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
		    		this.m_E_RoseNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_EquipSetHide/RoseNameLv/E_RoseName");
     			}
     			return this.m_E_RoseNameText;
     		}
     	}

		public Text E_RoseLvText
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
		    		this.m_E_RoseLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_EquipSetHide/RoseNameLv/E_RoseLv");
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

		        ES_EquipItem es = this.m_es_equipitemwuqi_1;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemWuqi_1");
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

		        ES_EquipItem es = this.m_es_equipitemyifu_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemYifu_1");
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

		        ES_EquipItem es = this.m_es_equipitemfuhu_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemFuhu_1");
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

		        ES_EquipItem es = this.m_es_equipitemjiezhi_1;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemJiezhi_1");
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

		        ES_EquipItem es = this.m_es_equipitemshiping1_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemShiping1_1");
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

		        ES_EquipItem es = this.m_es_equipitemshiping2_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemShiping2_1");
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

		        ES_EquipItem es = this.m_es_equipitemshiping3_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemShiping3_1");
		    	   this.m_es_equipitemshiping3_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemshiping3_1;
     		}
     	}
		
		public ES_EquipItem ES_EquipItemShiping4_1
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}

				ES_EquipItem es = this.m_es_equipitemshiping4_1;
				if( es ==null )
				{
					Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemShiping4_1");
					this.m_es_equipitemshiping4_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
				}
				return this.m_es_equipitemshiping4_1;
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

		        ES_EquipItem es = this.m_es_equipitemxiezi_1;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemXiezi_1");
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

		        ES_EquipItem es = this.m_es_equipitemkuzi_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemKuzi_1");
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

		        ES_EquipItem es = this.m_es_equipitemyaodai_1;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemYaodai_1");
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

		        ES_EquipItem es = this.m_es_equipitemshouzhuo_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemShouzhuo_1");
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

		        ES_EquipItem es = this.m_es_equipitemtoukui_1;
     			if( es==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemToukui_1");
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

		        ES_EquipItem es = this.m_es_equipitemxianglian_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemXianglian_1");
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

		        ES_EquipItem es = this.m_es_equipitemwuqi_2;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItemWuqi_2");
		    	   this.m_es_equipitemwuqi_2 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitemwuqi_2;
     		}
     	}
		
		public Text E_CombatText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_CombatText == null )
				{
					this.m_E_CombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_FightValueShow/E_Combat");
				}
				return this.m_E_CombatText;
			}
		}

		public void DestroyWidget()
		{
			this.m_EG_EquipSetHideRectTransform = null;
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
			this.m_es_equipitemshiping4_1 = null;
			this.m_es_equipitemxiezi_1 = null;
			this.m_es_equipitemkuzi_1 = null;
			this.m_es_equipitemyaodai_1 = null;
			this.m_es_equipitemshouzhuo_1 = null;
			this.m_es_equipitemtoukui_1 = null;
			this.m_es_equipitemxianglian_1 = null;
			this.m_es_equipitemwuqi_2 = null;
			this.m_E_CombatText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_EquipSetHideRectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Text m_E_RoseNameText = null;
		private Text m_E_RoseLvText = null;
		private EntityRef<ES_EquipItem> m_es_equipitemwuqi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemyifu_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemfuhu_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemjiezhi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping1_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping2_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping3_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshiping4_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemxiezi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemkuzi_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemyaodai_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemshouzhuo_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemtoukui_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemxianglian_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitemwuqi_2 = null;
		private Text m_E_CombatText = null;
		public Transform uiTransform = null;
	}
}
