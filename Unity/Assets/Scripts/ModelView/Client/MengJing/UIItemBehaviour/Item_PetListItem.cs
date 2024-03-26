
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetListItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long PetId;
		public Action<long> ClickPetHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetListItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.RectTransform EG_Node_1RectTransform
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
     				if( this.m_EG_Node_1RectTransform == null )
     				{
		    			this.m_EG_Node_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1");
     				}
     				return this.m_EG_Node_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1");
     			}
     		}
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
		    			this.m_E_ImageDiButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiButton");
     				}
     				return this.m_E_ImageDiButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiButton");
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
		    			this.m_E_ImageDiButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiButton");
     				}
     				return this.m_E_ImageDiButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageDiEventTriggerImage
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
     				if( this.m_E_ImageDiEventTriggerImage == null )
     				{
		    			this.m_E_ImageDiEventTriggerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiEventTrigger");
     				}
     				return this.m_E_ImageDiEventTriggerImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiEventTrigger");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ImageDiEventTriggerEventTrigger
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
     				if( this.m_E_ImageDiEventTriggerEventTrigger == null )
     				{
		    			this.m_E_ImageDiEventTriggerEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiEventTrigger");
     				}
     				return this.m_E_ImageDiEventTriggerEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_Node_1/E_ImageDiEventTrigger");
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
		    			this.m_E_ImageXuanzhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ImageXuanzhong");
     				}
     				return this.m_E_ImageXuanzhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ImageXuanzhong");
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
		    			this.m_E_Img_PeteroQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Img_PeteroQuality");
     				}
     				return this.m_E_Img_PeteroQualityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Img_PeteroQuality");
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
		    			this.m_E_Img_PetHeroIonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Img_PetHeroIon");
     				}
     				return this.m_E_Img_PetHeroIonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Img_PetHeroIon");
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
		    			this.m_E_Img_CanZhanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Img_CanZhan");
     				}
     				return this.m_E_Img_CanZhanImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Img_CanZhan");
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
		    			this.m_E_Lab_PetNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_PetName");
     				}
     				return this.m_E_Lab_PetNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_PetName");
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
		    			this.m_E_Lab_PetLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_PetLv");
     				}
     				return this.m_E_Lab_PetLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_PetLv");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_StatusText
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
     				if( this.m_E_Lab_StatusText == null )
     				{
		    			this.m_E_Lab_StatusText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_Status");
     				}
     				return this.m_E_Lab_StatusText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_Status");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_StartSetRectTransform
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
     				if( this.m_EG_StartSetRectTransform == null )
     				{
		    			this.m_EG_StartSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet");
     				}
     				return this.m_EG_StartSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_Start_5Image
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
     				if( this.m_E_Img_Start_5Image == null )
     				{
		    			this.m_E_Img_Start_5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_5");
     				}
     				return this.m_E_Img_Start_5Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_5");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_Start_4Image
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
     				if( this.m_E_Img_Start_4Image == null )
     				{
		    			this.m_E_Img_Start_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_4");
     				}
     				return this.m_E_Img_Start_4Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_4");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_Start_3Image
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
     				if( this.m_E_Img_Start_3Image == null )
     				{
		    			this.m_E_Img_Start_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_3");
     				}
     				return this.m_E_Img_Start_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_3");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_Start_2Image
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
     				if( this.m_E_Img_Start_2Image == null )
     				{
		    			this.m_E_Img_Start_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_2");
     				}
     				return this.m_E_Img_Start_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_2");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_Start_1Image
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
     				if( this.m_E_Img_Start_1Image == null )
     				{
		    			this.m_E_Img_Start_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_1");
     				}
     				return this.m_E_Img_Start_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/EG_StartSet/E_Img_Start_1");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_StartShowSetRectTransform
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
     				if( this.m_EG_StartShowSetRectTransform == null )
     				{
		    			this.m_EG_StartShowSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1/EG_StartShowSet");
     				}
     				return this.m_EG_StartShowSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1/EG_StartShowSet");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_StartShowText
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
     				if( this.m_E_Lab_StartShowText == null )
     				{
		    			this.m_E_Lab_StartShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/EG_StartShowSet/E_Lab_StartShow");
     				}
     				return this.m_E_Lab_StartShowText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/EG_StartShowSet/E_Lab_StartShow");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PetQualityText
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
     				if( this.m_E_Lab_PetQualityText == null )
     				{
		    			this.m_E_Lab_PetQualityText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_PetQuality");
     				}
     				return this.m_E_Lab_PetQualityText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_PetQuality");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ReddotImage
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
     				if( this.m_E_ReddotImage == null )
     				{
		    			this.m_E_ReddotImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Reddot");
     				}
     				return this.m_E_ReddotImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Reddot");
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
		    			this.m_E_Image_ProtectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Image_Protect");
     				}
     				return this.m_E_Image_ProtectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_Image_Protect");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_Node_2RectTransform
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
     				if( this.m_EG_Node_2RectTransform == null )
     				{
		    			this.m_EG_Node_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_2");
     				}
     				return this.m_EG_Node_2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_2");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_OpenText
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
     				if( this.m_E_Text_OpenText == null )
     				{
		    			this.m_E_Text_OpenText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_2/E_Text_Open");
     				}
     				return this.m_E_Text_OpenText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_2/E_Text_Open");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_Node_1RectTransform = null;
			this.m_E_ImageDiButtonButton = null;
			this.m_E_ImageDiButtonImage = null;
			this.m_E_ImageDiEventTriggerImage = null;
			this.m_E_ImageDiEventTriggerEventTrigger = null;
			this.m_E_ImageXuanzhongImage = null;
			this.m_E_Img_PeteroQualityImage = null;
			this.m_E_Img_PetHeroIonImage = null;
			this.m_E_Img_CanZhanImage = null;
			this.m_E_Lab_PetNameText = null;
			this.m_E_Lab_PetLvText = null;
			this.m_E_Lab_StatusText = null;
			this.m_EG_StartSetRectTransform = null;
			this.m_E_Img_Start_5Image = null;
			this.m_E_Img_Start_4Image = null;
			this.m_E_Img_Start_3Image = null;
			this.m_E_Img_Start_2Image = null;
			this.m_E_Img_Start_1Image = null;
			this.m_EG_StartShowSetRectTransform = null;
			this.m_E_Lab_StartShowText = null;
			this.m_E_Lab_PetQualityText = null;
			this.m_E_ReddotImage = null;
			this.m_E_Image_ProtectImage = null;
			this.m_EG_Node_2RectTransform = null;
			this.m_E_Text_OpenText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.RectTransform m_EG_Node_1RectTransform = null;
		private UnityEngine.UI.Button m_E_ImageDiButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageDiButtonImage = null;
		private UnityEngine.UI.Image m_E_ImageDiEventTriggerImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ImageDiEventTriggerEventTrigger = null;
		private UnityEngine.UI.Image m_E_ImageXuanzhongImage = null;
		private UnityEngine.UI.Image m_E_Img_PeteroQualityImage = null;
		private UnityEngine.UI.Image m_E_Img_PetHeroIonImage = null;
		private UnityEngine.UI.Image m_E_Img_CanZhanImage = null;
		private UnityEngine.UI.Text m_E_Lab_PetNameText = null;
		private UnityEngine.UI.Text m_E_Lab_PetLvText = null;
		private UnityEngine.UI.Text m_E_Lab_StatusText = null;
		private UnityEngine.RectTransform m_EG_StartSetRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_Start_5Image = null;
		private UnityEngine.UI.Image m_E_Img_Start_4Image = null;
		private UnityEngine.UI.Image m_E_Img_Start_3Image = null;
		private UnityEngine.UI.Image m_E_Img_Start_2Image = null;
		private UnityEngine.UI.Image m_E_Img_Start_1Image = null;
		private UnityEngine.RectTransform m_EG_StartShowSetRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_StartShowText = null;
		private UnityEngine.UI.Text m_E_Lab_PetQualityText = null;
		private UnityEngine.UI.Image m_E_ReddotImage = null;
		private UnityEngine.UI.Image m_E_Image_ProtectImage = null;
		private UnityEngine.RectTransform m_EG_Node_2RectTransform = null;
		private UnityEngine.UI.Text m_E_Text_OpenText = null;
		public Transform uiTransform = null;
	}
}
