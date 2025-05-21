
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetHeXinHeCheng))]
	[EnableMethod]
	public  class DlgPetHeXinHeChengViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Close");
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImagePetHexinItemIconImage
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
		    		this.m_E_ImagePetHexinItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ImagePetHexinItemIcon");
     			}
     			return this.m_E_ImagePetHexinItemIconImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_OneKeyButton
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
		    		this.m_E_Button_OneKeyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_OneKey");
     			}
     			return this.m_E_Button_OneKeyButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_OneKeyImage
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
		    		this.m_E_Button_OneKeyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_OneKey");
     			}
     			return this.m_E_Button_OneKeyImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetHeXinListLoopVerticalScrollRect
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
		    		this.m_E_PetHeXinListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_PetHeXinList");
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

		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.UI.Image m_E_ImagePetHexinItemIconImage = null;
		private UnityEngine.UI.Button m_E_Button_OneKeyButton = null;
		private UnityEngine.UI.Image m_E_Button_OneKeyImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetHeXinListLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
