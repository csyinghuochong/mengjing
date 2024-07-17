using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_MakeLearnItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_MakeLearnItem>
	{
		public int MakeId;
		public Action<int> ClickHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_MakeLearnItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ImageButtonButton
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
     				if( this.m_E_ImageButtonButton == null )
     				{
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public Image E_ImageButtonImage
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
     				if( this.m_E_ImageButtonImage == null )
     				{
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
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

		public Image E_ImageSelectImage
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
     				if( this.m_E_ImageSelectImage == null )
     				{
		    			this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageSelect");
     				}
     				return this.m_E_ImageSelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageSelect");
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

		public Text E_Label_LearnLvText
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
     				if( this.m_E_Label_LearnLvText == null )
     				{
		    			this.m_E_Label_LearnLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Label_LearnLv");
     				}
     				return this.m_E_Label_LearnLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Label_LearnLv");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Image_ItemQualityImage = null;
			this.m_E_Image_ItemIconImage = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_Label_ItemNameText = null;
			this.m_E_Label_LearnLvText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Image m_E_Image_ItemQualityImage = null;
		private Image m_E_Image_ItemIconImage = null;
		private Image m_E_ImageSelectImage = null;
		private Text m_E_Label_ItemNameText = null;
		private Text m_E_Label_LearnLvText = null;
		public Transform uiTransform = null;
	}
}
