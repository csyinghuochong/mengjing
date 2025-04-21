
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSingleHappyMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSingleHappyMainViewComponent))]
	public static partial class DlgSingleHappyMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSingleHappyMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSingleHappyMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
