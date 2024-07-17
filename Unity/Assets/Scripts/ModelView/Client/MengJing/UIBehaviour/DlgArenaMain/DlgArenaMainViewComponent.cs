using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgArenaMain))]
	[EnableMethod]
	public  class DlgArenaMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_TextVSText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextVSText == null )
     			{
		    		this.m_E_TextVSText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image/E_TextVS");
     			}
     			return this.m_E_TextVSText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextVSText = null;
			this.uiTransform = null;
		}

		private Text m_E_TextVSText = null;
		public Transform uiTransform = null;
	}
}
