using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ActivitySingInItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ActivitySingInItem> 
	{
		public GameObject CurrentImage_ItemIcon;
		public GameObject[] Image_ItemIconList = new GameObject[2];
		public Action<int> ClickHandler;
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ActivitySingInItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_Image_ItemIcon1Image
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
     				if( this.m_E_Image_ItemIcon1Image == null )
     				{
		    			this.m_E_Image_ItemIcon1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemIcon1");
     				}
     				return this.m_E_Image_ItemIcon1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemIcon1");
     			}
     		}
     	}

		public Image E_Image_ItemIcon2Image
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
     				if( this.m_E_Image_ItemIcon2Image == null )
     				{
		    			this.m_E_Image_ItemIcon2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemIcon2");
     				}
     				return this.m_E_Image_ItemIcon2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_ItemIcon2");
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

		public void DestroyWidget()
		{
			this.m_E_Image_ItemIcon1Image = null;
			this.m_E_Image_ItemIcon2Image = null;
			this.m_E_Image_XuanZhongImage = null;
			this.m_E_Image_ItemButtonButton = null;
			this.m_E_Image_ItemButtonImage = null;
			this.m_E_Label_ItemNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_Image_ItemIcon1Image = null;
		private Image m_E_Image_ItemIcon2Image = null;
		private Image m_E_Image_XuanZhongImage = null;
		private Button m_E_Image_ItemButtonButton = null;
		private Image m_E_Image_ItemButtonImage = null;
		private Text m_E_Label_ItemNameText = null;
		public Transform uiTransform = null;
	}
}
