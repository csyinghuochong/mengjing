namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class ChuansongComponent : Entity, IAwake
    {
        public bool Triggered { get; set; }

        public bool ChuanSongOpen { get; set; }
    }
}