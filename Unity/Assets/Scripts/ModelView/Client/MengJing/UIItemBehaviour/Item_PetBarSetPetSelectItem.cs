
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_PetBarSetPetSelectItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetBarSetPetSelectItem> 
	{
		public RolePetInfo RolePetInfo;
		public Action<long> OnSelectPet;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetBarSetPetSelectItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_ImageDiButtonButton
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
     				if( this.m_E_ImageDiButtonButton == null )
     				{
		    			this.m_E_ImageDiButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageDiButton");
     				}
     				return this.m_E_ImageDiButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageDiButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageDiButtonImage
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
     				if( this.m_E_ImageDiButtonImage == null )
     				{
		    			this.m_E_ImageDiButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDiButton");
     				}
     				return this.m_E_ImageDiButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDiButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageDiImage
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
     				if( this.m_E_ImageDiImage == null )
     				{
		    			this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDi");
     				}
     				return this.m_E_ImageDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageXuanzhongImage
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
     				if( this.m_E_ImageXuanzhongImage == null )
     				{
		    			this.m_E_ImageXuanzhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageXuanzhong");
     				}
     				return this.m_E_ImageXuanzhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageXuanzhong");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_PeteroQualityImage
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
     				if( this.m_E_Img_PeteroQualityImage == null )
     				{
		    			this.m_E_Img_PeteroQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_PeteroQuality");
     				}
     				return this.m_E_Img_PeteroQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_PeteroQuality");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_PetHeroIonImage
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
     				if( this.m_E_Img_PetHeroIonImage == null )
     				{
		    			this.m_E_Img_PetHeroIonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
     				}
     				return this.m_E_Img_PetHeroIonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
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

		public UnityEngine.UI.Text E_Lab_PetLvText
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
     				if( this.m_E_Lab_PetLvText == null )
     				{
		    			this.m_E_Lab_PetLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetLv");
     				}
     				return this.m_E_Lab_PetLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetLv");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_CanZhanImage
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
     				if( this.m_E_Img_CanZhanImage == null )
     				{
		    			this.m_E_Img_CanZhanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_CanZhan");
     				}
     				return this.m_E_Img_CanZhanImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_CanZhan");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_StartImage
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
     				if( this.m_E_Img_StartImage == null )
     				{
		    			this.m_E_Img_StartImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_Start");
     				}
     				return this.m_E_Img_StartImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_Start");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_StartLvText
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
     				if( this.m_E_Lab_StartLvText == null )
     				{
		    			this.m_E_Lab_StartLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_StartLv");
     				}
     				return this.m_E_Lab_StartLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_StartLv");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_ProtectImage
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
     				if( this.m_E_Image_ProtectImage == null )
     				{
		    			this.m_E_Image_ProtectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_Protect");
     				}
     				return this.m_E_Image_ProtectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_Protect");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageDiButtonButton = null;
			this.m_E_ImageDiButtonImage = null;
			this.m_E_ImageDiImage = null;
			this.m_E_ImageXuanzhongImage = null;
			this.m_E_Img_PeteroQualityImage = null;
			this.m_E_Img_PetHeroIonImage = null;
			this.m_E_Lab_PetNameText = null;
			this.m_E_Lab_PetLvText = null;
			this.m_E_Img_CanZhanImage = null;
			this.m_E_Img_StartImage = null;
			this.m_E_Lab_StartLvText = null;
			this.m_E_Image_ProtectImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ImageDiButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageDiButtonImage = null;
		private UnityEngine.UI.Image m_E_ImageDiImage = null;
		private UnityEngine.UI.Image m_E_ImageXuanzhongImage = null;
		private UnityEngine.UI.Image m_E_Img_PeteroQualityImage = null;
		private UnityEngine.UI.Image m_E_Img_PetHeroIonImage = null;
		private UnityEngine.UI.Text m_E_Lab_PetNameText = null;
		private UnityEngine.UI.Text m_E_Lab_PetLvText = null;
		private UnityEngine.UI.Image m_E_Img_CanZhanImage = null;
		private UnityEngine.UI.Image m_E_Img_StartImage = null;
		private UnityEngine.UI.Text m_E_Lab_StartLvText = null;
		private UnityEngine.UI.Image m_E_Image_ProtectImage = null;
		public Transform uiTransform = null;
	}
}
