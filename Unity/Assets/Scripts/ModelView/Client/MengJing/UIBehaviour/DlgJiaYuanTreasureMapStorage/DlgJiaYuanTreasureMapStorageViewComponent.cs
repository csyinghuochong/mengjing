
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanTreasureMapStorage))]
	[EnableMethod]
	public  class DlgJiaYuanTreasureMapStorageViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_BagItems2LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItems2LoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItems2LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems2");
     			}
     			return this.m_E_BagItems2LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_OneKeyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneKeyButton == null )
     			{
		    		this.m_E_OneKeyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_OneKey");
     			}
     			return this.m_E_OneKeyButton;
     		}
     	}

		public UnityEngine.UI.Image E_OneKeyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OneKeyImage == null )
     			{
		    		this.m_E_OneKeyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_OneKey");
     			}
     			return this.m_E_OneKeyImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItems1LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItems1LoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItems1LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_BagItems1");
     			}
     			return this.m_E_BagItems1LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_TakeOutAllButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOutAllButton == null )
     			{
		    		this.m_E_TakeOutAllButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_TakeOutAll");
     			}
     			return this.m_E_TakeOutAllButton;
     		}
     	}

		public UnityEngine.UI.Image E_TakeOutAllImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOutAllImage == null )
     			{
		    		this.m_E_TakeOutAllImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_TakeOutAll");
     			}
     			return this.m_E_TakeOutAllImage;
     		}
     	}

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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BagItems2LoopVerticalScrollRect = null;
			this.m_E_OneKeyButton = null;
			this.m_E_OneKeyImage = null;
			this.m_E_BagItems1LoopVerticalScrollRect = null;
			this.m_E_TakeOutAllButton = null;
			this.m_E_TakeOutAllImage = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItems2LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_OneKeyButton = null;
		private UnityEngine.UI.Image m_E_OneKeyImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItems1LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_TakeOutAllButton = null;
		private UnityEngine.UI.Image m_E_TakeOutAllImage = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		public Transform uiTransform = null;
	}
}
