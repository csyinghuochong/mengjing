
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMain))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_JoystickMoveRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_JoystickMoveRectTransform == null )
     			{
		    		this.m_EG_JoystickMoveRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_JoystickMove");
     			}
     			return this.m_EG_JoystickMoveRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_YaoGanDiMoveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YaoGanDiMoveImage == null )
     			{
		    		this.m_E_YaoGanDiMoveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_JoystickMove/E_YaoGanDiMove");
     			}
     			return this.m_E_YaoGanDiMoveImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_YaoGanDiMoveEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YaoGanDiMoveEventTrigger == null )
     			{
		    		this.m_E_YaoGanDiMoveEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_JoystickMove/E_YaoGanDiMove");
     			}
     			return this.m_E_YaoGanDiMoveEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_YaoGanDiFixImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YaoGanDiFixImage == null )
     			{
		    		this.m_E_YaoGanDiFixImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_JoystickMove/E_YaoGanDiFix");
     			}
     			return this.m_E_YaoGanDiFixImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_YaoGanDiFixEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YaoGanDiFixEventTrigger == null )
     			{
		    		this.m_E_YaoGanDiFixEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_JoystickMove/E_YaoGanDiFix");
     			}
     			return this.m_E_YaoGanDiFixEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_CenterShowImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CenterShowImage == null )
     			{
		    		this.m_E_CenterShowImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_JoystickMove/E_YaoGanDiFix/E_CenterShow");
     			}
     			return this.m_E_CenterShowImage;
     		}
     	}

		public UnityEngine.UI.Image E_ThumbImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ThumbImage == null )
     			{
		    		this.m_E_ThumbImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_JoystickMove/E_YaoGanDiFix/E_Thumb");
     			}
     			return this.m_E_ThumbImage;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftUpSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftUpSetRectTransform == null )
     			{
		    		this.m_EG_LeftUpSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftUpSet");
     			}
     			return this.m_EG_LeftUpSetRectTransform;
     		}
     	}

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
		    		this.m_E_RolePiLaoImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftUpSet/E_RolePiLaoImg");
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
		    		this.m_E_RoleHuoLiImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftUpSet/E_RoleHuoLiImg");
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
		    		this.m_E_PlayerHeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftUpSet/E_PlayerHeadIcon");
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
		    		this.m_E_SetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftUpSet/E_Set");
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
		    		this.m_E_SetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftUpSet/E_Set");
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
		    		this.m_EG_PetIconSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftUpSet/EG_PetIconSet");
     			}
     			return this.m_EG_PetIconSetRectTransform;
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
		    		this.m_E_RoleHuoLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LeftUpSet/E_RoleHuoLi");
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
		    		this.m_E_ServerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LeftUpSet/E_ServerName");
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
		    		this.m_E_RoleLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LeftUpSet/E_RoleLv");
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
		    		this.m_E_RoleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LeftUpSet/E_RoleName");
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
		    		this.m_E_RolePiLaoText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LeftUpSet/E_RolePiLao");
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
		    		this.m_E_CombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LeftUpSet/E_Combat");
     			}
     			return this.m_E_CombatText;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftSetRectTransform == null )
     			{
		    		this.m_EG_LeftSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftSet");
     			}
     			return this.m_EG_LeftSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PhoneLeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PhoneLeftRectTransform == null )
     			{
		    		this.m_EG_PhoneLeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PhoneLeft");
     			}
     			return this.m_EG_PhoneLeftRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_MainTaskRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainTaskRectTransform == null )
     			{
		    		this.m_EG_MainTaskRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask");
     			}
     			return this.m_EG_MainTaskRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_RoseTaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseTaskButton == null )
     			{
		    		this.m_E_RoseTaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask/E_RoseTask");
     			}
     			return this.m_E_RoseTaskButton;
     		}
     	}

		public UnityEngine.UI.Image E_RoseTaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseTaskImage == null )
     			{
		    		this.m_E_RoseTaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask/E_RoseTask");
     			}
     			return this.m_E_RoseTaskImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MainTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MainTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask/E_MainTaskItems");
     			}
     			return this.m_E_MainTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_LeftTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LeftTypeSetToggleGroup == null )
     			{
		    		this.m_E_LeftTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_PhoneLeft/E_LeftTypeSet");
     			}
     			return this.m_E_LeftTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_LeftTypeSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LeftTypeSetImage == null )
     			{
		    		this.m_E_LeftTypeSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PhoneLeft/E_LeftTypeSet");
     			}
     			return this.m_E_LeftTypeSetImage;
     		}
     	}

		public UnityEngine.RectTransform EG_MainTeamRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainTeamRectTransform == null )
     			{
		    		this.m_EG_MainTeamRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTeam");
     			}
     			return this.m_EG_MainTeamRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftBottomSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftBottomSetRectTransform == null )
     			{
		    		this.m_EG_LeftBottomSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet");
     			}
     			return this.m_EG_LeftBottomSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ShrinkButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShrinkButton == null )
     			{
		    		this.m_E_ShrinkButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/E_Shrink");
     			}
     			return this.m_E_ShrinkButton;
     		}
     	}

		public UnityEngine.UI.Image E_ShrinkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShrinkImage == null )
     			{
		    		this.m_E_ShrinkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/E_Shrink");
     			}
     			return this.m_E_ShrinkImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ShrinkEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShrinkEventTrigger == null )
     			{
		    		this.m_E_ShrinkEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/E_Shrink");
     			}
     			return this.m_E_ShrinkEventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftBottomBtnsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftBottomBtnsRectTransform == null )
     			{
		    		this.m_EG_LeftBottomBtnsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns");
     			}
     			return this.m_EG_LeftBottomBtnsRectTransform;
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
		    		this.m_E_RoseEquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseEquip");
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
		    		this.m_E_RoseEquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_RoseEquipEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseEquipEventTrigger == null )
     			{
		    		this.m_E_RoseEquipEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipEventTrigger;
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
		    		this.m_E_PetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Pet");
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
		    		this.m_E_PetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Pet");
     			}
     			return this.m_E_PetImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_PetEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEventTrigger == null )
     			{
		    		this.m_E_PetEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Pet");
     			}
     			return this.m_E_PetEventTrigger;
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
		    		this.m_E_RoseSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseSkill");
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
		    		this.m_E_RoseSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_RoseSkillEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseSkillEventTrigger == null )
     			{
		    		this.m_E_RoseSkillEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillEventTrigger;
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
		    		this.m_E_TaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Task");
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
		    		this.m_E_TaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Task");
     			}
     			return this.m_E_TaskImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_TaskEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskEventTrigger == null )
     			{
		    		this.m_E_TaskEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Task");
     			}
     			return this.m_E_TaskEventTrigger;
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
		    		this.m_E_FriendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Friend");
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
		    		this.m_E_FriendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Friend");
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
		    		this.m_E_ChengJiuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_ChengJiu");
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
		    		this.m_E_ChengJiuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RoseExpRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoseExpRectTransform == null )
     			{
		    		this.m_EG_RoseExpRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_RoseExp");
     			}
     			return this.m_EG_RoseExpRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_MainChatRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainChatRectTransform == null )
     			{
		    		this.m_EG_MainChatRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat");
     			}
     			return this.m_EG_MainChatRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MainChatItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainChatItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MainChatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat/E_MainChatItems");
     			}
     			return this.m_E_MainChatItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_OpenChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenChatButton == null )
     			{
		    		this.m_E_OpenChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat/E_OpenChat");
     			}
     			return this.m_E_OpenChatButton;
     		}
     	}

		public UnityEngine.UI.Image E_OpenChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenChatImage == null )
     			{
		    		this.m_E_OpenChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat/E_OpenChat");
     			}
     			return this.m_E_OpenChatImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RightSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightSetRectTransform == null )
     			{
		    		this.m_EG_RightSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RightSet");
     			}
     			return this.m_EG_RightSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_MainCityShowImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainCityShowImage == null )
     			{
		    		this.m_E_MainCityShowImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_MainCityShow");
     			}
     			return this.m_E_MainCityShowImage;
     		}
     	}

		public UnityEngine.UI.RawImage E_RawImageRawImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RawImageRawImage == null )
     			{
		    		this.m_E_RawImageRawImage = UIFindHelper.FindDeepChild<UnityEngine.UI.RawImage>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_MainCityShow/ImageDi_1/E_RawImage");
     			}
     			return this.m_E_RawImageRawImage;
     		}
     	}

		public UnityEngine.RectTransform EG_HeadListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HeadListRectTransform == null )
     			{
		    		this.m_EG_HeadListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_MainCityShow/ImageDi_1/EG_HeadList");
     			}
     			return this.m_EG_HeadListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_HeadItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HeadItemRectTransform == null )
     			{
		    		this.m_EG_HeadItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_MainCityShow/ImageDi_1/EG_HeadList/EG_HeadItem");
     			}
     			return this.m_EG_HeadItemRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_MapNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapNameText == null )
     			{
		    		this.m_E_MapNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_MapName");
     			}
     			return this.m_E_MapNameText;
     		}
     	}

		public UnityEngine.UI.Text E_TianQiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TianQiText == null )
     			{
		    		this.m_E_TianQiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_TianQi");
     			}
     			return this.m_E_TianQiText;
     		}
     	}

		public UnityEngine.UI.Text E_TimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimeText == null )
     			{
		    		this.m_E_TimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_Time");
     			}
     			return this.m_E_TimeText;
     		}
     	}

		public UnityEngine.UI.Button E_MiniMapButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MiniMapButtonButton == null )
     			{
		    		this.m_E_MiniMapButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_MiniMapButton");
     			}
     			return this.m_E_MiniMapButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_MiniMapButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MiniMapButtonImage == null )
     			{
		    		this.m_E_MiniMapButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/UIMapMini/E_MiniMapButton");
     			}
     			return this.m_E_MiniMapButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_AdventureButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AdventureButton == null )
     			{
		    		this.m_E_AdventureButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_Adventure");
     			}
     			return this.m_E_AdventureButton;
     		}
     	}

		public UnityEngine.UI.Image E_AdventureImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AdventureImage == null )
     			{
		    		this.m_E_AdventureImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_Adventure");
     			}
     			return this.m_E_AdventureImage;
     		}
     	}

		public UnityEngine.UI.Button E_PetFormationButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetFormationButton == null )
     			{
		    		this.m_E_PetFormationButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_PetFormation");
     			}
     			return this.m_E_PetFormationButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetFormationImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetFormationImage == null )
     			{
		    		this.m_E_PetFormationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_PetFormation");
     			}
     			return this.m_E_PetFormationImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_PetFormationEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetFormationEventTrigger == null )
     			{
		    		this.m_E_PetFormationEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_PetFormation");
     			}
     			return this.m_E_PetFormationEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_CityHorseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CityHorseButton == null )
     			{
		    		this.m_E_CityHorseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_CityHorse");
     			}
     			return this.m_E_CityHorseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CityHorseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CityHorseImage == null )
     			{
		    		this.m_E_CityHorseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_CityHorse");
     			}
     			return this.m_E_CityHorseImage;
     		}
     	}

		public UnityEngine.UI.Button E_TeamDungeonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeamDungeonButton == null )
     			{
		    		this.m_E_TeamDungeonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_TeamDungeon");
     			}
     			return this.m_E_TeamDungeonButton;
     		}
     	}

		public UnityEngine.UI.Image E_TeamDungeonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeamDungeonImage == null )
     			{
		    		this.m_E_TeamDungeonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_TeamDungeon");
     			}
     			return this.m_E_TeamDungeonImage;
     		}
     	}

		public UnityEngine.UI.Button E_JiaYuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanButton == null )
     			{
		    		this.m_E_JiaYuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_JiaYuan");
     			}
     			return this.m_E_JiaYuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_JiaYuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanImage == null )
     			{
		    		this.m_E_JiaYuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_JiaYuan");
     			}
     			return this.m_E_JiaYuanImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_JiaYuanEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanEventTrigger == null )
     			{
		    		this.m_E_JiaYuanEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_JiaYuan");
     			}
     			return this.m_E_JiaYuanEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_NpcDuiHuaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NpcDuiHuaButton == null )
     			{
		    		this.m_E_NpcDuiHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_NpcDuiHua");
     			}
     			return this.m_E_NpcDuiHuaButton;
     		}
     	}

		public UnityEngine.UI.Image E_NpcDuiHuaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NpcDuiHuaImage == null )
     			{
		    		this.m_E_NpcDuiHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_NpcDuiHua");
     			}
     			return this.m_E_NpcDuiHuaImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhanKai
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Button_ZhanKai == null )
				{
					this.m_E_Button_ZhanKai = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/Button_ZhanKai");
				}
				return this.m_E_Button_ZhanKai;
			}
		}

		public UnityEngine.UI.Button E_Btn_RerurnBuilding
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Btn_RerurnBuilding == null )
				{
					this.m_E_Btn_RerurnBuilding = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/Btn_TopRight_3/Btn_RerurnBuilding");
				}
				return this.m_E_Btn_RerurnBuilding;
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
		    		this.m_E_UnionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_Union");
     			}
     			return this.m_E_UnionButton;
     		}
     	}

		public UnityEngine.Transform E_Btn_TopRight_1
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Btn_TopRight_1 == null )
				{
					this.m_E_Btn_TopRight_1 = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"EG_RightSet/Btn_TopRight_1");
				}
				return this.m_E_Btn_TopRight_1;
			}
		}
		
		public UnityEngine.Transform E_Btn_TopRight_2
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Btn_TopRight_2 == null )
				{
					this.m_E_Btn_TopRight_2 = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"EG_RightSet/Btn_TopRight_2");
				}
				return this.m_E_Btn_TopRight_2;
			}
		}
		
		public UnityEngine.Transform E_Btn_TopRight_3
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Btn_TopRight_3 == null )
				{
					this.m_E_Btn_TopRight_3 = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"EG_RightSet/Btn_TopRight_3");
				}
				return this.m_E_Btn_TopRight_3;
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
		    		this.m_E_UnionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_Union");
     			}
     			return this.m_E_UnionImage;
     		}
     	}
		
		public ES_MainTeam ES_MainTeam
		{
			get
			{
				if (this.m_es_MainTeam == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_es_MainTeam == null )
				{
					Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTeam");
					this.m_es_MainTeam = this.AddChild<ES_MainTeam,Transform>(subTrans);
				}
				return this.m_es_MainTeam;
			}
		}

		public ES_MainSkill ES_MainSkill
		{
			get
			{
				if (this.m_es_MainSkill == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_es_MainSkill == null )
				{
					Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_RightSet/UIMainSkill");
					this.m_es_MainSkill = this.AddChild<ES_MainSkill,Transform>(subTrans);
				}
				return this.m_es_MainSkill;
			}
		}

		public UnityEngine.EventSystems.EventTrigger E_UnionEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionEventTrigger == null )
     			{
		    		this.m_E_UnionEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_RightSet/HomeButton/E_Union");
     			}
     			return this.m_E_UnionEventTrigger;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_JoystickMoveRectTransform = null;
			this.m_E_YaoGanDiMoveImage = null;
			this.m_E_YaoGanDiMoveEventTrigger = null;
			this.m_E_YaoGanDiFixImage = null;
			this.m_E_YaoGanDiFixEventTrigger = null;
			this.m_E_CenterShowImage = null;
			this.m_E_ThumbImage = null;
			this.m_EG_LeftUpSetRectTransform = null;
			this.m_E_RolePiLaoImgImage = null;
			this.m_E_RoleHuoLiImgImage = null;
			this.m_E_PlayerHeadIconImage = null;
			this.m_E_SetButton = null;
			this.m_E_SetImage = null;
			this.m_EG_PetIconSetRectTransform = null;
			this.m_E_RoleHuoLiText = null;
			this.m_E_ServerNameText = null;
			this.m_E_RoleLvText = null;
			this.m_E_RoleNameText = null;
			this.m_E_RolePiLaoText = null;
			this.m_E_CombatText = null;
			this.m_EG_LeftSetRectTransform = null;
			this.m_EG_PhoneLeftRectTransform = null;
			this.m_EG_MainTaskRectTransform = null;
			this.m_E_RoseTaskButton = null;
			this.m_E_RoseTaskImage = null;
			this.m_E_MainTaskItemsLoopVerticalScrollRect = null;
			this.m_E_LeftTypeSetToggleGroup = null;
			this.m_E_LeftTypeSetImage = null;
			this.m_EG_MainTeamRectTransform = null;
			this.m_EG_LeftBottomSetRectTransform = null;
			this.m_E_ShrinkButton = null;
			this.m_E_ShrinkImage = null;
			this.m_E_ShrinkEventTrigger = null;
			this.m_EG_LeftBottomBtnsRectTransform = null;
			this.m_E_RoseEquipButton = null;
			this.m_E_RoseEquipImage = null;
			this.m_E_RoseEquipEventTrigger = null;
			this.m_E_PetButton = null;
			this.m_E_PetImage = null;
			this.m_E_PetEventTrigger = null;
			this.m_E_RoseSkillButton = null;
			this.m_E_RoseSkillImage = null;
			this.m_E_RoseSkillEventTrigger = null;
			this.m_E_TaskButton = null;
			this.m_E_TaskImage = null;
			this.m_E_TaskEventTrigger = null;
			this.m_E_FriendButton = null;
			this.m_E_FriendImage = null;
			this.m_E_ChengJiuButton = null;
			this.m_E_ChengJiuImage = null;
			this.m_EG_RoseExpRectTransform = null;
			this.m_EG_MainChatRectTransform = null;
			this.m_E_MainChatItemsLoopVerticalScrollRect = null;
			this.m_E_OpenChatButton = null;
			this.m_E_OpenChatImage = null;
			this.m_EG_RightSetRectTransform = null;
			this.m_E_MainCityShowImage = null;
			this.m_E_RawImageRawImage = null;
			this.m_EG_HeadListRectTransform = null;
			this.m_EG_HeadItemRectTransform = null;
			this.m_E_MapNameText = null;
			this.m_E_TianQiText = null;
			this.m_E_TimeText = null;
			this.m_E_MiniMapButtonButton = null;
			this.m_E_MiniMapButtonImage = null;
			this.m_E_AdventureButton = null;
			this.m_E_AdventureImage = null;
			this.m_E_PetFormationButton = null;
			this.m_E_PetFormationImage = null;
			this.m_E_PetFormationEventTrigger = null;
			this.m_E_CityHorseButton = null;
			this.m_E_CityHorseImage = null;
			this.m_E_TeamDungeonButton = null;
			this.m_E_TeamDungeonImage = null;
			this.m_E_JiaYuanButton = null;
			this.m_E_JiaYuanImage = null;
			this.m_E_JiaYuanEventTrigger = null;
			this.m_E_NpcDuiHuaButton = null;
			this.m_E_NpcDuiHuaImage = null;
			this.m_E_UnionButton = null;
			this.m_E_UnionImage = null;
			this.m_E_UnionEventTrigger = null;
			this.uiTransform = null;
			this.m_E_Button_ZhanKai = null;
			this.m_E_Btn_TopRight_1 = null;
			this.m_E_Btn_TopRight_2 = null;
			this.m_E_Btn_TopRight_3 = null;
			this.m_E_Btn_RerurnBuilding = null;
			this.m_es_MainSkill = null;
		}

		private UnityEngine.RectTransform m_EG_JoystickMoveRectTransform = null;
		private UnityEngine.UI.Image m_E_YaoGanDiMoveImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_YaoGanDiMoveEventTrigger = null;
		private UnityEngine.UI.Image m_E_YaoGanDiFixImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_YaoGanDiFixEventTrigger = null;
		private UnityEngine.UI.Image m_E_CenterShowImage = null;
		private UnityEngine.UI.Image m_E_ThumbImage = null;
		private UnityEngine.RectTransform m_EG_LeftUpSetRectTransform = null;
		private UnityEngine.UI.Image m_E_RolePiLaoImgImage = null;
		private UnityEngine.UI.Image m_E_RoleHuoLiImgImage = null;
		private UnityEngine.UI.Image m_E_PlayerHeadIconImage = null;
		private UnityEngine.UI.Button m_E_SetButton = null;
		private UnityEngine.UI.Image m_E_SetImage = null;
		private UnityEngine.RectTransform m_EG_PetIconSetRectTransform = null;
		private UnityEngine.UI.Text m_E_RoleHuoLiText = null;
		private UnityEngine.UI.Text m_E_ServerNameText = null;
		private UnityEngine.UI.Text m_E_RoleLvText = null;
		private UnityEngine.UI.Text m_E_RoleNameText = null;
		private UnityEngine.UI.Text m_E_RolePiLaoText = null;
		private UnityEngine.UI.Text m_E_CombatText = null;
		private UnityEngine.RectTransform m_EG_LeftSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_PhoneLeftRectTransform = null;
		private UnityEngine.RectTransform m_EG_MainTaskRectTransform = null;
		private UnityEngine.UI.Button m_E_RoseTaskButton = null;
		private UnityEngine.UI.Image m_E_RoseTaskImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MainTaskItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_E_LeftTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_LeftTypeSetImage = null;
		private UnityEngine.RectTransform m_EG_MainTeamRectTransform = null;
		private UnityEngine.RectTransform m_EG_LeftBottomSetRectTransform = null;
		private UnityEngine.UI.Button m_E_ShrinkButton = null;
		private UnityEngine.UI.Image m_E_ShrinkImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ShrinkEventTrigger = null;
		private UnityEngine.RectTransform m_EG_LeftBottomBtnsRectTransform = null;
		private UnityEngine.UI.Button m_E_RoseEquipButton = null;
		private UnityEngine.UI.Image m_E_RoseEquipImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_RoseEquipEventTrigger = null;
		private UnityEngine.UI.Button m_E_PetButton = null;
		private UnityEngine.UI.Image m_E_PetImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_PetEventTrigger = null;
		private UnityEngine.UI.Button m_E_RoseSkillButton = null;
		private UnityEngine.UI.Image m_E_RoseSkillImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_RoseSkillEventTrigger = null;
		private UnityEngine.UI.Button m_E_TaskButton = null;
		private UnityEngine.UI.Image m_E_TaskImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TaskEventTrigger = null;
		private UnityEngine.UI.Button m_E_FriendButton = null;
		private UnityEngine.UI.Image m_E_FriendImage = null;
		private UnityEngine.UI.Button m_E_ChengJiuButton = null;
		private UnityEngine.UI.Image m_E_ChengJiuImage = null;
		private UnityEngine.RectTransform m_EG_RoseExpRectTransform = null;
		private UnityEngine.RectTransform m_EG_MainChatRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MainChatItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_OpenChatButton = null;
		private UnityEngine.UI.Image m_E_OpenChatImage = null;
		private UnityEngine.RectTransform m_EG_RightSetRectTransform = null;
		private UnityEngine.UI.Image m_E_MainCityShowImage = null;
		private UnityEngine.UI.RawImage m_E_RawImageRawImage = null;
		private UnityEngine.RectTransform m_EG_HeadListRectTransform = null;
		private UnityEngine.RectTransform m_EG_HeadItemRectTransform = null;
		private UnityEngine.UI.Text m_E_MapNameText = null;
		private UnityEngine.UI.Text m_E_TianQiText = null;
		private UnityEngine.UI.Text m_E_TimeText = null;
		private UnityEngine.UI.Button m_E_MiniMapButtonButton = null;
		private UnityEngine.UI.Image m_E_MiniMapButtonImage = null;
		private UnityEngine.UI.Button m_E_AdventureButton = null;
		private UnityEngine.UI.Image m_E_AdventureImage = null;
		private UnityEngine.UI.Button m_E_PetFormationButton = null;
		private UnityEngine.UI.Image m_E_PetFormationImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_PetFormationEventTrigger = null;
		private UnityEngine.UI.Button m_E_CityHorseButton = null;
		private UnityEngine.UI.Image m_E_CityHorseImage = null;
		private UnityEngine.UI.Button m_E_TeamDungeonButton = null;
		private UnityEngine.UI.Image m_E_TeamDungeonImage = null;
		private UnityEngine.UI.Button m_E_JiaYuanButton = null;
		private UnityEngine.UI.Image m_E_JiaYuanImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_JiaYuanEventTrigger = null;
		private UnityEngine.UI.Button m_E_NpcDuiHuaButton = null;
		private UnityEngine.UI.Image m_E_NpcDuiHuaImage = null;
		private UnityEngine.UI.Button m_E_UnionButton = null;
		private UnityEngine.UI.Image m_E_UnionImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_UnionEventTrigger = null;
		public Transform uiTransform = null;
		private UnityEngine.UI.Button m_E_Button_ZhanKai = null;
		private UnityEngine.Transform m_E_Btn_TopRight_1 = null;
		private UnityEngine.Transform m_E_Btn_TopRight_2 = null;
		private UnityEngine.Transform m_E_Btn_TopRight_3 = null;
		private UnityEngine.UI.Button m_E_Btn_RerurnBuilding = null;
		private EntityRef<ES_MainTeam> m_es_MainTeam = null;
		private EntityRef<ES_MainSkill> m_es_MainSkill = null;
	}
}
