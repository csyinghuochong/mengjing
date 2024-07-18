
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuaVisit : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public M2C_JiaYuanVisitListResponse m2C_JiaYuanVisitList;
		public List<JiaYuanVisit> Visits;
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanVisitItem>> ScrollItemJiaYuanVisitItems;
		
		
		public UnityEngine.UI.LoopVerticalScrollRect E_JiaYuanVisitItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanVisitItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanVisitItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanVisitItems");
     			}
     			return this.m_E_JiaYuanVisitItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Text E_TextLimitText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLimitText == null )
     			{
		    		this.m_E_TextLimitText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLimit");
     			}
     			return this.m_E_TextLimitText;
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
			this.m_E_JiaYuanVisitItemsLoopVerticalScrollRect = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_TextLimitText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_JiaYuanVisitItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Text m_E_TextLimitText = null;
		public Transform uiTransform = null;
	}
}
