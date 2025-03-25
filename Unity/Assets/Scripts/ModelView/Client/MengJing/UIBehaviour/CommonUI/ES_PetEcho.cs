using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEcho : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy ,IUILogic
	{
		
		public Dictionary<int, EntityRef<Scroll_Item_PetEchoItem>> ScrollItemPetEchoItems;
		public Dictionary<int, EntityRef<Scroll_Item_PetEchoSkillItem>> ScrollItemPetEchoSkillItems;
		
		public UnityEngine.RectTransform EG_Left_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Left_1RectTransform == null )
     			{
		    		this.m_EG_Left_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left_1");
     			}
     			return this.m_EG_Left_1RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetEchoItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEchoItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetEchoItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left_1/E_PetEchoItems");
     			}
     			return this.m_E_PetEchoItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_TotalCombat_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TotalCombat_1Text == null )
     			{
		    		this.m_E_TotalCombat_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left_1/E_TotalCombat_1");
     			}
     			return this.m_E_TotalCombat_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_NextNeedCombatText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextNeedCombatText == null )
     			{
		    		this.m_E_NextNeedCombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left_1/E_NextNeedCombat");
     			}
     			return this.m_E_NextNeedCombatText;
     		}
     	}

		public UnityEngine.RectTransform EG_Left_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Left_2RectTransform == null )
     			{
		    		this.m_EG_Left_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left_2");
     			}
     			return this.m_EG_Left_2RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetEchoSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEchoSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetEchoSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left_2/E_PetEchoSkillItems");
     			}
     			return this.m_E_PetEchoSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_TotalCombat_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TotalCombat_2Text == null )
     			{
		    		this.m_E_TotalCombat_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left_2/E_TotalCombat_2");
     			}
     			return this.m_E_TotalCombat_2Text;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenButton == null )
     			{
		    		this.m_E_ButtonOpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenImage == null )
     			{
		    		this.m_E_ButtonOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenImage;
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Text E_Text_AttributeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_AttributeText == null )
     			{
		    		this.m_E_Text_AttributeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Attribute");
     			}
     			return this.m_E_Text_AttributeText;
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

		public UnityEngine.UI.Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NameText == null )
     			{
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Name");
     			}
     			return this.m_E_Text_NameText;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonActiveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonActiveButton == null )
     			{
		    		this.m_E_ButtonActiveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonActive");
     			}
     			return this.m_E_ButtonActiveButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonActiveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonActiveImage == null )
     			{
		    		this.m_E_ButtonActiveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonActive");
     			}
     			return this.m_E_ButtonActiveImage;
     		}
     	}

		public UnityEngine.UI.Text E_ActiveNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveNumberText == null )
     			{
		    		this.m_E_ActiveNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ActiveNumber");
     			}
     			return this.m_E_ActiveNumberText;
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
			this.m_EG_Left_1RectTransform = null;
			this.m_E_PetEchoItemsLoopVerticalScrollRect = null;
			this.m_E_TotalCombat_1Text = null;
			this.m_E_NextNeedCombatText = null;
			this.m_EG_Left_2RectTransform = null;
			this.m_E_PetEchoSkillItemsLoopVerticalScrollRect = null;
			this.m_E_TotalCombat_2Text = null;
			this.m_E_ButtonOpenButton = null;
			this.m_E_ButtonOpenImage = null;
			this.m_es_rewardlist = null;
			this.m_es_modelshow = null;
			this.m_E_Text_AttributeText = null;
			this.m_E_Text_NeedLvText = null;
			this.m_E_Text_NameText = null;
			this.m_E_ButtonActiveButton = null;
			this.m_E_ButtonActiveImage = null;
			this.m_E_ActiveNumberText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_Left_1RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetEchoItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_TotalCombat_1Text = null;
		private UnityEngine.UI.Text m_E_NextNeedCombatText = null;
		private UnityEngine.RectTransform m_EG_Left_2RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetEchoSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_TotalCombat_2Text = null;
		private UnityEngine.UI.Button m_E_ButtonOpenButton = null;
		private UnityEngine.UI.Image m_E_ButtonOpenImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_Text_AttributeText = null;
		private UnityEngine.UI.Text m_E_Text_NeedLvText = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Button m_E_ButtonActiveButton = null;
		private UnityEngine.UI.Image m_E_ButtonActiveImage = null;
		private UnityEngine.UI.Text m_E_ActiveNumberText = null;
		public Transform uiTransform = null;
	}
}
