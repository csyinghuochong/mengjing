
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTuZhiMakeViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTuZhiMakeViewComponent))]
	public static partial class DlgTuZhiMakeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTuZhiMakeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTuZhiMakeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
