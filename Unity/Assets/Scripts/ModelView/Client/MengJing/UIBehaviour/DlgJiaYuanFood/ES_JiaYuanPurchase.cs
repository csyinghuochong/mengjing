using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanPurchase : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public long Timer;
		public JiaYuanComponentC JiaYuanComponentC { get; set; }
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanPurchaseItem>> ScrollItemJiaYuanPurchaseItems;

		public Button E_ButtonRefreshButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRefreshButton == null )
     			{
		    		this.m_E_ButtonRefreshButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonRefresh");
     			}
     			return this.m_E_ButtonRefreshButton;
     		}
     	}

		public Image E_ButtonRefreshImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRefreshImage == null )
     			{
		    		this.m_E_ButtonRefreshImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonRefresh");
     			}
     			return this.m_E_ButtonRefreshImage;
     		}
     	}

		public Text E_Text_TimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TimeText == null )
     			{
		    		this.m_E_Text_TimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Time");
     			}
     			return this.m_E_Text_TimeText;
     		}
     	}

		public LoopVerticalScrollRect E_JiaYuanPurchaseItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanPurchaseItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanPurchaseItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanPurchaseItems");
     			}
     			return this.m_E_JiaYuanPurchaseItemsLoopVerticalScrollRect;
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
			this.m_E_ButtonRefreshButton = null;
			this.m_E_ButtonRefreshImage = null;
			this.m_E_Text_TimeText = null;
			this.m_E_JiaYuanPurchaseItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonRefreshButton = null;
		private Image m_E_ButtonRefreshImage = null;
		private Text m_E_Text_TimeText = null;
		private LoopVerticalScrollRect m_E_JiaYuanPurchaseItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
