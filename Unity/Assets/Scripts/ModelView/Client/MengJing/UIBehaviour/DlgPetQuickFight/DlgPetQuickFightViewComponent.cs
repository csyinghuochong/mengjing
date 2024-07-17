using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetQuickFight))]
	[EnableMethod]
	public  class DlgPetQuickFightViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public LoopVerticalScrollRect E_PetQuickFightItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetQuickFightItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetQuickFightItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"TopLeft/E_PetQuickFightItems");
     			}
     			return this.m_E_PetQuickFightItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_PetQuickFightItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private LoopVerticalScrollRect m_E_PetQuickFightItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
