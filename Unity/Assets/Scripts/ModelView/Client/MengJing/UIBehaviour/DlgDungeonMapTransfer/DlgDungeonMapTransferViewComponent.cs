
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeonMapTransfer))]
	[EnableMethod]
	public  class DlgDungeonMapTransferViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_BossRefreshTimeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshTimeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BossRefreshTimeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BossRefreshTimeItems");
     			}
     			return this.m_E_BossRefreshTimeItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_BossRefreshSettingBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshSettingBtnButton == null )
     			{
		    		this.m_E_BossRefreshSettingBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BossRefreshSettingBtn");
     			}
     			return this.m_E_BossRefreshSettingBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_BossRefreshSettingBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshSettingBtnImage == null )
     			{
		    		this.m_E_BossRefreshSettingBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BossRefreshSettingBtn");
     			}
     			return this.m_E_BossRefreshSettingBtnImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_DungeonLevelItemLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DungeonLevelItemLoopVerticalScrollRect == null )
     			{
		    		this.m_E_DungeonLevelItemLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_DungeonLevelItem");
     			}
     			return this.m_E_DungeonLevelItemLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_BossRefreshSettingPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BossRefreshSettingPanelRectTransform == null )
     			{
		    		this.m_EG_BossRefreshSettingPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel");
     			}
     			return this.m_EG_BossRefreshSettingPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_CloseBossRefreshSettingBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBossRefreshSettingBtnButton == null )
     			{
		    		this.m_E_CloseBossRefreshSettingBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_CloseBossRefreshSettingBtn");
     			}
     			return this.m_E_CloseBossRefreshSettingBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseBossRefreshSettingBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBossRefreshSettingBtnImage == null )
     			{
		    		this.m_E_CloseBossRefreshSettingBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_CloseBossRefreshSettingBtn");
     			}
     			return this.m_E_CloseBossRefreshSettingBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_BossRefreshSettingItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshSettingItemsImage == null )
     			{
		    		this.m_E_BossRefreshSettingItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_BossRefreshSettingItems");
     			}
     			return this.m_E_BossRefreshSettingItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BossRefreshSettingItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshSettingItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BossRefreshSettingItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_BossRefreshSettingItems");
     			}
     			return this.m_E_BossRefreshSettingItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Node1/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Node1/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public UnityEngine.UI.Text E_ChapterTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChapterTextText == null )
     			{
		    		this.m_E_ChapterTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ChapterText");
     			}
     			return this.m_E_ChapterTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BossRefreshTimeItemsLoopVerticalScrollRect = null;
			this.m_E_BossRefreshSettingBtnButton = null;
			this.m_E_BossRefreshSettingBtnImage = null;
			this.m_E_DungeonLevelItemLoopVerticalScrollRect = null;
			this.m_EG_BossRefreshSettingPanelRectTransform = null;
			this.m_E_CloseBossRefreshSettingBtnButton = null;
			this.m_E_CloseBossRefreshSettingBtnImage = null;
			this.m_E_BossRefreshSettingItemsImage = null;
			this.m_E_BossRefreshSettingItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_ChapterTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_BossRefreshTimeItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_BossRefreshSettingBtnButton = null;
		private UnityEngine.UI.Image m_E_BossRefreshSettingBtnImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_DungeonLevelItemLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_BossRefreshSettingPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_CloseBossRefreshSettingBtnButton = null;
		private UnityEngine.UI.Image m_E_CloseBossRefreshSettingBtnImage = null;
		private UnityEngine.UI.Image m_E_BossRefreshSettingItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BossRefreshSettingItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.UI.Text m_E_ChapterTextText = null;
		public Transform uiTransform = null;
	}
}
