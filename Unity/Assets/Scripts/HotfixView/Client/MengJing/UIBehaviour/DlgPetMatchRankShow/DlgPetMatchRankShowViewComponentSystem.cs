
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMatchRankShowViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMatchRankShowViewComponent))]
	public static partial class DlgPetMatchRankShowViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMatchRankShowViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMatchRankShowViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
