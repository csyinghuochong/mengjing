
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

		public void DestroyWidget()
		{
			this.m_ELoopScrollList_RoleLoopVerticalScrollRect = null;
			this.m_ELvText = null;
			this.m_ENameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_RoleLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_ELvText = null;
		private UnityEngine.UI.Text m_ENameText = null;
		public Transform uiTransform = null;
	}
}
