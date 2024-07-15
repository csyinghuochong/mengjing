
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanPasture_B : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanPastureItem>> ScrollItemJiaYuanPastureItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_JiaYuanPastureItemsLoopVerticalScrollRect
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
		    		this.m_E_JiaYuanPastureItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanPastureItems");
     			}
     			return this.m_E_JiaYuanPastureItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CDTimeText
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
		    		this.m_E_Text_CDTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_CDTime");
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

		private UnityEngine.UI.LoopVerticalScrollRect m_E_JiaYuanPastureItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Text_CDTimeText = null;
		public Transform uiTransform = null;
	}
}
