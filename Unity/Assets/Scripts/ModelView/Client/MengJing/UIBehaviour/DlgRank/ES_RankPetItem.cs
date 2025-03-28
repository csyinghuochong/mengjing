using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankPetItem : Entity,IAwake<Transform>,IDestroy 
	{
		public GameObject[] ImageIconList;
		public RankPetInfo RankPetInfo;
		public List<long> PetIdList = new();
		
		public Button E_Btn_PVPButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PVPButton == null )
     			{
		    		this.m_E_Btn_PVPButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_PVP");
     			}
     			return this.m_E_Btn_PVPButton;
     		}
     	}

		public Image E_Btn_PVPImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PVPImage == null )
     			{
		    		this.m_E_Btn_PVPImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_PVP");
     			}
     			return this.m_E_Btn_PVPImage;
     		}
     	}

		public Button E_ImageIcon1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon1Button == null )
     			{
		    		this.m_E_ImageIcon1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon1");
     			}
     			return this.m_E_ImageIcon1Button;
     		}
     	}

		public Image E_ImageIcon1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon1Image == null )
     			{
		    		this.m_E_ImageIcon1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon1");
     			}
     			return this.m_E_ImageIcon1Image;
     		}
     	}

		public Button E_ImageIcon2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon2Button == null )
     			{
		    		this.m_E_ImageIcon2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon2");
     			}
     			return this.m_E_ImageIcon2Button;
     		}
     	}

		public Image E_ImageIcon2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon2Image == null )
     			{
		    		this.m_E_ImageIcon2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon2");
     			}
     			return this.m_E_ImageIcon2Image;
     		}
     	}

		public Button E_ImageIcon3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon3Button == null )
     			{
		    		this.m_E_ImageIcon3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon3");
     			}
     			return this.m_E_ImageIcon3Button;
     		}
     	}

		public Image E_ImageIcon3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon3Image == null )
     			{
		    		this.m_E_ImageIcon3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon3");
     			}
     			return this.m_E_ImageIcon3Image;
     		}
     	}

		public Button E_ImageIcon4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon4Button == null )
     			{
		    		this.m_E_ImageIcon4Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon4");
     			}
     			return this.m_E_ImageIcon4Button;
     		}
     	}

		public Image E_ImageIcon4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon4Image == null )
     			{
		    		this.m_E_ImageIcon4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon4");
     			}
     			return this.m_E_ImageIcon4Image;
     		}
     	}

		public Button E_ImageIcon5Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon5Button == null )
     			{
		    		this.m_E_ImageIcon5Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon5");
     			}
     			return this.m_E_ImageIcon5Button;
     		}
     	}

		public Image E_ImageIcon5Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIcon5Image == null )
     			{
		    		this.m_E_ImageIcon5Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"IconShowSet/Mask/E_ImageIcon5");
     			}
     			return this.m_E_ImageIcon5Image;
     		}
     	}

		public Text E_Lab_PaiMingText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_PaiMingText == null )
     			{
		    		this.m_E_Lab_PaiMingText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_PaiMing");
     			}
     			return this.m_E_Lab_PaiMingText;
     		}
     	}

		public Text E_Lab_TeamNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TeamNameText == null )
     			{
		    		this.m_E_Lab_TeamNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TeamName");
     			}
     			return this.m_E_Lab_TeamNameText;
     		}
     	}

		public Text E_Lab_OwnerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_OwnerText == null )
     			{
		    		this.m_E_Lab_OwnerText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Owner");
     			}
     			return this.m_E_Lab_OwnerText;
     		}
     	}
		
		public Text E_Lab_CombatText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Lab_CombatText == null )
				{
					this.m_E_Lab_CombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Combat");
				}
				return this.m_E_Lab_CombatText;
			}
		}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_Btn_PVPButton = null;
			this.m_E_Btn_PVPImage = null;
			this.m_E_ImageIcon1Button = null;
			this.m_E_ImageIcon1Image = null;
			this.m_E_ImageIcon2Button = null;
			this.m_E_ImageIcon2Image = null;
			this.m_E_ImageIcon3Button = null;
			this.m_E_ImageIcon3Image = null;
			this.m_E_ImageIcon4Button = null;
			this.m_E_ImageIcon4Image = null;
			this.m_E_ImageIcon5Button = null;
			this.m_E_ImageIcon5Image = null;
			this.m_E_Lab_PaiMingText = null;
			this.m_E_Lab_TeamNameText = null;
			this.m_E_Lab_OwnerText = null;
			this.m_E_Lab_CombatText = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_PVPButton = null;
		private Image m_E_Btn_PVPImage = null;
		private Button m_E_ImageIcon1Button = null;
		private Image m_E_ImageIcon1Image = null;
		private Button m_E_ImageIcon2Button = null;
		private Image m_E_ImageIcon2Image = null;
		private Button m_E_ImageIcon3Button = null;
		private Image m_E_ImageIcon3Image = null;
		private Button m_E_ImageIcon4Button = null;
		private Image m_E_ImageIcon4Image = null;
		private Button m_E_ImageIcon5Button = null;
		private Image m_E_ImageIcon5Image = null;
		private Text m_E_Lab_PaiMingText = null;
		private Text m_E_Lab_TeamNameText = null;
		private Text m_E_Lab_OwnerText = null;
		private Text m_E_Lab_CombatText = null;
		public Transform uiTransform = null;
	}
}
