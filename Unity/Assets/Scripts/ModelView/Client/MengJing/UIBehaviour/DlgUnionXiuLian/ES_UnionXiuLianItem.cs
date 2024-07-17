using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionXiuLianItem : Entity,IAwake<Transform>,IDestroy 
	{
		public Action<int> ClickHandler;
		public int Position;
		
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

		public Text E_Text_Tip_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Tip_1Text == null )
     			{
		    		this.m_E_Text_Tip_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Tip_1");
     			}
     			return this.m_E_Text_Tip_1Text;
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
			this.m_E_ImageSelectImage = null;
			this.m_E_Text_Tip_1Text = null;
			this.m_E_ImageIconButton = null;
			this.m_E_ImageIconImage = null;
			this.uiTransform = null;
		}

		private Image m_E_ImageSelectImage = null;
		private Text m_E_Text_Tip_1Text = null;
		private Button m_E_ImageIconButton = null;
		private Image m_E_ImageIconImage = null;
		public Transform uiTransform = null;
	}
}
