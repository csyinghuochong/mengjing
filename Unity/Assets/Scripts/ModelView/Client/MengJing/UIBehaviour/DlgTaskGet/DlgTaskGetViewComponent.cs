
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTaskGet))]
	[EnableMethod]
	public  class DlgTaskGetViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Img_buttonButton
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
		    		this.m_E_Img_buttonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Img_buttonImage
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
		    		this.m_E_Img_buttonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonMysteryButton
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
		    		this.m_E_ButtonMysteryButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonMystery");
     			}
     			return this.m_E_ButtonMysteryButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMysteryImage
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
		    		this.m_E_ButtonMysteryImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonMystery");
     			}
     			return this.m_E_ButtonMysteryImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonPetFragmentButton
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
		    		this.m_E_ButtonPetFragmentButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonPetFragment");
     			}
     			return this.m_E_ButtonPetFragmentButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonPetFragmentImage
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
		    		this.m_E_ButtonPetFragmentImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonPetFragment");
     			}
     			return this.m_E_ButtonPetFragmentImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonExpDuiHuanButton
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
		    		this.m_E_ButtonExpDuiHuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonExpDuiHuan");
     			}
     			return this.m_E_ButtonExpDuiHuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonExpDuiHuanImage
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
		    		this.m_E_ButtonExpDuiHuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonExpDuiHuan");
     			}
     			return this.m_E_ButtonExpDuiHuanImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonJieRiRewardButton
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
		    		this.m_E_ButtonJieRiRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonJieRiReward");
     			}
     			return this.m_E_ButtonJieRiRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonJieRiRewardImage
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
		    		this.m_E_ButtonJieRiRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonJieRiReward");
     			}
     			return this.m_E_ButtonJieRiRewardImage;
     		}
     	}

		public UnityEngine.RectTransform EG_EnergySkillRectTransform
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
		    		this.m_EG_EnergySkillRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_EnergySkill");
     			}
     			return this.m_EG_EnergySkillRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_EnergyDuihuanButton
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
		    		this.m_E_Btn_EnergyDuihuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_EnergySkill/E_Btn_EnergyDuihuan");
     			}
     			return this.m_E_Btn_EnergyDuihuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_EnergyDuihuanImage
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
		    		this.m_E_Btn_EnergyDuihuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_EnergySkill/E_Btn_EnergyDuihuan");
     			}
     			return this.m_E_Btn_EnergyDuihuanImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_MoNnengHintText
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
		    		this.m_E_Lab_MoNnengHintText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_EnergySkill/E_Lab_MoNnengHint");
     			}
     			return this.m_E_Lab_MoNnengHintText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_HuoBiNameText
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
		    		this.m_E_Lab_HuoBiNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_EnergySkill/E_Lab_HuoBiName");
     			}
     			return this.m_E_Lab_HuoBiNameText;
     		}
     	}

		public UnityEngine.UI.Image E_EnergySkillImageImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnergySkillImageImage == null )
     			{
		    		this.m_E_EnergySkillImageImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_EnergySkill/E_EnergySkillImage");
     			}
     			return this.m_E_EnergySkillImageImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGiveTaskButton
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
		    		this.m_E_ButtonGiveTaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonGiveTask");
     			}
     			return this.m_E_ButtonGiveTaskButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGiveTaskImage
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
		    		this.m_E_ButtonGiveTaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonGiveTask");
     			}
     			return this.m_E_ButtonGiveTaskImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NpcNameText
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
		    		this.m_E_Lab_NpcNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_NpcName");
     			}
     			return this.m_E_Lab_NpcNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NpcSpeakText
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
		    		this.m_E_Lab_NpcSpeakText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_NpcSpeak");
     			}
     			return this.m_E_Lab_NpcSpeakText;
     		}
     	}

		public UnityEngine.UI.Button E_CancelNpcSpeakButton
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
		    		this.m_E_CancelNpcSpeakButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_CancelNpcSpeak");
     			}
     			return this.m_E_CancelNpcSpeakButton;
     		}
     	}

		public UnityEngine.UI.Image E_CancelNpcSpeakImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelNpcSpeakImage == null )
     			{
		    		this.m_E_CancelNpcSpeakImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_CancelNpcSpeak");
     			}
     			return this.m_E_CancelNpcSpeakImage;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_TaskGetItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGetItemsScrollRect == null )
     			{
		    		this.m_E_TaskGetItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_TaskGetItems");
     			}
     			return this.m_E_TaskGetItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_TaskGetItemsImage
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
		    		this.m_E_TaskGetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_TaskGetItems");
     			}
     			return this.m_E_TaskGetItemsImage;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_TaskFubenItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskFubenItemsScrollRect == null )
     			{
		    		this.m_E_TaskFubenItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_TaskFubenItems");
     			}
     			return this.m_E_TaskFubenItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_TaskFubenItemsImage
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
		    		this.m_E_TaskFubenItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_TaskFubenItems");
     			}
     			return this.m_E_TaskFubenItemsImage;
     		}
     	}

		public UnityEngine.RectTransform EG_TaskDescRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TaskDescRectTransform == null )
     			{
		    		this.m_EG_TaskDescRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_TaskDesc");
     			}
     			return this.m_EG_TaskDescRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TaskDeskText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TaskDeskText == null )
     			{
		    		this.m_E_Lab_TaskDeskText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TaskDesc/E_Lab_TaskDesk");
     			}
     			return this.m_E_Lab_TaskDeskText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TaskNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TaskNameText == null )
     			{
		    		this.m_E_Lab_TaskNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TaskDesc/E_Lab_TaskName");
     			}
     			return this.m_E_Lab_TaskNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TextText == null )
     			{
		    		this.m_E_Lab_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TaskDesc/E_Lab_Text");
     			}
     			return this.m_E_Lab_TextText;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_TaskDesc/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGetButton
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetImage
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonReturnButton == null )
     			{
		    		this.m_E_ButtonReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonReturn");
     			}
     			return this.m_E_ButtonReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonReturnImage == null )
     			{
		    		this.m_E_ButtonReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonReturn");
     			}
     			return this.m_E_ButtonReturnImage;
     		}
     	}

		public UnityEngine.UI.Button E_BtnCommitTask1Button
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
		    		this.m_E_BtnCommitTask1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_BtnCommitTask1");
     			}
     			return this.m_E_BtnCommitTask1Button;
     		}
     	}

		public UnityEngine.UI.Image E_BtnCommitTask1Image
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
		    		this.m_E_BtnCommitTask1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_BtnCommitTask1");
     			}
     			return this.m_E_BtnCommitTask1Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_buttonButton = null;
			this.m_E_Img_buttonImage = null;
			this.m_E_ButtonMysteryButton = null;
			this.m_E_ButtonMysteryImage = null;
			this.m_E_ButtonPetFragmentButton = null;
			this.m_E_ButtonPetFragmentImage = null;
			this.m_E_ButtonExpDuiHuanButton = null;
			this.m_E_ButtonExpDuiHuanImage = null;
			this.m_E_ButtonJieRiRewardButton = null;
			this.m_E_ButtonJieRiRewardImage = null;
			this.m_EG_EnergySkillRectTransform = null;
			this.m_E_Btn_EnergyDuihuanButton = null;
			this.m_E_Btn_EnergyDuihuanImage = null;
			this.m_E_Lab_MoNnengHintText = null;
			this.m_E_Lab_HuoBiNameText = null;
			this.m_E_EnergySkillImageImage = null;
			this.m_E_ButtonGiveTaskButton = null;
			this.m_E_ButtonGiveTaskImage = null;
			this.m_E_Lab_NpcNameText = null;
			this.m_E_Lab_NpcSpeakText = null;
			this.m_E_CancelNpcSpeakButton = null;
			this.m_E_CancelNpcSpeakImage = null;
			this.m_E_TaskGetItemsScrollRect = null;
			this.m_E_TaskGetItemsImage = null;
			this.m_E_TaskFubenItemsScrollRect = null;
			this.m_E_TaskFubenItemsImage = null;
			this.m_EG_TaskDescRectTransform = null;
			this.m_E_Lab_TaskDeskText = null;
			this.m_E_Lab_TaskNameText = null;
			this.m_E_Lab_TextText = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.m_E_ButtonReturnButton = null;
			this.m_E_ButtonReturnImage = null;
			this.m_E_BtnCommitTask1Button = null;
			this.m_E_BtnCommitTask1Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Img_buttonButton = null;
		private UnityEngine.UI.Image m_E_Img_buttonImage = null;
		private UnityEngine.UI.Button m_E_ButtonMysteryButton = null;
		private UnityEngine.UI.Image m_E_ButtonMysteryImage = null;
		private UnityEngine.UI.Button m_E_ButtonPetFragmentButton = null;
		private UnityEngine.UI.Image m_E_ButtonPetFragmentImage = null;
		private UnityEngine.UI.Button m_E_ButtonExpDuiHuanButton = null;
		private UnityEngine.UI.Image m_E_ButtonExpDuiHuanImage = null;
		private UnityEngine.UI.Button m_E_ButtonJieRiRewardButton = null;
		private UnityEngine.UI.Image m_E_ButtonJieRiRewardImage = null;
		private UnityEngine.RectTransform m_EG_EnergySkillRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_EnergyDuihuanButton = null;
		private UnityEngine.UI.Image m_E_Btn_EnergyDuihuanImage = null;
		private UnityEngine.UI.Text m_E_Lab_MoNnengHintText = null;
		private UnityEngine.UI.Text m_E_Lab_HuoBiNameText = null;
		private UnityEngine.UI.Image m_E_EnergySkillImageImage = null;
		private UnityEngine.UI.Button m_E_ButtonGiveTaskButton = null;
		private UnityEngine.UI.Image m_E_ButtonGiveTaskImage = null;
		private UnityEngine.UI.Text m_E_Lab_NpcNameText = null;
		private UnityEngine.UI.Text m_E_Lab_NpcSpeakText = null;
		private UnityEngine.UI.Button m_E_CancelNpcSpeakButton = null;
		private UnityEngine.UI.Image m_E_CancelNpcSpeakImage = null;
		private UnityEngine.UI.ScrollRect m_E_TaskGetItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_TaskGetItemsImage = null;
		private UnityEngine.UI.ScrollRect m_E_TaskFubenItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_TaskFubenItemsImage = null;
		private UnityEngine.RectTransform m_EG_TaskDescRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_TaskDeskText = null;
		private UnityEngine.UI.Text m_E_Lab_TaskNameText = null;
		private UnityEngine.UI.Text m_E_Lab_TextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		private UnityEngine.UI.Button m_E_ButtonReturnButton = null;
		private UnityEngine.UI.Image m_E_ButtonReturnImage = null;
		private UnityEngine.UI.Button m_E_BtnCommitTask1Button = null;
		private UnityEngine.UI.Image m_E_BtnCommitTask1Image = null;
		public Transform uiTransform = null;
	}
}
