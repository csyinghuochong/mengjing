using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SettingTitle : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_SettingTitleItem>> ScrollItemSettingTitleItems;
		public List<TitleConfig> ShowTitleConfigs = new();
		
		public UnityEngine.UI.LoopVerticalScrollRect E_SettingTitleItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingTitleItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SettingTitleItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_SettingTitleItems");
     			}
     			return this.m_E_SettingTitleItemsLoopVerticalScrollRect;
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
			this.m_E_SettingTitleItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_SettingTitleItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
