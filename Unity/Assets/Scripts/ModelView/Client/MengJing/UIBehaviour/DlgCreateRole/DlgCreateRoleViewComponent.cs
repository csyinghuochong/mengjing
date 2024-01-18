
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCreateRole))]
	[EnableMethod]
	public  class DlgCreateRoleViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text ENameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ENameText == null )
     			{
		    		this.m_ENameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EName");
     			}
     			return this.m_ENameText;
     		}
     	}

		public UnityEngine.UI.Button ECreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateButton == null )
     			{
		    		this.m_ECreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ECreate");
     			}
     			return this.m_ECreateButton;
     		}
     	}

		public UnityEngine.UI.Image ECreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateImage == null )
     			{
		    		this.m_ECreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ECreate");
     			}
     			return this.m_ECreateImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ENameText = null;
			this.m_ECreateButton = null;
			this.m_ECreateImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ENameText = null;
		private UnityEngine.UI.Button m_ECreateButton = null;
		private UnityEngine.UI.Image m_ECreateImage = null;
		public Transform uiTransform = null;
	}
}
