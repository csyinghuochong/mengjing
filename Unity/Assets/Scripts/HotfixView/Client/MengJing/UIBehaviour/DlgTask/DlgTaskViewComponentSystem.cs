
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTaskViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTaskViewComponent))]
	public static partial class DlgTaskViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTaskViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTaskViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
