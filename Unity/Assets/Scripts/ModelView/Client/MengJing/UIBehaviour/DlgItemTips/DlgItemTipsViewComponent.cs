
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgItemTips))]
	[EnableMethod]
	public  class DlgItemTipsViewComponent : Entity,IAwake,IDestroy 
	{
		public void DestroyWidget()
		{
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
