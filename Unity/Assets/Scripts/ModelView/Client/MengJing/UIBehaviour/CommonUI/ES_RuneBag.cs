
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RuneBag : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		/// <summary>
		/// 符文列表条目，按序号复用，多出来的隐藏
		/// </summary>
		public List<EntityRef<Scroll_Item_RuneBagItem>> BagItems = new();

		/// <summary>
		/// 加载过的资源，面板销毁时统一卸载
		/// </summary>
		public List<string> AssetList = new List<string>();

		/// <summary>
		/// 当前筛选的类型，0 表示全部，其余对应 RuneType
		/// </summary>
		public int SelectRuneType;

		/// <summary>
		/// 当前选中的符文id（RuneData.Id），0 表示没选中
		/// </summary>
		public long SelectRuneId;

		/// <summary>
		/// 是否在批量分解模式：主列表改成勾选，右侧显示分解面板
		/// </summary>
		public bool IsDecomposeMode;

		/// <summary>
		/// 分解模式里勾选的符文id，可以多选
		/// </summary>
		public List<long> SelectRuneIds = new();

		/// <summary>
		/// 分解面板里已选符文的条目，按序号复用
		/// </summary>
		public List<EntityRef<Scroll_Item_RuneBagItem>> SelectItems = new();

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
		    		this.m_E_ReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Return");
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
		    		this.m_E_ReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Return");
     			}
     			return this.m_E_ReturnImage;
     		}
     	}

		public UnityEngine.UI.Button E_StartDecomposeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartDecomposeButton == null )
     			{
		    		this.m_E_StartDecomposeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_StartDecompose");
     			}
     			return this.m_E_StartDecomposeButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartDecomposeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartDecomposeImage == null )
     			{
		    		this.m_E_StartDecomposeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_StartDecompose");
     			}
     			return this.m_E_StartDecomposeImage;
     		}
     	}

		public UnityEngine.UI.Button E_EndDecomposeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EndDecomposeButton == null )
     			{
		    		this.m_E_EndDecomposeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_EndDecompose");
     			}
     			return this.m_E_EndDecomposeButton;
     		}
     	}

		public UnityEngine.UI.Image E_EndDecomposeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EndDecomposeImage == null )
     			{
		    		this.m_E_EndDecomposeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_EndDecompose");
     			}
     			return this.m_E_EndDecomposeImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_RuneTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneTypeSetToggleGroup == null )
     			{
		    		this.m_E_RuneTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_RuneTypeSet");
     			}
     			return this.m_E_RuneTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_RuneBagItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneBagItemsScrollRect == null )
     			{
		    		this.m_E_RuneBagItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/E_RuneBagItems");
     			}
     			return this.m_E_RuneBagItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_RuneBagItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneBagItemsImage == null )
     			{
		    		this.m_E_RuneBagItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_RuneBagItems");
     			}
     			return this.m_E_RuneBagItemsImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RuneUpgradeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RuneUpgradeRectTransform == null )
     			{
		    		this.m_EG_RuneUpgradeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RuneUpgrade");
     			}
     			return this.m_EG_RuneUpgradeRectTransform;
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
		    		this.m_E_RuneIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_RuneIcon");
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
		    		this.m_E_RuneNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_RuneName");
     			}
     			return this.m_E_RuneNameText;
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
		    		this.m_E_RuneLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_RuneLv");
     			}
     			return this.m_E_RuneLvText;
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
		    		this.m_E_RuneTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_RuneType");
     			}
     			return this.m_E_RuneTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneDesc_CurrentText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneDesc_CurrentText == null )
     			{
		    		this.m_E_RuneDesc_CurrentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_RuneDesc_Current");
     			}
     			return this.m_E_RuneDesc_CurrentText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneDesc_NextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneDesc_NextText == null )
     			{
		    		this.m_E_RuneDesc_NextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_RuneDesc_Next");
     			}
     			return this.m_E_RuneDesc_NextText;
     		}
     	}

		public UnityEngine.UI.Text E_ShardNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShardNumText == null )
     			{
		    		this.m_E_ShardNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_ShardNum");
     			}
     			return this.m_E_ShardNumText;
     		}
     	}

		public UnityEngine.UI.Button E_UpgradeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpgradeButton == null )
     			{
		    		this.m_E_UpgradeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_Upgrade");
     			}
     			return this.m_E_UpgradeButton;
     		}
     	}

		public UnityEngine.UI.Image E_UpgradeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpgradeImage == null )
     			{
		    		this.m_E_UpgradeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RuneUpgrade/E_Upgrade");
     			}
     			return this.m_E_UpgradeImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RuneDecomposeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RuneDecomposeRectTransform == null )
     			{
		    		this.m_EG_RuneDecomposeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RuneDecompose");
     			}
     			return this.m_EG_RuneDecomposeRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_DecomposeRuneNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DecomposeRuneNumText == null )
     			{
		    		this.m_E_DecomposeRuneNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneDecompose/E_DecomposeRuneNum");
     			}
     			return this.m_E_DecomposeRuneNumText;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_RuneBagItems_SelectScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneBagItems_SelectScrollRect == null )
     			{
		    		this.m_E_RuneBagItems_SelectScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"EG_RuneDecompose/E_RuneBagItems_Select");
     			}
     			return this.m_E_RuneBagItems_SelectScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_RuneBagItems_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneBagItems_SelectImage == null )
     			{
		    		this.m_E_RuneBagItems_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RuneDecompose/E_RuneBagItems_Select");
     			}
     			return this.m_E_RuneBagItems_SelectImage;
     		}
     	}

		public UnityEngine.UI.Text E_DecomposeShardNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DecomposeShardNumText == null )
     			{
		    		this.m_E_DecomposeShardNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_RuneDecompose/E_DecomposeShardNum");
     			}
     			return this.m_E_DecomposeShardNumText;
     		}
     	}

		public UnityEngine.UI.Button E_DecomposeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DecomposeButton == null )
     			{
		    		this.m_E_DecomposeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_RuneDecompose/E_Decompose");
     			}
     			return this.m_E_DecomposeButton;
     		}
     	}

		public UnityEngine.UI.Image E_DecomposeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DecomposeImage == null )
     			{
		    		this.m_E_DecomposeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RuneDecompose/E_Decompose");
     			}
     			return this.m_E_DecomposeImage;
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
			this.m_E_ReturnButton = null;
			this.m_E_ReturnImage = null;
			this.m_E_StartDecomposeButton = null;
			this.m_E_StartDecomposeImage = null;
			this.m_E_EndDecomposeButton = null;
			this.m_E_EndDecomposeImage = null;
			this.m_E_RuneTypeSetToggleGroup = null;
			this.m_E_RuneBagItemsScrollRect = null;
			this.m_E_RuneBagItemsImage = null;
			this.m_EG_RuneUpgradeRectTransform = null;
			this.m_E_RuneIconImage = null;
			this.m_E_RuneNameText = null;
			this.m_E_RuneLvText = null;
			this.m_E_RuneTypeText = null;
			this.m_E_RuneDesc_CurrentText = null;
			this.m_E_RuneDesc_NextText = null;
			this.m_E_ShardNumText = null;
			this.m_E_UpgradeButton = null;
			this.m_E_UpgradeImage = null;
			this.m_EG_RuneDecomposeRectTransform = null;
			this.m_E_DecomposeRuneNumText = null;
			this.m_E_RuneBagItems_SelectScrollRect = null;
			this.m_E_RuneBagItems_SelectImage = null;
			this.m_E_DecomposeShardNumText = null;
			this.m_E_DecomposeButton = null;
			this.m_E_DecomposeImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ReturnButton = null;
		private UnityEngine.UI.Image m_E_ReturnImage = null;
		private UnityEngine.UI.Button m_E_StartDecomposeButton = null;
		private UnityEngine.UI.Image m_E_StartDecomposeImage = null;
		private UnityEngine.UI.Button m_E_EndDecomposeButton = null;
		private UnityEngine.UI.Image m_E_EndDecomposeImage = null;
		private UnityEngine.UI.ToggleGroup m_E_RuneTypeSetToggleGroup = null;
		private UnityEngine.UI.ScrollRect m_E_RuneBagItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_RuneBagItemsImage = null;
		private UnityEngine.RectTransform m_EG_RuneUpgradeRectTransform = null;
		private UnityEngine.UI.Image m_E_RuneIconImage = null;
		private UnityEngine.UI.Text m_E_RuneNameText = null;
		private UnityEngine.UI.Text m_E_RuneLvText = null;
		private UnityEngine.UI.Text m_E_RuneTypeText = null;
		private UnityEngine.UI.Text m_E_RuneDesc_CurrentText = null;
		private UnityEngine.UI.Text m_E_RuneDesc_NextText = null;
		private UnityEngine.UI.Text m_E_ShardNumText = null;
		private UnityEngine.UI.Button m_E_UpgradeButton = null;
		private UnityEngine.UI.Image m_E_UpgradeImage = null;
		private UnityEngine.RectTransform m_EG_RuneDecomposeRectTransform = null;
		private UnityEngine.UI.Text m_E_DecomposeRuneNumText = null;
		private UnityEngine.UI.ScrollRect m_E_RuneBagItems_SelectScrollRect = null;
		private UnityEngine.UI.Image m_E_RuneBagItems_SelectImage = null;
		private UnityEngine.UI.Text m_E_DecomposeShardNumText = null;
		private UnityEngine.UI.Button m_E_DecomposeButton = null;
		private UnityEngine.UI.Image m_E_DecomposeImage = null;
		public Transform uiTransform = null;
	}
}
