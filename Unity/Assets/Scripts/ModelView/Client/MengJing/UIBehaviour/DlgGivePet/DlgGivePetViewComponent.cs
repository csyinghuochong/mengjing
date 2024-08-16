using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgGivePet))]
	[EnableMethod]
	public  class DlgGivePetViewComponent : Entity,IAwake,IDestroy 
	{
		public LoopVerticalScrollRect E_PetListItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetListItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetListItems");
     			}
     			return this.m_E_PetListItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_TaskDesTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskDesTextText == null )
     			{
		    		this.m_E_TaskDesTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_TaskDesText");
     			}
     			return this.m_E_TaskDesTextText;
     		}
     	}

		public ES_PetInfoShow ES_PetInfoShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetInfoShow es = this.m_es_petinfoshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_PetInfoShow");
		    	   this.m_es_petinfoshow = this.AddChild<ES_PetInfoShow,Transform>(subTrans);
     			}
     			return this.m_es_petinfoshow;
     		}
     	}

		public Button E_GiveBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveBtnButton == null )
     			{
		    		this.m_E_GiveBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_GiveBtn");
     			}
     			return this.m_E_GiveBtnButton;
     		}
     	}

		public Image E_GiveBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveBtnImage == null )
     			{
		    		this.m_E_GiveBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_GiveBtn");
     			}
     			return this.m_E_GiveBtnImage;
     		}
     	}

		public Button E_CloseBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnButton == null )
     			{
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnButton;
     		}
     	}

		public Image E_CloseBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseBtnImage == null )
     			{
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PetListItemsLoopVerticalScrollRect = null;
			this.m_E_TaskDesTextText = null;
			this.m_es_petinfoshow = null;
			this.m_E_GiveBtnButton = null;
			this.m_E_GiveBtnImage = null;
			this.m_E_CloseBtnButton = null;
			this.m_E_CloseBtnImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_PetListItemsLoopVerticalScrollRect = null;
		private Text m_E_TaskDesTextText = null;
		private EntityRef<ES_PetInfoShow> m_es_petinfoshow = null;
		private Button m_E_GiveBtnButton = null;
		private Image m_E_GiveBtnImage = null;
		private Button m_E_CloseBtnButton = null;
		private Image m_E_CloseBtnImage = null;
		public Transform uiTransform = null;
	}
}
