
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionRoleXiuLian))]
	[FriendOfAttribute(typeof(ES_UnionRoleXiuLian))]
	public static partial class ES_UnionRoleXiuLianSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionRoleXiuLian self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionRoleXiuLian self)
		{
			self.DestroyWidget();
		}
	}


}
