
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgZhuaPu))]
	[EnableMethod]
	public  class DlgZhuaPuViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_TextGaiLvText
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
		    		this.m_E_TextGaiLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_TextGaiLv");
     			}
     			return this.m_E_TextGaiLvText;
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonClose");
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_Img_NodeRectTransform
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
		    		this.m_EG_Img_NodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bottom/EG_Img_Node");
     			}
     			return this.m_EG_Img_NodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Img_PosImage
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
		    		this.m_E_Img_PosImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/EG_Img_Node/E_Img_Pos");
     			}
     			return this.m_E_Img_PosImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ChanZiImage
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
		    		this.m_E_Img_ChanZiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/EG_Img_Node/E_Img_ChanZi");
     			}
     			return this.m_E_Img_ChanZiImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonDigButton
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
		    		this.m_E_ButtonDigButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Bottom/E_ButtonDig");
     			}
     			return this.m_E_ButtonDigButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonDigImage
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
		    		this.m_E_ButtonDigImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_ButtonDig");
     			}
     			return this.m_E_ButtonDigImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Bottom/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextGaiLvText = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_EG_Img_NodeRectTransform = null;
			this.m_E_Img_PosImage = null;
			this.m_E_Img_ChanZiImage = null;
			this.m_E_ButtonDigButton = null;
			this.m_E_ButtonDigImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_TextGaiLvText = null;
		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.RectTransform m_EG_Img_NodeRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_PosImage = null;
		private UnityEngine.UI.Image m_E_Img_ChanZiImage = null;
		private UnityEngine.UI.Button m_E_ButtonDigButton = null;
		private UnityEngine.UI.Image m_E_ButtonDigImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
