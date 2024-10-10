
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_CellDungeonCellItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_CellDungeonCellItem> 
	{
		public CellDungeonInfo fubenCellInfo;

		public bool ShowOpen;
		public float PassTime;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CellDungeonCellItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_huiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_huiButton == null )
     				{
		    			this.m_E_huiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_hui");
     				}
     				return this.m_E_huiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_hui");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_huiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_huiImage == null )
     				{
		    			this.m_E_huiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_hui");
     				}
     				return this.m_E_huiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_hui");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_startImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_startImage == null )
     				{
		    			this.m_E_startImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_start");
     				}
     				return this.m_E_startImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_start");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_endImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_endImage == null )
     				{
		    			this.m_E_endImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_end");
     				}
     				return this.m_E_endImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_end");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_passableButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_passableButton == null )
     				{
		    			this.m_E_passableButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_passable");
     				}
     				return this.m_E_passableButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_passable");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_passableImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_passableImage == null )
     				{
		    			this.m_E_passableImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_passable");
     				}
     				return this.m_E_passableImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_passable");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_impassableButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_impassableButton == null )
     				{
		    			this.m_E_impassableButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_impassable");
     				}
     				return this.m_E_impassableButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_impassable");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_impassableImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_impassableImage == null )
     				{
		    			this.m_E_impassableImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_impassable");
     				}
     				return this.m_E_impassableImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_impassable");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_walkedButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_walkedButton == null )
     				{
		    			this.m_E_walkedButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_walked");
     				}
     				return this.m_E_walkedButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_walked");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_walkedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_walkedImage == null )
     				{
		    			this.m_E_walkedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_walked");
     				}
     				return this.m_E_walkedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_walked");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_TeShu_HuiFuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_TeShu_HuiFuImage == null )
     				{
		    			this.m_E_TeShu_HuiFuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_HuiFu");
     				}
     				return this.m_E_TeShu_HuiFuImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_HuiFu");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_TeShu_ChestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_TeShu_ChestImage == null )
     				{
		    			this.m_E_TeShu_ChestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_Chest");
     				}
     				return this.m_E_TeShu_ChestImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_Chest");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_TeShu_ShenMiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_TeShu_ShenMiImage == null )
     				{
		    			this.m_E_TeShu_ShenMiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_ShenMi");
     				}
     				return this.m_E_TeShu_ShenMiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_ShenMi");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_TeShu_MoNengImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_TeShu_MoNengImage == null )
     				{
		    			this.m_E_TeShu_MoNengImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_MoNeng");
     				}
     				return this.m_E_TeShu_MoNengImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_MoNeng");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_TeShu_JingYingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_TeShu_JingYingImage == null )
     				{
		    			this.m_E_TeShu_JingYingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_JingYing");
     				}
     				return this.m_E_TeShu_JingYingImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TeShu_JingYing");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_liangButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_liangButton == null )
     				{
		    			this.m_E_liangButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_liang");
     				}
     				return this.m_E_liangButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_liang");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_liangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_liangImage == null )
     				{
		    			this.m_E_liangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_liang");
     				}
     				return this.m_E_liangImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_liang");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_huiButton = null;
			this.m_E_huiImage = null;
			this.m_E_startImage = null;
			this.m_E_endImage = null;
			this.m_E_passableButton = null;
			this.m_E_passableImage = null;
			this.m_E_impassableButton = null;
			this.m_E_impassableImage = null;
			this.m_E_walkedButton = null;
			this.m_E_walkedImage = null;
			this.m_E_TeShu_HuiFuImage = null;
			this.m_E_TeShu_ChestImage = null;
			this.m_E_TeShu_ShenMiImage = null;
			this.m_E_TeShu_MoNengImage = null;
			this.m_E_TeShu_JingYingImage = null;
			this.m_E_liangButton = null;
			this.m_E_liangImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_huiButton = null;
		private UnityEngine.UI.Image m_E_huiImage = null;
		private UnityEngine.UI.Image m_E_startImage = null;
		private UnityEngine.UI.Image m_E_endImage = null;
		private UnityEngine.UI.Button m_E_passableButton = null;
		private UnityEngine.UI.Image m_E_passableImage = null;
		private UnityEngine.UI.Button m_E_impassableButton = null;
		private UnityEngine.UI.Image m_E_impassableImage = null;
		private UnityEngine.UI.Button m_E_walkedButton = null;
		private UnityEngine.UI.Image m_E_walkedImage = null;
		private UnityEngine.UI.Image m_E_TeShu_HuiFuImage = null;
		private UnityEngine.UI.Image m_E_TeShu_ChestImage = null;
		private UnityEngine.UI.Image m_E_TeShu_ShenMiImage = null;
		private UnityEngine.UI.Image m_E_TeShu_MoNengImage = null;
		private UnityEngine.UI.Image m_E_TeShu_JingYingImage = null;
		private UnityEngine.UI.Button m_E_liangButton = null;
		private UnityEngine.UI.Image m_E_liangImage = null;
		public Transform uiTransform = null;
	}
}
