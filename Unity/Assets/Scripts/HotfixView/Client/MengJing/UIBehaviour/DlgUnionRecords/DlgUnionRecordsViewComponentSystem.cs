
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionRecordsViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionRecordsViewComponent))]
	public static partial class DlgUnionRecordsViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionRecordsViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionRecordsViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
