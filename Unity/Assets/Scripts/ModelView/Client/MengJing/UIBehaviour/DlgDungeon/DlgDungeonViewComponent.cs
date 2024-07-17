using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeon))]
	[EnableMethod]
	public  class DlgDungeonViewComponent : Entity,IAwake,IDestroy 
	{
		public LoopVerticalScrollRect E_BossRefreshTimeItemsLoopVerticalScrollRect
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
		    		this.m_E_BossRefreshTimeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BossRefreshTimeItems");
     			}
     			return this.m_E_BossRefreshTimeItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_BossRefreshSettingBtnButton
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
		    		this.m_E_BossRefreshSettingBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_BossRefreshSettingBtn");
     			}
     			return this.m_E_BossRefreshSettingBtnButton;
     		}
     	}

		public Image E_BossRefreshSettingBtnImage
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
		    		this.m_E_BossRefreshSettingBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BossRefreshSettingBtn");
     			}
     			return this.m_E_BossRefreshSettingBtnImage;
     		}
     	}

		public LoopVerticalScrollRect E_DungeonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DungeonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_DungeonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_DungeonItems");
     			}
     			return this.m_E_DungeonItemsLoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_BossRefreshSettingPanelRectTransform
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
		    		this.m_EG_BossRefreshSettingPanelRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel");
     			}
     			return this.m_EG_BossRefreshSettingPanelRectTransform;
     		}
     	}

		public Button E_CloseBossRefreshSettingBtnButton
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
		    		this.m_E_CloseBossRefreshSettingBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_CloseBossRefreshSettingBtn");
     			}
     			return this.m_E_CloseBossRefreshSettingBtnButton;
     		}
     	}

		public Image E_CloseBossRefreshSettingBtnImage
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
		    		this.m_E_CloseBossRefreshSettingBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_CloseBossRefreshSettingBtn");
     			}
     			return this.m_E_CloseBossRefreshSettingBtnImage;
     		}
     	}

		public Image E_BossRefreshSettingItemsImage
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
		    		this.m_E_BossRefreshSettingItemsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_BossRefreshSettingItems");
     			}
     			return this.m_E_BossRefreshSettingItemsImage;
     		}
     	}

		public LoopVerticalScrollRect E_BossRefreshSettingItemsLoopVerticalScrollRect
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
		    		this.m_E_BossRefreshSettingItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_BossRefreshSettingPanel/E_BossRefreshSettingItems");
     			}
     			return this.m_E_BossRefreshSettingItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonCloseButton
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Node1/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Node1/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BossRefreshTimeItemsLoopVerticalScrollRect = null;
			this.m_E_BossRefreshSettingBtnButton = null;
			this.m_E_BossRefreshSettingBtnImage = null;
			this.m_E_DungeonItemsLoopVerticalScrollRect = null;
			this.m_EG_BossRefreshSettingPanelRectTransform = null;
			this.m_E_CloseBossRefreshSettingBtnButton = null;
			this.m_E_CloseBossRefreshSettingBtnImage = null;
			this.m_E_BossRefreshSettingItemsImage = null;
			this.m_E_BossRefreshSettingItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_BossRefreshTimeItemsLoopVerticalScrollRect = null;
		private Button m_E_BossRefreshSettingBtnButton = null;
		private Image m_E_BossRefreshSettingBtnImage = null;
		private LoopVerticalScrollRect m_E_DungeonItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_BossRefreshSettingPanelRectTransform = null;
		private Button m_E_CloseBossRefreshSettingBtnButton = null;
		private Image m_E_CloseBossRefreshSettingBtnImage = null;
		private Image m_E_BossRefreshSettingItemsImage = null;
		private LoopVerticalScrollRect m_E_BossRefreshSettingItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
