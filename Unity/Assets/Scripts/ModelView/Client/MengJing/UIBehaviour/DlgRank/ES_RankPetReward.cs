using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankPetReward : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<RankRewardConfig> ShowRankRewardConfigs;
		public Dictionary<int, EntityRef<Scroll_Item_RankRewardItem>> ScrollItemRankRewardItems;
		
		public LoopVerticalScrollRect E_RankRewardItemsLoopVerticalScrollRect
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
		    		this.m_E_RankRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RankRewardItems");
     			}
     			return this.m_E_RankRewardItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButton
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_CloseButton == null )
				{
					this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
				}
				return this.m_E_CloseButton;
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

		private LoopVerticalScrollRect m_E_RankRewardItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		public Transform uiTransform = null;
	}
}
