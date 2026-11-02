using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Rune : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		/// <summary>
		/// 孔位节点，按 Left 下的 RuneSlotItem_xx 静态节点创建
		/// </summary>
		public List<EntityRef<ES_RuneSlotItem>> SlotItems = new();

		/// <summary>
		/// 当前选中的孔位id（RuneSlotConfig.Id），0 表示没选中
		/// </summary>
		public int SelectSlotId;

		/// <summary>
		/// 镶嵌面板的符文列表，key 是列表序号，多出来的复用隐藏，和 DlgChouKaReward 一个套路
		/// </summary>
		public Dictionary<int, EntityRef<Scroll_Item_SockeRunetItem>> SocketItems = new Dictionary<int, EntityRef<Scroll_Item_SockeRunetItem>>();

		/// <summary>
		/// 镶嵌面板里当前选中的符文id（RuneData.Id），0 表示没选中
		/// </summary>
		public long SelectSocketRuneId;

		/// <summary>
		/// 镶嵌面板加载过的资源，面板销毁时统一卸载
		/// </summary>
		public List<string> AssetList = new List<string>();

		/// <summary>
		/// 符文背包（ES_RuneBag），点 E_Bag 时第一次创建，之后复用
		/// </summary>
		public EntityRef<ES_RuneBag> RuneBag;
		
		public UnityEngine.RectTransform EG_SocketRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SocketRectTransform == null )
     			{
		    		this.m_EG_SocketRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Socket");
     			}
     			return this.m_EG_SocketRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_RuneSlotType_SocketText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneSlotType_SocketText == null )
     			{
		    		this.m_E_RuneSlotType_SocketText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Socket/E_RuneSlotType_Socket");
     			}
     			return this.m_E_RuneSlotType_SocketText;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_SockeRunetItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SockeRunetItemsScrollRect == null )
     			{
		    		this.m_E_SockeRunetItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"EG_Socket/E_SockeRunetItems");
     			}
     			return this.m_E_SockeRunetItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_SockeRunetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SockeRunetItemsImage == null )
     			{
		    		this.m_E_SockeRunetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Socket/E_SockeRunetItems");
     			}
     			return this.m_E_SockeRunetItemsImage;
     		}
     	}

		public UnityEngine.UI.Button E_SocketButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SocketButton == null )
     			{
		    		this.m_E_SocketButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Socket/E_Socket");
     			}
     			return this.m_E_SocketButton;
     		}
     	}

		public UnityEngine.UI.Image E_SocketImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SocketImage == null )
     			{
		    		this.m_E_SocketImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Socket/E_Socket");
     			}
     			return this.m_E_SocketImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UnsocketRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UnsocketRectTransform == null )
     			{
		    		this.m_EG_UnsocketRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Unsocket");
     			}
     			return this.m_EG_UnsocketRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_RuneIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneIconImage == null )
     			{
		    		this.m_E_RuneIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Unsocket/E_RuneIcon");
     			}
     			return this.m_E_RuneIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_RuneNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneNameText == null )
     			{
		    		this.m_E_RuneNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Unsocket/E_RuneName");
     			}
     			return this.m_E_RuneNameText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneLv_UnsocketText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneLv_UnsocketText == null )
     			{
		    		this.m_E_RuneLv_UnsocketText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Unsocket/E_RuneLv_Unsocket");
     			}
     			return this.m_E_RuneLv_UnsocketText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneTypeText == null )
     			{
		    		this.m_E_RuneTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Unsocket/E_RuneType");
     			}
     			return this.m_E_RuneTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneDescText == null )
     			{
		    		this.m_E_RuneDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Unsocket/E_RuneDesc");
     			}
     			return this.m_E_RuneDescText;
     		}
     	}

		public UnityEngine.UI.Button E_UnsocketButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnsocketButton == null )
     			{
		    		this.m_E_UnsocketButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Unsocket/E_Unsocket");
     			}
     			return this.m_E_UnsocketButton;
     		}
     	}

		public UnityEngine.UI.Image E_UnsocketImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnsocketImage == null )
     			{
		    		this.m_E_UnsocketImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Unsocket/E_Unsocket");
     			}
     			return this.m_E_UnsocketImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UnlockSlotRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UnlockSlotRectTransform == null )
     			{
		    		this.m_EG_UnlockSlotRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UnlockSlot");
     			}
     			return this.m_EG_UnlockSlotRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_RuneSlotType_UnlockSlotText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneSlotType_UnlockSlotText == null )
     			{
		    		this.m_E_RuneSlotType_UnlockSlotText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UnlockSlot/E_RuneSlotType_UnlockSlot");
     			}
     			return this.m_E_RuneSlotType_UnlockSlotText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerLvText == null )
     			{
		    		this.m_E_PlayerLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UnlockSlot/Image/E_PlayerLv");
     			}
     			return this.m_E_PlayerLvText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLvTargetText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerLvTargetText == null )
     			{
		    		this.m_E_PlayerLvTargetText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UnlockSlot/Image/E_PlayerLvTarget");
     			}
     			return this.m_E_PlayerLvTargetText;
     		}
     	}

		public UnityEngine.UI.Image E_LodingValue_PlayerLvImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LodingValue_PlayerLvImage == null )
     			{
		    		this.m_E_LodingValue_PlayerLvImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UnlockSlot/Image/E_LodingValue_PlayerLv");
     			}
     			return this.m_E_LodingValue_PlayerLvImage;
     		}
     	}

		public UnityEngine.UI.Text E_RuneLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneLvText == null )
     			{
		    		this.m_E_RuneLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UnlockSlot/Image (3)/E_RuneLv");
     			}
     			return this.m_E_RuneLvText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneLvTargetText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneLvTargetText == null )
     			{
		    		this.m_E_RuneLvTargetText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UnlockSlot/Image (3)/E_RuneLvTarget");
     			}
     			return this.m_E_RuneLvTargetText;
     		}
     	}

		public UnityEngine.UI.Image E_LodingValue_RuneLvImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LodingValue_RuneLvImage == null )
     			{
		    		this.m_E_LodingValue_RuneLvImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UnlockSlot/Image (3)/E_LodingValue_RuneLv");
     			}
     			return this.m_E_LodingValue_RuneLvImage;
     		}
     	}

		public UnityEngine.UI.Text E_RuneSlotDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneSlotDesText == null )
     			{
		    		this.m_E_RuneSlotDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UnlockSlot/E_RuneSlotDes");
     			}
     			return this.m_E_RuneSlotDesText;
     		}
     	}

		public UnityEngine.UI.Button E_UnlockSlotButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnlockSlotButton == null )
     			{
		    		this.m_E_UnlockSlotButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UnlockSlot/E_UnlockSlot");
     			}
     			return this.m_E_UnlockSlotButton;
     		}
     	}

		public UnityEngine.UI.Image E_UnlockSlotImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnlockSlotImage == null )
     			{
		    		this.m_E_UnlockSlotImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UnlockSlot/E_UnlockSlot");
     			}
     			return this.m_E_UnlockSlotImage;
     		}
     	}

		public UnityEngine.UI.Button E_BagButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagButton == null )
     			{
		    		this.m_E_BagButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Bag");
     			}
     			return this.m_E_BagButton;
     		}
     	}

		public UnityEngine.UI.Image E_BagImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagImage == null )
     			{
		    		this.m_E_BagImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Bag");
     			}
     			return this.m_E_BagImage;
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
			this.m_EG_SocketRectTransform = null;
			this.m_E_RuneSlotType_SocketText = null;
			this.m_E_SockeRunetItemsScrollRect = null;
			this.m_E_SockeRunetItemsImage = null;
			this.m_E_SocketButton = null;
			this.m_E_SocketImage = null;
			this.m_EG_UnsocketRectTransform = null;
			this.m_E_RuneIconImage = null;
			this.m_E_RuneNameText = null;
			this.m_E_RuneLv_UnsocketText = null;
			this.m_E_RuneTypeText = null;
			this.m_E_RuneDescText = null;
			this.m_E_UnsocketButton = null;
			this.m_E_UnsocketImage = null;
			this.m_EG_UnlockSlotRectTransform = null;
			this.m_E_RuneSlotType_UnlockSlotText = null;
			this.m_E_PlayerLvText = null;
			this.m_E_PlayerLvTargetText = null;
			this.m_E_LodingValue_PlayerLvImage = null;
			this.m_E_RuneLvText = null;
			this.m_E_RuneLvTargetText = null;
			this.m_E_LodingValue_RuneLvImage = null;
			this.m_E_RuneSlotDesText = null;
			this.m_E_UnlockSlotButton = null;
			this.m_E_UnlockSlotImage = null;
			this.m_E_BagButton = null;
			this.m_E_BagImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SocketRectTransform = null;
		private UnityEngine.UI.Text m_E_RuneSlotType_SocketText = null;
		private UnityEngine.UI.ScrollRect m_E_SockeRunetItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_SockeRunetItemsImage = null;
		private UnityEngine.UI.Button m_E_SocketButton = null;
		private UnityEngine.UI.Image m_E_SocketImage = null;
		private UnityEngine.RectTransform m_EG_UnsocketRectTransform = null;
		private UnityEngine.UI.Image m_E_RuneIconImage = null;
		private UnityEngine.UI.Text m_E_RuneNameText = null;
		private UnityEngine.UI.Text m_E_RuneLv_UnsocketText = null;
		private UnityEngine.UI.Text m_E_RuneTypeText = null;
		private UnityEngine.UI.Text m_E_RuneDescText = null;
		private UnityEngine.UI.Button m_E_UnsocketButton = null;
		private UnityEngine.UI.Image m_E_UnsocketImage = null;
		private UnityEngine.RectTransform m_EG_UnlockSlotRectTransform = null;
		private UnityEngine.UI.Text m_E_RuneSlotType_UnlockSlotText = null;
		private UnityEngine.UI.Text m_E_PlayerLvText = null;
		private UnityEngine.UI.Text m_E_PlayerLvTargetText = null;
		private UnityEngine.UI.Image m_E_LodingValue_PlayerLvImage = null;
		private UnityEngine.UI.Text m_E_RuneLvText = null;
		private UnityEngine.UI.Text m_E_RuneLvTargetText = null;
		private UnityEngine.UI.Image m_E_LodingValue_RuneLvImage = null;
		private UnityEngine.UI.Text m_E_RuneSlotDesText = null;
		private UnityEngine.UI.Button m_E_UnlockSlotButton = null;
		private UnityEngine.UI.Image m_E_UnlockSlotImage = null;
		private UnityEngine.UI.Button m_E_BagButton = null;
		private UnityEngine.UI.Image m_E_BagImage = null;
		public Transform uiTransform = null;
	}
}
