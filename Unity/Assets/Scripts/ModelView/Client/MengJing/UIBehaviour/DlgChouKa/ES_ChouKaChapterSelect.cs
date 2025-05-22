using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChouKaChapterSelect : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Action<int> ClickHandler;
		
		public UnityEngine.UI.Button E_Btn_ZhangJie1Button
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
		    		this.m_E_Btn_ZhangJie1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie1");
     			}
     			return this.m_E_Btn_ZhangJie1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhangJie1Image
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
		    		this.m_E_Btn_ZhangJie1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie1");
     			}
     			return this.m_E_Btn_ZhangJie1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ZhangJie2Button
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
		    		this.m_E_Btn_ZhangJie2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie2");
     			}
     			return this.m_E_Btn_ZhangJie2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhangJie2Image
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
		    		this.m_E_Btn_ZhangJie2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie2");
     			}
     			return this.m_E_Btn_ZhangJie2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ZhangJie3Button
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
		    		this.m_E_Btn_ZhangJie3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie3");
     			}
     			return this.m_E_Btn_ZhangJie3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhangJie3Image
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
		    		this.m_E_Btn_ZhangJie3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie3");
     			}
     			return this.m_E_Btn_ZhangJie3Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ZhangJie4Button
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
		    		this.m_E_Btn_ZhangJie4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie4");
     			}
     			return this.m_E_Btn_ZhangJie4Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhangJie4Image
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
		    		this.m_E_Btn_ZhangJie4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie4");
     			}
     			return this.m_E_Btn_ZhangJie4Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ZhangJie5Button
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
		    		this.m_E_Btn_ZhangJie5Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie5");
     			}
     			return this.m_E_Btn_ZhangJie5Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhangJie5Image
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
		    		this.m_E_Btn_ZhangJie5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_ZhangJie5");
     			}
     			return this.m_E_Btn_ZhangJie5Image;
     		}
     	}

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

		private UnityEngine.UI.Button m_E_Btn_ZhangJie1Button = null;
		private UnityEngine.UI.Image m_E_Btn_ZhangJie1Image = null;
		private UnityEngine.UI.Button m_E_Btn_ZhangJie2Button = null;
		private UnityEngine.UI.Image m_E_Btn_ZhangJie2Image = null;
		private UnityEngine.UI.Button m_E_Btn_ZhangJie3Button = null;
		private UnityEngine.UI.Image m_E_Btn_ZhangJie3Image = null;
		private UnityEngine.UI.Button m_E_Btn_ZhangJie4Button = null;
		private UnityEngine.UI.Image m_E_Btn_ZhangJie4Image = null;
		private UnityEngine.UI.Button m_E_Btn_ZhangJie5Button = null;
		private UnityEngine.UI.Image m_E_Btn_ZhangJie5Image = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		public Transform uiTransform = null;
	}
}
