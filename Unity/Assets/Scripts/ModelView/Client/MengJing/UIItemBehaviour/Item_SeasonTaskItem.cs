
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SeasonTaskItem : Entity,IAwake,IDestroy,IUIScrollItem 
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

		public UnityEngine.RectTransform EG_ItemRectTransform
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
		    			this.m_EG_ItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item");
     				}
     				return this.m_EG_ItemRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Item");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_lineDiImage
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
		    			this.m_E_Img_lineDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_Img_lineDi");
     				}
     				return this.m_E_Img_lineDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_Img_lineDi");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_lineImage
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
		    			this.m_E_Img_lineImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_Img_line");
     				}
     				return this.m_E_Img_lineImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_Img_line");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ScelectImgImage
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
		    			this.m_E_ScelectImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_ScelectImg");
     				}
     				return this.m_E_ScelectImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_ScelectImg");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_SeasonIconButton
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
		    			this.m_E_SeasonIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     				}
     				return this.m_E_SeasonIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_SeasonIconImage
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
		    			this.m_E_SeasonIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     				}
     				return this.m_E_SeasonIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Item/E_SeasonIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextText
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
		    			this.m_E_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Item/E_Text");
     				}
     				return this.m_E_TextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Item/E_Text");
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

		private UnityEngine.RectTransform m_EG_ItemRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_lineDiImage = null;
		private UnityEngine.UI.Image m_E_Img_lineImage = null;
		private UnityEngine.UI.Image m_E_ScelectImgImage = null;
		private UnityEngine.UI.Button m_E_SeasonIconButton = null;
		private UnityEngine.UI.Image m_E_SeasonIconImage = null;
		private UnityEngine.UI.Text m_E_TextText = null;
		public Transform uiTransform = null;
	}
}
