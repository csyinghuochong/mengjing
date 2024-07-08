
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetCangKu : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_PetCangKuItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetCangKuItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetCangKuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetCangKuItems");
     			}
     			return this.m_E_PetCangKuItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetCangKuDefendsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetCangKuDefendsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetCangKuDefendsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetCangKuDefends");
     			}
     			return this.m_E_PetCangKuDefendsLoopVerticalScrollRect;
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
			this.m_E_PetCangKuItemsLoopVerticalScrollRect = null;
			this.m_E_PetCangKuDefendsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetCangKuItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetCangKuDefendsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
