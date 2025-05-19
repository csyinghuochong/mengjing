
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCellChapterOpen))]
	[EnableMethod]
	public  class DlgCellChapterOpenViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_ImageDiImage
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
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PostionSetRectTransform
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
		    		this.m_EG_PostionSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_PostionSet");
     			}
     			return this.m_EG_PostionSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ChapterNameText
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
		    		this.m_E_Lab_ChapterNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_PostionSet/E_Lab_ChapterName");
     			}
     			return this.m_E_Lab_ChapterNameText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageDiImage = null;
			this.m_EG_PostionSetRectTransform = null;
			this.m_E_Lab_ChapterNameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ImageDiImage = null;
		private UnityEngine.RectTransform m_EG_PostionSetRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_ChapterNameText = null;
		public Transform uiTransform = null;
	}
}
