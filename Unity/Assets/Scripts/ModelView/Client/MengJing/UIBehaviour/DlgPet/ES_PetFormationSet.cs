
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetFormationSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Action<long, int, int> DragEndHandler { get; set; } = null;
		public EntityRef<Scroll_Item_PetFormationItem>[] FormationItemComponents = new EntityRef<Scroll_Item_PetFormationItem>[9];
		
		public UnityEngine.UI.Image E_IconItemDragImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconItemDragImage == null )
     			{
		    		this.m_E_IconItemDragImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_IconItemDrag");
     			}
     			return this.m_E_IconItemDragImage;
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
			this.m_E_IconItemDragImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_IconItemDragImage = null;
		public Transform uiTransform = null;
	}
}
