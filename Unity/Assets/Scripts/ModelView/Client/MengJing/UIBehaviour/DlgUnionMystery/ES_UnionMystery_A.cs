using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionMystery_A : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos;
		public Dictionary<int, EntityRef<Scroll_Item_UnionMysteryItem_A>> ScrollItemUnionMysteryItemAs;
		
		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_UnionMysteryItemAsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionMysteryItemAsImage == null )
     			{
		    		this.m_E_UnionMysteryItemAsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_UnionMysteryItemAs");
     			}
     			return this.m_E_UnionMysteryItemAsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_UnionMysteryItemAsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionMysteryItemAsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionMysteryItemAsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_UnionMysteryItemAs");
     			}
     			return this.m_E_UnionMysteryItemAsLoopVerticalScrollRect;
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
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_E_UnionMysteryItemAsImage = null;
			this.m_E_UnionMysteryItemAsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_UnionMysteryItemAsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_UnionMysteryItemAsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
