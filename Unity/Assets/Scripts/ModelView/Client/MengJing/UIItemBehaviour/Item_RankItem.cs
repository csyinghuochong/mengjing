using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RankItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_RankItem>
	{
		public RankingTrialInfo RankingInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RankItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageBg1Image
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
     				if( this.m_E_ImageBg1Image == null )
     				{
		    			this.m_E_ImageBg1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg1");
     				}
     				return this.m_E_ImageBg1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg1");
     			}
     		}
     	}

		public Image E_ImageBg2Image
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
     				if( this.m_E_ImageBg2Image == null )
     				{
		    			this.m_E_ImageBg2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg2");
     				}
     				return this.m_E_ImageBg2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg2");
     			}
     		}
     	}

		public Image E_ImageHeadIconImage
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
     				if( this.m_E_ImageHeadIconImage == null )
     				{
		    			this.m_E_ImageHeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageHeadIcon");
     				}
     				return this.m_E_ImageHeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageHeadIcon");
     			}
     		}
     	}

		public RectTransform EG_RankShowSetRectTransform
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
     				if( this.m_EG_RankShowSetRectTransform == null )
     				{
		    			this.m_EG_RankShowSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RankShowSet");
     				}
     				return this.m_EG_RankShowSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RankShowSet");
     			}
     		}
     	}

		public Image E_Rank_1Image
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
     				if( this.m_E_Rank_1Image == null )
     				{
		    			this.m_E_Rank_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_1");
     				}
     				return this.m_E_Rank_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_1");
     			}
     		}
     	}

		public Image E_Rank_2Image
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
     				if( this.m_E_Rank_2Image == null )
     				{
		    			this.m_E_Rank_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_2");
     				}
     				return this.m_E_Rank_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_2");
     			}
     		}
     	}

		public Image E_Rank_3Image
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
     				if( this.m_E_Rank_3Image == null )
     				{
		    			this.m_E_Rank_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_3");
     				}
     				return this.m_E_Rank_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_3");
     			}
     		}
     	}

		public Text E_Text_RankText
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
     				if( this.m_E_Text_RankText == null )
     				{
		    			this.m_E_Text_RankText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Rank");
     				}
     				return this.m_E_Text_RankText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Rank");
     			}
     		}
     	}

		public Text E_Text_NameText
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
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public Text E_Text_LevelText
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
     				if( this.m_E_Text_LevelText == null )
     				{
		    			this.m_E_Text_LevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Level");
     				}
     				return this.m_E_Text_LevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Level");
     			}
     		}
     	}

		public Text E_Text_CombatText
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
     				if( this.m_E_Text_CombatText == null )
     				{
		    			this.m_E_Text_CombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Combat");
     				}
     				return this.m_E_Text_CombatText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Combat");
     			}
     		}
     	}

		public Button E_Button_WatchEquipButton
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
     				if( this.m_E_Button_WatchEquipButton == null )
     				{
		    			this.m_E_Button_WatchEquipButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     				}
     				return this.m_E_Button_WatchEquipButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     			}
     		}
     	}

		public Image E_Button_WatchEquipImage
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
     				if( this.m_E_Button_WatchEquipImage == null )
     				{
		    			this.m_E_Button_WatchEquipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     				}
     				return this.m_E_Button_WatchEquipImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     			}
     		}
     	}

		public Button E_Button_WatchPetButton
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
     				if( this.m_E_Button_WatchPetButton == null )
     				{
		    			this.m_E_Button_WatchPetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_WatchPet");
     				}
     				return this.m_E_Button_WatchPetButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_WatchPet");
     			}
     		}
     	}

		public Image E_Button_WatchPetImage
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
     				if( this.m_E_Button_WatchPetImage == null )
     				{
		    			this.m_E_Button_WatchPetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_WatchPet");
     				}
     				return this.m_E_Button_WatchPetImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_WatchPet");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageBg1Image = null;
			this.m_E_ImageBg2Image = null;
			this.m_E_ImageHeadIconImage = null;
			this.m_EG_RankShowSetRectTransform = null;
			this.m_E_Rank_1Image = null;
			this.m_E_Rank_2Image = null;
			this.m_E_Rank_3Image = null;
			this.m_E_Text_RankText = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_LevelText = null;
			this.m_E_Text_CombatText = null;
			this.m_E_Button_WatchEquipButton = null;
			this.m_E_Button_WatchEquipImage = null;
			this.m_E_Button_WatchPetButton = null;
			this.m_E_Button_WatchPetImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageBg1Image = null;
		private Image m_E_ImageBg2Image = null;
		private Image m_E_ImageHeadIconImage = null;
		private RectTransform m_EG_RankShowSetRectTransform = null;
		private Image m_E_Rank_1Image = null;
		private Image m_E_Rank_2Image = null;
		private Image m_E_Rank_3Image = null;
		private Text m_E_Text_RankText = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_LevelText = null;
		private Text m_E_Text_CombatText = null;
		private Button m_E_Button_WatchEquipButton = null;
		private Image m_E_Button_WatchEquipImage = null;
		private Button m_E_Button_WatchPetButton = null;
		private Image m_E_Button_WatchPetImage = null;
		public Transform uiTransform = null;
	}
}
