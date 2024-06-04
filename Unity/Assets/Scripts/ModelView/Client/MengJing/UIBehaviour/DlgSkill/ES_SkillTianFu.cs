
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillTianFu : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int TianFuId;
		public List<List<int>> ShowTianFu = new();
		public Dictionary<int, Scroll_Item_SkillTianFuItem> ScrollItemSkillTianFuItems;
        
		public UnityEngine.UI.LoopVerticalScrollRect E_SkillTianFuItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillTianFuItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SkillTianFuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SkillTianFuItems");
     			}
     			return this.m_E_SkillTianFuItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_TianFu_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Button == null )
     			{
		    		this.m_E_Btn_TianFu_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_TianFu_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Image == null )
     			{
		    		this.m_E_Btn_TianFu_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_TianFu_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Button == null )
     			{
		    		this.m_E_Btn_TianFu_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_TianFu_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Image == null )
     			{
		    		this.m_E_Btn_TianFu_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ActiveTianFuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ActiveTianFuButton == null )
     			{
		    		this.m_E_Btn_ActiveTianFuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ActiveTianFu");
     			}
     			return this.m_E_Btn_ActiveTianFuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ActiveTianFuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ActiveTianFuImage == null )
     			{
		    		this.m_E_Btn_ActiveTianFuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ActiveTianFu");
     			}
     			return this.m_E_Btn_ActiveTianFuImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextDesc1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextDesc1Text == null )
     			{
		    		this.m_E_TextDesc1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextDesc1");
     			}
     			return this.m_E_TextDesc1Text;
     		}
     	}

		public UnityEngine.RectTransform EG_DescListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DescListNodeRectTransform == null )
     			{
		    		this.m_EG_DescListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_DescListNode");
     			}
     			return this.m_EG_DescListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
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
     			if( this.m_E_Lab_SkillNameText == null )
     			{
		    		this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_SkillName");
     			}
     			return this.m_E_Lab_SkillNameText;
     		}
     	}

		public UnityEngine.UI.Image E_TianFuIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TianFuIconImage == null )
     			{
		    		this.m_E_TianFuIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_TianFuIcon");
     			}
     			return this.m_E_TianFuIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NeedLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NeedLvText == null )
     			{
		    		this.m_E_Text_NeedLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_NeedLv");
     			}
     			return this.m_E_Text_NeedLvText;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_SkillTianFuItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_TianFu_1Button = null;
			this.m_E_Btn_TianFu_1Image = null;
			this.m_E_Btn_TianFu_2Button = null;
			this.m_E_Btn_TianFu_2Image = null;
			this.m_E_Btn_ActiveTianFuButton = null;
			this.m_E_Btn_ActiveTianFuImage = null;
			this.m_E_TextDesc1Text = null;
			this.m_EG_DescListNodeRectTransform = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_Lab_SkillNameText = null;
			this.m_E_TianFuIconImage = null;
			this.m_E_Text_NeedLvText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_SkillTianFuItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_TianFu_1Button = null;
		private UnityEngine.UI.Image m_E_Btn_TianFu_1Image = null;
		private UnityEngine.UI.Button m_E_Btn_TianFu_2Button = null;
		private UnityEngine.UI.Image m_E_Btn_TianFu_2Image = null;
		private UnityEngine.UI.Button m_E_Btn_ActiveTianFuButton = null;
		private UnityEngine.UI.Image m_E_Btn_ActiveTianFuImage = null;
		private UnityEngine.UI.Text m_E_TextDesc1Text = null;
		private UnityEngine.RectTransform m_EG_DescListNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Text m_E_Lab_SkillNameText = null;
		private UnityEngine.UI.Image m_E_TianFuIconImage = null;
		private UnityEngine.UI.Text m_E_Text_NeedLvText = null;
		public Transform uiTransform = null;
	}
}
