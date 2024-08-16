using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamDungeonPrepare))]
	[EnableMethod]
	public  class DlgTeamDungeonPrepareViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_TeamPlayerItem0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TeamPlayerItem0RectTransform == null )
     			{
		    		this.m_EG_TeamPlayerItem0RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_TeamPlayerItem0");
     			}
     			return this.m_EG_TeamPlayerItem0RectTransform;
     		}
     	}

		public RectTransform EG_TeamPlayerItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TeamPlayerItem1RectTransform == null )
     			{
		    		this.m_EG_TeamPlayerItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_TeamPlayerItem1");
     			}
     			return this.m_EG_TeamPlayerItem1RectTransform;
     		}
     	}

		public RectTransform EG_TeamPlayerItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TeamPlayerItem2RectTransform == null )
     			{
		    		this.m_EG_TeamPlayerItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_TeamPlayerItem2");
     			}
     			return this.m_EG_TeamPlayerItem2RectTransform;
     		}
     	}

		public Text E_TextCountDownText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextCountDownText == null )
     			{
		    		this.m_E_TextCountDownText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextCountDown");
     			}
     			return this.m_E_TextCountDownText;
     		}
     	}

		public Button E_Button_AgreeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AgreeButton == null )
     			{
		    		this.m_E_Button_AgreeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Agree");
     			}
     			return this.m_E_Button_AgreeButton;
     		}
     	}

		public Image E_Button_AgreeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AgreeImage == null )
     			{
		    		this.m_E_Button_AgreeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Agree");
     			}
     			return this.m_E_Button_AgreeImage;
     		}
     	}

		public Button E_Button_RefuseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RefuseButton == null )
     			{
		    		this.m_E_Button_RefuseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Refuse");
     			}
     			return this.m_E_Button_RefuseButton;
     		}
     	}

		public Image E_Button_RefuseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RefuseImage == null )
     			{
		    		this.m_E_Button_RefuseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Refuse");
     			}
     			return this.m_E_Button_RefuseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_TeamPlayerItem0RectTransform = null;
			this.m_EG_TeamPlayerItem1RectTransform = null;
			this.m_EG_TeamPlayerItem2RectTransform = null;
			this.m_E_TextCountDownText = null;
			this.m_E_Button_AgreeButton = null;
			this.m_E_Button_AgreeImage = null;
			this.m_E_Button_RefuseButton = null;
			this.m_E_Button_RefuseImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_TeamPlayerItem0RectTransform = null;
		private RectTransform m_EG_TeamPlayerItem1RectTransform = null;
		private RectTransform m_EG_TeamPlayerItem2RectTransform = null;
		private Text m_E_TextCountDownText = null;
		private Button m_E_Button_AgreeButton = null;
		private Image m_E_Button_AgreeImage = null;
		private Button m_E_Button_RefuseButton = null;
		private Image m_E_Button_RefuseImage = null;
		public Transform uiTransform = null;
	}
}
