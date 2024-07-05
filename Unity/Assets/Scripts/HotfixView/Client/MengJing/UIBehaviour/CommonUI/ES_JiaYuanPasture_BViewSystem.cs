
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JiaYuanPasture_B))]
	[FriendOfAttribute(typeof(ES_JiaYuanPasture_B))]
	public static partial class ES_JiaYuanPasture_BSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JiaYuanPasture_B self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JiaYuanPasture_B self)
		{
			self.DestroyWidget();
		}
	}


}
