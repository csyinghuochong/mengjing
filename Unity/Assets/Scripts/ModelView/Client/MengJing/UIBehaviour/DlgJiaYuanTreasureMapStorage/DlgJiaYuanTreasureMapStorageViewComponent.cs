using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanTreasureMapStorage))]
	[EnableMethod]
	public  class DlgJiaYuanTreasureMapStorageViewComponent : Entity,IAwake,IDestroy 
	{
		public LoopVerticalScrollRect E_BagItems2LoopVerticalScrollRect
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
		    		this.m_E_BagItems2LoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems2");
     			}
     			return this.m_E_BagItems2LoopVerticalScrollRect;
     		}
     	}

		public Button E_OneKeyButton
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
		    		this.m_E_OneKeyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_OneKey");
     			}
     			return this.m_E_OneKeyButton;
     		}
     	}

		public Image E_OneKeyImage
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
		    		this.m_E_OneKeyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_OneKey");
     			}
     			return this.m_E_OneKeyImage;
     		}
     	}

		public LoopVerticalScrollRect E_BagItems1LoopVerticalScrollRect
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
		    		this.m_E_BagItems1LoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_BagItems1");
     			}
     			return this.m_E_BagItems1LoopVerticalScrollRect;
     		}
     	}

		public Button E_TakeOutAllButton
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
		    		this.m_E_TakeOutAllButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_TakeOutAll");
     			}
     			return this.m_E_TakeOutAllButton;
     		}
     	}

		public Image E_TakeOutAllImage
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
		    		this.m_E_TakeOutAllImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_TakeOutAll");
     			}
     			return this.m_E_TakeOutAllImage;
     		}
     	}

		public ToggleGroup E_ItemTypeSetToggleGroup
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Left/E_ItemTypeSet");
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

		private LoopVerticalScrollRect m_E_BagItems2LoopVerticalScrollRect = null;
		private Button m_E_OneKeyButton = null;
		private Image m_E_OneKeyImage = null;
		private LoopVerticalScrollRect m_E_BagItems1LoopVerticalScrollRect = null;
		private Button m_E_TakeOutAllButton = null;
		private Image m_E_TakeOutAllImage = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		public Transform uiTransform = null;
	}
}
