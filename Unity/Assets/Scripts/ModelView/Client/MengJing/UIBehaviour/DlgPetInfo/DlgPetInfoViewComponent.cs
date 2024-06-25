
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetInfo))]
	[EnableMethod]
	public  class DlgPetInfoViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_PetHeXinItem0Image
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
		    		this.m_E_PetHeXinItem0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_PetHeXinItem0");
     			}
     			return this.m_E_PetHeXinItem0Image;
     		}
     	}

		public UnityEngine.UI.Image E_PetHeXinItem1Image
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
		    		this.m_E_PetHeXinItem1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_PetHeXinItem1");
     			}
     			return this.m_E_PetHeXinItem1Image;
     		}
     	}

		public UnityEngine.UI.Image E_PetHeXinItem2Image
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
		    		this.m_E_PetHeXinItem2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_PetHeXinItem2");
     			}
     			return this.m_E_PetHeXinItem2Image;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonAddPointButton
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
		    		this.m_E_ButtonAddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonAddPointImage
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
		    		this.m_E_ButtonAddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointImage;
     		}
     	}

		public UnityEngine.RectTransform EG_AttributeNodeRectTransform
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
		    		this.m_EG_AttributeNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode");
     			}
     			return this.m_EG_AttributeNodeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem6RectTransform
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
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetZiZhiSet/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_PropertyShowTextText
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
		    		this.m_E_PropertyShowTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetPiFuSet/E_PropertyShowText");
     			}
     			return this.m_E_PropertyShowTextText;
     		}
     	}

		public UnityEngine.UI.Image E_SkinJiHuoImage
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
		    		this.m_E_SkinJiHuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetPiFuSet/E_SkinJiHuo");
     			}
     			return this.m_E_SkinJiHuoImage;
     		}
     	}

		public UnityEngine.UI.Image E_SkinWeiJiHuoImage
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
		    		this.m_E_SkinWeiJiHuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/PetPiFuSet/E_SkinWeiJiHuo");
     			}
     			return this.m_E_SkinWeiJiHuoImage;
     		}
     	}

		public UnityEngine.UI.Image E_PetProSetNodeImage
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
		    		this.m_E_PetProSetNodeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode");
     			}
     			return this.m_E_PetProSetNodeImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetProSetItem_1RectTransform
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
		    		this.m_EG_PetProSetItem_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_1");
     			}
     			return this.m_EG_PetProSetItem_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetProSetItem_2RectTransform
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
		    		this.m_EG_PetProSetItem_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_2");
     			}
     			return this.m_EG_PetProSetItem_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetProSetNode_1RectTransform
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
		    		this.m_EG_PetProSetNode_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetNode_1");
     			}
     			return this.m_EG_PetProSetNode_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetProSetNode_2RectTransform
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
		    		this.m_EG_PetProSetNode_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetNode_2");
     			}
     			return this.m_EG_PetProSetNode_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetHeXinSetRectTransform
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
		    		this.m_EG_PetHeXinSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_PetHeXinSet");
     			}
     			return this.m_EG_PetHeXinSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseHexinButton
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
		    		this.m_E_ButtonCloseHexinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseHexinImage
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
		    		this.m_E_ButtonCloseHexinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetAddPointRectTransform
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
		    		this.m_EG_PetAddPointRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_PetAddPoint");
     			}
     			return this.m_EG_PetAddPointRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseAddPointButton
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
		    		this.m_E_ButtonCloseAddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseAddPointImage
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
		    		this.m_E_ButtonCloseAddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetPingFenText
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
		    		this.m_E_Text_PetPingFenText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_PetPingFen");
     			}
     			return this.m_E_Text_PetPingFenText;
     		}
     	}

		public UnityEngine.UI.Button E_ImageJinHuaButton
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
		    		this.m_E_ImageJinHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageJinHuaImage
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
		    		this.m_E_ImageJinHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_JinHuaText
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
		    		this.m_E_Lab_JinHuaText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_ImageJinHua/E_Lab_JinHua");
     			}
     			return this.m_E_Lab_JinHuaText;
     		}
     	}

		public UnityEngine.UI.Image E_JinHuaReddotImage
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
		    		this.m_E_JinHuaReddotImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ImageJinHua/E_JinHuaReddot");
     			}
     			return this.m_E_JinHuaReddotImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageShouHuImage
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
		    		this.m_E_ImageShouHuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/ImageJinHua (1)/E_ImageShouHu");
     			}
     			return this.m_E_ImageShouHuImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ShouHuText
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
		    		this.m_E_Text_ShouHuText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/ImageJinHua (1)/E_Text_ShouHu");
     			}
     			return this.m_E_Text_ShouHuText;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseButton
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseImage
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonClose");
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

		private UnityEngine.UI.Image m_E_PetHeXinItem0Image = null;
		private UnityEngine.UI.Image m_E_PetHeXinItem1Image = null;
		private UnityEngine.UI.Image m_E_PetHeXinItem2Image = null;
		private UnityEngine.UI.Button m_E_ButtonAddPointButton = null;
		private UnityEngine.UI.Image m_E_ButtonAddPointImage = null;
		private UnityEngine.RectTransform m_EG_AttributeNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private UnityEngine.UI.Text m_E_PropertyShowTextText = null;
		private UnityEngine.UI.Image m_E_SkinJiHuoImage = null;
		private UnityEngine.UI.Image m_E_SkinWeiJiHuoImage = null;
		private UnityEngine.UI.Image m_E_PetProSetNodeImage = null;
		private UnityEngine.RectTransform m_EG_PetProSetItem_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetProSetItem_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetProSetNode_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetProSetNode_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetHeXinSetRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonCloseHexinButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseHexinImage = null;
		private UnityEngine.RectTransform m_EG_PetAddPointRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonCloseAddPointButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseAddPointImage = null;
		private UnityEngine.UI.Text m_E_Text_PetPingFenText = null;
		private UnityEngine.UI.Button m_E_ImageJinHuaButton = null;
		private UnityEngine.UI.Image m_E_ImageJinHuaImage = null;
		private UnityEngine.UI.Text m_E_Lab_JinHuaText = null;
		private UnityEngine.UI.Image m_E_JinHuaReddotImage = null;
		private UnityEngine.UI.Image m_E_ImageShouHuImage = null;
		private UnityEngine.UI.Text m_E_Text_ShouHuText = null;
		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
