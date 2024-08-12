
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionJingXuanViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionJingXuanViewComponent))]
	public static partial class DlgUnionJingXuanViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionJingXuanViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionJingXuanViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
