using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanMystery_B : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanMysteryItem>> ScrollItemJiaYuanMysteryItems;
		
		public LoopVerticalScrollRect E_JiaYuanMysteryItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanMysteryItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanMysteryItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanMysteryItems");
     			}
     			return this.m_E_JiaYuanMysteryItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_Text_CDTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CDTimeText == null )
     			{
		    		this.m_E_Text_CDTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_CDTime");
     			}
     			return this.m_E_Text_CDTimeText;
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
			this.m_E_JiaYuanMysteryItemsLoopVerticalScrollRect = null;
			this.m_E_Text_CDTimeText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_JiaYuanMysteryItemsLoopVerticalScrollRect = null;
		private Text m_E_Text_CDTimeText = null;
		public Transform uiTransform = null;
	}
}
