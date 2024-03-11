
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskDetail : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public ES_TaskType ES_TaskType_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_tasktype_0 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/TypeListNode/ES_TaskType_0");
		    	   this.m_es_tasktype_0 = this.AddChild<ES_TaskType,Transform>(subTrans);
     			}
     			return this.m_es_tasktype_0;
     		}
     	}

		public ES_TaskType ES_TaskType_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_tasktype_1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/TypeListNode/ES_TaskType_1");
		    	   this.m_es_tasktype_1 = this.AddChild<ES_TaskType,Transform>(subTrans);
     			}
     			return this.m_es_tasktype_1;
     		}
     	}

		public ES_TaskType ES_TaskType_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_tasktype_2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/TypeListNode/ES_TaskType_2");
		    	   this.m_es_tasktype_2 = this.AddChild<ES_TaskType,Transform>(subTrans);
     			}
     			return this.m_es_tasktype_2;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_tasktype_0 = null;
			this.m_es_tasktype_1 = null;
			this.m_es_tasktype_2 = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_TaskType> m_es_tasktype_0 = null;
		private EntityRef<ES_TaskType> m_es_tasktype_1 = null;
		private EntityRef<ES_TaskType> m_es_tasktype_2 = null;
		public Transform uiTransform = null;
	}
}
