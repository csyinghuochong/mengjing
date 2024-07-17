using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMiningChallenge))]
	[EnableMethod]
	public  class DlgPetMiningChallengeViewComponent : Entity,IAwake,IDestroy 
	{
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

		public Button E_ButtonConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonConfirmButton == null )
     			{
		    		this.m_E_ButtonConfirmButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmButton;
     		}
     	}

		public Image E_ButtonConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonConfirmImage == null )
     			{
		    		this.m_E_ButtonConfirmImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmImage;
     		}
     	}

		public Button E_ButtonResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetButton == null )
     			{
		    		this.m_E_ButtonResetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonReset");
     			}
     			return this.m_E_ButtonResetButton;
     		}
     	}

		public Image E_ButtonResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetImage == null )
     			{
		    		this.m_E_ButtonResetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonReset");
     			}
     			return this.m_E_ButtonResetImage;
     		}
     	}

		public RectTransform EG_TeamListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TeamListNodeRectTransform == null )
     			{
		    		this.m_EG_TeamListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_TeamListNode");
     			}
     			return this.m_EG_TeamListNodeRectTransform;
     		}
     	}

		public RectTransform EG_DefendTeamRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DefendTeamRectTransform == null )
     			{
		    		this.m_EG_DefendTeamRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_DefendTeam");
     			}
     			return this.m_EG_DefendTeamRectTransform;
     		}
     	}

		public Image E_RawImageImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RawImageImage == null )
     			{
		    		this.m_E_RawImageImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RawImage");
     			}
     			return this.m_E_RawImageImage;
     		}
     	}

		public Text E_Text_mingText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_mingText == null )
     			{
		    		this.m_E_Text_mingText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_ming");
     			}
     			return this.m_E_Text_mingText;
     		}
     	}

		public Text E_Text_playerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_playerText == null )
     			{
		    		this.m_E_Text_playerText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_player");
     			}
     			return this.m_E_Text_playerText;
     		}
     	}

		public Text E_Text_chanchuText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_chanchuText == null )
     			{
		    		this.m_E_Text_chanchuText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_chanchu");
     			}
     			return this.m_E_Text_chanchuText;
     		}
     	}

		public Text E_TextChallengeCDText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextChallengeCDText == null )
     			{
		    		this.m_E_TextChallengeCDText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextChallengeCD");
     			}
     			return this.m_E_TextChallengeCDText;
     		}
     	}

		public Text E_TextChallengeTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextChallengeTimeText == null )
     			{
		    		this.m_E_TextChallengeTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextChallengeTime");
     			}
     			return this.m_E_TextChallengeTimeText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_ButtonConfirmButton = null;
			this.m_E_ButtonConfirmImage = null;
			this.m_E_ButtonResetButton = null;
			this.m_E_ButtonResetImage = null;
			this.m_EG_TeamListNodeRectTransform = null;
			this.m_EG_DefendTeamRectTransform = null;
			this.m_E_RawImageImage = null;
			this.m_E_Text_mingText = null;
			this.m_E_Text_playerText = null;
			this.m_E_Text_chanchuText = null;
			this.m_E_TextChallengeCDText = null;
			this.m_E_TextChallengeTimeText = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private Button m_E_ButtonConfirmButton = null;
		private Image m_E_ButtonConfirmImage = null;
		private Button m_E_ButtonResetButton = null;
		private Image m_E_ButtonResetImage = null;
		private RectTransform m_EG_TeamListNodeRectTransform = null;
		private RectTransform m_EG_DefendTeamRectTransform = null;
		private Image m_E_RawImageImage = null;
		private Text m_E_Text_mingText = null;
		private Text m_E_Text_playerText = null;
		private Text m_E_Text_chanchuText = null;
		private Text m_E_TextChallengeCDText = null;
		private Text m_E_TextChallengeTimeText = null;
		public Transform uiTransform = null;
	}
}
