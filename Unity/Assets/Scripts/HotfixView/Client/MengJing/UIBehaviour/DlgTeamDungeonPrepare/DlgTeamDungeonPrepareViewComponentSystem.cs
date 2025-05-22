
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamDungeonPrepareViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTeamDungeonPrepareViewComponent))]
	public static partial class DlgTeamDungeonPrepareViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamDungeonPrepareViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamDungeonPrepareViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
