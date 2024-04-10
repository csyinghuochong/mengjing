
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SkillLearnItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
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

		public UnityEngine.UI.Button E_Img_ButtonButton
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
     				if( this.m_E_Img_ButtonButton == null )
     				{
		    			this.m_E_Img_ButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_Button");
     				}
     				return this.m_E_Img_ButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_Button");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_ButtonImage
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
     				if( this.m_E_Img_ButtonImage == null )
     				{
		    			this.m_E_Img_ButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_Button");
     				}
     				return this.m_E_Img_ButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_Button");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Img_XuanZhongButton
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
     				if( this.m_E_Img_XuanZhongButton == null )
     				{
		    			this.m_E_Img_XuanZhongButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_XuanZhong");
     				}
     				return this.m_E_Img_XuanZhongButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_XuanZhong");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_XuanZhongImage
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
     				if( this.m_E_Img_XuanZhongImage == null )
     				{
		    			this.m_E_Img_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_XuanZhong");
     				}
     				return this.m_E_Img_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_XuanZhong");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_Node_1RectTransform
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
     				if( this.m_EG_Node_1RectTransform == null )
     				{
		    			this.m_EG_Node_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1");
     				}
     				return this.m_EG_Node_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Img_SkillIconButton
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
     				if( this.m_E_Img_SkillIconButton == null )
     				{
		    			this.m_E_Img_SkillIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/Img_SkillIconDi/E_Img_SkillIcon");
     				}
     				return this.m_E_Img_SkillIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/Img_SkillIconDi/E_Img_SkillIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_SkillIconImage
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
     				if( this.m_E_Img_SkillIconImage == null )
     				{
		    			this.m_E_Img_SkillIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/Img_SkillIconDi/E_Img_SkillIcon");
     				}
     				return this.m_E_Img_SkillIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/Img_SkillIconDi/E_Img_SkillIcon");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Img_SkillIconEventTrigger
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
     				if( this.m_E_Img_SkillIconEventTrigger == null )
     				{
		    			this.m_E_Img_SkillIconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_Node_1/Img_SkillIconDi/E_Img_SkillIcon");
     				}
     				return this.m_E_Img_SkillIconEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_Node_1/Img_SkillIconDi/E_Img_SkillIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonMaxButton
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
     				if( this.m_E_ButtonMaxButton == null )
     				{
		    			this.m_E_ButtonMaxButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonMax");
     				}
     				return this.m_E_ButtonMaxButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonMax");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMaxImage
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
     				if( this.m_E_ButtonMaxImage == null )
     				{
		    			this.m_E_ButtonMaxImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonMax");
     				}
     				return this.m_E_ButtonMaxImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonMax");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonUpButton
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
     				if( this.m_E_ButtonUpButton == null )
     				{
		    			this.m_E_ButtonUpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonUp");
     				}
     				return this.m_E_ButtonUpButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonUp");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonUpImage
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
     				if( this.m_E_ButtonUpImage == null )
     				{
		    			this.m_E_ButtonUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonUp");
     				}
     				return this.m_E_ButtonUpImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonUp");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonLearnButton
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
     				if( this.m_E_ButtonLearnButton == null )
     				{
		    			this.m_E_ButtonLearnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonLearn");
     				}
     				return this.m_E_ButtonLearnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonLearn");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonLearnImage
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
     				if( this.m_E_ButtonLearnImage == null )
     				{
		    			this.m_E_ButtonLearnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonLearn");
     				}
     				return this.m_E_ButtonLearnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node_1/E_ButtonLearn");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ReddotRectTransform
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
     				if( this.m_EG_ReddotRectTransform == null )
     				{
		    			this.m_EG_ReddotRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1/EG_Reddot");
     				}
     				return this.m_EG_ReddotRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_1/EG_Reddot");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillNameText
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
     				if( this.m_E_Lab_SkillNameText == null )
     				{
		    			this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_SkillName");
     				}
     				return this.m_E_Lab_SkillNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_SkillName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillLvText
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
     				if( this.m_E_Lab_SkillLvText == null )
     				{
		    			this.m_E_Lab_SkillLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_SkillLv");
     				}
     				return this.m_E_Lab_SkillLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_SkillLv");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_DescText
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
     				if( this.m_E_Text_DescText == null )
     				{
		    			this.m_E_Text_DescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Text_Desc");
     				}
     				return this.m_E_Text_DescText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Text_Desc");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NeedSpText
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
     				if( this.m_E_Lab_NeedSpText == null )
     				{
		    			this.m_E_Lab_NeedSpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_NeedSp");
     				}
     				return this.m_E_Lab_NeedSpText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_1/E_Lab_NeedSp");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_Node_2RectTransform
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
     				if( this.m_EG_Node_2RectTransform == null )
     				{
		    			this.m_EG_Node_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_2");
     				}
     				return this.m_EG_Node_2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node_2");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_LearnLvText
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
     				if( this.m_E_Text_LearnLvText == null )
     				{
		    			this.m_E_Text_LearnLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_2/E_Text_LearnLv");
     				}
     				return this.m_E_Text_LearnLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node_2/E_Text_LearnLv");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_ButtonButton = null;
			this.m_E_Img_ButtonImage = null;
			this.m_E_Img_XuanZhongButton = null;
			this.m_E_Img_XuanZhongImage = null;
			this.m_EG_Node_1RectTransform = null;
			this.m_E_Img_SkillIconButton = null;
			this.m_E_Img_SkillIconImage = null;
			this.m_E_Img_SkillIconEventTrigger = null;
			this.m_E_ButtonMaxButton = null;
			this.m_E_ButtonMaxImage = null;
			this.m_E_ButtonUpButton = null;
			this.m_E_ButtonUpImage = null;
			this.m_E_ButtonLearnButton = null;
			this.m_E_ButtonLearnImage = null;
			this.m_EG_ReddotRectTransform = null;
			this.m_E_Lab_SkillNameText = null;
			this.m_E_Lab_SkillLvText = null;
			this.m_E_Text_DescText = null;
			this.m_E_Lab_NeedSpText = null;
			this.m_EG_Node_2RectTransform = null;
			this.m_E_Text_LearnLvText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_Img_ButtonButton = null;
		private UnityEngine.UI.Image m_E_Img_ButtonImage = null;
		private UnityEngine.UI.Button m_E_Img_XuanZhongButton = null;
		private UnityEngine.UI.Image m_E_Img_XuanZhongImage = null;
		private UnityEngine.RectTransform m_EG_Node_1RectTransform = null;
		private UnityEngine.UI.Button m_E_Img_SkillIconButton = null;
		private UnityEngine.UI.Image m_E_Img_SkillIconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Img_SkillIconEventTrigger = null;
		private UnityEngine.UI.Button m_E_ButtonMaxButton = null;
		private UnityEngine.UI.Image m_E_ButtonMaxImage = null;
		private UnityEngine.UI.Button m_E_ButtonUpButton = null;
		private UnityEngine.UI.Image m_E_ButtonUpImage = null;
		private UnityEngine.UI.Button m_E_ButtonLearnButton = null;
		private UnityEngine.UI.Image m_E_ButtonLearnImage = null;
		private UnityEngine.RectTransform m_EG_ReddotRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_SkillNameText = null;
		private UnityEngine.UI.Text m_E_Lab_SkillLvText = null;
		private UnityEngine.UI.Text m_E_Text_DescText = null;
		private UnityEngine.UI.Text m_E_Lab_NeedSpText = null;
		private UnityEngine.RectTransform m_EG_Node_2RectTransform = null;
		private UnityEngine.UI.Text m_E_Text_LearnLvText = null;
		public Transform uiTransform = null;
	}
}
