using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class Actor_SendReviveHandler : MessageLocationHandler<Unit, Actor_SendReviveRequest, Actor_SendReviveResponse>
    {
        protected override async ETTask Run(Unit unit, Actor_SendReviveRequest request, Actor_SendReviveResponse response)
        {
            MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            if (request.Revive)
            {
                string reviveCost = GlobalValueConfigCategory.Instance.Get(5).Value;
                bool success = unit.GetComponent<BagComponentS>().OnCostItemData(reviveCost);
                if (!success)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
                
                unit.SetBornPosition(unit.Position, true);
                unit.GetComponent<HeroDataComponentS>().OnRevive();
                unit.GetComponent<ChengJiuComponentS>().OnRevive();
            }
            else
            {
                switch (mapComponent.MapType)
                {
                    case MapTypeEnum.TeamDungeon:
                        TeamDungeonComponent teamDungeonComponent = unit.Scene().GetComponent<TeamDungeonComponent>();
                        unit.SetBornPosition(teamDungeonComponent.BossDeadPosition, true);
                        break;
                    case MapTypeEnum.DragonDungeon:
                        break;
                    default:
                        SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);

                        if (unit.GetBattleCamp() == CampEnum.CampPlayer_1)
                        {
                            unit.SetBornPosition(new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f), true);
                        }
                        else
                        {
                            unit.SetBornPosition(new float3(sceneConfig.InitPos[3] * 0.01f, sceneConfig.InitPos[4] * 0.01f, sceneConfig.InitPos[5] * 0.01f), true);
                        }
                        break;
                }
                unit.GetComponent<AttackRecordComponent>().ClearDamageList();
                unit.GetComponent<HeroDataComponentS>().OnRevive();
            }

            unit.TriggerTeamBuff(mapComponent.MapType);
            await ETTask.CompletedTask;
        }
    }
}
