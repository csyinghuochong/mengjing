
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgBattleMain))]
	[EnableMethod]
	public  class DlgBattleMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_TextVS_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextVS_1Text == null )
     			{
		    		this.m_E_TextVS_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_TextVS_1");
     			}
     			return this.m_E_TextVS_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextVS_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextVS_2Text == null )
     			{
		    		this.m_E_TextVS_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_TextVS_2");
     			}
     			return this.m_E_TextVS_2Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextVS_KillText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextVS_KillText == null )
     			{
		    		this.m_E_TextVS_KillText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_TextVS_Kill");
     			}
     			return this.m_E_TextVS_KillText;
     		}
     	}

		public UnityEngine.UI.Text E_CountDownTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CountDownTimeText == null )
     			{
		    		this.m_E_CountDownTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_CountDownTime");
     			}
     			return this.m_E_CountDownTimeText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextVS_1Text = null;
			this.m_E_TextVS_2Text = null;
			this.m_E_TextVS_KillText = null;
			this.m_E_CountDownTimeText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_TextVS_1Text = null;
		private UnityEngine.UI.Text m_E_TextVS_2Text = null;
		private UnityEngine.UI.Text m_E_TextVS_KillText = null;
		private UnityEngine.UI.Text m_E_CountDownTimeText = null;
		public Transform uiTransform = null;
	}
}
