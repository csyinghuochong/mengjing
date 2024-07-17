using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgChouKaReward))]
	[EnableMethod]
	public  class DlgChouKaRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_TextTitleText
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
		    		this.m_E_TextTitleText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextTitle");
     			}
     			return this.m_E_TextTitleText;
     		}
     	}

		public Button E_Btn_CloseButton
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public LoopVerticalScrollRect E_ChouKaRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChouKaRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChouKaRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ChouKaRewardItems");
     			}
     			return this.m_E_ChouKaRewardItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextTitleText = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_ChouKaRewardItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Text m_E_TextTitleText = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private LoopVerticalScrollRect m_E_ChouKaRewardItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
