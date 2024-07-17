using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetSelectItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetSelectItem>
	{
		public PetOperationType OperationType; //1合成 2洗练
		public RolePetInfo RolePetInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetSelectItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ImageDiButtonButton
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
		    			this.m_E_ImageDiButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageDiButton");
     				}
     				return this.m_E_ImageDiButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageDiButton");
     			}
     		}
     	}

		public Image E_ImageDiButtonImage
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
		    			this.m_E_ImageDiButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDiButton");
     				}
     				return this.m_E_ImageDiButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDiButton");
     			}
     		}
     	}

		public Image E_ImageXuanzhongImage
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
		    			this.m_E_ImageXuanzhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageXuanzhong");
     				}
     				return this.m_E_ImageXuanzhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageXuanzhong");
     			}
     		}
     	}

		public Image E_Img_PeteroQualityImage
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
		    			this.m_E_Img_PeteroQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_PeteroQuality");
     				}
     				return this.m_E_Img_PeteroQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_PeteroQuality");
     			}
     		}
     	}

		public Image E_Img_PetHeroIonImage
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
		    			this.m_E_Img_PetHeroIonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
     				}
     				return this.m_E_Img_PetHeroIonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
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

		public Text E_Lab_PetLvText
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
		    			this.m_E_Lab_PetLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PetLv");
     				}
     				return this.m_E_Lab_PetLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PetLv");
     			}
     		}
     	}

		public Image E_Img_CanZhanImage
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
		    			this.m_E_Img_CanZhanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_CanZhan");
     				}
     				return this.m_E_Img_CanZhanImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_CanZhan");
     			}
     		}
     	}

		public Image E_Img_StartImage
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
		    			this.m_E_Img_StartImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Start");
     				}
     				return this.m_E_Img_StartImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Start");
     			}
     		}
     	}

		public Text E_Lab_StartLvText
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
		    			this.m_E_Lab_StartLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_StartLv");
     				}
     				return this.m_E_Lab_StartLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_StartLv");
     			}
     		}
     	}

		public Image E_Image_ProtectImage
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
		    			this.m_E_Image_ProtectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Protect");
     				}
     				return this.m_E_Image_ProtectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Protect");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageDiButtonButton = null;
			this.m_E_ImageDiButtonImage = null;
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

		private Button m_E_ImageDiButtonButton = null;
		private Image m_E_ImageDiButtonImage = null;
		private Image m_E_ImageXuanzhongImage = null;
		private Image m_E_Img_PeteroQualityImage = null;
		private Image m_E_Img_PetHeroIonImage = null;
		private Text m_E_Lab_PetNameText = null;
		private Text m_E_Lab_PetLvText = null;
		private Image m_E_Img_CanZhanImage = null;
		private Image m_E_Img_StartImage = null;
		private Text m_E_Lab_StartLvText = null;
		private Image m_E_Image_ProtectImage = null;
		public Transform uiTransform = null;
	}
}
