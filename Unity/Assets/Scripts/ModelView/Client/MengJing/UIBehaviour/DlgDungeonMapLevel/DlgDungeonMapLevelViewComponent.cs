
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeonMapLevel))]
	[EnableMethod]
	public  class DlgDungeonMapLevelViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_ChapterNameText
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
		    		this.m_E_ChapterNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ChapterInfo/E_ChapterName");
     			}
     			return this.m_E_ChapterNameText;
     		}
     	}

		public UnityEngine.UI.Text E_OpenNumShowText
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
		    		this.m_E_OpenNumShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ChapterInfo/E_OpenNumShow");
     			}
     			return this.m_E_OpenNumShowText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_DungeonMapItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DungeonMapItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_DungeonMapItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_DungeonMapItems");
     			}
     			return this.m_E_DungeonMapItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ReturnButton
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
		    		this.m_E_ReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Return");
     			}
     			return this.m_E_ReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReturnImage
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
		    		this.m_E_ReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Return");
     			}
     			return this.m_E_ReturnImage;
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
		    		this.m_E_LevelNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"RightBG/LevelInfo/E_LevelName");
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
		    		this.m_E_LevelDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"RightBG/E_LevelDes");
     			}
     			return this.m_E_LevelDesText;
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
		    		this.m_E_EnterLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"RightBG/E_EnterLevel");
     			}
     			return this.m_E_EnterLevelText;
     		}
     	}

		public UnityEngine.UI.Image E_IsMetImage
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
		    		this.m_E_IsMetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/E_IsMet");
     			}
     			return this.m_E_IsMetImage;
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
		    		this.m_E_NanDu_1_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/NanDu_1/E_NanDu_1_Select");
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
		    		this.m_E_NanDu_1_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"RightBG/NanDu_1/E_NanDu_1_Button");
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
		    		this.m_E_NanDu_1_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/NanDu_1/E_NanDu_1_Button");
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
		    		this.m_E_NanDu_2_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/NanDu_2/E_NanDu_2_Select");
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
		    		this.m_E_NanDu_2_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"RightBG/NanDu_2/E_NanDu_2_Button");
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
		    		this.m_E_NanDu_2_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/NanDu_2/E_NanDu_2_Button");
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
		    		this.m_E_NanDu_3_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/NanDu_3/E_NanDu_3_Select");
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
		    		this.m_E_NanDu_3_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"RightBG/NanDu_3/E_NanDu_3_Button");
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
		    		this.m_E_NanDu_3_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/NanDu_3/E_NanDu_3_Button");
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
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"RightBG/E_EnterMap");
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
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RightBG/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ChapterNameText = null;
			this.m_E_OpenNumShowText = null;
			this.m_E_DungeonMapItemsLoopVerticalScrollRect = null;
			this.m_E_ReturnButton = null;
			this.m_E_ReturnImage = null;
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

		private UnityEngine.UI.Text m_E_ChapterNameText = null;
		private UnityEngine.UI.Text m_E_OpenNumShowText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_DungeonMapItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ReturnButton = null;
		private UnityEngine.UI.Image m_E_ReturnImage = null;
		private UnityEngine.UI.Text m_E_LevelNameText = null;
		private UnityEngine.UI.Text m_E_LevelDesText = null;
		private UnityEngine.UI.Text m_E_EnterLevelText = null;
		private UnityEngine.UI.Image m_E_IsMetImage = null;
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
		public Transform uiTransform = null;
	}
}
