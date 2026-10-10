
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_SkillAugmentItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SkillAugmentItem> 
	{
		public SkillAugmentInfo SkillAugmentInfo;
		public Action<SkillAugmentInfo> ClickHandler;

		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SkillAugmentItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_HighlightButton
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
     				if( this.m_E_HighlightButton == null )
     				{
		    			this.m_E_HighlightButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Highlight");
     				}
     				return this.m_E_HighlightButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Highlight");
     			}
     		}
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

		public UnityEngine.UI.Image E_SkillIconImage
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
     				if( this.m_E_SkillIconImage == null )
     				{
		    			this.m_E_SkillIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_SkillIcon");
     				}
     				return this.m_E_SkillIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_SkillIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_NullImage
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
     				if( this.m_E_NullImage == null )
     				{
		    			this.m_E_NullImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Null");
     				}
     				return this.m_E_NullImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Null");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_SkillNameText
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
     				if( this.m_E_SkillNameText == null )
     				{
		    			this.m_E_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_SkillName");
     				}
     				return this.m_E_SkillNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_SkillName");
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

		public UnityEngine.RectTransform EG_SkillAugment_1RectTransform
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
     				if( this.m_EG_SkillAugment_1RectTransform == null )
     				{
		    			this.m_EG_SkillAugment_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillAugment_1");
     				}
     				return this.m_EG_SkillAugment_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillAugment_1");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_SkillAugment_2RectTransform
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
     				if( this.m_EG_SkillAugment_2RectTransform == null )
     				{
		    			this.m_EG_SkillAugment_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillAugment_2");
     				}
     				return this.m_EG_SkillAugment_2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillAugment_2");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_SkillAugment_3RectTransform
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
     				if( this.m_EG_SkillAugment_3RectTransform == null )
     				{
		    			this.m_EG_SkillAugment_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillAugment_3");
     				}
     				return this.m_EG_SkillAugment_3RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillAugment_3");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_HighlightButton = null;
			this.m_E_HighlightImage = null;
			this.m_E_SkillIconImage = null;
			this.m_E_NullImage = null;
			this.m_E_SkillNameText = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.m_EG_SkillAugment_1RectTransform = null;
			this.m_EG_SkillAugment_2RectTransform = null;
			this.m_EG_SkillAugment_3RectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_HighlightButton = null;
		private UnityEngine.UI.Image m_E_HighlightImage = null;
		private UnityEngine.UI.Image m_E_SkillIconImage = null;
		private UnityEngine.UI.Image m_E_NullImage = null;
		private UnityEngine.UI.Text m_E_SkillNameText = null;
		private UnityEngine.UI.Button m_E_ClickButton = null;
		private UnityEngine.UI.Image m_E_ClickImage = null;
		private UnityEngine.RectTransform m_EG_SkillAugment_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillAugment_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillAugment_3RectTransform = null;
		public Transform uiTransform = null;
	}
}
