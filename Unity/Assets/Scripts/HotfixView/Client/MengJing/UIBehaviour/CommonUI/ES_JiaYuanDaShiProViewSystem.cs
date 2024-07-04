
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JiaYuanDaShiPro))]
	[FriendOfAttribute(typeof(ES_JiaYuanDaShiPro))]
	public static partial class ES_JiaYuanDaShiProSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JiaYuanDaShiPro self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JiaYuanDaShiPro self)
		{
			self.DestroyWidget();
		}
	}


}
