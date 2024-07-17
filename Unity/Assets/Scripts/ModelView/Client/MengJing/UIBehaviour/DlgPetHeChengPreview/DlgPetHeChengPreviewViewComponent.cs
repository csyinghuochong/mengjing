using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetHeChengPreview))]
	[EnableMethod]
	public  class DlgPetHeChengPreviewViewComponent : Entity,IAwake,IDestroy 
	{
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

		public RectTransform EG_PetZiZhiItem1RectTransform
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
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem2RectTransform
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
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem3RectTransform
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
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem4RectTransform
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
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem5RectTransform
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
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem6RectTransform
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
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public RectTransform EG_PetItemARectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetItemARectTransform == null )
     			{
		    		this.m_EG_PetItemARectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetItemA");
     			}
     			return this.m_EG_PetItemARectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_CommonSkillItems_ALoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItems_ALoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItems_ALoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems_A");
     			}
     			return this.m_E_CommonSkillItems_ALoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_PetItemBRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetItemBRectTransform == null )
     			{
		    		this.m_EG_PetItemBRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetItemB");
     			}
     			return this.m_EG_PetItemBRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_CommonSkillItems_BLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItems_BLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItems_BLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems_B");
     			}
     			return this.m_E_CommonSkillItems_BLoopVerticalScrollRect;
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

		public void DestroyWidget()
		{
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_EG_PetItemARectTransform = null;
			this.m_E_CommonSkillItems_ALoopVerticalScrollRect = null;
			this.m_EG_PetItemBRectTransform = null;
			this.m_E_CommonSkillItems_BLoopVerticalScrollRect = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private RectTransform m_EG_PetItemARectTransform = null;
		private LoopVerticalScrollRect m_E_CommonSkillItems_ALoopVerticalScrollRect = null;
		private RectTransform m_EG_PetItemBRectTransform = null;
		private LoopVerticalScrollRect m_E_CommonSkillItems_BLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
