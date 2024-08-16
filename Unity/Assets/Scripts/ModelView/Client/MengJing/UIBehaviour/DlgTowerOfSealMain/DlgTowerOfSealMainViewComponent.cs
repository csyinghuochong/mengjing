
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOfSealMain))]
	[EnableMethod]
	public  class DlgTowerOfSealMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_StartBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnButton == null )
     			{
		    		this.m_E_StartBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_StartBtn");
     			}
     			return this.m_E_StartBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnImage == null )
     			{
		    		this.m_E_StartBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_StartBtn");
     			}
     			return this.m_E_StartBtnImage;
     		}
     	}

		public UnityEngine.UI.Text E_LevelNumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelNumTextText == null )
     			{
		    		this.m_E_LevelNumTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_LevelNumText");
     			}
     			return this.m_E_LevelNumTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_StartBtnButton = null;
			this.m_E_StartBtnImage = null;
			this.m_E_LevelNumTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_StartBtnButton = null;
		private UnityEngine.UI.Image m_E_StartBtnImage = null;
		private UnityEngine.UI.Text m_E_LevelNumTextText = null;
		public Transform uiTransform = null;
	}
}
