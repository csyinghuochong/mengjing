using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_RolePetBagItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_RolePetBagItem>
	{
		public Action<RolePetInfo> ClickHandler;
		public RolePetInfo RolePetInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RolePetBagItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_Image_ItemButtonButton
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
     				if( this.m_E_Image_ItemButtonButton == null )
     				{
		    			this.m_E_Image_ItemButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Image_ItemButton");
     				}
     				return this.m_E_Image_ItemButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Image_ItemButton");
     			}
     		}
     	}

		public Image E_Image_ItemButtonImage
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
     				if( this.m_E_Image_ItemButtonImage == null )
     				{
		    			this.m_E_Image_ItemButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemButton");
     				}
     				return this.m_E_Image_ItemButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemButton");
     			}
     		}
     	}

		public Button E_Image_EventTriggerButton
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
     				if( this.m_E_Image_EventTriggerButton == null )
     				{
		    			this.m_E_Image_EventTriggerButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     				}
     				return this.m_E_Image_EventTriggerButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     			}
     		}
     	}

		public Image E_Image_EventTriggerImage
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
     				if( this.m_E_Image_EventTriggerImage == null )
     				{
		    			this.m_E_Image_EventTriggerImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     				}
     				return this.m_E_Image_EventTriggerImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     			}
     		}
     	}

		public EventTrigger E_Image_EventTriggerEventTrigger
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
     				if( this.m_E_Image_EventTriggerEventTrigger == null )
     				{
		    			this.m_E_Image_EventTriggerEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     				}
     				return this.m_E_Image_EventTriggerEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     			}
     		}
     	}

		public Image E_Image_ItemQualityImage
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
     				if( this.m_E_Image_ItemQualityImage == null )
     				{
		    			this.m_E_Image_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemQuality");
     				}
     				return this.m_E_Image_ItemQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemQuality");
     			}
     		}
     	}

		public Image E_Image_ItemIconImage
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
     				if( this.m_E_Image_ItemIconImage == null )
     				{
		    			this.m_E_Image_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemIcon");
     				}
     				return this.m_E_Image_ItemIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemIcon");
     			}
     		}
     	}

		public Text E_Label_ItemNumText
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
     				if( this.m_E_Label_ItemNumText == null )
     				{
		    			this.m_E_Label_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Label_ItemNum");
     				}
     				return this.m_E_Label_ItemNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Label_ItemNum");
     			}
     		}
     	}

		public Text E_Label_ItemNameText
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
     				if( this.m_E_Label_ItemNameText == null )
     				{
		    			this.m_E_Label_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Label_ItemName");
     				}
     				return this.m_E_Label_ItemNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Label_ItemName");
     			}
     		}
     	}

		public Image E_Image_XuanZhongImage
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
     				if( this.m_E_Image_XuanZhongImage == null )
     				{
		    			this.m_E_Image_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_XuanZhong");
     				}
     				return this.m_E_Image_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_XuanZhong");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Image_ItemButtonButton = null;
			this.m_E_Image_ItemButtonImage = null;
			this.m_E_Image_EventTriggerButton = null;
			this.m_E_Image_EventTriggerImage = null;
			this.m_E_Image_EventTriggerEventTrigger = null;
			this.m_E_Image_ItemQualityImage = null;
			this.m_E_Image_ItemIconImage = null;
			this.m_E_Label_ItemNumText = null;
			this.m_E_Label_ItemNameText = null;
			this.m_E_Image_XuanZhongImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_Image_ItemButtonButton = null;
		private Image m_E_Image_ItemButtonImage = null;
		private Button m_E_Image_EventTriggerButton = null;
		private Image m_E_Image_EventTriggerImage = null;
		private EventTrigger m_E_Image_EventTriggerEventTrigger = null;
		private Image m_E_Image_ItemQualityImage = null;
		private Image m_E_Image_ItemIconImage = null;
		private Text m_E_Label_ItemNumText = null;
		private Text m_E_Label_ItemNameText = null;
		private Image m_E_Image_XuanZhongImage = null;
		public Transform uiTransform = null;
	}
}
