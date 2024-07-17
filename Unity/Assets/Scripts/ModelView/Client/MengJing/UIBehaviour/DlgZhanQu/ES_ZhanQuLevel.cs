using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ZhanQuLevel : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ZhanQuLevelItem>> ScrollItemZhanQuLevelItems;
		
		public LoopVerticalScrollRect E_ZhanQuLevelItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhanQuLevelItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ZhanQuLevelItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ZhanQuLevelItems");
     			}
     			return this.m_E_ZhanQuLevelItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_Lab_MyLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MyLvText == null )
     			{
		    		this.m_E_Lab_MyLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_MyLv");
     			}
     			return this.m_E_Lab_MyLvText;
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
			this.m_E_ZhanQuLevelItemsLoopVerticalScrollRect = null;
			this.m_E_Lab_MyLvText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_ZhanQuLevelItemsLoopVerticalScrollRect = null;
		private Text m_E_Lab_MyLvText = null;
		public Transform uiTransform = null;
	}
}
