using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ZhanQuCombat : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ZhanQuCombatItem>> ScrollItemZhanQuCombatItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_ZhanQuCombatItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhanQuCombatItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ZhanQuCombatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_ZhanQuCombatItems");
     			}
     			return this.m_E_ZhanQuCombatItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_MyCombatText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MyCombatText == null )
     			{
		    		this.m_E_MyCombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_MyCombat");
     			}
     			return this.m_E_MyCombatText;
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
			this.m_E_ZhanQuCombatItemsLoopVerticalScrollRect = null;
			this.m_E_MyCombatText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_ZhanQuCombatItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_MyCombatText = null;
		public Transform uiTransform = null;
	}
}
