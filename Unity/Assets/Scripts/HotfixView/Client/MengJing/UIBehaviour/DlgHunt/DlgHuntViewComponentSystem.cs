
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgHuntViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgHuntViewComponent))]
	public static partial class DlgHuntViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgHuntViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgHuntViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
