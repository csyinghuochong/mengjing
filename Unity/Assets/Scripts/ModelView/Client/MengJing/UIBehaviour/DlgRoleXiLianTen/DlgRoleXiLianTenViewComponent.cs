
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleXiLianTen))]
	[EnableMethod]
	public  class DlgRoleXiLianTenViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonCloseButton == null )
     			{
		    		this.m_E_ImageButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButtonClose");
     			}
     			return this.m_E_ImageButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonCloseImage == null )
     			{
		    		this.m_E_ImageButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButtonClose");
     			}
     			return this.m_E_ImageButtonCloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ItemListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ItemListNodeRectTransform == null )
     			{
		    		this.m_EG_ItemListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_ItemListNode");
     			}
     			return this.m_EG_ItemListNodeRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonCloseButton = null;
			this.m_E_ImageButtonCloseImage = null;
			this.m_EG_ItemListNodeRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonCloseImage = null;
		private UnityEngine.RectTransform m_EG_ItemListNodeRectTransform = null;
		public Transform uiTransform = null;
	}
}
