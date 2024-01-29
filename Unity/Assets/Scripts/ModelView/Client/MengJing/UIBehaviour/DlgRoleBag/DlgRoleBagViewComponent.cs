
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleBag))]
	[EnableMethod]
	public  class DlgRoleBagViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_AllToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AllToggle == null )
     			{
		    		this.m_E_AllToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_All");
     			}
     			return this.m_E_AllToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_EquipToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipToggle == null )
     			{
		    		this.m_E_EquipToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_Equip");
     			}
     			return this.m_E_EquipToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_CaiLiaoToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CaiLiaoToggle == null )
     			{
		    		this.m_E_CaiLiaoToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_CaiLiao");
     			}
     			return this.m_E_CaiLiaoToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_XiaoHaoToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiaoHaoToggle == null )
     			{
		    		this.m_E_XiaoHaoToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_ItemTypeSet/E_XiaoHao");
     			}
     			return this.m_E_XiaoHaoToggle;
     		}
     	}

		public UnityEngine.UI.Button E_ZhengLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhengLiButton == null )
     			{
		    		this.m_E_ZhengLiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ZhengLi");
     			}
     			return this.m_E_ZhengLiButton;
     		}
     	}

		public UnityEngine.UI.Image E_ZhengLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhengLiImage == null )
     			{
		    		this.m_E_ZhengLiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ZhengLi");
     			}
     			return this.m_E_ZhengLiImage;
     		}
     	}

		public UnityEngine.UI.Button E_OneSellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneSellButton == null )
     			{
		    		this.m_E_OneSellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_OneSell");
     			}
     			return this.m_E_OneSellButton;
     		}
     	}

		public UnityEngine.UI.Image E_OneSellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneSellImage == null )
     			{
		    		this.m_E_OneSellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_OneSell");
     			}
     			return this.m_E_OneSellImage;
     		}
     	}

		public UnityEngine.UI.Button E_OneGemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneGemButton == null )
     			{
		    		this.m_E_OneGemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_OneGem");
     			}
     			return this.m_E_OneGemButton;
     		}
     	}

		public UnityEngine.UI.Image E_OneGemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneGemImage == null )
     			{
		    		this.m_E_OneGemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_OneGem");
     			}
     			return this.m_E_OneGemImage;
     		}
     	}

		public UnityEngine.UI.Button E_OpenOneSellSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenOneSellSetButton == null )
     			{
		    		this.m_E_OpenOneSellSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_OpenOneSellSet");
     			}
     			return this.m_E_OpenOneSellSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_OpenOneSellSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenOneSellSetImage == null )
     			{
		    		this.m_E_OpenOneSellSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_OpenOneSellSet");
     			}
     			return this.m_E_OpenOneSellSetImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_AllToggle = null;
			this.m_E_EquipToggle = null;
			this.m_E_CaiLiaoToggle = null;
			this.m_E_XiaoHaoToggle = null;
			this.m_E_ZhengLiButton = null;
			this.m_E_ZhengLiImage = null;
			this.m_E_OneSellButton = null;
			this.m_E_OneSellImage = null;
			this.m_E_OneGemButton = null;
			this.m_E_OneGemImage = null;
			this.m_E_OpenOneSellSetButton = null;
			this.m_E_OpenOneSellSetImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_AllToggle = null;
		private UnityEngine.UI.Toggle m_E_EquipToggle = null;
		private UnityEngine.UI.Toggle m_E_CaiLiaoToggle = null;
		private UnityEngine.UI.Toggle m_E_XiaoHaoToggle = null;
		private UnityEngine.UI.Button m_E_ZhengLiButton = null;
		private UnityEngine.UI.Image m_E_ZhengLiImage = null;
		private UnityEngine.UI.Button m_E_OneSellButton = null;
		private UnityEngine.UI.Image m_E_OneSellImage = null;
		private UnityEngine.UI.Button m_E_OneGemButton = null;
		private UnityEngine.UI.Image m_E_OneGemImage = null;
		private UnityEngine.UI.Button m_E_OpenOneSellSetButton = null;
		private UnityEngine.UI.Image m_E_OpenOneSellSetImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
