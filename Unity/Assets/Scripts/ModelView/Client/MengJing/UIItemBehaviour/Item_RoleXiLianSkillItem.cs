using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_RoleXiLianSkillItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_RoleXiLianSkillItem>
	{
		public EquipXiLianConfig EquipXiLianConfig;
		public List<EntityRef<Scroll_Item_CommonSkillItem>> uIItems = new();
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RoleXiLianSkillItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_Text_XiLianNameText
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
     				if( this.m_E_Text_XiLianNameText == null )
     				{
		    			this.m_E_Text_XiLianNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TopNode/E_Text_XiLianName");
     				}
     				return this.m_E_Text_XiLianNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TopNode/E_Text_XiLianName");
     			}
     		}
     	}

		public RectTransform EG_JiHuoSetRectTransform
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
     				if( this.m_EG_JiHuoSetRectTransform == null )
     				{
		    			this.m_EG_JiHuoSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"TopNode/EG_JiHuoSet");
     				}
     				return this.m_EG_JiHuoSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"TopNode/EG_JiHuoSet");
     			}
     		}
     	}

		public RectTransform EG_ItemNodeRectTransform
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
     				if( this.m_EG_ItemNodeRectTransform == null )
     				{
		    			this.m_EG_ItemNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ItemNode");
     				}
     				return this.m_EG_ItemNodeRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ItemNode");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Text_XiLianNameText = null;
			this.m_EG_JiHuoSetRectTransform = null;
			this.m_EG_ItemNodeRectTransform = null;
			this.uiTransform = null;
			this.uIItems.Clear();		// 引用类型清空 不然第二次打开有问题 看一会怎么全部优化一下 
			this.DataId = 0;
		}

		private Text m_E_Text_XiLianNameText = null;
		private RectTransform m_EG_JiHuoSetRectTransform = null;
		private RectTransform m_EG_ItemNodeRectTransform = null;
		public Transform uiTransform = null;
	}
}
