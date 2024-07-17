using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRunRace))]
	[EnableMethod]
	public  class DlgRunRaceViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_EnterBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterBtnButton == null )
     			{
		    		this.m_E_EnterBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnButton;
     		}
     	}

		public Image E_EnterBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterBtnImage == null )
     			{
		    		this.m_E_EnterBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnImage;
     		}
     	}

		public LoopVerticalScrollRect E_RunRaceItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RunRaceItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RunRaceItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RunRaceItems");
     			}
     			return this.m_E_RunRaceItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_EnterBtnButton = null;
			this.m_E_EnterBtnImage = null;
			this.m_E_RunRaceItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_EnterBtnButton = null;
		private Image m_E_EnterBtnImage = null;
		private LoopVerticalScrollRect m_E_RunRaceItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
