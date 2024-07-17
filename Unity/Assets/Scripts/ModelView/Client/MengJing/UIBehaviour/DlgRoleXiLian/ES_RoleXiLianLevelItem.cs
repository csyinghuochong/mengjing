using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianLevelItem : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public float PostionY;
		public int XiLianLevelId;
		public List<KeyValuePairInt> ShowSkill;
		public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
		
		public Image E_ImageExpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageExpImage == null )
     			{
		    		this.m_E_ImageExpImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageExp");
     			}
     			return this.m_E_ImageExpImage;
     		}
     	}

		public Text E_TextTitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTitleText == null )
     			{
		    		this.m_E_TextTitleText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextTitle");
     			}
     			return this.m_E_TextTitleText;
     		}
     	}

		public Text E_TextAttributeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextAttributeText == null )
     			{
		    		this.m_E_TextAttributeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextAttribute");
     			}
     			return this.m_E_TextAttributeText;
     		}
     	}

		public Text E_TextLevelTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelTipText == null )
     			{
		    		this.m_E_TextLevelTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLevelTip");
     			}
     			return this.m_E_TextLevelTipText;
     		}
     	}

		public Text E_TextShuLianDuText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextShuLianDuText == null )
     			{
		    		this.m_E_TextShuLianDuText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextShuLianDu");
     			}
     			return this.m_E_TextShuLianDuText;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RewardList es = this.m_es_rewardlist;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public Image E_Image_AcvityedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_AcvityedImage == null )
     			{
		    		this.m_E_Image_AcvityedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Acvityed");
     			}
     			return this.m_E_Image_AcvityedImage;
     		}
     	}

		public Button E_ButtonGetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetButton == null )
     			{
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public Image E_ButtonGetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetImage == null )
     			{
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
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
			this.m_E_ImageExpImage = null;
			this.m_E_TextTitleText = null;
			this.m_E_TextAttributeText = null;
			this.m_E_TextLevelTipText = null;
			this.m_E_TextShuLianDuText = null;
			this.m_es_rewardlist = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_Image_AcvityedImage = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.uiTransform = null;
		}

		private Image m_E_ImageExpImage = null;
		private Text m_E_TextTitleText = null;
		private Text m_E_TextAttributeText = null;
		private Text m_E_TextLevelTipText = null;
		private Text m_E_TextShuLianDuText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private Image m_E_Image_AcvityedImage = null;
		private Button m_E_ButtonGetButton = null;
		private Image m_E_ButtonGetImage = null;
		public Transform uiTransform = null;
	}
}
