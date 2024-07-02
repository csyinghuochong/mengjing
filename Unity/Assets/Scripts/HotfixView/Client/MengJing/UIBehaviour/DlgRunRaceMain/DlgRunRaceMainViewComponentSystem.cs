
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRunRaceMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRunRaceMainViewComponent))]
	public static partial class DlgRunRaceMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRunRaceMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRunRaceMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
