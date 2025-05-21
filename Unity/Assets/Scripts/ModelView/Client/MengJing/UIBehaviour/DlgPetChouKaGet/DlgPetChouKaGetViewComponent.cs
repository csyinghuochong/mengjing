
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetChouKaGet))]
	[EnableMethod]
	public  class DlgPetChouKaGetViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_BianYiDiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BianYiDiButton == null )
     			{
		    		this.m_E_BianYiDiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BianYiDi");
     			}
     			return this.m_E_BianYiDiButton;
     		}
     	}

		public UnityEngine.UI.Image E_BianYiDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BianYiDiImage == null )
     			{
		    		this.m_E_BianYiDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BianYiDi");
     			}
     			return this.m_E_BianYiDiImage;
     		}
     	}

		public UnityEngine.UI.Button E_LucklyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LucklyButton == null )
     			{
		    		this.m_E_LucklyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Luckly");
     			}
     			return this.m_E_LucklyButton;
     		}
     	}

		public UnityEngine.UI.Image E_LucklyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LucklyImage == null )
     			{
		    		this.m_E_LucklyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Luckly");
     			}
     			return this.m_E_LucklyImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetSkinIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetSkinIconRectTransform == null )
     			{
		    		this.m_EG_PetSkinIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetSkinIcon");
     			}
     			return this.m_EG_PetSkinIconRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_NewSkinNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NewSkinNameText == null )
     			{
		    		this.m_E_NewSkinNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PetSkinIcon/E_NewSkinName");
     			}
     			return this.m_E_NewSkinNameText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetNameText == null )
     			{
		    		this.m_E_Text_PetNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_PetName");
     			}
     			return this.m_E_Text_PetNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_FightValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_FightValueText == null )
     			{
		    		this.m_E_Text_FightValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_FightValue");
     			}
     			return this.m_E_Text_FightValueText;
     		}
     	}

		public UnityEngine.RectTransform EG_ImageStarListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ImageStarListRectTransform == null )
     			{
		    		this.m_EG_ImageStarListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_ImageStarList");
     			}
     			return this.m_EG_ImageStarListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem1RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem2RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem3RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem4RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem5RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem6RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem6RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
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
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/UIPetInfoShow/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetLevelText == null )
     			{
		    		this.m_E_Text_PetLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/UIPetInfoShow/E_Text_PetLevel");
     			}
     			return this.m_E_Text_PetLevelText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_TipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TipText == null )
     			{
		    		this.m_E_Text_TipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/UIPetInfoShow/E_Text_Tip");
     			}
     			return this.m_E_Text_TipText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_QualityText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_QualityText == null )
     			{
		    		this.m_E_Text_QualityText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/UIPetInfoShow/E_Text_Quality");
     			}
     			return this.m_E_Text_QualityText;
     		}
     	}

		public UnityEngine.RectTransform EG_PiFuJiHuoRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PiFuJiHuoRectTransform == null )
     			{
		    		this.m_EG_PiFuJiHuoRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/UIPetInfoShow/EG_PiFuJiHuo");
     			}
     			return this.m_EG_PiFuJiHuoRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BianYiDiButton = null;
			this.m_E_BianYiDiImage = null;
			this.m_E_LucklyButton = null;
			this.m_E_LucklyImage = null;
			this.m_EG_PetSkinIconRectTransform = null;
			this.m_E_NewSkinNameText = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_es_modelshow = null;
			this.m_E_Text_PetNameText = null;
			this.m_E_Text_FightValueText = null;
			this.m_EG_ImageStarListRectTransform = null;
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_Text_PetLevelText = null;
			this.m_E_Text_TipText = null;
			this.m_E_Text_QualityText = null;
			this.m_EG_PiFuJiHuoRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_BianYiDiButton = null;
		private UnityEngine.UI.Image m_E_BianYiDiImage = null;
		private UnityEngine.UI.Button m_E_LucklyButton = null;
		private UnityEngine.UI.Image m_E_LucklyImage = null;
		private UnityEngine.RectTransform m_EG_PetSkinIconRectTransform = null;
		private UnityEngine.UI.Text m_E_NewSkinNameText = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_Text_PetNameText = null;
		private UnityEngine.UI.Text m_E_Text_FightValueText = null;
		private UnityEngine.RectTransform m_EG_ImageStarListRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Text_PetLevelText = null;
		private UnityEngine.UI.Text m_E_Text_TipText = null;
		private UnityEngine.UI.Text m_E_Text_QualityText = null;
		private UnityEngine.RectTransform m_EG_PiFuJiHuoRectTransform = null;
		public Transform uiTransform = null;
	}
}
