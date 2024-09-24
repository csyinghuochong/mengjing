
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgFunctionViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgFunctionViewComponent))]
	public static partial class DlgFunctionViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgFunctionViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgFunctionViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
