using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_BattleTask : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<TaskPro> ShowTaskPro = new();
		public Dictionary<int, EntityRef<Scroll_Item_BattleTaskItem>> ScrollItemBattleTaskItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_BattleTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BattleTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BattleTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_BattleTaskItems");
     			}
     			return this.m_E_BattleTaskItemsLoopVerticalScrollRect;
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
			this.m_E_BattleTaskItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_BattleTaskItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
