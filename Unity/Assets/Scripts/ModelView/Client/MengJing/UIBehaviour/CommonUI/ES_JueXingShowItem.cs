
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JueXingShowItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		public Action<int> ClickHandler;
		public int SkillId;
		
		public UnityEngine.UI.Button E_ImageIconButton
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
		    		this.m_E_ImageIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
     			}
     			return this.m_E_ImageIconButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIconImage
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
		    		this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ImageMask/E_ImageIcon");
     			}
     			return this.m_E_ImageIconImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageKuangImage
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
		    		this.m_E_ImageKuangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageKuang");
     			}
     			return this.m_E_ImageKuangImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextSkillNameText
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
		    		this.m_E_TextSkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextSkillName");
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

		private UnityEngine.UI.Button m_E_ImageIconButton = null;
		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.UI.Image m_E_ImageKuangImage = null;
		private UnityEngine.UI.Text m_E_TextSkillNameText = null;
		public Transform uiTransform = null;
	}
}
