using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanPetWalkItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanPetWalkItem>
	{
		public GameObject[] ImageMood_List = new GameObject[5];
		public RolePetInfo RolePetInfo;

		public int Position { get; set; }
		public Action<int> ClickAddHandler;
		public Action ClickStopHandler;

		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanPetWalkItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public RectTransform EG_SetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EG_SetRectTransform == null )
     				{
		    			this.m_EG_SetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Set");
     				}
     				return this.m_EG_SetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Set");
     			}
     		}
     	}

		public Image E_ImagePetIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImagePetIconImage == null )
     				{
		    			this.m_E_ImagePetIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImagePetIcon");
     				}
     				return this.m_E_ImagePetIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImagePetIcon");
     			}
     		}
     	}

		public Button E_Button_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_AddButton == null )
     				{
		    			this.m_E_Button_AddButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Set/E_Button_Add");
     				}
     				return this.m_E_Button_AddButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Set/E_Button_Add");
     			}
     		}
     	}

		public Image E_Button_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_AddImage == null )
     				{
		    			this.m_E_Button_AddImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_Button_Add");
     				}
     				return this.m_E_Button_AddImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_Button_Add");
     			}
     		}
     	}

		public Image E_ImageMood_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageMood_0Image == null )
     				{
		    			this.m_E_ImageMood_0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_0");
     				}
     				return this.m_E_ImageMood_0Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_0");
     			}
     		}
     	}

		public Image E_ImageMood_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageMood_1Image == null )
     				{
		    			this.m_E_ImageMood_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_1");
     				}
     				return this.m_E_ImageMood_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_1");
     			}
     		}
     	}

		public Image E_ImageMood_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageMood_2Image == null )
     				{
		    			this.m_E_ImageMood_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_2");
     				}
     				return this.m_E_ImageMood_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_2");
     			}
     		}
     	}

		public Image E_ImageMood_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageMood_3Image == null )
     				{
		    			this.m_E_ImageMood_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_3");
     				}
     				return this.m_E_ImageMood_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_3");
     			}
     		}
     	}

		public Image E_ImageMood_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageMood_4Image == null )
     				{
		    			this.m_E_ImageMood_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_4");
     				}
     				return this.m_E_ImageMood_4Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_ImageMood_4");
     			}
     		}
     	}

		public Button E_Button_StopButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_StopButton == null )
     				{
		    			this.m_E_Button_StopButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Set/E_Button_Stop");
     				}
     				return this.m_E_Button_StopButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Set/E_Button_Stop");
     			}
     		}
     	}

		public Image E_Button_StopImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_StopImage == null )
     				{
		    			this.m_E_Button_StopImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_Button_Stop");
     				}
     				return this.m_E_Button_StopImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_Button_Stop");
     			}
     		}
     	}

		public Button E_Button_WalkButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_WalkButton == null )
     				{
		    			this.m_E_Button_WalkButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Set/E_Button_Walk");
     				}
     				return this.m_E_Button_WalkButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Set/E_Button_Walk");
     			}
     		}
     	}

		public Image E_Button_WalkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_WalkImage == null )
     				{
		    			this.m_E_Button_WalkImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_Button_Walk");
     				}
     				return this.m_E_Button_WalkImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Set/E_Button_Walk");
     			}
     		}
     	}

		public Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_Name");
     			}
     		}
     	}

		public Text E_Text_LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_LevelText == null )
     				{
		    			this.m_E_Text_LevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_Level");
     				}
     				return this.m_E_Text_LevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_Level");
     			}
     		}
     	}

		public Text E_Text_Tip_121Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_Tip_121Text == null )
     				{
		    			this.m_E_Text_Tip_121Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_Tip_121");
     				}
     				return this.m_E_Text_Tip_121Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_Tip_121");
     			}
     		}
     	}

		public Text E_Text_TotalExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_TotalExpText == null )
     				{
		    			this.m_E_Text_TotalExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_TotalExp");
     				}
     				return this.m_E_Text_TotalExpText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_TotalExp");
     			}
     		}
     	}

		public Text E_Text_TotalExpHourText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_TotalExpHourText == null )
     				{
		    			this.m_E_Text_TotalExpHourText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_TotalExpHour");
     				}
     				return this.m_E_Text_TotalExpHourText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Set/E_Text_TotalExpHour");
     			}
     		}
     	}

		public Image E_Image_LockImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Image_LockImage == null )
     				{
		    			this.m_E_Image_LockImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Lock");
     				}
     				return this.m_E_Image_LockImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Lock");
     			}
     		}
     	}

		public Text E_OpenLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_OpenLvText == null )
     				{
		    			this.m_E_OpenLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Image_Lock/E_OpenLv");
     				}
     				return this.m_E_OpenLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Image_Lock/E_OpenLv");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SetRectTransform = null;
			this.m_E_ImagePetIconImage = null;
			this.m_E_Button_AddButton = null;
			this.m_E_Button_AddImage = null;
			this.m_E_ImageMood_0Image = null;
			this.m_E_ImageMood_1Image = null;
			this.m_E_ImageMood_2Image = null;
			this.m_E_ImageMood_3Image = null;
			this.m_E_ImageMood_4Image = null;
			this.m_E_Button_StopButton = null;
			this.m_E_Button_StopImage = null;
			this.m_E_Button_WalkButton = null;
			this.m_E_Button_WalkImage = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_LevelText = null;
			this.m_E_Text_Tip_121Text = null;
			this.m_E_Text_TotalExpText = null;
			this.m_E_Text_TotalExpHourText = null;
			this.m_E_Image_LockImage = null;
			this.m_E_OpenLvText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private RectTransform m_EG_SetRectTransform = null;
		private Image m_E_ImagePetIconImage = null;
		private Button m_E_Button_AddButton = null;
		private Image m_E_Button_AddImage = null;
		private Image m_E_ImageMood_0Image = null;
		private Image m_E_ImageMood_1Image = null;
		private Image m_E_ImageMood_2Image = null;
		private Image m_E_ImageMood_3Image = null;
		private Image m_E_ImageMood_4Image = null;
		private Button m_E_Button_StopButton = null;
		private Image m_E_Button_StopImage = null;
		private Button m_E_Button_WalkButton = null;
		private Image m_E_Button_WalkImage = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_LevelText = null;
		private Text m_E_Text_Tip_121Text = null;
		private Text m_E_Text_TotalExpText = null;
		private Text m_E_Text_TotalExpHourText = null;
		private Image m_E_Image_LockImage = null;
		private Text m_E_OpenLvText = null;
		public Transform uiTransform = null;
	}
}
