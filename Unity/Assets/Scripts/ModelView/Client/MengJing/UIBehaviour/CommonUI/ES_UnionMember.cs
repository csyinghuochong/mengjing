using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionMember : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy ,IUILogic
	{
		
		public UnionInfo UnionInfo;
		public List<long> OnLinePlayer;
		public long UnionJingXuanTimer;
		public List<UnionPlayerInfo> ShowUnionPlayerInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_UnionMemberItem>> ScrollItemUnionMyItems;

		
		public UnityEngine.RectTransform EG_ShowSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ShowSetRectTransform == null )
     			{
		    		this.m_EG_ShowSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_ShowSet");
     			}
     			return this.m_EG_ShowSetRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_UnionMyItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionMyItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionMyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_ShowSet/E_UnionMyItems");
     			}
     			return this.m_E_UnionMyItemsLoopVerticalScrollRect;
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
			this.m_EG_ShowSetRectTransform = null;
			this.m_E_UnionMyItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_ShowSetRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_UnionMyItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
