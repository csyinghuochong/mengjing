
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMain))]
	[EnableMethod]
	public  class DlgPetMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_PetFubenFingerImage
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
		    		this.m_E_PetFubenFingerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PetFubenFinger");
     			}
     			return this.m_E_PetFubenFingerImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_PetFubenFingerEventTrigger
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
		    		this.m_E_PetFubenFingerEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_PetFubenFinger");
     			}
     			return this.m_E_PetFubenFingerEventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_MonsterHpNodeRectTransform
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
		    		this.m_EG_MonsterHpNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_MonsterHpNode");
     			}
     			return this.m_EG_MonsterHpNodeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UIMonsterHpRectTransform
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
		    		this.m_EG_UIMonsterHpRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_MonsterHpNode/EG_UIMonsterHp");
     			}
     			return this.m_EG_UIMonsterHpRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetHpNodeRectTransform
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
		    		this.m_EG_PetHpNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_PetHpNode");
     			}
     			return this.m_EG_PetHpNodeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UIPetHpRectTransform
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
		    		this.m_EG_UIPetHpRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_PetHpNode/EG_UIPetHp");
     			}
     			return this.m_EG_UIPetHpRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RerurnBuildingButton
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
		    		this.m_E_Btn_RerurnBuildingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_RerurnBuilding");
     			}
     			return this.m_E_Btn_RerurnBuildingButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RerurnBuildingImage
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
		    		this.m_E_Btn_RerurnBuildingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_RerurnBuilding");
     			}
     			return this.m_E_Btn_RerurnBuildingImage;
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
		    		this.m_E_Image_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_3");
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
		    		this.m_E_Image_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_2");
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
		    		this.m_E_Image_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_1");
     			}
     			return this.m_E_Image_1Image;
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
		    		this.m_E_CountdownTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_CountdownTime");
     			}
     			return this.m_E_CountdownTimeText;
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
		    		this.m_E_DiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Di");
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

		private UnityEngine.UI.Image m_E_PetFubenFingerImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_PetFubenFingerEventTrigger = null;
		private UnityEngine.RectTransform m_EG_MonsterHpNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIMonsterHpRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetHpNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIPetHpRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_RerurnBuildingButton = null;
		private UnityEngine.UI.Image m_E_Btn_RerurnBuildingImage = null;
		private UnityEngine.UI.Image m_E_Image_3Image = null;
		private UnityEngine.UI.Image m_E_Image_2Image = null;
		private UnityEngine.UI.Image m_E_Image_1Image = null;
		private UnityEngine.UI.Text m_E_CountdownTimeText = null;
		private UnityEngine.UI.Image m_E_DiImage = null;
		public Transform uiTransform = null;
	}
}
