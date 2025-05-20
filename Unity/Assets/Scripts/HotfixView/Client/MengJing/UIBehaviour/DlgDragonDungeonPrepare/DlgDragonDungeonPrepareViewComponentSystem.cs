
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDragonDungeonPrepareViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDragonDungeonPrepareViewComponent))]
	public static partial class DlgDragonDungeonPrepareViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDragonDungeonPrepareViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDragonDungeonPrepareViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
