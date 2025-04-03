namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleeGetMyCardsHandler : MessageLocationHandler<Unit, C2M_PetMeleeGetMyCards, M2C_PetMeleeGetMyCards>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeGetMyCards request, M2C_PetMeleeGetMyCards response)
        {
            // 当掉线重新连接了，可以发送这个消息拿到当前的卡牌
            // 重连成功，派发事件， 各自的模块去处理。。

            switch (request.MapType)
            {
                case MapTypeEnum.PetMelee:
                case MapTypeEnum.PetMatch:
                    PetMeleeDungeonComponent petMeleeDungeonComponent = unit.Scene().GetComponent<PetMeleeDungeonComponent>();
                    if (petMeleeDungeonComponent != null)
                    {
                        response.PetMeleeCardList.AddRange(petMeleeDungeonComponent.PetMeleeCardInHand[unit.Id]);
                    }
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}