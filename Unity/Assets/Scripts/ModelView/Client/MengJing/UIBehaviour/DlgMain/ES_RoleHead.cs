
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleHead : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UserInfoComponentC UserInfoComponent { get; set; }
		public int MaxPiLao;
		
		public UnityEngine.UI.Image E_RolePiLaoImgImage
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
		    		this.m_E_RolePiLaoImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RolePiLaoImg");
     			}
     			return this.m_E_RolePiLaoImgImage;
     		}
     	}

		public UnityEngine.UI.Image E_RoleHuoLiImgImage
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
		    		this.m_E_RoleHuoLiImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RoleHuoLiImg");
     			}
     			return this.m_E_RoleHuoLiImgImage;
     		}
     	}

		public UnityEngine.UI.Image E_PlayerHeadIconImage
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
		    		this.m_E_PlayerHeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image (3)/E_PlayerHeadIcon");
     			}
     			return this.m_E_PlayerHeadIconImage;
     		}
     	}

		public UnityEngine.UI.Button E_SetButton
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
		    		this.m_E_SetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Set");
     			}
     			return this.m_E_SetButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetImage
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
		    		this.m_E_SetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Set");
     			}
     			return this.m_E_SetImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetIconSetRectTransform
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
		    		this.m_EG_PetIconSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetIconSet");
     			}
     			return this.m_EG_PetIconSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Img_PetHpImage
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
		    		this.m_E_Img_PetHpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PetIconSet/E_Img_PetHp");
     			}
     			return this.m_E_Img_PetHpImage;
     		}
     	}

		public UnityEngine.UI.Button E_ImagePetHeadIconButton
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
		    		this.m_E_ImagePetHeadIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PetIconSet/E_ImagePetHeadIcon");
     			}
     			return this.m_E_ImagePetHeadIconButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImagePetHeadIconImage
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
		    		this.m_E_ImagePetHeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PetIconSet/E_ImagePetHeadIcon");
     			}
     			return this.m_E_ImagePetHeadIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PetNameText
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
		    		this.m_E_Lab_PetNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PetIconSet/E_Lab_PetName");
     			}
     			return this.m_E_Lab_PetNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PetLvText
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
		    		this.m_E_Lab_PetLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PetIconSet/E_Lab_PetLv");
     			}
     			return this.m_E_Lab_PetLvText;
     		}
     	}

		public UnityEngine.UI.Text E_RoleHuoLiText
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
		    		this.m_E_RoleHuoLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RoleHuoLi");
     			}
     			return this.m_E_RoleHuoLiText;
     		}
     	}

		public UnityEngine.UI.Text E_ServerNameText
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
		    		this.m_E_ServerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ServerName");
     			}
     			return this.m_E_ServerNameText;
     		}
     	}

		public UnityEngine.UI.Text E_RoleLvText
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
		    		this.m_E_RoleLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RoleLv");
     			}
     			return this.m_E_RoleLvText;
     		}
     	}

		public UnityEngine.UI.Text E_RoleNameText
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
		    		this.m_E_RoleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RoleName");
     			}
     			return this.m_E_RoleNameText;
     		}
     	}

		public UnityEngine.UI.Text E_RolePiLaoText
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
		    		this.m_E_RolePiLaoText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RolePiLao");
     			}
     			return this.m_E_RolePiLaoText;
     		}
     	}

		public UnityEngine.UI.Text E_CombatText
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
		    		this.m_E_CombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Combat");
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

		private UnityEngine.UI.Image m_E_RolePiLaoImgImage = null;
		private UnityEngine.UI.Image m_E_RoleHuoLiImgImage = null;
		private UnityEngine.UI.Image m_E_PlayerHeadIconImage = null;
		private UnityEngine.UI.Button m_E_SetButton = null;
		private UnityEngine.UI.Image m_E_SetImage = null;
		private UnityEngine.RectTransform m_EG_PetIconSetRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_PetHpImage = null;
		private UnityEngine.UI.Button m_E_ImagePetHeadIconButton = null;
		private UnityEngine.UI.Image m_E_ImagePetHeadIconImage = null;
		private UnityEngine.UI.Text m_E_Lab_PetNameText = null;
		private UnityEngine.UI.Text m_E_Lab_PetLvText = null;
		private UnityEngine.UI.Text m_E_RoleHuoLiText = null;
		private UnityEngine.UI.Text m_E_ServerNameText = null;
		private UnityEngine.UI.Text m_E_RoleLvText = null;
		private UnityEngine.UI.Text m_E_RoleNameText = null;
		private UnityEngine.UI.Text m_E_RolePiLaoText = null;
		private UnityEngine.UI.Text m_E_CombatText = null;
		public Transform uiTransform = null;
	}
}
