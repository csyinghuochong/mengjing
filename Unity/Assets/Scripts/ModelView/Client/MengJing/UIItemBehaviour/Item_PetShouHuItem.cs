using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetShouHuItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetShouHuItem>
	{
		public RolePetInfo RolePetInfo;
		public Action<long> ButtonShouHuHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetShouHuItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_Img_PetHeroIonImage
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
		    			this.m_E_Img_PetHeroIonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
     				}
     				return this.m_E_Img_PetHeroIonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_PetHeroIon");
     			}
     		}
     	}

		public Image E_Img_ShouHuIconImage
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
     				if( this.m_E_Img_ShouHuIconImage == null )
     				{
		    			this.m_E_Img_ShouHuIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_ShouHuIcon");
     				}
     				return this.m_E_Img_ShouHuIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_ShouHuIcon");
     			}
     		}
     	}

		public Text E_Lab_PetNameText
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
		    			this.m_E_Lab_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     				}
     				return this.m_E_Lab_PetNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PetName");
     			}
     		}
     	}

		public Text E_Lab_PinFenText
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
		    			this.m_E_Lab_PinFenText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PinFen");
     				}
     				return this.m_E_Lab_PinFenText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PinFen");
     			}
     		}
     	}

		public Text E_Lab_ShouHuText
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
     				if( this.m_E_Lab_ShouHuText == null )
     				{
		    			this.m_E_Lab_ShouHuText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ShouHu");
     				}
     				return this.m_E_Lab_ShouHuText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ShouHu");
     			}
     		}
     	}

		public RectTransform EG_Node_2RectTransform
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
     				if( this.m_EG_Node_2RectTransform == null )
     				{
		    			this.m_EG_Node_2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node_2");
     				}
     				return this.m_EG_Node_2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node_2");
     			}
     		}
     	}

		public Button E_ButtonShouHuButton
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
     				if( this.m_E_ButtonShouHuButton == null )
     				{
		    			this.m_E_ButtonShouHuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node_2/E_ButtonShouHu");
     				}
     				return this.m_E_ButtonShouHuButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node_2/E_ButtonShouHu");
     			}
     		}
     	}

		public Image E_ButtonShouHuImage
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
     				if( this.m_E_ButtonShouHuImage == null )
     				{
		    			this.m_E_ButtonShouHuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node_2/E_ButtonShouHu");
     				}
     				return this.m_E_ButtonShouHuImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node_2/E_ButtonShouHu");
     			}
     		}
     	}

		public RectTransform EG_Node_1RectTransform
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
     				if( this.m_EG_Node_1RectTransform == null )
     				{
		    			this.m_EG_Node_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node_1");
     				}
     				return this.m_EG_Node_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node_1");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_PetHeroIonImage = null;
			this.m_E_Img_ShouHuIconImage = null;
			this.m_E_Lab_PetNameText = null;
			this.m_E_Lab_PinFenText = null;
			this.m_E_Lab_ShouHuText = null;
			this.m_EG_Node_2RectTransform = null;
			this.m_E_ButtonShouHuButton = null;
			this.m_E_ButtonShouHuImage = null;
			this.m_EG_Node_1RectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_Img_PetHeroIonImage = null;
		private Image m_E_Img_ShouHuIconImage = null;
		private Text m_E_Lab_PetNameText = null;
		private Text m_E_Lab_PinFenText = null;
		private Text m_E_Lab_ShouHuText = null;
		private RectTransform m_EG_Node_2RectTransform = null;
		private Button m_E_ButtonShouHuButton = null;
		private Image m_E_ButtonShouHuImage = null;
		private RectTransform m_EG_Node_1RectTransform = null;
		public Transform uiTransform = null;
	}
}
