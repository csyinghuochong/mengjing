
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDragonDungeonCreateViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDragonDungeonCreateViewComponent))]
	public static partial class DlgDragonDungeonCreateViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDragonDungeonCreateViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDragonDungeonCreateViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
