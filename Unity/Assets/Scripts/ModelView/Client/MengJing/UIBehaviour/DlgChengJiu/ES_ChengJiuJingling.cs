
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChengJiuJingling : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int JingLingId;
		public List<JingLingConfig> ShowJingLing = new();
		public Dictionary<int, EntityRef<Scroll_Item_ChengJiuJinglingItem>> ScrollItemChengJiuJinglingItems;
		
		public UnityEngine.RectTransform EG_LeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftRectTransform == null )
     			{
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TotalProgressText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TotalProgressText == null )
     			{
		    		this.m_E_TotalProgressText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_TotalProgress");
     			}
     			return this.m_E_TotalProgressText;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_ChengJiuJinglingItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuJinglingItemsImage == null )
     			{
		    		this.m_E_ChengJiuJinglingItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/E_ChengJiuJinglingItems");
     			}
     			return this.m_E_ChengJiuJinglingItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ChengJiuJinglingItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left/E_ChengJiuJinglingItems");
     			}
     			return this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Right/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Text E_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameText == null )
     			{
		    		this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Name");
     			}
     			return this.m_E_NameText;
     		}
     	}

		public UnityEngine.UI.Text E_LvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LvText == null )
     			{
		    		this.m_E_LvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Lv");
     			}
     			return this.m_E_LvText;
     		}
     	}

		public UnityEngine.RectTransform EG_TextAttributeItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TextAttributeItemRectTransform == null )
     			{
		    		this.m_EG_TextAttributeItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_TextAttributeItem");
     			}
     			return this.m_EG_TextAttributeItemRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AttributeListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AttributeListNodeRectTransform == null )
     			{
		    		this.m_EG_AttributeListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeListNode");
     			}
     			return this.m_EG_AttributeListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_ProbabilityText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProbabilityText == null )
     			{
		    		this.m_E_ProbabilityText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Probability");
     			}
     			return this.m_E_ProbabilityText;
     		}
     	}

		public UnityEngine.UI.Text E_GetWayText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GetWayText == null )
     			{
		    		this.m_E_GetWayText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_GetWay");
     			}
     			return this.m_E_GetWayText;
     		}
     	}

		public UnityEngine.UI.Image E_ProgressImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressImgImage == null )
     			{
		    		this.m_E_ProgressImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/Progress/E_ProgressImg");
     			}
     			return this.m_E_ProgressImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_ProgressTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressTxtText == null )
     			{
		    		this.m_E_ProgressTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/Progress/E_ProgressTxt");
     			}
     			return this.m_E_ProgressTxtText;
     		}
     	}

		public UnityEngine.UI.Button E_ActivateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivateButton == null )
     			{
		    		this.m_E_ActivateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/E_Activate");
     			}
     			return this.m_E_ActivateButton;
     		}
     	}

		public UnityEngine.UI.Image E_ActivateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivateImage == null )
     			{
		    		this.m_E_ActivateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_Activate");
     			}
     			return this.m_E_ActivateImage;
     		}
     	}

		public UnityEngine.UI.Text E_UnactivateText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnactivateText == null )
     			{
		    		this.m_E_UnactivateText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Unactivate");
     			}
     			return this.m_E_UnactivateText;
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
			this.m_EG_LeftRectTransform = null;
			this.m_E_TotalProgressText = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_ChengJiuJinglingItemsImage = null;
			this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = null;
			this.m_EG_RightRectTransform = null;
			this.m_es_modelshow = null;
			this.m_E_NameText = null;
			this.m_E_LvText = null;
			this.m_EG_TextAttributeItemRectTransform = null;
			this.m_EG_AttributeListNodeRectTransform = null;
			this.m_E_ProbabilityText = null;
			this.m_E_GetWayText = null;
			this.m_E_ProgressImgImage = null;
			this.m_E_ProgressTxtText = null;
			this.m_E_ActivateButton = null;
			this.m_E_ActivateImage = null;
			this.m_E_UnactivateText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.UI.Text m_E_TotalProgressText = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_ChengJiuJinglingItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		private UnityEngine.UI.Text m_E_LvText = null;
		private UnityEngine.RectTransform m_EG_TextAttributeItemRectTransform = null;
		private UnityEngine.RectTransform m_EG_AttributeListNodeRectTransform = null;
		private UnityEngine.UI.Text m_E_ProbabilityText = null;
		private UnityEngine.UI.Text m_E_GetWayText = null;
		private UnityEngine.UI.Image m_E_ProgressImgImage = null;
		private UnityEngine.UI.Text m_E_ProgressTxtText = null;
		private UnityEngine.UI.Button m_E_ActivateButton = null;
		private UnityEngine.UI.Image m_E_ActivateImage = null;
		private UnityEngine.UI.Text m_E_UnactivateText = null;
		public Transform uiTransform = null;
	}
}
