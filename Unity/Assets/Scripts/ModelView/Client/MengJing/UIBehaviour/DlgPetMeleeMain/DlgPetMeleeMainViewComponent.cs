
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMeleeMain))]
	[EnableMethod]
	public  class DlgPetMeleeMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_TimeImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimeImgImage == null )
     			{
		    		this.m_E_TimeImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/E_TimeImg");
     			}
     			return this.m_E_TimeImgImage;
     		}
     	}

		public UnityEngine.UI.Image E_JingLiImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingLiImgImage == null )
     			{
		    		this.m_E_JingLiImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_JingLiImg");
     			}
     			return this.m_E_JingLiImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_JingLiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingLiText == null )
     			{
		    		this.m_E_JingLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_JingLi");
     			}
     			return this.m_E_JingLiText;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect E_PetMeleeItemsLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMeleeItemsLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_PetMeleeItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"Bottom/E_PetMeleeItems");
     			}
     			return this.m_E_PetMeleeItemsLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_CancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelButton == null )
     			{
		    		this.m_E_CancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Cancel");
     			}
     			return this.m_E_CancelButton;
     		}
     	}

		public UnityEngine.UI.Image E_CancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelImage == null )
     			{
		    		this.m_E_CancelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Cancel");
     			}
     			return this.m_E_CancelImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TimeImgImage = null;
			this.m_E_JingLiImgImage = null;
			this.m_E_JingLiText = null;
			this.m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
			this.m_E_CancelButton = null;
			this.m_E_CancelImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_TimeImgImage = null;
		private UnityEngine.UI.Image m_E_JingLiImgImage = null;
		private UnityEngine.UI.Text m_E_JingLiText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Button m_E_CancelButton = null;
		private UnityEngine.UI.Image m_E_CancelImage = null;
		public Transform uiTransform = null;
	}
}
