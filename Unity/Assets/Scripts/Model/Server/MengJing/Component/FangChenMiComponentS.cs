

namespace ET.Server
{

    [ComponentOf(typeof(Scene))]
    public class FangChenMiComponentS : Entity, IAwake 
    {

        public bool IsHoliday{ get; set; }

        public bool StopServer { get; set; }
    }

}