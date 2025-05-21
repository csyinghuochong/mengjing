
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMeleeLevel))]
	[EnableMethod]
	public  class DlgPetMeleeLevelViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.ToggleGroup E_SectionSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SectionSetToggleGroup == null )
     			{
		    		this.m_E_SectionSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_SectionSet");
     			}
     			return this.m_E_SectionSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_PetMeleeLevelItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMeleeLevelItemsImage == null )
     			{
		    		this.m_E_PetMeleeLevelItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_PetMeleeLevelItems");
     			}
     			return this.m_E_PetMeleeLevelItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetMeleeLevelItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMeleeLevelItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetMeleeLevelItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetMeleeLevelItems");
     			}
     			return this.m_E_PetMeleeLevelItemsLoopVerticalScrollRect;
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
		    		this.m_E_PetMeleeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_PetMelee");
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
		    		this.m_E_PetMeleeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_PetMelee");
     			}
     			return this.m_E_PetMeleeImage;
     		}
     	}

		public UnityEngine.UI.Image E_RewardProgressImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardProgressImage == null )
     			{
		    		this.m_E_RewardProgressImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/RewardSet/E_RewardProgress");
     			}
     			return this.m_E_RewardProgressImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward1EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward1EventTrigger == null )
     			{
		    		this.m_E_Reward1EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Left/RewardSet/E_Reward1");
     			}
     			return this.m_E_Reward1EventTrigger;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward2EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward2EventTrigger == null )
     			{
		    		this.m_E_Reward2EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Left/RewardSet/E_Reward2");
     			}
     			return this.m_E_Reward2EventTrigger;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward3EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward3EventTrigger == null )
     			{
		    		this.m_E_Reward3EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Left/RewardSet/E_Reward3");
     			}
     			return this.m_E_Reward3EventTrigger;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward4EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward4EventTrigger == null )
     			{
		    		this.m_E_Reward4EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Left/RewardSet/E_Reward4");
     			}
     			return this.m_E_Reward4EventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_RightBGImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RightBGImage == null )
     			{
		    		this.m_E_RightBGImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RightBG");
     			}
     			return this.m_E_RightBGImage;
     		}
     	}

		public UnityEngine.UI.Text E_LevelNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelNameText == null )
     			{
		    		this.m_E_LevelNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RightBG/E_LevelName");
     			}
     			return this.m_E_LevelNameText;
     		}
     	}

		public UnityEngine.UI.Text E_LevelDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelDesText == null )
     			{
		    		this.m_E_LevelDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RightBG/E_LevelDes");
     			}
     			return this.m_E_LevelDesText;
     		}
     	}

		public UnityEngine.UI.Image E_MonsterItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterItemsImage == null )
     			{
		    		this.m_E_MonsterItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RightBG/E_MonsterItems");
     			}
     			return this.m_E_MonsterItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MonsterItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MonsterItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RightBG/E_MonsterItems");
     			}
     			return this.m_E_MonsterItemsLoopVerticalScrollRect;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_RightBG/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_RightBG/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RightBG/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.UI.Button E_ReceiveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceiveButton == null )
     			{
		    		this.m_E_ReceiveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_RightBG/E_Receive");
     			}
     			return this.m_E_ReceiveButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReceiveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceiveImage == null )
     			{
		    		this.m_E_ReceiveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RightBG/E_Receive");
     			}
     			return this.m_E_ReceiveImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ReceivedRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ReceivedRectTransform == null )
     			{
		    		this.m_EG_ReceivedRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_RightBG/EG_Received");
     			}
     			return this.m_EG_ReceivedRectTransform;
     		}
     	}

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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SectionSetToggleGroup = null;
			this.m_E_PetMeleeLevelItemsImage = null;
			this.m_E_PetMeleeLevelItemsLoopVerticalScrollRect = null;
			this.m_E_PetMeleeButton = null;
			this.m_E_PetMeleeImage = null;
			this.m_E_RewardProgressImage = null;
			this.m_E_Reward1EventTrigger = null;
			this.m_E_Reward2EventTrigger = null;
			this.m_E_Reward3EventTrigger = null;
			this.m_E_Reward4EventTrigger = null;
			this.m_E_RightBGImage = null;
			this.m_E_LevelNameText = null;
			this.m_E_LevelDesText = null;
			this.m_E_MonsterItemsImage = null;
			this.m_E_MonsterItemsLoopVerticalScrollRect = null;
			this.m_es_rewardlist = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_E_ReceiveButton = null;
			this.m_E_ReceiveImage = null;
			this.m_EG_ReceivedRectTransform = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_SectionSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_PetMeleeLevelItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetMeleeLevelItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_PetMeleeButton = null;
		private UnityEngine.UI.Image m_E_PetMeleeImage = null;
		private UnityEngine.UI.Image m_E_RewardProgressImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward1EventTrigger = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward2EventTrigger = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward3EventTrigger = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward4EventTrigger = null;
		private UnityEngine.UI.Image m_E_RightBGImage = null;
		private UnityEngine.UI.Text m_E_LevelNameText = null;
		private UnityEngine.UI.Text m_E_LevelDesText = null;
		private UnityEngine.UI.Image m_E_MonsterItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MonsterItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.UI.Button m_E_ReceiveButton = null;
		private UnityEngine.UI.Image m_E_ReceiveImage = null;
		private UnityEngine.RectTransform m_EG_ReceivedRectTransform = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		public Transform uiTransform = null;
	}
}
