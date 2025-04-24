
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetChouKa : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<int> RewardShowItems = new();

		public long Interval = 0; //匀速
		public int TargetIndex = 0;
		public int CurrentIndex = 0;
		public bool OnStopTurn;
		public bool ifStop;
		
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonStopButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStopButton == null )
     			{
		    		this.m_E_ButtonStopButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonStop");
     			}
     			return this.m_E_ButtonStopButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonStopImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStopImage == null )
     			{
		    		this.m_E_ButtonStopImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonStop");
     			}
     			return this.m_E_ButtonStopImage;
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
		    		this.m_E_ButtonOpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonOpen");
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
		    		this.m_E_ButtonOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonOpen");
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
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
		    		this.m_E_OpenCostNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_OpenCostNum");
     			}
     			return this.m_E_OpenCostNumText;
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
		    		this.m_E_OpenCostItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_OpenCostItemIcon");
     			}
     			return this.m_E_OpenCostItemIconImage;
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
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonStopButton = null;
			this.m_E_ButtonStopImage = null;
			this.m_E_ButtonOpenButton = null;
			this.m_E_ButtonOpenImage = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_OpenCostNumText = null;
			this.m_E_OpenCostItemIconImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonStopButton = null;
		private UnityEngine.UI.Image m_E_ButtonStopImage = null;
		private UnityEngine.UI.Button m_E_ButtonOpenButton = null;
		private UnityEngine.UI.Image m_E_ButtonOpenImage = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Text m_E_OpenCostNumText = null;
		private UnityEngine.UI.Image m_E_OpenCostItemIconImage = null;
		public Transform uiTransform = null;
	}
}
