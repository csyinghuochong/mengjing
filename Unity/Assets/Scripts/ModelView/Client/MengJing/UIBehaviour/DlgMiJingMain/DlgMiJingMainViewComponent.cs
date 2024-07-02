
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMiJingMain))]
	[EnableMethod]
	public  class DlgMiJingMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_DamageListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DamageListNodeRectTransform == null )
     			{
		    		this.m_EG_DamageListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_DamageListNode");
     			}
     			return this.m_EG_DamageListNodeRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_DamageListNodeRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_DamageListNodeRectTransform = null;
		public Transform uiTransform = null;
	}
}
