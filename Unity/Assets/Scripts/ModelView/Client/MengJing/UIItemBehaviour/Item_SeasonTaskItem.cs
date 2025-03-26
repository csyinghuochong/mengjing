
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
		    			this.m_E_SeasonIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_SeasonIcon");
     				}
     				return this.m_E_SeasonIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_SeasonIcon");
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
		    			this.m_E_SeasonIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SeasonIcon");
     				}
     				return this.m_E_SeasonIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SeasonIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextNameText
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
     				if( this.m_E_TextNameText == null )
     				{
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextDiText
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
     				if( this.m_E_TextDiText == null )
     				{
		    			this.m_E_TextDiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextDi");
     				}
     				return this.m_E_TextDiText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextDi");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_CompletedRectTransform
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
     				if( this.m_EG_CompletedRectTransform == null )
     				{
		    			this.m_EG_CompletedRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Completed");
     				}
     				return this.m_EG_CompletedRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Completed");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_LockRectTransform
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
     				if( this.m_EG_LockRectTransform == null )
     				{
		    			this.m_EG_LockRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Lock");
     				}
     				return this.m_EG_LockRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Lock");
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
		    			this.m_E_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text");
     				}
     				return this.m_E_TextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SeasonIconButton = null;
			this.m_E_SeasonIconImage = null;
			this.m_E_TextNameText = null;
			this.m_E_TextDiText = null;
			this.m_EG_CompletedRectTransform = null;
			this.m_EG_LockRectTransform = null;
			this.m_E_TextText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_SeasonIconButton = null;
		private UnityEngine.UI.Image m_E_SeasonIconImage = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		private UnityEngine.UI.Text m_E_TextDiText = null;
		private UnityEngine.RectTransform m_EG_CompletedRectTransform = null;
		private UnityEngine.RectTransform m_EG_LockRectTransform = null;
		private UnityEngine.UI.Text m_E_TextText = null;
		public Transform uiTransform = null;
	}
}
