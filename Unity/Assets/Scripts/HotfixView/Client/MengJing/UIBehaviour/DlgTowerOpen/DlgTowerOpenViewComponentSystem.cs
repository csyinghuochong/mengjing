
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTowerOpenViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTowerOpenViewComponent))]
	public static partial class DlgTowerOpenViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTowerOpenViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTowerOpenViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
