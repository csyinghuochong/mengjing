
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionKeJiViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionKeJiViewComponent))]
	public static partial class DlgUnionKeJiViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionKeJiViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionKeJiViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
