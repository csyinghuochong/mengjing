
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
		    		this.m_E_JiFanHpImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/JiFangSet/E_JiFanHpImg");
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
		    		this.m_E_JiFanHpTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/JiFangSet/E_JiFanHpTxt");
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
		    		this.m_E_JiFanNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/JiFangSet/E_JiFanNum");
     			}
     			return this.m_E_JiFanNumText;
     		}
     	}

		public UnityEngine.UI.Text E_JiFanToweText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiFanToweText == null )
     			{
		    		this.m_E_JiFanToweText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/JiFangSet/E_JiFanTowe");
     			}
     			return this.m_E_JiFanToweText;
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
		    		this.m_E_DiRenHpImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/DiRenSet/E_DiRenHpImg");
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
		    		this.m_E_DiRenHpTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/DiRenSet/E_DiRenHpTxt");
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
		    		this.m_E_DiRenNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/DiRenSet/E_DiRenNum");
     			}
     			return this.m_E_DiRenNumText;
     		}
     	}

		public UnityEngine.UI.Text E_DiRenToweText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DiRenToweText == null )
     			{
		    		this.m_E_DiRenToweText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/DiRenSet/E_DiRenTowe");
     			}
     			return this.m_E_DiRenToweText;
     		}
     	}

		public UnityEngine.UI.Image E_DisposeCardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DisposeCardImage == null )
     			{
		    		this.m_E_DisposeCardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_DisposeCard");
     			}
     			return this.m_E_DisposeCardImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_DisposeCardEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DisposeCardEventTrigger == null )
     			{
		    		this.m_E_DisposeCardEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_DisposeCard");
     			}
     			return this.m_E_DisposeCardEventTrigger;
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
		    		this.m_E_RerurnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Rerurn");
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
		    		this.m_E_RerurnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Rerurn");
     			}
     			return this.m_E_RerurnImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_3Image == null )
     			{
		    		this.m_E_Image_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Image_3");
     			}
     			return this.m_E_Image_3Image;
     		}
     	}

		public UnityEngine.UI.Image E_Image_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_2Image == null )
     			{
		    		this.m_E_Image_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Image_2");
     			}
     			return this.m_E_Image_2Image;
     		}
     	}

		public UnityEngine.UI.Image E_Image_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_1Image == null )
     			{
		    		this.m_E_Image_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Image_1");
     			}
     			return this.m_E_Image_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_DiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DiImage == null )
     			{
		    		this.m_E_DiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Di");
     			}
     			return this.m_E_DiImage;
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
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Icon");
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
		    		this.m_E_IconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Icon");
     			}
     			return this.m_E_IconEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_CountdownTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CountdownTimeText == null )
     			{
		    		this.m_E_CountdownTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/Top/E_CountdownTime");
     			}
     			return this.m_E_CountdownTimeText;
     		}
     	}

		public UnityEngine.UI.Image E_MoLiImgOnlineImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MoLiImgOnlineImage == null )
     			{
		    		this.m_E_MoLiImgOnlineImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_MoLiImgOnline");
     			}
     			return this.m_E_MoLiImgOnlineImage;
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

		public UnityEngine.UI.Image E_MoLiImg222Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MoLiImg222Image == null )
     			{
		    		this.m_E_MoLiImg222Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_MoLiImg222");
     			}
     			return this.m_E_MoLiImg222Image;
     		}
     	}

		public UnityEngine.UI.Text E_MoLiRPSText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MoLiRPSText == null )
     			{
		    		this.m_E_MoLiRPSText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_MoLiRPS");
     			}
     			return this.m_E_MoLiRPSText;
     		}
     	}

		public UnityEngine.UI.Text E_MoLiTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MoLiTxtText == null )
     			{
		    		this.m_E_MoLiTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_MoLiTxt");
     			}
     			return this.m_E_MoLiTxtText;
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
		    		this.m_EG_CardInHandRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bottom/EG_CardInHand");
     			}
     			return this.m_EG_CardInHandRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_CancelCardAreaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelCardAreaImage == null )
     			{
		    		this.m_E_CancelCardAreaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_CancelCardArea");
     			}
     			return this.m_E_CancelCardAreaImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_CancelCardAreaEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelCardAreaEventTrigger == null )
     			{
		    		this.m_E_CancelCardAreaEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Bottom/E_CancelCardArea");
     			}
     			return this.m_E_CancelCardAreaEventTrigger;
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
		    		this.m_EG_CardPoolRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bottom/EG_CardPool");
     			}
     			return this.m_EG_CardPoolRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TouchImage = null;
			this.m_E_TouchEventTrigger = null;
			this.m_E_JiFanHpImgImage = null;
			this.m_E_JiFanHpTxtText = null;
			this.m_E_JiFanNumText = null;
			this.m_E_JiFanToweText = null;
			this.m_E_DiRenHpImgImage = null;
			this.m_E_DiRenHpTxtText = null;
			this.m_E_DiRenNumText = null;
			this.m_E_DiRenToweText = null;
			this.m_E_DisposeCardImage = null;
			this.m_E_DisposeCardEventTrigger = null;
			this.m_E_RerurnButton = null;
			this.m_E_RerurnImage = null;
			this.m_E_Image_3Image = null;
			this.m_E_Image_2Image = null;
			this.m_E_Image_1Image = null;
			this.m_E_DiImage = null;
			this.m_E_IconImage = null;
			this.m_E_IconEventTrigger = null;
			this.m_E_CountdownTimeText = null;
			this.m_E_MoLiImgOnlineImage = null;
			this.m_E_MoLiImgImage = null;
			this.m_E_MoLiImg222Image = null;
			this.m_E_MoLiRPSText = null;
			this.m_E_MoLiTxtText = null;
			this.m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
			this.m_EG_CardInHandRectTransform = null;
			this.m_E_CancelCardAreaImage = null;
			this.m_E_CancelCardAreaEventTrigger = null;
			this.m_EG_CardPoolRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_TouchImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TouchEventTrigger = null;
		private UnityEngine.UI.Image m_E_JiFanHpImgImage = null;
		private UnityEngine.UI.Text m_E_JiFanHpTxtText = null;
		private UnityEngine.UI.Text m_E_JiFanNumText = null;
		private UnityEngine.UI.Text m_E_JiFanToweText = null;
		private UnityEngine.UI.Image m_E_DiRenHpImgImage = null;
		private UnityEngine.UI.Text m_E_DiRenHpTxtText = null;
		private UnityEngine.UI.Text m_E_DiRenNumText = null;
		private UnityEngine.UI.Text m_E_DiRenToweText = null;
		private UnityEngine.UI.Image m_E_DisposeCardImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_DisposeCardEventTrigger = null;
		private UnityEngine.UI.Button m_E_RerurnButton = null;
		private UnityEngine.UI.Image m_E_RerurnImage = null;
		private UnityEngine.UI.Image m_E_Image_3Image = null;
		private UnityEngine.UI.Image m_E_Image_2Image = null;
		private UnityEngine.UI.Image m_E_Image_1Image = null;
		private UnityEngine.UI.Image m_E_DiImage = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_IconEventTrigger = null;
		private UnityEngine.UI.Text m_E_CountdownTimeText = null;
		private UnityEngine.UI.Image m_E_MoLiImgOnlineImage = null;
		private UnityEngine.UI.Image m_E_MoLiImgImage = null;
		private UnityEngine.UI.Image m_E_MoLiImg222Image = null;
		private UnityEngine.UI.Text m_E_MoLiRPSText = null;
		private UnityEngine.UI.Text m_E_MoLiTxtText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_PetMeleeItemsLoopHorizontalScrollRect = null;
		private UnityEngine.RectTransform m_EG_CardInHandRectTransform = null;
		private UnityEngine.UI.Image m_E_CancelCardAreaImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_CancelCardAreaEventTrigger = null;
		private UnityEngine.RectTransform m_EG_CardPoolRectTransform = null;
		public Transform uiTransform = null;
	}
}
