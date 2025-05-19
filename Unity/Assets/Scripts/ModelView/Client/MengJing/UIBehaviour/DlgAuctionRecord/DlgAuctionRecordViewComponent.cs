
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgAuctionRecord))]
	[EnableMethod]
	public  class DlgAuctionRecordViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonClose");
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_BuildingListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BuildingListRectTransform == null )
     			{
		    		this.m_EG_BuildingListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/ScrollView_2/Viewport/EG_BuildingList");
     			}
     			return this.m_EG_BuildingListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UIAuctionRecordItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIAuctionRecordItemRectTransform == null )
     			{
		    		this.m_EG_UIAuctionRecordItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/ScrollView_2/Viewport/EG_BuildingList/EG_UIAuctionRecordItem");
     			}
     			return this.m_EG_UIAuctionRecordItemRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_EG_BuildingListRectTransform = null;
			this.m_EG_UIAuctionRecordItemRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.RectTransform m_EG_BuildingListRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIAuctionRecordItemRectTransform = null;
		public Transform uiTransform = null;
	}
}
