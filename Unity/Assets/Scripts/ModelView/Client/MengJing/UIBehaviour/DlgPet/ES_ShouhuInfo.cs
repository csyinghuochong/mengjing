using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ShouhuInfo : Entity,IAwake<Transform>,IDestroy 
	{
		public int Index;
		public Action<int> SelectHandler;
		
		public Button E_ImageSelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectButton == null )
     			{
		    		this.m_E_ImageSelectButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageSelect");
     			}
     			return this.m_E_ImageSelectButton;
     		}
     	}

		public Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public Image E_ImageActiveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageActiveImage == null )
     			{
		    		this.m_E_ImageActiveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageActive");
     			}
     			return this.m_E_ImageActiveImage;
     		}
     	}

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

		public Image E_ImageDaDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageDaDiImage == null )
     			{
		    		this.m_E_ImageDaDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDaDi");
     			}
     			return this.m_E_ImageDaDiImage;
     		}
     	}

		public Image E_ImageIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIconImage == null )
     			{
		    		this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     			return this.m_E_ImageIconImage;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ModelShow es = this.m_es_modelshow;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NameText == null )
     			{
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     			return this.m_E_Text_NameText;
     		}
     	}

		public Text E_Text_AttriText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_AttriText == null )
     			{
		    		this.m_E_Text_AttriText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Attri");
     			}
     			return this.m_E_Text_AttriText;
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
			this.m_E_ImageSelectButton = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_ImageActiveImage = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_ImageDaDiImage = null;
			this.m_E_ImageIconImage = null;
			this.m_es_modelshow = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_AttriText = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageSelectButton = null;
		private Image m_E_ImageSelectImage = null;
		private Image m_E_ImageActiveImage = null;
		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Image m_E_ImageDaDiImage = null;
		private Image m_E_ImageIconImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_AttriText = null;
		public Transform uiTransform = null;
	}
}
