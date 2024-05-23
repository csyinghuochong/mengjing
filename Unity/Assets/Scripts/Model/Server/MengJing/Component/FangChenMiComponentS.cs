

namespace ET.Server
{

    [ComponentOf(typeof(Scene))]
    public class FangChenMiComponentS : Entity, IAwake 
    {

        public bool IsHoliday;

        public bool StopServer;
    }

}