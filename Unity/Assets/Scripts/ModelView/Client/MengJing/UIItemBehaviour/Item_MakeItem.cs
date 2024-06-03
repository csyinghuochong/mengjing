
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_MakeItem : Entity,IAwake,IDestroy,IUIScrollItem 
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

		public UnityEngine.UI.Image E_ImageQualityImage
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
		    			this.m_E_ImageQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageQuality");
     				}
     				return this.m_E_ImageQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageQuality");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ItemHeroIonImage
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
		    			this.m_E_ItemHeroIonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemHeroIon");
     				}
     				return this.m_E_ItemHeroIonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemHeroIon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PetNameText
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
		    			this.m_E_Lab_PetNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     				}
     				return this.m_E_Lab_PetNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XuanZhongButton
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
		    			this.m_E_Btn_XuanZhongButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     				}
     				return this.m_E_Btn_XuanZhongButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XuanZhongImage
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
		    			this.m_E_Btn_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     				}
     				return this.m_E_Btn_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_SelectImage
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
		    			this.m_E_Image_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_Select");
     				}
     				return this.m_E_Image_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_Select");
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

		private UnityEngine.UI.Image m_E_ImageQualityImage = null;
		private UnityEngine.UI.Image m_E_ItemHeroIonImage = null;
		private UnityEngine.UI.Text m_E_Lab_PetNameText = null;
		private UnityEngine.UI.Button m_E_Btn_XuanZhongButton = null;
		private UnityEngine.UI.Image m_E_Btn_XuanZhongImage = null;
		private UnityEngine.UI.Image m_E_Image_SelectImage = null;
		public Transform uiTransform = null;
	}
}
