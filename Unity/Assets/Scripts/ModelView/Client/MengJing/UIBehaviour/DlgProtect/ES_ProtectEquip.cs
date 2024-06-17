
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ProtectEquip : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public BagInfo XilianBagInfo;
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
		public List<BagInfo> ShowBagInfos = new();
		
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_Obj_EquipPropertyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Obj_EquipPropertyTextText == null )
     			{
		    		this.m_E_Obj_EquipPropertyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Obj_EquipPropertyText");
     			}
     			return this.m_E_Obj_EquipPropertyTextText;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipBaseSetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipBaseSetListRectTransform == null )
     			{
		    		this.m_EG_EquipBaseSetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_EquipBaseSetList");
     			}
     			return this.m_EG_EquipBaseSetListRectTransform;
     		}
     	}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Button E_XiLianButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianButtonButton == null )
     			{
		    		this.m_E_XiLianButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_XiLianButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianButtonImage == null )
     			{
		    		this.m_E_XiLianButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonUnLockButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonUnLockButton == null )
     			{
		    		this.m_E_ButtonUnLockButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonUnLock");
     			}
     			return this.m_E_ButtonUnLockButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonUnLockImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonUnLockImage == null )
     			{
		    		this.m_E_ButtonUnLockImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonUnLock");
     			}
     			return this.m_E_ButtonUnLockImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NumText == null )
     			{
		    		this.m_E_Lab_NumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/Text_2 (1)/E_Lab_Num");
     			}
     			return this.m_E_Lab_NumText;
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
			this.m_E_Obj_EquipPropertyTextText = null;
			this.m_EG_EquipBaseSetListRectTransform = null;
			this.m_es_commonitem = null;
			this.m_E_XiLianButtonButton = null;
			this.m_E_XiLianButtonImage = null;
			this.m_E_ButtonUnLockButton = null;
			this.m_E_ButtonUnLockImage = null;
			this.m_E_Lab_NumText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Obj_EquipPropertyTextText = null;
		private UnityEngine.RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Button m_E_XiLianButtonButton = null;
		private UnityEngine.UI.Image m_E_XiLianButtonImage = null;
		private UnityEngine.UI.Button m_E_ButtonUnLockButton = null;
		private UnityEngine.UI.Image m_E_ButtonUnLockImage = null;
		private UnityEngine.UI.Text m_E_Lab_NumText = null;
		public Transform uiTransform = null;
	}
}
