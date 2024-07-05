
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JiaYuanPasture_A))]
	[FriendOfAttribute(typeof(ES_JiaYuanPasture_A))]
	public static partial class ES_JiaYuanPasture_ASystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JiaYuanPasture_A self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JiaYuanPasture_A self)
		{
			self.DestroyWidget();
		}
	}


}
