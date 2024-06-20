
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CountryTask : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public GameObject[] Button_Open;
		public GameObject[] Button_Reward;
		public GameObject[] Text_Huoyue;
		public List<TaskPro> ShowTaskPros = new();
		public Dictionary<int, Scroll_Item_CountryTaskItem> ScrollItemCountryTaskItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_CountryTaskItemsLoopVerticalScrollRect
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
		    		this.m_E_CountryTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_CountryTaskItems");
     			}
     			return this.m_E_CountryTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_Image_progressvalueImage
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
		    		this.m_E_Image_progressvalueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Image_progressvalue");
     			}
     			return this.m_E_Image_progressvalueImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_1Button
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
		    		this.m_E_Button_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_1");
     			}
     			return this.m_E_Button_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_1Image
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
		    		this.m_E_Button_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_1");
     			}
     			return this.m_E_Button_1Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Button_1EventTrigger
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
		    		this.m_E_Button_1EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_1");
     			}
     			return this.m_E_Button_1EventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Button_2Button
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
		    		this.m_E_Button_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_2");
     			}
     			return this.m_E_Button_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_2Image
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
		    		this.m_E_Button_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_2");
     			}
     			return this.m_E_Button_2Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Button_2EventTrigger
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
		    		this.m_E_Button_2EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_2");
     			}
     			return this.m_E_Button_2EventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Button_3Button
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
		    		this.m_E_Button_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_3");
     			}
     			return this.m_E_Button_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_3Image
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
		    		this.m_E_Button_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_3");
     			}
     			return this.m_E_Button_3Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Button_3EventTrigger
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
		    		this.m_E_Button_3EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_3");
     			}
     			return this.m_E_Button_3EventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Button_4Button
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
		    		this.m_E_Button_4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_4");
     			}
     			return this.m_E_Button_4Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_4Image
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
		    		this.m_E_Button_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_4");
     			}
     			return this.m_E_Button_4Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Button_4EventTrigger
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
		    		this.m_E_Button_4EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_Button_4");
     			}
     			return this.m_E_Button_4EventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Open_1Image
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
		    		this.m_E_Button_Open_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Open_1");
     			}
     			return this.m_E_Button_Open_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Open_2Image
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
		    		this.m_E_Button_Open_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Open_2");
     			}
     			return this.m_E_Button_Open_2Image;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Open_3Image
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
		    		this.m_E_Button_Open_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Open_3");
     			}
     			return this.m_E_Button_Open_3Image;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Open_4Image
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
		    		this.m_E_Button_Open_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Open_4");
     			}
     			return this.m_E_Button_Open_4Image;
     		}
     	}

		public UnityEngine.UI.Text E_Text_DayHuoYueText
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
		    		this.m_E_Text_DayHuoYueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_DayHuoYue");
     			}
     			return this.m_E_Text_DayHuoYueText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Huoyue1Text
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
		    		this.m_E_Text_Huoyue1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue1");
     			}
     			return this.m_E_Text_Huoyue1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Huoyue2Text
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
		    		this.m_E_Text_Huoyue2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue2");
     			}
     			return this.m_E_Text_Huoyue2Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Huoyue3Text
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
		    		this.m_E_Text_Huoyue3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue3");
     			}
     			return this.m_E_Text_Huoyue3Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Huoyue4Text
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
		    		this.m_E_Text_Huoyue4Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Huoyue4");
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

		private UnityEngine.UI.LoopVerticalScrollRect m_E_CountryTaskItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_Image_progressvalueImage = null;
		private UnityEngine.UI.Button m_E_Button_1Button = null;
		private UnityEngine.UI.Image m_E_Button_1Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Button_1EventTrigger = null;
		private UnityEngine.UI.Button m_E_Button_2Button = null;
		private UnityEngine.UI.Image m_E_Button_2Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Button_2EventTrigger = null;
		private UnityEngine.UI.Button m_E_Button_3Button = null;
		private UnityEngine.UI.Image m_E_Button_3Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Button_3EventTrigger = null;
		private UnityEngine.UI.Button m_E_Button_4Button = null;
		private UnityEngine.UI.Image m_E_Button_4Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Button_4EventTrigger = null;
		private UnityEngine.UI.Image m_E_Button_Open_1Image = null;
		private UnityEngine.UI.Image m_E_Button_Open_2Image = null;
		private UnityEngine.UI.Image m_E_Button_Open_3Image = null;
		private UnityEngine.UI.Image m_E_Button_Open_4Image = null;
		private UnityEngine.UI.Text m_E_Text_DayHuoYueText = null;
		private UnityEngine.UI.Text m_E_Text_Huoyue1Text = null;
		private UnityEngine.UI.Text m_E_Text_Huoyue2Text = null;
		private UnityEngine.UI.Text m_E_Text_Huoyue3Text = null;
		private UnityEngine.UI.Text m_E_Text_Huoyue4Text = null;
		public Transform uiTransform = null;
	}
}
