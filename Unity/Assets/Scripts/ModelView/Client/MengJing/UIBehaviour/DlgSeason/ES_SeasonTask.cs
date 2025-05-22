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
		
		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SeasonDayTaskItemsLoopVerticalScrollRect
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
		    		this.m_E_SeasonDayTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SeasonDayTaskItems");
     			}
     			return this.m_E_SeasonDayTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_SeasonTaskItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonTaskItemsImage == null )
     			{
		    		this.m_E_SeasonTaskItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SeasonTaskItems");
     			}
     			return this.m_E_SeasonTaskItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SeasonTaskItemsLoopVerticalScrollRect
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
		    		this.m_E_SeasonTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SeasonTaskItems");
     			}
     			return this.m_E_SeasonTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_Img_LodingValue_22Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LodingValue_22Image == null )
     			{
		    		this.m_E_Img_LodingValue_22Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Img_LodingValue_22");
     			}
     			return this.m_E_Img_LodingValue_22Image;
     		}
     	}

		public UnityEngine.UI.Image E_Img_LodingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LodingImage == null )
     			{
		    		this.m_E_Img_LodingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Img_LodingValue_22/E_Img_Loding");
     			}
     			return this.m_E_Img_LodingImage;
     		}
     	}

		public UnityEngine.UI.Text E_TaskNameTextText
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
		    		this.m_E_TaskNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TaskNameText");
     			}
     			return this.m_E_TaskNameTextText;
     		}
     	}

		public UnityEngine.UI.Text E_ProgressTextText
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
		    		this.m_E_ProgressTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_ProgressText");
     			}
     			return this.m_E_ProgressTextText;
     		}
     	}

		public UnityEngine.UI.Text E_TaskDescTextText
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
		    		this.m_E_TaskDescTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TaskDescText");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_GiveBtnButton
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
		    		this.m_E_GiveBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_GiveBtn");
     			}
     			return this.m_E_GiveBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_GiveBtnImage
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
		    		this.m_E_GiveBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_GiveBtn");
     			}
     			return this.m_E_GiveBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_GetBtnButton
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
		    		this.m_E_GetBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_GetBtn");
     			}
     			return this.m_E_GetBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_GetBtnImage
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
		    		this.m_E_GetBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_GetBtn");
     			}
     			return this.m_E_GetBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_AcvityedImgImage
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
		    		this.m_E_AcvityedImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_AcvityedImg");
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
			this.m_E_SeasonTaskItemsImage = null;
			this.m_E_SeasonTaskItemsLoopVerticalScrollRect = null;
			this.m_E_Img_LodingValue_22Image = null;
			this.m_E_Img_LodingImage = null;
			this.m_E_TaskNameTextText = null;
			this.m_E_ProgressTextText = null;
			this.m_E_TaskDescTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_GiveBtnButton = null;
			this.m_E_GiveBtnImage = null;
			this.m_E_GetBtnButton = null;
			this.m_E_GetBtnImage = null;
			this.m_E_AcvityedImgImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SeasonDayTaskItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_SeasonTaskItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SeasonTaskItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_Img_LodingValue_22Image = null;
		private UnityEngine.UI.Image m_E_Img_LodingImage = null;
		private UnityEngine.UI.Text m_E_TaskNameTextText = null;
		private UnityEngine.UI.Text m_E_ProgressTextText = null;
		private UnityEngine.UI.Text m_E_TaskDescTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_GiveBtnButton = null;
		private UnityEngine.UI.Image m_E_GiveBtnImage = null;
		private UnityEngine.UI.Button m_E_GetBtnButton = null;
		private UnityEngine.UI.Image m_E_GetBtnImage = null;
		private UnityEngine.UI.Image m_E_AcvityedImgImage = null;
		public Transform uiTransform = null;
	}
}
