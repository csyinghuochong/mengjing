﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskDetail : Entity,IAwake<Transform>,IDestroy
	{
		public int TaskId { get; set; }
		public TaskPro TaskPro;
		
		public ES_TaskType ES_TaskType_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_TaskType es = this.m_es_tasktype_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/TypeListNode/ES_TaskType_0");
		    	   this.m_es_tasktype_0 = this.AddChild<ES_TaskType,Transform>(subTrans);
     			}
     			return this.m_es_tasktype_0;
     		}
     	}

		public ES_TaskType ES_TaskType_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_TaskType es = this.m_es_tasktype_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/TypeListNode/ES_TaskType_1");
		    	   this.m_es_tasktype_1 = this.AddChild<ES_TaskType,Transform>(subTrans);
     			}
     			return this.m_es_tasktype_1;
     		}
     	}

		public ES_TaskType ES_TaskType_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_TaskType es = this.m_es_tasktype_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/TypeListNode/ES_TaskType_2");
		    	   this.m_es_tasktype_2 = this.AddChild<ES_TaskType,Transform>(subTrans);
     			}
     			return this.m_es_tasktype_2;
     		}
     	}

		public RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_ZhuizongButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhuizongButton == null )
     			{
		    		this.m_E_ZhuizongButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_Zhuizong");
     			}
     			return this.m_E_ZhuizongButton;
     		}
     	}

		public Image E_ZhuizongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhuizongImage == null )
     			{
		    		this.m_E_ZhuizongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_Zhuizong");
     			}
     			return this.m_E_ZhuizongImage;
     		}
     	}

		public Button E_CancelZhuizongButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelZhuizongButton == null )
     			{
		    		this.m_E_CancelZhuizongButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_CancelZhuizong");
     			}
     			return this.m_E_CancelZhuizongButton;
     		}
     	}

		public Image E_CancelZhuizongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelZhuizongImage == null )
     			{
		    		this.m_E_CancelZhuizongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_CancelZhuizong");
     			}
     			return this.m_E_CancelZhuizongImage;
     		}
     	}

		public Text E_TeskDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeskDesText == null )
     			{
		    		this.m_E_TeskDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_TeskDes");
     			}
     			return this.m_E_TeskDesText;
     		}
     	}

		public Text E_TaskTargetText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTargetText == null )
     			{
		    		this.m_E_TaskTargetText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_TaskTarget");
     			}
     			return this.m_E_TaskTargetText;
     		}
     	}

		public Button E_GiveupButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveupButton == null )
     			{
		    		this.m_E_GiveupButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_Giveup");
     			}
     			return this.m_E_GiveupButton;
     		}
     	}

		public Image E_GiveupImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveupImage == null )
     			{
		    		this.m_E_GiveupImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_Giveup");
     			}
     			return this.m_E_GiveupImage;
     		}
     	}

		public Button E_GoingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GoingButton == null )
     			{
		    		this.m_E_GoingButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_Going");
     			}
     			return this.m_E_GoingButton;
     		}
     	}

		public Image E_GoingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GoingImage == null )
     			{
		    		this.m_E_GoingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_Going");
     			}
     			return this.m_E_GoingImage;
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
			this.m_es_tasktype_0 = null;
			this.m_es_tasktype_1 = null;
			this.m_es_tasktype_2 = null;
			this.m_EG_RightRectTransform = null;
			this.m_es_rewardlist = null;
			this.m_E_ZhuizongButton = null;
			this.m_E_ZhuizongImage = null;
			this.m_E_CancelZhuizongButton = null;
			this.m_E_CancelZhuizongImage = null;
			this.m_E_TeskDesText = null;
			this.m_E_TaskTargetText = null;
			this.m_E_GiveupButton = null;
			this.m_E_GiveupImage = null;
			this.m_E_GoingButton = null;
			this.m_E_GoingImage = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_TaskType> m_es_tasktype_0 = null;
		private EntityRef<ES_TaskType> m_es_tasktype_1 = null;
		private EntityRef<ES_TaskType> m_es_tasktype_2 = null;
		private RectTransform m_EG_RightRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ZhuizongButton = null;
		private Image m_E_ZhuizongImage = null;
		private Button m_E_CancelZhuizongButton = null;
		private Image m_E_CancelZhuizongImage = null;
		private Text m_E_TeskDesText = null;
		private Text m_E_TaskTargetText = null;
		private Button m_E_GiveupButton = null;
		private Image m_E_GiveupImage = null;
		private Button m_E_GoingButton = null;
		private Image m_E_GoingImage = null;
		public Transform uiTransform = null;
	}
}
