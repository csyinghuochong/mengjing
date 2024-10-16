
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMeleeMain))]
	[EnableMethod]
	public  class DlgPetMeleeMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_LeftTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LeftTimeTextText == null )
     			{
		    		this.m_E_LeftTimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_LeftTimeText");
     			}
     			return this.m_E_LeftTimeTextText;
     		}
     	}

		public UnityEngine.UI.Image E_LeftTimeImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LeftTimeImgImage == null )
     			{
		    		this.m_E_LeftTimeImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/E_LeftTimeImg");
     			}
     			return this.m_E_LeftTimeImgImage;
     		}
     	}

		public UnityEngine.UI.Image E_MoLiImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MoLiImgImage == null )
     			{
		    		this.m_E_MoLiImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_MoLiImg");
     			}
     			return this.m_E_MoLiImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_MoLiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MoLiText == null )
     			{
		    		this.m_E_MoLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_MoLi");
     			}
     			return this.m_E_MoLiText;
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
			this.m_E_LeftTimeTextText = null;
			this.m_E_LeftTimeImgImage = null;
			this.m_E_MoLiImgImage = null;
			this.m_E_MoLiText = null;
			this.m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
			this.m_E_CancelButton = null;
			this.m_E_CancelImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_LeftTimeTextText = null;
		private UnityEngine.UI.Image m_E_LeftTimeImgImage = null;
		private UnityEngine.UI.Image m_E_MoLiImgImage = null;
		private UnityEngine.UI.Text m_E_MoLiText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Button m_E_CancelButton = null;
		private UnityEngine.UI.Image m_E_CancelImage = null;
		public Transform uiTransform = null;
	}
}
