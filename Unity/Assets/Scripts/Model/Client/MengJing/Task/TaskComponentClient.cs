using System.Collections.Generic;

namespace ET.Client
{
    // �ͻ��˹���ClientScene�ϣ�����˹���Unit��
    [ComponentOf(typeof(Scene))]
    public class TaskComponentClient : Entity, IAwake, IDestroy
    {
        public List<int> ReceiveHuoYueIds = new List<int>();
        public List<TaskPro> TaskCountryList = new List<TaskPro>();
        public List<TaskPro> RoleTaskList = new List<TaskPro>();
        public List<int> RoleComoleteTaskList = new List<int>();
    }
}