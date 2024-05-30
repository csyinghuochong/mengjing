
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<RankingInfo> ShowRankingInfos = new();
		public Dictionary<int, Scroll_Item_RankShowItem> ScrollItemRankShowItems;
		public int CurrentItemType;
		
		public UnityEngine.RectTransform EG_UISetRectTransform
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
		    		this.m_EG_UISetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UISet");
     			}
     			return this.m_EG_UISetRectTransform;
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
		    		this.m_E_RankShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_UISet/E_RankShowItems");
     			}
     			return this.m_E_RankShowItemsLoopVerticalScrollRect;
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_TypeWarriorToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TypeWarriorToggle == null )
     			{
		    		this.m_E_TypeWarriorToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/E_TypeWarrior");
     			}
     			return this.m_E_TypeWarriorToggle;
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
		    		this.m_E_HeadIcomImage1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/E_TypeWarrior/E_HeadIcomImage1");
     			}
     			return this.m_E_HeadIcomImage1Image;
     		}
     	}

		public UnityEngine.UI.Toggle E_TypeMagicianToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TypeMagicianToggle == null )
     			{
		    		this.m_E_TypeMagicianToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/E_TypeMagician");
     			}
     			return this.m_E_TypeMagicianToggle;
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
		    		this.m_E_HeadIcomImage2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/E_TypeMagician/E_HeadIcomImage2");
     			}
     			return this.m_E_HeadIcomImage2Image;
     		}
     	}

		public UnityEngine.UI.Toggle E_TypeHunterToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TypeHunterToggle == null )
     			{
		    		this.m_E_TypeHunterToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/E_TypeHunter");
     			}
     			return this.m_E_TypeHunterToggle;
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
		    		this.m_E_HeadIcomImage3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UISet/E_ItemTypeSet/E_TypeHunter/E_HeadIcomImage3");
     			}
     			return this.m_E_HeadIcomImage3Image;
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
		    		this.m_E_Text_MyRankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UISet/E_Text_MyRank");
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
			this.m_E_TypeWarriorToggle = null;
			this.m_E_HeadIcomImage1Image = null;
			this.m_E_TypeMagicianToggle = null;
			this.m_E_HeadIcomImage2Image = null;
			this.m_E_TypeHunterToggle = null;
			this.m_E_HeadIcomImage3Image = null;
			this.m_E_Text_MyRankText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_UISetRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RankShowItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_TypeWarriorToggle = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage1Image = null;
		private UnityEngine.UI.Toggle m_E_TypeMagicianToggle = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage2Image = null;
		private UnityEngine.UI.Toggle m_E_TypeHunterToggle = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage3Image = null;
		private UnityEngine.UI.Text m_E_Text_MyRankText = null;
		public Transform uiTransform = null;
	}
}
