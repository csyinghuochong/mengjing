using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleHead : Entity,IAwake<Transform>,IDestroy 
	{
		public UserInfoComponentC UserInfoComponent { get; set; }
		public int MaxPiLao;
		
		public Image E_RolePiLaoImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePiLaoImgImage == null )
     			{
		    		this.m_E_RolePiLaoImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RolePiLaoImg");
     			}
     			return this.m_E_RolePiLaoImgImage;
     		}
     	}

		public Image E_RoleHuoLiImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleHuoLiImgImage == null )
     			{
		    		this.m_E_RoleHuoLiImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RoleHuoLiImg");
     			}
     			return this.m_E_RoleHuoLiImgImage;
     		}
     	}

		public Image E_PlayerHeadIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerHeadIconImage == null )
     			{
		    		this.m_E_PlayerHeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_PlayerHeadIcon");
     			}
     			return this.m_E_PlayerHeadIconImage;
     		}
     	}

		public Button E_SetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetButton == null )
     			{
		    		this.m_E_SetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Set");
     			}
     			return this.m_E_SetButton;
     		}
     	}

		public Image E_SetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetImage == null )
     			{
		    		this.m_E_SetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Set");
     			}
     			return this.m_E_SetImage;
     		}
     	}

		public RectTransform EG_PetIconSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetIconSetRectTransform == null )
     			{
		    		this.m_EG_PetIconSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetIconSet");
     			}
     			return this.m_EG_PetIconSetRectTransform;
     		}
     	}

		public Image E_Img_PetHpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_PetHpImage == null )
     			{
		    		this.m_E_Img_PetHpImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PetIconSet/E_Img_PetHp");
     			}
     			return this.m_E_Img_PetHpImage;
     		}
     	}

		public Button E_ImagePetHeadIconButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImagePetHeadIconButton == null )
     			{
		    		this.m_E_ImagePetHeadIconButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PetIconSet/E_ImagePetHeadIcon");
     			}
     			return this.m_E_ImagePetHeadIconButton;
     		}
     	}

		public Image E_ImagePetHeadIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImagePetHeadIconImage == null )
     			{
		    		this.m_E_ImagePetHeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PetIconSet/E_ImagePetHeadIcon");
     			}
     			return this.m_E_ImagePetHeadIconImage;
     		}
     	}

		public Text E_Lab_PetNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_PetNameText == null )
     			{
		    		this.m_E_Lab_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PetIconSet/E_Lab_PetName");
     			}
     			return this.m_E_Lab_PetNameText;
     		}
     	}

		public Text E_Lab_PetLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_PetLvText == null )
     			{
		    		this.m_E_Lab_PetLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PetIconSet/E_Lab_PetLv");
     			}
     			return this.m_E_Lab_PetLvText;
     		}
     	}

		public Text E_RoleHuoLiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleHuoLiText == null )
     			{
		    		this.m_E_RoleHuoLiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RoleHuoLi");
     			}
     			return this.m_E_RoleHuoLiText;
     		}
     	}

		public Text E_ServerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerNameText == null )
     			{
		    		this.m_E_ServerNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ServerName");
     			}
     			return this.m_E_ServerNameText;
     		}
     	}

		public Text E_RoleLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleLvText == null )
     			{
		    		this.m_E_RoleLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RoleLv");
     			}
     			return this.m_E_RoleLvText;
     		}
     	}

		public Text E_RoleNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameText == null )
     			{
		    		this.m_E_RoleNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RoleName");
     			}
     			return this.m_E_RoleNameText;
     		}
     	}

		public Text E_RolePiLaoText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePiLaoText == null )
     			{
		    		this.m_E_RolePiLaoText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RolePiLao");
     			}
     			return this.m_E_RolePiLaoText;
     		}
     	}

		public Text E_CombatText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CombatText == null )
     			{
		    		this.m_E_CombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Combat");
     			}
     			return this.m_E_CombatText;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_RolePiLaoImgImage = null;
			this.m_E_RoleHuoLiImgImage = null;
			this.m_E_PlayerHeadIconImage = null;
			this.m_E_SetButton = null;
			this.m_E_SetImage = null;
			this.m_EG_PetIconSetRectTransform = null;
			this.m_E_Img_PetHpImage = null;
			this.m_E_ImagePetHeadIconButton = null;
			this.m_E_ImagePetHeadIconImage = null;
			this.m_E_Lab_PetNameText = null;
			this.m_E_Lab_PetLvText = null;
			this.m_E_RoleHuoLiText = null;
			this.m_E_ServerNameText = null;
			this.m_E_RoleLvText = null;
			this.m_E_RoleNameText = null;
			this.m_E_RolePiLaoText = null;
			this.m_E_CombatText = null;
			this.uiTransform = null;
		}

		private Image m_E_RolePiLaoImgImage = null;
		private Image m_E_RoleHuoLiImgImage = null;
		private Image m_E_PlayerHeadIconImage = null;
		private Button m_E_SetButton = null;
		private Image m_E_SetImage = null;
		private RectTransform m_EG_PetIconSetRectTransform = null;
		private Image m_E_Img_PetHpImage = null;
		private Button m_E_ImagePetHeadIconButton = null;
		private Image m_E_ImagePetHeadIconImage = null;
		private Text m_E_Lab_PetNameText = null;
		private Text m_E_Lab_PetLvText = null;
		private Text m_E_RoleHuoLiText = null;
		private Text m_E_ServerNameText = null;
		private Text m_E_RoleLvText = null;
		private Text m_E_RoleNameText = null;
		private Text m_E_RolePiLaoText = null;
		private Text m_E_CombatText = null;
		public Transform uiTransform = null;
	}
}
