using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgZhuaPu))]
	[EnableMethod]
	public  class DlgZhuaPuViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_Img_NodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Img_NodeRectTransform == null )
     			{
		    		this.m_EG_Img_NodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Bottom/EG_Img_Node");
     			}
     			return this.m_EG_Img_NodeRectTransform;
     		}
     	}

		public Image E_Img_PosImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_PosImage == null )
     			{
		    		this.m_E_Img_PosImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Bottom/EG_Img_Node/E_Img_Pos");
     			}
     			return this.m_E_Img_PosImage;
     		}
     	}

		public Image E_Img_ChanZiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ChanZiImage == null )
     			{
		    		this.m_E_Img_ChanZiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Bottom/EG_Img_Node/E_Img_ChanZi");
     			}
     			return this.m_E_Img_ChanZiImage;
     		}
     	}

		public Button E_ButtonDigButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDigButton == null )
     			{
		    		this.m_E_ButtonDigButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Bottom/E_ButtonDig");
     			}
     			return this.m_E_ButtonDigButton;
     		}
     	}

		public Image E_ButtonDigImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDigImage == null )
     			{
		    		this.m_E_ButtonDigImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Bottom/E_ButtonDig");
     			}
     			return this.m_E_ButtonDigImage;
     		}
     	}

		public Text E_TextGaiLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextGaiLvText == null )
     			{
		    		this.m_E_TextGaiLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_TextGaiLv");
     			}
     			return this.m_E_TextGaiLvText;
     		}
     	}

		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
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
			this.m_EG_Img_NodeRectTransform = null;
			this.m_E_Img_PosImage = null;
			this.m_E_Img_ChanZiImage = null;
			this.m_E_ButtonDigButton = null;
			this.m_E_ButtonDigImage = null;
			this.m_E_TextGaiLvText = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_Img_NodeRectTransform = null;
		private Image m_E_Img_PosImage = null;
		private Image m_E_Img_ChanZiImage = null;
		private Button m_E_ButtonDigButton = null;
		private Image m_E_ButtonDigImage = null;
		private Text m_E_TextGaiLvText = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
