
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMatchRankShow))]
	[EnableMethod]
	public  class DlgPetMatchRankShowViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UISetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UISetRectTransform == null )
     			{
		    		this.m_EG_UISetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UISet");
     			}
     			return this.m_EG_UISetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_MyRankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_MyRankText == null )
     			{
		    		this.m_E_Text_MyRankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UISet/Left/E_Text_MyRank");
     			}
     			return this.m_E_Text_MyRankText;
     		}
     	}

		public UnityEngine.RectTransform EG_Rank_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Rank_1RectTransform == null )
     			{
		    		this.m_EG_Rank_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UISet/Left/EG_Rank_1");
     			}
     			return this.m_EG_Rank_1RectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_UISet/Left/EG_Rank_1/ES_ModelShow_1");
		    	   this.m_es_modelshow_1 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow_1;
     		}
     	}

		public UnityEngine.RectTransform EG_Rank_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Rank_2RectTransform == null )
     			{
		    		this.m_EG_Rank_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UISet/Left/EG_Rank_2");
     			}
     			return this.m_EG_Rank_2RectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_UISet/Left/EG_Rank_2/ES_ModelShow_2");
		    	   this.m_es_modelshow_2 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow_2;
     		}
     	}

		public UnityEngine.RectTransform EG_Rank_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Rank_3RectTransform == null )
     			{
		    		this.m_EG_Rank_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UISet/Left/EG_Rank_3");
     			}
     			return this.m_EG_Rank_3RectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_UISet/Left/EG_Rank_3/ES_ModelShow_3");
		    	   this.m_es_modelshow_3 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow_3;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetMatchRankShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetMatchRankShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetMatchRankShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_UISet/Right/E_PetMatchRankShowItems");
     			}
     			return this.m_E_PetMatchRankShowItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_MyRankShowRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MyRankShowRectTransform == null )
     			{
		    		this.m_EG_MyRankShowRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UISet/Right/EG_MyRankShow");
     			}
     			return this.m_EG_MyRankShowRectTransform;
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_UISet/Right/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage1Image == null )
     			{
		    		this.m_E_HeadIcomImage1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UISet/Right/E_ItemTypeSet/Type_0/E_HeadIcomImage1");
     			}
     			return this.m_E_HeadIcomImage1Image;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage2Image == null )
     			{
		    		this.m_E_HeadIcomImage2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UISet/Right/E_ItemTypeSet/Type_1/E_HeadIcomImage2");
     			}
     			return this.m_E_HeadIcomImage2Image;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage3Image == null )
     			{
		    		this.m_E_HeadIcomImage3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UISet/Right/E_ItemTypeSet/Type_2/E_HeadIcomImage3");
     			}
     			return this.m_E_HeadIcomImage3Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_EG_UISetRectTransform = null;
			this.m_E_Text_MyRankText = null;
			this.m_EG_Rank_1RectTransform = null;
			this.m_es_modelshow_1 = null;
			this.m_EG_Rank_2RectTransform = null;
			this.m_es_modelshow_2 = null;
			this.m_EG_Rank_3RectTransform = null;
			this.m_es_modelshow_3 = null;
			this.m_E_PetMatchRankShowItemsLoopVerticalScrollRect = null;
			this.m_EG_MyRankShowRectTransform = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_HeadIcomImage1Image = null;
			this.m_E_HeadIcomImage2Image = null;
			this.m_E_HeadIcomImage3Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.RectTransform m_EG_UISetRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_MyRankText = null;
		private UnityEngine.RectTransform m_EG_Rank_1RectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow_1 = null;
		private UnityEngine.RectTransform m_EG_Rank_2RectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow_2 = null;
		private UnityEngine.RectTransform m_EG_Rank_3RectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow_3 = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetMatchRankShowItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_MyRankShowRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage1Image = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage2Image = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage3Image = null;
		public Transform uiTransform = null;
	}
}
