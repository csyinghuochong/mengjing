using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetHeXinHeCheng))]
	[EnableMethod]
	public  class DlgPetHeXinHeChengViewComponent : Entity,IAwake,IDestroy 
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

		public Image E_ImagePetHexinItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImagePetHexinItemIconImage == null )
     			{
		    		this.m_E_ImagePetHexinItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImagePetHexinItemIcon");
     			}
     			return this.m_E_ImagePetHexinItemIconImage;
     		}
     	}

		public Button E_Button_OneKeyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OneKeyButton == null )
     			{
		    		this.m_E_Button_OneKeyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_OneKey");
     			}
     			return this.m_E_Button_OneKeyButton;
     		}
     	}

		public Image E_Button_OneKeyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OneKeyImage == null )
     			{
		    		this.m_E_Button_OneKeyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_OneKey");
     			}
     			return this.m_E_Button_OneKeyImage;
     		}
     	}

		public LoopVerticalScrollRect E_PetHeXinListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetHeXinListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetHeXinList");
     			}
     			return this.m_E_PetHeXinListLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_ImagePetHexinItemIconImage = null;
			this.m_E_Button_OneKeyButton = null;
			this.m_E_Button_OneKeyImage = null;
			this.m_E_PetHeXinListLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private Image m_E_ImagePetHexinItemIconImage = null;
		private Button m_E_Button_OneKeyButton = null;
		private Image m_E_Button_OneKeyImage = null;
		private LoopVerticalScrollRect m_E_PetHeXinListLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
