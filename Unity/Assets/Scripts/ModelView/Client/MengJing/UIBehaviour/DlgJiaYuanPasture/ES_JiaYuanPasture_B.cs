using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanPasture_B : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanPastureItem>> ScrollItemJiaYuanPastureItems;
		
		public LoopVerticalScrollRect E_JiaYuanPastureItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanPastureItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanPastureItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanPastureItems");
     			}
     			return this.m_E_JiaYuanPastureItemsLoopVerticalScrollRect;
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
			this.m_E_JiaYuanPastureItemsLoopVerticalScrollRect = null;
			this.m_E_Text_CDTimeText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_JiaYuanPastureItemsLoopVerticalScrollRect = null;
		private Text m_E_Text_CDTimeText = null;
		public Transform uiTransform = null;
	}
}
