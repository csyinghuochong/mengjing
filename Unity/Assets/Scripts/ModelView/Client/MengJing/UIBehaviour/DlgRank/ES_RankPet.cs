using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankPet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<EntityRef<ES_RankPetItem>> PetUIList = new();
		public GameObject[] ImageIconList;
		
		public UnityEngine.RectTransform EG_PetListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetListNodeRectTransform == null )
     			{
		    		this.m_EG_PetListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_PetListNode");
     			}
     			return this.m_EG_PetListNodeRectTransform;
     		}
     	}

		public ES_RankPetItem ES_RankPetItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RankPetItem es = this.m_es_rankpetitem;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/EG_PetListNode/ES_RankPetItem");
		    	   this.m_es_rankpetitem = this.AddChild<ES_RankPetItem,Transform>(subTrans);
     			}
     			return this.m_es_rankpetitem;
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
		    		this.m_E_Button_RefreshButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_Refresh");
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
		    		this.m_E_Button_RefreshImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_Refresh");
     			}
     			return this.m_E_Button_RefreshImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CombatText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CombatText == null )
     			{
		    		this.m_E_Text_CombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_Combat");
     			}
     			return this.m_E_Text_CombatText;
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
		    		this.m_E_ImageIcon1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon1");
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
		    		this.m_E_ImageIcon1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon1");
     			}
     			return this.m_E_ImageIcon1Image;
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
		    		this.m_E_ImageIcon2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon2");
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
		    		this.m_E_ImageIcon2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon2");
     			}
     			return this.m_E_ImageIcon2Image;
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
		    		this.m_E_ImageIcon3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon3");
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
		    		this.m_E_ImageIcon3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon3");
     			}
     			return this.m_E_ImageIcon3Image;
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
		    		this.m_E_ImageIcon4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon4");
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
		    		this.m_E_ImageIcon4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon4");
     			}
     			return this.m_E_ImageIcon4Image;
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
		    		this.m_E_ImageIcon5Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon5");
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
		    		this.m_E_ImageIcon5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/IconShowSet/Mask/E_ImageIcon5");
     			}
     			return this.m_E_ImageIcon5Image;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeftTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LeftTimeText == null )
     			{
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_LeftTime");
     			}
     			return this.m_E_Text_LeftTimeText;
     		}
     	}

		public UnityEngine.UI.Button E_Button_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddButton == null )
     			{
		    		this.m_E_Button_AddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Add");
     			}
     			return this.m_E_Button_AddButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddImage == null )
     			{
		    		this.m_E_Button_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Add");
     			}
     			return this.m_E_Button_AddImage;
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
		    		this.m_E_Button_TeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Team");
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
		    		this.m_E_Button_TeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Team");
     			}
     			return this.m_E_Button_TeamImage;
     		}
     	}

		public UnityEngine.UI.Button E_RankRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankRewardButton == null )
     			{
		    		this.m_E_RankRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_RankReward");
     			}
     			return this.m_E_RankRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_RankRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankRewardImage == null )
     			{
		    		this.m_E_RankRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_RankReward");
     			}
     			return this.m_E_RankRewardImage;
     		}
     	}

		public ES_RankPetReward ES_RankPetReward
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RankPetReward es = this.m_es_rankpetreward;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RankPetReward");
		    	   this.m_es_rankpetreward = this.AddChild<ES_RankPetReward,Transform>(subTrans);
     			}
     			return this.m_es_rankpetreward;
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
			this.m_EG_PetListNodeRectTransform = null;
			this.m_es_rankpetitem = null;
			this.m_E_Button_RefreshButton = null;
			this.m_E_Button_RefreshImage = null;
			this.m_E_Text_CombatText = null;
			this.m_E_Button_RewardButton = null;
			this.m_E_Button_RewardImage = null;
			this.m_E_Text_RankText = null;
			this.m_E_ImageIcon1Button = null;
			this.m_E_ImageIcon1Image = null;
			this.m_E_ImageIcon2Button = null;
			this.m_E_ImageIcon2Image = null;
			this.m_E_ImageIcon3Button = null;
			this.m_E_ImageIcon3Image = null;
			this.m_E_ImageIcon4Button = null;
			this.m_E_ImageIcon4Image = null;
			this.m_E_ImageIcon5Button = null;
			this.m_E_ImageIcon5Image = null;
			this.m_E_Text_LeftTimeText = null;
			this.m_E_Button_AddButton = null;
			this.m_E_Button_AddImage = null;
			this.m_E_Button_TeamButton = null;
			this.m_E_Button_TeamImage = null;
			this.m_E_RankRewardButton = null;
			this.m_E_RankRewardImage = null;
			this.m_es_rankpetreward = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PetListNodeRectTransform = null;
		private EntityRef<ES_RankPetItem> m_es_rankpetitem = null;
		private UnityEngine.UI.Button m_E_Button_RefreshButton = null;
		private UnityEngine.UI.Image m_E_Button_RefreshImage = null;
		private UnityEngine.UI.Text m_E_Text_CombatText = null;
		private UnityEngine.UI.Button m_E_Button_RewardButton = null;
		private UnityEngine.UI.Image m_E_Button_RewardImage = null;
		private UnityEngine.UI.Text m_E_Text_RankText = null;
		private UnityEngine.UI.Button m_E_ImageIcon1Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon1Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon2Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon2Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon3Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon3Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon4Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon4Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon5Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon5Image = null;
		private UnityEngine.UI.Text m_E_Text_LeftTimeText = null;
		private UnityEngine.UI.Button m_E_Button_AddButton = null;
		private UnityEngine.UI.Image m_E_Button_AddImage = null;
		private UnityEngine.UI.Button m_E_Button_TeamButton = null;
		private UnityEngine.UI.Image m_E_Button_TeamImage = null;
		private UnityEngine.UI.Button m_E_RankRewardButton = null;
		private UnityEngine.UI.Image m_E_RankRewardImage = null;
		private EntityRef<ES_RankPetReward> m_es_rankpetreward = null;
		public Transform uiTransform = null;
	}
}
