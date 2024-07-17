using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgEnterMapHint))]
	[EnableMethod]
	public  class DlgEnterMapHintViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_LeftRectTransform
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
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public RectTransform EG_JingLingShowSetRectTransform
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
		    		this.m_EG_JingLingShowSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_JingLingShowSet");
     			}
     			return this.m_EG_JingLingShowSetRectTransform;
     		}
     	}

		public RectTransform EG_ShenYuanSetRectTransform
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
		    		this.m_EG_ShenYuanSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_ShenYuanSet");
     			}
     			return this.m_EG_ShenYuanSetRectTransform;
     		}
     	}

		public Text E_titleTextText
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
		    		this.m_E_titleTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Left/E_titleText");
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

		private RectTransform m_EG_LeftRectTransform = null;
		private RectTransform m_EG_JingLingShowSetRectTransform = null;
		private RectTransform m_EG_ShenYuanSetRectTransform = null;
		private Text m_E_titleTextText = null;
		public Transform uiTransform = null;
	}
}
