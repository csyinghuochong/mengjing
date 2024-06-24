
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMiningChallenge))]
	[EnableMethod]
	public  class DlgPetMiningChallengeViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonCloseButton
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseImage
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonConfirmButton
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
		    		this.m_E_ButtonConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonConfirmImage
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
		    		this.m_E_ButtonConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonResetButton
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
		    		this.m_E_ButtonResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonReset");
     			}
     			return this.m_E_ButtonResetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonResetImage
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
		    		this.m_E_ButtonResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonReset");
     			}
     			return this.m_E_ButtonResetImage;
     		}
     	}

		public UnityEngine.RectTransform EG_DefendTeamRectTransform
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
		    		this.m_EG_DefendTeamRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_DefendTeam");
     			}
     			return this.m_EG_DefendTeamRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_RawImageImage
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
		    		this.m_E_RawImageImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RawImage");
     			}
     			return this.m_E_RawImageImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_mingText
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
		    		this.m_E_Text_mingText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_ming");
     			}
     			return this.m_E_Text_mingText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_playerText
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
		    		this.m_E_Text_playerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_player");
     			}
     			return this.m_E_Text_playerText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_chanchuText
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
		    		this.m_E_Text_chanchuText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_chanchu");
     			}
     			return this.m_E_Text_chanchuText;
     		}
     	}

		public UnityEngine.UI.Text E_TextChallengeCDText
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
		    		this.m_E_TextChallengeCDText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextChallengeCD");
     			}
     			return this.m_E_TextChallengeCDText;
     		}
     	}

		public UnityEngine.UI.Text E_TextChallengeTimeText
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
		    		this.m_E_TextChallengeTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextChallengeTime");
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
			this.m_EG_DefendTeamRectTransform = null;
			this.m_E_RawImageImage = null;
			this.m_E_Text_mingText = null;
			this.m_E_Text_playerText = null;
			this.m_E_Text_chanchuText = null;
			this.m_E_TextChallengeCDText = null;
			this.m_E_TextChallengeTimeText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.UI.Button m_E_ButtonConfirmButton = null;
		private UnityEngine.UI.Image m_E_ButtonConfirmImage = null;
		private UnityEngine.UI.Button m_E_ButtonResetButton = null;
		private UnityEngine.UI.Image m_E_ButtonResetImage = null;
		private UnityEngine.RectTransform m_EG_DefendTeamRectTransform = null;
		private UnityEngine.UI.Image m_E_RawImageImage = null;
		private UnityEngine.UI.Text m_E_Text_mingText = null;
		private UnityEngine.UI.Text m_E_Text_playerText = null;
		private UnityEngine.UI.Text m_E_Text_chanchuText = null;
		private UnityEngine.UI.Text m_E_TextChallengeCDText = null;
		private UnityEngine.UI.Text m_E_TextChallengeTimeText = null;
		public Transform uiTransform = null;
	}
}
