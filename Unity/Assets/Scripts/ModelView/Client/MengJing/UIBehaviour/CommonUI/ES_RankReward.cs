
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankReward : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		public Dictionary<int, Scroll_Item_RankRewardItem> ScrollItemRankRewardItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_RankRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RankRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RankRewardItems");
     			}
     			return this.m_E_RankRewardItemsLoopVerticalScrollRect;
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
			this.m_E_RankRewardItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_RankRewardItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
