using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityLogin : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivityLoginItem>> ScrollItemActivityLoginItems;
		
		public LoopVerticalScrollRect E_ActivityLoginItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivityLoginItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ActivityLoginItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ActivityLoginItems");
     			}
     			return this.m_E_ActivityLoginItemsLoopVerticalScrollRect;
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
			this.m_E_ActivityLoginItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_ActivityLoginItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
