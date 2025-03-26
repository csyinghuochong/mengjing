using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonTask : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public TaskPro TaskPro; // 进行中的赛季任务 或 选中的每日任务
		public int TaskType;
		public int CompeletTaskId;
		public List<int> ShowTaskIds = new();
		public Dictionary<int, EntityRef<Scroll_Item_SeasonTaskItem>> ScrollItemSeasonTaskItems;
		public List<TaskPro> ShowTaskPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_SeasonDayTaskItem>> ScrollItemSeasonDayTaskItems;

		public ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public LoopVerticalScrollRect E_SeasonDayTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonDayTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SeasonDayTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SeasonDayTaskItems");
     			}
     			return this.m_E_SeasonDayTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public LoopVerticalScrollRect E_SeasonTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SeasonTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SeasonTaskItems");
     			}
     			return this.m_E_SeasonTaskItemsLoopVerticalScrollRect;
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
     			if( es == null )
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
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_SeasonDayTaskItemsLoopVerticalScrollRect = null;
			this.m_E_SeasonTaskItemsLoopVerticalScrollRect = null;
			this.m_E_Img_LodingValue = null;
			this.m_E_Img_LodingValue_22 = null;
			this.m_E_TaskNameTextText = null;
			this.m_E_ProgressTextText = null;
			this.m_E_TaskDescTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_GetBtnButton = null;
			this.m_E_GetBtnImage = null;
			this.m_E_GiveBtnButton = null;
			this.m_E_GiveBtnImage = null;
			this.m_E_AcvityedImgImage = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private LoopVerticalScrollRect m_E_SeasonDayTaskItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_SeasonTaskItemsLoopVerticalScrollRect = null;
		private Image m_E_Img_LodingValue = null;
		private Image m_E_Img_LodingValue_22 = null;
		private Text m_E_TaskNameTextText = null;
		private Text m_E_ProgressTextText = null;
		private Text m_E_TaskDescTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_GetBtnButton = null;
		private Image m_E_GetBtnImage = null;
		private Button m_E_GiveBtnButton = null;
		private Image m_E_GiveBtnImage = null;
		private Image m_E_AcvityedImgImage = null;
		public Transform uiTransform = null;
	}
}
