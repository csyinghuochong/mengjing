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
		
		public LoopVerticalScrollRect E_ZhanQuCombatItemsLoopVerticalScrollRect
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
		    		this.m_E_ZhanQuCombatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ZhanQuCombatItems");
     			}
     			return this.m_E_ZhanQuCombatItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_MyCombatText
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
		    		this.m_E_MyCombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_MyCombat");
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

		private LoopVerticalScrollRect m_E_ZhanQuCombatItemsLoopVerticalScrollRect = null;
		private Text m_E_MyCombatText = null;
		public Transform uiTransform = null;
	}
}
