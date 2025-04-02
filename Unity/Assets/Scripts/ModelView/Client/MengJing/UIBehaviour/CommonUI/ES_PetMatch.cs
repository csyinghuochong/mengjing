
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMatch : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		
		public GameObject[] ImageIconList;
		
		public UnityEngine.UI.Button E_ImageIcon6Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon6Button == null )
     			{
		    		this.m_E_ImageIcon6Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_ImageIcon6");
     			}
     			return this.m_E_ImageIcon6Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon6Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon6Image == null )
     			{
		    		this.m_E_ImageIcon6Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_ImageIcon6");
     			}
     			return this.m_E_ImageIcon6Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon5Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon5Button == null )
     			{
		    		this.m_E_ImageIcon5Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_ImageIcon5");
     			}
     			return this.m_E_ImageIcon5Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon5Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon5Image == null )
     			{
		    		this.m_E_ImageIcon5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_ImageIcon5");
     			}
     			return this.m_E_ImageIcon5Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon4Button == null )
     			{
		    		this.m_E_ImageIcon4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_ImageIcon4");
     			}
     			return this.m_E_ImageIcon4Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon4Image == null )
     			{
		    		this.m_E_ImageIcon4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_ImageIcon4");
     			}
     			return this.m_E_ImageIcon4Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon3Button == null )
     			{
		    		this.m_E_ImageIcon3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_ImageIcon3");
     			}
     			return this.m_E_ImageIcon3Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon3Image == null )
     			{
		    		this.m_E_ImageIcon3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_ImageIcon3");
     			}
     			return this.m_E_ImageIcon3Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon2Button == null )
     			{
		    		this.m_E_ImageIcon2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_ImageIcon2");
     			}
     			return this.m_E_ImageIcon2Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon2Image == null )
     			{
		    		this.m_E_ImageIcon2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_ImageIcon2");
     			}
     			return this.m_E_ImageIcon2Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon1Button == null )
     			{
		    		this.m_E_ImageIcon1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Mask/E_ImageIcon1");
     			}
     			return this.m_E_ImageIcon1Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon1Image == null )
     			{
		    		this.m_E_ImageIcon1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_ImageIcon1");
     			}
     			return this.m_E_ImageIcon1Image;
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
		    		this.m_E_Button_RefreshButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Refresh");
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
		    		this.m_E_Button_RefreshImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Refresh");
     			}
     			return this.m_E_Button_RefreshImage;
     		}
     	}

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
		    		this.m_E_Button_TeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Team");
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
		    		this.m_E_Button_TeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Team");
     			}
     			return this.m_E_Button_TeamImage;
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
		    		this.m_E_Button_RewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Reward");
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
		    		this.m_E_Button_RewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Reward");
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
		    		this.m_E_Button_RankButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Rank");
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
		    		this.m_E_Button_RankImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Rank");
     			}
     			return this.m_E_Button_RankImage;
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
		    		this.m_E_Text_ScoreText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Score");
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
		    		this.m_E_Text_RankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Rank");
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
			this.m_E_ImageIcon6Button = null;
			this.m_E_ImageIcon6Image = null;
			this.m_E_ImageIcon5Button = null;
			this.m_E_ImageIcon5Image = null;
			this.m_E_ImageIcon4Button = null;
			this.m_E_ImageIcon4Image = null;
			this.m_E_ImageIcon3Button = null;
			this.m_E_ImageIcon3Image = null;
			this.m_E_ImageIcon2Button = null;
			this.m_E_ImageIcon2Image = null;
			this.m_E_ImageIcon1Button = null;
			this.m_E_ImageIcon1Image = null;
			this.m_E_Button_RefreshButton = null;
			this.m_E_Button_RefreshImage = null;
			this.m_E_Button_TeamButton = null;
			this.m_E_Button_TeamImage = null;
			this.m_E_Button_RewardButton = null;
			this.m_E_Button_RewardImage = null;
			this.m_E_Button_RankButton = null;
			this.m_E_Button_RankImage = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Text_ScoreText = null;
			this.m_E_Text_RankText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageIcon6Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon6Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon5Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon5Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon4Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon4Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon3Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon3Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon2Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon2Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon1Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon1Image = null;
		private UnityEngine.UI.Button m_E_Button_RefreshButton = null;
		private UnityEngine.UI.Image m_E_Button_RefreshImage = null;
		private UnityEngine.UI.Button m_E_Button_TeamButton = null;
		private UnityEngine.UI.Image m_E_Button_TeamImage = null;
		private UnityEngine.UI.Button m_E_Button_RewardButton = null;
		private UnityEngine.UI.Image m_E_Button_RewardImage = null;
		private UnityEngine.UI.Button m_E_Button_RankButton = null;
		private UnityEngine.UI.Image m_E_Button_RankImage = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Text m_E_Text_ScoreText = null;
		private UnityEngine.UI.Text m_E_Text_RankText = null;
		public Transform uiTransform = null;
	}
}
