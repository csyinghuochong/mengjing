
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JiaYuanCookbook))]
	[FriendOfAttribute(typeof(ES_JiaYuanCookbook))]
	public static partial class ES_JiaYuanCookbookSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JiaYuanCookbook self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JiaYuanCookbook self)
		{
			self.DestroyWidget();
		}
	}


}
