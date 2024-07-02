
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgEnterMapHint))]
	[EnableMethod]
	public  class DlgEnterMapHintViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_LeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftRectTransform == null )
     			{
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_JingLingShowSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_JingLingShowSetRectTransform == null )
     			{
		    		this.m_EG_JingLingShowSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_JingLingShowSet");
     			}
     			return this.m_EG_JingLingShowSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_ShenYuanSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ShenYuanSetRectTransform == null )
     			{
		    		this.m_EG_ShenYuanSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_ShenYuanSet");
     			}
     			return this.m_EG_ShenYuanSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_titleTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_titleTextText == null )
     			{
		    		this.m_E_titleTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_titleText");
     			}
     			return this.m_E_titleTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_LeftRectTransform = null;
			this.m_EG_JingLingShowSetRectTransform = null;
			this.m_EG_ShenYuanSetRectTransform = null;
			this.m_E_titleTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.RectTransform m_EG_JingLingShowSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_ShenYuanSetRectTransform = null;
		private UnityEngine.UI.Text m_E_titleTextText = null;
		public Transform uiTransform = null;
	}
}
