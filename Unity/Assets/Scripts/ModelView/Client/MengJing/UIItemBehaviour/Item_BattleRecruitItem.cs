using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_BattleRecruitItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_BattleRecruitItem> 
	{
		public long SummonTime;
		public int CostGold;
		public BattleSummonConfig BattleSummonConfig;
		public Action<int, int> OnRecruitAction;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_BattleRecruitItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_NameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_NameTextText == null )
     				{
		    			this.m_E_NameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     				}
     				return this.m_E_NameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( es == null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     			else
     			{
     				if( es != null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			es = this.m_es_modelshow;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_modelshow = null;
		    				this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     		}
     	}

		public Text E_PropertiesText_0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PropertiesText_0Text == null )
     				{
		    			this.m_E_PropertiesText_0Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertiesText_0");
     				}
     				return this.m_E_PropertiesText_0Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertiesText_0");
     			}
     		}
     	}

		public Text E_PropertiesText_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PropertiesText_1Text == null )
     				{
		    			this.m_E_PropertiesText_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertiesText_1");
     				}
     				return this.m_E_PropertiesText_1Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertiesText_1");
     			}
     		}
     	}

		public Text E_PropertiesText_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PropertiesText_2Text == null )
     				{
		    			this.m_E_PropertiesText_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertiesText_2");
     				}
     				return this.m_E_PropertiesText_2Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertiesText_2");
     			}
     		}
     	}

		public Text E_MonsterNumberTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_MonsterNumberTextText == null )
     				{
		    			this.m_E_MonsterNumberTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_MonsterNumberText");
     				}
     				return this.m_E_MonsterNumberTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_MonsterNumberText");
     			}
     		}
     	}

		public Text E_CostTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_CostTextText == null )
     				{
		    			this.m_E_CostTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_CostText");
     				}
     				return this.m_E_CostTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_CostText");
     			}
     		}
     	}

		public Button E_RecruitItemBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RecruitItemBtnButton == null )
     				{
		    			this.m_E_RecruitItemBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RecruitItemBtn");
     				}
     				return this.m_E_RecruitItemBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RecruitItemBtn");
     			}
     		}
     	}

		public Image E_RecruitItemBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RecruitItemBtnImage == null )
     				{
		    			this.m_E_RecruitItemBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RecruitItemBtn");
     				}
     				return this.m_E_RecruitItemBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RecruitItemBtn");
     			}
     		}
     	}

		public Text E_BtnTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_BtnTextText == null )
     				{
		    			this.m_E_BtnTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RecruitItemBtn/E_BtnText");
     				}
     				return this.m_E_BtnTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RecruitItemBtn/E_BtnText");
     			}
     		}
     	}

		public Text E_TimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_TimeTextText == null )
     				{
		    			this.m_E_TimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TimeText");
     				}
     				return this.m_E_TimeTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TimeText");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_NameTextText = null;
			this.m_es_modelshow = null;
			this.m_E_PropertiesText_0Text = null;
			this.m_E_PropertiesText_1Text = null;
			this.m_E_PropertiesText_2Text = null;
			this.m_E_MonsterNumberTextText = null;
			this.m_E_CostTextText = null;
			this.m_E_RecruitItemBtnButton = null;
			this.m_E_RecruitItemBtnImage = null;
			this.m_E_BtnTextText = null;
			this.m_E_TimeTextText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_NameTextText = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Text m_E_PropertiesText_0Text = null;
		private Text m_E_PropertiesText_1Text = null;
		private Text m_E_PropertiesText_2Text = null;
		private Text m_E_MonsterNumberTextText = null;
		private Text m_E_CostTextText = null;
		private Button m_E_RecruitItemBtnButton = null;
		private Image m_E_RecruitItemBtnImage = null;
		private Text m_E_BtnTextText = null;
		private Text m_E_TimeTextText = null;
		public Transform uiTransform = null;
	}
}
