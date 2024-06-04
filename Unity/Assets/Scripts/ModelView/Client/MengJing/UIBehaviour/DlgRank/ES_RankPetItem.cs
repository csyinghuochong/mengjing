
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankPetItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public GameObject[] ImageIconList;
		public RankPetInfo RankPetInfo;
		public List<long> PetIdList = new();
		
		public UnityEngine.UI.Button E_Btn_PVPButton
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
		    		this.m_E_Btn_PVPButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_PVP");
     			}
     			return this.m_E_Btn_PVPButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_PVPImage
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
		    		this.m_E_Btn_PVPImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_PVP");
     			}
     			return this.m_E_Btn_PVPImage;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon1Button
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
		    		this.m_E_ImageIcon1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon1");
     			}
     			return this.m_E_ImageIcon1Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon1Image
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
		    		this.m_E_ImageIcon1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon1");
     			}
     			return this.m_E_ImageIcon1Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon2Button
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
		    		this.m_E_ImageIcon2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon2");
     			}
     			return this.m_E_ImageIcon2Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon2Image
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
		    		this.m_E_ImageIcon2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon2");
     			}
     			return this.m_E_ImageIcon2Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon3Button
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
		    		this.m_E_ImageIcon3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon3");
     			}
     			return this.m_E_ImageIcon3Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon3Image
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
		    		this.m_E_ImageIcon3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon3");
     			}
     			return this.m_E_ImageIcon3Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon4Button
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
		    		this.m_E_ImageIcon4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon4");
     			}
     			return this.m_E_ImageIcon4Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon4Image
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
		    		this.m_E_ImageIcon4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon4");
     			}
     			return this.m_E_ImageIcon4Image;
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon5Button
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
		    		this.m_E_ImageIcon5Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon5");
     			}
     			return this.m_E_ImageIcon5Button;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon5Image
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
		    		this.m_E_ImageIcon5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"IconShowSet/E_ImageIcon5");
     			}
     			return this.m_E_ImageIcon5Image;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_PaiMingText
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
		    		this.m_E_Lab_PaiMingText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_PaiMing");
     			}
     			return this.m_E_Lab_PaiMingText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TeamNameText
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
		    		this.m_E_Lab_TeamNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_TeamName");
     			}
     			return this.m_E_Lab_TeamNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_OwnerText
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
		    		this.m_E_Lab_OwnerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_Owner");
     			}
     			return this.m_E_Lab_OwnerText;
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
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_PVPButton = null;
		private UnityEngine.UI.Image m_E_Btn_PVPImage = null;
		private UnityEngine.UI.Button m_E_ImageIcon1Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon1Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon2Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon2Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon3Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon3Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon4Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon4Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon5Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon5Image = null;
		private UnityEngine.UI.Text m_E_Lab_PaiMingText = null;
		private UnityEngine.UI.Text m_E_Lab_TeamNameText = null;
		private UnityEngine.UI.Text m_E_Lab_OwnerText = null;
		public Transform uiTransform = null;
	}
}
