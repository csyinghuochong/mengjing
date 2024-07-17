using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSeasonMain))]
	[EnableMethod]
	public  class DlgSeasonMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_CDdownTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CDdownTimeTextText == null )
     			{
		    		this.m_E_CDdownTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_CDdownTimeText");
     			}
     			return this.m_E_CDdownTimeTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CDdownTimeTextText = null;
			this.uiTransform = null;
		}

		private Text m_E_CDdownTimeTextText = null;
		public Transform uiTransform = null;
	}
}
