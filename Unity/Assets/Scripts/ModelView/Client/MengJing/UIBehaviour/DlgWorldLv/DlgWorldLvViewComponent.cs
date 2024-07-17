using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWorldLv))]
	[EnableMethod]
	public  class DlgWorldLvViewComponent : Entity,IAwake,IDestroy 
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

		public Button E_ButtonDiHuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDiHuanButton == null )
     			{
		    		this.m_E_ButtonDiHuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonDiHuan");
     			}
     			return this.m_E_ButtonDiHuanButton;
     		}
     	}

		public Image E_ButtonDiHuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDiHuanImage == null )
     			{
		    		this.m_E_ButtonDiHuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonDiHuan");
     			}
     			return this.m_E_ButtonDiHuanImage;
     		}
     	}

		public Text E_Lab_ExpRateText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ExpRateText == null )
     			{
		    		this.m_E_Lab_ExpRateText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ExpRate");
     			}
     			return this.m_E_Lab_ExpRateText;
     		}
     	}

		public Text E_Lab_ExpAddProText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ExpAddProText == null )
     			{
		    		this.m_E_Lab_ExpAddProText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ExpAddPro");
     			}
     			return this.m_E_Lab_ExpAddProText;
     		}
     	}

		public Text E_Text_WorldLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_WorldLvText == null )
     			{
		    		this.m_E_Text_WorldLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_WorldLv");
     			}
     			return this.m_E_Text_WorldLvText;
     		}
     	}

		public Text E_Lab_MyLv1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MyLv1Text == null )
     			{
		    		this.m_E_Lab_MyLv1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_MyLv1");
     			}
     			return this.m_E_Lab_MyLv1Text;
     		}
     	}

		public Text E_Lab_MyLv2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MyLv2Text == null )
     			{
		    		this.m_E_Lab_MyLv2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_MyLv2");
     			}
     			return this.m_E_Lab_MyLv2Text;
     		}
     	}

		public Text E_Lab_GanDiNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_GanDiNameText == null )
     			{
		    		this.m_E_Lab_GanDiNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_GanDiName");
     			}
     			return this.m_E_Lab_GanDiNameText;
     		}
     	}

		public Text E_Lab_DuiHuanTimesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_DuiHuanTimesText == null )
     			{
		    		this.m_E_Lab_DuiHuanTimesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_DuiHuanTimes");
     			}
     			return this.m_E_Lab_DuiHuanTimesText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_ButtonDiHuanButton = null;
			this.m_E_ButtonDiHuanImage = null;
			this.m_E_Lab_ExpRateText = null;
			this.m_E_Lab_ExpAddProText = null;
			this.m_E_Text_WorldLvText = null;
			this.m_E_Lab_MyLv1Text = null;
			this.m_E_Lab_MyLv2Text = null;
			this.m_E_Lab_GanDiNameText = null;
			this.m_E_Lab_DuiHuanTimesText = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private Button m_E_ButtonDiHuanButton = null;
		private Image m_E_ButtonDiHuanImage = null;
		private Text m_E_Lab_ExpRateText = null;
		private Text m_E_Lab_ExpAddProText = null;
		private Text m_E_Text_WorldLvText = null;
		private Text m_E_Lab_MyLv1Text = null;
		private Text m_E_Lab_MyLv2Text = null;
		private Text m_E_Lab_GanDiNameText = null;
		private Text m_E_Lab_DuiHuanTimesText = null;
		public Transform uiTransform = null;
	}
}
