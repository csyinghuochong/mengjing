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
		
		public UnityEngine.UI.LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
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
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SkillSetItemsLoopVerticalScrollRect
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
		    		this.m_E_SkillSetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SkillSetItems");
     			}
     			return this.m_E_SkillSetItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIPositionSetRectTransform
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
		    		this.m_EG_SkillIPositionSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillIPositionSet");
     			}
     			return this.m_EG_SkillIPositionSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIconItemRectTransform
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
		    		this.m_EG_SkillIconItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillIconItem");
     			}
     			return this.m_EG_SkillIconItemRectTransform;
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
			this.m_E_CommonItemsLoopVerticalScrollRect = null;
			this.m_E_SkillSetItemsLoopVerticalScrollRect = null;
			this.m_EG_SkillIPositionSetRectTransform = null;
			this.m_EG_SkillIconItemRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SkillSetItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_SkillIPositionSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillIconItemRectTransform = null;
		public Transform uiTransform = null;
	}
}
