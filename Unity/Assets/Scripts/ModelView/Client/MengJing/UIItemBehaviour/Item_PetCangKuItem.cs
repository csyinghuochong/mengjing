
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetCangKuItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public RolePetInfo RolePetInfo;
		public Action PetCangKuAction;
		public int Index;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetCangKuItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_Img_PetHeroIonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Img_PetHeroIonImage == null )
     				{
		    			this.m_E_Img_PetHeroIonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
     				}
     				return this.m_E_Img_PetHeroIonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PetNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Lab_PetNameText == null )
     				{
		    			this.m_E_Lab_PetNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     				}
     				return this.m_E_Lab_PetNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PetLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Lab_PetLvText == null )
     				{
		    			this.m_E_Lab_PetLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetLv");
     				}
     				return this.m_E_Lab_PetLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PetLv");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PinFenText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Lab_PinFenText == null )
     				{
		    			this.m_E_Lab_PinFenText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PinFen");
     				}
     				return this.m_E_Lab_PinFenText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PinFen");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonPutButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ButtonPutButton == null )
     				{
		    			this.m_E_ButtonPutButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonPut");
     				}
     				return this.m_E_ButtonPutButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonPut");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonPutImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ButtonPutImage == null )
     				{
		    			this.m_E_ButtonPutImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonPut");
     				}
     				return this.m_E_ButtonPutImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonPut");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_PetHeroIonImage = null;
			this.m_E_Lab_PetNameText = null;
			this.m_E_Lab_PetLvText = null;
			this.m_E_Lab_PinFenText = null;
			this.m_E_ButtonPutButton = null;
			this.m_E_ButtonPutImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_Img_PetHeroIonImage = null;
		private UnityEngine.UI.Text m_E_Lab_PetNameText = null;
		private UnityEngine.UI.Text m_E_Lab_PetLvText = null;
		private UnityEngine.UI.Text m_E_Lab_PinFenText = null;
		private UnityEngine.UI.Button m_E_ButtonPutButton = null;
		private UnityEngine.UI.Image m_E_ButtonPutImage = null;
		public Transform uiTransform = null;
	}
}
