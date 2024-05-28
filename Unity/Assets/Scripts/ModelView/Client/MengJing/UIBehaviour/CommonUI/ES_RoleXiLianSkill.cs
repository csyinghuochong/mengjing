
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianSkill : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, Scroll_Item_RoleXiLianSkillItem> ScrollItemRoleXiLianSkillItems;
		public List<EquipXiLianConfig> ShouJiConfigs;
		public int XilianLevel;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_RoleXiLianSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleXiLianSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RoleXiLianSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RoleXiLianSkillItems");
     			}
     			return this.m_E_RoleXiLianSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_Text_XiLianNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_XiLianNameText == null )
     			{
		    		this.m_E_Text_XiLianNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RoleXiLianSkillItems/Content/Item_RoleXiLianSkillItem/TopNode/E_Text_XiLianName");
     			}
     			return this.m_E_Text_XiLianNameText;
     		}
     	}

		public UnityEngine.RectTransform EG_JiHuoSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_JiHuoSetRectTransform == null )
     			{
		    		this.m_EG_JiHuoSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_RoleXiLianSkillItems/Content/Item_RoleXiLianSkillItem/TopNode/EG_JiHuoSet");
     			}
     			return this.m_EG_JiHuoSetRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RoleXiLianSkillItems/Content/Item_RoleXiLianSkillItem/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
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
			this.m_E_RoleXiLianSkillItemsLoopVerticalScrollRect = null;
			this.m_E_Text_XiLianNameText = null;
			this.m_EG_JiHuoSetRectTransform = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_RoleXiLianSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Text_XiLianNameText = null;
		private UnityEngine.RectTransform m_EG_JiHuoSetRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
