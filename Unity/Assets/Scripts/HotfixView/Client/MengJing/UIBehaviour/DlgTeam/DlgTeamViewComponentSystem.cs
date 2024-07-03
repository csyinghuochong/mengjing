
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTeamViewComponent))]
	public static partial class DlgTeamViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
