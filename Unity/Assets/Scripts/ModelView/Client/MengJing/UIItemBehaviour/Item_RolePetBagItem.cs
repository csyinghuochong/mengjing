
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RolePetBagItem : Entity,IAwake,IDestroy,IUIScrollItem 
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

		public UnityEngine.UI.Button E_Image_ItemButtonButton
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
		    			this.m_E_Image_ItemButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Image_ItemButton");
     				}
     				return this.m_E_Image_ItemButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Image_ItemButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_ItemButtonImage
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
		    			this.m_E_Image_ItemButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_ItemButton");
     				}
     				return this.m_E_Image_ItemButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_ItemButton");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Image_EventTriggerButton
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
		    			this.m_E_Image_EventTriggerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     				}
     				return this.m_E_Image_EventTriggerButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_EventTriggerImage
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
		    			this.m_E_Image_EventTriggerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     				}
     				return this.m_E_Image_EventTriggerImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Image_EventTriggerEventTrigger
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
		    			this.m_E_Image_EventTriggerEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     				}
     				return this.m_E_Image_EventTriggerEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Image_EventTrigger");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_ItemQualityImage
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
		    			this.m_E_Image_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_ItemQuality");
     				}
     				return this.m_E_Image_ItemQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_ItemQuality");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_ItemIconImage
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
		    			this.m_E_Image_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_ItemIcon");
     				}
     				return this.m_E_Image_ItemIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_ItemIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemNumText
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
		    			this.m_E_Label_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Label_ItemNum");
     				}
     				return this.m_E_Label_ItemNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Label_ItemNum");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemNameText
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
		    			this.m_E_Label_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Label_ItemName");
     				}
     				return this.m_E_Label_ItemNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Label_ItemName");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_XuanZhongImage
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
		    			this.m_E_Image_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_XuanZhong");
     				}
     				return this.m_E_Image_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_XuanZhong");
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

		private UnityEngine.UI.Button m_E_Image_ItemButtonButton = null;
		private UnityEngine.UI.Image m_E_Image_ItemButtonImage = null;
		private UnityEngine.UI.Button m_E_Image_EventTriggerButton = null;
		private UnityEngine.UI.Image m_E_Image_EventTriggerImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Image_EventTriggerEventTrigger = null;
		private UnityEngine.UI.Image m_E_Image_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_Image_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_Label_ItemNumText = null;
		private UnityEngine.UI.Text m_E_Label_ItemNameText = null;
		private UnityEngine.UI.Image m_E_Image_XuanZhongImage = null;
		public Transform uiTransform = null;
	}
}
