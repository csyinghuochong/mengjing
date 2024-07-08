
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanPurchase : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public long Timer;
		public JiaYuanComponentC JiaYuanComponentC { get; set; }
		public Dictionary<int, Scroll_Item_JiaYuanPurchaseItem> ScrollItemJiaYuanPurchaseItems;

		public UnityEngine.UI.Button E_ButtonRefreshButton
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
		    		this.m_E_ButtonRefreshButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonRefresh");
     			}
     			return this.m_E_ButtonRefreshButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRefreshImage
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
		    		this.m_E_ButtonRefreshImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonRefresh");
     			}
     			return this.m_E_ButtonRefreshImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_TimeText
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
		    		this.m_E_Text_TimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Time");
     			}
     			return this.m_E_Text_TimeText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_JiaYuanPurchaseItemsLoopVerticalScrollRect
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
		    		this.m_E_JiaYuanPurchaseItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanPurchaseItems");
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

		private UnityEngine.UI.Button m_E_ButtonRefreshButton = null;
		private UnityEngine.UI.Image m_E_ButtonRefreshImage = null;
		private UnityEngine.UI.Text m_E_Text_TimeText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_JiaYuanPurchaseItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
