using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRelink))]
	[EnableMethod]
	public  class DlgRelinkViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_Img_LoadingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LoadingImage == null )
     			{
		    		this.m_E_Img_LoadingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Loading");
     			}
     			return this.m_E_Img_LoadingImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_LoadingImage = null;
			this.uiTransform = null;
		}

		private Image m_E_Img_LoadingImage = null;
		public Transform uiTransform = null;
	}
}
