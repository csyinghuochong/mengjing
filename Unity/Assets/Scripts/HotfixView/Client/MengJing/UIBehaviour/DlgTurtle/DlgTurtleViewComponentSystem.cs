
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTurtleViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTurtleViewComponent))]
	public static partial class DlgTurtleViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTurtleViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTurtleViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
