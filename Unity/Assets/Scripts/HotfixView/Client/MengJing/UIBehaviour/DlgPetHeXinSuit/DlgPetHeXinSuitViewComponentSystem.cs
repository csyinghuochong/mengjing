
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetHeXinSuitViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetHeXinSuitViewComponent))]
	public static partial class DlgPetHeXinSuitViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetHeXinSuitViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetHeXinSuitViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
