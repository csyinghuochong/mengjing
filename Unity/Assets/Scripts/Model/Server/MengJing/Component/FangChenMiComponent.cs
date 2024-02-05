

namespace ET.Server
{

    [ComponentOf(typeof(Scene))]
    public class FangChenMiComponent : Entity, IAwake 
    {

        public bool IsHoliday;

        public bool StopServer;
    }

}