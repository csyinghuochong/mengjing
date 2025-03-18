
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionViewComponent))]
	public static partial class DlgUnionViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
