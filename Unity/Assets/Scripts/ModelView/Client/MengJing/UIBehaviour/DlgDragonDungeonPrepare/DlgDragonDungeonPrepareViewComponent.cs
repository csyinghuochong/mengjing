
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDragonDungeonPrepare))]
	[EnableMethod]
	public  class DlgDragonDungeonPrepareViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_DragonPlayerItem0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DragonPlayerItem0RectTransform == null )
     			{
		    		this.m_EG_DragonPlayerItem0RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_DragonPlayerItem0");
     			}
     			return this.m_EG_DragonPlayerItem0RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_DragonPlayerItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DragonPlayerItem1RectTransform == null )
     			{
		    		this.m_EG_DragonPlayerItem1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_DragonPlayerItem1");
     			}
     			return this.m_EG_DragonPlayerItem1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_DragonPlayerItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DragonPlayerItem2RectTransform == null )
     			{
		    		this.m_EG_DragonPlayerItem2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_DragonPlayerItem2");
     			}
     			return this.m_EG_DragonPlayerItem2RectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextCountDownText
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
		    		this.m_E_TextCountDownText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_TextCountDown");
     			}
     			return this.m_E_TextCountDownText;
     		}
     	}

		public UnityEngine.UI.Button E_Button_AgreeButton
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
		    		this.m_E_Button_AgreeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Agree");
     			}
     			return this.m_E_Button_AgreeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_AgreeImage
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
		    		this.m_E_Button_AgreeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Agree");
     			}
     			return this.m_E_Button_AgreeImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RefuseButton
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
		    		this.m_E_Button_RefuseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Refuse");
     			}
     			return this.m_E_Button_RefuseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RefuseImage
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
		    		this.m_E_Button_RefuseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Refuse");
     			}
     			return this.m_E_Button_RefuseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_DragonPlayerItem0RectTransform = null;
			this.m_EG_DragonPlayerItem1RectTransform = null;
			this.m_EG_DragonPlayerItem2RectTransform = null;
			this.m_E_TextCountDownText = null;
			this.m_E_Button_AgreeButton = null;
			this.m_E_Button_AgreeImage = null;
			this.m_E_Button_RefuseButton = null;
			this.m_E_Button_RefuseImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_DragonPlayerItem0RectTransform = null;
		private UnityEngine.RectTransform m_EG_DragonPlayerItem1RectTransform = null;
		private UnityEngine.RectTransform m_EG_DragonPlayerItem2RectTransform = null;
		private UnityEngine.UI.Text m_E_TextCountDownText = null;
		private UnityEngine.UI.Button m_E_Button_AgreeButton = null;
		private UnityEngine.UI.Image m_E_Button_AgreeImage = null;
		private UnityEngine.UI.Button m_E_Button_RefuseButton = null;
		private UnityEngine.UI.Image m_E_Button_RefuseImage = null;
		public Transform uiTransform = null;
	}
}
