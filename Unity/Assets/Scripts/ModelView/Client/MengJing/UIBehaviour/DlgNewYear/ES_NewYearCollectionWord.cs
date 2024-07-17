using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_NewYearCollectionWord : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_NewYearCollectionWordItem>> ScrollItemNewYearCollectionWordItems;
		
		public LoopVerticalScrollRect E_NewYearCollectionWordItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NewYearCollectionWordItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_NewYearCollectionWordItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_NewYearCollectionWordItems");
     			}
     			return this.m_E_NewYearCollectionWordItemsLoopVerticalScrollRect;
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
			this.m_E_NewYearCollectionWordItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_NewYearCollectionWordItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
