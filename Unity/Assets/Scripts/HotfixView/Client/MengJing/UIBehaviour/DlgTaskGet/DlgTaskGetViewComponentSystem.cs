
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTaskGetViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTaskGetViewComponent))]
	public static partial class DlgTaskGetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTaskGetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTaskGetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
