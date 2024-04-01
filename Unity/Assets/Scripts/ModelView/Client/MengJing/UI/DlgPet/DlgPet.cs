namespace ET.Client
{
    public enum PetOperationType
    {
        HeCheng = 1,
        XiLian = 2,
        UpStar_Main = 3,
        UpStar_FuZh = 4,
        RankPet_Team = 5,
        XianJi = 6,
        JiaYuan_Walk = 7,
    }

    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPet: Entity, IAwake, IUILogic
    {
        public DlgPetViewComponent View
        {
            get => this.GetComponent<DlgPetViewComponent>();
        }

        public int PetItemWeizhi; //-1左 1 右边
    }
}