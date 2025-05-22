using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMatch : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public GameObject MainPetItem;
		public List<GameObject> MainPetItemList = new();
		public PetMeleeInfo PetMeleeInfo;
		
		public UnityEngine.UI.Button E_Button_TeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_TeamButton == null )
     			{
		    		this.m_E_Button_TeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_Team");
     			}
     			return this.m_E_Button_TeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_TeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_TeamImage == null )
     			{
		    		this.m_E_Button_TeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_Team");
     			}
     			return this.m_E_Button_TeamImage;
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.RectTransform EG_MainPetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainPetListRectTransform == null )
     			{
		    		this.m_EG_MainPetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MainPetList");
     			}
     			return this.m_EG_MainPetListRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RefreshButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RefreshButton == null )
     			{
		    		this.m_E_Button_RefreshButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Refresh");
     			}
     			return this.m_E_Button_RefreshButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RefreshImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RefreshImage == null )
     			{
		    		this.m_E_Button_RefreshImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Refresh");
     			}
     			return this.m_E_Button_RefreshImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RewardButton == null )
     			{
		    		this.m_E_Button_RewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Reward");
     			}
     			return this.m_E_Button_RewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RewardImage == null )
     			{
		    		this.m_E_Button_RewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Reward");
     			}
     			return this.m_E_Button_RewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RankButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RankButton == null )
     			{
		    		this.m_E_Button_RankButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Rank");
     			}
     			return this.m_E_Button_RankButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RankImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RankImage == null )
     			{
		    		this.m_E_Button_RankImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Rank");
     			}
     			return this.m_E_Button_RankImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ScoreText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ScoreText == null )
     			{
		    		this.m_E_Text_ScoreText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Score");
     			}
     			return this.m_E_Text_ScoreText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_RankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RankText == null )
     			{
		    		this.m_E_Text_RankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Rank");
     			}
     			return this.m_E_Text_RankText;
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
			this.m_E_Button_TeamButton = null;
			this.m_E_Button_TeamImage = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_EG_MainPetListRectTransform = null;
			this.m_E_Button_RefreshButton = null;
			this.m_E_Button_RefreshImage = null;
			this.m_E_Button_RewardButton = null;
			this.m_E_Button_RewardImage = null;
			this.m_E_Button_RankButton = null;
			this.m_E_Button_RankImage = null;
			this.m_E_Text_ScoreText = null;
			this.m_E_Text_RankText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Button_TeamButton = null;
		private UnityEngine.UI.Image m_E_Button_TeamImage = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.RectTransform m_EG_MainPetListRectTransform = null;
		private UnityEngine.UI.Button m_E_Button_RefreshButton = null;
		private UnityEngine.UI.Image m_E_Button_RefreshImage = null;
		private UnityEngine.UI.Button m_E_Button_RewardButton = null;
		private UnityEngine.UI.Image m_E_Button_RewardImage = null;
		private UnityEngine.UI.Button m_E_Button_RankButton = null;
		private UnityEngine.UI.Image m_E_Button_RankImage = null;
		private UnityEngine.UI.Text m_E_Text_ScoreText = null;
		private UnityEngine.UI.Text m_E_Text_RankText = null;
		public Transform uiTransform = null;
	}
}
