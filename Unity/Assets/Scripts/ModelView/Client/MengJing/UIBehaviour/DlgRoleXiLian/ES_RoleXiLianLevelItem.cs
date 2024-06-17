
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianLevelItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public float PostionY;
		public int XiLianLevelId;
		public List<KeyValuePairInt> ShowSkill;
		public Dictionary<int, Scroll_Item_CommonSkillItem> ScrollItemCommonSkillItems;
		
		public UnityEngine.UI.Image E_ImageExpImage
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
		    		this.m_E_ImageExpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageExp");
     			}
     			return this.m_E_ImageExpImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextTitleText
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
		    		this.m_E_TextTitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTitle");
     			}
     			return this.m_E_TextTitleText;
     		}
     	}

		public UnityEngine.UI.Text E_TextAttributeText
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
		    		this.m_E_TextAttributeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextAttribute");
     			}
     			return this.m_E_TextAttributeText;
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelTipText
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
		    		this.m_E_TextLevelTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLevelTip");
     			}
     			return this.m_E_TextLevelTipText;
     		}
     	}

		public UnityEngine.UI.Text E_TextShuLianDuText
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
		    		this.m_E_TextShuLianDuText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextShuLianDu");
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
     			if( this.m_es_rewardlist .Equals(null))
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
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
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_Image_AcvityedImage
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
		    		this.m_E_Image_AcvityedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_Acvityed");
     			}
     			return this.m_E_Image_AcvityedImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGetButton
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetImage
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonGet");
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

		private UnityEngine.UI.Image m_E_ImageExpImage = null;
		private UnityEngine.UI.Text m_E_TextTitleText = null;
		private UnityEngine.UI.Text m_E_TextAttributeText = null;
		private UnityEngine.UI.Text m_E_TextLevelTipText = null;
		private UnityEngine.UI.Text m_E_TextShuLianDuText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_Image_AcvityedImage = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		public Transform uiTransform = null;
	}
}
