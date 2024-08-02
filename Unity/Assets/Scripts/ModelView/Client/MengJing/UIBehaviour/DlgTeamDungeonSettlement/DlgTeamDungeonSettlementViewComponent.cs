
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamDungeonSettlement))]
	[EnableMethod]
	public  class DlgTeamDungeonSettlementViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Img_back2Button
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
		    		this.m_E_Img_back2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_back2");
     			}
     			return this.m_E_Img_back2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Img_back2Image
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
		    		this.m_E_Img_back2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_back2");
     			}
     			return this.m_E_Img_back2Image;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIconImage == null )
     			{
		    		this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"SettlementItemList/TeamDungeonSettlementPlayer/E_ImageIcon");
     			}
     			return this.m_E_ImageIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NameText == null )
     			{
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"SettlementItemList/TeamDungeonSettlementPlayer/E_Text_Name");
     			}
     			return this.m_E_Text_NameText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LevelText == null )
     			{
		    		this.m_E_Text_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"SettlementItemList/TeamDungeonSettlementPlayer/E_Text_Level");
     			}
     			return this.m_E_Text_LevelText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_DamageText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_DamageText == null )
     			{
		    		this.m_E_Text_DamageText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"SettlementItemList/TeamDungeonSettlementPlayer/E_Text_Damage");
     			}
     			return this.m_E_Text_DamageText;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectEffectSetRectTransform
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
		    		this.m_EG_SelectEffectSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SelectEffectSet");
     			}
     			return this.m_EG_SelectEffectSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_exitButton
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
		    		this.m_E_Button_exitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_exit");
     			}
     			return this.m_E_Button_exitButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_exitImage
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
		    		this.m_E_Button_exitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_exit");
     			}
     			return this.m_E_Button_exitImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeftTimeText
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
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_LeftTime");
     			}
     			return this.m_E_Text_LeftTimeText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_back2Button = null;
			this.m_E_Img_back2Image = null;
			this.m_E_ImageIconImage = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_LevelText = null;
			this.m_E_Text_DamageText = null;
			this.m_EG_SelectEffectSetRectTransform = null;
			this.m_E_Button_exitButton = null;
			this.m_E_Button_exitImage = null;
			this.m_E_Text_LeftTimeText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Img_back2Button = null;
		private UnityEngine.UI.Image m_E_Img_back2Image = null;
		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_LevelText = null;
		private UnityEngine.UI.Text m_E_Text_DamageText = null;
		private UnityEngine.RectTransform m_EG_SelectEffectSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Button_exitButton = null;
		private UnityEngine.UI.Image m_E_Button_exitImage = null;
		private UnityEngine.UI.Text m_E_Text_LeftTimeText = null;
		public Transform uiTransform = null;
	}
}
