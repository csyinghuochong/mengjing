using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_SkillLearnItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SkillLearnItem> 
	{
		public SkillPro SkillPro;
		public Action<SkillPro> ClickHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SkillLearnItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_HighlightButton
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
		    			this.m_E_HighlightButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Highlight");
     				}
     				return this.m_E_HighlightButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Highlight");
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

		public Image E_SkillIconImage
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
		    			this.m_E_SkillIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Mask/E_SkillIcon");
     				}
     				return this.m_E_SkillIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Mask/E_SkillIcon");
     			}
     		}
     	}

		public Image E_NullImage
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
		    			this.m_E_NullImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Null");
     				}
     				return this.m_E_NullImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Null");
     			}
     		}
     	}

		public Text E_LearnLvText
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
     				if( this.m_E_LearnLvText == null )
     				{
		    			this.m_E_LearnLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LearnLv");
     				}
     				return this.m_E_LearnLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LearnLv");
     			}
     		}
     	}

		public Text E_SkillNameText
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
		    			this.m_E_SkillNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SkillName");
     				}
     				return this.m_E_SkillNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SkillName");
     			}
     		}
     	}

		public Text E_SkillLvText
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
     				if( this.m_E_SkillLvText == null )
     				{
		    			this.m_E_SkillLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SkillLv");
     				}
     				return this.m_E_SkillLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SkillLv");
     			}
     		}
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

		public void DestroyWidget()
		{
			this.m_E_HighlightButton = null;
			this.m_E_HighlightImage = null;
			this.m_E_SkillIconImage = null;
			this.m_E_NullImage = null;
			this.m_E_LearnLvText = null;
			this.m_E_SkillNameText = null;
			this.m_E_SkillLvText = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_HighlightButton = null;
		private Image m_E_HighlightImage = null;
		private Image m_E_SkillIconImage = null;
		private Image m_E_NullImage = null;
		private Text m_E_LearnLvText = null;
		private Text m_E_SkillNameText = null;
		private Text m_E_SkillLvText = null;
		private Button m_E_ClickButton = null;
		private Image m_E_ClickImage = null;
		public Transform uiTransform = null;
	}
}
