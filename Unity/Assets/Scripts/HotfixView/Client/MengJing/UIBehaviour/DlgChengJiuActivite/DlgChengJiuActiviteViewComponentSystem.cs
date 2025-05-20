
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChengJiuActiviteViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgChengJiuActiviteViewComponent))]
	public static partial class DlgChengJiuActiviteViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChengJiuActiviteViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChengJiuActiviteViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
