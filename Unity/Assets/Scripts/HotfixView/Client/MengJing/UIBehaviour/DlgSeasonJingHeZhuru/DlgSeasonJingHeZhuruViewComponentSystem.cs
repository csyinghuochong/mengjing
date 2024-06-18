
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSeasonJingHeZhuruViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSeasonJingHeZhuruViewComponent))]
	public static partial class DlgSeasonJingHeZhuruViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSeasonJingHeZhuruViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSeasonJingHeZhuruViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
