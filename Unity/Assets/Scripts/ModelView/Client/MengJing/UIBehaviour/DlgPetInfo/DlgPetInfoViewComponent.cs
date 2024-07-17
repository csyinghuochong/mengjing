using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetInfo))]
	[EnableMethod]
	public  class DlgPetInfoViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_PetHeXinItem0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinItem0Image == null )
     			{
		    		this.m_E_PetHeXinItem0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_PetHeXinItem0");
     			}
     			return this.m_E_PetHeXinItem0Image;
     		}
     	}

		public Image E_PetHeXinItem1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinItem1Image == null )
     			{
		    		this.m_E_PetHeXinItem1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_PetHeXinItem1");
     			}
     			return this.m_E_PetHeXinItem1Image;
     		}
     	}

		public Image E_PetHeXinItem2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinItem2Image == null )
     			{
		    		this.m_E_PetHeXinItem2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_PetHeXinItem2");
     			}
     			return this.m_E_PetHeXinItem2Image;
     		}
     	}

		public Button E_ButtonAddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAddPointButton == null )
     			{
		    		this.m_E_ButtonAddPointButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointButton;
     		}
     	}

		public Image E_ButtonAddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAddPointImage == null )
     			{
		    		this.m_E_ButtonAddPointImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointImage;
     		}
     	}

		public RectTransform EG_AttributeNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AttributeNodeRectTransform == null )
     			{
		    		this.m_EG_AttributeNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode");
     			}
     			return this.m_EG_AttributeNodeRectTransform;
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
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetZiZhiSet/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public Text E_PropertyShowTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PropertyShowTextText == null )
     			{
		    		this.m_E_PropertyShowTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetPiFuSet/E_PropertyShowText");
     			}
     			return this.m_E_PropertyShowTextText;
     		}
     	}

		public Image E_SkinJiHuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkinJiHuoImage == null )
     			{
		    		this.m_E_SkinJiHuoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetPiFuSet/E_SkinJiHuo");
     			}
     			return this.m_E_SkinJiHuoImage;
     		}
     	}

		public Image E_SkinWeiJiHuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkinWeiJiHuoImage == null )
     			{
		    		this.m_E_SkinWeiJiHuoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetPiFuSet/E_SkinWeiJiHuo");
     			}
     			return this.m_E_SkinWeiJiHuoImage;
     		}
     	}

		public Image E_PetProSetNodeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetProSetNodeImage == null )
     			{
		    		this.m_E_PetProSetNodeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode");
     			}
     			return this.m_E_PetProSetNodeImage;
     		}
     	}

		public RectTransform EG_PetProSetItem_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetProSetItem_1RectTransform == null )
     			{
		    		this.m_EG_PetProSetItem_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_1");
     			}
     			return this.m_EG_PetProSetItem_1RectTransform;
     		}
     	}

		public RectTransform EG_PetProSetItem_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetProSetItem_2RectTransform == null )
     			{
		    		this.m_EG_PetProSetItem_2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_2");
     			}
     			return this.m_EG_PetProSetItem_2RectTransform;
     		}
     	}

		public RectTransform EG_PetProSetNode_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetProSetNode_1RectTransform == null )
     			{
		    		this.m_EG_PetProSetNode_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetNode_1");
     			}
     			return this.m_EG_PetProSetNode_1RectTransform;
     		}
     	}

		public RectTransform EG_PetProSetNode_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetProSetNode_2RectTransform == null )
     			{
		    		this.m_EG_PetProSetNode_2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetNode_2");
     			}
     			return this.m_EG_PetProSetNode_2RectTransform;
     		}
     	}

		public RectTransform EG_PetHeXinSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetHeXinSetRectTransform == null )
     			{
		    		this.m_EG_PetHeXinSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_PetHeXinSet");
     			}
     			return this.m_EG_PetHeXinSetRectTransform;
     		}
     	}

		public Button E_ButtonCloseHexinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseHexinButton == null )
     			{
		    		this.m_E_ButtonCloseHexinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinButton;
     		}
     	}

		public Image E_ButtonCloseHexinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseHexinImage == null )
     			{
		    		this.m_E_ButtonCloseHexinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinImage;
     		}
     	}

		public RectTransform EG_PetAddPointRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetAddPointRectTransform == null )
     			{
		    		this.m_EG_PetAddPointRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_PetAddPoint");
     			}
     			return this.m_EG_PetAddPointRectTransform;
     		}
     	}

		public Button E_ButtonCloseAddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseAddPointButton == null )
     			{
		    		this.m_E_ButtonCloseAddPointButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointButton;
     		}
     	}

		public Image E_ButtonCloseAddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseAddPointImage == null )
     			{
		    		this.m_E_ButtonCloseAddPointImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointImage;
     		}
     	}

		public Text E_Text_PetPingFenText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetPingFenText == null )
     			{
		    		this.m_E_Text_PetPingFenText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_PetPingFen");
     			}
     			return this.m_E_Text_PetPingFenText;
     		}
     	}

		public Button E_ImageJinHuaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageJinHuaButton == null )
     			{
		    		this.m_E_ImageJinHuaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaButton;
     		}
     	}

		public Image E_ImageJinHuaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageJinHuaImage == null )
     			{
		    		this.m_E_ImageJinHuaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaImage;
     		}
     	}

		public Text E_Lab_JinHuaText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_JinHuaText == null )
     			{
		    		this.m_E_Lab_JinHuaText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_ImageJinHua/E_Lab_JinHua");
     			}
     			return this.m_E_Lab_JinHuaText;
     		}
     	}

		public Image E_JinHuaReddotImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JinHuaReddotImage == null )
     			{
		    		this.m_E_JinHuaReddotImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ImageJinHua/E_JinHuaReddot");
     			}
     			return this.m_E_JinHuaReddotImage;
     		}
     	}

		public Image E_ImageShouHuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageShouHuImage == null )
     			{
		    		this.m_E_ImageShouHuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/ImageJinHua (1)/E_ImageShouHu");
     			}
     			return this.m_E_ImageShouHuImage;
     		}
     	}

		public Text E_Text_ShouHuText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ShouHuText == null )
     			{
		    		this.m_E_Text_ShouHuText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/ImageJinHua (1)/E_Text_ShouHu");
     			}
     			return this.m_E_Text_ShouHuText;
     		}
     	}

		public Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PetHeXinItem0Image = null;
			this.m_E_PetHeXinItem1Image = null;
			this.m_E_PetHeXinItem2Image = null;
			this.m_E_ButtonAddPointButton = null;
			this.m_E_ButtonAddPointImage = null;
			this.m_EG_AttributeNodeRectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_E_PropertyShowTextText = null;
			this.m_E_SkinJiHuoImage = null;
			this.m_E_SkinWeiJiHuoImage = null;
			this.m_E_PetProSetNodeImage = null;
			this.m_EG_PetProSetItem_1RectTransform = null;
			this.m_EG_PetProSetItem_2RectTransform = null;
			this.m_EG_PetProSetNode_1RectTransform = null;
			this.m_EG_PetProSetNode_2RectTransform = null;
			this.m_EG_PetHeXinSetRectTransform = null;
			this.m_E_ButtonCloseHexinButton = null;
			this.m_E_ButtonCloseHexinImage = null;
			this.m_EG_PetAddPointRectTransform = null;
			this.m_E_ButtonCloseAddPointButton = null;
			this.m_E_ButtonCloseAddPointImage = null;
			this.m_E_Text_PetPingFenText = null;
			this.m_E_ImageJinHuaButton = null;
			this.m_E_ImageJinHuaImage = null;
			this.m_E_Lab_JinHuaText = null;
			this.m_E_JinHuaReddotImage = null;
			this.m_E_ImageShouHuImage = null;
			this.m_E_Text_ShouHuText = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private Image m_E_PetHeXinItem0Image = null;
		private Image m_E_PetHeXinItem1Image = null;
		private Image m_E_PetHeXinItem2Image = null;
		private Button m_E_ButtonAddPointButton = null;
		private Image m_E_ButtonAddPointImage = null;
		private RectTransform m_EG_AttributeNodeRectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private Text m_E_PropertyShowTextText = null;
		private Image m_E_SkinJiHuoImage = null;
		private Image m_E_SkinWeiJiHuoImage = null;
		private Image m_E_PetProSetNodeImage = null;
		private RectTransform m_EG_PetProSetItem_1RectTransform = null;
		private RectTransform m_EG_PetProSetItem_2RectTransform = null;
		private RectTransform m_EG_PetProSetNode_1RectTransform = null;
		private RectTransform m_EG_PetProSetNode_2RectTransform = null;
		private RectTransform m_EG_PetHeXinSetRectTransform = null;
		private Button m_E_ButtonCloseHexinButton = null;
		private Image m_E_ButtonCloseHexinImage = null;
		private RectTransform m_EG_PetAddPointRectTransform = null;
		private Button m_E_ButtonCloseAddPointButton = null;
		private Image m_E_ButtonCloseAddPointImage = null;
		private Text m_E_Text_PetPingFenText = null;
		private Button m_E_ImageJinHuaButton = null;
		private Image m_E_ImageJinHuaImage = null;
		private Text m_E_Lab_JinHuaText = null;
		private Image m_E_JinHuaReddotImage = null;
		private Image m_E_ImageShouHuImage = null;
		private Text m_E_Text_ShouHuText = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
