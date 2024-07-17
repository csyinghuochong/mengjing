using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_MakeNeedItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_MakeNeedItem>
	{
		public int ItemId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_MakeNeedItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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

		public void DestroyWidget()
		{
			this.m_E_Label_ItemNameText = null;
			this.m_E_Label_ItemNumText = null;
			this.m_E_Image_ItemQualityImage = null;
			this.m_E_Image_ItemIconImage = null;
			this.m_E_Image_EventTriggerButton = null;
			this.m_E_Image_EventTriggerImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_Label_ItemNameText = null;
		private Text m_E_Label_ItemNumText = null;
		private Image m_E_Image_ItemQualityImage = null;
		private Image m_E_Image_ItemIconImage = null;
		private Button m_E_Image_EventTriggerButton = null;
		private Image m_E_Image_EventTriggerImage = null;
		public Transform uiTransform = null;
	}
}
