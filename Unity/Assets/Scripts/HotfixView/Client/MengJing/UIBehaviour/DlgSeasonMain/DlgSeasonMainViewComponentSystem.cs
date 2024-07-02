
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSeasonMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSeasonMainViewComponent))]
	public static partial class DlgSeasonMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSeasonMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSeasonMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
