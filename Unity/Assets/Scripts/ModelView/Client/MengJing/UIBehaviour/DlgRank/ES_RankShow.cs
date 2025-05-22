
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<RankingInfo> ShowRankingInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_RankShowItem>> ScrollItemRankShowItems;
		public int CurrentItemType;
		private EntityRef<Scroll_Item_RankShowItem> myRankShowItem;
		public Scroll_Item_RankShowItem MyRankShowItem { get => this.myRankShowItem; set => this.myRankShowItem = value; }
		
		public UnityEngine.RectTransform EG_LeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftRectTransform == null )
     			{
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_MyRankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_MyRankText == null )
     			{
		    		this.m_E_Text_MyRankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_Text_MyRank");
     			}
     			return this.m_E_Text_MyRankText;
     		}
     	}

		public UnityEngine.RectTransform EG_Rank_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Rank_1RectTransform == null )
     			{
		    		this.m_EG_Rank_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_Rank_1");
     			}
     			return this.m_EG_Rank_1RectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Left/EG_Rank_1/ES_ModelShow_1");
		    	   this.m_es_modelshow_1 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow_1;
     		}
     	}

		public UnityEngine.RectTransform EG_Rank_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Rank_2RectTransform == null )
     			{
		    		this.m_EG_Rank_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_Rank_2");
     			}
     			return this.m_EG_Rank_2RectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Left/EG_Rank_2/ES_ModelShow_2");
		    	   this.m_es_modelshow_2 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow_2;
     		}
     	}

		public UnityEngine.RectTransform EG_Rank_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Rank_3RectTransform == null )
     			{
		    		this.m_EG_Rank_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_Rank_3");
     			}
     			return this.m_EG_Rank_3RectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Left/EG_Rank_3/ES_ModelShow_3");
		    	   this.m_es_modelshow_3 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow_3;
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
		    		this.m_E_RankRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/E_RankReward");
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
		    		this.m_E_RankRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/E_RankReward");
     			}
     			return this.m_E_RankRewardImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RightRectTransform
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
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RankShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RankShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/E_RankShowItems");
     			}
     			return this.m_E_RankShowItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_MyRankShowRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MyRankShowRectTransform == null )
     			{
		    		this.m_EG_MyRankShowRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_MyRankShow");
     			}
     			return this.m_EG_MyRankShowRectTransform;
     		}
     	}

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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage1Image == null )
     			{
		    		this.m_E_HeadIcomImage1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet/Type_0/E_HeadIcomImage1");
     			}
     			return this.m_E_HeadIcomImage1Image;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage2Image == null )
     			{
		    		this.m_E_HeadIcomImage2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet/Type_1/E_HeadIcomImage2");
     			}
     			return this.m_E_HeadIcomImage2Image;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage3Image == null )
     			{
		    		this.m_E_HeadIcomImage3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet/Type_2/E_HeadIcomImage3");
     			}
     			return this.m_E_HeadIcomImage3Image;
     		}
     	}

		public ES_RankReward ES_RankReward
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RankReward es = this.m_es_rankreward;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RankReward");
		    	   this.m_es_rankreward = this.AddChild<ES_RankReward,Transform>(subTrans);
     			}
     			return this.m_es_rankreward;
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
			this.m_EG_LeftRectTransform = null;
			this.m_E_Text_MyRankText = null;
			this.m_EG_Rank_1RectTransform = null;
			this.m_es_modelshow_1 = null;
			this.m_EG_Rank_2RectTransform = null;
			this.m_es_modelshow_2 = null;
			this.m_EG_Rank_3RectTransform = null;
			this.m_es_modelshow_3 = null;
			this.m_E_RankRewardButton = null;
			this.m_E_RankRewardImage = null;
			this.m_EG_RightRectTransform = null;
			this.m_E_RankShowItemsLoopVerticalScrollRect = null;
			this.m_EG_MyRankShowRectTransform = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_HeadIcomImage1Image = null;
			this.m_E_HeadIcomImage2Image = null;
			this.m_E_HeadIcomImage3Image = null;
			this.m_es_rankreward = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_MyRankText = null;
		private UnityEngine.RectTransform m_EG_Rank_1RectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow_1 = null;
		private UnityEngine.RectTransform m_EG_Rank_2RectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow_2 = null;
		private UnityEngine.RectTransform m_EG_Rank_3RectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow_3 = null;
		private UnityEngine.UI.Button m_E_RankRewardButton = null;
		private UnityEngine.UI.Image m_E_RankRewardImage = null;
		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RankShowItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_MyRankShowRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage1Image = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage2Image = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage3Image = null;
		private EntityRef<ES_RankReward> m_es_rankreward = null;
		public Transform uiTransform = null;
	}
}
