
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOfSeal))]
	[EnableMethod]
	public  class DlgTowerOfSealViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_EnterButton
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
		    		this.m_E_Btn_EnterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_EnterImage
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
		    		this.m_E_Btn_EnterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
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

		private UnityEngine.UI.Button m_E_Btn_EnterButton = null;
		private UnityEngine.UI.Image m_E_Btn_EnterImage = null;
		public Transform uiTransform = null;
	}
}
