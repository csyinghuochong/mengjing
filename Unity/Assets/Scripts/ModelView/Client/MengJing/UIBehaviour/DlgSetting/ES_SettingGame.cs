
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
		    		this.m_E_HideDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_HideDi");
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
		    		this.m_E_ButtonSkillSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonSkillSet");
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
		    		this.m_E_ButtonSkillSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonSkillSet");
     			}
     			return this.m_E_ButtonSkillSetImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonReSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonReSetButton == null )
     			{
		    		this.m_E_ButtonReSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonReSet");
     			}
     			return this.m_E_ButtonReSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonReSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonReSetImage == null )
     			{
		    		this.m_E_ButtonReSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonReSet");
     			}
     			return this.m_E_ButtonReSetImage;
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
		    		this.m_E_Btn_CloseGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_CloseGame");
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
		    		this.m_E_Btn_CloseGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_CloseGame");
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
		    		this.m_E_Btn_ReturnDengLuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ReturnDengLu");
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
		    		this.m_E_Btn_ReturnDengLuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ReturnDengLu");
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
		    		this.m_E_TextVersionText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/BanBenHao/E_TextVersion");
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
		    		this.m_E_LastLoginTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/DengLuTime/E_LastLoginTime");
     			}
     			return this.m_E_LastLoginTimeText;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_ScrollView_0ScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_0ScrollRect == null )
     			{
		    		this.m_E_ScrollView_0ScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_ScrollView_0");
     			}
     			return this.m_E_ScrollView_0ScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ScrollView_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_0Image == null )
     			{
		    		this.m_E_ScrollView_0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_0");
     			}
     			return this.m_E_ScrollView_0Image;
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
		    		this.m_E_SliderSoundSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"Right/E_ScrollView_0/Viewport/Content/SettingItem_0/E_SliderSound");
     			}
     			return this.m_E_SliderSoundSlider;
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
		    		this.m_E_SliderMusicSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"Right/E_ScrollView_0/Viewport/Content/SettingItem_1/E_SliderMusic");
     			}
     			return this.m_E_SliderMusicSlider;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_ScrollView_1ScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_1ScrollRect == null )
     			{
		    		this.m_E_ScrollView_1ScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_ScrollView_1");
     			}
     			return this.m_E_ScrollView_1ScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ScrollView_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_1Image == null )
     			{
		    		this.m_E_ScrollView_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_1");
     			}
     			return this.m_E_ScrollView_1Image;
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
		    		this.m_EG_HighFpsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_0/EG_HighFps");
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
		    		this.m_EG_SmoothRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_1/EG_Smooth");
     			}
     			return this.m_EG_SmoothRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_FpsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FpsRectTransform == null )
     			{
		    		this.m_EG_FpsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_2/EG_Fps");
     			}
     			return this.m_EG_FpsRectTransform;
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
		    		this.m_EG_NoShowOtherRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_3/EG_NoShowOther");
     			}
     			return this.m_EG_NoShowOtherRectTransform;
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
		    		this.m_EG_LenDepthSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_4/EG_LenDepthSet");
     			}
     			return this.m_EG_LenDepthSetRectTransform;
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
		    		this.m_EG_RotaAngleSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_5/EG_RotaAngleSet");
     			}
     			return this.m_EG_RotaAngleSetRectTransform;
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
		    		this.m_EG_CameraHorizontalOffsetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_6/EG_CameraHorizontalOffset");
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
		    		this.m_EG_CameraVerticalOffsetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_7/EG_CameraVerticalOffset");
     			}
     			return this.m_EG_CameraVerticalOffsetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_TestViewBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TestViewBtnButton == null )
     			{
		    		this.m_E_TestViewBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_8/E_TestViewBtn");
     			}
     			return this.m_E_TestViewBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_TestViewBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TestViewBtnImage == null )
     			{
		    		this.m_E_TestViewBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_8/E_TestViewBtn");
     			}
     			return this.m_E_TestViewBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_PrintViewBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PrintViewBtnButton == null )
     			{
		    		this.m_E_PrintViewBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_8/E_PrintViewBtn");
     			}
     			return this.m_E_PrintViewBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_PrintViewBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PrintViewBtnImage == null )
     			{
		    		this.m_E_PrintViewBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_8/E_PrintViewBtn");
     			}
     			return this.m_E_PrintViewBtnImage;
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
		    		this.m_E_ReSetCameraBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_8/E_ReSetCameraBtn");
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
		    		this.m_E_ReSetCameraBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_8/E_ReSetCameraBtn");
     			}
     			return this.m_E_ReSetCameraBtnImage;
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
		    		this.m_EG_YinYingRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_9/EG_YinYing");
     			}
     			return this.m_EG_YinYingRectTransform;
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
		    		this.m_EG_FirstUnionNameRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_1/Viewport/Content/SettingItem_10/EG_FirstUnionName");
     			}
     			return this.m_EG_FirstUnionNameRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_ScrollView_2ScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_2ScrollRect == null )
     			{
		    		this.m_E_ScrollView_2ScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_ScrollView_2");
     			}
     			return this.m_E_ScrollView_2ScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ScrollView_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_2Image == null )
     			{
		    		this.m_E_ScrollView_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_2");
     			}
     			return this.m_E_ScrollView_2Image;
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
		    		this.m_EG_ActTargetSelectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_2/Viewport/Content/SettingItem_0/EG_ActTargetSelect");
     			}
     			return this.m_EG_ActTargetSelectRectTransform;
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
		    		this.m_EG_AutoAttackRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_2/Viewport/Content/SettingItem_1/EG_AutoAttack");
     			}
     			return this.m_EG_AutoAttackRectTransform;
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
		    		this.m_EG_ActTypeSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_2/Viewport/Content/SettingItem_2/EG_ActTypeSet");
     			}
     			return this.m_EG_ActTypeSetRectTransform;
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
		    		this.m_EG_SkillAttackPlayerFirstRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_2/Viewport/Content/SettingItem_3/EG_SkillAttackPlayerFirst");
     			}
     			return this.m_EG_SkillAttackPlayerFirstRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_ScrollView_3ScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_3ScrollRect == null )
     			{
		    		this.m_E_ScrollView_3ScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_ScrollView_3");
     			}
     			return this.m_E_ScrollView_3ScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ScrollView_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollView_3Image == null )
     			{
		    		this.m_E_ScrollView_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3");
     			}
     			return this.m_E_ScrollView_3Image;
     		}
     	}

		public UnityEngine.RectTransform EG_ClickRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ClickRectTransform == null )
     			{
		    		this.m_EG_ClickRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_0/EG_Click");
     			}
     			return this.m_EG_ClickRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_FixedRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FixedRectTransform == null )
     			{
		    		this.m_EG_FixedRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_1/EG_Fixed");
     			}
     			return this.m_EG_FixedRectTransform;
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
		    		this.m_E_InputFieldCNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_2/E_InputFieldCName");
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
		    		this.m_E_InputFieldCNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_2/E_InputFieldCName");
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
		    		this.m_E_ButtonRnameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_2/E_ButtonRname");
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
		    		this.m_E_ButtonRnameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_2/E_ButtonRname");
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
		    		this.m_E_ButtonPhoneButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_2/E_ButtonPhone");
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
		    		this.m_E_ButtonPhoneImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_2/E_ButtonPhone");
     			}
     			return this.m_E_ButtonPhoneImage;
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
		    		this.m_EG_RandomHoreseRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_3/EG_RandomHorese");
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
		    		this.m_EG_OneSellSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_4/EG_OneSellSet");
     			}
     			return this.m_EG_OneSellSetRectTransform;
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
		    		this.m_EG_HideLeftBottomRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_5/EG_HideLeftBottom");
     			}
     			return this.m_EG_HideLeftBottomRectTransform;
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
		    		this.m_EG_PickSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_6/EG_PickSet");
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
		    		this.m_E_LocalizationBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_7/E_LocalizationBtn");
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
		    		this.m_E_LocalizationBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_7/E_LocalizationBtn");
     			}
     			return this.m_E_LocalizationBtnImage;
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
		    		this.m_EG_ZhuBoSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/SettingItem_8/EG_ZhuBoSet");
     			}
     			return this.m_EG_ZhuBoSetRectTransform;
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
		    		this.m_E_Btn_YinYueButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/MusicSet/E_Btn_YinYue");
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
		    		this.m_E_Btn_YinYueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/MusicSet/E_Btn_YinYue");
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
		    		this.m_E_Image_yinyuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/MusicSet/E_Image_yinyu");
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
		    		this.m_E_Btn_SoundButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/MusicSet/E_Btn_Sound");
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
		    		this.m_E_Btn_SoundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/MusicSet/E_Btn_Sound");
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
		    		this.m_E_Image_SoundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/MusicSet/E_Image_Sound");
     			}
     			return this.m_E_Image_SoundImage;
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
		    		this.m_E_ScreenToggle0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/ToggleGroup/E_ScreenToggle0");
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
		    		this.m_E_ScreenToggle1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/ToggleGroup/E_ScreenToggle1");
     			}
     			return this.m_E_ScreenToggle1Toggle;
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
		    		this.m_E_TextZhangHaoIDText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/E_TextZhangHaoID");
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
		    		this.m_E_TextZhangHaoIDEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_ScrollView_3/Viewport/Content/UIGameSetting/E_TextZhangHaoID");
     			}
     			return this.m_E_TextZhangHaoIDEventTrigger;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
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
		    		this.m_EG_HideNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_HideNode");
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
		    		this.m_E_GameMemoryButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_HideNode/E_GameMemory");
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
		    		this.m_E_GameMemoryImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_HideNode/E_GameMemory");
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
		    		this.m_E_NoMovingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_HideNode/E_NoMoving");
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
		    		this.m_E_NoMovingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_HideNode/E_NoMoving");
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
			this.m_E_ButtonReSetButton = null;
			this.m_E_ButtonReSetImage = null;
			this.m_E_Btn_CloseGameButton = null;
			this.m_E_Btn_CloseGameImage = null;
			this.m_E_Btn_ReturnDengLuButton = null;
			this.m_E_Btn_ReturnDengLuImage = null;
			this.m_E_TextVersionText = null;
			this.m_E_LastLoginTimeText = null;
			this.m_E_ScrollView_0ScrollRect = null;
			this.m_E_ScrollView_0Image = null;
			this.m_E_SliderSoundSlider = null;
			this.m_E_SliderMusicSlider = null;
			this.m_E_ScrollView_1ScrollRect = null;
			this.m_E_ScrollView_1Image = null;
			this.m_EG_HighFpsRectTransform = null;
			this.m_EG_SmoothRectTransform = null;
			this.m_EG_FpsRectTransform = null;
			this.m_EG_NoShowOtherRectTransform = null;
			this.m_EG_LenDepthSetRectTransform = null;
			this.m_EG_RotaAngleSetRectTransform = null;
			this.m_EG_CameraHorizontalOffsetRectTransform = null;
			this.m_EG_CameraVerticalOffsetRectTransform = null;
			this.m_E_TestViewBtnButton = null;
			this.m_E_TestViewBtnImage = null;
			this.m_E_PrintViewBtnButton = null;
			this.m_E_PrintViewBtnImage = null;
			this.m_E_ReSetCameraBtnButton = null;
			this.m_E_ReSetCameraBtnImage = null;
			this.m_EG_YinYingRectTransform = null;
			this.m_EG_FirstUnionNameRectTransform = null;
			this.m_E_ScrollView_2ScrollRect = null;
			this.m_E_ScrollView_2Image = null;
			this.m_EG_ActTargetSelectRectTransform = null;
			this.m_EG_AutoAttackRectTransform = null;
			this.m_EG_ActTypeSetRectTransform = null;
			this.m_EG_SkillAttackPlayerFirstRectTransform = null;
			this.m_E_ScrollView_3ScrollRect = null;
			this.m_E_ScrollView_3Image = null;
			this.m_EG_ClickRectTransform = null;
			this.m_EG_FixedRectTransform = null;
			this.m_E_InputFieldCNameInputField = null;
			this.m_E_InputFieldCNameImage = null;
			this.m_E_ButtonRnameButton = null;
			this.m_E_ButtonRnameImage = null;
			this.m_E_ButtonPhoneButton = null;
			this.m_E_ButtonPhoneImage = null;
			this.m_EG_RandomHoreseRectTransform = null;
			this.m_EG_OneSellSetRectTransform = null;
			this.m_EG_HideLeftBottomRectTransform = null;
			this.m_EG_PickSetRectTransform = null;
			this.m_E_LocalizationBtnButton = null;
			this.m_E_LocalizationBtnImage = null;
			this.m_EG_ZhuBoSetRectTransform = null;
			this.m_E_Btn_YinYueButton = null;
			this.m_E_Btn_YinYueImage = null;
			this.m_E_Image_yinyuImage = null;
			this.m_E_Btn_SoundButton = null;
			this.m_E_Btn_SoundImage = null;
			this.m_E_Image_SoundImage = null;
			this.m_E_ScreenToggle0Toggle = null;
			this.m_E_ScreenToggle1Toggle = null;
			this.m_E_TextZhangHaoIDText = null;
			this.m_E_TextZhangHaoIDEventTrigger = null;
			this.m_E_BtnItemTypeSetToggleGroup = null;
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
		private UnityEngine.UI.Button m_E_ButtonReSetButton = null;
		private UnityEngine.UI.Image m_E_ButtonReSetImage = null;
		private UnityEngine.UI.Button m_E_Btn_CloseGameButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseGameImage = null;
		private UnityEngine.UI.Button m_E_Btn_ReturnDengLuButton = null;
		private UnityEngine.UI.Image m_E_Btn_ReturnDengLuImage = null;
		private UnityEngine.UI.Text m_E_TextVersionText = null;
		private UnityEngine.UI.Text m_E_LastLoginTimeText = null;
		private UnityEngine.UI.ScrollRect m_E_ScrollView_0ScrollRect = null;
		private UnityEngine.UI.Image m_E_ScrollView_0Image = null;
		private UnityEngine.UI.Slider m_E_SliderSoundSlider = null;
		private UnityEngine.UI.Slider m_E_SliderMusicSlider = null;
		private UnityEngine.UI.ScrollRect m_E_ScrollView_1ScrollRect = null;
		private UnityEngine.UI.Image m_E_ScrollView_1Image = null;
		private UnityEngine.RectTransform m_EG_HighFpsRectTransform = null;
		private UnityEngine.RectTransform m_EG_SmoothRectTransform = null;
		private UnityEngine.RectTransform m_EG_FpsRectTransform = null;
		private UnityEngine.RectTransform m_EG_NoShowOtherRectTransform = null;
		private UnityEngine.RectTransform m_EG_LenDepthSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_RotaAngleSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_CameraHorizontalOffsetRectTransform = null;
		private UnityEngine.RectTransform m_EG_CameraVerticalOffsetRectTransform = null;
		private UnityEngine.UI.Button m_E_TestViewBtnButton = null;
		private UnityEngine.UI.Image m_E_TestViewBtnImage = null;
		private UnityEngine.UI.Button m_E_PrintViewBtnButton = null;
		private UnityEngine.UI.Image m_E_PrintViewBtnImage = null;
		private UnityEngine.UI.Button m_E_ReSetCameraBtnButton = null;
		private UnityEngine.UI.Image m_E_ReSetCameraBtnImage = null;
		private UnityEngine.RectTransform m_EG_YinYingRectTransform = null;
		private UnityEngine.RectTransform m_EG_FirstUnionNameRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_ScrollView_2ScrollRect = null;
		private UnityEngine.UI.Image m_E_ScrollView_2Image = null;
		private UnityEngine.RectTransform m_EG_ActTargetSelectRectTransform = null;
		private UnityEngine.RectTransform m_EG_AutoAttackRectTransform = null;
		private UnityEngine.RectTransform m_EG_ActTypeSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillAttackPlayerFirstRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_ScrollView_3ScrollRect = null;
		private UnityEngine.UI.Image m_E_ScrollView_3Image = null;
		private UnityEngine.RectTransform m_EG_ClickRectTransform = null;
		private UnityEngine.RectTransform m_EG_FixedRectTransform = null;
		private UnityEngine.UI.InputField m_E_InputFieldCNameInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldCNameImage = null;
		private UnityEngine.UI.Button m_E_ButtonRnameButton = null;
		private UnityEngine.UI.Image m_E_ButtonRnameImage = null;
		private UnityEngine.UI.Button m_E_ButtonPhoneButton = null;
		private UnityEngine.UI.Image m_E_ButtonPhoneImage = null;
		private UnityEngine.RectTransform m_EG_RandomHoreseRectTransform = null;
		private UnityEngine.RectTransform m_EG_OneSellSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_HideLeftBottomRectTransform = null;
		private UnityEngine.RectTransform m_EG_PickSetRectTransform = null;
		private UnityEngine.UI.Button m_E_LocalizationBtnButton = null;
		private UnityEngine.UI.Image m_E_LocalizationBtnImage = null;
		private UnityEngine.RectTransform m_EG_ZhuBoSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_YinYueButton = null;
		private UnityEngine.UI.Image m_E_Btn_YinYueImage = null;
		private UnityEngine.UI.Image m_E_Image_yinyuImage = null;
		private UnityEngine.UI.Button m_E_Btn_SoundButton = null;
		private UnityEngine.UI.Image m_E_Btn_SoundImage = null;
		private UnityEngine.UI.Image m_E_Image_SoundImage = null;
		private UnityEngine.UI.Toggle m_E_ScreenToggle0Toggle = null;
		private UnityEngine.UI.Toggle m_E_ScreenToggle1Toggle = null;
		private UnityEngine.UI.Text m_E_TextZhangHaoIDText = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TextZhangHaoIDEventTrigger = null;
		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_HideNodeRectTransform = null;
		private UnityEngine.UI.Button m_E_GameMemoryButton = null;
		private UnityEngine.UI.Image m_E_GameMemoryImage = null;
		private UnityEngine.UI.Button m_E_NoMovingButton = null;
		private UnityEngine.UI.Image m_E_NoMovingImage = null;
		public Transform uiTransform = null;
	}
}
