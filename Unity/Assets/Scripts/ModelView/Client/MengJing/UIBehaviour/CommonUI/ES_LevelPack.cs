
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_LevelPack : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.ScrollRect E_LevelPackItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelPackItemsScrollRect == null )
     			{
		    		this.m_E_LevelPackItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_LevelPackItems");
     			}
     			return this.m_E_LevelPackItemsScrollRect;
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
			this.m_E_LevelPackItemsScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_LevelPackItemsScrollRect = null;
		public Transform uiTransform = null;
	}
}
