using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMiningReward))]
	[EnableMethod]
	public  class DlgPetMiningRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseButton == null )
     			{
		    		this.m_E_ImageCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseButton;
     		}
     	}

		public Image E_ImageCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseImage == null )
     			{
		    		this.m_E_ImageCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseImage;
     		}
     	}

		public Image E_PetMiningRewardItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMiningRewardItemsImage == null )
     			{
		    		this.m_E_PetMiningRewardItemsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_PetMiningRewardItems");
     			}
     			return this.m_E_PetMiningRewardItemsImage;
     		}
     	}

		public LoopVerticalScrollRect E_PetMiningRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMiningRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetMiningRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetMiningRewardItems");
     			}
     			return this.m_E_PetMiningRewardItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageCloseButton = null;
			this.m_E_ImageCloseImage = null;
			this.m_E_PetMiningRewardItemsImage = null;
			this.m_E_PetMiningRewardItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageCloseButton = null;
		private Image m_E_ImageCloseImage = null;
		private Image m_E_PetMiningRewardItemsImage = null;
		private LoopVerticalScrollRect m_E_PetMiningRewardItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
