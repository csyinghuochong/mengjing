using UnityEngine;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMiJingMain))]
	[EnableMethod]
	public  class DlgMiJingMainViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_DamageListNodeRectTransform
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
		    		this.m_EG_DamageListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_DamageListNode");
     			}
     			return this.m_EG_DamageListNodeRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_DamageListNodeRectTransform = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_DamageListNodeRectTransform = null;
		public Transform uiTransform = null;
	}
}
