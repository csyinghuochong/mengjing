
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetEggLucklyExplainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetEggLucklyExplainViewComponent))]
	public static partial class DlgPetEggLucklyExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetEggLucklyExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetEggLucklyExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
