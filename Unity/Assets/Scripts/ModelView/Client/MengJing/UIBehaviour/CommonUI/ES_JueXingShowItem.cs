using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JueXingShowItem : Entity,IAwake<Transform>,IDestroy
	{
		public Action<int> ClickHandler;
		public int SkillId;
		
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
		    		this.m_E_ImageIconButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
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
		    		this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
     			}
     			return this.m_E_ImageIconImage;
     		}
     	}

		public Image E_ImageKuangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageKuangImage == null )
     			{
		    		this.m_E_ImageKuangImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageKuang");
     			}
     			return this.m_E_ImageKuangImage;
     		}
     	}

		public Text E_TextSkillNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextSkillNameText == null )
     			{
		    		this.m_E_TextSkillNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextSkillName");
     			}
     			return this.m_E_TextSkillNameText;
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
			this.m_E_ImageIconButton = null;
			this.m_E_ImageIconImage = null;
			this.m_E_ImageKuangImage = null;
			this.m_E_TextSkillNameText = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageIconButton = null;
		private Image m_E_ImageIconImage = null;
		private Image m_E_ImageKuangImage = null;
		private Text m_E_TextSkillNameText = null;
		public Transform uiTransform = null;
	}
}
