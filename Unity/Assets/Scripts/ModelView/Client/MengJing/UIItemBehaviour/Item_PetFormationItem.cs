using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_PetFormationItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetFormationItem>
	{
		public Action<RolePetInfo, PointerEventData> BeginDragHandler;
		public Action<RolePetInfo, PointerEventData> DragingHandler;
		public Action<RolePetInfo, PointerEventData> EndDragHandler;
		public RolePetInfo RolePetInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetFormationItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageBackImage
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
     				if( this.m_E_ImageBackImage == null )
     				{
		    			this.m_E_ImageBackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBack");
     				}
     				return this.m_E_ImageBackImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBack");
     			}
     		}
     	}

		public EventTrigger E_ImageBackEventTrigger
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
     				if( this.m_E_ImageBackEventTrigger == null )
     				{
		    			this.m_E_ImageBackEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_ImageBack");
     				}
     				return this.m_E_ImageBackEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_ImageBack");
     			}
     		}
     	}

		public Image E_ImageIconImage
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
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     		}
     	}

		public EventTrigger E_ImageIconEventTrigger
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
		    			this.m_E_ImageIconEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_ImageIcon");
     				}
     				return this.m_E_ImageIconEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     		}
     	}

		public Image E_ImageFightImage
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
     				if( this.m_E_ImageFightImage == null )
     				{
		    			this.m_E_ImageFightImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageFight");
     				}
     				return this.m_E_ImageFightImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageFight");
     			}
     		}
     	}

		public Text E_TextLvText
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
     				if( this.m_E_TextLvText == null )
     				{
		    			this.m_E_TextLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLv");
     				}
     				return this.m_E_TextLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLv");
     			}
     		}
     	}

		public Text E_TextNameText
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
     				if( this.m_E_TextNameText == null )
     				{
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageBackImage = null;
			this.m_E_ImageBackEventTrigger = null;
			this.m_E_ImageIconImage = null;
			this.m_E_ImageIconEventTrigger = null;
			this.m_E_ImageFightImage = null;
			this.m_E_TextLvText = null;
			this.m_E_TextNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageBackImage = null;
		private EventTrigger m_E_ImageBackEventTrigger = null;
		private Image m_E_ImageIconImage = null;
		private EventTrigger m_E_ImageIconEventTrigger = null;
		private Image m_E_ImageFightImage = null;
		private Text m_E_TextLvText = null;
		private Text m_E_TextNameText = null;
		public Transform uiTransform = null;
	}
}
