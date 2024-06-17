
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMail))]
	[EnableMethod]
	public  class DlgMailViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_CloseButton
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.UI.Text E_NoMailText
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
		    		this.m_E_NoMailText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NoMail");
     			}
     			return this.m_E_NoMailText;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOneKeyButton
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
		    		this.m_E_ButtonOneKeyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonOneKey");
     			}
     			return this.m_E_ButtonOneKeyButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOneKeyImage
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
		    		this.m_E_ButtonOneKeyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonOneKey");
     			}
     			return this.m_E_ButtonOneKeyImage;
     		}
     	}

		public UnityEngine.UI.Text E_NumTextText
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
		    		this.m_E_NumTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_NumText");
     			}
     			return this.m_E_NumTextText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MailItemsLoopVerticalScrollRect
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
		    		this.m_E_MailItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_MailItems");
     			}
     			return this.m_E_MailItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_MailContentRectTransform
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
		    		this.m_EG_MailContentRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_MailContent");
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
     			if( this.m_es_rewardlist .Equals(null) )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_MailContent/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Text E_TextMailTitleText
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
		    		this.m_E_TextMailTitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_MailContent/E_TextMailTitle");
     			}
     			return this.m_E_TextMailTitleText;
     		}
     	}

		public UnityEngine.UI.Text E_TextMailContentText
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
		    		this.m_E_TextMailContentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_MailContent/E_TextMailContent");
     			}
     			return this.m_E_TextMailContentText;
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_MailContent/E_ButtonGet");
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_MailContent/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
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

		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.UI.Text m_E_NoMailText = null;
		private UnityEngine.UI.Button m_E_ButtonOneKeyButton = null;
		private UnityEngine.UI.Image m_E_ButtonOneKeyImage = null;
		private UnityEngine.UI.Text m_E_NumTextText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MailItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_MailContentRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Text m_E_TextMailTitleText = null;
		private UnityEngine.UI.Text m_E_TextMailContentText = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		public Transform uiTransform = null;
	}
}
