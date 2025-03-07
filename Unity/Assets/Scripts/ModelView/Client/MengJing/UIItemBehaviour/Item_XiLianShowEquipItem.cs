
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_XiLianShowEquipItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_XiLianShowEquipItem> 
	{
		public int Occ;
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public ItemOperateEnum ItemOperateEnum;
		public List<ItemInfo> EquipList { get; set; } = new();
		public Action<ItemInfo> OnClickAction { get; set; }
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_XiLianShowEquipItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.RectTransform EG_ShowRectTransform
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
     				if( this.m_EG_ShowRectTransform == null )
     				{
		    			this.m_EG_ShowRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Show");
     				}
     				return this.m_EG_ShowRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Show");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemQualityImage
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
     				if( this.m_E_ItemQualityImage == null )
     				{
		    			this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_ItemQuality");
     				}
     				return this.m_E_ItemQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_ItemQuality");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemIconImage
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
     				if( this.m_E_ItemIconImage == null )
     				{
		    			this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_ItemIcon");
     				}
     				return this.m_E_ItemIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_ItemIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ItemNameText
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
     				if( this.m_E_ItemNameText == null )
     				{
		    			this.m_E_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Show/E_ItemName");
     				}
     				return this.m_E_ItemNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Show/E_ItemName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ItemWordText
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
     				if( this.m_E_ItemWordText == null )
     				{
		    			this.m_E_ItemWordText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Show/E_ItemWord");
     				}
     				return this.m_E_ItemWordText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Show/E_ItemWord");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_HighlightImage
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
     				if( this.m_E_HighlightImage == null )
     				{
		    			this.m_E_HighlightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_Highlight");
     				}
     				return this.m_E_HighlightImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_Highlight");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ClickButton
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
     				if( this.m_E_ClickButton == null )
     				{
		    			this.m_E_ClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Show/E_Click");
     				}
     				return this.m_E_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Show/E_Click");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ClickImage
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
     				if( this.m_E_ClickImage == null )
     				{
		    			this.m_E_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_Click");
     				}
     				return this.m_E_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Show/E_Click");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_NullRectTransform
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
     				if( this.m_EG_NullRectTransform == null )
     				{
		    			this.m_EG_NullRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Null");
     				}
     				return this.m_EG_NullRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Null");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_ShowRectTransform = null;
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_ItemNameText = null;
			this.m_E_ItemWordText = null;
			this.m_E_HighlightImage = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.m_EG_NullRectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.RectTransform m_EG_ShowRectTransform = null;
		private UnityEngine.UI.Image m_E_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_ItemNameText = null;
		private UnityEngine.UI.Text m_E_ItemWordText = null;
		private UnityEngine.UI.Image m_E_HighlightImage = null;
		private UnityEngine.UI.Button m_E_ClickButton = null;
		private UnityEngine.UI.Image m_E_ClickImage = null;
		private UnityEngine.RectTransform m_EG_NullRectTransform = null;
		public Transform uiTransform = null;
	}
}
