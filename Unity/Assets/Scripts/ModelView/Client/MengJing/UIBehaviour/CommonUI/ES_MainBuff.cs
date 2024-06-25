
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainBuff : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public long Timer;
		public GameObject UIMainBuffItem;
		public List<UIMainBuffItemComponent> MainBuffUIList = new();
		public List<UIMainBuffItemComponent> CacheUIList = new();
		
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
