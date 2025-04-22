using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_TaskTypeItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_TaskTypeItem>
	{
		public TaskPro TaskPro;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_TaskTypeItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ClickButton
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
     				if( this.m_E_ClickButton == null )
     				{
		    			this.m_E_ClickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public Image E_ClickImage
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
     				if( this.m_E_ClickImage == null )
     				{
		    			this.m_E_ClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public Image E_HighlightImage
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
     				if( this.m_E_HighlightImage == null )
     				{
		    			this.m_E_HighlightImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Highlight");
     				}
     				return this.m_E_HighlightImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Highlight");
     			}
     		}
     	}

		public Image E_DianImage
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
     				if( this.m_E_DianImage == null )
     				{
		    			this.m_E_DianImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Dian");
     				}
     				return this.m_E_DianImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Dian");
     			}
     		}
     	}

		public Image E_GoingImage
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
     				if( this.m_E_GoingImage == null )
     				{
		    			this.m_E_GoingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Going");
     				}
     				return this.m_E_GoingImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Going");
     			}
     		}
     	}

		public Image E_CompleteImage
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
     				if( this.m_E_CompleteImage == null )
     				{
		    			this.m_E_CompleteImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Complete");
     				}
     				return this.m_E_CompleteImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Complete");
     			}
     		}
     	}

		public Text E_TaskNameText
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
     				if( this.m_E_TaskNameText == null )
     				{
		    			this.m_E_TaskNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskName");
     				}
     				return this.m_E_TaskNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.m_E_HighlightImage = null;
			this.m_E_DianImage = null;
			this.m_E_GoingImage = null;
			this.m_E_CompleteImage = null;
			this.m_E_TaskNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ClickButton = null;
		private Image m_E_ClickImage = null;
		private Image m_E_HighlightImage = null;
		private Image m_E_DianImage = null;
		private Image m_E_GoingImage = null;
		private Image m_E_CompleteImage = null;
		private Text m_E_TaskNameText = null;
		public Transform uiTransform = null;
	}
}
