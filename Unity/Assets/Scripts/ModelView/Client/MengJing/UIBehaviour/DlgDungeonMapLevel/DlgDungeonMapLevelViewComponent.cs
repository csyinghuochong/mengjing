using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeonMapLevel))]
	[EnableMethod]
	public  class DlgDungeonMapLevelViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_ChapterNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChapterNameText == null )
     			{
		    		this.m_E_ChapterNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ChapterInfo/E_ChapterName");
     			}
     			return this.m_E_ChapterNameText;
     		}
     	}

		public Image E_ChapterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChapterImage == null )
     			{
		    		this.m_E_ChapterImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ChapterInfo/E_Chapter");
     			}
     			return this.m_E_ChapterImage;
     		}
     	}

		public Text E_OpenNumShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenNumShowText == null )
     			{
		    		this.m_E_OpenNumShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ChapterInfo/E_OpenNumShow");
     			}
     			return this.m_E_OpenNumShowText;
     		}
     	}

		public LoopVerticalScrollRect E_DungeonMapLevelItemsLoopVerticalScrollRect
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
		    		this.m_E_DungeonMapLevelItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_DungeonMapLevelItems");
     			}
     			return this.m_E_DungeonMapLevelItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReturnButton == null )
     			{
		    		this.m_E_ReturnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Return");
     			}
     			return this.m_E_ReturnButton;
     		}
     	}

		public Image E_ReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReturnImage == null )
     			{
		    		this.m_E_ReturnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Return");
     			}
     			return this.m_E_ReturnImage;
     		}
     	}

		public Image E_RightBGImage
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
		    		this.m_E_RightBGImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG");
     			}
     			return this.m_E_RightBGImage;
     		}
     	}

		public Text E_LevelNameText
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
		    		this.m_E_LevelNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RightBG/LevelInfo/E_LevelName");
     			}
     			return this.m_E_LevelNameText;
     		}
     	}

		public Text E_LevelDesText
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
		    		this.m_E_LevelDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RightBG/E_LevelDes");
     			}
     			return this.m_E_LevelDesText;
     		}
     	}

		public Text E_EnterLevelText
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
		    		this.m_E_EnterLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_RightBG/E_EnterLevel");
     			}
     			return this.m_E_EnterLevelText;
     		}
     	}

		public Image E_IsMetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IsMetImage == null )
     			{
		    		this.m_E_IsMetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/E_IsMet");
     			}
     			return this.m_E_IsMetImage;
     		}
     	}

		public Image E_NanDu_1_SelectImage
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
		    		this.m_E_NanDu_1_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/NanDu_1/E_NanDu_1_Select");
     			}
     			return this.m_E_NanDu_1_SelectImage;
     		}
     	}

		public Button E_NanDu_1_ButtonButton
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
		    		this.m_E_NanDu_1_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RightBG/NanDu_1/E_NanDu_1_Button");
     			}
     			return this.m_E_NanDu_1_ButtonButton;
     		}
     	}

		public Image E_NanDu_1_ButtonImage
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
		    		this.m_E_NanDu_1_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/NanDu_1/E_NanDu_1_Button");
     			}
     			return this.m_E_NanDu_1_ButtonImage;
     		}
     	}

		public Image E_NanDu_2_SelectImage
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
		    		this.m_E_NanDu_2_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/NanDu_2/E_NanDu_2_Select");
     			}
     			return this.m_E_NanDu_2_SelectImage;
     		}
     	}

		public Button E_NanDu_2_ButtonButton
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
		    		this.m_E_NanDu_2_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RightBG/NanDu_2/E_NanDu_2_Button");
     			}
     			return this.m_E_NanDu_2_ButtonButton;
     		}
     	}

		public Image E_NanDu_2_ButtonImage
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
		    		this.m_E_NanDu_2_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/NanDu_2/E_NanDu_2_Button");
     			}
     			return this.m_E_NanDu_2_ButtonImage;
     		}
     	}

		public Image E_NanDu_3_SelectImage
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
		    		this.m_E_NanDu_3_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/NanDu_3/E_NanDu_3_Select");
     			}
     			return this.m_E_NanDu_3_SelectImage;
     		}
     	}

		public Button E_NanDu_3_ButtonButton
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
		    		this.m_E_NanDu_3_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RightBG/NanDu_3/E_NanDu_3_Button");
     			}
     			return this.m_E_NanDu_3_ButtonButton;
     		}
     	}

		public Image E_NanDu_3_ButtonImage
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
		    		this.m_E_NanDu_3_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/NanDu_3/E_NanDu_3_Button");
     			}
     			return this.m_E_NanDu_3_ButtonImage;
     		}
     	}

		public Button E_EnterMapButton
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
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RightBG/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public Image E_EnterMapImage
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
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RightBG/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ChapterNameText = null;
			this.m_E_ChapterImage = null;
			this.m_E_OpenNumShowText = null;
			this.m_E_DungeonMapLevelItemsLoopVerticalScrollRect = null;
			this.m_E_ReturnButton = null;
			this.m_E_ReturnImage = null;
			this.m_E_RightBGImage = null;
			this.m_E_LevelNameText = null;
			this.m_E_LevelDesText = null;
			this.m_E_EnterLevelText = null;
			this.m_E_IsMetImage = null;
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
			this.uiTransform = null;
		}

		private Text m_E_ChapterNameText = null;
		private Image m_E_ChapterImage = null;
		private Text m_E_OpenNumShowText = null;
		private LoopVerticalScrollRect m_E_DungeonMapLevelItemsLoopVerticalScrollRect = null;
		private Button m_E_ReturnButton = null;
		private Image m_E_ReturnImage = null;
		private Image m_E_RightBGImage = null;
		private Text m_E_LevelNameText = null;
		private Text m_E_LevelDesText = null;
		private Text m_E_EnterLevelText = null;
		private Image m_E_IsMetImage = null;
		private Image m_E_NanDu_1_SelectImage = null;
		private Button m_E_NanDu_1_ButtonButton = null;
		private Image m_E_NanDu_1_ButtonImage = null;
		private Image m_E_NanDu_2_SelectImage = null;
		private Button m_E_NanDu_2_ButtonButton = null;
		private Image m_E_NanDu_2_ButtonImage = null;
		private Image m_E_NanDu_3_SelectImage = null;
		private Button m_E_NanDu_3_ButtonButton = null;
		private Image m_E_NanDu_3_ButtonImage = null;
		private Button m_E_EnterMapButton = null;
		private Image m_E_EnterMapImage = null;
		public Transform uiTransform = null;
	}
}
