
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_CreateRoleSkillItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_CreateRoleSkillItem> 
	{
		public string SkillAtlas;
		public int SkillId;
		public string addTip;
		public bool UnActive;
		public int HaveSkillNum = 0;
		public Action<int> SelectAction;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CreateRoleSkillItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_ImageIconImage
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
     				if( this.m_E_ImageIconImage == null )
     				{
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ImageIconEventTrigger
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
     				if( this.m_E_ImageIconEventTrigger == null )
     				{
		    			this.m_E_ImageIconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
     				}
     				return this.m_E_ImageIconEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextSkillNameText
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
     				if( this.m_E_TextSkillNameText == null )
     				{
		    			this.m_E_TextSkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextSkillName");
     				}
     				return this.m_E_TextSkillNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextSkillName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageIconImage = null;
			this.m_E_ImageIconEventTrigger = null;
			this.m_E_TextSkillNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ImageIconEventTrigger = null;
		private UnityEngine.UI.Text m_E_TextSkillNameText = null;
		public Transform uiTransform = null;
	}
}
