
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_SkillSocketItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SkillSocketItem> 
	{
		public SkillSocketInfo SkillSocketInfo;
		public Action<SkillSocketInfo> ClickHandler;

		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SkillSocketItem BindTrans(Transform trans)
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

		public UnityEngine.UI.Image E_SkillIcon_1Image
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
     				if( this.m_E_SkillIcon_1Image == null )
     				{
		    			this.m_E_SkillIcon_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask (1)/E_SkillIcon_1");
     				}
     				return this.m_E_SkillIcon_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask (1)/E_SkillIcon_1");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_SkillIcon_2Image
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
     				if( this.m_E_SkillIcon_2Image == null )
     				{
		    			this.m_E_SkillIcon_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask (2)/E_SkillIcon_2");
     				}
     				return this.m_E_SkillIcon_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask (2)/E_SkillIcon_2");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_SkillIcon_3Image
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
     				if( this.m_E_SkillIcon_3Image == null )
     				{
		    			this.m_E_SkillIcon_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask (3)/E_SkillIcon_3");
     				}
     				return this.m_E_SkillIcon_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask (3)/E_SkillIcon_3");
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
			this.m_E_HighlightButton = null;
			this.m_E_HighlightImage = null;
			this.m_E_SkillIconImage = null;
			this.m_E_NullImage = null;
			this.m_E_SkillNameText = null;
			this.m_E_SkillIcon_1Image = null;
			this.m_E_SkillIcon_2Image = null;
			this.m_E_SkillIcon_3Image = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_HighlightButton = null;
		private UnityEngine.UI.Image m_E_HighlightImage = null;
		private UnityEngine.UI.Image m_E_SkillIconImage = null;
		private UnityEngine.UI.Image m_E_NullImage = null;
		private UnityEngine.UI.Text m_E_SkillNameText = null;
		private UnityEngine.UI.Image m_E_SkillIcon_1Image = null;
		private UnityEngine.UI.Image m_E_SkillIcon_2Image = null;
		private UnityEngine.UI.Image m_E_SkillIcon_3Image = null;
		private UnityEngine.UI.Button m_E_ClickButton = null;
		private UnityEngine.UI.Image m_E_ClickImage = null;
		public Transform uiTransform = null;
	}
}
