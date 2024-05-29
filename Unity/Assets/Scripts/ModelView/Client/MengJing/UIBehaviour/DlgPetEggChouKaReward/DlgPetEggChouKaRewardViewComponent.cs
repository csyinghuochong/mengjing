
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetEggChouKaReward))]
	[EnableMethod]
	public  class DlgPetEggChouKaRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_TextTitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTitleText == null )
     			{
		    		this.m_E_TextTitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTitle");
     			}
     			return this.m_E_TextTitleText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetEggChouKaRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggChouKaRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetEggChouKaRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetEggChouKaRewardItems");
     			}
     			return this.m_E_PetEggChouKaRewardItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextTitleText = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_PetEggChouKaRewardItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_TextTitleText = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetEggChouKaRewardItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
