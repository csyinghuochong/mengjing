using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetSkinIconItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetSkinIconItem>
	{
		public Action<int> ClickHandler;
		public int SkinId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetSkinIconItem BindTrans(Transform trans)
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

		public Text E_TextSkinNameText
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
     				if( this.m_E_TextSkinNameText == null )
     				{
		    			this.m_E_TextSkinNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextSkinName");
     				}
     				return this.m_E_TextSkinNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextSkinName");
     			}
     		}
     	}

		public Text E_JiHuoSetText
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
     				if( this.m_E_JiHuoSetText == null )
     				{
		    			this.m_E_JiHuoSetText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_JiHuoSet");
     				}
     				return this.m_E_JiHuoSetText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_JiHuoSet");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Image_ItemButtonButton = null;
			this.m_E_Image_ItemButtonImage = null;
			this.m_E_Image_ItemQualityImage = null;
			this.m_E_Image_ItemIconImage = null;
			this.m_E_Image_XuanZhongImage = null;
			this.m_E_TextSkinNameText = null;
			this.m_E_JiHuoSetText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_Image_ItemButtonButton = null;
		private Image m_E_Image_ItemButtonImage = null;
		private Image m_E_Image_ItemQualityImage = null;
		private Image m_E_Image_ItemIconImage = null;
		private Image m_E_Image_XuanZhongImage = null;
		private Text m_E_TextSkinNameText = null;
		private Text m_E_JiHuoSetText = null;
		public Transform uiTransform = null;
	}
}
