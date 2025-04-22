using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMail))]
	[EnableMethod]
	public  class DlgMailViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public Text E_NoMailText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoMailText == null )
     			{
		    		this.m_E_NoMailText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NoMail");
     			}
     			return this.m_E_NoMailText;
     		}
     	}

		public Button E_ButtonOneKeyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOneKeyButton == null )
     			{
		    		this.m_E_ButtonOneKeyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonOneKey");
     			}
     			return this.m_E_ButtonOneKeyButton;
     		}
     	}

		public Image E_ButtonOneKeyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOneKeyImage == null )
     			{
		    		this.m_E_ButtonOneKeyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonOneKey");
     			}
     			return this.m_E_ButtonOneKeyImage;
     		}
     	}

		public Text E_NumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NumTextText == null )
     			{
		    		this.m_E_NumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_NumText");
     			}
     			return this.m_E_NumTextText;
     		}
     	}

		public LoopVerticalScrollRect E_MailItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MailItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_MailItems");
     			}
     			return this.m_E_MailItemsLoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_MailContentRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MailContentRectTransform == null )
     			{
		    		this.m_EG_MailContentRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_MailContent");
     			}
     			return this.m_EG_MailContentRectTransform;
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_MailContent/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Text E_TextMailTitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextMailTitleText == null )
     			{
		    		this.m_E_TextMailTitleText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_MailContent/E_TextMailTitle");
     			}
     			return this.m_E_TextMailTitleText;
     		}
     	}

		public Text E_TextMailContentText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextMailContentText == null )
     			{
		    		this.m_E_TextMailContentText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_MailContent/E_TextMailContent");
     			}
     			return this.m_E_TextMailContentText;
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_MailContent/E_ButtonGet");
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_MailContent/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
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
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_NoMailText = null;
			this.m_E_ButtonOneKeyButton = null;
			this.m_E_ButtonOneKeyImage = null;
			this.m_E_NumTextText = null;
			this.m_E_MailItemsLoopVerticalScrollRect = null;
			this.m_EG_MailContentRectTransform = null;
			this.m_es_rewardlist = null;
			this.m_E_TextMailTitleText = null;
			this.m_E_TextMailContentText = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private Text m_E_NoMailText = null;
		private Button m_E_ButtonOneKeyButton = null;
		private Image m_E_ButtonOneKeyImage = null;
		private Text m_E_NumTextText = null;
		private LoopVerticalScrollRect m_E_MailItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_MailContentRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Text m_E_TextMailTitleText = null;
		private Text m_E_TextMailContentText = null;
		private Button m_E_ButtonGetButton = null;
		private Image m_E_ButtonGetImage = null;
		public Transform uiTransform = null;
	}
}
