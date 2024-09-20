
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeonMap))]
	[EnableMethod]
	public  class DlgDungeonMapViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_MapPanelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapPanelImage == null )
     			{
		    		this.m_E_MapPanelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel");
     			}
     			return this.m_E_MapPanelImage;
     		}
     	}

		public UnityEngine.UI.Image E_MapPanelDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapPanelDiImage == null )
     			{
		    		this.m_E_MapPanelDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_MapPanelDi");
     			}
     			return this.m_E_MapPanelDiImage;
     		}
     	}

		public UnityEngine.UI.Button E_Map0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map0Button == null )
     			{
		    		this.m_E_Map0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map0");
     			}
     			return this.m_E_Map0Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map0Image == null )
     			{
		    		this.m_E_Map0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map0");
     			}
     			return this.m_E_Map0Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map1Button == null )
     			{
		    		this.m_E_Map1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map1");
     			}
     			return this.m_E_Map1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map1Image == null )
     			{
		    		this.m_E_Map1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map1");
     			}
     			return this.m_E_Map1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map2Button == null )
     			{
		    		this.m_E_Map2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map2");
     			}
     			return this.m_E_Map2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map2Image == null )
     			{
		    		this.m_E_Map2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map2");
     			}
     			return this.m_E_Map2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map4Button == null )
     			{
		    		this.m_E_Map4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map4");
     			}
     			return this.m_E_Map4Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map4Image == null )
     			{
		    		this.m_E_Map4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map4");
     			}
     			return this.m_E_Map4Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map3Button == null )
     			{
		    		this.m_E_Map3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map3");
     			}
     			return this.m_E_Map3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map3Image == null )
     			{
		    		this.m_E_Map3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map3");
     			}
     			return this.m_E_Map3Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map5Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map5Button == null )
     			{
		    		this.m_E_Map5Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map5");
     			}
     			return this.m_E_Map5Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map5Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map5Image == null )
     			{
		    		this.m_E_Map5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map5");
     			}
     			return this.m_E_Map5Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map6Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map6Button == null )
     			{
		    		this.m_E_Map6Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map6");
     			}
     			return this.m_E_Map6Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map6Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map6Image == null )
     			{
		    		this.m_E_Map6Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map6");
     			}
     			return this.m_E_Map6Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map7Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map7Button == null )
     			{
		    		this.m_E_Map7Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map7");
     			}
     			return this.m_E_Map7Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map7Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map7Image == null )
     			{
		    		this.m_E_Map7Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map7");
     			}
     			return this.m_E_Map7Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map8Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map8Button == null )
     			{
		    		this.m_E_Map8Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map8");
     			}
     			return this.m_E_Map8Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map8Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map8Image == null )
     			{
		    		this.m_E_Map8Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map8");
     			}
     			return this.m_E_Map8Image;
     		}
     	}

		public UnityEngine.UI.Image E_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectImage == null )
     			{
		    		this.m_E_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Select");
     			}
     			return this.m_E_SelectImage;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_LevelPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LevelPanelRectTransform == null )
     			{
		    		this.m_EG_LevelPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LevelPanel");
     			}
     			return this.m_EG_LevelPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_RightBGImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RightBGImage == null )
     			{
		    		this.m_E_RightBGImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG");
     			}
     			return this.m_E_RightBGImage;
     		}
     	}

		public UnityEngine.UI.Text E_LevelNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelNameText == null )
     			{
		    		this.m_E_LevelNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/LevelInfo/E_LevelName");
     			}
     			return this.m_E_LevelNameText;
     		}
     	}

		public UnityEngine.UI.Text E_LevelDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelDesText == null )
     			{
		    		this.m_E_LevelDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/E_LevelDes");
     			}
     			return this.m_E_LevelDesText;
     		}
     	}

		public UnityEngine.UI.Text E_NanDuTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDuTipText == null )
     			{
		    		this.m_E_NanDuTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/E_NanDuTip");
     			}
     			return this.m_E_NanDuTipText;
     		}
     	}

		public UnityEngine.UI.Text E_AdditionText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AdditionText == null )
     			{
		    		this.m_E_AdditionText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/E_Addition");
     			}
     			return this.m_E_AdditionText;
     		}
     	}

		public UnityEngine.UI.Text E_EnterLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterLevelText == null )
     			{
		    		this.m_E_EnterLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/E_EnterLevel");
     			}
     			return this.m_E_EnterLevelText;
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_1_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_1_SelectImage == null )
     			{
		    		this.m_E_NanDu_1_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_1/E_NanDu_1_Select");
     			}
     			return this.m_E_NanDu_1_SelectImage;
     		}
     	}

		public UnityEngine.UI.Button E_NanDu_1_ButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_1_ButtonButton == null )
     			{
		    		this.m_E_NanDu_1_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_1/E_NanDu_1_Button");
     			}
     			return this.m_E_NanDu_1_ButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_1_ButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_1_ButtonImage == null )
     			{
		    		this.m_E_NanDu_1_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_1/E_NanDu_1_Button");
     			}
     			return this.m_E_NanDu_1_ButtonImage;
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_2_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_2_SelectImage == null )
     			{
		    		this.m_E_NanDu_2_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_2/E_NanDu_2_Select");
     			}
     			return this.m_E_NanDu_2_SelectImage;
     		}
     	}

		public UnityEngine.UI.Button E_NanDu_2_ButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_2_ButtonButton == null )
     			{
		    		this.m_E_NanDu_2_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_2/E_NanDu_2_Button");
     			}
     			return this.m_E_NanDu_2_ButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_2_ButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_2_ButtonImage == null )
     			{
		    		this.m_E_NanDu_2_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_2/E_NanDu_2_Button");
     			}
     			return this.m_E_NanDu_2_ButtonImage;
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_3_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_3_SelectImage == null )
     			{
		    		this.m_E_NanDu_3_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_3/E_NanDu_3_Select");
     			}
     			return this.m_E_NanDu_3_SelectImage;
     		}
     	}

		public UnityEngine.UI.Button E_NanDu_3_ButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_3_ButtonButton == null )
     			{
		    		this.m_E_NanDu_3_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_3/E_NanDu_3_Button");
     			}
     			return this.m_E_NanDu_3_ButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_3_ButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NanDu_3_ButtonImage == null )
     			{
		    		this.m_E_NanDu_3_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/NanDu_3/E_NanDu_3_Button");
     			}
     			return this.m_E_NanDu_3_ButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_RightBG/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftRectTransform == null )
     			{
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_RefreshTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RefreshTimeText == null )
     			{
		    		this.m_E_RefreshTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_RefreshTime");
     			}
     			return this.m_E_RefreshTimeText;
     		}
     	}

		public UnityEngine.UI.Button E_BossRefreshButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshButton == null )
     			{
		    		this.m_E_BossRefreshButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_BossRefresh");
     			}
     			return this.m_E_BossRefreshButton;
     		}
     	}

		public UnityEngine.UI.Image E_BossRefreshImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshImage == null )
     			{
		    		this.m_E_BossRefreshImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_BossRefresh");
     			}
     			return this.m_E_BossRefreshImage;
     		}
     	}

		public UnityEngine.UI.Image E_DungeonMapLevelItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DungeonMapLevelItemsImage == null )
     			{
		    		this.m_E_DungeonMapLevelItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_DungeonMapLevelItems");
     			}
     			return this.m_E_DungeonMapLevelItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_DungeonMapLevelItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DungeonMapLevelItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_DungeonMapLevelItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_DungeonMapLevelItems");
     			}
     			return this.m_E_DungeonMapLevelItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_BossRefreshCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshCloseButton == null )
     			{
		    		this.m_E_BossRefreshCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_BossRefreshClose");
     			}
     			return this.m_E_BossRefreshCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_BossRefreshCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossRefreshCloseImage == null )
     			{
		    		this.m_E_BossRefreshCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_BossRefreshClose");
     			}
     			return this.m_E_BossRefreshCloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_LevelReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelReturnButton == null )
     			{
		    		this.m_E_LevelReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LevelPanel/E_LevelReturn");
     			}
     			return this.m_E_LevelReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_LevelReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelReturnImage == null )
     			{
		    		this.m_E_LevelReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_LevelReturn");
     			}
     			return this.m_E_LevelReturnImage;
     		}
     	}

		public UnityEngine.UI.Image E_Type0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type0Image == null )
     			{
		    		this.m_E_Type0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_Type0");
     			}
     			return this.m_E_Type0Image;
     		}
     	}

		public UnityEngine.UI.Image E_Type1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type1Image == null )
     			{
		    		this.m_E_Type1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_Type1");
     			}
     			return this.m_E_Type1Image;
     		}
     	}

		public UnityEngine.UI.Image E_Type2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type2Image == null )
     			{
		    		this.m_E_Type2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_Type2");
     			}
     			return this.m_E_Type2Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_MapPanelImage = null;
			this.m_E_MapPanelDiImage = null;
			this.m_E_Map0Button = null;
			this.m_E_Map0Image = null;
			this.m_E_Map1Button = null;
			this.m_E_Map1Image = null;
			this.m_E_Map2Button = null;
			this.m_E_Map2Image = null;
			this.m_E_Map4Button = null;
			this.m_E_Map4Image = null;
			this.m_E_Map3Button = null;
			this.m_E_Map3Image = null;
			this.m_E_Map5Button = null;
			this.m_E_Map5Image = null;
			this.m_E_Map6Button = null;
			this.m_E_Map6Image = null;
			this.m_E_Map7Button = null;
			this.m_E_Map7Image = null;
			this.m_E_Map8Button = null;
			this.m_E_Map8Image = null;
			this.m_E_SelectImage = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_EG_LevelPanelRectTransform = null;
			this.m_E_RightBGImage = null;
			this.m_E_LevelNameText = null;
			this.m_E_LevelDesText = null;
			this.m_E_NanDuTipText = null;
			this.m_E_AdditionText = null;
			this.m_E_EnterLevelText = null;
			this.m_E_NanDu_1_SelectImage = null;
			this.m_E_NanDu_1_ButtonButton = null;
			this.m_E_NanDu_1_ButtonImage = null;
			this.m_E_NanDu_2_SelectImage = null;
			this.m_E_NanDu_2_ButtonButton = null;
			this.m_E_NanDu_2_ButtonImage = null;
			this.m_E_NanDu_3_SelectImage = null;
			this.m_E_NanDu_3_ButtonButton = null;
			this.m_E_NanDu_3_ButtonImage = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_EG_LeftRectTransform = null;
			this.m_E_RefreshTimeText = null;
			this.m_E_BossRefreshButton = null;
			this.m_E_BossRefreshImage = null;
			this.m_E_DungeonMapLevelItemsImage = null;
			this.m_E_DungeonMapLevelItemsLoopVerticalScrollRect = null;
			this.m_E_BossRefreshCloseButton = null;
			this.m_E_BossRefreshCloseImage = null;
			this.m_E_LevelReturnButton = null;
			this.m_E_LevelReturnImage = null;
			this.m_E_Type0Image = null;
			this.m_E_Type1Image = null;
			this.m_E_Type2Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_MapPanelImage = null;
		private UnityEngine.UI.Image m_E_MapPanelDiImage = null;
		private UnityEngine.UI.Button m_E_Map0Button = null;
		private UnityEngine.UI.Image m_E_Map0Image = null;
		private UnityEngine.UI.Button m_E_Map1Button = null;
		private UnityEngine.UI.Image m_E_Map1Image = null;
		private UnityEngine.UI.Button m_E_Map2Button = null;
		private UnityEngine.UI.Image m_E_Map2Image = null;
		private UnityEngine.UI.Button m_E_Map4Button = null;
		private UnityEngine.UI.Image m_E_Map4Image = null;
		private UnityEngine.UI.Button m_E_Map3Button = null;
		private UnityEngine.UI.Image m_E_Map3Image = null;
		private UnityEngine.UI.Button m_E_Map5Button = null;
		private UnityEngine.UI.Image m_E_Map5Image = null;
		private UnityEngine.UI.Button m_E_Map6Button = null;
		private UnityEngine.UI.Image m_E_Map6Image = null;
		private UnityEngine.UI.Button m_E_Map7Button = null;
		private UnityEngine.UI.Image m_E_Map7Image = null;
		private UnityEngine.UI.Button m_E_Map8Button = null;
		private UnityEngine.UI.Image m_E_Map8Image = null;
		private UnityEngine.UI.Image m_E_SelectImage = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.RectTransform m_EG_LevelPanelRectTransform = null;
		private UnityEngine.UI.Image m_E_RightBGImage = null;
		private UnityEngine.UI.Text m_E_LevelNameText = null;
		private UnityEngine.UI.Text m_E_LevelDesText = null;
		private UnityEngine.UI.Text m_E_NanDuTipText = null;
		private UnityEngine.UI.Text m_E_AdditionText = null;
		private UnityEngine.UI.Text m_E_EnterLevelText = null;
		private UnityEngine.UI.Image m_E_NanDu_1_SelectImage = null;
		private UnityEngine.UI.Button m_E_NanDu_1_ButtonButton = null;
		private UnityEngine.UI.Image m_E_NanDu_1_ButtonImage = null;
		private UnityEngine.UI.Image m_E_NanDu_2_SelectImage = null;
		private UnityEngine.UI.Button m_E_NanDu_2_ButtonButton = null;
		private UnityEngine.UI.Image m_E_NanDu_2_ButtonImage = null;
		private UnityEngine.UI.Image m_E_NanDu_3_SelectImage = null;
		private UnityEngine.UI.Button m_E_NanDu_3_ButtonButton = null;
		private UnityEngine.UI.Image m_E_NanDu_3_ButtonImage = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.UI.Text m_E_RefreshTimeText = null;
		private UnityEngine.UI.Button m_E_BossRefreshButton = null;
		private UnityEngine.UI.Image m_E_BossRefreshImage = null;
		private UnityEngine.UI.Image m_E_DungeonMapLevelItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_DungeonMapLevelItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_BossRefreshCloseButton = null;
		private UnityEngine.UI.Image m_E_BossRefreshCloseImage = null;
		private UnityEngine.UI.Button m_E_LevelReturnButton = null;
		private UnityEngine.UI.Image m_E_LevelReturnImage = null;
		private UnityEngine.UI.Image m_E_Type0Image = null;
		private UnityEngine.UI.Image m_E_Type1Image = null;
		private UnityEngine.UI.Image m_E_Type2Image = null;
		public Transform uiTransform = null;
	}
}
