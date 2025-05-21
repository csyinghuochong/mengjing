
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPhoneCodeViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPhoneCodeViewComponent))]
	public static partial class DlgPhoneCodeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPhoneCodeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPhoneCodeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
