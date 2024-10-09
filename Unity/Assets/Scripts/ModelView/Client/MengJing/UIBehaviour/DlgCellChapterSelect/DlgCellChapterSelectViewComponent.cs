
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCellChapterSelect))]
	[EnableMethod]
	public  class DlgCellChapterSelectViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_MapPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MapPanelRectTransform == null )
     			{
		    		this.m_EG_MapPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MapPanel");
     			}
     			return this.m_EG_MapPanelRectTransform;
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

		public UnityEngine.UI.Image E_BlackBGImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BlackBGImage == null )
     			{
		    		this.m_E_BlackBGImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/E_BlackBG");
     			}
     			return this.m_E_BlackBGImage;
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

		public UnityEngine.UI.Image E_CellDungeonItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CellDungeonItemsImage == null )
     			{
		    		this.m_E_CellDungeonItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_CellDungeonItems");
     			}
     			return this.m_E_CellDungeonItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CellDungeonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CellDungeonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CellDungeonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_LevelPanel/EG_Left/E_CellDungeonItems");
     			}
     			return this.m_E_CellDungeonItemsLoopVerticalScrollRect;
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

		public void DestroyWidget()
		{
			this.m_EG_MapPanelRectTransform = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_EG_LevelPanelRectTransform = null;
			this.m_E_BlackBGImage = null;
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
			this.m_E_CellDungeonItemsImage = null;
			this.m_E_CellDungeonItemsLoopVerticalScrollRect = null;
			this.m_E_LevelReturnButton = null;
			this.m_E_LevelReturnImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_MapPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.RectTransform m_EG_LevelPanelRectTransform = null;
		private UnityEngine.UI.Image m_E_BlackBGImage = null;
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
		private UnityEngine.UI.Image m_E_CellDungeonItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CellDungeonItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_LevelReturnButton = null;
		private UnityEngine.UI.Image m_E_LevelReturnImage = null;
		public Transform uiTransform = null;
	}
}
