
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMeleeMain))]
	[EnableMethod]
	public  class DlgPetMeleeMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_TouchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchImage == null )
     			{
		    		this.m_E_TouchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_TouchEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchEventTrigger == null )
     			{
		    		this.m_E_TouchEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchEventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_TopRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TopRectTransform == null )
     			{
		    		this.m_EG_TopRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Top");
     			}
     			return this.m_EG_TopRectTransform;
     		}
     	}

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
		    		this.m_E_LeftTimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Top/E_LeftTimeText");
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
		    		this.m_E_LeftTimeImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Top/E_LeftTimeImg");
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

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     			return this.m_E_IconImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_IconEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconEventTrigger == null )
     			{
		    		this.m_E_IconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Icon");
     			}
     			return this.m_E_IconEventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_CardInHandRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CardInHandRectTransform == null )
     			{
		    		this.m_EG_CardInHandRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_CardInHand");
     			}
     			return this.m_EG_CardInHandRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_CardPoolRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CardPoolRectTransform == null )
     			{
		    		this.m_EG_CardPoolRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_CardPool");
     			}
     			return this.m_EG_CardPoolRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TouchImage = null;
			this.m_E_TouchEventTrigger = null;
			this.m_EG_TopRectTransform = null;
			this.m_E_LeftTimeTextText = null;
			this.m_E_LeftTimeImgImage = null;
			this.m_E_MoLiImgImage = null;
			this.m_E_MoLiText = null;
			this.m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
			this.m_E_IconImage = null;
			this.m_E_IconEventTrigger = null;
			this.m_EG_CardInHandRectTransform = null;
			this.m_EG_CardPoolRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_TouchImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TouchEventTrigger = null;
		private UnityEngine.RectTransform m_EG_TopRectTransform = null;
		private UnityEngine.UI.Text m_E_LeftTimeTextText = null;
		private UnityEngine.UI.Image m_E_LeftTimeImgImage = null;
		private UnityEngine.UI.Image m_E_MoLiImgImage = null;
		private UnityEngine.UI.Text m_E_MoLiText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_IconEventTrigger = null;
		private UnityEngine.RectTransform m_EG_CardInHandRectTransform = null;
		private UnityEngine.RectTransform m_EG_CardPoolRectTransform = null;
		public Transform uiTransform = null;
	}
}
