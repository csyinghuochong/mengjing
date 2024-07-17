using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanWarehouse))]
	[EnableMethod]
	public  class DlgJiaYuanWarehouseViewComponent : Entity,IAwake,IDestroy 
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

		public Button E_ButtonPackButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPackButton == null )
     			{
		    		this.m_E_ButtonPackButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonPack");
     			}
     			return this.m_E_ButtonPackButton;
     		}
     	}

		public Image E_ButtonPackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPackImage == null )
     			{
		    		this.m_E_ButtonPackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonPack");
     			}
     			return this.m_E_ButtonPackImage;
     		}
     	}

		public Button E_ButtonTakeOutAllButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTakeOutAllButton == null )
     			{
		    		this.m_E_ButtonTakeOutAllButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonTakeOutAll");
     			}
     			return this.m_E_ButtonTakeOutAllButton;
     		}
     	}

		public Image E_ButtonTakeOutAllImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTakeOutAllImage == null )
     			{
		    		this.m_E_ButtonTakeOutAllImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonTakeOutAll");
     			}
     			return this.m_E_ButtonTakeOutAllImage;
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

		public Image E_NoLock_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_1Image == null )
     			{
		    		this.m_E_NoLock_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_1");
     			}
     			return this.m_E_NoLock_1Image;
     		}
     	}

		public Image E_NoLock_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_2Image == null )
     			{
		    		this.m_E_NoLock_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_2");
     			}
     			return this.m_E_NoLock_2Image;
     		}
     	}

		public Image E_NoLock_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_3Image == null )
     			{
		    		this.m_E_NoLock_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_3");
     			}
     			return this.m_E_NoLock_3Image;
     		}
     	}

		public Image E_NoLock_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoLock_4Image == null )
     			{
		    		this.m_E_NoLock_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_NoLock_4");
     			}
     			return this.m_E_NoLock_4Image;
     		}
     	}

		public Image E_Lock_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_1Image == null )
     			{
		    		this.m_E_Lock_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_1");
     			}
     			return this.m_E_Lock_1Image;
     		}
     	}

		public Image E_Lock_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_2Image == null )
     			{
		    		this.m_E_Lock_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_2");
     			}
     			return this.m_E_Lock_2Image;
     		}
     	}

		public Image E_Lock_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_3Image == null )
     			{
		    		this.m_E_Lock_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_3");
     			}
     			return this.m_E_Lock_3Image;
     		}
     	}

		public Image E_Lock_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lock_4Image == null )
     			{
		    		this.m_E_Lock_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Lock_4");
     			}
     			return this.m_E_Lock_4Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BagItems2LoopVerticalScrollRect = null;
			this.m_E_OneKeyButton = null;
			this.m_E_OneKeyImage = null;
			this.m_E_ButtonPackButton = null;
			this.m_E_ButtonPackImage = null;
			this.m_E_ButtonTakeOutAllButton = null;
			this.m_E_ButtonTakeOutAllImage = null;
			this.m_E_BagItems1LoopVerticalScrollRect = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_NoLock_1Image = null;
			this.m_E_NoLock_2Image = null;
			this.m_E_NoLock_3Image = null;
			this.m_E_NoLock_4Image = null;
			this.m_E_Lock_1Image = null;
			this.m_E_Lock_2Image = null;
			this.m_E_Lock_3Image = null;
			this.m_E_Lock_4Image = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_BagItems2LoopVerticalScrollRect = null;
		private Button m_E_OneKeyButton = null;
		private Image m_E_OneKeyImage = null;
		private Button m_E_ButtonPackButton = null;
		private Image m_E_ButtonPackImage = null;
		private Button m_E_ButtonTakeOutAllButton = null;
		private Image m_E_ButtonTakeOutAllImage = null;
		private LoopVerticalScrollRect m_E_BagItems1LoopVerticalScrollRect = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private Image m_E_NoLock_1Image = null;
		private Image m_E_NoLock_2Image = null;
		private Image m_E_NoLock_3Image = null;
		private Image m_E_NoLock_4Image = null;
		private Image m_E_Lock_1Image = null;
		private Image m_E_Lock_2Image = null;
		private Image m_E_Lock_3Image = null;
		private Image m_E_Lock_4Image = null;
		public Transform uiTransform = null;
	}
}
