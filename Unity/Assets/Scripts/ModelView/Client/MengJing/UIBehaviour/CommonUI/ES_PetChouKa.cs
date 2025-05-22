
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetChouKa : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Dictionary<int, EntityRef<Scroll_Item_PetChouKaItem>> ScrollItemPetChouKaItems = new();
		public List<RewardItem> RewardShowItems = new();

		public long Interval = 0; //匀速
		public int TargetIndex = 0;
		public int CurrentIndex = 0;
		public bool OnStopTurn;
		public bool ifStop;
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.ScrollRect E_BagItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsScrollRect == null )
     			{
		    		this.m_E_BagItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems");
     			}
     			return this.m_E_BagItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_BagItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsImage == null )
     			{
		    		this.m_E_BagItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_BagItems");
     			}
     			return this.m_E_BagItemsImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenButton == null )
     			{
		    		this.m_E_ButtonOpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenImage == null )
     			{
		    		this.m_E_ButtonOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenImage;
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public UnityEngine.UI.Image E_OpenCostItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenCostItemIconImage == null )
     			{
		    		this.m_E_OpenCostItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_OpenCostItemIcon");
     			}
     			return this.m_E_OpenCostItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_OpenCostNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenCostNumText == null )
     			{
		    		this.m_E_OpenCostNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_OpenCostNum");
     			}
     			return this.m_E_OpenCostNumText;
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
			this.m_E_BagItemsScrollRect = null;
			this.m_E_BagItemsImage = null;
			this.m_E_ButtonOpenButton = null;
			this.m_E_ButtonOpenImage = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_OpenCostItemIconImage = null;
			this.m_E_OpenCostNumText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_BagItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_BagItemsImage = null;
		private UnityEngine.UI.Button m_E_ButtonOpenButton = null;
		private UnityEngine.UI.Image m_E_ButtonOpenImage = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Image m_E_OpenCostItemIconImage = null;
		private UnityEngine.UI.Text m_E_OpenCostNumText = null;
		public Transform uiTransform = null;
	}
}
