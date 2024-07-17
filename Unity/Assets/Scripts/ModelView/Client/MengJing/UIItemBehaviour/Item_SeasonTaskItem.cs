using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SeasonTaskItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SeasonTaskItem> 
	{
		public int TaskId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SeasonTaskItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public RectTransform EG_ItemRectTransform
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
     				if( this.m_EG_ItemRectTransform == null )
     				{
		    			this.m_EG_ItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Item");
     				}
     				return this.m_EG_ItemRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Item");
     			}
     		}
     	}

		public Image E_Img_lineDiImage
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
     				if( this.m_E_Img_lineDiImage == null )
     				{
		    			this.m_E_Img_lineDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_Img_lineDi");
     				}
     				return this.m_E_Img_lineDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_Img_lineDi");
     			}
     		}
     	}

		public Image E_Img_lineImage
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
     				if( this.m_E_Img_lineImage == null )
     				{
		    			this.m_E_Img_lineImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_Img_line");
     				}
     				return this.m_E_Img_lineImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_Img_line");
     			}
     		}
     	}

		public Image E_ScelectImgImage
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
     				if( this.m_E_ScelectImgImage == null )
     				{
		    			this.m_E_ScelectImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_ScelectImg");
     				}
     				return this.m_E_ScelectImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_ScelectImg");
     			}
     		}
     	}

		public Button E_SeasonIconButton
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
     				if( this.m_E_SeasonIconButton == null )
     				{
		    			this.m_E_SeasonIconButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     				}
     				return this.m_E_SeasonIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     			}
     		}
     	}

		public Image E_SeasonIconImage
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
     				if( this.m_E_SeasonIconImage == null )
     				{
		    			this.m_E_SeasonIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     				}
     				return this.m_E_SeasonIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     			}
     		}
     	}

		public Text E_TextText
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
     				if( this.m_E_TextText == null )
     				{
		    			this.m_E_TextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Item/E_Text");
     				}
     				return this.m_E_TextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Item/E_Text");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_ItemRectTransform = null;
			this.m_E_Img_lineDiImage = null;
			this.m_E_Img_lineImage = null;
			this.m_E_ScelectImgImage = null;
			this.m_E_SeasonIconButton = null;
			this.m_E_SeasonIconImage = null;
			this.m_E_TextText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private RectTransform m_EG_ItemRectTransform = null;
		private Image m_E_Img_lineDiImage = null;
		private Image m_E_Img_lineImage = null;
		private Image m_E_ScelectImgImage = null;
		private Button m_E_SeasonIconButton = null;
		private Image m_E_SeasonIconImage = null;
		private Text m_E_TextText = null;
		public Transform uiTransform = null;
	}
}
