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

		public RectTransform EG_UISetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UISetRectTransform == null )
     			{
		    		this.m_EG_UISetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UISet");
     			}
     			return this.m_EG_UISetRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_RankShowItemsLoopVerticalScrollRect
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
		    		this.m_E_RankShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_UISet/E_RankShowItems");
     			}
     			return this.m_E_RankShowItemsLoopVerticalScrollRect;
     		}
     	}

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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public Image E_HeadIcomImage1Image
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
		    		this.m_E_HeadIcomImage1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/Type_0/E_HeadIcomImage1");
     			}
     			return this.m_E_HeadIcomImage1Image;
     		}
     	}

		public Image E_HeadIcomImage2Image
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
		    		this.m_E_HeadIcomImage2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/Type_1/E_HeadIcomImage2");
     			}
     			return this.m_E_HeadIcomImage2Image;
     		}
     	}

		public Image E_HeadIcomImage3Image
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
		    		this.m_E_HeadIcomImage3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/Type_2/E_HeadIcomImage3");
     			}
     			return this.m_E_HeadIcomImage3Image;
     		}
     	}

		public Text E_Text_MyRankText
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
		    		this.m_E_Text_MyRankText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_UISet/E_Text_MyRank");
     			}
     			return this.m_E_Text_MyRankText;
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
			this.m_EG_UISetRectTransform = null;
			this.m_E_RankShowItemsLoopVerticalScrollRect = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_HeadIcomImage1Image = null;
			this.m_E_HeadIcomImage2Image = null;
			this.m_E_HeadIcomImage3Image = null;
			this.m_E_Text_MyRankText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_UISetRectTransform = null;
		private LoopVerticalScrollRect m_E_RankShowItemsLoopVerticalScrollRect = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private Image m_E_HeadIcomImage1Image = null;
		private Image m_E_HeadIcomImage2Image = null;
		private Image m_E_HeadIcomImage3Image = null;
		private Text m_E_Text_MyRankText = null;
		public Transform uiTransform = null;
	}
}
