
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CellDungeonCellMini : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public GameObject cellContainer;
		public CellDungeonInfo[] fubenCellInfos = new CellDungeonInfo[9];
		public EntityRef<Scroll_Item_CellDungeonCellItem>[] fubenCellUIs = new EntityRef<Scroll_Item_CellDungeonCellItem>[9];
		public long Timer;
		
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
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
