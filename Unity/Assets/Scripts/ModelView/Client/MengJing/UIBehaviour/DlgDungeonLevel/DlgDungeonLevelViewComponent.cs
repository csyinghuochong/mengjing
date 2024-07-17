using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeonLevel))]
	[EnableMethod]
	public  class DlgDungeonLevelViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_NanDu_1_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"NanDu_1/E_NanDu_1_Button");
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
		    		this.m_E_NanDu_1_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NanDu_1/E_NanDu_1_Button");
     			}
     			return this.m_E_NanDu_1_ButtonImage;
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
		    		this.m_E_NanDu_1_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NanDu_1/E_NanDu_1_Select");
     			}
     			return this.m_E_NanDu_1_SelectImage;
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
		    		this.m_E_NanDu_2_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"NanDu_2/E_NanDu_2_Button");
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
		    		this.m_E_NanDu_2_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NanDu_2/E_NanDu_2_Button");
     			}
     			return this.m_E_NanDu_2_ButtonImage;
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
		    		this.m_E_NanDu_2_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NanDu_2/E_NanDu_2_Select");
     			}
     			return this.m_E_NanDu_2_SelectImage;
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
		    		this.m_E_NanDu_3_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"NanDu_3/E_NanDu_3_Button");
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
		    		this.m_E_NanDu_3_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NanDu_3/E_NanDu_3_Button");
     			}
     			return this.m_E_NanDu_3_ButtonImage;
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
		    		this.m_E_NanDu_3_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NanDu_3/E_NanDu_3_Select");
     			}
     			return this.m_E_NanDu_3_SelectImage;
     		}
     	}

		public LoopVerticalScrollRect E_DungeonLevelItemLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DungeonLevelItemLoopVerticalScrollRect == null )
     			{
		    		this.m_E_DungeonLevelItemLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_DungeonLevelItem");
     			}
     			return this.m_E_DungeonLevelItemLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"GameObject/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"GameObject/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public Text E_Lab_LevelNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_LevelNameText == null )
     			{
		    		this.m_E_Lab_LevelNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"GameObject/E_Lab_LevelName");
     			}
     			return this.m_E_Lab_LevelNameText;
     		}
     	}

		public Text E_Lab_OpenNumShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_OpenNumShowText == null )
     			{
		    		this.m_E_Lab_OpenNumShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"GameObject/E_Lab_OpenNumShow");
     			}
     			return this.m_E_Lab_OpenNumShowText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_NanDu_1_ButtonButton = null;
			this.m_E_NanDu_1_ButtonImage = null;
			this.m_E_NanDu_1_SelectImage = null;
			this.m_E_NanDu_2_ButtonButton = null;
			this.m_E_NanDu_2_ButtonImage = null;
			this.m_E_NanDu_2_SelectImage = null;
			this.m_E_NanDu_3_ButtonButton = null;
			this.m_E_NanDu_3_ButtonImage = null;
			this.m_E_NanDu_3_SelectImage = null;
			this.m_E_DungeonLevelItemLoopVerticalScrollRect = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_Lab_LevelNameText = null;
			this.m_E_Lab_OpenNumShowText = null;
			this.uiTransform = null;
		}

		private Button m_E_NanDu_1_ButtonButton = null;
		private Image m_E_NanDu_1_ButtonImage = null;
		private Image m_E_NanDu_1_SelectImage = null;
		private Button m_E_NanDu_2_ButtonButton = null;
		private Image m_E_NanDu_2_ButtonImage = null;
		private Image m_E_NanDu_2_SelectImage = null;
		private Button m_E_NanDu_3_ButtonButton = null;
		private Image m_E_NanDu_3_ButtonImage = null;
		private Image m_E_NanDu_3_SelectImage = null;
		private LoopVerticalScrollRect m_E_DungeonLevelItemLoopVerticalScrollRect = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private Text m_E_Lab_LevelNameText = null;
		private Text m_E_Lab_OpenNumShowText = null;
		public Transform uiTransform = null;
	}
}
