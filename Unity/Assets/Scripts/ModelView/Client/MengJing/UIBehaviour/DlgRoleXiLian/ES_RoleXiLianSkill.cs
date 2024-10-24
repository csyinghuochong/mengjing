﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianSkill : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_RoleXiLianSkillItem>> ScrollItemRoleXiLianSkillItems;
		public List<EquipXiLianConfig> ShouJiConfigs;
		public int XilianLevel;
		
		public LoopVerticalScrollRect E_RoleXiLianSkillItemsLoopVerticalScrollRect
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
		    		this.m_E_RoleXiLianSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RoleXiLianSkillItems");
     			}
     			return this.m_E_RoleXiLianSkillItemsLoopVerticalScrollRect;
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
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_RoleXiLianSkillItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
