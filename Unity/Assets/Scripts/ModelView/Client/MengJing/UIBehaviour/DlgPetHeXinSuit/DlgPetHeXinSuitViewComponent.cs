using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetHeXinSuit))]
	[EnableMethod]
	public  class DlgPetHeXinSuitViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public RectTransform EG_UIPetHeXinSuitItemListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIPetHeXinSuitItemListNodeRectTransform == null )
     			{
		    		this.m_EG_UIPetHeXinSuitItemListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UIPetHeXinSuitItemListNode");
     			}
     			return this.m_EG_UIPetHeXinSuitItemListNodeRectTransform;
     		}
     	}

		public Image E_UIPetHeXinSuitItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIPetHeXinSuitItemImage == null )
     			{
		    		this.m_E_UIPetHeXinSuitItemImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIPetHeXinSuitItemListNode/E_UIPetHeXinSuitItem");
     			}
     			return this.m_E_UIPetHeXinSuitItemImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_EG_UIPetHeXinSuitItemListNodeRectTransform = null;
			this.m_E_UIPetHeXinSuitItemImage = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private RectTransform m_EG_UIPetHeXinSuitItemListNodeRectTransform = null;
		private Image m_E_UIPetHeXinSuitItemImage = null;
		public Transform uiTransform = null;
	}
}
