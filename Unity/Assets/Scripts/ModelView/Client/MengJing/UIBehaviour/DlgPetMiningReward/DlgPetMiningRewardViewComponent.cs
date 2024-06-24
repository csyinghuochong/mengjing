
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMiningReward))]
	[EnableMethod]
	public  class DlgPetMiningRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageCloseButton
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
		    		this.m_E_ImageCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageCloseImage
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
		    		this.m_E_ImageCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_PetMiningRewardItemsImage
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
		    		this.m_E_PetMiningRewardItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PetMiningRewardItems");
     			}
     			return this.m_E_PetMiningRewardItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetMiningRewardItemsLoopVerticalScrollRect
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
		    		this.m_E_PetMiningRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetMiningRewardItems");
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

		private UnityEngine.UI.Button m_E_ImageCloseButton = null;
		private UnityEngine.UI.Image m_E_ImageCloseImage = null;
		private UnityEngine.UI.Image m_E_PetMiningRewardItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetMiningRewardItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
