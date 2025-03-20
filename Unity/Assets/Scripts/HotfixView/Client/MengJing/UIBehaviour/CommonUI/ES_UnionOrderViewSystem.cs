
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionOrder))]
	[FriendOfAttribute(typeof(ES_UnionOrder))]
	public static partial class ES_UnionOrderSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionOrder self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionOrder self)
		{
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this ES_UnionOrder self)
		{
			
		}
	}


}
