
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFunction))]
	[EnableMethod]
	public  class DlgFunctionViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_DragonDungeonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DragonDungeonButton == null )
     			{
		    		this.m_E_DragonDungeonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/Scroll View Left/Viewport/Content/E_DragonDungeon");
     			}
     			return this.m_E_DragonDungeonButton;
     		}
     	}

		public UnityEngine.UI.Image E_DragonDungeonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DragonDungeonImage == null )
     			{
		    		this.m_E_DragonDungeonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View Left/Viewport/Content/E_DragonDungeon");
     			}
     			return this.m_E_DragonDungeonImage;
     		}
     	}

		public UnityEngine.UI.Button E_PetMeleeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMeleeButton == null )
     			{
		    		this.m_E_PetMeleeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/Scroll View Left/Viewport/Content/E_PetMelee");
     			}
     			return this.m_E_PetMeleeButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetMeleeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMeleeImage == null )
     			{
		    		this.m_E_PetMeleeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View Left/Viewport/Content/E_PetMelee");
     			}
     			return this.m_E_PetMeleeImage;
     		}
     	}

		public UnityEngine.UI.Button E_SingleHappyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SingleHappyButton == null )
     			{
		    		this.m_E_SingleHappyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/Scroll View Left/Viewport/Content/E_SingleHappy");
     			}
     			return this.m_E_SingleHappyButton;
     		}
     	}

		public UnityEngine.UI.Image E_SingleHappyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SingleHappyImage == null )
     			{
		    		this.m_E_SingleHappyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View Left/Viewport/Content/E_SingleHappy");
     			}
     			return this.m_E_SingleHappyImage;
     		}
     	}

		public UnityEngine.UI.Button E_TaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskButton == null )
     			{
		    		this.m_E_TaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Task");
     			}
     			return this.m_E_TaskButton;
     		}
     	}

		public UnityEngine.UI.Image E_TaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskImage == null )
     			{
		    		this.m_E_TaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Task");
     			}
     			return this.m_E_TaskImage;
     		}
     	}

		public UnityEngine.UI.Button E_RoseEquipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseEquipButton == null )
     			{
		    		this.m_E_RoseEquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipButton;
     		}
     	}

		public UnityEngine.UI.Image E_RoseEquipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseEquipImage == null )
     			{
		    		this.m_E_RoseEquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipImage;
     		}
     	}

		public UnityEngine.UI.Button E_PetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetButton == null )
     			{
		    		this.m_E_PetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Pet");
     			}
     			return this.m_E_PetButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetImage == null )
     			{
		    		this.m_E_PetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Pet");
     			}
     			return this.m_E_PetImage;
     		}
     	}

		public UnityEngine.UI.Button E_RoseSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseSkillButton == null )
     			{
		    		this.m_E_RoseSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_RoseSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseSkillImage == null )
     			{
		    		this.m_E_RoseSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillImage;
     		}
     	}

		public UnityEngine.UI.Button E_FriendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendButton == null )
     			{
		    		this.m_E_FriendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Friend");
     			}
     			return this.m_E_FriendButton;
     		}
     	}

		public UnityEngine.UI.Image E_FriendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendImage == null )
     			{
		    		this.m_E_FriendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Friend");
     			}
     			return this.m_E_FriendImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChengJiuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuButton == null )
     			{
		    		this.m_E_ChengJiuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChengJiuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuImage == null )
     			{
		    		this.m_E_ChengJiuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuImage;
     		}
     	}

		public UnityEngine.UI.Button E_PetBarButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarButton == null )
     			{
		    		this.m_E_PetBarButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_PetBar");
     			}
     			return this.m_E_PetBarButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetBarImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarImage == null )
     			{
		    		this.m_E_PetBarImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_PetBar");
     			}
     			return this.m_E_PetBarImage;
     		}
     	}

		public UnityEngine.UI.Button E_UnionButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionButton == null )
     			{
		    		this.m_E_UnionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Union");
     			}
     			return this.m_E_UnionButton;
     		}
     	}

		public UnityEngine.UI.Image E_UnionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionImage == null )
     			{
		    		this.m_E_UnionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/Scroll View Right/Viewport/Content/E_Union");
     			}
     			return this.m_E_UnionImage;
     		}
     	}

		public UnityEngine.UI.Button E_SettingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingButton == null )
     			{
		    		this.m_E_SettingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Setting");
     			}
     			return this.m_E_SettingButton;
     		}
     	}

		public UnityEngine.UI.Image E_SettingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingImage == null )
     			{
		    		this.m_E_SettingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Setting");
     			}
     			return this.m_E_SettingImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_DragonDungeonButton = null;
			this.m_E_DragonDungeonImage = null;
			this.m_E_PetMeleeButton = null;
			this.m_E_PetMeleeImage = null;
			this.m_E_SingleHappyButton = null;
			this.m_E_SingleHappyImage = null;
			this.m_E_TaskButton = null;
			this.m_E_TaskImage = null;
			this.m_E_RoseEquipButton = null;
			this.m_E_RoseEquipImage = null;
			this.m_E_PetButton = null;
			this.m_E_PetImage = null;
			this.m_E_RoseSkillButton = null;
			this.m_E_RoseSkillImage = null;
			this.m_E_FriendButton = null;
			this.m_E_FriendImage = null;
			this.m_E_ChengJiuButton = null;
			this.m_E_ChengJiuImage = null;
			this.m_E_PetBarButton = null;
			this.m_E_PetBarImage = null;
			this.m_E_UnionButton = null;
			this.m_E_UnionImage = null;
			this.m_E_SettingButton = null;
			this.m_E_SettingImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.Button m_E_DragonDungeonButton = null;
		private UnityEngine.UI.Image m_E_DragonDungeonImage = null;
		private UnityEngine.UI.Button m_E_PetMeleeButton = null;
		private UnityEngine.UI.Image m_E_PetMeleeImage = null;
		private UnityEngine.UI.Button m_E_SingleHappyButton = null;
		private UnityEngine.UI.Image m_E_SingleHappyImage = null;
		private UnityEngine.UI.Button m_E_TaskButton = null;
		private UnityEngine.UI.Image m_E_TaskImage = null;
		private UnityEngine.UI.Button m_E_RoseEquipButton = null;
		private UnityEngine.UI.Image m_E_RoseEquipImage = null;
		private UnityEngine.UI.Button m_E_PetButton = null;
		private UnityEngine.UI.Image m_E_PetImage = null;
		private UnityEngine.UI.Button m_E_RoseSkillButton = null;
		private UnityEngine.UI.Image m_E_RoseSkillImage = null;
		private UnityEngine.UI.Button m_E_FriendButton = null;
		private UnityEngine.UI.Image m_E_FriendImage = null;
		private UnityEngine.UI.Button m_E_ChengJiuButton = null;
		private UnityEngine.UI.Image m_E_ChengJiuImage = null;
		private UnityEngine.UI.Button m_E_PetBarButton = null;
		private UnityEngine.UI.Image m_E_PetBarImage = null;
		private UnityEngine.UI.Button m_E_UnionButton = null;
		private UnityEngine.UI.Image m_E_UnionImage = null;
		private UnityEngine.UI.Button m_E_SettingButton = null;
		private UnityEngine.UI.Image m_E_SettingImage = null;
		public Transform uiTransform = null;
	}
}
