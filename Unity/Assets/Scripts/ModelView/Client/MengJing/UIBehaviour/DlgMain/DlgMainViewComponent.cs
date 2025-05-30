
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMain))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_RoleHead ES_RoleHead
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RoleHead es = this.m_es_rolehead;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_RoleHead");
		    	   this.m_es_rolehead = this.AddChild<ES_RoleHead,Transform>(subTrans);
     			}
     			return this.m_es_rolehead;
     		}
     	}

		public ES_MainBuff ES_MainBuff
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainBuff es = this.m_es_mainbuff;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_MainBuff");
		    	   this.m_es_mainbuff = this.AddChild<ES_MainBuff,Transform>(subTrans);
     			}
     			return this.m_es_mainbuff;
     		}
     	}

		public ES_MainHpBar ES_MainHpBar
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainHpBar es = this.m_es_mainhpbar;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_MainHpBar");
		    	   this.m_es_mainhpbar = this.AddChild<ES_MainHpBar,Transform>(subTrans);
     			}
     			return this.m_es_mainhpbar;
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
		    		this.m_EG_PhoneLeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_PhoneLeft");
     			}
     			return this.m_EG_PhoneLeftRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ShouSuoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouSuoButton == null )
     			{
		    		this.m_E_Btn_ShouSuoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/E_Btn_ShouSuo");
     			}
     			return this.m_E_Btn_ShouSuoButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShouSuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouSuoImage == null )
     			{
		    		this.m_E_Btn_ShouSuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/E_Btn_ShouSuo");
     			}
     			return this.m_E_Btn_ShouSuoImage;
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
		    		this.m_E_LeftTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/E_LeftTypeSet");
     			}
     			return this.m_E_LeftTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_Team_Type_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Team_Type_1Toggle == null )
     			{
		    		this.m_E_Team_Type_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/E_LeftTypeSet/E_Team_Type_1");
     			}
     			return this.m_E_Team_Type_1Toggle;
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
		    		this.m_EG_MainTaskRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTask");
     			}
     			return this.m_EG_MainTaskRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_MainTaskItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainTaskItemsScrollRect == null )
     			{
		    		this.m_E_MainTaskItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTask/E_MainTaskItems");
     			}
     			return this.m_E_MainTaskItemsScrollRect;
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
		    		this.m_E_RoseTaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTask/E_RoseTask");
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
		    		this.m_E_RoseTaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTask/E_RoseTask");
     			}
     			return this.m_E_RoseTaskImage;
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
		    		this.m_EG_MainTeamRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTeam");
     			}
     			return this.m_EG_MainTeamRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_MainTeamItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainTeamItemsScrollRect == null )
     			{
		    		this.m_E_MainTeamItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTeam/E_MainTeamItems");
     			}
     			return this.m_E_MainTeamItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_RoseTeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseTeamButton == null )
     			{
		    		this.m_E_RoseTeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTeam/E_RoseTeam");
     			}
     			return this.m_E_RoseTeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_RoseTeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseTeamImage == null )
     			{
		    		this.m_E_RoseTeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_PhoneLeft/EG_MainTeam/E_RoseTeam");
     			}
     			return this.m_E_RoseTeamImage;
     		}
     	}

		public ES_JoystickMove ES_JoystickMove
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JoystickMove es = this.m_es_joystickmove;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_JoystickMove");
		    	   this.m_es_joystickmove = this.AddChild<ES_JoystickMove,Transform>(subTrans);
     			}
     			return this.m_es_joystickmove;
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
		    		this.m_E_OpenChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_OpenChat");
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
		    		this.m_E_OpenChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_OpenChat");
     			}
     			return this.m_E_OpenChatImage;
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
		    		this.m_EG_MainChatRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MainChat");
     			}
     			return this.m_EG_MainChatRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_MainChatItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainChatItemsScrollRect == null )
     			{
		    		this.m_E_MainChatItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/EG_MainChat/E_MainChatItems");
     			}
     			return this.m_E_MainChatItemsScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_RightBottomSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightBottomSetRectTransform == null )
     			{
		    		this.m_EG_RightBottomSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightBottomSet");
     			}
     			return this.m_EG_RightBottomSetRectTransform;
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
		    		this.m_E_ShrinkButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/E_Shrink");
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
		    		this.m_E_ShrinkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/E_Shrink");
     			}
     			return this.m_E_ShrinkImage;
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
		    		this.m_EG_LeftBottomBtnsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns");
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
		    		this.m_E_RoseEquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_RoseEquip");
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
		    		this.m_E_RoseEquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_RoseEquip");
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
		    		this.m_E_RoseEquipEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_RoseEquip");
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
		    		this.m_E_PetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Pet");
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
		    		this.m_E_PetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Pet");
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
		    		this.m_E_PetEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Pet");
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
		    		this.m_E_RoseSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_RoseSkill");
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
		    		this.m_E_RoseSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_RoseSkill");
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
		    		this.m_E_RoseSkillEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_RoseSkill");
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
		    		this.m_E_TaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Task");
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
		    		this.m_E_TaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Task");
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
		    		this.m_E_TaskEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Task");
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
		    		this.m_E_FriendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Friend");
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
		    		this.m_E_FriendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_Friend");
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
		    		this.m_E_ChengJiuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_ChengJiu");
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
		    		this.m_E_ChengJiuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/EG_LeftBottomBtns/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuImage;
     		}
     	}

		public UnityEngine.UI.Button E_BagButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagButton == null )
     			{
		    		this.m_E_BagButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/E_Bag");
     			}
     			return this.m_E_BagButton;
     		}
     	}

		public UnityEngine.UI.Image E_BagImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagImage == null )
     			{
		    		this.m_E_BagImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightBottomSet/E_Bag");
     			}
     			return this.m_E_BagImage;
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
		    		this.m_EG_RightSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightSet");
     			}
     			return this.m_EG_RightSetRectTransform;
     		}
     	}

		public ES_CellDungeonCellMini ES_CellDungeonCellMini
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CellDungeonCellMini es = this.m_es_celldungeoncellmini;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_RightSet/ES_CellDungeonCellMini");
		    	   this.m_es_celldungeoncellmini = this.AddChild<ES_CellDungeonCellMini,Transform>(subTrans);
     			}
     			return this.m_es_celldungeoncellmini;
     		}
     	}

		public ES_MapMini ES_MapMini
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MapMini es = this.m_es_mapmini;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_RightSet/ES_MapMini");
		    	   this.m_es_mapmini = this.AddChild<ES_MapMini,Transform>(subTrans);
     			}
     			return this.m_es_mapmini;
     		}
     	}

		public ES_MainActivityTip ES_MainActivityTip
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainActivityTip es = this.m_es_mainactivitytip;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_RightSet/ES_MainActivityTip");
		    	   this.m_es_mainactivitytip = this.AddChild<ES_MainActivityTip,Transform>(subTrans);
     			}
     			return this.m_es_mainactivitytip;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhanKaiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhanKaiButton == null )
     			{
		    		this.m_E_Button_ZhanKaiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/E_Button_ZhanKai");
     			}
     			return this.m_E_Button_ZhanKaiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhanKaiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhanKaiImage == null )
     			{
		    		this.m_E_Button_ZhanKaiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/E_Button_ZhanKai");
     			}
     			return this.m_E_Button_ZhanKaiImage;
     		}
     	}

		public UnityEngine.RectTransform EG_Btn_TopRight_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Btn_TopRight_1RectTransform == null )
     			{
		    		this.m_EG_Btn_TopRight_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1");
     			}
     			return this.m_EG_Btn_TopRight_1RectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RunRaceButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RunRaceButton == null )
     			{
		    		this.m_E_Button_RunRaceButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_RunRace");
     			}
     			return this.m_E_Button_RunRaceButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RunRaceImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RunRaceImage == null )
     			{
		    		this.m_E_Button_RunRaceImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_RunRace");
     			}
     			return this.m_E_Button_RunRaceImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_HappyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HappyButton == null )
     			{
		    		this.m_E_Button_HappyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Happy");
     			}
     			return this.m_E_Button_HappyButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_HappyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HappyImage == null )
     			{
		    		this.m_E_Button_HappyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Happy");
     			}
     			return this.m_E_Button_HappyImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_HuntButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HuntButton == null )
     			{
		    		this.m_E_Button_HuntButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Hunt");
     			}
     			return this.m_E_Button_HuntButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_HuntImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HuntImage == null )
     			{
		    		this.m_E_Button_HuntImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Hunt");
     			}
     			return this.m_E_Button_HuntImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_SoloButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SoloButton == null )
     			{
		    		this.m_E_Button_SoloButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Solo");
     			}
     			return this.m_E_Button_SoloButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_SoloImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SoloImage == null )
     			{
		    		this.m_E_Button_SoloImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Solo");
     			}
     			return this.m_E_Button_SoloImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BattleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BattleButton == null )
     			{
		    		this.m_E_Btn_BattleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Btn_Battle");
     			}
     			return this.m_E_Btn_BattleButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BattleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BattleImage == null )
     			{
		    		this.m_E_Btn_BattleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Btn_Battle");
     			}
     			return this.m_E_Btn_BattleImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_DonationButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DonationButton == null )
     			{
		    		this.m_E_Button_DonationButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Donation");
     			}
     			return this.m_E_Button_DonationButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_DonationImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DonationImage == null )
     			{
		    		this.m_E_Button_DonationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Donation");
     			}
     			return this.m_E_Button_DonationImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_FenXiangButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FenXiangButton == null )
     			{
		    		this.m_E_Button_FenXiangButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_FenXiang");
     			}
     			return this.m_E_Button_FenXiangButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_FenXiangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FenXiangImage == null )
     			{
		    		this.m_E_Button_FenXiangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_FenXiang");
     			}
     			return this.m_E_Button_FenXiangImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_EveryTaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EveryTaskButton == null )
     			{
		    		this.m_E_Btn_EveryTaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Btn_EveryTask");
     			}
     			return this.m_E_Btn_EveryTaskButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_EveryTaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EveryTaskImage == null )
     			{
		    		this.m_E_Btn_EveryTaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Btn_EveryTask");
     			}
     			return this.m_E_Btn_EveryTaskImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RechargeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RechargeButton == null )
     			{
		    		this.m_E_Button_RechargeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Recharge");
     			}
     			return this.m_E_Button_RechargeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RechargeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RechargeImage == null )
     			{
		    		this.m_E_Button_RechargeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Recharge");
     			}
     			return this.m_E_Button_RechargeImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HuoDongButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDongButton == null )
     			{
		    		this.m_E_Btn_HuoDongButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Btn_HuoDong");
     			}
     			return this.m_E_Btn_HuoDongButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HuoDongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDongImage == null )
     			{
		    		this.m_E_Btn_HuoDongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Btn_HuoDong");
     			}
     			return this.m_E_Btn_HuoDongImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhenYingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhenYingButton == null )
     			{
		    		this.m_E_Button_ZhenYingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_ZhenYing");
     			}
     			return this.m_E_Button_ZhenYingButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhenYingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhenYingImage == null )
     			{
		    		this.m_E_Button_ZhenYingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_ZhenYing");
     			}
     			return this.m_E_Button_ZhenYingImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_EnergyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_EnergyButton == null )
     			{
		    		this.m_E_Button_EnergyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Energy");
     			}
     			return this.m_E_Button_EnergyButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_EnergyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_EnergyImage == null )
     			{
		    		this.m_E_Button_EnergyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Energy");
     			}
     			return this.m_E_Button_EnergyImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_FashionButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FashionButton == null )
     			{
		    		this.m_E_Button_FashionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Fashion");
     			}
     			return this.m_E_Button_FashionButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_FashionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FashionImage == null )
     			{
		    		this.m_E_Button_FashionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Fashion");
     			}
     			return this.m_E_Button_FashionImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_DemonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DemonButton == null )
     			{
		    		this.m_E_Button_DemonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Demon");
     			}
     			return this.m_E_Button_DemonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_DemonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DemonImage == null )
     			{
		    		this.m_E_Button_DemonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Demon");
     			}
     			return this.m_E_Button_DemonImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_SeasonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SeasonButton == null )
     			{
		    		this.m_E_Button_SeasonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Season");
     			}
     			return this.m_E_Button_SeasonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_SeasonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SeasonImage == null )
     			{
		    		this.m_E_Button_SeasonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_1/E_Button_Season");
     			}
     			return this.m_E_Button_SeasonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_Btn_TopRight_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Btn_TopRight_2RectTransform == null )
     			{
		    		this.m_EG_Btn_TopRight_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2");
     			}
     			return this.m_EG_Btn_TopRight_2RectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ActivityV1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ActivityV1Button == null )
     			{
		    		this.m_E_Button_ActivityV1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_ActivityV1");
     			}
     			return this.m_E_Button_ActivityV1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ActivityV1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ActivityV1Image == null )
     			{
		    		this.m_E_Button_ActivityV1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_ActivityV1");
     			}
     			return this.m_E_Button_ActivityV1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AuctionButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AuctionButton == null )
     			{
		    		this.m_E_Btn_AuctionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AuctionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AuctionImage == null )
     			{
		    		this.m_E_Btn_AuctionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_HongBaoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HongBaoButton == null )
     			{
		    		this.m_E_Button_HongBaoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_HongBao");
     			}
     			return this.m_E_Button_HongBaoButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_HongBaoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HongBaoImage == null )
     			{
		    		this.m_E_Button_HongBaoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_HongBao");
     			}
     			return this.m_E_Button_HongBaoImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhanQuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhanQuButton == null )
     			{
		    		this.m_E_Button_ZhanQuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_ZhanQu");
     			}
     			return this.m_E_Button_ZhanQuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhanQuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhanQuImage == null )
     			{
		    		this.m_E_Button_ZhanQuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_ZhanQu");
     			}
     			return this.m_E_Button_ZhanQuImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_NewYearButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_NewYearButton == null )
     			{
		    		this.m_E_Button_NewYearButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_NewYear");
     			}
     			return this.m_E_Button_NewYearButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_NewYearImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_NewYearImage == null )
     			{
		    		this.m_E_Button_NewYearImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_NewYear");
     			}
     			return this.m_E_Button_NewYearImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RechargeRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RechargeRewardButton == null )
     			{
		    		this.m_E_Button_RechargeRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_RechargeReward");
     			}
     			return this.m_E_Button_RechargeRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RechargeRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RechargeRewardImage == null )
     			{
		    		this.m_E_Button_RechargeRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_RechargeReward");
     			}
     			return this.m_E_Button_RechargeRewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_WelfareButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_WelfareButton == null )
     			{
		    		this.m_E_Button_WelfareButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_Welfare");
     			}
     			return this.m_E_Button_WelfareButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_WelfareImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_WelfareImage == null )
     			{
		    		this.m_E_Button_WelfareImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_Welfare");
     			}
     			return this.m_E_Button_WelfareImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GMButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GMButton == null )
     			{
		    		this.m_E_Btn_GMButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_GM");
     			}
     			return this.m_E_Btn_GMButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GMImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GMImage == null )
     			{
		    		this.m_E_Btn_GMImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_GM");
     			}
     			return this.m_E_Btn_GMImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RankButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RankButton == null )
     			{
		    		this.m_E_Btn_RankButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_Rank");
     			}
     			return this.m_E_Btn_RankButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RankImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RankImage == null )
     			{
		    		this.m_E_Btn_RankImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_Rank");
     			}
     			return this.m_E_Btn_RankImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_WorldLvButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_WorldLvButton == null )
     			{
		    		this.m_E_Button_WorldLvButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Button_WorldLv");
     			}
     			return this.m_E_Button_WorldLvButton;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_PaiMaiHangButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PaiMaiHangButton == null )
     			{
		    		this.m_E_Btn_PaiMaiHangButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_PaiMaiHang");
     			}
     			return this.m_E_Btn_PaiMaiHangButton;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CellDungeonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CellDungeonButton == null )
     			{
		    		this.m_E_Btn_CellDungeonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_CellDungeon");
     			}
     			return this.m_E_Btn_CellDungeonButton;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_PetMeleeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PetMeleeButton == null )
     			{
		    		this.m_E_Btn_PetMeleeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_2/E_Btn_PetMelee");
     			}
     			return this.m_E_Btn_PetMeleeButton;
     		}
     	}

		public UnityEngine.RectTransform EG_Btn_TopRight_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Btn_TopRight_3RectTransform == null )
     			{
		    		this.m_EG_Btn_TopRight_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3");
     			}
     			return this.m_EG_Btn_TopRight_3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_Btn_KillMonsterRewardRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Btn_KillMonsterRewardRectTransform == null )
     			{
		    		this.m_EG_Btn_KillMonsterRewardRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/EG_Btn_KillMonsterReward");
     			}
     			return this.m_EG_Btn_KillMonsterRewardRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_Btn_LvRewardRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Btn_LvRewardRectTransform == null )
     			{
		    		this.m_EG_Btn_LvRewardRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/EG_Btn_LvReward");
     			}
     			return this.m_EG_Btn_LvRewardRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_MailHintTipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailHintTipButton == null )
     			{
		    		this.m_E_MailHintTipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_MailHintTip");
     			}
     			return this.m_E_MailHintTipButton;
     		}
     	}

		public UnityEngine.UI.Image E_MailHintTipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailHintTipImage == null )
     			{
		    		this.m_E_MailHintTipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_MailHintTip");
     			}
     			return this.m_E_MailHintTipImage;
     		}
     	}

		public UnityEngine.UI.Button E_E_Btn_MapTransferButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_E_Btn_MapTransferButton == null )
     			{
		    		this.m_E_E_Btn_MapTransferButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_E_Btn_MapTransfer");
     			}
     			return this.m_E_E_Btn_MapTransferButton;
     		}
     	}

		public UnityEngine.UI.Image E_E_Btn_MapTransferImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_E_Btn_MapTransferImage == null )
     			{
		    		this.m_E_E_Btn_MapTransferImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_E_Btn_MapTransfer");
     			}
     			return this.m_E_E_Btn_MapTransferImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RerurnDungeonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RerurnDungeonButton == null )
     			{
		    		this.m_E_Btn_RerurnDungeonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnDungeon");
     			}
     			return this.m_E_Btn_RerurnDungeonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RerurnDungeonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RerurnDungeonImage == null )
     			{
		    		this.m_E_Btn_RerurnDungeonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnDungeon");
     			}
     			return this.m_E_Btn_RerurnDungeonImage;
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
		    		this.m_E_Btn_RerurnBuildingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnBuilding");
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
		    		this.m_E_Btn_RerurnBuildingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnBuilding");
     			}
     			return this.m_E_Btn_RerurnBuildingImage;
     		}
     	}

		public UnityEngine.RectTransform EG_HomeButtonRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HomeButtonRectTransform == null )
     			{
		    		this.m_EG_HomeButtonRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton");
     			}
     			return this.m_EG_HomeButtonRectTransform;
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
		    		this.m_E_AdventureButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_Adventure");
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
		    		this.m_E_AdventureImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_Adventure");
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
		    		this.m_E_PetFormationButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_PetFormation");
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
		    		this.m_E_PetFormationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_PetFormation");
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
		    		this.m_E_PetFormationEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_PetFormation");
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
		    		this.m_E_CityHorseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_CityHorse");
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
		    		this.m_E_CityHorseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_CityHorse");
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
		    		this.m_E_TeamDungeonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_TeamDungeon");
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
		    		this.m_E_TeamDungeonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_TeamDungeon");
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
		    		this.m_E_JiaYuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_JiaYuan");
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
		    		this.m_E_JiaYuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_JiaYuan");
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
		    		this.m_E_JiaYuanEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_JiaYuan");
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
		    		this.m_E_NpcDuiHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_NpcDuiHua");
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
		    		this.m_E_NpcDuiHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_NpcDuiHua");
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
		    		this.m_E_UnionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_Union");
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
		    		this.m_E_UnionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_Union");
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
		    		this.m_E_UnionEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RightSet/EG_HomeButton/E_Union");
     			}
     			return this.m_E_UnionEventTrigger;
     		}
     	}

		public ES_MainSkill ES_MainSkill
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainSkill es = this.m_es_mainskill;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_RightSet/ES_MainSkill");
		    	   this.m_es_mainskill = this.AddChild<ES_MainSkill,Transform>(subTrans);
     			}
     			return this.m_es_mainskill;
     		}
     	}

		public UnityEngine.RectTransform EG_FpsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FpsRectTransform == null )
     			{
		    		this.m_EG_FpsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_Fps");
     			}
     			return this.m_EG_FpsRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextFpsText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextFpsText == null )
     			{
		    		this.m_E_TextFpsText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_Fps/E_TextFps");
     			}
     			return this.m_E_TextFpsText;
     		}
     	}

		public UnityEngine.UI.Text E_TextPingText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPingText == null )
     			{
		    		this.m_E_TextPingText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_Fps/E_TextPing");
     			}
     			return this.m_E_TextPingText;
     		}
     	}

		public UnityEngine.UI.Text E_TextMessageText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextMessageText == null )
     			{
		    		this.m_E_TextMessageText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_Fps/E_TextMessage");
     			}
     			return this.m_E_TextMessageText;
     		}
     	}

		public UnityEngine.UI.Image E_DragPanelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DragPanelImage == null )
     			{
		    		this.m_E_DragPanelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_DragPanel");
     			}
     			return this.m_E_DragPanelImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_DragPanelEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DragPanelEventTrigger == null )
     			{
		    		this.m_E_DragPanelEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_DragPanel");
     			}
     			return this.m_E_DragPanelEventTrigger;
     		}
     	}

		public ES_OpenBox ES_OpenBox
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_OpenBox es = this.m_es_openbox;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_OpenBox");
		    	   this.m_es_openbox = this.AddChild<ES_OpenBox,Transform>(subTrans);
     			}
     			return this.m_es_openbox;
     		}
     	}

		public ES_DigTreasure ES_DigTreasure
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_DigTreasure es = this.m_es_digtreasure;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_DigTreasure");
		    	   this.m_es_digtreasure = this.AddChild<ES_DigTreasure,Transform>(subTrans);
     			}
     			return this.m_es_digtreasure;
     		}
     	}

		public ES_Singing ES_Singing
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_Singing es = this.m_es_singing;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_Singing");
		    	   this.m_es_singing = this.AddChild<ES_Singing,Transform>(subTrans);
     			}
     			return this.m_es_singing;
     		}
     	}

		public UnityEngine.RectTransform EG_GuaJiSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_GuaJiSetRectTransform == null )
     			{
		    		this.m_EG_GuaJiSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_GuaJiSet");
     			}
     			return this.m_EG_GuaJiSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_StopGuaJiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StopGuaJiButton == null )
     			{
		    		this.m_E_Btn_StopGuaJiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_GuaJiSet/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_StopGuaJiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StopGuaJiImage == null )
     			{
		    		this.m_E_Btn_StopGuaJiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_GuaJiSet/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UIStallRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIStallRectTransform == null )
     			{
		    		this.m_EG_UIStallRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_UIStall");
     			}
     			return this.m_EG_UIStallRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonStallCancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStallCancelButton == null )
     			{
		    		this.m_E_ButtonStallCancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_UIStall/E_ButtonStallCancel");
     			}
     			return this.m_E_ButtonStallCancelButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonStallCancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStallCancelImage == null )
     			{
		    		this.m_E_ButtonStallCancelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_UIStall/E_ButtonStallCancel");
     			}
     			return this.m_E_ButtonStallCancelImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonStallOpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStallOpenButton == null )
     			{
		    		this.m_E_ButtonStallOpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_UIStall/E_ButtonStallOpen");
     			}
     			return this.m_E_ButtonStallOpenButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonStallOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStallOpenImage == null )
     			{
		    		this.m_E_ButtonStallOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_UIStall/E_ButtonStallOpen");
     			}
     			return this.m_E_ButtonStallOpenImage;
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
		    		this.m_EG_RoseExpRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bottom/EG_RoseExp");
     			}
     			return this.m_EG_RoseExpRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ExpProImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpProImage == null )
     			{
		    		this.m_E_ExpProImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/EG_RoseExp/E_ExpPro");
     			}
     			return this.m_E_ExpProImage;
     		}
     	}

		public UnityEngine.UI.Text E_ExpValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpValueText == null )
     			{
		    		this.m_E_ExpValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/EG_RoseExp/E_ExpValue");
     			}
     			return this.m_E_ExpValueText;
     		}
     	}

		public UnityEngine.RectTransform EG_MainPetFightsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainPetFightsRectTransform == null )
     			{
		    		this.m_EG_MainPetFightsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bottom/EG_MainPetFights");
     			}
     			return this.m_EG_MainPetFightsRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextPetSwitchText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPetSwitchText == null )
     			{
		    		this.m_E_TextPetSwitchText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/EG_MainPetFights/E_TextPetSwitch");
     			}
     			return this.m_E_TextPetSwitchText;
     		}
     	}

		public UnityEngine.UI.Text E_TextPetSwitchTitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPetSwitchTitleText == null )
     			{
		    		this.m_E_TextPetSwitchTitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/EG_MainPetFights/E_TextPetSwitchTitle");
     			}
     			return this.m_E_TextPetSwitchTitleText;
     		}
     	}

		public ES_MainPetFight ES_MainPetFight_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainPetFight es = this.m_es_mainpetfight_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Bottom/EG_MainPetFights/ES_MainPetFight_0");
		    	   this.m_es_mainpetfight_0 = this.AddChild<ES_MainPetFight,Transform>(subTrans);
     			}
     			return this.m_es_mainpetfight_0;
     		}
     	}

		public ES_MainPetFight ES_MainPetFight_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainPetFight es = this.m_es_mainpetfight_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Bottom/EG_MainPetFights/ES_MainPetFight_1");
		    	   this.m_es_mainpetfight_1 = this.AddChild<ES_MainPetFight,Transform>(subTrans);
     			}
     			return this.m_es_mainpetfight_1;
     		}
     	}

		public ES_MainPetFight ES_MainPetFight_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainPetFight es = this.m_es_mainpetfight_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Bottom/EG_MainPetFights/ES_MainPetFight_2");
		    	   this.m_es_mainpetfight_2 = this.AddChild<ES_MainPetFight,Transform>(subTrans);
     			}
     			return this.m_es_mainpetfight_2;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_rolehead = null;
			this.m_es_mainbuff = null;
			this.m_es_mainhpbar = null;
			this.m_EG_PhoneLeftRectTransform = null;
			this.m_E_Btn_ShouSuoButton = null;
			this.m_E_Btn_ShouSuoImage = null;
			this.m_E_LeftTypeSetToggleGroup = null;
			this.m_E_Team_Type_1Toggle = null;
			this.m_EG_MainTaskRectTransform = null;
			this.m_E_MainTaskItemsScrollRect = null;
			this.m_E_RoseTaskButton = null;
			this.m_E_RoseTaskImage = null;
			this.m_EG_MainTeamRectTransform = null;
			this.m_E_MainTeamItemsScrollRect = null;
			this.m_E_RoseTeamButton = null;
			this.m_E_RoseTeamImage = null;
			this.m_es_joystickmove = null;
			this.m_E_OpenChatButton = null;
			this.m_E_OpenChatImage = null;
			this.m_EG_MainChatRectTransform = null;
			this.m_E_MainChatItemsScrollRect = null;
			this.m_EG_RightBottomSetRectTransform = null;
			this.m_E_ShrinkButton = null;
			this.m_E_ShrinkImage = null;
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
			this.m_E_BagButton = null;
			this.m_E_BagImage = null;
			this.m_EG_RightSetRectTransform = null;
			this.m_es_celldungeoncellmini = null;
			this.m_es_mapmini = null;
			this.m_es_mainactivitytip = null;
			this.m_E_Button_ZhanKaiButton = null;
			this.m_E_Button_ZhanKaiImage = null;
			this.m_EG_Btn_TopRight_1RectTransform = null;
			this.m_E_Button_RunRaceButton = null;
			this.m_E_Button_RunRaceImage = null;
			this.m_E_Button_HappyButton = null;
			this.m_E_Button_HappyImage = null;
			this.m_E_Button_HuntButton = null;
			this.m_E_Button_HuntImage = null;
			this.m_E_Button_SoloButton = null;
			this.m_E_Button_SoloImage = null;
			this.m_E_Btn_BattleButton = null;
			this.m_E_Btn_BattleImage = null;
			this.m_E_Button_DonationButton = null;
			this.m_E_Button_DonationImage = null;
			this.m_E_Button_FenXiangButton = null;
			this.m_E_Button_FenXiangImage = null;
			this.m_E_Btn_EveryTaskButton = null;
			this.m_E_Btn_EveryTaskImage = null;
			this.m_E_Button_RechargeButton = null;
			this.m_E_Button_RechargeImage = null;
			this.m_E_Btn_HuoDongButton = null;
			this.m_E_Btn_HuoDongImage = null;
			this.m_E_Button_ZhenYingButton = null;
			this.m_E_Button_ZhenYingImage = null;
			this.m_E_Button_EnergyButton = null;
			this.m_E_Button_EnergyImage = null;
			this.m_E_Button_FashionButton = null;
			this.m_E_Button_FashionImage = null;
			this.m_E_Button_DemonButton = null;
			this.m_E_Button_DemonImage = null;
			this.m_E_Button_SeasonButton = null;
			this.m_E_Button_SeasonImage = null;
			this.m_EG_Btn_TopRight_2RectTransform = null;
			this.m_E_Button_ActivityV1Button = null;
			this.m_E_Button_ActivityV1Image = null;
			this.m_E_Btn_AuctionButton = null;
			this.m_E_Btn_AuctionImage = null;
			this.m_E_Button_HongBaoButton = null;
			this.m_E_Button_HongBaoImage = null;
			this.m_E_Button_ZhanQuButton = null;
			this.m_E_Button_ZhanQuImage = null;
			this.m_E_Button_NewYearButton = null;
			this.m_E_Button_NewYearImage = null;
			this.m_E_Button_RechargeRewardButton = null;
			this.m_E_Button_RechargeRewardImage = null;
			this.m_E_Button_WelfareButton = null;
			this.m_E_Button_WelfareImage = null;
			this.m_E_Btn_GMButton = null;
			this.m_E_Btn_GMImage = null;
			this.m_E_Btn_RankButton = null;
			this.m_E_Btn_RankImage = null;
			this.m_E_Button_WorldLvButton = null;
			this.m_E_Btn_PaiMaiHangButton = null;
			this.m_E_Btn_CellDungeonButton = null;
			this.m_E_Btn_PetMeleeButton = null;
			this.m_EG_Btn_TopRight_3RectTransform = null;
			this.m_EG_Btn_KillMonsterRewardRectTransform = null;
			this.m_EG_Btn_LvRewardRectTransform = null;
			this.m_E_MailHintTipButton = null;
			this.m_E_MailHintTipImage = null;
			this.m_E_E_Btn_MapTransferButton = null;
			this.m_E_E_Btn_MapTransferImage = null;
			this.m_E_Btn_RerurnDungeonButton = null;
			this.m_E_Btn_RerurnDungeonImage = null;
			this.m_E_Btn_RerurnBuildingButton = null;
			this.m_E_Btn_RerurnBuildingImage = null;
			this.m_EG_HomeButtonRectTransform = null;
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
			this.m_es_mainskill = null;
			this.m_EG_FpsRectTransform = null;
			this.m_E_TextFpsText = null;
			this.m_E_TextPingText = null;
			this.m_E_TextMessageText = null;
			this.m_E_DragPanelImage = null;
			this.m_E_DragPanelEventTrigger = null;
			this.m_es_openbox = null;
			this.m_es_digtreasure = null;
			this.m_es_singing = null;
			this.m_EG_GuaJiSetRectTransform = null;
			this.m_E_Btn_StopGuaJiButton = null;
			this.m_E_Btn_StopGuaJiImage = null;
			this.m_EG_UIStallRectTransform = null;
			this.m_E_ButtonStallCancelButton = null;
			this.m_E_ButtonStallCancelImage = null;
			this.m_E_ButtonStallOpenButton = null;
			this.m_E_ButtonStallOpenImage = null;
			this.m_EG_RoseExpRectTransform = null;
			this.m_E_ExpProImage = null;
			this.m_E_ExpValueText = null;
			this.m_EG_MainPetFightsRectTransform = null;
			this.m_E_TextPetSwitchText = null;
			this.m_E_TextPetSwitchTitleText = null;
			this.m_es_mainpetfight_0 = null;
			this.m_es_mainpetfight_1 = null;
			this.m_es_mainpetfight_2 = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_RoleHead> m_es_rolehead = null;
		private EntityRef<ES_MainBuff> m_es_mainbuff = null;
		private EntityRef<ES_MainHpBar> m_es_mainhpbar = null;
		private UnityEngine.RectTransform m_EG_PhoneLeftRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_ShouSuoButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShouSuoImage = null;
		private UnityEngine.UI.ToggleGroup m_E_LeftTypeSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Team_Type_1Toggle = null;
		private UnityEngine.RectTransform m_EG_MainTaskRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_MainTaskItemsScrollRect = null;
		private UnityEngine.UI.Button m_E_RoseTaskButton = null;
		private UnityEngine.UI.Image m_E_RoseTaskImage = null;
		private UnityEngine.RectTransform m_EG_MainTeamRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_MainTeamItemsScrollRect = null;
		private UnityEngine.UI.Button m_E_RoseTeamButton = null;
		private UnityEngine.UI.Image m_E_RoseTeamImage = null;
		private EntityRef<ES_JoystickMove> m_es_joystickmove = null;
		private UnityEngine.UI.Button m_E_OpenChatButton = null;
		private UnityEngine.UI.Image m_E_OpenChatImage = null;
		private UnityEngine.RectTransform m_EG_MainChatRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_MainChatItemsScrollRect = null;
		private UnityEngine.RectTransform m_EG_RightBottomSetRectTransform = null;
		private UnityEngine.UI.Button m_E_ShrinkButton = null;
		private UnityEngine.UI.Image m_E_ShrinkImage = null;
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
		private UnityEngine.UI.Button m_E_BagButton = null;
		private UnityEngine.UI.Image m_E_BagImage = null;
		private UnityEngine.RectTransform m_EG_RightSetRectTransform = null;
		private EntityRef<ES_CellDungeonCellMini> m_es_celldungeoncellmini = null;
		private EntityRef<ES_MapMini> m_es_mapmini = null;
		private EntityRef<ES_MainActivityTip> m_es_mainactivitytip = null;
		private UnityEngine.UI.Button m_E_Button_ZhanKaiButton = null;
		private UnityEngine.UI.Image m_E_Button_ZhanKaiImage = null;
		private UnityEngine.RectTransform m_EG_Btn_TopRight_1RectTransform = null;
		private UnityEngine.UI.Button m_E_Button_RunRaceButton = null;
		private UnityEngine.UI.Image m_E_Button_RunRaceImage = null;
		private UnityEngine.UI.Button m_E_Button_HappyButton = null;
		private UnityEngine.UI.Image m_E_Button_HappyImage = null;
		private UnityEngine.UI.Button m_E_Button_HuntButton = null;
		private UnityEngine.UI.Image m_E_Button_HuntImage = null;
		private UnityEngine.UI.Button m_E_Button_SoloButton = null;
		private UnityEngine.UI.Image m_E_Button_SoloImage = null;
		private UnityEngine.UI.Button m_E_Btn_BattleButton = null;
		private UnityEngine.UI.Image m_E_Btn_BattleImage = null;
		private UnityEngine.UI.Button m_E_Button_DonationButton = null;
		private UnityEngine.UI.Image m_E_Button_DonationImage = null;
		private UnityEngine.UI.Button m_E_Button_FenXiangButton = null;
		private UnityEngine.UI.Image m_E_Button_FenXiangImage = null;
		private UnityEngine.UI.Button m_E_Btn_EveryTaskButton = null;
		private UnityEngine.UI.Image m_E_Btn_EveryTaskImage = null;
		private UnityEngine.UI.Button m_E_Button_RechargeButton = null;
		private UnityEngine.UI.Image m_E_Button_RechargeImage = null;
		private UnityEngine.UI.Button m_E_Btn_HuoDongButton = null;
		private UnityEngine.UI.Image m_E_Btn_HuoDongImage = null;
		private UnityEngine.UI.Button m_E_Button_ZhenYingButton = null;
		private UnityEngine.UI.Image m_E_Button_ZhenYingImage = null;
		private UnityEngine.UI.Button m_E_Button_EnergyButton = null;
		private UnityEngine.UI.Image m_E_Button_EnergyImage = null;
		private UnityEngine.UI.Button m_E_Button_FashionButton = null;
		private UnityEngine.UI.Image m_E_Button_FashionImage = null;
		private UnityEngine.UI.Button m_E_Button_DemonButton = null;
		private UnityEngine.UI.Image m_E_Button_DemonImage = null;
		private UnityEngine.UI.Button m_E_Button_SeasonButton = null;
		private UnityEngine.UI.Image m_E_Button_SeasonImage = null;
		private UnityEngine.RectTransform m_EG_Btn_TopRight_2RectTransform = null;
		private UnityEngine.UI.Button m_E_Button_ActivityV1Button = null;
		private UnityEngine.UI.Image m_E_Button_ActivityV1Image = null;
		private UnityEngine.UI.Button m_E_Btn_AuctionButton = null;
		private UnityEngine.UI.Image m_E_Btn_AuctionImage = null;
		private UnityEngine.UI.Button m_E_Button_HongBaoButton = null;
		private UnityEngine.UI.Image m_E_Button_HongBaoImage = null;
		private UnityEngine.UI.Button m_E_Button_ZhanQuButton = null;
		private UnityEngine.UI.Image m_E_Button_ZhanQuImage = null;
		private UnityEngine.UI.Button m_E_Button_NewYearButton = null;
		private UnityEngine.UI.Image m_E_Button_NewYearImage = null;
		private UnityEngine.UI.Button m_E_Button_RechargeRewardButton = null;
		private UnityEngine.UI.Image m_E_Button_RechargeRewardImage = null;
		private UnityEngine.UI.Button m_E_Button_WelfareButton = null;
		private UnityEngine.UI.Image m_E_Button_WelfareImage = null;
		private UnityEngine.UI.Button m_E_Btn_GMButton = null;
		private UnityEngine.UI.Image m_E_Btn_GMImage = null;
		private UnityEngine.UI.Button m_E_Btn_RankButton = null;
		private UnityEngine.UI.Image m_E_Btn_RankImage = null;
		private UnityEngine.UI.Button m_E_Button_WorldLvButton = null;
		private UnityEngine.UI.Button m_E_Btn_PaiMaiHangButton = null;
		private UnityEngine.UI.Button m_E_Btn_CellDungeonButton = null;
		private UnityEngine.UI.Button m_E_Btn_PetMeleeButton = null;
		private UnityEngine.RectTransform m_EG_Btn_TopRight_3RectTransform = null;
		private UnityEngine.RectTransform m_EG_Btn_KillMonsterRewardRectTransform = null;
		private UnityEngine.RectTransform m_EG_Btn_LvRewardRectTransform = null;
		private UnityEngine.UI.Button m_E_MailHintTipButton = null;
		private UnityEngine.UI.Image m_E_MailHintTipImage = null;
		private UnityEngine.UI.Button m_E_E_Btn_MapTransferButton = null;
		private UnityEngine.UI.Image m_E_E_Btn_MapTransferImage = null;
		private UnityEngine.UI.Button m_E_Btn_RerurnDungeonButton = null;
		private UnityEngine.UI.Image m_E_Btn_RerurnDungeonImage = null;
		private UnityEngine.UI.Button m_E_Btn_RerurnBuildingButton = null;
		private UnityEngine.UI.Image m_E_Btn_RerurnBuildingImage = null;
		private UnityEngine.RectTransform m_EG_HomeButtonRectTransform = null;
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
		private EntityRef<ES_MainSkill> m_es_mainskill = null;
		private UnityEngine.RectTransform m_EG_FpsRectTransform = null;
		private UnityEngine.UI.Text m_E_TextFpsText = null;
		private UnityEngine.UI.Text m_E_TextPingText = null;
		private UnityEngine.UI.Text m_E_TextMessageText = null;
		private UnityEngine.UI.Image m_E_DragPanelImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_DragPanelEventTrigger = null;
		private EntityRef<ES_OpenBox> m_es_openbox = null;
		private EntityRef<ES_DigTreasure> m_es_digtreasure = null;
		private EntityRef<ES_Singing> m_es_singing = null;
		private UnityEngine.RectTransform m_EG_GuaJiSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_StopGuaJiButton = null;
		private UnityEngine.UI.Image m_E_Btn_StopGuaJiImage = null;
		private UnityEngine.RectTransform m_EG_UIStallRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonStallCancelButton = null;
		private UnityEngine.UI.Image m_E_ButtonStallCancelImage = null;
		private UnityEngine.UI.Button m_E_ButtonStallOpenButton = null;
		private UnityEngine.UI.Image m_E_ButtonStallOpenImage = null;
		private UnityEngine.RectTransform m_EG_RoseExpRectTransform = null;
		private UnityEngine.UI.Image m_E_ExpProImage = null;
		private UnityEngine.UI.Text m_E_ExpValueText = null;
		private UnityEngine.RectTransform m_EG_MainPetFightsRectTransform = null;
		private UnityEngine.UI.Text m_E_TextPetSwitchText = null;
		private UnityEngine.UI.Text m_E_TextPetSwitchTitleText = null;
		private EntityRef<ES_MainPetFight> m_es_mainpetfight_0 = null;
		private EntityRef<ES_MainPetFight> m_es_mainpetfight_1 = null;
		private EntityRef<ES_MainPetFight> m_es_mainpetfight_2 = null;
		public Transform uiTransform = null;
	}
}
