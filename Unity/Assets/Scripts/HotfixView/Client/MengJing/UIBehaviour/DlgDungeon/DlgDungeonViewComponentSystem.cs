
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDungeonViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDungeonViewComponent))]
	public static partial class DlgDungeonViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDungeonViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDungeonViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
