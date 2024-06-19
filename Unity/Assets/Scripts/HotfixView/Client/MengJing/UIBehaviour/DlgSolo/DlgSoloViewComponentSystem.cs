
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSoloViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSoloViewComponent))]
	public static partial class DlgSoloViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSoloViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSoloViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
