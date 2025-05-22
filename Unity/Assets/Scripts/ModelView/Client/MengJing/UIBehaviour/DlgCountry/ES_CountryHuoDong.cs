
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CountryHuoDong : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EG_UICountryTaskItem_0RectTransform
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
		    		this.m_EG_UICountryTaskItem_0RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/EG_UICountryTaskItem_0");
     			}
     			return this.m_EG_UICountryTaskItem_0RectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HuoDong_ArenaButton
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
		    		this.m_E_Btn_HuoDong_ArenaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_Arena");
     			}
     			return this.m_E_Btn_HuoDong_ArenaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HuoDong_ArenaImage
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
		    		this.m_E_Btn_HuoDong_ArenaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_Arena");
     			}
     			return this.m_E_Btn_HuoDong_ArenaImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HuoDong_ArenaJieShaoButton
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
		    		this.m_E_Btn_HuoDong_ArenaJieShaoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_ArenaJieShao");
     			}
     			return this.m_E_Btn_HuoDong_ArenaJieShaoButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HuoDong_ArenaJieShaoImage
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
		    		this.m_E_Btn_HuoDong_ArenaJieShaoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_3/E_Btn_HuoDong_ArenaJieShao");
     			}
     			return this.m_E_Btn_HuoDong_ArenaJieShaoImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HuoDong_LingzhuButton
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
		    		this.m_E_Btn_HuoDong_LingzhuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_Lingzhu");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HuoDong_LingzhuImage
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
		    		this.m_E_Btn_HuoDong_LingzhuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_Lingzhu");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HuoDong_LingzhuJieShaoButton
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
		    		this.m_E_Btn_HuoDong_LingzhuJieShaoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_LingzhuJieShao");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuJieShaoButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HuoDong_LingzhuJieShaoImage
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
		    		this.m_E_Btn_HuoDong_LingzhuJieShaoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_4/E_Btn_HuoDong_LingzhuJieShao");
     			}
     			return this.m_E_Btn_HuoDong_LingzhuJieShaoImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HuoDong_XiaoGuiButton
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
		    		this.m_E_Btn_HuoDong_XiaoGuiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_5/E_Btn_HuoDong_XiaoGui");
     			}
     			return this.m_E_Btn_HuoDong_XiaoGuiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HuoDong_XiaoGuiImage
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
		    		this.m_E_Btn_HuoDong_XiaoGuiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_5/E_Btn_HuoDong_XiaoGui");
     			}
     			return this.m_E_Btn_HuoDong_XiaoGuiImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HuoDong_BaozangButton
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
		    		this.m_E_Btn_HuoDong_BaozangButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_7/E_Btn_HuoDong_Baozang");
     			}
     			return this.m_E_Btn_HuoDong_BaozangButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HuoDong_BaozangImage
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
		    		this.m_E_Btn_HuoDong_BaozangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Right/ScrollView_1/Viewport/TaskListNode/UICountryTaskItem_7/E_Btn_HuoDong_Baozang");
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

		private UnityEngine.RectTransform m_EG_UICountryTaskItem_0RectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_HuoDong_ArenaButton = null;
		private UnityEngine.UI.Image m_E_Btn_HuoDong_ArenaImage = null;
		private UnityEngine.UI.Button m_E_Btn_HuoDong_ArenaJieShaoButton = null;
		private UnityEngine.UI.Image m_E_Btn_HuoDong_ArenaJieShaoImage = null;
		private UnityEngine.UI.Button m_E_Btn_HuoDong_LingzhuButton = null;
		private UnityEngine.UI.Image m_E_Btn_HuoDong_LingzhuImage = null;
		private UnityEngine.UI.Button m_E_Btn_HuoDong_LingzhuJieShaoButton = null;
		private UnityEngine.UI.Image m_E_Btn_HuoDong_LingzhuJieShaoImage = null;
		private UnityEngine.UI.Button m_E_Btn_HuoDong_XiaoGuiButton = null;
		private UnityEngine.UI.Image m_E_Btn_HuoDong_XiaoGuiImage = null;
		private UnityEngine.UI.Button m_E_Btn_HuoDong_BaozangButton = null;
		private UnityEngine.UI.Image m_E_Btn_HuoDong_BaozangImage = null;
		public Transform uiTransform = null;
	}
}
