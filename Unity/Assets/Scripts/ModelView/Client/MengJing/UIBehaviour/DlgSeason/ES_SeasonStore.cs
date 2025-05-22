using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonStore : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<int> ShowItems = new();
		public Dictionary<int, EntityRef<Scroll_Item_SeasonStoreItem>> ScrollItemSeasonStoreItems;
		
		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SeasonStoreItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonStoreItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SeasonStoreItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_SeasonStoreItems");
     			}
     			return this.m_E_SeasonStoreItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_GoldNumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GoldNumTextText == null )
     			{
		    		this.m_E_GoldNumTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_GoldNumText");
     			}
     			return this.m_E_GoldNumTextText;
     		}
     	}

		public UnityEngine.UI.Image E_GoldImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GoldImgImage == null )
     			{
		    		this.m_E_GoldImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_GoldImg");
     			}
     			return this.m_E_GoldImgImage;
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
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_E_SeasonStoreItemsLoopVerticalScrollRect = null;
			this.m_E_GoldNumTextText = null;
			this.m_E_GoldImgImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SeasonStoreItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_GoldNumTextText = null;
		private UnityEngine.UI.Image m_E_GoldImgImage = null;
		public Transform uiTransform = null;
	}
}
