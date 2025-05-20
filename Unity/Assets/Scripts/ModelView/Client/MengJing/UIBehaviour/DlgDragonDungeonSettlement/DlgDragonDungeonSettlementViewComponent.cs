
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDragonDungeonSettlement))]
	[EnableMethod]
	public  class DlgDragonDungeonSettlementViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_E_Img_back2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Img_back2");
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
		    		this.m_E_Img_back2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Img_back2");
     			}
     			return this.m_E_Img_back2Image;
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
		    		this.m_EG_SelectEffectSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_SelectEffectSet");
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
		    		this.m_E_Button_exitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_exit");
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
		    		this.m_E_Button_exitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_exit");
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
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_LeftTime");
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

		private UnityEngine.UI.Button m_E_Img_back2Button = null;
		private UnityEngine.UI.Image m_E_Img_back2Image = null;
		private UnityEngine.RectTransform m_EG_SelectEffectSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Button_exitButton = null;
		private UnityEngine.UI.Image m_E_Button_exitImage = null;
		private UnityEngine.UI.Text m_E_Text_LeftTimeText = null;
		public Transform uiTransform = null;
	}
}
