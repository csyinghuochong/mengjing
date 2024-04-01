
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetHeChengExplainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetHeChengExplainViewComponent))]
	public static partial class DlgPetHeChengExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetHeChengExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetHeChengExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
