using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_MakeItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_MakeItem>
	{
		public int ItemID;
		public int MakeID;
		public Action<int> ActionClick;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_MakeItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageQualityImage
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
     				if( this.m_E_ImageQualityImage == null )
     				{
		    			this.m_E_ImageQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageQuality");
     				}
     				return this.m_E_ImageQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageQuality");
     			}
     		}
     	}

		public Image E_ItemHeroIonImage
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
     				if( this.m_E_ItemHeroIonImage == null )
     				{
		    			this.m_E_ItemHeroIonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemHeroIon");
     				}
     				return this.m_E_ItemHeroIonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemHeroIon");
     			}
     		}
     	}

		public Text E_Lab_PetNameText
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
     				if( this.m_E_Lab_PetNameText == null )
     				{
		    			this.m_E_Lab_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     				}
     				return this.m_E_Lab_PetNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     			}
     		}
     	}

		public Button E_Btn_XuanZhongButton
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
     				if( this.m_E_Btn_XuanZhongButton == null )
     				{
		    			this.m_E_Btn_XuanZhongButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     				}
     				return this.m_E_Btn_XuanZhongButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     			}
     		}
     	}

		public Image E_Btn_XuanZhongImage
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
     				if( this.m_E_Btn_XuanZhongImage == null )
     				{
		    			this.m_E_Btn_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     				}
     				return this.m_E_Btn_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     			}
     		}
     	}

		public Image E_Image_SelectImage
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
     				if( this.m_E_Image_SelectImage == null )
     				{
		    			this.m_E_Image_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Select");
     				}
     				return this.m_E_Image_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Select");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageQualityImage = null;
			this.m_E_ItemHeroIonImage = null;
			this.m_E_Lab_PetNameText = null;
			this.m_E_Btn_XuanZhongButton = null;
			this.m_E_Btn_XuanZhongImage = null;
			this.m_E_Image_SelectImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageQualityImage = null;
		private Image m_E_ItemHeroIonImage = null;
		private Text m_E_Lab_PetNameText = null;
		private Button m_E_Btn_XuanZhongButton = null;
		private Image m_E_Btn_XuanZhongImage = null;
		private Image m_E_Image_SelectImage = null;
		public Transform uiTransform = null;
	}
}
