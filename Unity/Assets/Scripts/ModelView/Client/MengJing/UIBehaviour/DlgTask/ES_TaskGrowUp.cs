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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_TaskGrowUpItemsScrollRect
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
		    		this.m_E_TaskGrowUpItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/E_TaskGrowUpItems");
     			}
     			return this.m_E_TaskGrowUpItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_TaskGrowUpItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGrowUpItemsImage == null )
     			{
		    		this.m_E_TaskGrowUpItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_TaskGrowUpItems");
     			}
     			return this.m_E_TaskGrowUpItemsImage;
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
		    		this.m_E_Img_LodingValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Img_LodingValue");
     			}
     			return this.m_E_Img_LodingValueImage;
     		}
     	}

		public ES_CommonSkillItem ES_CommonSkillItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonSkillItem es = this.m_es_commonskillitem_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_CommonSkillItem_0");
		    	   this.m_es_commonskillitem_0 = this.AddChild<ES_CommonSkillItem,Transform>(subTrans);
     			}
     			return this.m_es_commonskillitem_0;
     		}
     	}

		public ES_CommonSkillItem ES_CommonSkillItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonSkillItem es = this.m_es_commonskillitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_CommonSkillItem_1");
		    	   this.m_es_commonskillitem_1 = this.AddChild<ES_CommonSkillItem,Transform>(subTrans);
     			}
     			return this.m_es_commonskillitem_1;
     		}
     	}

		public ES_CommonSkillItem ES_CommonSkillItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonSkillItem es = this.m_es_commonskillitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_CommonSkillItem_2");
		    	   this.m_es_commonskillitem_2 = this.AddChild<ES_CommonSkillItem,Transform>(subTrans);
     			}
     			return this.m_es_commonskillitem_2;
     		}
     	}

		public UnityEngine.UI.Text E_TextProgressText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextProgressText == null )
     			{
		    		this.m_E_TextProgressText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_TextProgress");
     			}
     			return this.m_E_TextProgressText;
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
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_TaskGrowUpItemsScrollRect = null;
			this.m_E_TaskGrowUpItemsImage = null;
			this.m_E_Img_LodingValueImage = null;
			this.m_es_commonskillitem_0 = null;
			this.m_es_commonskillitem_1 = null;
			this.m_es_commonskillitem_2 = null;
			this.m_E_TextProgressText = null;
			this.m_es_rewardlist = null;
			this.m_E_GetBtnButton = null;
			this.m_E_GetBtnImage = null;
			this.m_E_GiveBtnButton = null;
			this.m_E_GiveBtnImage = null;
			this.m_E_Img_LodingValue_22Image = null;
			this.m_E_AcvityedImgImage = null;
			this.m_E_TaskNameTextText = null;
			this.m_E_ProgressTextText = null;
			this.m_E_TaskDescTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.ScrollRect m_E_TaskGrowUpItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_TaskGrowUpItemsImage = null;
		private UnityEngine.UI.Image m_E_Img_LodingValueImage = null;
		private EntityRef<ES_CommonSkillItem> m_es_commonskillitem_0 = null;
		private EntityRef<ES_CommonSkillItem> m_es_commonskillitem_1 = null;
		private EntityRef<ES_CommonSkillItem> m_es_commonskillitem_2 = null;
		private UnityEngine.UI.Text m_E_TextProgressText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_GetBtnButton = null;
		private UnityEngine.UI.Image m_E_GetBtnImage = null;
		private UnityEngine.UI.Button m_E_GiveBtnButton = null;
		private UnityEngine.UI.Image m_E_GiveBtnImage = null;
		private UnityEngine.UI.Image m_E_Img_LodingValue_22Image = null;
		private UnityEngine.UI.Image m_E_AcvityedImgImage = null;
		private UnityEngine.UI.Text m_E_TaskNameTextText = null;
		private UnityEngine.UI.Text m_E_ProgressTextText = null;
		private UnityEngine.UI.Text m_E_TaskDescTextText = null;
		public Transform uiTransform = null;
	}
}
