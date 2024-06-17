
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMystery))]
	[EnableMethod]
	public  class DlgMysteryViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_modelshow ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MysteryItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MysteryItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MysteryItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_MysteryItems");
     			}
     			return this.m_E_MysteryItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_E_MysteryItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MysteryItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
