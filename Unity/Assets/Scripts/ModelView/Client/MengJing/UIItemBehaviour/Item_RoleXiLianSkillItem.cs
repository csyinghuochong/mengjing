
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RoleXiLianSkillItem : Entity,IAwake,IDestroy,IUIScrollItem,IUILogic
	{
		public List<KeyValuePairInt> XilianSkill;
		public EquipXiLianConfig EquipXiLianConfig;
		public Dictionary<int, Scroll_Item_CommonSkillItem> ScrollItemCommonSkillItems;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RoleXiLianSkillItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_XiLianNameText == null )
     				{
		    			this.m_E_Text_XiLianNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TopNode/E_Text_XiLianName");
     				}
     				return this.m_E_Text_XiLianNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TopNode/E_Text_XiLianName");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_EG_JiHuoSetRectTransform == null )
     				{
		    			this.m_EG_JiHuoSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"TopNode/EG_JiHuoSet");
     				}
     				return this.m_EG_JiHuoSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"TopNode/EG_JiHuoSet");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     				{
		    			this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems");
     				}
     				return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Text_XiLianNameText = null;
			this.m_EG_JiHuoSetRectTransform = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_Text_XiLianNameText = null;
		private UnityEngine.RectTransform m_EG_JiHuoSetRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
