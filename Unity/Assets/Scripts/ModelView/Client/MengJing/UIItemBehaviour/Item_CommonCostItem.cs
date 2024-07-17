using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CommonCostItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_CommonCostItem>
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CommonCostItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ItemButtonButton
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
     				if( this.m_E_ItemButtonButton == null )
     				{
		    			this.m_E_ItemButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ItemButton");
     				}
     				return this.m_E_ItemButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ItemButton");
     			}
     		}
     	}

		public Image E_ItemButtonImage
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
     				if( this.m_E_ItemButtonImage == null )
     				{
		    			this.m_E_ItemButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemButton");
     				}
     				return this.m_E_ItemButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemButton");
     			}
     		}
     	}

		public Button E_EventTriggerButton
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
     				if( this.m_E_EventTriggerButton == null )
     				{
		    			this.m_E_EventTriggerButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_EventTrigger");
     				}
     				return this.m_E_EventTriggerButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_EventTrigger");
     			}
     		}
     	}

		public Image E_EventTriggerImage
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
     				if( this.m_E_EventTriggerImage == null )
     				{
		    			this.m_E_EventTriggerImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EventTrigger");
     				}
     				return this.m_E_EventTriggerImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EventTrigger");
     			}
     		}
     	}

		public EventTrigger E_EventTriggerEventTrigger
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
     				if( this.m_E_EventTriggerEventTrigger == null )
     				{
		    			this.m_E_EventTriggerEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_EventTrigger");
     				}
     				return this.m_E_EventTriggerEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_EventTrigger");
     			}
     		}
     	}

		public Image E_ItemQualityImage
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
     				if( this.m_E_ItemQualityImage == null )
     				{
		    			this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemQuality");
     				}
     				return this.m_E_ItemQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemQuality");
     			}
     		}
     	}

		public Image E_ItemIconImage
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
     				if( this.m_E_ItemIconImage == null )
     				{
		    			this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemIcon");
     				}
     				return this.m_E_ItemIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemIcon");
     			}
     		}
     	}

		public Text E_ItemNumText
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
     				if( this.m_E_ItemNumText == null )
     				{
		    			this.m_E_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ItemNum");
     				}
     				return this.m_E_ItemNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ItemNum");
     			}
     		}
     	}

		public Text E_ItemNameText
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
     				if( this.m_E_ItemNameText == null )
     				{
		    			this.m_E_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ItemName");
     				}
     				return this.m_E_ItemNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ItemName");
     			}
     		}
     	}

		public Image E_XuanZhongImage
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
     				if( this.m_E_XuanZhongImage == null )
     				{
		    			this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_XuanZhong");
     				}
     				return this.m_E_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_XuanZhong");
     			}
     		}
     	}

		public Image E_ItemEffectImage
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
     				if( this.m_E_ItemEffectImage == null )
     				{
		    			this.m_E_ItemEffectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemEffect");
     				}
     				return this.m_E_ItemEffectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemEffect");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ItemButtonButton = null;
			this.m_E_ItemButtonImage = null;
			this.m_E_EventTriggerButton = null;
			this.m_E_EventTriggerImage = null;
			this.m_E_EventTriggerEventTrigger = null;
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_ItemNumText = null;
			this.m_E_ItemNameText = null;
			this.m_E_XuanZhongImage = null;
			this.m_E_ItemEffectImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ItemButtonButton = null;
		private Image m_E_ItemButtonImage = null;
		private Button m_E_EventTriggerButton = null;
		private Image m_E_EventTriggerImage = null;
		private EventTrigger m_E_EventTriggerEventTrigger = null;
		private Image m_E_ItemQualityImage = null;
		private Image m_E_ItemIconImage = null;
		private Text m_E_ItemNumText = null;
		private Text m_E_ItemNameText = null;
		private Image m_E_XuanZhongImage = null;
		private Image m_E_ItemEffectImage = null;
		public Transform uiTransform = null;
	}
}
