
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgButtonPositionSetViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgButtonPositionSetViewComponent))]
	public static partial class DlgButtonPositionSetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgButtonPositionSetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgButtonPositionSetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
