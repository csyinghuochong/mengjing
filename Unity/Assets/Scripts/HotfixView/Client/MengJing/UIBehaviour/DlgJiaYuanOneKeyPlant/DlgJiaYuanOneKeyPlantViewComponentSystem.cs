
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanOneKeyPlantViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanOneKeyPlantViewComponent))]
	public static partial class DlgJiaYuanOneKeyPlantViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanOneKeyPlantViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanOneKeyPlantViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
