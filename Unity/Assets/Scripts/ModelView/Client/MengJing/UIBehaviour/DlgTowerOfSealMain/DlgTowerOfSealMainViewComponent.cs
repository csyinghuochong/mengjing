using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOfSealMain))]
	[EnableMethod]
	public  class DlgTowerOfSealMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_StartBtnButton
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
		    		this.m_E_StartBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_StartBtn");
     			}
     			return this.m_E_StartBtnButton;
     		}
     	}

		public Image E_StartBtnImage
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
		    		this.m_E_StartBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_StartBtn");
     			}
     			return this.m_E_StartBtnImage;
     		}
     	}

		public Text E_LevelNumTextText
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
		    		this.m_E_LevelNumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_LevelNumText");
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

		private Button m_E_StartBtnButton = null;
		private Image m_E_StartBtnImage = null;
		private Text m_E_LevelNumTextText = null;
		public Transform uiTransform = null;
	}
}
