
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_RoleHuiShou))]
	[FriendOfAttribute(typeof(ES_RoleHuiShou))]
	public static partial class ES_RoleHuiShouSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_RoleHuiShou self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_RoleHuiShou self)
		{
			self.DestroyWidget();
		}
	}


}
