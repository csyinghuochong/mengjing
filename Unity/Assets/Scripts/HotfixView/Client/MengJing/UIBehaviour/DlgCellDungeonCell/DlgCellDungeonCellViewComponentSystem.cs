
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellDungeonCellViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCellDungeonCellViewComponent))]
	public static partial class DlgCellDungeonCellViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellDungeonCellViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellDungeonCellViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
