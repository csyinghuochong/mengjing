using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMain))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_DragPanelImage
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
		    		this.m_E_DragPanelImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_DragPanel");
     			}
     			return this.m_E_DragPanelImage;
     		}
     	}

		public EventTrigger E_DragPanelEventTrigger
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
		    		this.m_E_DragPanelEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_DragPanel");
     			}
     			return this.m_E_DragPanelEventTrigger;
     		}
     	}

		public ES_ButtonPositionSet ES_ButtonPositionSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ButtonPositionSet es = this.m_es_buttonpositionset;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ButtonPositionSet");
		    	   this.m_es_buttonpositionset = this.AddChild<ES_ButtonPositionSet,Transform>(subTrans);
     			}
     			return this.m_es_buttonpositionset;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_JoystickMove");
		    	   this.m_es_joystickmove = this.AddChild<ES_JoystickMove,Transform>(subTrans);
     			}
     			return this.m_es_joystickmove;
     		}
     	}

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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RoleHead");
		    	   this.m_es_rolehead = this.AddChild<ES_RoleHead,Transform>(subTrans);
     			}
     			return this.m_es_rolehead;
     		}
     	}

		public RectTransform EG_PhoneLeftRectTransform
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
		    		this.m_EG_PhoneLeftRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PhoneLeft");
     			}
     			return this.m_EG_PhoneLeftRectTransform;
     		}
     	}

		public RectTransform EG_MainTaskRectTransform
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
		    		this.m_EG_MainTaskRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask");
     			}
     			return this.m_EG_MainTaskRectTransform;
     		}
     	}

		public Button E_RoseTaskButton
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
		    		this.m_E_RoseTaskButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask/E_RoseTask");
     			}
     			return this.m_E_RoseTaskButton;
     		}
     	}

		public Image E_RoseTaskImage
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
		    		this.m_E_RoseTaskImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask/E_RoseTask");
     			}
     			return this.m_E_RoseTaskImage;
     		}
     	}

		public LoopVerticalScrollRect E_MainTaskItemsLoopVerticalScrollRect
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
		    		this.m_E_MainTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTask/E_MainTaskItems");
     			}
     			return this.m_E_MainTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public ToggleGroup E_LeftTypeSetToggleGroup
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
		    		this.m_E_LeftTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"EG_PhoneLeft/E_LeftTypeSet");
     			}
     			return this.m_E_LeftTypeSetToggleGroup;
     		}
     	}

		public Image E_LeftTypeSetImage
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
		    		this.m_E_LeftTypeSetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PhoneLeft/E_LeftTypeSet");
     			}
     			return this.m_E_LeftTypeSetImage;
     		}
     	}

		public RectTransform EG_MainTeamRectTransform
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
		    		this.m_EG_MainTeamRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTeam");
     			}
     			return this.m_EG_MainTeamRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_MainTeamItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainTeamItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MainTeamItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTeam/E_MainTeamItems");
     			}
     			return this.m_E_MainTeamItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_RoseTeamButton
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
		    		this.m_E_RoseTeamButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTeam/E_RoseTeam");
     			}
     			return this.m_E_RoseTeamButton;
     		}
     	}

		public Image E_RoseTeamImage
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
		    		this.m_E_RoseTeamImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PhoneLeft/EG_MainTeam/E_RoseTeam");
     			}
     			return this.m_E_RoseTeamImage;
     		}
     	}

		public RectTransform EG_LeftSetRectTransform
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
		    		this.m_EG_LeftSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_LeftSet");
     			}
     			return this.m_EG_LeftSetRectTransform;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_LeftSet/ES_MainHpBar");
		    	   this.m_es_mainhpbar = this.AddChild<ES_MainHpBar,Transform>(subTrans);
     			}
     			return this.m_es_mainhpbar;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_LeftSet/ES_MainBuff");
		    	   this.m_es_mainbuff = this.AddChild<ES_MainBuff,Transform>(subTrans);
     			}
     			return this.m_es_mainbuff;
     		}
     	}

		public RectTransform EG_LeftBottomSetRectTransform
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
		    		this.m_EG_LeftBottomSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet");
     			}
     			return this.m_EG_LeftBottomSetRectTransform;
     		}
     	}

		public Button E_ShrinkButton
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
		    		this.m_E_ShrinkButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/E_Shrink");
     			}
     			return this.m_E_ShrinkButton;
     		}
     	}

		public Image E_ShrinkImage
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
		    		this.m_E_ShrinkImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/E_Shrink");
     			}
     			return this.m_E_ShrinkImage;
     		}
     	}

		public EventTrigger E_ShrinkEventTrigger
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
		    		this.m_E_ShrinkEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/E_Shrink");
     			}
     			return this.m_E_ShrinkEventTrigger;
     		}
     	}

		public RectTransform EG_LeftBottomBtnsRectTransform
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
		    		this.m_EG_LeftBottomBtnsRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns");
     			}
     			return this.m_EG_LeftBottomBtnsRectTransform;
     		}
     	}

		public Button E_RoseEquipButton
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
		    		this.m_E_RoseEquipButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipButton;
     		}
     	}

		public Image E_RoseEquipImage
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
		    		this.m_E_RoseEquipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipImage;
     		}
     	}

		public EventTrigger E_RoseEquipEventTrigger
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
		    		this.m_E_RoseEquipEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipEventTrigger;
     		}
     	}

		public Button E_PetButton
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
		    		this.m_E_PetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Pet");
     			}
     			return this.m_E_PetButton;
     		}
     	}

		public Image E_PetImage
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
		    		this.m_E_PetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Pet");
     			}
     			return this.m_E_PetImage;
     		}
     	}

		public EventTrigger E_PetEventTrigger
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
		    		this.m_E_PetEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Pet");
     			}
     			return this.m_E_PetEventTrigger;
     		}
     	}

		public Button E_RoseSkillButton
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
		    		this.m_E_RoseSkillButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillButton;
     		}
     	}

		public Image E_RoseSkillImage
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
		    		this.m_E_RoseSkillImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillImage;
     		}
     	}

		public EventTrigger E_RoseSkillEventTrigger
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
		    		this.m_E_RoseSkillEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillEventTrigger;
     		}
     	}

		public Button E_TaskButton
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
		    		this.m_E_TaskButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Task");
     			}
     			return this.m_E_TaskButton;
     		}
     	}

		public Image E_TaskImage
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
		    		this.m_E_TaskImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Task");
     			}
     			return this.m_E_TaskImage;
     		}
     	}

		public EventTrigger E_TaskEventTrigger
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
		    		this.m_E_TaskEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Task");
     			}
     			return this.m_E_TaskEventTrigger;
     		}
     	}

		public Button E_FriendButton
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
		    		this.m_E_FriendButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Friend");
     			}
     			return this.m_E_FriendButton;
     		}
     	}

		public Image E_FriendImage
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
		    		this.m_E_FriendImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_Friend");
     			}
     			return this.m_E_FriendImage;
     		}
     	}

		public Button E_ChengJiuButton
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
		    		this.m_E_ChengJiuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuButton;
     		}
     	}

		public Image E_ChengJiuImage
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
		    		this.m_E_ChengJiuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_LeftBottomBtns/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuImage;
     		}
     	}

		public RectTransform EG_RoseExpRectTransform
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
		    		this.m_EG_RoseExpRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_RoseExp");
     			}
     			return this.m_EG_RoseExpRectTransform;
     		}
     	}

		public Image E_ExpProImage
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
		    		this.m_E_ExpProImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_RoseExp/E_ExpPro");
     			}
     			return this.m_E_ExpProImage;
     		}
     	}

		public Text E_ExpValueText
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
		    		this.m_E_ExpValueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_RoseExp/E_ExpValue");
     			}
     			return this.m_E_ExpValueText;
     		}
     	}

		public RectTransform EG_MainChatRectTransform
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
		    		this.m_EG_MainChatRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat");
     			}
     			return this.m_EG_MainChatRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_MainChatItemsLoopVerticalScrollRect
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
		    		this.m_E_MainChatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat/E_MainChatItems");
     			}
     			return this.m_E_MainChatItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_OpenChatButton
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
		    		this.m_E_OpenChatButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat/E_OpenChat");
     			}
     			return this.m_E_OpenChatButton;
     		}
     	}

		public Image E_OpenChatImage
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
		    		this.m_E_OpenChatImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_LeftBottomSet/EG_MainChat/E_OpenChat");
     			}
     			return this.m_E_OpenChatImage;
     		}
     	}

		public RectTransform EG_RightSetRectTransform
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
		    		this.m_EG_RightSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RightSet");
     			}
     			return this.m_EG_RightSetRectTransform;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_RightSet/ES_MapMini");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_RightSet/ES_MainActivityTip");
		    	   this.m_es_mainactivitytip = this.AddChild<ES_MainActivityTip,Transform>(subTrans);
     			}
     			return this.m_es_mainactivitytip;
     		}
     	}

		public Button E_Button_ZhanKaiButton
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
		    		this.m_E_Button_ZhanKaiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/E_Button_ZhanKai");
     			}
     			return this.m_E_Button_ZhanKaiButton;
     		}
     	}

		public Image E_Button_ZhanKaiImage
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
		    		this.m_E_Button_ZhanKaiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/E_Button_ZhanKai");
     			}
     			return this.m_E_Button_ZhanKaiImage;
     		}
     	}

		public RectTransform EG_Btn_TopRight_1RectTransform
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
		    		this.m_EG_Btn_TopRight_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1");
     			}
     			return this.m_EG_Btn_TopRight_1RectTransform;
     		}
     	}

		public Button E_Button_RunRaceButton
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
		    		this.m_E_Button_RunRaceButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_RunRace");
     			}
     			return this.m_E_Button_RunRaceButton;
     		}
     	}

		public Image E_Button_RunRaceImage
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
		    		this.m_E_Button_RunRaceImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_RunRace");
     			}
     			return this.m_E_Button_RunRaceImage;
     		}
     	}

		public Button E_Button_HappyButton
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
		    		this.m_E_Button_HappyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Happy");
     			}
     			return this.m_E_Button_HappyButton;
     		}
     	}

		public Image E_Button_HappyImage
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
		    		this.m_E_Button_HappyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Happy");
     			}
     			return this.m_E_Button_HappyImage;
     		}
     	}

		public Button E_Button_HuntButton
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
		    		this.m_E_Button_HuntButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Hunt");
     			}
     			return this.m_E_Button_HuntButton;
     		}
     	}

		public Image E_Button_HuntImage
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
		    		this.m_E_Button_HuntImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Hunt");
     			}
     			return this.m_E_Button_HuntImage;
     		}
     	}

		public Button E_Button_SoloButton
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
		    		this.m_E_Button_SoloButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Solo");
     			}
     			return this.m_E_Button_SoloButton;
     		}
     	}

		public Image E_Button_SoloImage
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
		    		this.m_E_Button_SoloImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Solo");
     			}
     			return this.m_E_Button_SoloImage;
     		}
     	}

		public Button E_Btn_BattleButton
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
		    		this.m_E_Btn_BattleButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Btn_Battle");
     			}
     			return this.m_E_Btn_BattleButton;
     		}
     	}

		public Image E_Btn_BattleImage
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
		    		this.m_E_Btn_BattleImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Btn_Battle");
     			}
     			return this.m_E_Btn_BattleImage;
     		}
     	}

		public Button E_Button_DonationButton
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
		    		this.m_E_Button_DonationButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Donation");
     			}
     			return this.m_E_Button_DonationButton;
     		}
     	}

		public Image E_Button_DonationImage
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
		    		this.m_E_Button_DonationImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Donation");
     			}
     			return this.m_E_Button_DonationImage;
     		}
     	}

		public Button E_Button_FenXiangButton
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
		    		this.m_E_Button_FenXiangButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_FenXiang");
     			}
     			return this.m_E_Button_FenXiangButton;
     		}
     	}

		public Image E_Button_FenXiangImage
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
		    		this.m_E_Button_FenXiangImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_FenXiang");
     			}
     			return this.m_E_Button_FenXiangImage;
     		}
     	}

		public Button E_Btn_EveryTaskButton
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
		    		this.m_E_Btn_EveryTaskButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Btn_EveryTask");
     			}
     			return this.m_E_Btn_EveryTaskButton;
     		}
     	}

		public Image E_Btn_EveryTaskImage
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
		    		this.m_E_Btn_EveryTaskImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Btn_EveryTask");
     			}
     			return this.m_E_Btn_EveryTaskImage;
     		}
     	}

		public Button E_Button_RechargeButton
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
		    		this.m_E_Button_RechargeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Recharge");
     			}
     			return this.m_E_Button_RechargeButton;
     		}
     	}

		public Image E_Button_RechargeImage
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
		    		this.m_E_Button_RechargeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Recharge");
     			}
     			return this.m_E_Button_RechargeImage;
     		}
     	}

		public Button E_Btn_HuoDongButton
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
		    		this.m_E_Btn_HuoDongButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Btn_HuoDong");
     			}
     			return this.m_E_Btn_HuoDongButton;
     		}
     	}

		public Image E_Btn_HuoDongImage
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
		    		this.m_E_Btn_HuoDongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Btn_HuoDong");
     			}
     			return this.m_E_Btn_HuoDongImage;
     		}
     	}

		public Button E_Button_ZhenYingButton
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
		    		this.m_E_Button_ZhenYingButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_ZhenYing");
     			}
     			return this.m_E_Button_ZhenYingButton;
     		}
     	}

		public Image E_Button_ZhenYingImage
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
		    		this.m_E_Button_ZhenYingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_ZhenYing");
     			}
     			return this.m_E_Button_ZhenYingImage;
     		}
     	}

		public Button E_Button_EnergyButton
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
		    		this.m_E_Button_EnergyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Energy");
     			}
     			return this.m_E_Button_EnergyButton;
     		}
     	}

		public Image E_Button_EnergyImage
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
		    		this.m_E_Button_EnergyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Energy");
     			}
     			return this.m_E_Button_EnergyImage;
     		}
     	}

		public Button E_Button_FashionButton
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
		    		this.m_E_Button_FashionButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Fashion");
     			}
     			return this.m_E_Button_FashionButton;
     		}
     	}

		public Image E_Button_FashionImage
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
		    		this.m_E_Button_FashionImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Fashion");
     			}
     			return this.m_E_Button_FashionImage;
     		}
     	}

		public Button E_Button_DemonButton
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
		    		this.m_E_Button_DemonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Demon");
     			}
     			return this.m_E_Button_DemonButton;
     		}
     	}

		public Image E_Button_DemonImage
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
		    		this.m_E_Button_DemonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Demon");
     			}
     			return this.m_E_Button_DemonImage;
     		}
     	}

		public Button E_Button_SeasonButton
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
		    		this.m_E_Button_SeasonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Season");
     			}
     			return this.m_E_Button_SeasonButton;
     		}
     	}

		public Image E_Button_SeasonImage
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
		    		this.m_E_Button_SeasonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_1/E_Button_Season");
     			}
     			return this.m_E_Button_SeasonImage;
     		}
     	}

		public RectTransform EG_Btn_TopRight_2RectTransform
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
		    		this.m_EG_Btn_TopRight_2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2");
     			}
     			return this.m_EG_Btn_TopRight_2RectTransform;
     		}
     	}

		public Button E_Button_ActivityV1Button
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
		    		this.m_E_Button_ActivityV1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_ActivityV1");
     			}
     			return this.m_E_Button_ActivityV1Button;
     		}
     	}

		public Image E_Button_ActivityV1Image
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
		    		this.m_E_Button_ActivityV1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_ActivityV1");
     			}
     			return this.m_E_Button_ActivityV1Image;
     		}
     	}

		public Button E_Btn_AuctionButton
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
		    		this.m_E_Btn_AuctionButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionButton;
     		}
     	}

		public Image E_Btn_AuctionImage
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
		    		this.m_E_Btn_AuctionImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Btn_Auction");
     			}
     			return this.m_E_Btn_AuctionImage;
     		}
     	}

		public Button E_Button_HongBaoButton
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
		    		this.m_E_Button_HongBaoButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_HongBao");
     			}
     			return this.m_E_Button_HongBaoButton;
     		}
     	}

		public Image E_Button_HongBaoImage
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
		    		this.m_E_Button_HongBaoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_HongBao");
     			}
     			return this.m_E_Button_HongBaoImage;
     		}
     	}

		public Button E_Button_ZhanQuButton
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
		    		this.m_E_Button_ZhanQuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_ZhanQu");
     			}
     			return this.m_E_Button_ZhanQuButton;
     		}
     	}

		public Image E_Button_ZhanQuImage
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
		    		this.m_E_Button_ZhanQuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_ZhanQu");
     			}
     			return this.m_E_Button_ZhanQuImage;
     		}
     	}

		public Button E_Button_NewYearButton
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
		    		this.m_E_Button_NewYearButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_NewYear");
     			}
     			return this.m_E_Button_NewYearButton;
     		}
     	}

		public Image E_Button_NewYearImage
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
		    		this.m_E_Button_NewYearImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_NewYear");
     			}
     			return this.m_E_Button_NewYearImage;
     		}
     	}

		public Button E_Button_RechargeRewardButton
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
		    		this.m_E_Button_RechargeRewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_RechargeReward");
     			}
     			return this.m_E_Button_RechargeRewardButton;
     		}
     	}

		public Image E_Button_RechargeRewardImage
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
		    		this.m_E_Button_RechargeRewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_RechargeReward");
     			}
     			return this.m_E_Button_RechargeRewardImage;
     		}
     	}

		public Button E_Button_WelfareButton
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
		    		this.m_E_Button_WelfareButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_Welfare");
     			}
     			return this.m_E_Button_WelfareButton;
     		}
     	}

		public Image E_Button_WelfareImage
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
		    		this.m_E_Button_WelfareImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_Welfare");
     			}
     			return this.m_E_Button_WelfareImage;
     		}
     	}

		public Button E_Btn_GMButton
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
		    		this.m_E_Btn_GMButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Btn_GM");
     			}
     			return this.m_E_Btn_GMButton;
     		}
     	}

		public Image E_Btn_GMImage
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
		    		this.m_E_Btn_GMImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Btn_GM");
     			}
     			return this.m_E_Btn_GMImage;
     		}
     	}

		public Button E_Btn_RankButton
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
		    		this.m_E_Btn_RankButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Btn_Rank");
     			}
     			return this.m_E_Btn_RankButton;
     		}
     	}

		public Image E_Btn_RankImage
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
		    		this.m_E_Btn_RankImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Btn_Rank");
     			}
     			return this.m_E_Btn_RankImage;
     		}
     	}

		public Button E_Button_WorldLvButton
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
		    		this.m_E_Button_WorldLvButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Button_WorldLv");
     			}
     			return this.m_E_Button_WorldLvButton;
     		}
     	}

		public Button E_Btn_PaiMaiHangButton
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
		    		this.m_E_Btn_PaiMaiHangButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_2/E_Btn_PaiMaiHang");
     			}
     			return this.m_E_Btn_PaiMaiHangButton;
     		}
     	}

		public RectTransform EG_Btn_TopRight_3RectTransform
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
		    		this.m_EG_Btn_TopRight_3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3");
     			}
     			return this.m_EG_Btn_TopRight_3RectTransform;
     		}
     	}

		public RectTransform EG_Btn_KillMonsterRewardRectTransform
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
		    		this.m_EG_Btn_KillMonsterRewardRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/EG_Btn_KillMonsterReward");
     			}
     			return this.m_EG_Btn_KillMonsterRewardRectTransform;
     		}
     	}

		public RectTransform EG_Btn_LvRewardRectTransform
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
		    		this.m_EG_Btn_LvRewardRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/EG_Btn_LvReward");
     			}
     			return this.m_EG_Btn_LvRewardRectTransform;
     		}
     	}

		public Button E_MailHintTipButton
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
		    		this.m_E_MailHintTipButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_MailHintTip");
     			}
     			return this.m_E_MailHintTipButton;
     		}
     	}

		public Image E_MailHintTipImage
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
		    		this.m_E_MailHintTipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_MailHintTip");
     			}
     			return this.m_E_MailHintTipImage;
     		}
     	}

		public Button E_E_Btn_MapTransferButton
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
		    		this.m_E_E_Btn_MapTransferButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_E_Btn_MapTransfer");
     			}
     			return this.m_E_E_Btn_MapTransferButton;
     		}
     	}

		public Image E_E_Btn_MapTransferImage
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
		    		this.m_E_E_Btn_MapTransferImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_E_Btn_MapTransfer");
     			}
     			return this.m_E_E_Btn_MapTransferImage;
     		}
     	}

		public Button E_Btn_RerurnDungeonButton
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
		    		this.m_E_Btn_RerurnDungeonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnDungeon");
     			}
     			return this.m_E_Btn_RerurnDungeonButton;
     		}
     	}

		public Image E_Btn_RerurnDungeonImage
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
		    		this.m_E_Btn_RerurnDungeonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnDungeon");
     			}
     			return this.m_E_Btn_RerurnDungeonImage;
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
		    		this.m_E_Btn_RerurnBuildingButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnBuilding");
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
		    		this.m_E_Btn_RerurnBuildingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_Btn_TopRight_3/E_Btn_RerurnBuilding");
     			}
     			return this.m_E_Btn_RerurnBuildingImage;
     		}
     	}

		public RectTransform EG_HomeButtonRectTransform
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
		    		this.m_EG_HomeButtonRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton");
     			}
     			return this.m_EG_HomeButtonRectTransform;
     		}
     	}

		public Button E_AdventureButton
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
		    		this.m_E_AdventureButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_Adventure");
     			}
     			return this.m_E_AdventureButton;
     		}
     	}

		public Image E_AdventureImage
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
		    		this.m_E_AdventureImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_Adventure");
     			}
     			return this.m_E_AdventureImage;
     		}
     	}

		public Button E_PetFormationButton
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
		    		this.m_E_PetFormationButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_PetFormation");
     			}
     			return this.m_E_PetFormationButton;
     		}
     	}

		public Image E_PetFormationImage
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
		    		this.m_E_PetFormationImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_PetFormation");
     			}
     			return this.m_E_PetFormationImage;
     		}
     	}

		public EventTrigger E_PetFormationEventTrigger
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
		    		this.m_E_PetFormationEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_PetFormation");
     			}
     			return this.m_E_PetFormationEventTrigger;
     		}
     	}

		public Button E_CityHorseButton
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
		    		this.m_E_CityHorseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_CityHorse");
     			}
     			return this.m_E_CityHorseButton;
     		}
     	}

		public Image E_CityHorseImage
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
		    		this.m_E_CityHorseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_CityHorse");
     			}
     			return this.m_E_CityHorseImage;
     		}
     	}

		public Button E_TeamDungeonButton
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
		    		this.m_E_TeamDungeonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_TeamDungeon");
     			}
     			return this.m_E_TeamDungeonButton;
     		}
     	}

		public Image E_TeamDungeonImage
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
		    		this.m_E_TeamDungeonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_TeamDungeon");
     			}
     			return this.m_E_TeamDungeonImage;
     		}
     	}

		public Button E_JiaYuanButton
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
		    		this.m_E_JiaYuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_JiaYuan");
     			}
     			return this.m_E_JiaYuanButton;
     		}
     	}

		public Image E_JiaYuanImage
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
		    		this.m_E_JiaYuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_JiaYuan");
     			}
     			return this.m_E_JiaYuanImage;
     		}
     	}

		public EventTrigger E_JiaYuanEventTrigger
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
		    		this.m_E_JiaYuanEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_JiaYuan");
     			}
     			return this.m_E_JiaYuanEventTrigger;
     		}
     	}

		public Button E_NpcDuiHuaButton
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
		    		this.m_E_NpcDuiHuaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_NpcDuiHua");
     			}
     			return this.m_E_NpcDuiHuaButton;
     		}
     	}

		public Image E_NpcDuiHuaImage
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
		    		this.m_E_NpcDuiHuaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_NpcDuiHua");
     			}
     			return this.m_E_NpcDuiHuaImage;
     		}
     	}

		public Button E_UnionButton
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
		    		this.m_E_UnionButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_Union");
     			}
     			return this.m_E_UnionButton;
     		}
     	}

		public Image E_UnionImage
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
		    		this.m_E_UnionImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_Union");
     			}
     			return this.m_E_UnionImage;
     		}
     	}

		public EventTrigger E_UnionEventTrigger
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
		    		this.m_E_UnionEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_RightSet/EG_HomeButton/E_Union");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_RightSet/ES_MainSkill");
		    	   this.m_es_mainskill = this.AddChild<ES_MainSkill,Transform>(subTrans);
     			}
     			return this.m_es_mainskill;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_OpenBox");
		    	   this.m_es_openbox = this.AddChild<ES_OpenBox,Transform>(subTrans);
     			}
     			return this.m_es_openbox;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_Singing");
		    	   this.m_es_singing = this.AddChild<ES_Singing,Transform>(subTrans);
     			}
     			return this.m_es_singing;
     		}
     	}

		public RectTransform EG_FpsRectTransform
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
		    		this.m_EG_FpsRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Fps");
     			}
     			return this.m_EG_FpsRectTransform;
     		}
     	}

		public Text E_TextFpsText
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
		    		this.m_E_TextFpsText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Fps/E_TextFps");
     			}
     			return this.m_E_TextFpsText;
     		}
     	}

		public Text E_TextPingText
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
		    		this.m_E_TextPingText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Fps/E_TextPing");
     			}
     			return this.m_E_TextPingText;
     		}
     	}

		public Text E_TextMessageText
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
		    		this.m_E_TextMessageText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Fps/E_TextMessage");
     			}
     			return this.m_E_TextMessageText;
     		}
     	}

		public RectTransform EG_GuaJiSetRectTransform
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
		    		this.m_EG_GuaJiSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_GuaJiSet");
     			}
     			return this.m_EG_GuaJiSetRectTransform;
     		}
     	}

		public Button E_Btn_StopGuaJiButton
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
		    		this.m_E_Btn_StopGuaJiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_GuaJiSet/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiButton;
     		}
     	}

		public Image E_Btn_StopGuaJiImage
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
		    		this.m_E_Btn_StopGuaJiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_GuaJiSet/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_DragPanelImage = null;
			this.m_E_DragPanelEventTrigger = null;
			this.m_es_buttonpositionset = null;
			this.m_es_joystickmove = null;
			this.m_es_rolehead = null;
			this.m_EG_PhoneLeftRectTransform = null;
			this.m_EG_MainTaskRectTransform = null;
			this.m_E_RoseTaskButton = null;
			this.m_E_RoseTaskImage = null;
			this.m_E_MainTaskItemsLoopVerticalScrollRect = null;
			this.m_E_LeftTypeSetToggleGroup = null;
			this.m_E_LeftTypeSetImage = null;
			this.m_EG_MainTeamRectTransform = null;
			this.m_E_MainTeamItemsLoopVerticalScrollRect = null;
			this.m_E_RoseTeamButton = null;
			this.m_E_RoseTeamImage = null;
			this.m_EG_LeftSetRectTransform = null;
			this.m_es_mainhpbar = null;
			this.m_es_mainbuff = null;
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
			this.m_E_ExpProImage = null;
			this.m_E_ExpValueText = null;
			this.m_EG_MainChatRectTransform = null;
			this.m_E_MainChatItemsLoopVerticalScrollRect = null;
			this.m_E_OpenChatButton = null;
			this.m_E_OpenChatImage = null;
			this.m_EG_RightSetRectTransform = null;
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
			this.m_es_openbox = null;
			this.m_es_singing = null;
			this.m_EG_FpsRectTransform = null;
			this.m_E_TextFpsText = null;
			this.m_E_TextPingText = null;
			this.m_E_TextMessageText = null;
			this.m_EG_GuaJiSetRectTransform = null;
			this.m_E_Btn_StopGuaJiButton = null;
			this.m_E_Btn_StopGuaJiImage = null;
			this.uiTransform = null;
		}

		private Image m_E_DragPanelImage = null;
		private EventTrigger m_E_DragPanelEventTrigger = null;
		private EntityRef<ES_ButtonPositionSet> m_es_buttonpositionset = null;
		private EntityRef<ES_JoystickMove> m_es_joystickmove = null;
		private EntityRef<ES_RoleHead> m_es_rolehead = null;
		private RectTransform m_EG_PhoneLeftRectTransform = null;
		private RectTransform m_EG_MainTaskRectTransform = null;
		private Button m_E_RoseTaskButton = null;
		private Image m_E_RoseTaskImage = null;
		private LoopVerticalScrollRect m_E_MainTaskItemsLoopVerticalScrollRect = null;
		private ToggleGroup m_E_LeftTypeSetToggleGroup = null;
		private Image m_E_LeftTypeSetImage = null;
		private RectTransform m_EG_MainTeamRectTransform = null;
		private LoopVerticalScrollRect m_E_MainTeamItemsLoopVerticalScrollRect = null;
		private Button m_E_RoseTeamButton = null;
		private Image m_E_RoseTeamImage = null;
		private RectTransform m_EG_LeftSetRectTransform = null;
		private EntityRef<ES_MainHpBar> m_es_mainhpbar = null;
		private EntityRef<ES_MainBuff> m_es_mainbuff = null;
		private RectTransform m_EG_LeftBottomSetRectTransform = null;
		private Button m_E_ShrinkButton = null;
		private Image m_E_ShrinkImage = null;
		private EventTrigger m_E_ShrinkEventTrigger = null;
		private RectTransform m_EG_LeftBottomBtnsRectTransform = null;
		private Button m_E_RoseEquipButton = null;
		private Image m_E_RoseEquipImage = null;
		private EventTrigger m_E_RoseEquipEventTrigger = null;
		private Button m_E_PetButton = null;
		private Image m_E_PetImage = null;
		private EventTrigger m_E_PetEventTrigger = null;
		private Button m_E_RoseSkillButton = null;
		private Image m_E_RoseSkillImage = null;
		private EventTrigger m_E_RoseSkillEventTrigger = null;
		private Button m_E_TaskButton = null;
		private Image m_E_TaskImage = null;
		private EventTrigger m_E_TaskEventTrigger = null;
		private Button m_E_FriendButton = null;
		private Image m_E_FriendImage = null;
		private Button m_E_ChengJiuButton = null;
		private Image m_E_ChengJiuImage = null;
		private RectTransform m_EG_RoseExpRectTransform = null;
		private Image m_E_ExpProImage = null;
		private Text m_E_ExpValueText = null;
		private RectTransform m_EG_MainChatRectTransform = null;
		private LoopVerticalScrollRect m_E_MainChatItemsLoopVerticalScrollRect = null;
		private Button m_E_OpenChatButton = null;
		private Image m_E_OpenChatImage = null;
		private RectTransform m_EG_RightSetRectTransform = null;
		private EntityRef<ES_MapMini> m_es_mapmini = null;
		private EntityRef<ES_MainActivityTip> m_es_mainactivitytip = null;
		private Button m_E_Button_ZhanKaiButton = null;
		private Image m_E_Button_ZhanKaiImage = null;
		private RectTransform m_EG_Btn_TopRight_1RectTransform = null;
		private Button m_E_Button_RunRaceButton = null;
		private Image m_E_Button_RunRaceImage = null;
		private Button m_E_Button_HappyButton = null;
		private Image m_E_Button_HappyImage = null;
		private Button m_E_Button_HuntButton = null;
		private Image m_E_Button_HuntImage = null;
		private Button m_E_Button_SoloButton = null;
		private Image m_E_Button_SoloImage = null;
		private Button m_E_Btn_BattleButton = null;
		private Image m_E_Btn_BattleImage = null;
		private Button m_E_Button_DonationButton = null;
		private Image m_E_Button_DonationImage = null;
		private Button m_E_Button_FenXiangButton = null;
		private Image m_E_Button_FenXiangImage = null;
		private Button m_E_Btn_EveryTaskButton = null;
		private Image m_E_Btn_EveryTaskImage = null;
		private Button m_E_Button_RechargeButton = null;
		private Image m_E_Button_RechargeImage = null;
		private Button m_E_Btn_HuoDongButton = null;
		private Image m_E_Btn_HuoDongImage = null;
		private Button m_E_Button_ZhenYingButton = null;
		private Image m_E_Button_ZhenYingImage = null;
		private Button m_E_Button_EnergyButton = null;
		private Image m_E_Button_EnergyImage = null;
		private Button m_E_Button_FashionButton = null;
		private Image m_E_Button_FashionImage = null;
		private Button m_E_Button_DemonButton = null;
		private Image m_E_Button_DemonImage = null;
		private Button m_E_Button_SeasonButton = null;
		private Image m_E_Button_SeasonImage = null;
		private RectTransform m_EG_Btn_TopRight_2RectTransform = null;
		private Button m_E_Button_ActivityV1Button = null;
		private Image m_E_Button_ActivityV1Image = null;
		private Button m_E_Btn_AuctionButton = null;
		private Image m_E_Btn_AuctionImage = null;
		private Button m_E_Button_HongBaoButton = null;
		private Image m_E_Button_HongBaoImage = null;
		private Button m_E_Button_ZhanQuButton = null;
		private Image m_E_Button_ZhanQuImage = null;
		private Button m_E_Button_NewYearButton = null;
		private Image m_E_Button_NewYearImage = null;
		private Button m_E_Button_RechargeRewardButton = null;
		private Image m_E_Button_RechargeRewardImage = null;
		private Button m_E_Button_WelfareButton = null;
		private Image m_E_Button_WelfareImage = null;
		private Button m_E_Btn_GMButton = null;
		private Image m_E_Btn_GMImage = null;
		private Button m_E_Btn_RankButton = null;
		private Image m_E_Btn_RankImage = null;
		private Button m_E_Button_WorldLvButton = null;
		private Button m_E_Btn_PaiMaiHangButton = null;
		private RectTransform m_EG_Btn_TopRight_3RectTransform = null;
		private RectTransform m_EG_Btn_KillMonsterRewardRectTransform = null;
		private RectTransform m_EG_Btn_LvRewardRectTransform = null;
		private Button m_E_MailHintTipButton = null;
		private Image m_E_MailHintTipImage = null;
		private Button m_E_E_Btn_MapTransferButton = null;
		private Image m_E_E_Btn_MapTransferImage = null;
		private Button m_E_Btn_RerurnDungeonButton = null;
		private Image m_E_Btn_RerurnDungeonImage = null;
		private Button m_E_Btn_RerurnBuildingButton = null;
		private Image m_E_Btn_RerurnBuildingImage = null;
		private RectTransform m_EG_HomeButtonRectTransform = null;
		private Button m_E_AdventureButton = null;
		private Image m_E_AdventureImage = null;
		private Button m_E_PetFormationButton = null;
		private Image m_E_PetFormationImage = null;
		private EventTrigger m_E_PetFormationEventTrigger = null;
		private Button m_E_CityHorseButton = null;
		private Image m_E_CityHorseImage = null;
		private Button m_E_TeamDungeonButton = null;
		private Image m_E_TeamDungeonImage = null;
		private Button m_E_JiaYuanButton = null;
		private Image m_E_JiaYuanImage = null;
		private EventTrigger m_E_JiaYuanEventTrigger = null;
		private Button m_E_NpcDuiHuaButton = null;
		private Image m_E_NpcDuiHuaImage = null;
		private Button m_E_UnionButton = null;
		private Image m_E_UnionImage = null;
		private EventTrigger m_E_UnionEventTrigger = null;
		private EntityRef<ES_MainSkill> m_es_mainskill = null;
		private EntityRef<ES_OpenBox> m_es_openbox = null;
		private EntityRef<ES_Singing> m_es_singing = null;
		private RectTransform m_EG_FpsRectTransform = null;
		private Text m_E_TextFpsText = null;
		private Text m_E_TextPingText = null;
		private Text m_E_TextMessageText = null;
		private RectTransform m_EG_GuaJiSetRectTransform = null;
		private Button m_E_Btn_StopGuaJiButton = null;
		private Image m_E_Btn_StopGuaJiImage = null;
		public Transform uiTransform = null;
	}
}
