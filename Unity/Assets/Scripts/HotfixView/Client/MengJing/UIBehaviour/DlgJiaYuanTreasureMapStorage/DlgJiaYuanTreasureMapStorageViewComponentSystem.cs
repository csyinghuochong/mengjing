
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanTreasureMapStorageViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanTreasureMapStorageViewComponent))]
	public static partial class DlgJiaYuanTreasureMapStorageViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanTreasureMapStorageViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanTreasureMapStorageViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
