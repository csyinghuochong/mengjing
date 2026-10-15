
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf(typeof(ES_Story))]
	[EnableMethod]
	public  class Scroll_Item_StoryItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_StoryItem> 
	{
		public StoryConfig StoryConfig;
		public Action<int> ClickHandler;

		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_StoryItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_HighlightImage
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
		    			this.m_E_HighlightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Highlight");
     				}
     				return this.m_E_HighlightImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Highlight");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_NameText
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
     				if( this.m_E_NameText == null )
     				{
		    			this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Name");
     				}
     				return this.m_E_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_CompleteText
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
     				if( this.m_E_CompleteText == null )
     				{
		    			this.m_E_CompleteText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Complete");
     				}
     				return this.m_E_CompleteText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Complete");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ClickButton
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
		    			this.m_E_ClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ClickImage
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
		    			this.m_E_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_HighlightImage = null;
			this.m_E_NameText = null;
			this.m_E_CompleteText = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_HighlightImage = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		private UnityEngine.UI.Text m_E_CompleteText = null;
		private UnityEngine.UI.Button m_E_ClickButton = null;
		private UnityEngine.UI.Image m_E_ClickImage = null;
		public Transform uiTransform = null;
	}
}
