
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellDungeonEnterShowViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCellDungeonEnterShowViewComponent))]
	public static partial class DlgCellDungeonEnterShowViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellDungeonEnterShowViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellDungeonEnterShowViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
