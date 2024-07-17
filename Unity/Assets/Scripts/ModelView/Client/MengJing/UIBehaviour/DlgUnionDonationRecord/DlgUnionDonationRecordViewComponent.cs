using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionDonationRecord))]
	[EnableMethod]
	public  class DlgUnionDonationRecordViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public RectTransform EG_BuildingListRectTransform
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
		    		this.m_EG_BuildingListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView_2/Viewport/EG_BuildingList");
     			}
     			return this.m_EG_BuildingListRectTransform;
     		}
     	}

		public RectTransform EG_UIUnionDonationRecordItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIUnionDonationRecordItemRectTransform == null )
     			{
		    		this.m_EG_UIUnionDonationRecordItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView_2/Viewport/EG_BuildingList/EG_UIUnionDonationRecordItem");
     			}
     			return this.m_EG_UIUnionDonationRecordItemRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_EG_BuildingListRectTransform = null;
			this.m_EG_UIUnionDonationRecordItemRectTransform = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private RectTransform m_EG_BuildingListRectTransform = null;
		private RectTransform m_EG_UIUnionDonationRecordItemRectTransform = null;
		public Transform uiTransform = null;
	}
}
