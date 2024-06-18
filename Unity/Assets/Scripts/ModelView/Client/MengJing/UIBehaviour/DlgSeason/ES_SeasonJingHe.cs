
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonJingHe : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Sprite OldSprite;
		public BagInfo BagInfo;
		public int JingHeId;
		public List<SeasonJingHeConfig> ShowSeasonJingHeConfigs;
		public Dictionary<int, Scroll_Item_SeasonJingHeItem> ScrollItemSeasonJingHeItems;
		public List<BagInfo> ShowBagInfos = new();
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
		
		public UnityEngine.UI.Button E_Btn_TianFu_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Button == null )
     			{
		    		this.m_E_Btn_TianFu_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_TianFu_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Image == null )
     			{
		    		this.m_E_Btn_TianFu_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_TianFu_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Button == null )
     			{
		    		this.m_E_Btn_TianFu_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_TianFu_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Image == null )
     			{
		    		this.m_E_Btn_TianFu_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Image;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SeasonJingHeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonJingHeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SeasonJingHeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SeasonJingHeItems");
     			}
     			return this.m_E_SeasonJingHeItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_JingHeImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingHeImgImage == null )
     			{
		    		this.m_E_JingHeImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_JingHeImg");
     			}
     			return this.m_E_JingHeImgImage;
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public ES_CostItem ES_CostItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_costitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CostItem");
		    	   this.m_es_costitem = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem;
     		}
     	}

		public UnityEngine.UI.Button E_OpenBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenBtnButton == null )
     			{
		    		this.m_E_OpenBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_OpenBtn");
     			}
     			return this.m_E_OpenBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_OpenBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenBtnImage == null )
     			{
		    		this.m_E_OpenBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_OpenBtn");
     			}
     			return this.m_E_OpenBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_EquipBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBtnButton == null )
     			{
		    		this.m_E_EquipBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_EquipBtn");
     			}
     			return this.m_E_EquipBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_EquipBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBtnImage == null )
     			{
		    		this.m_E_EquipBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EquipBtn");
     			}
     			return this.m_E_EquipBtnImage;
     		}
     	}

		public UnityEngine.UI.Text E_NameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameTextText == null )
     			{
		    		this.m_E_NameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     			return this.m_E_NameTextText;
     		}
     	}

		public UnityEngine.UI.Text E_DesTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DesTextText == null )
     			{
		    		this.m_E_DesTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_DesText");
     			}
     			return this.m_E_DesTextText;
     		}
     	}

		public UnityEngine.UI.Button E_TakeOffBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOffBtnButton == null )
     			{
		    		this.m_E_TakeOffBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_TakeOffBtn");
     			}
     			return this.m_E_TakeOffBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_TakeOffBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOffBtnImage == null )
     			{
		    		this.m_E_TakeOffBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TakeOffBtn");
     			}
     			return this.m_E_TakeOffBtnImage;
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
			this.m_E_Btn_TianFu_1Button = null;
			this.m_E_Btn_TianFu_1Image = null;
			this.m_E_Btn_TianFu_2Button = null;
			this.m_E_Btn_TianFu_2Image = null;
			this.m_E_SeasonJingHeItemsLoopVerticalScrollRect = null;
			this.m_E_JingHeImgImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_es_costitem = null;
			this.m_E_OpenBtnButton = null;
			this.m_E_OpenBtnImage = null;
			this.m_E_EquipBtnButton = null;
			this.m_E_EquipBtnImage = null;
			this.m_E_NameTextText = null;
			this.m_E_DesTextText = null;
			this.m_E_TakeOffBtnButton = null;
			this.m_E_TakeOffBtnImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_TianFu_1Button = null;
		private UnityEngine.UI.Image m_E_Btn_TianFu_1Image = null;
		private UnityEngine.UI.Button m_E_Btn_TianFu_2Button = null;
		private UnityEngine.UI.Image m_E_Btn_TianFu_2Image = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SeasonJingHeItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_JingHeImgImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_CostItem> m_es_costitem = null;
		private UnityEngine.UI.Button m_E_OpenBtnButton = null;
		private UnityEngine.UI.Image m_E_OpenBtnImage = null;
		private UnityEngine.UI.Button m_E_EquipBtnButton = null;
		private UnityEngine.UI.Image m_E_EquipBtnImage = null;
		private UnityEngine.UI.Text m_E_NameTextText = null;
		private UnityEngine.UI.Text m_E_DesTextText = null;
		private UnityEngine.UI.Button m_E_TakeOffBtnButton = null;
		private UnityEngine.UI.Image m_E_TakeOffBtnImage = null;
		public Transform uiTransform = null;
	}
}
