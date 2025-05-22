
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WatchEquip : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public ES_EquipSet ES_EquipSet_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_EquipSet es = this.m_es_equipset_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_EquipSet_1");
		    	   this.m_es_equipset_1 = this.AddChild<ES_EquipSet,Transform>(subTrans);
     			}
     			return this.m_es_equipset_1;
     		}
     	}

		public ES_EquipSet ES_EquipSet_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_EquipSet es = this.m_es_equipset_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_EquipSet_2");
		    	   this.m_es_equipset_2 = this.AddChild<ES_EquipSet,Transform>(subTrans);
     			}
     			return this.m_es_equipset_2;
     		}
     	}

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
			this.m_es_equipset_1 = null;
			this.m_es_equipset_2 = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_EquipSet> m_es_equipset_1 = null;
		private EntityRef<ES_EquipSet> m_es_equipset_2 = null;
		public Transform uiTransform = null;
	}
}
