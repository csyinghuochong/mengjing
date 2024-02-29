
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleProperty))]
	[EnableMethod]
	public  class DlgRolePropertyViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_RolePropertyBaseItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/AttributeNode/E_RolePropertyBaseItems");
     			}
     			return this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_PiLaoImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PiLaoImgImage == null )
     			{
		    		this.m_E_PiLaoImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/AttributeNode/ProSet/TiLi/E_PiLaoImg");
     			}
     			return this.m_E_PiLaoImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_PiLaoTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PiLaoTextText == null )
     			{
		    		this.m_E_PiLaoTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/AttributeNode/ProSet/TiLi/E_PiLaoText");
     			}
     			return this.m_E_PiLaoTextText;
     		}
     	}

		public UnityEngine.UI.Image E_BaoShiDuImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BaoShiDuImgImage == null )
     			{
		    		this.m_E_BaoShiDuImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/AttributeNode/ProSet/Satiety/E_BaoShiDuImg");
     			}
     			return this.m_E_BaoShiDuImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_BaoShiDuTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BaoShiDuTextText == null )
     			{
		    		this.m_E_BaoShiDuTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/AttributeNode/ProSet/Satiety/E_BaoShiDuText");
     			}
     			return this.m_E_BaoShiDuTextText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RolePropertyTeShuItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/AttributeNode/E_RolePropertyTeShuItems");
     			}
     			return this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_AddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddPointButton == null )
     			{
		    		this.m_E_AddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/AttributeNode/E_AddPoint");
     			}
     			return this.m_E_AddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddPointImage == null )
     			{
		    		this.m_E_AddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/AttributeNode/E_AddPoint");
     			}
     			return this.m_E_AddPointImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect = null;
			this.m_E_PiLaoImgImage = null;
			this.m_E_PiLaoTextText = null;
			this.m_E_BaoShiDuImgImage = null;
			this.m_E_BaoShiDuTextText = null;
			this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = null;
			this.m_E_AddPointButton = null;
			this.m_E_AddPointImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_RolePropertyBaseItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_PiLaoImgImage = null;
		private UnityEngine.UI.Text m_E_PiLaoTextText = null;
		private UnityEngine.UI.Image m_E_BaoShiDuImgImage = null;
		private UnityEngine.UI.Text m_E_BaoShiDuTextText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_AddPointButton = null;
		private UnityEngine.UI.Image m_E_AddPointImage = null;
		public Transform uiTransform = null;
	}
}
