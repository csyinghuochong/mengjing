
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_RoleGemHole))]
	[FriendOfAttribute(typeof(ES_RoleGemHole))]
	public static partial class ES_RoleGemHoleSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_RoleGemHole self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_RoleGemHole self)
		{
			self.DestroyWidget();
		}
	}


}
