using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChouKaChapterSelect : Entity,IAwake<Transform>,IDestroy 
	{
		public Action<int> ClickHandler;
		
		public Button E_Btn_ZhangJie1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie1Button == null )
     			{
		    		this.m_E_Btn_ZhangJie1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ZhangJie1");
     			}
     			return this.m_E_Btn_ZhangJie1Button;
     		}
     	}

		public Image E_Btn_ZhangJie1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie1Image == null )
     			{
		    		this.m_E_Btn_ZhangJie1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ZhangJie1");
     			}
     			return this.m_E_Btn_ZhangJie1Image;
     		}
     	}

		public Button E_Btn_ZhangJie2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie2Button == null )
     			{
		    		this.m_E_Btn_ZhangJie2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ZhangJie2");
     			}
     			return this.m_E_Btn_ZhangJie2Button;
     		}
     	}

		public Image E_Btn_ZhangJie2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie2Image == null )
     			{
		    		this.m_E_Btn_ZhangJie2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ZhangJie2");
     			}
     			return this.m_E_Btn_ZhangJie2Image;
     		}
     	}

		public Button E_Btn_ZhangJie3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie3Button == null )
     			{
		    		this.m_E_Btn_ZhangJie3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ZhangJie3");
     			}
     			return this.m_E_Btn_ZhangJie3Button;
     		}
     	}

		public Image E_Btn_ZhangJie3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie3Image == null )
     			{
		    		this.m_E_Btn_ZhangJie3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ZhangJie3");
     			}
     			return this.m_E_Btn_ZhangJie3Image;
     		}
     	}

		public Button E_Btn_ZhangJie4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie4Button == null )
     			{
		    		this.m_E_Btn_ZhangJie4Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ZhangJie4");
     			}
     			return this.m_E_Btn_ZhangJie4Button;
     		}
     	}

		public Image E_Btn_ZhangJie4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie4Image == null )
     			{
		    		this.m_E_Btn_ZhangJie4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ZhangJie4");
     			}
     			return this.m_E_Btn_ZhangJie4Image;
     		}
     	}

		public Button E_Btn_ZhangJie5Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie5Button == null )
     			{
		    		this.m_E_Btn_ZhangJie5Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ZhangJie5");
     			}
     			return this.m_E_Btn_ZhangJie5Button;
     		}
     	}

		public Image E_Btn_ZhangJie5Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJie5Image == null )
     			{
		    		this.m_E_Btn_ZhangJie5Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ZhangJie5");
     			}
     			return this.m_E_Btn_ZhangJie5Image;
     		}
     	}

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
			this.m_E_Btn_ZhangJie1Button = null;
			this.m_E_Btn_ZhangJie1Image = null;
			this.m_E_Btn_ZhangJie2Button = null;
			this.m_E_Btn_ZhangJie2Image = null;
			this.m_E_Btn_ZhangJie3Button = null;
			this.m_E_Btn_ZhangJie3Image = null;
			this.m_E_Btn_ZhangJie4Button = null;
			this.m_E_Btn_ZhangJie4Image = null;
			this.m_E_Btn_ZhangJie5Button = null;
			this.m_E_Btn_ZhangJie5Image = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_ZhangJie1Button = null;
		private Image m_E_Btn_ZhangJie1Image = null;
		private Button m_E_Btn_ZhangJie2Button = null;
		private Image m_E_Btn_ZhangJie2Image = null;
		private Button m_E_Btn_ZhangJie3Button = null;
		private Image m_E_Btn_ZhangJie3Image = null;
		private Button m_E_Btn_ZhangJie4Button = null;
		private Image m_E_Btn_ZhangJie4Image = null;
		private Button m_E_Btn_ZhangJie5Button = null;
		private Image m_E_Btn_ZhangJie5Image = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		public Transform uiTransform = null;
	}
}
