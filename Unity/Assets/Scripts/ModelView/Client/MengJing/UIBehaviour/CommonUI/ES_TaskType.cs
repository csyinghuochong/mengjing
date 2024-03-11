
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskType : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public void DestroyWidget()
		{
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
