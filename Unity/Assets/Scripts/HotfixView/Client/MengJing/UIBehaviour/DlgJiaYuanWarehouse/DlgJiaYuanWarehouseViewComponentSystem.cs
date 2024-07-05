
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanWarehouseViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanWarehouseViewComponent))]
	public static partial class DlgJiaYuanWarehouseViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanWarehouseViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanWarehouseViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
