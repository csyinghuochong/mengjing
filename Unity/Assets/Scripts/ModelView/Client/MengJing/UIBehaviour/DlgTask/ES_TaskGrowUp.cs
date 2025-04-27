using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskGrowUp : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public TaskPro TaskPro;
		public int CompeletTaskId;
		public int SelectIndex;
		public List<int> ShowTaskConfigIds = new();
		public Dictionary<int, EntityRef<Scroll_Item_TaskGrowUpItem>> ScrollItemTaskGrowUpItems = new();
		public List<string> AssetList { get; set; } = new();
		
		public ScrollRect E_TaskGrowUpItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGrowUpItemsScrollRect == null )
     			{
		    		this.m_E_TaskGrowUpItemsScrollRect = UIFindHelper.FindDeepChild<ScrollRect>(this.uiTransform.gameObject,"E_TaskGrowUpItems");
     			}
     			return this.m_E_TaskGrowUpItemsScrollRect;
     		}
     	}

		public Text E_TaskNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskNameTextText == null )
     			{
		    		this.m_E_TaskNameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskNameText");
     			}
     			return this.m_E_TaskNameTextText;
     		}
     	}

		public Text E_ProgressTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressTextText == null )
     			{
		    		this.m_E_ProgressTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ProgressText");
     			}
     			return this.m_E_ProgressTextText;
     		}
     	}

		public Text E_TaskDescTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskDescTextText == null )
     			{
		    		this.m_E_TaskDescTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskDescText");
     			}
     			return this.m_E_TaskDescTextText;
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
     			if( es==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_GetBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GetBtnButton == null )
     			{
		    		this.m_E_GetBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_GetBtn");
     			}
     			return this.m_E_GetBtnButton;
     		}
     	}

		public Image E_GetBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GetBtnImage == null )
     			{
		    		this.m_E_GetBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_GetBtn");
     			}
     			return this.m_E_GetBtnImage;
     		}
     	}

		public Button E_GiveBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveBtnButton == null )
     			{
		    		this.m_E_GiveBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_GiveBtn");
     			}
     			return this.m_E_GiveBtnButton;
     		}
     	}

		public Image E_GiveBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveBtnImage == null )
     			{
		    		this.m_E_GiveBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_GiveBtn");
     			}
     			return this.m_E_GiveBtnImage;
     		}
     	}

		public Image E_AcvityedImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AcvityedImgImage == null )
     			{
		    		this.m_E_AcvityedImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_AcvityedImg");
     			}
     			return this.m_E_AcvityedImgImage;
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
					this.m_E_Img_LodingValue = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_LodingValue");
				}
				return this.m_E_Img_LodingValue;
			}
		}
		
		public Image E_Img_LodingValue_22
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Img_LodingValue_22 == null )
				{
					this.m_E_Img_LodingValue_22 = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_LodingValue_22");
				}
				return this.m_E_Img_LodingValue_22;
			}
		}
				
		public ES_CommonSkillItem ES_CommonSkillItem_0
		{
			get
			{
				ES_CommonSkillItem es = this.m_ES_CommonSkillItem_0;
				if (es == null)
				{
					Transform go = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TaskGrowUpSkillItem_0");
					this.m_ES_CommonSkillItem_0 = this.AddChild<ES_CommonSkillItem, Transform>(go);
				}

				return this.m_ES_CommonSkillItem_0;
			}
		}

		public ES_CommonSkillItem ES_CommonSkillItem_1
		{
			get
			{
				ES_CommonSkillItem es = this.m_ES_CommonSkillItem_1;
				if (es == null)
				{
					Transform go = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TaskGrowUpSkillItem_1");
					this.m_ES_CommonSkillItem_1 = this.AddChild<ES_CommonSkillItem, Transform>(go);
				}

				return this.m_ES_CommonSkillItem_1;
			}
		}
		
		public ES_CommonSkillItem ES_CommonSkillItem_2
		{
			get
			{
				ES_CommonSkillItem es = this.m_ES_CommonSkillItem_2;
				if (es == null)
				{
					Transform go = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TaskGrowUpSkillItem_2");
					this.m_ES_CommonSkillItem_2 = this.AddChild<ES_CommonSkillItem, Transform>(go);
				}

				return this.m_ES_CommonSkillItem_2;
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

		public Text E_TextProgress
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_TextProgress == null )
				{
					this.m_E_TextProgress = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextProgress");
				}
				return this.m_E_TextProgress;
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
			this.m_E_TaskGrowUpItemsScrollRect = null;
			this.m_E_FunctionSetBtnToggleGroup = null;	
			this.m_E_TaskNameTextText = null;
			this.m_E_ProgressTextText = null;
			this.m_E_TaskDescTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_GetBtnButton = null;
			this.m_E_GetBtnImage = null;
			this.m_E_GiveBtnButton = null;
			this.m_E_GiveBtnImage = null;
			this.m_E_AcvityedImgImage = null;
			this.m_E_Img_LodingValue = null;
			this.m_ES_CommonSkillItem_0 = null;
			this.m_ES_CommonSkillItem_1 = null;
			this.m_ES_CommonSkillItem_2 = null;
			this.m_E_Img_LodingValue_22 = null;
			this.m_E_TextProgress = null;
			this.uiTransform = null;
		}

		private ScrollRect m_E_TaskGrowUpItemsScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Text m_E_TaskNameTextText = null;
		private Text m_E_ProgressTextText = null;
		private Text m_E_TaskDescTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_GetBtnButton = null;
		private Image m_E_GetBtnImage = null;
		private Button m_E_GiveBtnButton = null;
		private Image m_E_GiveBtnImage = null;
		private Image m_E_AcvityedImgImage = null;
		private Image m_E_Img_LodingValue = null;
		private Image m_E_Img_LodingValue_22 = null;
		private EntityRef<ES_CommonSkillItem> m_ES_CommonSkillItem_0 = null;
		private EntityRef<ES_CommonSkillItem> m_ES_CommonSkillItem_1 = null;
		private EntityRef<ES_CommonSkillItem> m_ES_CommonSkillItem_2 = null;
		private Text m_E_TextProgress = null;
		public Transform uiTransform = null;
	}
}
