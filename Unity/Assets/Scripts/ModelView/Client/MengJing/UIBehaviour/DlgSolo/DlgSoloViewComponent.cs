
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSolo))]
	[EnableMethod]
	public  class DlgSoloViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonMatchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMatchButton == null )
     			{
		    		this.m_E_ButtonMatchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonMatch");
     			}
     			return this.m_E_ButtonMatchButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMatchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMatchImage == null )
     			{
		    		this.m_E_ButtonMatchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonMatch");
     			}
     			return this.m_E_ButtonMatchImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_IntegraListText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_IntegraListText == null )
     			{
		    		this.m_E_Text_IntegraListText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_IntegraList");
     			}
     			return this.m_E_Text_IntegraListText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ResultText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ResultText == null )
     			{
		    		this.m_E_Text_ResultText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Result");
     			}
     			return this.m_E_Text_ResultText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_MatchText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_MatchText == null )
     			{
		    		this.m_E_Text_MatchText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Match");
     			}
     			return this.m_E_Text_MatchText;
     		}
     	}

		public UnityEngine.RectTransform EG_SoloResultListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SoloResultListNodeRectTransform == null )
     			{
		    		this.m_EG_SoloResultListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView1/Viewport/EG_SoloResultListNode");
     			}
     			return this.m_EG_SoloResultListNodeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UISoloResultShowRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UISoloResultShowRectTransform == null )
     			{
		    		this.m_EG_UISoloResultShowRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView1/Viewport/EG_SoloResultListNode/EG_UISoloResultShow");
     			}
     			return this.m_EG_UISoloResultShowRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonMatchButton = null;
			this.m_E_ButtonMatchImage = null;
			this.m_E_Text_IntegraListText = null;
			this.m_E_Text_ResultText = null;
			this.m_E_Text_MatchText = null;
			this.m_EG_SoloResultListNodeRectTransform = null;
			this.m_EG_UISoloResultShowRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonMatchButton = null;
		private UnityEngine.UI.Image m_E_ButtonMatchImage = null;
		private UnityEngine.UI.Text m_E_Text_IntegraListText = null;
		private UnityEngine.UI.Text m_E_Text_ResultText = null;
		private UnityEngine.UI.Text m_E_Text_MatchText = null;
		private UnityEngine.RectTransform m_EG_SoloResultListNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_UISoloResultShowRectTransform = null;
		public Transform uiTransform = null;
	}
}
