using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSeasonTowerReward))]
	[EnableMethod]
	public  class DlgSeasonTowerRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_CloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonButton == null )
     			{
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonButton;
     		}
     	}

		public Image E_CloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonImage == null )
     			{
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public LoopVerticalScrollRect E_RankRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RankRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RankRewardItems");
     			}
     			return this.m_E_RankRewardItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_RankRewardItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseButtonButton = null;
		private Image m_E_CloseButtonImage = null;
		private LoopVerticalScrollRect m_E_RankRewardItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
