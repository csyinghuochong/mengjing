
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMJLobby))]
	[EnableMethod]
	public  class DlgMJLobbyViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_RoleLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_RoleLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_RoleLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"ELoopScrollList_Role");
     			}
     			return this.m_ELoopScrollList_RoleLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text ELvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELvText == null )
     			{
		    		this.m_ELvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELoopScrollList_Role/Content/Item_LobbyRole/ELv");
     			}
     			return this.m_ELvText;
     		}
     	}

		public UnityEngine.UI.Text ENameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ENameText == null )
     			{
		    		this.m_ENameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELoopScrollList_Role/Content/Item_LobbyRole/EName");
     			}
     			return this.m_ENameText;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}
		
		

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.UI.Button E_BtnSelectRole
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_BtnSelectRole == null )
				{
					this.m_BtnSelectRole = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"RoleListSet/RoleList/BtnSelectRole");
				}
				return this.m_BtnSelectRole;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_ELoopScrollList_RoleLoopVerticalScrollRect = null;
			this.m_ELvText = null;
			this.m_ENameText = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.uiTransform = null;
			this.m_BtnSelectRole = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_RoleLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_ELvText = null;
		private UnityEngine.UI.Text m_ENameText = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.UI.Button m_BtnSelectRole = null;
		public Transform uiTransform = null;
	}
}
