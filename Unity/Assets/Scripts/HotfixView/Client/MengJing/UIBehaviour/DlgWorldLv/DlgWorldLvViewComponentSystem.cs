
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWorldLvViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgWorldLvViewComponent))]
	public static partial class DlgWorldLvViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWorldLvViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWorldLvViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
