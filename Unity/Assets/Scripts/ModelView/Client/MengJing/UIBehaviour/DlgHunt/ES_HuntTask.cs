using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_HuntTask : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<TaskPro> ShowTaskPro = new();
		public Dictionary<int, EntityRef<Scroll_Item_HuntTaskItem>> ScrollItemHuntTaskItems;
		
		public LoopVerticalScrollRect E_HuntTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuntTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_HuntTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_HuntTaskItems");
     			}
     			return this.m_E_HuntTaskItemsLoopVerticalScrollRect;
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
			this.m_E_HuntTaskItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_HuntTaskItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
