using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTaskGet))]
	[EnableMethod]
	public  class DlgTaskGetViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Img_buttonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_buttonButton == null )
     			{
		    		this.m_E_Img_buttonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonButton;
     		}
     	}

		public Image E_Img_buttonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_buttonImage == null )
     			{
		    		this.m_E_Img_buttonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonImage;
     		}
     	}

		public Text E_Lab_NpcNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NpcNameText == null )
     			{
		    		this.m_E_Lab_NpcNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_NpcName");
     			}
     			return this.m_E_Lab_NpcNameText;
     		}
     	}

		public Text E_Lab_NpcSpeakText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NpcSpeakText == null )
     			{
		    		this.m_E_Lab_NpcSpeakText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_NpcSpeak");
     			}
     			return this.m_E_Lab_NpcSpeakText;
     		}
     	}
		
		public Button E_CancelNpcSpeakButton
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_CancelNpcSpeakButton == null )
				{
					this.m_E_CancelNpcSpeakButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CancelNpcSpeak");
				}
				return this.m_E_CancelNpcSpeakButton;
			}
		}

		public Image E_TaskGetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGetItemsImage == null )
     			{
		    		this.m_E_TaskGetItemsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_TaskGetItems");
     			}
     			return this.m_E_TaskGetItemsImage;
     		}
     	}

		public ScrollRect E_TaskGetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TaskGetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<ScrollRect>(this.uiTransform.gameObject,"E_TaskGetItems");
     			}
     			return this.m_E_TaskGetItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonGetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetButton == null )
     			{
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public Image E_ButtonGetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetImage == null )
     			{
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_TaskGetItems/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public Button E_BtnCommitTask1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCommitTask1Button == null )
     			{
		    		this.m_E_BtnCommitTask1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_BtnCommitTask1");
     			}
     			return this.m_E_BtnCommitTask1Button;
     		}
     	}

		public Image E_BtnCommitTask1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCommitTask1Image == null )
     			{
		    		this.m_E_BtnCommitTask1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BtnCommitTask1");
     			}
     			return this.m_E_BtnCommitTask1Image;
     		}
     	}

		public Button E_ButtonGiveTaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGiveTaskButton == null )
     			{
		    		this.m_E_ButtonGiveTaskButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonGiveTask");
     			}
     			return this.m_E_ButtonGiveTaskButton;
     		}
     	}

		public Image E_ButtonGiveTaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGiveTaskImage == null )
     			{
		    		this.m_E_ButtonGiveTaskImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_TaskGetItems/E_ButtonGiveTask");
     			}
     			return this.m_E_ButtonGiveTaskImage;
     		}
     	}

		public RectTransform EG_EnergySkillRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EnergySkillRectTransform == null )
     			{
		    		this.m_EG_EnergySkillRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_EnergySkill");
     			}
     			return this.m_EG_EnergySkillRectTransform;
     		}
     	}

		public Button E_Btn_EnergyDuihuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnergyDuihuanButton == null )
     			{
		    		this.m_E_Btn_EnergyDuihuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_EnergySkill/E_Btn_EnergyDuihuan");
     			}
     			return this.m_E_Btn_EnergyDuihuanButton;
     		}
     	}

		public Image E_Btn_EnergyDuihuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnergyDuihuanImage == null )
     			{
		    		this.m_E_Btn_EnergyDuihuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_EnergySkill/E_Btn_EnergyDuihuan");
     			}
     			return this.m_E_Btn_EnergyDuihuanImage;
     		}
     	}

		public Text E_Lab_MoNnengHintText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MoNnengHintText == null )
     			{
		    		this.m_E_Lab_MoNnengHintText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_EnergySkill/E_Lab_MoNnengHint");
     			}
     			return this.m_E_Lab_MoNnengHintText;
     		}
     	}

		public Text E_Lab_HuoBiNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_HuoBiNameText == null )
     			{
		    		this.m_E_Lab_HuoBiNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_EnergySkill/E_Lab_HuoBiName");
     			}
     			return this.m_E_Lab_HuoBiNameText;
     		}
     	}

		public Button E_ButtonJieRiRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJieRiRewardButton == null )
     			{
		    		this.m_E_ButtonJieRiRewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonJieRiReward");
     			}
     			return this.m_E_ButtonJieRiRewardButton;
     		}
     	}

		public Button E_ButtonReturnButton
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_ButtonReturn == null )
				{
					this.m_E_ButtonReturn = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonReturn");
				}
				return this.m_E_ButtonReturn;
			}
		}

		public Image E_ButtonJieRiRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJieRiRewardImage == null )
     			{
		    		this.m_E_ButtonJieRiRewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonJieRiReward");
     			}
     			return this.m_E_ButtonJieRiRewardImage;
     		}
     	}

		public Button E_ButtonExpDuiHuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonExpDuiHuanButton == null )
     			{
		    		this.m_E_ButtonExpDuiHuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonExpDuiHuan");
     			}
     			return this.m_E_ButtonExpDuiHuanButton;
     		}
     	}

		public Image E_ButtonExpDuiHuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonExpDuiHuanImage == null )
     			{
		    		this.m_E_ButtonExpDuiHuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonExpDuiHuan");
     			}
     			return this.m_E_ButtonExpDuiHuanImage;
     		}
     	}

		public Button E_ButtonPetFragmentButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPetFragmentButton == null )
     			{
		    		this.m_E_ButtonPetFragmentButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonPetFragment");
     			}
     			return this.m_E_ButtonPetFragmentButton;
     		}
     	}

		public Image E_ButtonPetFragmentImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPetFragmentImage == null )
     			{
		    		this.m_E_ButtonPetFragmentImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonPetFragment");
     			}
     			return this.m_E_ButtonPetFragmentImage;
     		}
     	}

		public Button E_ButtonMysteryButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMysteryButton == null )
     			{
		    		this.m_E_ButtonMysteryButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonMystery");
     			}
     			return this.m_E_ButtonMysteryButton;
     		}
     	}

		public Image E_ButtonMysteryImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMysteryImage == null )
     			{
		    		this.m_E_ButtonMysteryImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonMystery");
     			}
     			return this.m_E_ButtonMysteryImage;
     		}
     	}

		public Image E_EnergySkillImage
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_EnergySkillImage == null )
				{
					this.m_E_EnergySkillImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_EnergySkill/E_EnergySkillImage");
				}
				return this.m_E_EnergySkillImage;
			}
		}

		public Image E_TaskFubenItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskFubenItemsImage == null )
     			{
		    		this.m_E_TaskFubenItemsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_TaskFubenItems");
     			}
     			return this.m_E_TaskFubenItemsImage;
     		}
     	}

		public Transform EG_TaskDesc
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_EG_TaskDesc == null )
				{
					this.m_EG_TaskDesc = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_TaskDesc");
				}
				return this.m_EG_TaskDesc;
			}
		}
		
		public Text E_Lab_TaskDest
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Lab_TaskDest == null )
				{
					this.m_E_Lab_TaskDest = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskDesk");
				}
				return this.m_E_Lab_TaskDest;
			}
		}

		public Text E_Lab_TaskName
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Lab_TaskName == null )
				{
					this.m_E_Lab_TaskName = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskName");
				}
				return this.m_E_Lab_TaskName;
			}
		}
		
		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_BagItemsLoopVerticalScrollRect == null )
				{
					this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
				}
				return this.m_E_BagItemsLoopVerticalScrollRect;
			}
		}
		
		public LoopVerticalScrollRect E_TaskFubenItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskFubenItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TaskFubenItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_TaskFubenItems");
     			}
     			return this.m_E_TaskFubenItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_buttonButton = null;
			this.m_E_Img_buttonImage = null;
			this.m_E_Lab_NpcNameText = null;
			this.m_E_Lab_NpcSpeakText = null;
			this.m_E_CancelNpcSpeakButton = null;
			this.m_E_TaskGetItemsImage = null;
			this.m_E_TaskGetItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.m_E_BtnCommitTask1Button = null;
			this.m_E_BtnCommitTask1Image = null;
			this.m_E_ButtonGiveTaskButton = null;
			this.m_E_ButtonGiveTaskImage = null;
			this.m_EG_EnergySkillRectTransform = null;
			this.m_E_Btn_EnergyDuihuanButton = null;
			this.m_E_Btn_EnergyDuihuanImage = null;
			this.m_E_Lab_MoNnengHintText = null;
			this.m_E_Lab_HuoBiNameText = null;
			this.m_E_ButtonJieRiRewardButton = null;
			this.m_E_ButtonJieRiRewardImage = null;
			this.m_E_ButtonExpDuiHuanButton = null;
			this.m_E_ButtonExpDuiHuanImage = null;
			this.m_E_ButtonPetFragmentButton = null;
			this.m_E_ButtonPetFragmentImage = null;
			this.m_E_ButtonMysteryButton = null;
			this.m_E_ButtonMysteryImage = null;
			this.m_E_TaskFubenItemsImage = null;
			this.m_E_EnergySkillImage = null;
			this.m_E_TaskFubenItemsLoopVerticalScrollRect = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_EG_TaskDesc = null;
			this.m_E_Lab_TaskDest = null;
			this.m_E_Lab_TaskName = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonReturn = null;
			this.uiTransform = null;
		}

		private Button m_E_Img_buttonButton = null;
		private Image m_E_Img_buttonImage = null;
		private Text m_E_Lab_NpcNameText = null;
		private Button m_E_CancelNpcSpeakButton = null;
		private Text m_E_Lab_NpcSpeakText = null;
		private Image m_E_TaskGetItemsImage = null;
		private ScrollRect m_E_TaskGetItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonGetButton = null;
		private Image m_E_ButtonGetImage = null;
		private Button m_E_BtnCommitTask1Button = null;
		private Image m_E_BtnCommitTask1Image = null;
		private Button m_E_ButtonGiveTaskButton = null;
		private Image m_E_ButtonGiveTaskImage = null;
		private RectTransform m_EG_EnergySkillRectTransform = null;
		private Button m_E_Btn_EnergyDuihuanButton = null;
		private Image m_E_Btn_EnergyDuihuanImage = null;
		private Text m_E_Lab_MoNnengHintText = null;
		private Text m_E_Lab_HuoBiNameText = null;
		private Button m_E_ButtonJieRiRewardButton = null;
		private Button m_E_ButtonReturn = null;
		private Image m_E_ButtonJieRiRewardImage = null;
		private Button m_E_ButtonExpDuiHuanButton = null;
		private Image m_E_ButtonExpDuiHuanImage = null;
		private Button m_E_ButtonPetFragmentButton = null;
		private Image m_E_ButtonPetFragmentImage = null;
		private Button m_E_ButtonMysteryButton = null;
		private Image m_E_ButtonMysteryImage = null;
		private Image m_E_TaskFubenItemsImage = null;
		private Image m_E_EnergySkillImage;
		private Transform m_EG_TaskDesc = null;
		private Text m_E_Lab_TaskDest = null;
		private Text m_E_Lab_TaskName = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_TaskFubenItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
