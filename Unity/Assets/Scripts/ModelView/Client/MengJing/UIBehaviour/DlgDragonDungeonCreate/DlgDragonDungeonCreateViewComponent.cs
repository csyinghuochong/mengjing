
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDragonDungeonCreate))]
	[EnableMethod]
	public  class DlgDragonDungeonCreateViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonButton == null )
     			{
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonImage == null )
     			{
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_DragondungeonListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DragondungeonListRectTransform == null )
     			{
		    		this.m_EG_DragondungeonListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_DragondungeonList");
     			}
     			return this.m_EG_DragondungeonListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_DragondungeonItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DragondungeonItemRectTransform == null )
     			{
		    		this.m_EG_DragondungeonItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_DragondungeonList/EG_DragondungeonItem");
     			}
     			return this.m_EG_DragondungeonItemRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_DragondungeonList/EG_DragondungeonItem/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_CreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CreateButton == null )
     			{
		    		this.m_E_Button_CreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Create");
     			}
     			return this.m_E_Button_CreateButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_CreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CreateImage == null )
     			{
		    		this.m_E_Button_CreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Create");
     			}
     			return this.m_E_Button_CreateImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextFubenName2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextFubenName2Text == null )
     			{
		    		this.m_E_TextFubenName2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextFubenName2");
     			}
     			return this.m_E_TextFubenName2Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextFubenDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextFubenDescText == null )
     			{
		    		this.m_E_TextFubenDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextFubenDesc");
     			}
     			return this.m_E_TextFubenDescText;
     		}
     	}

		public UnityEngine.UI.Text E_TextPlayerLimitText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPlayerLimitText == null )
     			{
		    		this.m_E_TextPlayerLimitText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextPlayerLimit");
     			}
     			return this.m_E_TextPlayerLimitText;
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelLimitText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelLimitText == null )
     			{
		    		this.m_E_TextLevelLimitText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextLevelLimit");
     			}
     			return this.m_E_TextLevelLimitText;
     		}
     	}

		public UnityEngine.UI.Button E_Button_XieZhuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_XieZhuButton == null )
     			{
		    		this.m_E_Button_XieZhuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_XieZhu");
     			}
     			return this.m_E_Button_XieZhuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_XieZhuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_XieZhuImage == null )
     			{
		    		this.m_E_Button_XieZhuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_XieZhu");
     			}
     			return this.m_E_Button_XieZhuImage;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.RectTransform EG_ShenYuanRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ShenYuanRectTransform == null )
     			{
		    		this.m_EG_ShenYuanRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_ShenYuan");
     			}
     			return this.m_EG_ShenYuanRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ShenYuanButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShenYuanButtonButton == null )
     			{
		    		this.m_E_ShenYuanButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_ShenYuan/E_ShenYuanButton");
     			}
     			return this.m_E_ShenYuanButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ShenYuanButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShenYuanButtonImage == null )
     			{
		    		this.m_E_ShenYuanButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_ShenYuan/E_ShenYuanButton");
     			}
     			return this.m_E_ShenYuanButtonImage;
     		}
     	}

		public UnityEngine.UI.Image E_ShenYuanModeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShenYuanModeImage == null )
     			{
		    		this.m_E_ShenYuanModeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_ShenYuan/E_ShenYuanMode");
     			}
     			return this.m_E_ShenYuanModeImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonImage = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_EG_DragondungeonListRectTransform = null;
			this.m_EG_DragondungeonItemRectTransform = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_Button_CreateButton = null;
			this.m_E_Button_CreateImage = null;
			this.m_E_TextFubenName2Text = null;
			this.m_E_TextFubenDescText = null;
			this.m_E_TextPlayerLimitText = null;
			this.m_E_TextLevelLimitText = null;
			this.m_E_Button_XieZhuButton = null;
			this.m_E_Button_XieZhuImage = null;
			this.m_es_rewardlist = null;
			this.m_EG_ShenYuanRectTransform = null;
			this.m_E_ShenYuanButtonButton = null;
			this.m_E_ShenYuanButtonImage = null;
			this.m_E_ShenYuanModeImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.RectTransform m_EG_DragondungeonListRectTransform = null;
		private UnityEngine.RectTransform m_EG_DragondungeonItemRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Button m_E_Button_CreateButton = null;
		private UnityEngine.UI.Image m_E_Button_CreateImage = null;
		private UnityEngine.UI.Text m_E_TextFubenName2Text = null;
		private UnityEngine.UI.Text m_E_TextFubenDescText = null;
		private UnityEngine.UI.Text m_E_TextPlayerLimitText = null;
		private UnityEngine.UI.Text m_E_TextLevelLimitText = null;
		private UnityEngine.UI.Button m_E_Button_XieZhuButton = null;
		private UnityEngine.UI.Image m_E_Button_XieZhuImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.RectTransform m_EG_ShenYuanRectTransform = null;
		private UnityEngine.UI.Button m_E_ShenYuanButtonButton = null;
		private UnityEngine.UI.Image m_E_ShenYuanButtonImage = null;
		private UnityEngine.UI.Image m_E_ShenYuanModeImage = null;
		public Transform uiTransform = null;
	}
}
