using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSelectReward))]
	[EnableMethod]
	public  class DlgSelectRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_TitleTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleTextText == null )
     			{
		    		this.m_E_TitleTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image (8)/E_TitleText");
     			}
     			return this.m_E_TitleTextText;
     		}
     	}

		public LoopVerticalScrollRect E_SelectRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SelectRewardItems");
     			}
     			return this.m_E_SelectRewardItemsLoopVerticalScrollRect;
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

		public void DestroyWidget()
		{
			this.m_E_TitleTextText = null;
			this.m_E_SelectRewardItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.uiTransform = null;
		}

		private Text m_E_TitleTextText = null;
		private LoopVerticalScrollRect m_E_SelectRewardItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		public Transform uiTransform = null;
	}
}
