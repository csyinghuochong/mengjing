
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDamageValueViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDamageValueViewComponent))]
	public static partial class DlgDamageValueViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDamageValueViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDamageValueViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
