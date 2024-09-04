using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionKeJiLearn : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int Position;
		public UnionInfo UnionMyInfo;
		public UserInfo UserInfo { get; set; }
		public Dictionary<int, EntityRef<Scroll_Item_UnionKeJiLearnItem>> ScrollItemUnionKeJiLearnItems;
		
		public LoopVerticalScrollRect E_UnionKeJiLearnItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_UnionKeJiLearnItems");
     			}
     			return this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect;
     		}
     	}

		public Image E_HeadImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadImgImage == null )
     			{
		    		this.m_E_HeadImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HeadImg");
     			}
     			return this.m_E_HeadImgImage;
     		}
     	}

		public Text E_NameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameTextText == null )
     			{
		    		this.m_E_NameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     			return this.m_E_NameTextText;
     		}
     	}

		public Text E_LvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LvTextText == null )
     			{
		    		this.m_E_LvTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LvText");
     			}
     			return this.m_E_LvTextText;
     		}
     	}

		public ES_CostList ES_CostList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CostList es = this.m_es_costlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
     		}
     	}

		public Button E_StartBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnButton == null )
     			{
		    		this.m_E_StartBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_StartBtn");
     			}
     			return this.m_E_StartBtnButton;
     		}
     	}

		public Image E_StartBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnImage == null )
     			{
		    		this.m_E_StartBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_StartBtn");
     			}
     			return this.m_E_StartBtnImage;
     		}
     	}

		public Text E_AttributeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttributeTextText == null )
     			{
		    		this.m_E_AttributeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_AttributeText");
     			}
     			return this.m_E_AttributeTextText;
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
			this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect = null;
			this.m_E_HeadImgImage = null;
			this.m_E_NameTextText = null;
			this.m_E_LvTextText = null;
			this.m_es_costlist = null;
			this.m_E_StartBtnButton = null;
			this.m_E_StartBtnImage = null;
			this.m_E_AttributeTextText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_UnionKeJiLearnItemsLoopVerticalScrollRect = null;
		private Image m_E_HeadImgImage = null;
		private Text m_E_NameTextText = null;
		private Text m_E_LvTextText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private Button m_E_StartBtnButton = null;
		private Image m_E_StartBtnImage = null;
		private Text m_E_AttributeTextText = null;
		public Transform uiTransform = null;
	}
}
