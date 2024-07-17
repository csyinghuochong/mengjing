using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOpen))]
	[EnableMethod]
	public  class DlgTowerOpenViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_TextTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTipText == null )
     			{
		    		this.m_E_TextTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UITiaoZhan/E_TextTip");
     			}
     			return this.m_E_TextTipText;
     		}
     	}

		public RectTransform EG_PostionSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PostionSetRectTransform == null )
     			{
		    		this.m_EG_PostionSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PostionSet");
     			}
     			return this.m_EG_PostionSetRectTransform;
     		}
     	}

		public Image E_ImageDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageDiImage == null )
     			{
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public Text E_Lab_ChapterNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ChapterNameText == null )
     			{
		    		this.m_E_Lab_ChapterNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapterName");
     			}
     			return this.m_E_Lab_ChapterNameText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextTipText = null;
			this.m_EG_PostionSetRectTransform = null;
			this.m_E_ImageDiImage = null;
			this.m_E_Lab_ChapterNameText = null;
			this.uiTransform = null;
		}

		private Text m_E_TextTipText = null;
		private RectTransform m_EG_PostionSetRectTransform = null;
		private Image m_E_ImageDiImage = null;
		private Text m_E_Lab_ChapterNameText = null;
		public Transform uiTransform = null;
	}
}
