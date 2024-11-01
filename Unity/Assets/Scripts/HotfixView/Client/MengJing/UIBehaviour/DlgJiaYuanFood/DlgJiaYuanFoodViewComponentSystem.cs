
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanFoodViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanFoodViewComponent))]
	public static partial class DlgJiaYuanFoodViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanFoodViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanFoodViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
