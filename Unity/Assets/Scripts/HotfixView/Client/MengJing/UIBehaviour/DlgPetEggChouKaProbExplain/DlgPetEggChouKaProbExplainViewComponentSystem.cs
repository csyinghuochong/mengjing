
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetEggChouKaProbExplainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetEggChouKaProbExplainViewComponent))]
	public static partial class DlgPetEggChouKaProbExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetEggChouKaProbExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetEggChouKaProbExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
