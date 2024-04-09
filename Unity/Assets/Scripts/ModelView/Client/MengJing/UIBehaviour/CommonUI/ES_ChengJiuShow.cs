
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChengJiuShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int ChengTypeId;
		public List<int> ShowType = new();
		public Dictionary<int, Scroll_Item_ChengJiuTypeItem> ScrollItemChengJiuTypeItems;
		public List<int> ShowTask = new();
		public Dictionary<int, Scroll_Item_ChengJiuShowItem> ScrollItemChengJiuShowItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_ChengJiuTypeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuTypeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuTypeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_ChengJiuTypeItems");
     			}
     			return this.m_E_ChengJiuTypeItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ChengJiuShowItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuShowItemsImage == null )
     			{
		    		this.m_E_ChengJiuShowItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ChengJiuShowItems");
     			}
     			return this.m_E_ChengJiuShowItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ChengJiuShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_ChengJiuShowItems");
     			}
     			return this.m_E_ChengJiuShowItemsLoopVerticalScrollRect;
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
			this.m_E_ChengJiuTypeItemsLoopVerticalScrollRect = null;
			this.m_E_ChengJiuShowItemsImage = null;
			this.m_E_ChengJiuShowItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChengJiuTypeItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_ChengJiuShowItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChengJiuShowItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
