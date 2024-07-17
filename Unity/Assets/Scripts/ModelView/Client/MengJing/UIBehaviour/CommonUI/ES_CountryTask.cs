using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CountryTask : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public GameObject[] Button_Open;
		public GameObject[] Button_Reward;
		public GameObject[] Text_Huoyue;
		public List<TaskPro> ShowTaskPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_CountryTaskItem>> ScrollItemCountryTaskItems;

		public LoopVerticalScrollRect E_CountryTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CountryTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CountryTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_CountryTaskItems");
     			}
     			return this.m_E_CountryTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public Image E_Image_progressvalueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_progressvalueImage == null )
     			{
		    		this.m_E_Image_progressvalueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Image_progressvalue");
     			}
     			return this.m_E_Image_progressvalueImage;
     		}
     	}

		public Button E_Button_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1Button == null )
     			{
		    		this.m_E_Button_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Button_1");
     			}
     			return this.m_E_Button_1Button;
     		}
     	}

		public Image E_Button_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1Image == null )
     			{
		    		this.m_E_Button_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_1");
     			}
     			return this.m_E_Button_1Image;
     		}
     	}

		public EventTrigger E_Button_1EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1EventTrigger == null )
     			{
		    		this.m_E_Button_1EventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_1");
     			}
     			return this.m_E_Button_1EventTrigger;
     		}
     	}

		public Button E_Button_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2Button == null )
     			{
		    		this.m_E_Button_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Button_2");
     			}
     			return this.m_E_Button_2Button;
     		}
     	}

		public Image E_Button_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2Image == null )
     			{
		    		this.m_E_Button_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_2");
     			}
     			return this.m_E_Button_2Image;
     		}
     	}

		public EventTrigger E_Button_2EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2EventTrigger == null )
     			{
		    		this.m_E_Button_2EventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_2");
     			}
     			return this.m_E_Button_2EventTrigger;
     		}
     	}

		public Button E_Button_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_3Button == null )
     			{
		    		this.m_E_Button_3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Button_3");
     			}
     			return this.m_E_Button_3Button;
     		}
     	}

		public Image E_Button_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_3Image == null )
     			{
		    		this.m_E_Button_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_3");
     			}
     			return this.m_E_Button_3Image;
     		}
     	}

		public EventTrigger E_Button_3EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_3EventTrigger == null )
     			{
		    		this.m_E_Button_3EventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_3");
     			}
     			return this.m_E_Button_3EventTrigger;
     		}
     	}

		public Button E_Button_4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_4Button == null )
     			{
		    		this.m_E_Button_4Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Button_4");
     			}
     			return this.m_E_Button_4Button;
     		}
     	}

		public Image E_Button_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_4Image == null )
     			{
		    		this.m_E_Button_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_4");
     			}
     			return this.m_E_Button_4Image;
     		}
     	}

		public EventTrigger E_Button_4EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_4EventTrigger == null )
     			{
		    		this.m_E_Button_4EventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_4");
     			}
     			return this.m_E_Button_4EventTrigger;
     		}
     	}

		public Image E_Button_Open_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Open_1Image == null )
     			{
		    		this.m_E_Button_Open_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_Open_1");
     			}
     			return this.m_E_Button_Open_1Image;
     		}
     	}

		public Image E_Button_Open_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Open_2Image == null )
     			{
		    		this.m_E_Button_Open_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_Open_2");
     			}
     			return this.m_E_Button_Open_2Image;
     		}
     	}

		public Image E_Button_Open_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Open_3Image == null )
     			{
		    		this.m_E_Button_Open_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_Open_3");
     			}
     			return this.m_E_Button_Open_3Image;
     		}
     	}

		public Image E_Button_Open_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Open_4Image == null )
     			{
		    		this.m_E_Button_Open_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_Open_4");
     			}
     			return this.m_E_Button_Open_4Image;
     		}
     	}

		public Text E_Text_DayHuoYueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_DayHuoYueText == null )
     			{
		    		this.m_E_Text_DayHuoYueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_DayHuoYue");
     			}
     			return this.m_E_Text_DayHuoYueText;
     		}
     	}

		public Text E_Text_Huoyue1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Huoyue1Text == null )
     			{
		    		this.m_E_Text_Huoyue1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue1");
     			}
     			return this.m_E_Text_Huoyue1Text;
     		}
     	}

		public Text E_Text_Huoyue2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Huoyue2Text == null )
     			{
		    		this.m_E_Text_Huoyue2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue2");
     			}
     			return this.m_E_Text_Huoyue2Text;
     		}
     	}

		public Text E_Text_Huoyue3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Huoyue3Text == null )
     			{
		    		this.m_E_Text_Huoyue3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue3");
     			}
     			return this.m_E_Text_Huoyue3Text;
     		}
     	}

		public Text E_Text_Huoyue4Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Huoyue4Text == null )
     			{
		    		this.m_E_Text_Huoyue4Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue4");
     			}
     			return this.m_E_Text_Huoyue4Text;
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
			this.m_E_CountryTaskItemsLoopVerticalScrollRect = null;
			this.m_E_Image_progressvalueImage = null;
			this.m_E_Button_1Button = null;
			this.m_E_Button_1Image = null;
			this.m_E_Button_1EventTrigger = null;
			this.m_E_Button_2Button = null;
			this.m_E_Button_2Image = null;
			this.m_E_Button_2EventTrigger = null;
			this.m_E_Button_3Button = null;
			this.m_E_Button_3Image = null;
			this.m_E_Button_3EventTrigger = null;
			this.m_E_Button_4Button = null;
			this.m_E_Button_4Image = null;
			this.m_E_Button_4EventTrigger = null;
			this.m_E_Button_Open_1Image = null;
			this.m_E_Button_Open_2Image = null;
			this.m_E_Button_Open_3Image = null;
			this.m_E_Button_Open_4Image = null;
			this.m_E_Text_DayHuoYueText = null;
			this.m_E_Text_Huoyue1Text = null;
			this.m_E_Text_Huoyue2Text = null;
			this.m_E_Text_Huoyue3Text = null;
			this.m_E_Text_Huoyue4Text = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_CountryTaskItemsLoopVerticalScrollRect = null;
		private Image m_E_Image_progressvalueImage = null;
		private Button m_E_Button_1Button = null;
		private Image m_E_Button_1Image = null;
		private EventTrigger m_E_Button_1EventTrigger = null;
		private Button m_E_Button_2Button = null;
		private Image m_E_Button_2Image = null;
		private EventTrigger m_E_Button_2EventTrigger = null;
		private Button m_E_Button_3Button = null;
		private Image m_E_Button_3Image = null;
		private EventTrigger m_E_Button_3EventTrigger = null;
		private Button m_E_Button_4Button = null;
		private Image m_E_Button_4Image = null;
		private EventTrigger m_E_Button_4EventTrigger = null;
		private Image m_E_Button_Open_1Image = null;
		private Image m_E_Button_Open_2Image = null;
		private Image m_E_Button_Open_3Image = null;
		private Image m_E_Button_Open_4Image = null;
		private Text m_E_Text_DayHuoYueText = null;
		private Text m_E_Text_Huoyue1Text = null;
		private Text m_E_Text_Huoyue2Text = null;
		private Text m_E_Text_Huoyue3Text = null;
		private Text m_E_Text_Huoyue4Text = null;
		public Transform uiTransform = null;
	}
}
