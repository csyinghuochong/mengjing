using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRolePetBag))]
	[EnableMethod]
	public  class DlgRolePetBagViewComponent : Entity,IAwake,IDestroy 
	{
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

		public LoopVerticalScrollRect E_RolePetBagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePetBagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RolePetBagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RolePetBagItems");
     			}
     			return this.m_E_RolePetBagItemsLoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_PetZiZhiItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem1RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem2RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem3RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem4RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem5RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem6RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem6RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_FenjieBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FenjieBtnButton == null )
     			{
		    		this.m_E_FenjieBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_FenjieBtn");
     			}
     			return this.m_E_FenjieBtnButton;
     		}
     	}

		public Image E_FenjieBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FenjieBtnImage == null )
     			{
		    		this.m_E_FenjieBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_FenjieBtn");
     			}
     			return this.m_E_FenjieBtnImage;
     		}
     	}

		public Button E_TakeOutBagBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOutBagBtnButton == null )
     			{
		    		this.m_E_TakeOutBagBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_TakeOutBagBtn");
     			}
     			return this.m_E_TakeOutBagBtnButton;
     		}
     	}

		public Image E_TakeOutBagBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOutBagBtnImage == null )
     			{
		    		this.m_E_TakeOutBagBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_TakeOutBagBtn");
     			}
     			return this.m_E_TakeOutBagBtnImage;
     		}
     	}

		public Text E_TextNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNumberText == null )
     			{
		    		this.m_E_TextNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextNumber");
     			}
     			return this.m_E_TextNumberText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_RolePetBagItemsLoopVerticalScrollRect = null;
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_FenjieBtnButton = null;
			this.m_E_FenjieBtnImage = null;
			this.m_E_TakeOutBagBtnButton = null;
			this.m_E_TakeOutBagBtnImage = null;
			this.m_E_TextNumberText = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private LoopVerticalScrollRect m_E_RolePetBagItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private Button m_E_FenjieBtnButton = null;
		private Image m_E_FenjieBtnImage = null;
		private Button m_E_TakeOutBagBtnButton = null;
		private Image m_E_TakeOutBagBtnImage = null;
		private Text m_E_TextNumberText = null;
		public Transform uiTransform = null;
	}
}
