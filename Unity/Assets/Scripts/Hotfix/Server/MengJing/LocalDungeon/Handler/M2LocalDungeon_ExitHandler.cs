using System;

namespace ET.Server
{
    [MessageHandler(SceneType.LocalDungeon)]
    public class M2LocalDungeon_ExitHandler: MessageHandler<Scene, M2LocalDungeon_ExitRequest, LocalDungeon2M_ExitResponse>
    {

        private async ETTask CloseBattleFubenScene(Scene fubenscene, M2LocalDungeon_ExitRequest request)
        {
            //Console.WriteLine($"M2LocalDungeon_Exit:  {fubenscene.Name}  {request.Camp1Player.Count}  {request.Camp2Player.Count}   {fubenscene.DomainZone()} ");
            fubenscene.GetComponent<BattleDungeonComponent>().OnBattleOver(request.Camp1Player, request.Camp2Player);
            await fubenscene.GetComponent<BattleDungeonComponent>().KickOutPlayer();
            await fubenscene.Root().GetComponent<TimerComponent>().WaitAsync(60000 + RandomHelper.RandomNumber(0, 1000));
            TransferHelper.NoticeFubenCenter(fubenscene, 2).Coroutine();
            fubenscene.Dispose();
        }

        protected override async ETTask Run(Scene scene, M2LocalDungeon_ExitRequest request, LocalDungeon2M_ExitResponse response)
        {
            switch (request.SceneType)
            {
                case SceneTypeEnum.Battle:
                    Scene fubenscene = scene.GetChild<Scene>(request.FubenId);
                    CloseBattleFubenScene(fubenscene, request).Coroutine();
                    break;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
