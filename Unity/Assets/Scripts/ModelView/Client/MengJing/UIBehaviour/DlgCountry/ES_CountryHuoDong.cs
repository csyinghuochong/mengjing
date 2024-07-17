using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CountryHuoDong : Entity,IAwake<Transform>,IDestroy 
	{
		public RectTransform EG_UICountryTaskItem_0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UICountryTaskItem_0RectTransform == null )
     			{
		    		this.m_EG_UICountryTaskItem_0RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/EG_UICountryTaskItem_0");
     			}
     			return this.m_EG_UICountryTaskItem_0RectTransform;
     		}
     	}

		public Button E_Btn_HuoDong_ArenaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_ArenaButton == null )
     			{
		    		this.m_E_Btn_HuoDong_ArenaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_Arena");
     			}
     			return this.m_E_Btn_HuoDong_ArenaButton;
     		}
     	}

		public Image E_Btn_HuoDong_ArenaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_ArenaImage == null )
     			{
		    		this.m_E_Btn_HuoDong_ArenaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_Arena");
     			}
     			return this.m_E_Btn_HuoDong_ArenaImage;
     		}
     	}

		public Button E_Btn_HuoDong_ArenaJieShaoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_ArenaJieShaoButton == null )
     			{
		    		this.m_E_Btn_HuoDong_ArenaJieShaoButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_ArenaJieShao");
     			}
     			return this.m_E_Btn_HuoDong_ArenaJieShaoButton;
     		}
     	}

		public Image E_Btn_HuoDong_ArenaJieShaoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_ArenaJieShaoImage == null )
     			{
		    		this.m_E_Btn_HuoDong_ArenaJieShaoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_ArenaJieShao");
     			}
     			return this.m_E_Btn_HuoDong_ArenaJieShaoImage;
     		}
     	}

		public Button E_Btn_HuoDong_LingzhuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_LingzhuButton == null )
     			{
		    		this.m_E_Btn_HuoDong_LingzhuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_Lingzhu");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuButton;
     		}
     	}

		public Image E_Btn_HuoDong_LingzhuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_LingzhuImage == null )
     			{
		    		this.m_E_Btn_HuoDong_LingzhuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_Lingzhu");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuImage;
     		}
     	}

		public Button E_Btn_HuoDong_LingzhuJieShaoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_LingzhuJieShaoButton == null )
     			{
		    		this.m_E_Btn_HuoDong_LingzhuJieShaoButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_LingzhuJieShao");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuJieShaoButton;
     		}
     	}

		public Image E_Btn_HuoDong_LingzhuJieShaoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_LingzhuJieShaoImage == null )
     			{
		    		this.m_E_Btn_HuoDong_LingzhuJieShaoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_LingzhuJieShao");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuJieShaoImage;
     		}
     	}

		public Button E_Btn_HuoDong_XiaoGuiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_XiaoGuiButton == null )
     			{
		    		this.m_E_Btn_HuoDong_XiaoGuiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_5/E_Btn_HuoDong_XiaoGui");
     			}
     			return this.m_E_Btn_HuoDong_XiaoGuiButton;
     		}
     	}

		public Image E_Btn_HuoDong_XiaoGuiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_XiaoGuiImage == null )
     			{
		    		this.m_E_Btn_HuoDong_XiaoGuiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_5/E_Btn_HuoDong_XiaoGui");
     			}
     			return this.m_E_Btn_HuoDong_XiaoGuiImage;
     		}
     	}

		public Button E_Btn_HuoDong_BaozangButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_BaozangButton == null )
     			{
		    		this.m_E_Btn_HuoDong_BaozangButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_7/E_Btn_HuoDong_Baozang");
     			}
     			return this.m_E_Btn_HuoDong_BaozangButton;
     		}
     	}

		public Image E_Btn_HuoDong_BaozangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HuoDong_BaozangImage == null )
     			{
		    		this.m_E_Btn_HuoDong_BaozangImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_7/E_Btn_HuoDong_Baozang");
     			}
     			return this.m_E_Btn_HuoDong_BaozangImage;
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
			this.m_EG_UICountryTaskItem_0RectTransform = null;
			this.m_E_Btn_HuoDong_ArenaButton = null;
			this.m_E_Btn_HuoDong_ArenaImage = null;
			this.m_E_Btn_HuoDong_ArenaJieShaoButton = null;
			this.m_E_Btn_HuoDong_ArenaJieShaoImage = null;
			this.m_E_Btn_HuoDong_LingzhuButton = null;
			this.m_E_Btn_HuoDong_LingzhuImage = null;
			this.m_E_Btn_HuoDong_LingzhuJieShaoButton = null;
			this.m_E_Btn_HuoDong_LingzhuJieShaoImage = null;
			this.m_E_Btn_HuoDong_XiaoGuiButton = null;
			this.m_E_Btn_HuoDong_XiaoGuiImage = null;
			this.m_E_Btn_HuoDong_BaozangButton = null;
			this.m_E_Btn_HuoDong_BaozangImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_UICountryTaskItem_0RectTransform = null;
		private Button m_E_Btn_HuoDong_ArenaButton = null;
		private Image m_E_Btn_HuoDong_ArenaImage = null;
		private Button m_E_Btn_HuoDong_ArenaJieShaoButton = null;
		private Image m_E_Btn_HuoDong_ArenaJieShaoImage = null;
		private Button m_E_Btn_HuoDong_LingzhuButton = null;
		private Image m_E_Btn_HuoDong_LingzhuImage = null;
		private Button m_E_Btn_HuoDong_LingzhuJieShaoButton = null;
		private Image m_E_Btn_HuoDong_LingzhuJieShaoImage = null;
		private Button m_E_Btn_HuoDong_XiaoGuiButton = null;
		private Image m_E_Btn_HuoDong_XiaoGuiImage = null;
		private Button m_E_Btn_HuoDong_BaozangButton = null;
		private Image m_E_Btn_HuoDong_BaozangImage = null;
		public Transform uiTransform = null;
	}
}
