
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCellDungeonEnterShow))]
	[EnableMethod]
	public  class DlgCellDungeonEnterShowViewComponent : Entity,IAwake,IDestroy 
	{
		public void DestroyWidget()
		{
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
