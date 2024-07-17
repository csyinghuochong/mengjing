using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgLSRoom))]
	[EnableMethod]
	public  class DlgLSRoomViewComponent : Entity,IAwake,IDestroy 
	{
		public Text EprogressText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EprogressText == null )
     			{
		    		this.m_EprogressText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Panel/Eprogress");
     			}
     			return this.m_EprogressText;
     		}
     	}

		public Text EpredictText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EpredictText == null )
     			{
		    		this.m_EpredictText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Panel/Epredict");
     			}
     			return this.m_EpredictText;
     		}
     	}

		public Text EframecountText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EframecountText == null )
     			{
		    		this.m_EframecountText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Panel/Eframecount");
     			}
     			return this.m_EframecountText;
     		}
     	}

		public RectTransform EGReplayRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGReplayRectTransform == null )
     			{
		    		this.m_EGReplayRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Panel/EGReplay");
     			}
     			return this.m_EGReplayRectTransform;
     		}
     	}

		public InputField EjumpToCountInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EjumpToCountInputField == null )
     			{
		    		this.m_EjumpToCountInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Panel/EGReplay/EjumpToCount");
     			}
     			return this.m_EjumpToCountInputField;
     		}
     	}

		public Image EjumpToCountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EjumpToCountImage == null )
     			{
		    		this.m_EjumpToCountImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EGReplay/EjumpToCount");
     			}
     			return this.m_EjumpToCountImage;
     		}
     	}

		public Button EjumpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EjumpButton == null )
     			{
		    		this.m_EjumpButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Panel/EGReplay/Ejump");
     			}
     			return this.m_EjumpButton;
     		}
     	}

		public Image EjumpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EjumpImage == null )
     			{
		    		this.m_EjumpImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EGReplay/Ejump");
     			}
     			return this.m_EjumpImage;
     		}
     	}

		public Button EspeedButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EspeedButton == null )
     			{
		    		this.m_EspeedButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Panel/EGReplay/Espeed");
     			}
     			return this.m_EspeedButton;
     		}
     	}

		public Image EspeedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EspeedImage == null )
     			{
		    		this.m_EspeedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EGReplay/Espeed");
     			}
     			return this.m_EspeedImage;
     		}
     	}

		public RectTransform EGPlayRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGPlayRectTransform == null )
     			{
		    		this.m_EGPlayRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Panel/EGPlay");
     			}
     			return this.m_EGPlayRectTransform;
     		}
     	}

		public InputField E_SaveNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveNameInputField == null )
     			{
		    		this.m_E_SaveNameInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Panel/EGPlay/E_SaveName");
     			}
     			return this.m_E_SaveNameInputField;
     		}
     	}

		public Image E_SaveNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveNameImage == null )
     			{
		    		this.m_E_SaveNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EGPlay/E_SaveName");
     			}
     			return this.m_E_SaveNameImage;
     		}
     	}

		public Button E_SaveReplayButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveReplayButton == null )
     			{
		    		this.m_E_SaveReplayButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Panel/EGPlay/E_SaveReplay");
     			}
     			return this.m_E_SaveReplayButton;
     		}
     	}

		public Image E_SaveReplayImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveReplayImage == null )
     			{
		    		this.m_E_SaveReplayImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EGPlay/E_SaveReplay");
     			}
     			return this.m_E_SaveReplayImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EprogressText = null;
			this.m_EpredictText = null;
			this.m_EframecountText = null;
			this.m_EGReplayRectTransform = null;
			this.m_EjumpToCountInputField = null;
			this.m_EjumpToCountImage = null;
			this.m_EjumpButton = null;
			this.m_EjumpImage = null;
			this.m_EspeedButton = null;
			this.m_EspeedImage = null;
			this.m_EGPlayRectTransform = null;
			this.m_E_SaveNameInputField = null;
			this.m_E_SaveNameImage = null;
			this.m_E_SaveReplayButton = null;
			this.m_E_SaveReplayImage = null;
			this.uiTransform = null;
		}

		private Text m_EprogressText = null;
		private Text m_EpredictText = null;
		private Text m_EframecountText = null;
		private RectTransform m_EGReplayRectTransform = null;
		private InputField m_EjumpToCountInputField = null;
		private Image m_EjumpToCountImage = null;
		private Button m_EjumpButton = null;
		private Image m_EjumpImage = null;
		private Button m_EspeedButton = null;
		private Image m_EspeedImage = null;
		private RectTransform m_EGPlayRectTransform = null;
		private InputField m_E_SaveNameInputField = null;
		private Image m_E_SaveNameImage = null;
		private Button m_E_SaveReplayButton = null;
		private Image m_E_SaveReplayImage = null;
		public Transform uiTransform = null;
	}
}
