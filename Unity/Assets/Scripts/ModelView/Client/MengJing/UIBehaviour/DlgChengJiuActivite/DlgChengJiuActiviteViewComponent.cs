using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgChengJiuActivite))]
	[EnableMethod]
	public  class DlgChengJiuActiviteViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_ChengJiuIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuIconImage == null )
     			{
		    		this.m_E_ChengJiuIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Bottom/E_ChengJiuIcon");
     			}
     			return this.m_E_ChengJiuIconImage;
     		}
     	}

		public Text E_Text_ChengJiuNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ChengJiuNameText == null )
     			{
		    		this.m_E_Text_ChengJiuNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Bottom/E_Text_ChengJiuName");
     			}
     			return this.m_E_Text_ChengJiuNameText;
     		}
     	}

		public Text E_Text_ChengJiuPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ChengJiuPointText == null )
     			{
		    		this.m_E_Text_ChengJiuPointText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Bottom/E_Text_ChengJiuPoint");
     			}
     			return this.m_E_Text_ChengJiuPointText;
     		}
     	}

		public Text E_Text_ChengJiuDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ChengJiuDescText == null )
     			{
		    		this.m_E_Text_ChengJiuDescText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Bottom/E_Text_ChengJiuDesc");
     			}
     			return this.m_E_Text_ChengJiuDescText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ChengJiuIconImage = null;
			this.m_E_Text_ChengJiuNameText = null;
			this.m_E_Text_ChengJiuPointText = null;
			this.m_E_Text_ChengJiuDescText = null;
			this.uiTransform = null;
		}

		private Image m_E_ChengJiuIconImage = null;
		private Text m_E_Text_ChengJiuNameText = null;
		private Text m_E_Text_ChengJiuPointText = null;
		private Text m_E_Text_ChengJiuDescText = null;
		public Transform uiTransform = null;
	}
}
