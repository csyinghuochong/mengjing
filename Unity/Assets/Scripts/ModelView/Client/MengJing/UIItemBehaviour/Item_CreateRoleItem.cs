using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CreateRoleItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_CreateRoleItem>
	{
		public CreateRoleInfo CreateRoleInfo;
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

		public RectTransform EG_RoleRectTransform
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
		    			this.m_EG_RoleRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Role");
     				}
     				return this.m_EG_RoleRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Role");
     			}
     		}
     	}

		public Image E_SelectImage
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
     				if( this.m_E_SelectImage == null )
     				{
		    			this.m_E_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Role/E_Select");
     				}
     				return this.m_E_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Role/E_Select");
     			}
     		}
     	}

		public Text E_RoleOccText
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
		    			this.m_E_RoleOccText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Role/E_RoleOcc");
     				}
     				return this.m_E_RoleOccText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Role/E_RoleOcc");
     			}
     		}
     	}

		public Text E_RoleNameText
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
		    			this.m_E_RoleNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Role/E_RoleName");
     				}
     				return this.m_E_RoleNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Role/E_RoleName");
     			}
     		}
     	}

		public Image E_RoleHeadIconImage
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
		    			this.m_E_RoleHeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Role/E_RoleHeadIcon");
     				}
     				return this.m_E_RoleHeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Role/E_RoleHeadIcon");
     			}
     		}
     	}

		public Text E_RoleLvText
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
		    			this.m_E_RoleLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Role/E_RoleLv");
     				}
     				return this.m_E_RoleLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Role/E_RoleLv");
     			}
     		}
     	}

		public RectTransform EG_NoRoleRectTransform
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
		    			this.m_EG_NoRoleRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_NoRole");
     				}
     				return this.m_EG_NoRoleRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_NoRole");
     			}
     		}
     	}

		public Image E_DiImage
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
     				if( this.m_E_DiImage == null )
     				{
		    			this.m_E_DiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_NoRole/E_Di");
     				}
     				return this.m_E_DiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_NoRole/E_Di");
     			}
     		}
     	}

		public Button E_SelectRoleButton
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
		    			this.m_E_SelectRoleButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_SelectRole");
     				}
     				return this.m_E_SelectRoleButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_SelectRole");
     			}
     		}
     	}

		public Image E_SelectRoleImage
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
		    			this.m_E_SelectRoleImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_SelectRole");
     				}
     				return this.m_E_SelectRoleImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_SelectRole");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_RoleRectTransform = null;
			this.m_E_SelectImage = null;
			this.m_E_RoleOccText = null;
			this.m_E_RoleNameText = null;
			this.m_E_RoleHeadIconImage = null;
			this.m_E_RoleLvText = null;
			this.m_EG_NoRoleRectTransform = null;
			this.m_E_DiImage = null;
			this.m_E_SelectRoleButton = null;
			this.m_E_SelectRoleImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private RectTransform m_EG_RoleRectTransform = null;
		private Image m_E_SelectImage = null;
		private Text m_E_RoleOccText = null;
		private Text m_E_RoleNameText = null;
		private Image m_E_RoleHeadIconImage = null;
		private Text m_E_RoleLvText = null;
		private RectTransform m_EG_NoRoleRectTransform = null;
		private Image m_E_DiImage = null;
		private Button m_E_SelectRoleButton = null;
		private Image m_E_SelectRoleImage = null;
		public Transform uiTransform = null;
	}
}
