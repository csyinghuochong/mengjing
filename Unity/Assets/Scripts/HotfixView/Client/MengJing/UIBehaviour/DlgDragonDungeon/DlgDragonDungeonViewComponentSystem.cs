
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDragonDungeonViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDragonDungeonViewComponent))]
	public static partial class DlgDragonDungeonViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDragonDungeonViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDragonDungeonViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
