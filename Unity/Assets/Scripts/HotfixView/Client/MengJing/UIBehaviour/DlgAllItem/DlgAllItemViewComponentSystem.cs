
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgAllItemViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgAllItemViewComponent))]
	public static partial class DlgAllItemViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgAllItemViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgAllItemViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
