using UnityEngine;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_NewYearMonster : Entity,IAwake<Transform>,IDestroy 
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
