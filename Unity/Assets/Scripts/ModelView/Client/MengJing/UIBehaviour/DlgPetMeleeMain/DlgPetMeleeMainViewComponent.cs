
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

		public UnityEngine.RectTransform EG_LeftTimeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftTimeRectTransform == null )
     			{
		    		this.m_EG_LeftTimeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftTime");
     			}
     			return this.m_EG_LeftTimeRectTransform;
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
		    		this.m_E_LeftTimeImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftTime/E_LeftTimeImg");
     			}
     			return this.m_E_LeftTimeImgImage;
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
		    		this.m_E_LeftTimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LeftTimeText");
     			}
     			return this.m_E_LeftTimeTextText;
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

		public UnityEngine.UI.Image E_DiRenHpImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DiRenHpImgImage == null )
     			{
		    		this.m_E_DiRenHpImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DiRenSet/E_DiRenHpImg");
     			}
     			return this.m_E_DiRenHpImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_DiRenHpTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DiRenHpTxtText == null )
     			{
		    		this.m_E_DiRenHpTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"DiRenSet/E_DiRenHpTxt");
     			}
     			return this.m_E_DiRenHpTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_DiRenNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DiRenNumText == null )
     			{
		    		this.m_E_DiRenNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"DiRenSet/E_DiRenNum");
     			}
     			return this.m_E_DiRenNumText;
     		}
     	}

		public UnityEngine.UI.Image E_JiFanHpImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiFanHpImgImage == null )
     			{
		    		this.m_E_JiFanHpImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"JiFangSet/E_JiFanHpImg");
     			}
     			return this.m_E_JiFanHpImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_JiFanHpTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiFanHpTxtText == null )
     			{
		    		this.m_E_JiFanHpTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"JiFangSet/E_JiFanHpTxt");
     			}
     			return this.m_E_JiFanHpTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_JiFanNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiFanNumText == null )
     			{
		    		this.m_E_JiFanNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"JiFangSet/E_JiFanNum");
     			}
     			return this.m_E_JiFanNumText;
     		}
     	}

		public UnityEngine.UI.Button E_RerurnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RerurnButton == null )
     			{
		    		this.m_E_RerurnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Rerurn");
     			}
     			return this.m_E_RerurnButton;
     		}
     	}

		public UnityEngine.UI.Image E_RerurnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RerurnImage == null )
     			{
		    		this.m_E_RerurnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Rerurn");
     			}
     			return this.m_E_RerurnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TouchImage = null;
			this.m_E_TouchEventTrigger = null;
			this.m_EG_LeftTimeRectTransform = null;
			this.m_E_LeftTimeImgImage = null;
			this.m_E_LeftTimeTextText = null;
			this.m_E_MoLiImgImage = null;
			this.m_E_MoLiText = null;
			this.m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
			this.m_E_IconImage = null;
			this.m_E_IconEventTrigger = null;
			this.m_EG_CardInHandRectTransform = null;
			this.m_EG_CardPoolRectTransform = null;
			this.m_E_DiRenHpImgImage = null;
			this.m_E_DiRenHpTxtText = null;
			this.m_E_DiRenNumText = null;
			this.m_E_JiFanHpImgImage = null;
			this.m_E_JiFanHpTxtText = null;
			this.m_E_JiFanNumText = null;
			this.m_E_RerurnButton = null;
			this.m_E_RerurnImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_TouchImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TouchEventTrigger = null;
		private UnityEngine.RectTransform m_EG_LeftTimeRectTransform = null;
		private UnityEngine.UI.Image m_E_LeftTimeImgImage = null;
		private UnityEngine.UI.Text m_E_LeftTimeTextText = null;
		private UnityEngine.UI.Image m_E_MoLiImgImage = null;
		private UnityEngine.UI.Text m_E_MoLiText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_IconEventTrigger = null;
		private UnityEngine.RectTransform m_EG_CardInHandRectTransform = null;
		private UnityEngine.RectTransform m_EG_CardPoolRectTransform = null;
		private UnityEngine.UI.Image m_E_DiRenHpImgImage = null;
		private UnityEngine.UI.Text m_E_DiRenHpTxtText = null;
		private UnityEngine.UI.Text m_E_DiRenNumText = null;
		private UnityEngine.UI.Image m_E_JiFanHpImgImage = null;
		private UnityEngine.UI.Text m_E_JiFanHpTxtText = null;
		private UnityEngine.UI.Text m_E_JiFanNumText = null;
		private UnityEngine.UI.Button m_E_RerurnButton = null;
		private UnityEngine.UI.Image m_E_RerurnImage = null;
		public Transform uiTransform = null;
	}
}
