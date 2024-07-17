using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMain))]
	[EnableMethod]
	public  class DlgPetMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_PetFubenFingerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetFubenFingerImage == null )
     			{
		    		this.m_E_PetFubenFingerImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_PetFubenFinger");
     			}
     			return this.m_E_PetFubenFingerImage;
     		}
     	}

		public EventTrigger E_PetFubenFingerEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetFubenFingerEventTrigger == null )
     			{
		    		this.m_E_PetFubenFingerEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_PetFubenFinger");
     			}
     			return this.m_E_PetFubenFingerEventTrigger;
     		}
     	}

		public RectTransform EG_MonsterHpNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MonsterHpNodeRectTransform == null )
     			{
		    		this.m_EG_MonsterHpNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_MonsterHpNode");
     			}
     			return this.m_EG_MonsterHpNodeRectTransform;
     		}
     	}

		public RectTransform EG_UIMonsterHpRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIMonsterHpRectTransform == null )
     			{
		    		this.m_EG_UIMonsterHpRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_MonsterHpNode/EG_UIMonsterHp");
     			}
     			return this.m_EG_UIMonsterHpRectTransform;
     		}
     	}

		public RectTransform EG_PetHpNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetHpNodeRectTransform == null )
     			{
		    		this.m_EG_PetHpNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetHpNode");
     			}
     			return this.m_EG_PetHpNodeRectTransform;
     		}
     	}

		public RectTransform EG_UIPetHpRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIPetHpRectTransform == null )
     			{
		    		this.m_EG_UIPetHpRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetHpNode/EG_UIPetHp");
     			}
     			return this.m_EG_UIPetHpRectTransform;
     		}
     	}

		public Button E_Btn_RerurnBuildingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RerurnBuildingButton == null )
     			{
		    		this.m_E_Btn_RerurnBuildingButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_RerurnBuilding");
     			}
     			return this.m_E_Btn_RerurnBuildingButton;
     		}
     	}

		public Image E_Btn_RerurnBuildingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RerurnBuildingImage == null )
     			{
		    		this.m_E_Btn_RerurnBuildingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_RerurnBuilding");
     			}
     			return this.m_E_Btn_RerurnBuildingImage;
     		}
     	}

		public Image E_Image_3Image
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
		    		this.m_E_Image_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_3");
     			}
     			return this.m_E_Image_3Image;
     		}
     	}

		public Image E_Image_2Image
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
		    		this.m_E_Image_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_2");
     			}
     			return this.m_E_Image_2Image;
     		}
     	}

		public Image E_Image_1Image
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
		    		this.m_E_Image_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_1");
     			}
     			return this.m_E_Image_1Image;
     		}
     	}

		public Text E_CountdownTimeText
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
		    		this.m_E_CountdownTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_CountdownTime");
     			}
     			return this.m_E_CountdownTimeText;
     		}
     	}

		public Image E_DiImage
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
		    		this.m_E_DiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Di");
     			}
     			return this.m_E_DiImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PetFubenFingerImage = null;
			this.m_E_PetFubenFingerEventTrigger = null;
			this.m_EG_MonsterHpNodeRectTransform = null;
			this.m_EG_UIMonsterHpRectTransform = null;
			this.m_EG_PetHpNodeRectTransform = null;
			this.m_EG_UIPetHpRectTransform = null;
			this.m_E_Btn_RerurnBuildingButton = null;
			this.m_E_Btn_RerurnBuildingImage = null;
			this.m_E_Image_3Image = null;
			this.m_E_Image_2Image = null;
			this.m_E_Image_1Image = null;
			this.m_E_CountdownTimeText = null;
			this.m_E_DiImage = null;
			this.uiTransform = null;
		}

		private Image m_E_PetFubenFingerImage = null;
		private EventTrigger m_E_PetFubenFingerEventTrigger = null;
		private RectTransform m_EG_MonsterHpNodeRectTransform = null;
		private RectTransform m_EG_UIMonsterHpRectTransform = null;
		private RectTransform m_EG_PetHpNodeRectTransform = null;
		private RectTransform m_EG_UIPetHpRectTransform = null;
		private Button m_E_Btn_RerurnBuildingButton = null;
		private Image m_E_Btn_RerurnBuildingImage = null;
		private Image m_E_Image_3Image = null;
		private Image m_E_Image_2Image = null;
		private Image m_E_Image_1Image = null;
		private Text m_E_CountdownTimeText = null;
		private Image m_E_DiImage = null;
		public Transform uiTransform = null;
	}
}
