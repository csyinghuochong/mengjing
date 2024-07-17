using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Shield : Entity,IAwake<Transform>,IDestroy 
	{
		public Action<int> ClickHandler;
		public int ShieldType;
		
		public RectTransform EG_SelectShowRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectShowRectTransform == null )
     			{
		    		this.m_EG_SelectShowRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SelectShow");
     			}
     			return this.m_EG_SelectShowRectTransform;
     		}
     	}

		public Button E_ImageIconButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIconButton == null )
     			{
		    		this.m_E_ImageIconButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     			return this.m_E_ImageIconButton;
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

		public Text E_TextNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNameText == null )
     			{
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     			return this.m_E_TextNameText;
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
			this.m_EG_SelectShowRectTransform = null;
			this.m_E_ImageIconButton = null;
			this.m_E_ImageIconImage = null;
			this.m_E_TextNameText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SelectShowRectTransform = null;
		private Button m_E_ImageIconButton = null;
		private Image m_E_ImageIconImage = null;
		private Text m_E_TextNameText = null;
		public Transform uiTransform = null;
	}
}
