
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSeasonLordDetail))]
	[EnableMethod]
	public  class DlgSeasonLordDetailViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CloseBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnButton == null )
     			{
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnImage == null )
     			{
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnImage;
     		}
     	}

		public UnityEngine.UI.Text E_PositionTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PositionTextText == null )
     			{
		    		this.m_E_PositionTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PositionText");
     			}
     			return this.m_E_PositionTextText;
     		}
     	}

		public UnityEngine.UI.Text E_RefreshTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RefreshTimeTextText == null )
     			{
		    		this.m_E_RefreshTimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RefreshTimeText");
     			}
     			return this.m_E_RefreshTimeTextText;
     		}
     	}

		public UnityEngine.UI.Image E_MonsterHeadImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterHeadImgImage == null )
     			{
		    		this.m_E_MonsterHeadImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MonsterHeadImg");
     			}
     			return this.m_E_MonsterHeadImgImage;
     		}
     	}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNameTextText == null )
     			{
		    		this.m_E_ItemNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemNameText");
     			}
     			return this.m_E_ItemNameTextText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemDesTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDesTextText == null )
     			{
		    		this.m_E_ItemDesTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemDesText");
     			}
     			return this.m_E_ItemDesTextText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_UseItemBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseItemBtnButton == null )
     			{
		    		this.m_E_UseItemBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_UseItemBtn");
     			}
     			return this.m_E_UseItemBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_UseItemBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseItemBtnImage == null )
     			{
		    		this.m_E_UseItemBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_UseItemBtn");
     			}
     			return this.m_E_UseItemBtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseBtnButton = null;
			this.m_E_CloseBtnImage = null;
			this.m_E_PositionTextText = null;
			this.m_E_RefreshTimeTextText = null;
			this.m_E_MonsterHeadImgImage = null;
			this.m_es_commonitem = null;
			this.m_E_ItemNameTextText = null;
			this.m_E_ItemDesTextText = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_UseItemBtnButton = null;
			this.m_E_UseItemBtnImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CloseBtnButton = null;
		private UnityEngine.UI.Image m_E_CloseBtnImage = null;
		private UnityEngine.UI.Text m_E_PositionTextText = null;
		private UnityEngine.UI.Text m_E_RefreshTimeTextText = null;
		private UnityEngine.UI.Image m_E_MonsterHeadImgImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Text m_E_ItemNameTextText = null;
		private UnityEngine.UI.Text m_E_ItemDesTextText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_UseItemBtnButton = null;
		private UnityEngine.UI.Image m_E_UseItemBtnImage = null;
		public Transform uiTransform = null;
	}
}
