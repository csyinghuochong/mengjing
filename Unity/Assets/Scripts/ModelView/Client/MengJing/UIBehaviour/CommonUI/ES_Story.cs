
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Story : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EG_MainRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainRectTransform == null )
     			{
		    		this.m_EG_MainRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Main");
     			}
     			return this.m_EG_MainRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_LodingValue_AffinityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LodingValue_AffinityImage == null )
     			{
		    		this.m_E_LodingValue_AffinityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Main/Left/E_LodingValue_Affinity");
     			}
     			return this.m_E_LodingValue_AffinityImage;
     		}
     	}

		public UnityEngine.UI.Image E_LodingValue_FunImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LodingValue_FunImage == null )
     			{
		    		this.m_E_LodingValue_FunImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Main/Left/E_LodingValue_Fun");
     			}
     			return this.m_E_LodingValue_FunImage;
     		}
     	}

		public UnityEngine.UI.Image E_LodingValue_ViolenceImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LodingValue_ViolenceImage == null )
     			{
		    		this.m_E_LodingValue_ViolenceImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Main/Left/E_LodingValue_Violence");
     			}
     			return this.m_E_LodingValue_ViolenceImage;
     		}
     	}

		public UnityEngine.RectTransform EG_MainRightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainRightRectTransform == null )
     			{
		    		this.m_EG_MainRightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Main/EG_MainRight");
     			}
     			return this.m_EG_MainRightRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_StoryEndingText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryEndingText == null )
     			{
		    		this.m_E_StoryEndingText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Main/EG_MainRight/E_StoryEnding");
     			}
     			return this.m_E_StoryEndingText;
     		}
     	}

		public UnityEngine.UI.Image E_StoryEndingRewardListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryEndingRewardListImage == null )
     			{
		    		this.m_E_StoryEndingRewardListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Main/EG_MainRight/E_StoryEndingRewardList");
     			}
     			return this.m_E_StoryEndingRewardListImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_StoryEndingRewardListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryEndingRewardListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_StoryEndingRewardListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Main/EG_MainRight/E_StoryEndingRewardList");
     			}
     			return this.m_E_StoryEndingRewardListLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_StoryEndingReceiveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryEndingReceiveButton == null )
     			{
		    		this.m_E_StoryEndingReceiveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Main/EG_MainRight/E_StoryEndingReceive");
     			}
     			return this.m_E_StoryEndingReceiveButton;
     		}
     	}

		public UnityEngine.UI.Image E_StoryEndingReceiveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryEndingReceiveImage == null )
     			{
		    		this.m_E_StoryEndingReceiveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Main/EG_MainRight/E_StoryEndingReceive");
     			}
     			return this.m_E_StoryEndingReceiveImage;
     		}
     	}

		public UnityEngine.RectTransform EG_StoryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_StoryRectTransform == null )
     			{
		    		this.m_EG_StoryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Story");
     			}
     			return this.m_EG_StoryRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_StoryChapterItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryChapterItemsScrollRect == null )
     			{
		    		this.m_E_StoryChapterItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"EG_Story/Left/E_StoryChapterItems");
     			}
     			return this.m_E_StoryChapterItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_StoryChapterItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryChapterItemsImage == null )
     			{
		    		this.m_E_StoryChapterItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Story/Left/E_StoryChapterItems");
     			}
     			return this.m_E_StoryChapterItemsImage;
     		}
     	}

		public UnityEngine.RectTransform EG_StoryRightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_StoryRightRectTransform == null )
     			{
		    		this.m_EG_StoryRightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight");
     			}
     			return this.m_EG_StoryRightRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_StoryItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryItemsScrollRect == null )
     			{
		    		this.m_E_StoryItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_StoryItems");
     			}
     			return this.m_E_StoryItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_StoryItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryItemsImage == null )
     			{
		    		this.m_E_StoryItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_StoryItems");
     			}
     			return this.m_E_StoryItemsImage;
     		}
     	}

		public UnityEngine.UI.Text E_StoryNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryNameText == null )
     			{
		    		this.m_E_StoryNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_StoryName");
     			}
     			return this.m_E_StoryNameText;
     		}
     	}

		public UnityEngine.UI.Text E_StoryDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryDesText == null )
     			{
		    		this.m_E_StoryDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_StoryDes");
     			}
     			return this.m_E_StoryDesText;
     		}
     	}

		public UnityEngine.UI.Image E_StoryChoiceListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryChoiceListImage == null )
     			{
		    		this.m_E_StoryChoiceListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_StoryChoiceList");
     			}
     			return this.m_E_StoryChoiceListImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_StoryChoiceListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoryChoiceListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_StoryChoiceListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_StoryChoiceList");
     			}
     			return this.m_E_StoryChoiceListLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmChoiceButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmChoiceButton == null )
     			{
		    		this.m_E_ConfirmChoiceButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_ConfirmChoice");
     			}
     			return this.m_E_ConfirmChoiceButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmChoiceImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmChoiceImage == null )
     			{
		    		this.m_E_ConfirmChoiceImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Story/EG_StoryRight/E_ConfirmChoice");
     			}
     			return this.m_E_ConfirmChoiceImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_PageTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PageTypeSetToggleGroup == null )
     			{
		    		this.m_E_PageTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_PageTypeSet");
     			}
     			return this.m_E_PageTypeSetToggleGroup;
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
			this.m_EG_MainRectTransform = null;
			this.m_E_LodingValue_AffinityImage = null;
			this.m_E_LodingValue_FunImage = null;
			this.m_E_LodingValue_ViolenceImage = null;
			this.m_EG_MainRightRectTransform = null;
			this.m_E_StoryEndingText = null;
			this.m_E_StoryEndingRewardListImage = null;
			this.m_E_StoryEndingRewardListLoopVerticalScrollRect = null;
			this.m_E_StoryEndingReceiveButton = null;
			this.m_E_StoryEndingReceiveImage = null;
			this.m_EG_StoryRectTransform = null;
			this.m_E_StoryChapterItemsScrollRect = null;
			this.m_E_StoryChapterItemsImage = null;
			this.m_EG_StoryRightRectTransform = null;
			this.m_E_StoryItemsScrollRect = null;
			this.m_E_StoryItemsImage = null;
			this.m_E_StoryNameText = null;
			this.m_E_StoryDesText = null;
			this.m_E_StoryChoiceListImage = null;
			this.m_E_StoryChoiceListLoopVerticalScrollRect = null;
			this.m_E_ConfirmChoiceButton = null;
			this.m_E_ConfirmChoiceImage = null;
			this.m_E_PageTypeSetToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_MainRectTransform = null;
		private UnityEngine.UI.Image m_E_LodingValue_AffinityImage = null;
		private UnityEngine.UI.Image m_E_LodingValue_FunImage = null;
		private UnityEngine.UI.Image m_E_LodingValue_ViolenceImage = null;
		private UnityEngine.RectTransform m_EG_MainRightRectTransform = null;
		private UnityEngine.UI.Text m_E_StoryEndingText = null;
		private UnityEngine.UI.Image m_E_StoryEndingRewardListImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_StoryEndingRewardListLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_StoryEndingReceiveButton = null;
		private UnityEngine.UI.Image m_E_StoryEndingReceiveImage = null;
		private UnityEngine.RectTransform m_EG_StoryRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_StoryChapterItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_StoryChapterItemsImage = null;
		private UnityEngine.RectTransform m_EG_StoryRightRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_StoryItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_StoryItemsImage = null;
		private UnityEngine.UI.Text m_E_StoryNameText = null;
		private UnityEngine.UI.Text m_E_StoryDesText = null;
		private UnityEngine.UI.Image m_E_StoryChoiceListImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_StoryChoiceListLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ConfirmChoiceButton = null;
		private UnityEngine.UI.Image m_E_ConfirmChoiceImage = null;
		private UnityEngine.UI.ToggleGroup m_E_PageTypeSetToggleGroup = null;
		public Transform uiTransform = null;
	}
}
