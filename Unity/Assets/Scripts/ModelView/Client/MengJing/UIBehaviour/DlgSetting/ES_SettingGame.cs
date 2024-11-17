
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SettingGame : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UserInfoComponentC UserInfoComponent { get; set; }
		public List<KeyValuePair> GameSettingInfos = new();
		
		public UnityEngine.UI.Image E_HideDiImage
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
		    		this.m_E_HideDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_HideDi");
     			}
     			return this.m_E_HideDiImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSkillSetButton
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
		    		this.m_E_ButtonSkillSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonSkillSet");
     			}
     			return this.m_E_ButtonSkillSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSkillSetImage
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
		    		this.m_E_ButtonSkillSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonSkillSet");
     			}
     			return this.m_E_ButtonSkillSetImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CloseGameButton
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
		    		this.m_E_Btn_CloseGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_CloseGame");
     			}
     			return this.m_E_Btn_CloseGameButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseGameImage
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
		    		this.m_E_Btn_CloseGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_CloseGame");
     			}
     			return this.m_E_Btn_CloseGameImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ReturnDengLuButton
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
		    		this.m_E_Btn_ReturnDengLuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_ReturnDengLu");
     			}
     			return this.m_E_Btn_ReturnDengLuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ReturnDengLuImage
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
		    		this.m_E_Btn_ReturnDengLuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_ReturnDengLu");
     			}
     			return this.m_E_Btn_ReturnDengLuImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextVersionText
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
		    		this.m_E_TextVersionText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BanBenHao/E_TextVersion");
     			}
     			return this.m_E_TextVersionText;
     		}
     	}

		public UnityEngine.UI.Text E_LastLoginTimeText
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
		    		this.m_E_LastLoginTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"DengLuTime/E_LastLoginTime");
     			}
     			return this.m_E_LastLoginTimeText;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldCNameInputField
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
		    		this.m_E_InputFieldCNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_InputFieldCName");
     			}
     			return this.m_E_InputFieldCNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldCNameImage
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
		    		this.m_E_InputFieldCNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_InputFieldCName");
     			}
     			return this.m_E_InputFieldCNameImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonRnameButton
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
		    		this.m_E_ButtonRnameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonRname");
     			}
     			return this.m_E_ButtonRnameButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRnameImage
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
		    		this.m_E_ButtonRnameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonRname");
     			}
     			return this.m_E_ButtonRnameImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonPhoneButton
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
		    		this.m_E_ButtonPhoneButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonPhone");
     			}
     			return this.m_E_ButtonPhoneButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonPhoneImage
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
		    		this.m_E_ButtonPhoneImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ButtonPhone");
     			}
     			return this.m_E_ButtonPhoneImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_FixedButton
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
		    		this.m_E_Btn_FixedButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGanSet/E_Btn_Fixed");
     			}
     			return this.m_E_Btn_FixedButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_FixedImage
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
		    		this.m_E_Btn_FixedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGanSet/E_Btn_Fixed");
     			}
     			return this.m_E_Btn_FixedImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_FixedImage
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
		    		this.m_E_Image_FixedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGanSet/E_Image_Fixed");
     			}
     			return this.m_E_Image_FixedImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_YinYueButton
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
		    		this.m_E_Btn_YinYueButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_YinYue");
     			}
     			return this.m_E_Btn_YinYueButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_YinYueImage
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
		    		this.m_E_Btn_YinYueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_YinYue");
     			}
     			return this.m_E_Btn_YinYueImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_yinyuImage
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
		    		this.m_E_Image_yinyuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Image_yinyu");
     			}
     			return this.m_E_Image_yinyuImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SoundButton
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
		    		this.m_E_Btn_SoundButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_Sound");
     			}
     			return this.m_E_Btn_SoundButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SoundImage
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
		    		this.m_E_Btn_SoundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Btn_Sound");
     			}
     			return this.m_E_Btn_SoundImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_SoundImage
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
		    		this.m_E_Image_SoundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/MusicSet/E_Image_Sound");
     			}
     			return this.m_E_Image_SoundImage;
     		}
     	}

		public UnityEngine.UI.Slider E_SliderMusicSlider
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
		    		this.m_E_SliderMusicSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_SliderMusic");
     			}
     			return this.m_E_SliderMusicSlider;
     		}
     	}

		public UnityEngine.UI.Slider E_SliderSoundSlider
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
		    		this.m_E_SliderSoundSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_SliderSound");
     			}
     			return this.m_E_SliderSoundSlider;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_FpsButton
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
		    		this.m_E_Btn_FpsButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/Fps/E_Btn_Fps");
     			}
     			return this.m_E_Btn_FpsButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_FpsImage
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
		    		this.m_E_Btn_FpsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/Fps/E_Btn_Fps");
     			}
     			return this.m_E_Btn_FpsImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_fpsImage
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
		    		this.m_E_Image_fpsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/Fps/E_Image_fps");
     			}
     			return this.m_E_Image_fpsImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ClickButton
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
		    		this.m_E_Btn_ClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGan/E_Btn_Click");
     			}
     			return this.m_E_Btn_ClickButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ClickImage
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
		    		this.m_E_Btn_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGan/E_Btn_Click");
     			}
     			return this.m_E_Btn_ClickImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_ClickImage
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
		    		this.m_E_Image_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/YaoGan/E_Image_Click");
     			}
     			return this.m_E_Image_ClickImage;
     		}
     	}

		public UnityEngine.RectTransform EG_HighFpsRectTransform
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
		    		this.m_EG_HighFpsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_HighFps");
     			}
     			return this.m_EG_HighFpsRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SmoothRectTransform
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
		    		this.m_EG_SmoothRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_Smooth");
     			}
     			return this.m_EG_SmoothRectTransform;
     		}
     	}

		public UnityEngine.UI.Toggle E_ScreenToggle0Toggle
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
		    		this.m_E_ScreenToggle0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/ToggleGroup/E_ScreenToggle0");
     			}
     			return this.m_E_ScreenToggle0Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ScreenToggle1Toggle
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
		    		this.m_E_ScreenToggle1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/ToggleGroup/E_ScreenToggle1");
     			}
     			return this.m_E_ScreenToggle1Toggle;
     		}
     	}

		public UnityEngine.RectTransform EG_YinYingRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_YinYingRectTransform == null )
     			{
		    		this.m_EG_YinYingRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_YinYing");
     			}
     			return this.m_EG_YinYingRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_YinYingButton
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
		    		this.m_E_Btn_YinYingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_YinYing/E_Btn_YinYing");
     			}
     			return this.m_E_Btn_YinYingButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_YinYingImage
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
		    		this.m_E_Btn_YinYingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_YinYing/E_Btn_YinYing");
     			}
     			return this.m_E_Btn_YinYingImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_YinYingImage
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
		    		this.m_E_Image_YinYingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_YinYing/E_Image_YinYing");
     			}
     			return this.m_E_Image_YinYingImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RandomHoreseRectTransform
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
		    		this.m_EG_RandomHoreseRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_RandomHorese");
     			}
     			return this.m_EG_RandomHoreseRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_OneSellSetRectTransform
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
		    		this.m_EG_OneSellSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_OneSellSet");
     			}
     			return this.m_EG_OneSellSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_ActTypeSetRectTransform
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
		    		this.m_EG_ActTypeSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_ActTypeSet");
     			}
     			return this.m_EG_ActTypeSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_ActTargetSelectRectTransform
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
		    		this.m_EG_ActTargetSelectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_ActTargetSelect");
     			}
     			return this.m_EG_ActTargetSelectRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_NoShowOtherRectTransform
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
		    		this.m_EG_NoShowOtherRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_NoShowOther");
     			}
     			return this.m_EG_NoShowOtherRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AutoAttackRectTransform
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
		    		this.m_EG_AutoAttackRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_AutoAttack");
     			}
     			return this.m_EG_AutoAttackRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_HideLeftBottomRectTransform
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
		    		this.m_EG_HideLeftBottomRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_HideLeftBottom");
     			}
     			return this.m_EG_HideLeftBottomRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_FirstUnionNameRectTransform
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
		    		this.m_EG_FirstUnionNameRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_FirstUnionName");
     			}
     			return this.m_EG_FirstUnionNameRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillAttackPlayerFirstRectTransform
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
		    		this.m_EG_SkillAttackPlayerFirstRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_SkillAttackPlayerFirst");
     			}
     			return this.m_EG_SkillAttackPlayerFirstRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PickSetRectTransform
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
		    		this.m_EG_PickSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_PickSet");
     			}
     			return this.m_EG_PickSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_LocalizationBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LocalizationBtnButton == null )
     			{
		    		this.m_E_LocalizationBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_LocalizationBtn");
     			}
     			return this.m_E_LocalizationBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_LocalizationBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LocalizationBtnImage == null )
     			{
		    		this.m_E_LocalizationBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_LocalizationBtn");
     			}
     			return this.m_E_LocalizationBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_ReSetCameraBtnButton
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
		    		this.m_E_ReSetCameraBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ReSetCameraBtn");
     			}
     			return this.m_E_ReSetCameraBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReSetCameraBtnImage
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
		    		this.m_E_ReSetCameraBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_ReSetCameraBtn");
     			}
     			return this.m_E_ReSetCameraBtnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_LenDepthSetRectTransform
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
		    		this.m_EG_LenDepthSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_LenDepthSet");
     			}
     			return this.m_EG_LenDepthSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_CameraHorizontalOffsetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CameraHorizontalOffsetRectTransform == null )
     			{
		    		this.m_EG_CameraHorizontalOffsetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_CameraHorizontalOffset");
     			}
     			return this.m_EG_CameraHorizontalOffsetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_CameraVerticalOffsetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CameraVerticalOffsetRectTransform == null )
     			{
		    		this.m_EG_CameraVerticalOffsetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_CameraVerticalOffset");
     			}
     			return this.m_EG_CameraVerticalOffsetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SaveViewBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveViewBtnButton == null )
     			{
		    		this.m_E_SaveViewBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_SaveViewBtn");
     			}
     			return this.m_E_SaveViewBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_SaveViewBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveViewBtnImage == null )
     			{
		    		this.m_E_SaveViewBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_SaveViewBtn");
     			}
     			return this.m_E_SaveViewBtnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UseCustomViewRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UseCustomViewRectTransform == null )
     			{
		    		this.m_EG_UseCustomViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_UseCustomView");
     			}
     			return this.m_EG_UseCustomViewRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_RotaAngleSetRectTransform
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
		    		this.m_EG_RotaAngleSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_RotaAngleSet");
     			}
     			return this.m_EG_RotaAngleSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_ZhuBoSetRectTransform
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
		    		this.m_EG_ZhuBoSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/EG_ZhuBoSet");
     			}
     			return this.m_EG_ZhuBoSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextZhangHaoIDText
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
		    		this.m_E_TextZhangHaoIDText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_TextZhangHaoID");
     			}
     			return this.m_E_TextZhangHaoIDText;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_TextZhangHaoIDEventTrigger
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
		    		this.m_E_TextZhangHaoIDEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ScrollView/Viewport/Content/UIGameSetting/E_TextZhangHaoID");
     			}
     			return this.m_E_TextZhangHaoIDEventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EG_HideNodeRectTransform
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
		    		this.m_EG_HideNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_HideNode");
     			}
     			return this.m_EG_HideNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_GameMemoryButton
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
		    		this.m_E_GameMemoryButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_HideNode/E_GameMemory");
     			}
     			return this.m_E_GameMemoryButton;
     		}
     	}

		public UnityEngine.UI.Image E_GameMemoryImage
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
		    		this.m_E_GameMemoryImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_HideNode/E_GameMemory");
     			}
     			return this.m_E_GameMemoryImage;
     		}
     	}

		public UnityEngine.UI.Button E_NoMovingButton
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
		    		this.m_E_NoMovingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_HideNode/E_NoMoving");
     			}
     			return this.m_E_NoMovingButton;
     		}
     	}

		public UnityEngine.UI.Image E_NoMovingImage
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
		    		this.m_E_NoMovingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_HideNode/E_NoMoving");
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
			this.m_EG_YinYingRectTransform = null;
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
			this.m_E_LocalizationBtnButton = null;
			this.m_E_LocalizationBtnImage = null;
			this.m_E_ReSetCameraBtnButton = null;
			this.m_E_ReSetCameraBtnImage = null;
			this.m_EG_LenDepthSetRectTransform = null;
			this.m_EG_CameraHorizontalOffsetRectTransform = null;
			this.m_EG_CameraVerticalOffsetRectTransform = null;
			this.m_E_SaveViewBtnButton = null;
			this.m_E_SaveViewBtnImage = null;
			this.m_EG_UseCustomViewRectTransform = null;
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

		private UnityEngine.UI.Image m_E_HideDiImage = null;
		private UnityEngine.UI.Button m_E_ButtonSkillSetButton = null;
		private UnityEngine.UI.Image m_E_ButtonSkillSetImage = null;
		private UnityEngine.UI.Button m_E_Btn_CloseGameButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseGameImage = null;
		private UnityEngine.UI.Button m_E_Btn_ReturnDengLuButton = null;
		private UnityEngine.UI.Image m_E_Btn_ReturnDengLuImage = null;
		private UnityEngine.UI.Text m_E_TextVersionText = null;
		private UnityEngine.UI.Text m_E_LastLoginTimeText = null;
		private UnityEngine.UI.InputField m_E_InputFieldCNameInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldCNameImage = null;
		private UnityEngine.UI.Button m_E_ButtonRnameButton = null;
		private UnityEngine.UI.Image m_E_ButtonRnameImage = null;
		private UnityEngine.UI.Button m_E_ButtonPhoneButton = null;
		private UnityEngine.UI.Image m_E_ButtonPhoneImage = null;
		private UnityEngine.UI.Button m_E_Btn_FixedButton = null;
		private UnityEngine.UI.Image m_E_Btn_FixedImage = null;
		private UnityEngine.UI.Image m_E_Image_FixedImage = null;
		private UnityEngine.UI.Button m_E_Btn_YinYueButton = null;
		private UnityEngine.UI.Image m_E_Btn_YinYueImage = null;
		private UnityEngine.UI.Image m_E_Image_yinyuImage = null;
		private UnityEngine.UI.Button m_E_Btn_SoundButton = null;
		private UnityEngine.UI.Image m_E_Btn_SoundImage = null;
		private UnityEngine.UI.Image m_E_Image_SoundImage = null;
		private UnityEngine.UI.Slider m_E_SliderMusicSlider = null;
		private UnityEngine.UI.Slider m_E_SliderSoundSlider = null;
		private UnityEngine.UI.Button m_E_Btn_FpsButton = null;
		private UnityEngine.UI.Image m_E_Btn_FpsImage = null;
		private UnityEngine.UI.Image m_E_Image_fpsImage = null;
		private UnityEngine.UI.Button m_E_Btn_ClickButton = null;
		private UnityEngine.UI.Image m_E_Btn_ClickImage = null;
		private UnityEngine.UI.Image m_E_Image_ClickImage = null;
		private UnityEngine.RectTransform m_EG_HighFpsRectTransform = null;
		private UnityEngine.RectTransform m_EG_SmoothRectTransform = null;
		private UnityEngine.UI.Toggle m_E_ScreenToggle0Toggle = null;
		private UnityEngine.UI.Toggle m_E_ScreenToggle1Toggle = null;
		private UnityEngine.RectTransform m_EG_YinYingRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_YinYingButton = null;
		private UnityEngine.UI.Image m_E_Btn_YinYingImage = null;
		private UnityEngine.UI.Image m_E_Image_YinYingImage = null;
		private UnityEngine.RectTransform m_EG_RandomHoreseRectTransform = null;
		private UnityEngine.RectTransform m_EG_OneSellSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_ActTypeSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_ActTargetSelectRectTransform = null;
		private UnityEngine.RectTransform m_EG_NoShowOtherRectTransform = null;
		private UnityEngine.RectTransform m_EG_AutoAttackRectTransform = null;
		private UnityEngine.RectTransform m_EG_HideLeftBottomRectTransform = null;
		private UnityEngine.RectTransform m_EG_FirstUnionNameRectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillAttackPlayerFirstRectTransform = null;
		private UnityEngine.RectTransform m_EG_PickSetRectTransform = null;
		private UnityEngine.UI.Button m_E_LocalizationBtnButton = null;
		private UnityEngine.UI.Image m_E_LocalizationBtnImage = null;
		private UnityEngine.UI.Button m_E_ReSetCameraBtnButton = null;
		private UnityEngine.UI.Image m_E_ReSetCameraBtnImage = null;
		private UnityEngine.RectTransform m_EG_LenDepthSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_CameraHorizontalOffsetRectTransform = null;
		private UnityEngine.RectTransform m_EG_CameraVerticalOffsetRectTransform = null;
		private UnityEngine.UI.Button m_E_SaveViewBtnButton = null;
		private UnityEngine.UI.Image m_E_SaveViewBtnImage = null;
		private UnityEngine.RectTransform m_EG_UseCustomViewRectTransform = null;
		private UnityEngine.RectTransform m_EG_RotaAngleSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_ZhuBoSetRectTransform = null;
		private UnityEngine.UI.Text m_E_TextZhangHaoIDText = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TextZhangHaoIDEventTrigger = null;
		private UnityEngine.RectTransform m_EG_HideNodeRectTransform = null;
		private UnityEngine.UI.Button m_E_GameMemoryButton = null;
		private UnityEngine.UI.Image m_E_GameMemoryImage = null;
		private UnityEngine.UI.Button m_E_NoMovingButton = null;
		private UnityEngine.UI.Image m_E_NoMovingImage = null;
		public Transform uiTransform = null;
	}
}
