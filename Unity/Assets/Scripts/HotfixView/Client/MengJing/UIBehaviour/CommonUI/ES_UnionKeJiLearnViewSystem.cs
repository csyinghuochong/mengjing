
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionKeJiLearn))]
	[FriendOfAttribute(typeof(ES_UnionKeJiLearn))]
	public static partial class ES_UnionKeJiLearnSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionKeJiLearn self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionKeJiLearn self)
		{
			self.DestroyWidget();
		}
	}


}
