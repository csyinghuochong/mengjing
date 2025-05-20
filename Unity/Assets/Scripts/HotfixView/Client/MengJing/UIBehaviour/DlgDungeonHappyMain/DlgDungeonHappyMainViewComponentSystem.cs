
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDungeonHappyMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDungeonHappyMainViewComponent))]
	public static partial class DlgDungeonHappyMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDungeonHappyMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDungeonHappyMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
