
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
		    		this.m_E_RoseTaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveLeft/PhoneLeft/UIMainTask/E_RoseTask");
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
		    		this.m_E_RoseTaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveLeft/PhoneLeft/UIMainTask/E_RoseTask");
     			}
     			return this.m_E_RoseTaskImage;
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
		    		this.m_E_ShrinkButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/E_Shrink");
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
		    		this.m_E_ShrinkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/E_Shrink");
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
		    		this.m_E_ShrinkEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveBottom/E_Shrink");
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
		    		this.m_EG_LeftBottomBtnsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns");
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
		    		this.m_E_RoseEquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseEquip");
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
		    		this.m_E_RoseEquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseEquip");
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
		    		this.m_E_RoseEquipEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseEquip");
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
		    		this.m_E_PetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Pet");
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
		    		this.m_E_PetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Pet");
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
		    		this.m_E_PetEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Pet");
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
		    		this.m_E_RoseSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseSkill");
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
		    		this.m_E_RoseSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseSkill");
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
		    		this.m_E_RoseSkillEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseSkill");
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
		    		this.m_E_TaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Task");
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
		    		this.m_E_TaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Task");
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
		    		this.m_E_TaskEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Task");
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
		    		this.m_E_FriendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Friend");
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
		    		this.m_E_FriendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Friend");
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
		    		this.m_E_ChengJiuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_ChengJiu");
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
		    		this.m_E_ChengJiuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuImage;
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
		    		this.m_E_AdventureButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_Adventure");
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
		    		this.m_E_AdventureImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_Adventure");
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
		    		this.m_E_PetFormationButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_PetFormation");
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
		    		this.m_E_PetFormationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_PetFormation");
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
		    		this.m_E_PetFormationEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_PetFormation");
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
		    		this.m_E_CityHorseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_CityHorse");
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
		    		this.m_E_CityHorseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_CityHorse");
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
		    		this.m_E_TeamDungeonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_TeamDungeon");
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
		    		this.m_E_TeamDungeonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_TeamDungeon");
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
		    		this.m_E_JiaYuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_JiaYuan");
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
		    		this.m_E_JiaYuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_JiaYuan");
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
		    		this.m_E_JiaYuanEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_JiaYuan");
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
		    		this.m_E_NpcDuiHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_NpcDuiHua");
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
		    		this.m_E_NpcDuiHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_NpcDuiHua");
     			}
     			return this.m_E_NpcDuiHuaImage;
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
		    		this.m_E_UnionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_Union");
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
		    		this.m_E_UnionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_Union");
     			}
     			return this.m_E_UnionImage;
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
		    		this.m_E_UnionEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"DoMoveRight/HomeButton/E_Union");
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
			this.m_E_RoseTaskButton = null;
			this.m_E_RoseTaskImage = null;
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
		}

		private UnityEngine.RectTransform m_EG_JoystickMoveRectTransform = null;
		private UnityEngine.UI.Image m_E_YaoGanDiMoveImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_YaoGanDiMoveEventTrigger = null;
		private UnityEngine.UI.Image m_E_YaoGanDiFixImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_YaoGanDiFixEventTrigger = null;
		private UnityEngine.UI.Image m_E_CenterShowImage = null;
		private UnityEngine.UI.Image m_E_ThumbImage = null;
		private UnityEngine.UI.Button m_E_RoseTaskButton = null;
		private UnityEngine.UI.Image m_E_RoseTaskImage = null;
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
	}
}
