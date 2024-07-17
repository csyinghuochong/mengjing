using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanRecord))]
	[EnableMethod]
	public  class DlgJiaYuanRecordViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseButton == null )
     			{
		    		this.m_E_ImageCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseButton;
     		}
     	}

		public Image E_ImageCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseImage == null )
     			{
		    		this.m_E_ImageCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseImage;
     		}
     	}

		public RectTransform EG_BuildingList2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BuildingList2RectTransform == null )
     			{
		    		this.m_EG_BuildingList2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView2/Viewport/EG_BuildingList2");
     			}
     			return this.m_EG_BuildingList2RectTransform;
     		}
     	}

		public RectTransform EG_UIJiaYuanRecordItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIJiaYuanRecordItemRectTransform == null )
     			{
		    		this.m_EG_UIJiaYuanRecordItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView2/Viewport/EG_BuildingList2/EG_UIJiaYuanRecordItem");
     			}
     			return this.m_EG_UIJiaYuanRecordItemRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageCloseButton = null;
			this.m_E_ImageCloseImage = null;
			this.m_EG_BuildingList2RectTransform = null;
			this.m_EG_UIJiaYuanRecordItemRectTransform = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageCloseButton = null;
		private Image m_E_ImageCloseImage = null;
		private RectTransform m_EG_BuildingList2RectTransform = null;
		private RectTransform m_EG_UIJiaYuanRecordItemRectTransform = null;
		public Transform uiTransform = null;
	}
}
