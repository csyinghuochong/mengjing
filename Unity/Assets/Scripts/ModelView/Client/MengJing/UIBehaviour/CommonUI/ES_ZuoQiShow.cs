
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ZuoQiShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.LoopHorizontalScrollRect E_ZuoQiShowItemsLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_ZuoQiShowItems");
     			}
     			return this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopHorizontalScrollRect m_E_ZuoQiShowItemsLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
