using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMapBig))]
	[EnableMethod]
	public  class DlgMapBigViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_MapNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapNameText == null )
     			{
		    		this.m_E_MapNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image (5)/E_MapName");
     			}
     			return this.m_E_MapNameText;
     		}
     	}

		public RectTransform EG_ImageSelectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ImageSelectRectTransform == null )
     			{
		    		this.m_EG_ImageSelectRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ImageSelect");
     			}
     			return this.m_EG_ImageSelectRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_MapBigNpcItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapBigNpcItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MapBigNpcItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_MapBigNpcItems");
     			}
     			return this.m_E_MapBigNpcItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_ShowMonsterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShowMonsterButton == null )
     			{
		    		this.m_E_Btn_ShowMonsterButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ShowMonster");
     			}
     			return this.m_E_Btn_ShowMonsterButton;
     		}
     	}

		public Image E_Btn_ShowMonsterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShowMonsterImage == null )
     			{
		    		this.m_E_Btn_ShowMonsterImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ShowMonster");
     			}
     			return this.m_E_Btn_ShowMonsterImage;
     		}
     	}

		public Button E_Btn_CloseButton
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public RectTransform EG_MapNameSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MapNameSetRectTransform == null )
     			{
		    		this.m_EG_MapNameSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet");
     			}
     			return this.m_EG_MapNameSetRectTransform;
     		}
     	}

		public Button E_RawImageButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RawImageButton == null )
     			{
		    		this.m_E_RawImageButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MapNameSet/E_RawImage");
     			}
     			return this.m_E_RawImageButton;
     		}
     	}

		public RawImage E_RawImageRawImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RawImageRawImage == null )
     			{
		    		this.m_E_RawImageRawImage = UIFindHelper.FindDeepChild<RawImage>(this.uiTransform.gameObject,"EG_MapNameSet/E_RawImage");
     			}
     			return this.m_E_RawImageRawImage;
     		}
     	}

		public EventTrigger E_RawImageEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RawImageEventTrigger == null )
     			{
		    		this.m_E_RawImageEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_MapNameSet/E_RawImage");
     			}
     			return this.m_E_RawImageEventTrigger;
     		}
     	}

		public Text E_TextStallText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextStallText == null )
     			{
		    		this.m_E_TextStallText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MapNameSet/E_TextStall");
     			}
     			return this.m_E_TextStallText;
     		}
     	}

		public RectTransform EG_monsterPostionRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_monsterPostionRectTransform == null )
     			{
		    		this.m_EG_monsterPostionRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_monsterPostion");
     			}
     			return this.m_EG_monsterPostionRectTransform;
     		}
     	}

		public RectTransform EG_npcPostionRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_npcPostionRectTransform == null )
     			{
		    		this.m_EG_npcPostionRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_npcPostion");
     			}
     			return this.m_EG_npcPostionRectTransform;
     		}
     	}

		public RectTransform EG_chuansongRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_chuansongRectTransform == null )
     			{
		    		this.m_EG_chuansongRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_chuansong");
     			}
     			return this.m_EG_chuansongRectTransform;
     		}
     	}

		public RectTransform EG_mainPostionRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_mainPostionRectTransform == null )
     			{
		    		this.m_EG_mainPostionRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_mainPostion");
     			}
     			return this.m_EG_mainPostionRectTransform;
     		}
     	}

		public Text E_TextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextText == null )
     			{
		    		this.m_E_TextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MapNameSet/EG_mainPostion/E_Text");
     			}
     			return this.m_E_TextText;
     		}
     	}

		public RectTransform EG_bossIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_bossIconRectTransform == null )
     			{
		    		this.m_EG_bossIconRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_bossIcon");
     			}
     			return this.m_EG_bossIconRectTransform;
     		}
     	}

		public RectTransform EG_jiayuanPetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_jiayuanPetRectTransform == null )
     			{
		    		this.m_EG_jiayuanPetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_jiayuanPet");
     			}
     			return this.m_EG_jiayuanPetRectTransform;
     		}
     	}

		public RectTransform EG_jiayuanRubshRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_jiayuanRubshRectTransform == null )
     			{
		    		this.m_EG_jiayuanRubshRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_jiayuanRubsh");
     			}
     			return this.m_EG_jiayuanRubshRectTransform;
     		}
     	}

		public RectTransform EG_teamerPostionRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_teamerPostionRectTransform == null )
     			{
		    		this.m_EG_teamerPostionRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_teamerPostion");
     			}
     			return this.m_EG_teamerPostionRectTransform;
     		}
     	}

		public RectTransform EG_jinglingIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_jinglingIconRectTransform == null )
     			{
		    		this.m_EG_jinglingIconRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_jinglingIcon");
     			}
     			return this.m_EG_jinglingIconRectTransform;
     		}
     	}

		public RectTransform EG_pathPointRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_pathPointRectTransform == null )
     			{
		    		this.m_EG_pathPointRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MapNameSet/EG_pathPoint");
     			}
     			return this.m_EG_pathPointRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_MapNameText = null;
			this.m_EG_ImageSelectRectTransform = null;
			this.m_E_MapBigNpcItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_ShowMonsterButton = null;
			this.m_E_Btn_ShowMonsterImage = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_EG_MapNameSetRectTransform = null;
			this.m_E_RawImageButton = null;
			this.m_E_RawImageRawImage = null;
			this.m_E_RawImageEventTrigger = null;
			this.m_E_TextStallText = null;
			this.m_EG_monsterPostionRectTransform = null;
			this.m_EG_npcPostionRectTransform = null;
			this.m_EG_chuansongRectTransform = null;
			this.m_EG_mainPostionRectTransform = null;
			this.m_E_TextText = null;
			this.m_EG_bossIconRectTransform = null;
			this.m_EG_jiayuanPetRectTransform = null;
			this.m_EG_jiayuanRubshRectTransform = null;
			this.m_EG_teamerPostionRectTransform = null;
			this.m_EG_jinglingIconRectTransform = null;
			this.m_EG_pathPointRectTransform = null;
			this.uiTransform = null;
		}

		private Text m_E_MapNameText = null;
		private RectTransform m_EG_ImageSelectRectTransform = null;
		private LoopVerticalScrollRect m_E_MapBigNpcItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_ShowMonsterButton = null;
		private Image m_E_Btn_ShowMonsterImage = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private RectTransform m_EG_MapNameSetRectTransform = null;
		private Button m_E_RawImageButton = null;
		private RawImage m_E_RawImageRawImage = null;
		private EventTrigger m_E_RawImageEventTrigger = null;
		private Text m_E_TextStallText = null;
		private RectTransform m_EG_monsterPostionRectTransform = null;
		private RectTransform m_EG_npcPostionRectTransform = null;
		private RectTransform m_EG_chuansongRectTransform = null;
		private RectTransform m_EG_mainPostionRectTransform = null;
		private Text m_E_TextText = null;
		private RectTransform m_EG_bossIconRectTransform = null;
		private RectTransform m_EG_jiayuanPetRectTransform = null;
		private RectTransform m_EG_jiayuanRubshRectTransform = null;
		private RectTransform m_EG_teamerPostionRectTransform = null;
		private RectTransform m_EG_jinglingIconRectTransform = null;
		private RectTransform m_EG_pathPointRectTransform = null;
		public Transform uiTransform = null;
	}
}
