using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRechargeReward))]
	[EnableMethod]
	public  class DlgRechargeRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_ButtonRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRewardButton == null )
     			{
		    		this.m_E_ButtonRewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonReward");
     			}
     			return this.m_E_ButtonRewardButton;
     		}
     	}

		public Image E_ButtonRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRewardImage == null )
     			{
		    		this.m_E_ButtonRewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonReward");
     			}
     			return this.m_E_ButtonRewardImage;
     		}
     	}

		public Button E_ButtonGoToPayButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGoToPayButton == null )
     			{
		    		this.m_E_ButtonGoToPayButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonGoToPay");
     			}
     			return this.m_E_ButtonGoToPayButton;
     		}
     	}

		public Image E_ButtonGoToPayImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGoToPayImage == null )
     			{
		    		this.m_E_ButtonGoToPayImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonGoToPay");
     			}
     			return this.m_E_ButtonGoToPayImage;
     		}
     	}

		public Image E_ImageReceivedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageReceivedImage == null )
     			{
		    		this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageReceived");
     			}
     			return this.m_E_ImageReceivedImage;
     		}
     	}

		public Text E_TextTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTipText == null )
     			{
		    		this.m_E_TextTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextTip");
     			}
     			return this.m_E_TextTipText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonRewardButton = null;
			this.m_E_ButtonRewardImage = null;
			this.m_E_ButtonGoToPayButton = null;
			this.m_E_ButtonGoToPayImage = null;
			this.m_E_ImageReceivedImage = null;
			this.m_E_TextTipText = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ButtonRewardButton = null;
		private Image m_E_ButtonRewardImage = null;
		private Button m_E_ButtonGoToPayButton = null;
		private Image m_E_ButtonGoToPayImage = null;
		private Image m_E_ImageReceivedImage = null;
		private Text m_E_TextTipText = null;
		public Transform uiTransform = null;
	}
}
