
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
