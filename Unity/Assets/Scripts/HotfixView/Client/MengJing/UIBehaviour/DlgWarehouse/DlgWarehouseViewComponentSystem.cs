
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWarehouseViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgWarehouseViewComponent))]
	public static partial class DlgWarehouseViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWarehouseViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWarehouseViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
