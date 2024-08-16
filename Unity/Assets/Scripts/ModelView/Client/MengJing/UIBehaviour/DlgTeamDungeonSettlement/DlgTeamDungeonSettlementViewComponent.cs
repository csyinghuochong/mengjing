using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamDungeonSettlement))]
	[EnableMethod]
	public  class DlgTeamDungeonSettlementViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Img_back2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_back2Button == null )
     			{
		    		this.m_E_Img_back2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Img_back2");
     			}
     			return this.m_E_Img_back2Button;
     		}
     	}

		public Image E_Img_back2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_back2Image == null )
     			{
		    		this.m_E_Img_back2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_back2");
     			}
     			return this.m_E_Img_back2Image;
     		}
     	}

		public RectTransform EG_SelectEffectSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectEffectSetRectTransform == null )
     			{
		    		this.m_EG_SelectEffectSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SelectEffectSet");
     			}
     			return this.m_EG_SelectEffectSetRectTransform;
     		}
     	}

		public Button E_Button_exitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_exitButton == null )
     			{
		    		this.m_E_Button_exitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_exit");
     			}
     			return this.m_E_Button_exitButton;
     		}
     	}

		public Image E_Button_exitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_exitImage == null )
     			{
		    		this.m_E_Button_exitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_exit");
     			}
     			return this.m_E_Button_exitImage;
     		}
     	}

		public Text E_Text_LeftTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LeftTimeText == null )
     			{
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_LeftTime");
     			}
     			return this.m_E_Text_LeftTimeText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_back2Button = null;
			this.m_E_Img_back2Image = null;
			this.m_EG_SelectEffectSetRectTransform = null;
			this.m_E_Button_exitButton = null;
			this.m_E_Button_exitImage = null;
			this.m_E_Text_LeftTimeText = null;
			this.uiTransform = null;
		}

		private Button m_E_Img_back2Button = null;
		private Image m_E_Img_back2Image = null;
		private RectTransform m_EG_SelectEffectSetRectTransform = null;
		private Button m_E_Button_exitButton = null;
		private Image m_E_Button_exitImage = null;
		private Text m_E_Text_LeftTimeText = null;
		public Transform uiTransform = null;
	}
}
