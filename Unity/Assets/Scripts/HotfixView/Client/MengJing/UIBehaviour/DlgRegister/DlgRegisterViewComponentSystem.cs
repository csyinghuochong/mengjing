
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRegisterViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRegisterViewComponent))]
	public static partial class DlgRegisterViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRegisterViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRegisterViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
