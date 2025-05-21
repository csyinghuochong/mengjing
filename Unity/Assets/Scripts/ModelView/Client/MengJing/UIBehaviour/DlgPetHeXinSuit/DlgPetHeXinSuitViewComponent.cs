
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetHeXinSuit))]
	[EnableMethod]
	public  class DlgPetHeXinSuitViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_CloseButton
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UIPetHeXinSuitItemListNodeRectTransform
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
		    		this.m_EG_UIPetHeXinSuitItemListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_UIPetHeXinSuitItemListNode");
     			}
     			return this.m_EG_UIPetHeXinSuitItemListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_UIPetHeXinSuitItemImage
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
		    		this.m_E_UIPetHeXinSuitItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_UIPetHeXinSuitItemListNode/E_UIPetHeXinSuitItem");
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

		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.RectTransform m_EG_UIPetHeXinSuitItemListNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_UIPetHeXinSuitItemImage = null;
		public Transform uiTransform = null;
	}
}
