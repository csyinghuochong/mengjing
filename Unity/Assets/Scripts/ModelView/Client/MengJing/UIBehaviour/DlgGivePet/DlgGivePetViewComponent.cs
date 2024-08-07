
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgGivePet))]
	[EnableMethod]
	public  class DlgGivePetViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_PetListItemsLoopVerticalScrollRect
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
		    		this.m_E_PetListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetListItems");
     			}
     			return this.m_E_PetListItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_TaskDesTextText
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
		    		this.m_E_TaskDesTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TaskDesText");
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

		public UnityEngine.UI.Button E_GiveBtnButton
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
		    		this.m_E_GiveBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_GiveBtn");
     			}
     			return this.m_E_GiveBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_GiveBtnImage
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
		    		this.m_E_GiveBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_GiveBtn");
     			}
     			return this.m_E_GiveBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_CloseBtnButton
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
		    		this.m_E_CloseBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CloseBtn");
     			}
     			return this.m_E_CloseBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseBtnImage
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
		    		this.m_E_CloseBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CloseBtn");
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

		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetListItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_TaskDesTextText = null;
		private EntityRef<ES_PetInfoShow> m_es_petinfoshow = null;
		private UnityEngine.UI.Button m_E_GiveBtnButton = null;
		private UnityEngine.UI.Image m_E_GiveBtnImage = null;
		private UnityEngine.UI.Button m_E_CloseBtnButton = null;
		private UnityEngine.UI.Image m_E_CloseBtnImage = null;
		public Transform uiTransform = null;
	}
}
