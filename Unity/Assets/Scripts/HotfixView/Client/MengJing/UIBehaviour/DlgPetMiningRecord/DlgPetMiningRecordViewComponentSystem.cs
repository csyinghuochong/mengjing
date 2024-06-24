
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMiningRecordViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMiningRecordViewComponent))]
	public static partial class DlgPetMiningRecordViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMiningRecordViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMiningRecordViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
