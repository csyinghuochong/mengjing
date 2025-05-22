
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianSkill : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Dictionary<int, EntityRef<Scroll_Item_RoleXiLianSkillItem>> ScrollItemRoleXiLianSkillItems = new();
		public List<EquipXiLianConfig> ShouJiConfigs;
		public int XilianLevel;
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.ScrollRect E_RoleXiLianSkillItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleXiLianSkillItemsScrollRect == null )
     			{
		    		this.m_E_RoleXiLianSkillItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_RoleXiLianSkillItems");
     			}
     			return this.m_E_RoleXiLianSkillItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_RoleXiLianSkillItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleXiLianSkillItemsImage == null )
     			{
		    		this.m_E_RoleXiLianSkillItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_RoleXiLianSkillItems");
     			}
     			return this.m_E_RoleXiLianSkillItemsImage;
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
			this.m_E_RoleXiLianSkillItemsScrollRect = null;
			this.m_E_RoleXiLianSkillItemsImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_RoleXiLianSkillItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_RoleXiLianSkillItemsImage = null;
		public Transform uiTransform = null;
	}
}
