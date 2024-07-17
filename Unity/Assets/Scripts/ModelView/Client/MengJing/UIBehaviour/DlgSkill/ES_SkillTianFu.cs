using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillTianFu : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int TianFuId;
		public List<List<int>> ShowTianFu = new();
		public Dictionary<int, EntityRef<Scroll_Item_SkillTianFuItem>> ScrollItemSkillTianFuItems;
        
		public LoopVerticalScrollRect E_SkillTianFuItemsLoopVerticalScrollRect
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
		    		this.m_E_SkillTianFuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SkillTianFuItems");
     			}
     			return this.m_E_SkillTianFuItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_TianFu_1Button
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
		    		this.m_E_Btn_TianFu_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Button;
     		}
     	}

		public Image E_Btn_TianFu_1Image
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
		    		this.m_E_Btn_TianFu_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Image;
     		}
     	}

		public Button E_Btn_TianFu_2Button
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
		    		this.m_E_Btn_TianFu_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Button;
     		}
     	}

		public Image E_Btn_TianFu_2Image
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
		    		this.m_E_Btn_TianFu_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Image;
     		}
     	}

		public Button E_Btn_ActiveTianFuButton
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
		    		this.m_E_Btn_ActiveTianFuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Btn_ActiveTianFu");
     			}
     			return this.m_E_Btn_ActiveTianFuButton;
     		}
     	}

		public Image E_Btn_ActiveTianFuImage
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
		    		this.m_E_Btn_ActiveTianFuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Btn_ActiveTianFu");
     			}
     			return this.m_E_Btn_ActiveTianFuImage;
     		}
     	}

		public Text E_TextDesc1Text
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
		    		this.m_E_TextDesc1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_TextDesc1");
     			}
     			return this.m_E_TextDesc1Text;
     		}
     	}

		public RectTransform EG_DescListNodeRectTransform
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
		    		this.m_EG_DescListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_DescListNode");
     			}
     			return this.m_EG_DescListNodeRectTransform;
     		}
     	}

		public Image E_ImageSelectImage
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public Text E_Lab_SkillNameText
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
		    		this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Lab_SkillName");
     			}
     			return this.m_E_Lab_SkillNameText;
     		}
     	}

		public Image E_TianFuIconImage
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
		    		this.m_E_TianFuIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_TianFuIcon");
     			}
     			return this.m_E_TianFuIconImage;
     		}
     	}

		public Text E_Text_NeedLvText
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
		    		this.m_E_Text_NeedLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_NeedLv");
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

		private LoopVerticalScrollRect m_E_SkillTianFuItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_TianFu_1Button = null;
		private Image m_E_Btn_TianFu_1Image = null;
		private Button m_E_Btn_TianFu_2Button = null;
		private Image m_E_Btn_TianFu_2Image = null;
		private Button m_E_Btn_ActiveTianFuButton = null;
		private Image m_E_Btn_ActiveTianFuImage = null;
		private Text m_E_TextDesc1Text = null;
		private RectTransform m_EG_DescListNodeRectTransform = null;
		private Image m_E_ImageSelectImage = null;
		private Text m_E_Lab_SkillNameText = null;
		private Image m_E_TianFuIconImage = null;
		private Text m_E_Text_NeedLvText = null;
		public Transform uiTransform = null;
	}
}
