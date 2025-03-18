using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetInfoShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public GameObject[] PetZiZhiItemList = new GameObject[6];
		public int Weizhi; //-1左 1 右边
		public PetOperationType BagOperationType;
		public RolePetInfo RolePetInfo;
		public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
		public List<int> ShowPetSkills = new();
		
		public RectTransform EG_ImageStarListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ImageStarListRectTransform == null )
     			{
		    		this.m_EG_ImageStarListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_ImageStarList");
     			}
     			return this.m_EG_ImageStarListRectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem1RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem2RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem3RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem4RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem5RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem6RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem6RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_QieHuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_QieHuanButton == null )
     			{
		    		this.m_E_Btn_QieHuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_Btn_QieHuan");
     			}
     			return this.m_E_Btn_QieHuanButton;
     		}
     	}

		public Image E_Btn_QieHuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_QieHuanImage == null )
     			{
		    		this.m_E_Btn_QieHuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Btn_QieHuan");
     			}
     			return this.m_E_Btn_QieHuanImage;
     		}
     	}

		public Button E_Img_PeteroQualityButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_PeteroQualityButton == null )
     			{
		    		this.m_E_Img_PeteroQualityButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_Img_PeteroQuality");
     			}
     			return this.m_E_Img_PeteroQualityButton;
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
     			if( this.m_E_Img_PeteroQualityImage == null )
     			{
		    		this.m_E_Img_PeteroQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Img_PeteroQuality");
     			}
     			return this.m_E_Img_PeteroQualityImage;
     		}
     	}

		public Image E_Img_PeteroQualityaddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_PeteroQualityaddImage == null )
     			{
		    		this.m_E_Img_PeteroQualityaddImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Img_PeteroQuality/E_Img_PeteroQualityadd");
     			}
     			return this.m_E_Img_PeteroQualityaddImage;
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
     			if( this.m_E_Img_PetHeroIonImage == null )
     			{
		    		this.m_E_Img_PetHeroIonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Img_PetHeroIon");
     			}
     			return this.m_E_Img_PetHeroIonImage;
     		}
     	}

		public Image E_ImageExpValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageExpValueImage == null )
     			{
		    		this.m_E_ImageExpValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/ImageExpDi/E_ImageExpValue");
     			}
     			return this.m_E_ImageExpValueImage;
     		}
     	}

		public Text E_Text_PetNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetNameText == null )
     			{
		    		this.m_E_Text_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetName");
     			}
     			return this.m_E_Text_PetNameText;
     		}
     	}

		public Text E_Text_PetLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetLevelText == null )
     			{
		    		this.m_E_Text_PetLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetLevel");
     			}
     			return this.m_E_Text_PetLevelText;
     		}
     	}

		public Text E_Text_PetExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetExpText == null )
     			{
		    		this.m_E_Text_PetExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetExp");
     			}
     			return this.m_E_Text_PetExpText;
     		}
     	}
		
		public Text E_Text_PetPingFen
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_PetPingFen == null )
				{
					this.m_E_Text_PetPingFen = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetPingFen");
				}
				return this.m_E_Text_PetPingFen;
			}
		}


		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_EG_ImageStarListRectTransform = null;
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_QieHuanButton = null;
			this.m_E_Btn_QieHuanImage = null;
			this.m_E_Img_PeteroQualityButton = null;
			this.m_E_Img_PeteroQualityImage = null;
			this.m_E_Img_PeteroQualityaddImage = null;
			this.m_E_Img_PetHeroIonImage = null;
			this.m_E_ImageExpValueImage = null;
			this.m_E_Text_PetNameText = null;
			this.m_E_Text_PetLevelText = null;
			this.m_E_Text_PetExpText = null;
			this.m_E_Text_PetPingFen = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_ImageStarListRectTransform = null;
		private RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_QieHuanButton = null;
		private Image m_E_Btn_QieHuanImage = null;
		private Button m_E_Img_PeteroQualityButton = null;
		private Image m_E_Img_PeteroQualityImage = null;
		private Image m_E_Img_PeteroQualityaddImage = null;
		private Image m_E_Img_PetHeroIonImage = null;
		private Image m_E_ImageExpValueImage = null;
		private Text m_E_Text_PetNameText = null;
		private Text m_E_Text_PetLevelText = null;
		private Text m_E_Text_PetExpText = null;
		private Text m_E_Text_PetPingFen = null;
		public Transform uiTransform = null;
	}
}
