using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamApplyList))]
	[EnableMethod]
	public  class DlgTeamApplyListViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Img_ButtonButton
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
		    		this.m_E_Img_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Img_Button");
     			}
     			return this.m_E_Img_ButtonButton;
     		}
     	}

		public Image E_Img_ButtonImage
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
		    		this.m_E_Img_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Button");
     			}
     			return this.m_E_Img_ButtonImage;
     		}
     	}

		public LoopVerticalScrollRect E_TeamApplyItemsLoopVerticalScrollRect
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
		    		this.m_E_TeamApplyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_TeamApplyItems");
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

		private Button m_E_Img_ButtonButton = null;
		private Image m_E_Img_ButtonImage = null;
		private LoopVerticalScrollRect m_E_TeamApplyItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
