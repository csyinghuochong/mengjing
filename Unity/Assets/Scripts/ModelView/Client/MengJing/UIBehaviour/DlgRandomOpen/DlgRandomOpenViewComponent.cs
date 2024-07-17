using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRandomOpen))]
	[EnableMethod]
	public  class DlgRandomOpenViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_Text_LayerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LayerText == null )
     			{
		    		this.m_E_Text_LayerText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Layer");
     			}
     			return this.m_E_Text_LayerText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Text_LayerText = null;
			this.uiTransform = null;
		}

		private Text m_E_Text_LayerText = null;
		public Transform uiTransform = null;
	}
}
