using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SettingGame : Entity,IAwake<Transform>,IDestroy 
	{
		public UserInfoComponentC UserInfoComponent { get; set; }
		public List<KeyValuePair> GameSettingInfos = new();
		
		public Image E_HideDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HideDiImage == null )
     			{
		    		this.m_E_HideDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HideDi");
     			}
     			return this.m_E_HideDiImage;
     		}
     	}

		public Button E_ButtonSkillSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSkillSetButton == null )
     			{
		    		this.m_E_ButtonSkillSetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonSkillSet");
     			}
     			return this.m_E_ButtonSkillSetButton;
     		}
     	}

		public Image E_ButtonSkillSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSkillSetImage == null )
     			{
		    		this.m_E_ButtonSkillSetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonSkillSet");
     			}
     			return this.m_E_ButtonSkillSetImage;
     		}
     	}

		public Button E_Btn_CloseGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseGameButton == null )
     			{
		    		this.m_E_Btn_CloseGameButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_CloseGame");
     			}
     			return this.m_E_Btn_CloseGameButton;
     		}
     	}

		public Image E_Btn_CloseGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseGameImage == null )
     			{
		    		this.m_E_Btn_CloseGameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_CloseGame");
     			}
     			return this.m_E_Btn_CloseGameImage;
     		}
     	}

		public Button E_Btn_ReturnDengLuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReturnDengLuButton == null )
     			{
		    		this.m_E_Btn_ReturnDengLuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ReturnDengLu");
     			}
     			return this.m_E_Btn_ReturnDengLuButton;
     		}
     	}

		public Image E_Btn_ReturnDengLuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReturnDengLuImage == null )
     			{
		    		this.m_E_Btn_ReturnDengLuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ReturnDengLu");
     			}
     			return this.m_E_Btn_ReturnDengLuImage;
     		}
     	}

		public Text E_TextVersionText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextVersionText == null )
     			{
		    		this.m_E_TextVersionText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"BanBenHao/E_TextVersion");
     			}
     			return this.m_E_TextVersionText;
     		}
     	}

		public Text E_LastLoginTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LastLoginTimeText == null )
     			{
		    		this.m_E_LastLoginTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"DengLuTime/E_LastLoginTime");
     			}
     			return this.m_E_LastLoginTimeText;
     		}
     	}

		public InputField E_InputFieldCNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldCNameInputField == null )
     			{
		    		this.m_E_InputFieldCNameInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_InputFieldCName");
     			}
     			return this.m_E_InputFieldCNameInputField;
     		}
     	}

		public Image E_InputFieldCNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldCNameImage == null )
     			{
		    		this.m_E_InputFieldCNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_InputFieldCName");
     			}
     			return this.m_E_InputFieldCNameImage;
     		}
     	}

		public Button E_ButtonRnameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRnameButton == null )
     			{
		    		this.m_E_ButtonRnameButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonRname");
     			}
     			return this.m_E_ButtonRnameButton;
     		}
     	}

		public Image E_ButtonRnameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRnameImage == null )
     			{
		    		this.m_E_ButtonRnameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonRname");
     			}
     			return this.m_E_ButtonRnameImage;
     		}
     	}

		public Button E_ButtonPhoneButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPhoneButton == null )
     			{
		    		this.m_E_ButtonPhoneButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonPhone");
     			}
     			return this.m_E_ButtonPhoneButton;
     		}
     	}

		public Image E_ButtonPhoneImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPhoneImage == null )
     			{
		    		this.m_E_ButtonPhoneImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonPhone");
     			}
     			return this.m_E_ButtonPhoneImage;
     		}
     	}

		public Button E_Btn_FixedButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FixedButton == null )
     			{
		    		this.m_E_Btn_FixedButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGanSet/E_Btn_Fixed");
     			}
     			return this.m_E_Btn_FixedButton;
     		}
     	}

		public Image E_Btn_FixedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FixedImage == null )
     			{
		    		this.m_E_Btn_FixedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGanSet/E_Btn_Fixed");
     			}
     			return this.m_E_Btn_FixedImage;
     		}
     	}

		public Image E_Image_FixedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_FixedImage == null )
     			{
		    		this.m_E_Image_FixedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGanSet/E_Image_Fixed");
     			}
     			return this.m_E_Image_FixedImage;
     		}
     	}

		public Button E_Btn_YinYueButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_YinYueButton == null )
     			{
		    		this.m_E_Btn_YinYueButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_YinYue");
     			}
     			return this.m_E_Btn_YinYueButton;
     		}
     	}

		public Image E_Btn_YinYueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_YinYueImage == null )
     			{
		    		this.m_E_Btn_YinYueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_YinYue");
     			}
     			return this.m_E_Btn_YinYueImage;
     		}
     	}

		public Image E_Image_yinyuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_yinyuImage == null )
     			{
		    		this.m_E_Image_yinyuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Image_yinyu");
     			}
     			return this.m_E_Image_yinyuImage;
     		}
     	}

		public Button E_Btn_SoundButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SoundButton == null )
     			{
		    		this.m_E_Btn_SoundButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_Sound");
     			}
     			return this.m_E_Btn_SoundButton;
     		}
     	}

		public Image E_Btn_SoundImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SoundImage == null )
     			{
		    		this.m_E_Btn_SoundImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_Sound");
     			}
     			return this.m_E_Btn_SoundImage;
     		}
     	}

		public Image E_Image_SoundImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_SoundImage == null )
     			{
		    		this.m_E_Image_SoundImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Image_Sound");
     			}
     			return this.m_E_Image_SoundImage;
     		}
     	}

		public Slider E_SliderMusicSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SliderMusicSlider == null )
     			{
		    		this.m_E_SliderMusicSlider = UIFindHelper.FindDeepChild<Slider>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_SliderMusic");
     			}
     			return this.m_E_SliderMusicSlider;
     		}
     	}

		public Slider E_SliderSoundSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SliderSoundSlider == null )
     			{
		    		this.m_E_SliderSoundSlider = UIFindHelper.FindDeepChild<Slider>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_SliderSound");
     			}
     			return this.m_E_SliderSoundSlider;
     		}
     	}

		public Button E_Btn_FpsButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FpsButton == null )
     			{
		    		this.m_E_Btn_FpsButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/Fps/E_Btn_Fps");
     			}
     			return this.m_E_Btn_FpsButton;
     		}
     	}

		public Image E_Btn_FpsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FpsImage == null )
     			{
		    		this.m_E_Btn_FpsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/Fps/E_Btn_Fps");
     			}
     			return this.m_E_Btn_FpsImage;
     		}
     	}

		public Image E_Image_fpsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_fpsImage == null )
     			{
		    		this.m_E_Image_fpsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/Fps/E_Image_fps");
     			}
     			return this.m_E_Image_fpsImage;
     		}
     	}

		public Button E_Btn_ClickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ClickButton == null )
     			{
		    		this.m_E_Btn_ClickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGan/E_Btn_Click");
     			}
     			return this.m_E_Btn_ClickButton;
     		}
     	}

		public Image E_Btn_ClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ClickImage == null )
     			{
		    		this.m_E_Btn_ClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGan/E_Btn_Click");
     			}
     			return this.m_E_Btn_ClickImage;
     		}
     	}

		public Image E_Image_ClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_ClickImage == null )
     			{
		    		this.m_E_Image_ClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGan/E_Image_Click");
     			}
     			return this.m_E_Image_ClickImage;
     		}
     	}

		public RectTransform EG_HighFpsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HighFpsRectTransform == null )
     			{
		    		this.m_EG_HighFpsRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_HighFps");
     			}
     			return this.m_EG_HighFpsRectTransform;
     		}
     	}

		public RectTransform EG_SmoothRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SmoothRectTransform == null )
     			{
		    		this.m_EG_SmoothRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_Smooth");
     			}
     			return this.m_EG_SmoothRectTransform;
     		}
     	}

		public Toggle E_ScreenToggle0Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScreenToggle0Toggle == null )
     			{
		    		this.m_E_ScreenToggle0Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/ToggleGroup/E_ScreenToggle0");
     			}
     			return this.m_E_ScreenToggle0Toggle;
     		}
     	}

		public Toggle E_ScreenToggle1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScreenToggle1Toggle == null )
     			{
		    		this.m_E_ScreenToggle1Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/ToggleGroup/E_ScreenToggle1");
     			}
     			return this.m_E_ScreenToggle1Toggle;
     		}
     	}

		public Button E_Btn_YinYingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_YinYingButton == null )
     			{
		    		this.m_E_Btn_YinYingButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_YinYing/E_Btn_YinYing");
     			}
     			return this.m_E_Btn_YinYingButton;
     		}
     	}

		public Image E_Btn_YinYingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_YinYingImage == null )
     			{
		    		this.m_E_Btn_YinYingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YinYing/E_Btn_YinYing");
     			}
     			return this.m_E_Btn_YinYingImage;
     		}
     	}

		public Image E_Image_YinYingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_YinYingImage == null )
     			{
		    		this.m_E_Image_YinYingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_YinYing/E_Image_YinYing");
     			}
     			return this.m_E_Image_YinYingImage;
     		}
     	}

		public RectTransform EG_RandomHoreseRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RandomHoreseRectTransform == null )
     			{
		    		this.m_EG_RandomHoreseRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_RandomHorese");
     			}
     			return this.m_EG_RandomHoreseRectTransform;
     		}
     	}

		public RectTransform EG_OneSellSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OneSellSetRectTransform == null )
     			{
		    		this.m_EG_OneSellSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_OneSellSet");
     			}
     			return this.m_EG_OneSellSetRectTransform;
     		}
     	}

		public RectTransform EG_ActTypeSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ActTypeSetRectTransform == null )
     			{
		    		this.m_EG_ActTypeSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_ActTypeSet");
     			}
     			return this.m_EG_ActTypeSetRectTransform;
     		}
     	}

		public RectTransform EG_ActTargetSelectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ActTargetSelectRectTransform == null )
     			{
		    		this.m_EG_ActTargetSelectRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_ActTargetSelect");
     			}
     			return this.m_EG_ActTargetSelectRectTransform;
     		}
     	}

		public RectTransform EG_NoShowOtherRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_NoShowOtherRectTransform == null )
     			{
		    		this.m_EG_NoShowOtherRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_NoShowOther");
     			}
     			return this.m_EG_NoShowOtherRectTransform;
     		}
     	}

		public RectTransform EG_AutoAttackRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AutoAttackRectTransform == null )
     			{
		    		this.m_EG_AutoAttackRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_AutoAttack");
     			}
     			return this.m_EG_AutoAttackRectTransform;
     		}
     	}

		public RectTransform EG_HideLeftBottomRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HideLeftBottomRectTransform == null )
     			{
		    		this.m_EG_HideLeftBottomRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_HideLeftBottom");
     			}
     			return this.m_EG_HideLeftBottomRectTransform;
     		}
     	}

		public RectTransform EG_FirstUnionNameRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FirstUnionNameRectTransform == null )
     			{
		    		this.m_EG_FirstUnionNameRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_FirstUnionName");
     			}
     			return this.m_EG_FirstUnionNameRectTransform;
     		}
     	}

		public RectTransform EG_SkillAttackPlayerFirstRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillAttackPlayerFirstRectTransform == null )
     			{
		    		this.m_EG_SkillAttackPlayerFirstRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_SkillAttackPlayerFirst");
     			}
     			return this.m_EG_SkillAttackPlayerFirstRectTransform;
     		}
     	}

		public RectTransform EG_PickSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PickSetRectTransform == null )
     			{
		    		this.m_EG_PickSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_PickSet");
     			}
     			return this.m_EG_PickSetRectTransform;
     		}
     	}

		public Button E_ReSetCameraBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetCameraBtnButton == null )
     			{
		    		this.m_E_ReSetCameraBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ReSetCameraBtn");
     			}
     			return this.m_E_ReSetCameraBtnButton;
     		}
     	}

		public Image E_ReSetCameraBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetCameraBtnImage == null )
     			{
		    		this.m_E_ReSetCameraBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ReSetCameraBtn");
     			}
     			return this.m_E_ReSetCameraBtnImage;
     		}
     	}

		public RectTransform EG_LenDepthSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LenDepthSetRectTransform == null )
     			{
		    		this.m_EG_LenDepthSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_LenDepthSet");
     			}
     			return this.m_EG_LenDepthSetRectTransform;
     		}
     	}

		public RectTransform EG_RotaAngleSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RotaAngleSetRectTransform == null )
     			{
		    		this.m_EG_RotaAngleSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_RotaAngleSet");
     			}
     			return this.m_EG_RotaAngleSetRectTransform;
     		}
     	}

		public RectTransform EG_ZhuBoSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ZhuBoSetRectTransform == null )
     			{
		    		this.m_EG_ZhuBoSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_ZhuBoSet");
     			}
     			return this.m_EG_ZhuBoSetRectTransform;
     		}
     	}

		public Text E_TextZhangHaoIDText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextZhangHaoIDText == null )
     			{
		    		this.m_E_TextZhangHaoIDText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_TextZhangHaoID");
     			}
     			return this.m_E_TextZhangHaoIDText;
     		}
     	}

		public EventTrigger E_TextZhangHaoIDEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextZhangHaoIDEventTrigger == null )
     			{
		    		this.m_E_TextZhangHaoIDEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_TextZhangHaoID");
     			}
     			return this.m_E_TextZhangHaoIDEventTrigger;
     		}
     	}

		public RectTransform EG_HideNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HideNodeRectTransform == null )
     			{
		    		this.m_EG_HideNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_HideNode");
     			}
     			return this.m_EG_HideNodeRectTransform;
     		}
     	}

		public Button E_GameMemoryButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameMemoryButton == null )
     			{
		    		this.m_E_GameMemoryButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_HideNode/E_GameMemory");
     			}
     			return this.m_E_GameMemoryButton;
     		}
     	}

		public Image E_GameMemoryImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameMemoryImage == null )
     			{
		    		this.m_E_GameMemoryImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_HideNode/E_GameMemory");
     			}
     			return this.m_E_GameMemoryImage;
     		}
     	}

		public Button E_NoMovingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoMovingButton == null )
     			{
		    		this.m_E_NoMovingButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_HideNode/E_NoMoving");
     			}
     			return this.m_E_NoMovingButton;
     		}
     	}

		public Image E_NoMovingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoMovingImage == null )
     			{
		    		this.m_E_NoMovingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_HideNode/E_NoMoving");
     			}
     			return this.m_E_NoMovingImage;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_HideDiImage = null;
			this.m_E_ButtonSkillSetButton = null;
			this.m_E_ButtonSkillSetImage = null;
			this.m_E_Btn_CloseGameButton = null;
			this.m_E_Btn_CloseGameImage = null;
			this.m_E_Btn_ReturnDengLuButton = null;
			this.m_E_Btn_ReturnDengLuImage = null;
			this.m_E_TextVersionText = null;
			this.m_E_LastLoginTimeText = null;
			this.m_E_InputFieldCNameInputField = null;
			this.m_E_InputFieldCNameImage = null;
			this.m_E_ButtonRnameButton = null;
			this.m_E_ButtonRnameImage = null;
			this.m_E_ButtonPhoneButton = null;
			this.m_E_ButtonPhoneImage = null;
			this.m_E_Btn_FixedButton = null;
			this.m_E_Btn_FixedImage = null;
			this.m_E_Image_FixedImage = null;
			this.m_E_Btn_YinYueButton = null;
			this.m_E_Btn_YinYueImage = null;
			this.m_E_Image_yinyuImage = null;
			this.m_E_Btn_SoundButton = null;
			this.m_E_Btn_SoundImage = null;
			this.m_E_Image_SoundImage = null;
			this.m_E_SliderMusicSlider = null;
			this.m_E_SliderSoundSlider = null;
			this.m_E_Btn_FpsButton = null;
			this.m_E_Btn_FpsImage = null;
			this.m_E_Image_fpsImage = null;
			this.m_E_Btn_ClickButton = null;
			this.m_E_Btn_ClickImage = null;
			this.m_E_Image_ClickImage = null;
			this.m_EG_HighFpsRectTransform = null;
			this.m_EG_SmoothRectTransform = null;
			this.m_E_ScreenToggle0Toggle = null;
			this.m_E_ScreenToggle1Toggle = null;
			this.m_E_Btn_YinYingButton = null;
			this.m_E_Btn_YinYingImage = null;
			this.m_E_Image_YinYingImage = null;
			this.m_EG_RandomHoreseRectTransform = null;
			this.m_EG_OneSellSetRectTransform = null;
			this.m_EG_ActTypeSetRectTransform = null;
			this.m_EG_ActTargetSelectRectTransform = null;
			this.m_EG_NoShowOtherRectTransform = null;
			this.m_EG_AutoAttackRectTransform = null;
			this.m_EG_HideLeftBottomRectTransform = null;
			this.m_EG_FirstUnionNameRectTransform = null;
			this.m_EG_SkillAttackPlayerFirstRectTransform = null;
			this.m_EG_PickSetRectTransform = null;
			this.m_E_ReSetCameraBtnButton = null;
			this.m_E_ReSetCameraBtnImage = null;
			this.m_EG_LenDepthSetRectTransform = null;
			this.m_EG_RotaAngleSetRectTransform = null;
			this.m_EG_ZhuBoSetRectTransform = null;
			this.m_E_TextZhangHaoIDText = null;
			this.m_E_TextZhangHaoIDEventTrigger = null;
			this.m_EG_HideNodeRectTransform = null;
			this.m_E_GameMemoryButton = null;
			this.m_E_GameMemoryImage = null;
			this.m_E_NoMovingButton = null;
			this.m_E_NoMovingImage = null;
			this.uiTransform = null;
		}

		private Image m_E_HideDiImage = null;
		private Button m_E_ButtonSkillSetButton = null;
		private Image m_E_ButtonSkillSetImage = null;
		private Button m_E_Btn_CloseGameButton = null;
		private Image m_E_Btn_CloseGameImage = null;
		private Button m_E_Btn_ReturnDengLuButton = null;
		private Image m_E_Btn_ReturnDengLuImage = null;
		private Text m_E_TextVersionText = null;
		private Text m_E_LastLoginTimeText = null;
		private InputField m_E_InputFieldCNameInputField = null;
		private Image m_E_InputFieldCNameImage = null;
		private Button m_E_ButtonRnameButton = null;
		private Image m_E_ButtonRnameImage = null;
		private Button m_E_ButtonPhoneButton = null;
		private Image m_E_ButtonPhoneImage = null;
		private Button m_E_Btn_FixedButton = null;
		private Image m_E_Btn_FixedImage = null;
		private Image m_E_Image_FixedImage = null;
		private Button m_E_Btn_YinYueButton = null;
		private Image m_E_Btn_YinYueImage = null;
		private Image m_E_Image_yinyuImage = null;
		private Button m_E_Btn_SoundButton = null;
		private Image m_E_Btn_SoundImage = null;
		private Image m_E_Image_SoundImage = null;
		private Slider m_E_SliderMusicSlider = null;
		private Slider m_E_SliderSoundSlider = null;
		private Button m_E_Btn_FpsButton = null;
		private Image m_E_Btn_FpsImage = null;
		private Image m_E_Image_fpsImage = null;
		private Button m_E_Btn_ClickButton = null;
		private Image m_E_Btn_ClickImage = null;
		private Image m_E_Image_ClickImage = null;
		private RectTransform m_EG_HighFpsRectTransform = null;
		private RectTransform m_EG_SmoothRectTransform = null;
		private Toggle m_E_ScreenToggle0Toggle = null;
		private Toggle m_E_ScreenToggle1Toggle = null;
		private Button m_E_Btn_YinYingButton = null;
		private Image m_E_Btn_YinYingImage = null;
		private Image m_E_Image_YinYingImage = null;
		private RectTransform m_EG_RandomHoreseRectTransform = null;
		private RectTransform m_EG_OneSellSetRectTransform = null;
		private RectTransform m_EG_ActTypeSetRectTransform = null;
		private RectTransform m_EG_ActTargetSelectRectTransform = null;
		private RectTransform m_EG_NoShowOtherRectTransform = null;
		private RectTransform m_EG_AutoAttackRectTransform = null;
		private RectTransform m_EG_HideLeftBottomRectTransform = null;
		private RectTransform m_EG_FirstUnionNameRectTransform = null;
		private RectTransform m_EG_SkillAttackPlayerFirstRectTransform = null;
		private RectTransform m_EG_PickSetRectTransform = null;
		private Button m_E_ReSetCameraBtnButton = null;
		private Image m_E_ReSetCameraBtnImage = null;
		private RectTransform m_EG_LenDepthSetRectTransform = null;
		private RectTransform m_EG_RotaAngleSetRectTransform = null;
		private RectTransform m_EG_ZhuBoSetRectTransform = null;
		private Text m_E_TextZhangHaoIDText = null;
		private EventTrigger m_E_TextZhangHaoIDEventTrigger = null;
		private RectTransform m_EG_HideNodeRectTransform = null;
		private Button m_E_GameMemoryButton = null;
		private Image m_E_GameMemoryImage = null;
		private Button m_E_NoMovingButton = null;
		private Image m_E_NoMovingImage = null;
		public Transform uiTransform = null;
	}
}
