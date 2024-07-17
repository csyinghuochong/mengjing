using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionMystery_A : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos;
		public Dictionary<int, EntityRef<Scroll_Item_UnionMysteryItem_A>> ScrollItemUnionMysteryItemAs;
		
		public LoopVerticalScrollRect ELoopScrollList_LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_LoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"ELoopScrollList_");
     			}
     			return this.m_ELoopScrollList_LoopVerticalScrollRect;
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
			this.m_ELoopScrollList_LoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_ELoopScrollList_LoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
