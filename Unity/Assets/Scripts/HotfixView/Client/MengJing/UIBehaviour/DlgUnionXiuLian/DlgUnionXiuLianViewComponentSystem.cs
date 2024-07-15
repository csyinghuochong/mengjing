
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionXiuLianViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionXiuLianViewComponent))]
	public static partial class DlgUnionXiuLianViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionXiuLianViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionXiuLianViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
