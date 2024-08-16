
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTowerOfSealCostViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTowerOfSealCostViewComponent))]
	public static partial class DlgTowerOfSealCostViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTowerOfSealCostViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTowerOfSealCostViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
