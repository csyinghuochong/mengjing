using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillSet : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<GameObject> SkillSetIconList = new();
		public GameObject SkillIconItemCopy;
		public Vector2 localPoint;
		public List<SkillPro> ShowSkillPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_SkillSetItem>> ScrollItemSkillSetItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		
		public RectTransform EG_SkillIPositionSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIPositionSetRectTransform == null )
     			{
		    		this.m_EG_SkillIPositionSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_SkillIPositionSet");
     			}
     			return this.m_EG_SkillIPositionSetRectTransform;
     		}
     	}

		public RectTransform EG_SkillIconItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIconItemRectTransform == null )
     			{
		    		this.m_EG_SkillIconItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_SkillIconItem");
     			}
     			return this.m_EG_SkillIconItemRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public LoopVerticalScrollRect E_SkillSetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillSetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SkillSetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_SkillSetItems");
     			}
     			return this.m_E_SkillSetItemsLoopVerticalScrollRect;
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
			this.m_EG_SkillIPositionSetRectTransform = null;
			this.m_EG_SkillIconItemRectTransform = null;
			this.m_E_CommonItemsLoopVerticalScrollRect = null;
			this.m_E_SkillSetItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SkillIPositionSetRectTransform = null;
		private RectTransform m_EG_SkillIconItemRectTransform = null;
		private LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_SkillSetItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
