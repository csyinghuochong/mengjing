
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellDungeonReviveViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCellDungeonReviveViewComponent))]
	public static partial class DlgCellDungeonReviveViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellDungeonReviveViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellDungeonReviveViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
