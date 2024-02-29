
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
			this.m_E_AddPointButton = null;
			this.m_E_AddPointImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_RolePropertyBaseItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_AddPointButton = null;
		private UnityEngine.UI.Image m_E_AddPointImage = null;
		public Transform uiTransform = null;
	}
}
