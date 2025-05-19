
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCellDungeonEnterShow))]
	[EnableMethod]
	public  class DlgCellDungeonEnterShowViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.RectTransform EG_NanDu_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_NanDu_1RectTransform == null )
     			{
		    		this.m_EG_NanDu_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_PostionSet/EG_NanDu_1");
     			}
     			return this.m_EG_NanDu_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_NanDu_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_NanDu_2RectTransform == null )
     			{
		    		this.m_EG_NanDu_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_PostionSet/EG_NanDu_2");
     			}
     			return this.m_EG_NanDu_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_NanDu_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_NanDu_3RectTransform == null )
     			{
		    		this.m_EG_NanDu_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_PostionSet/EG_NanDu_3");
     			}
     			return this.m_EG_NanDu_3RectTransform;
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

		public UnityEngine.RectTransform EG_JingYingGuanKaShowSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_JingYingGuanKaShowSetRectTransform == null )
     			{
		    		this.m_EG_JingYingGuanKaShowSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_PostionSet/EG_JingYingGuanKaShowSet");
     			}
     			return this.m_EG_JingYingGuanKaShowSetRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PostionSetRectTransform = null;
			this.m_EG_NanDu_1RectTransform = null;
			this.m_EG_NanDu_2RectTransform = null;
			this.m_EG_NanDu_3RectTransform = null;
			this.m_E_Lab_ChapterNameText = null;
			this.m_EG_JingYingGuanKaShowSetRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PostionSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_NanDu_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_NanDu_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_NanDu_3RectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_ChapterNameText = null;
		private UnityEngine.RectTransform m_EG_JingYingGuanKaShowSetRectTransform = null;
		public Transform uiTransform = null;
	}
}
