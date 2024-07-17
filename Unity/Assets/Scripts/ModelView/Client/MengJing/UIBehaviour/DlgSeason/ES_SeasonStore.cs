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
		
		public LoopVerticalScrollRect E_SeasonStoreItemsLoopVerticalScrollRect
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
		    		this.m_E_SeasonStoreItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SeasonStoreItems");
     			}
     			return this.m_E_SeasonStoreItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_GoldNumTextText
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
		    		this.m_E_GoldNumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_GoldNumText");
     			}
     			return this.m_E_GoldNumTextText;
     		}
     	}

		public Image E_GoldImgImage
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
		    		this.m_E_GoldImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_GoldImg");
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
			this.m_E_SeasonStoreItemsLoopVerticalScrollRect = null;
			this.m_E_GoldNumTextText = null;
			this.m_E_GoldImgImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_SeasonStoreItemsLoopVerticalScrollRect = null;
		private Text m_E_GoldNumTextText = null;
		private Image m_E_GoldImgImage = null;
		public Transform uiTransform = null;
	}
}
