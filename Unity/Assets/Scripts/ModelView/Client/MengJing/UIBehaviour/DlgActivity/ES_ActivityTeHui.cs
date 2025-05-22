
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityTeHui : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Dictionary<int, EntityRef<Scroll_Item_ActivityTeHuiItem>> ScrollItemActivityTeHuiItems = new();
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.ScrollRect E_ActivityTeHuiItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivityTeHuiItemsScrollRect == null )
     			{
		    		this.m_E_ActivityTeHuiItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Center/E_ActivityTeHuiItems");
     			}
     			return this.m_E_ActivityTeHuiItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ActivityTeHuiItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivityTeHuiItemsImage == null )
     			{
		    		this.m_E_ActivityTeHuiItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ActivityTeHuiItems");
     			}
     			return this.m_E_ActivityTeHuiItemsImage;
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
			this.m_E_ActivityTeHuiItemsScrollRect = null;
			this.m_E_ActivityTeHuiItemsImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_ActivityTeHuiItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_ActivityTeHuiItemsImage = null;
		public Transform uiTransform = null;
	}
}
