
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CreateRoleItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CreateRoleItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.RectTransform EG_RoleRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EG_RoleRectTransform == null )
     				{
		    			this.m_EG_RoleRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Role");
     				}
     				return this.m_EG_RoleRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Role");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_RoleOccText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RoleOccText == null )
     				{
		    			this.m_E_RoleOccText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Role/E_RoleOcc");
     				}
     				return this.m_E_RoleOccText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Role/E_RoleOcc");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_RoleNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RoleNameText == null )
     				{
		    			this.m_E_RoleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Role/E_RoleName");
     				}
     				return this.m_E_RoleNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Role/E_RoleName");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_RoleHeadIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RoleHeadIconImage == null )
     				{
		    			this.m_E_RoleHeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Role/E_RoleHeadIcon");
     				}
     				return this.m_E_RoleHeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Role/E_RoleHeadIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_RoleLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RoleLvText == null )
     				{
		    			this.m_E_RoleLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Role/E_RoleLv");
     				}
     				return this.m_E_RoleLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Role/E_RoleLv");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_NoRoleRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EG_NoRoleRectTransform == null )
     				{
		    			this.m_EG_NoRoleRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_NoRole");
     				}
     				return this.m_EG_NoRoleRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_NoRole");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_SelectRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_SelectRoleButton == null )
     				{
		    			this.m_E_SelectRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_SelectRole");
     				}
     				return this.m_E_SelectRoleButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_SelectRole");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_SelectRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_SelectRoleImage == null )
     				{
		    			this.m_E_SelectRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SelectRole");
     				}
     				return this.m_E_SelectRoleImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SelectRole");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_RoleRectTransform = null;
			this.m_E_RoleOccText = null;
			this.m_E_RoleNameText = null;
			this.m_E_RoleHeadIconImage = null;
			this.m_E_RoleLvText = null;
			this.m_EG_NoRoleRectTransform = null;
			this.m_E_SelectRoleButton = null;
			this.m_E_SelectRoleImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.RectTransform m_EG_RoleRectTransform = null;
		private UnityEngine.UI.Text m_E_RoleOccText = null;
		private UnityEngine.UI.Text m_E_RoleNameText = null;
		private UnityEngine.UI.Image m_E_RoleHeadIconImage = null;
		private UnityEngine.UI.Text m_E_RoleLvText = null;
		private UnityEngine.RectTransform m_EG_NoRoleRectTransform = null;
		private UnityEngine.UI.Button m_E_SelectRoleButton = null;
		private UnityEngine.UI.Image m_E_SelectRoleImage = null;
		public Transform uiTransform = null;
	}
}
