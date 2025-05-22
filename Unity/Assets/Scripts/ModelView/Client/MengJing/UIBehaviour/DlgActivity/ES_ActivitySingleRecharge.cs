
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivitySingleRecharge : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<ActivityConfig> ShowItem = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivitySingleRechargeItem>> ScrollItemActivitySingleRechargeItems = new();
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.ScrollRect E_ActivitySingleRechargeItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingleRechargeItemsScrollRect == null )
     			{
		    		this.m_E_ActivitySingleRechargeItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Center/E_ActivitySingleRechargeItems");
     			}
     			return this.m_E_ActivitySingleRechargeItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ActivitySingleRechargeItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingleRechargeItemsImage == null )
     			{
		    		this.m_E_ActivitySingleRechargeItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ActivitySingleRechargeItems");
     			}
     			return this.m_E_ActivitySingleRechargeItemsImage;
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
			this.m_E_ActivitySingleRechargeItemsScrollRect = null;
			this.m_E_ActivitySingleRechargeItemsImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_ActivitySingleRechargeItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_ActivitySingleRechargeItemsImage = null;
		public Transform uiTransform = null;
	}
}
