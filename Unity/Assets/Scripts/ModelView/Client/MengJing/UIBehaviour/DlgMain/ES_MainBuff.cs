using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainBuff : Entity,IAwake<Transform>,IDestroy 
	{
		public long Timer;
		public GameObject UIMainBuffItem;
		public List<EntityRef<UIMainBuffItemComponent>> MainBuffUIList = new();
		public List<EntityRef<UIMainBuffItemComponent>> CacheUIList = new();
		
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
