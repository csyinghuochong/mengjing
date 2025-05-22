
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamApplyList))]
	[EnableMethod]
	public  class DlgTeamApplyListViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Img_ButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ButtonButton == null )
     			{
		    		this.m_E_Img_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_Button");
     			}
     			return this.m_E_Img_ButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ButtonImage == null )
     			{
		    		this.m_E_Img_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_Button");
     			}
     			return this.m_E_Img_ButtonImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_TeamApplyItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeamApplyItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TeamApplyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_TeamApplyItems");
     			}
     			return this.m_E_TeamApplyItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_ButtonButton = null;
			this.m_E_Img_ButtonImage = null;
			this.m_E_TeamApplyItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Img_ButtonButton = null;
		private UnityEngine.UI.Image m_E_Img_ButtonImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_TeamApplyItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
