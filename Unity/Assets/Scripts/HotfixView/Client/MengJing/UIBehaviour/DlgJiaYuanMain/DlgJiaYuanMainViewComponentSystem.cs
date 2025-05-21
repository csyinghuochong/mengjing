
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanMainViewComponent))]
	public static partial class DlgJiaYuanMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
