
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRunRace))]
	[EnableMethod]
	public  class DlgRunRaceViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_EnterBtnButton
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
		    		this.m_E_EnterBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterBtnImage
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
		    		this.m_E_EnterBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RunRaceItemsLoopVerticalScrollRect
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
		    		this.m_E_RunRaceItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RunRaceItems");
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

		private UnityEngine.UI.Button m_E_EnterBtnButton = null;
		private UnityEngine.UI.Image m_E_EnterBtnImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RunRaceItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
