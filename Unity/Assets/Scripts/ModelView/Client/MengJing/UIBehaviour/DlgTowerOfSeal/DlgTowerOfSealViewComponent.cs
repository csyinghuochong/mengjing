using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOfSeal))]
	[EnableMethod]
	public  class DlgTowerOfSealViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Btn_EnterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnterButton == null )
     			{
		    		this.m_E_Btn_EnterButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterButton;
     		}
     	}

		public Image E_Btn_EnterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnterImage == null )
     			{
		    		this.m_E_Btn_EnterImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_EnterButton = null;
			this.m_E_Btn_EnterImage = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_EnterButton = null;
		private Image m_E_Btn_EnterImage = null;
		public Transform uiTransform = null;
	}
}
