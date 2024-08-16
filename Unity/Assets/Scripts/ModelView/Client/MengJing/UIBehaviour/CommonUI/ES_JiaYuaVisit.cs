using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuaVisit : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public M2C_JiaYuanVisitListResponse m2C_JiaYuanVisitList;
		public List<JiaYuanVisit> Visits;
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanVisitItem>> ScrollItemJiaYuanVisitItems;
		
		
		public LoopVerticalScrollRect E_JiaYuanVisitItemsLoopVerticalScrollRect
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
		    		this.m_E_JiaYuanVisitItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanVisitItems");
     			}
     			return this.m_E_JiaYuanVisitItemsLoopVerticalScrollRect;
     		}
     	}

		public ToggleGroup E_FunctionSetBtnToggleGroup
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public Text E_TextLimitText
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
		    		this.m_E_TextLimitText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLimit");
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

		private LoopVerticalScrollRect m_E_JiaYuanVisitItemsLoopVerticalScrollRect = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Text m_E_TextLimitText = null;
		public Transform uiTransform = null;
	}
}
