
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetHeChengPreview))]
	[EnableMethod]
	public  class DlgPetHeChengPreviewViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem1");
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
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem2");
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
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem3");
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
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem4");
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
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem5");
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
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetItemARectTransform
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
		    		this.m_EG_PetItemARectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetItemA");
     			}
     			return this.m_EG_PetItemARectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonSkillItems_ALoopVerticalScrollRect
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
		    		this.m_E_CommonSkillItems_ALoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems_A");
     			}
     			return this.m_E_CommonSkillItems_ALoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_PetItemBRectTransform
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
		    		this.m_EG_PetItemBRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetItemB");
     			}
     			return this.m_EG_PetItemBRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonSkillItems_BLoopVerticalScrollRect
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
		    		this.m_E_CommonSkillItems_BLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CommonSkillItems_B");
     			}
     			return this.m_E_CommonSkillItems_BLoopVerticalScrollRect;
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

		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetItemARectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItems_ALoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_PetItemBRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItems_BLoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
