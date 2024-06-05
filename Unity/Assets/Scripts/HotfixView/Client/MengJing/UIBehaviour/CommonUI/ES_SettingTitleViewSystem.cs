
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SettingTitle))]
	[FriendOfAttribute(typeof(ES_SettingTitle))]
	public static partial class ES_SettingTitleSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SettingTitle self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SettingTitle self)
		{
			self.DestroyWidget();
		}
	}


}
