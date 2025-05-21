
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMapBig))]
	[EnableMethod]
	public  class DlgMapBigViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_MapNameSetRectTransform
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
		    		this.m_EG_MapNameSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet");
     			}
     			return this.m_EG_MapNameSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_RawImageButton
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
		    		this.m_E_RawImageButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/EG_MapNameSet/E_RawImage");
     			}
     			return this.m_E_RawImageButton;
     		}
     	}

		public UnityEngine.UI.RawImage E_RawImageRawImage
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
		    		this.m_E_RawImageRawImage = UIFindHelper.FindDeepChild<UnityEngine.UI.RawImage>(this.uiTransform.gameObject,"Left/EG_MapNameSet/E_RawImage");
     			}
     			return this.m_E_RawImageRawImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_RawImageEventTrigger
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
		    		this.m_E_RawImageEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Left/EG_MapNameSet/E_RawImage");
     			}
     			return this.m_E_RawImageEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_TextStallText
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
		    		this.m_E_TextStallText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_MapNameSet/E_TextStall");
     			}
     			return this.m_E_TextStallText;
     		}
     	}

		public UnityEngine.RectTransform EG_monsterPostionRectTransform
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
		    		this.m_EG_monsterPostionRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_monsterPostion");
     			}
     			return this.m_EG_monsterPostionRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_npcPostionRectTransform
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
		    		this.m_EG_npcPostionRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_npcPostion");
     			}
     			return this.m_EG_npcPostionRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_chuansongRectTransform
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
		    		this.m_EG_chuansongRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_chuansong");
     			}
     			return this.m_EG_chuansongRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_mainPostionRectTransform
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
		    		this.m_EG_mainPostionRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_mainPostion");
     			}
     			return this.m_EG_mainPostionRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextText
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
		    		this.m_E_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_mainPostion/E_Text");
     			}
     			return this.m_E_TextText;
     		}
     	}

		public UnityEngine.RectTransform EG_bossIconRectTransform
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
		    		this.m_EG_bossIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_bossIcon");
     			}
     			return this.m_EG_bossIconRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_jiayuanPetRectTransform
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
		    		this.m_EG_jiayuanPetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_jiayuanPet");
     			}
     			return this.m_EG_jiayuanPetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_jiayuanRubshRectTransform
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
		    		this.m_EG_jiayuanRubshRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_jiayuanRubsh");
     			}
     			return this.m_EG_jiayuanRubshRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_teamerPostionRectTransform
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
		    		this.m_EG_teamerPostionRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_teamerPostion");
     			}
     			return this.m_EG_teamerPostionRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_jinglingIconRectTransform
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
		    		this.m_EG_jinglingIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_jinglingIcon");
     			}
     			return this.m_EG_jinglingIconRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_pathPointRectTransform
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
		    		this.m_EG_pathPointRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MapNameSet/EG_pathPoint");
     			}
     			return this.m_EG_pathPointRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_MapBigNpcItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapBigNpcItemsImage == null )
     			{
		    		this.m_E_MapBigNpcItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_MapBigNpcItems");
     			}
     			return this.m_E_MapBigNpcItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MapBigNpcItemsLoopVerticalScrollRect
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
		    		this.m_E_MapBigNpcItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_MapBigNpcItems");
     			}
     			return this.m_E_MapBigNpcItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ShowMonsterButton
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
		    		this.m_E_Btn_ShowMonsterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ShowMonster");
     			}
     			return this.m_E_Btn_ShowMonsterButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShowMonsterImage
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
		    		this.m_E_Btn_ShowMonsterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ShowMonster");
     			}
     			return this.m_E_Btn_ShowMonsterImage;
     		}
     	}

		public UnityEngine.UI.Text E_MapNameText
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
		    		this.m_E_MapNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/Image (5)/E_MapName");
     			}
     			return this.m_E_MapNameText;
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/E_Btn_Close");
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ImageSelectRectTransform
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
		    		this.m_EG_ImageSelectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/EG_ImageSelect");
     			}
     			return this.m_EG_ImageSelectRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
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
			this.m_E_MapBigNpcItemsImage = null;
			this.m_E_MapBigNpcItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_ShowMonsterButton = null;
			this.m_E_Btn_ShowMonsterImage = null;
			this.m_E_MapNameText = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_EG_ImageSelectRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_MapNameSetRectTransform = null;
		private UnityEngine.UI.Button m_E_RawImageButton = null;
		private UnityEngine.UI.RawImage m_E_RawImageRawImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_RawImageEventTrigger = null;
		private UnityEngine.UI.Text m_E_TextStallText = null;
		private UnityEngine.RectTransform m_EG_monsterPostionRectTransform = null;
		private UnityEngine.RectTransform m_EG_npcPostionRectTransform = null;
		private UnityEngine.RectTransform m_EG_chuansongRectTransform = null;
		private UnityEngine.RectTransform m_EG_mainPostionRectTransform = null;
		private UnityEngine.UI.Text m_E_TextText = null;
		private UnityEngine.RectTransform m_EG_bossIconRectTransform = null;
		private UnityEngine.RectTransform m_EG_jiayuanPetRectTransform = null;
		private UnityEngine.RectTransform m_EG_jiayuanRubshRectTransform = null;
		private UnityEngine.RectTransform m_EG_teamerPostionRectTransform = null;
		private UnityEngine.RectTransform m_EG_jinglingIconRectTransform = null;
		private UnityEngine.RectTransform m_EG_pathPointRectTransform = null;
		private UnityEngine.UI.Image m_E_MapBigNpcItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MapBigNpcItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_ShowMonsterButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShowMonsterImage = null;
		private UnityEngine.UI.Text m_E_MapNameText = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.RectTransform m_EG_ImageSelectRectTransform = null;
		public Transform uiTransform = null;
	}
}
