using System;
using System.Collections.Generic;
using ET.Client;
using UnityEngine;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public  class A2A_ActivityUpdateHandler : MessageHandler<Scene, A2A_ActivityUpdateRequest, A2A_ActivityUpdateResponse>
    {
        protected override async ETTask Run(Scene scene, A2A_ActivityUpdateRequest request, A2A_ActivityUpdateResponse response)
        {
            int hour = request.Hour;
            switch (scene.SceneType)
            {
                case SceneType.Gate:
                    Log.Warning($"Gate定时刷新: {scene.Zone()} {hour} ");
                    if (hour == 0)
                    {
                        PrintAllEntity();
                    }
                    Player[] players = scene.GetComponent<PlayerComponent>().GetAll();
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i].PlayerState != PlayerState.Game)
                        {
                            continue;
                        }
                       
                        scene.Root().GetComponent<MessageLocationSenderComponent>().Get( LocationType.Unit).Send(players[i].UnitId, new G2M_ActivityUpdate() { ActivityType = hour });
                    }

                    if (request.Hour >= 20 && scene.Zone() == 3)
                    {
                        Console.WriteLine("gongzuoshi3 0");
                        EventSystem.Instance.Publish(scene.Root(), new GMCommonRequest() { Context = "gongzuoshi3 0" });
                    }

                    if (request.Hour == 23 && scene.Zone() == 3)
                    {
                        //打印所有拍卖大于特定值
                        string command = "paimai2 0 50000000";
                        Console.WriteLine(command);
                        EventSystem.Instance.Publish(scene.Root(), new GMCommonRequest() { Context = command});

                        //清理今日拍卖
                        string filePath = "../Logs/WJ_PaiMai.txt";
                        LogHelper.WriteLogList(new List<string>() { "" }, filePath, false);

                        string filePath_2 = "../Logs/WJ_Chat.txt";
                        LogHelper.WriteLogList(new List<string>() { "" }, filePath_2, false);
                    }
                    if (request.Hour == 10 && scene.Zone() == 3)
                    {
                        //打印拍卖
                    }

                    break;
                case SceneType.Map:
                    //Log.Console($"{scene.Name}  {scene.DomainZone()}  request.FunctionType: {request.FunctionId} {request.FunctionType}");
                    if (request.FunctionId == 1057 && request.FunctionType == 1)
                    {
                        for (int npcid = 20099007; npcid <= 20099010; npcid++ )
                        {
                            UnitFactory.CreateNpc(scene, npcid);
                        }
                    }
                    if (request.FunctionId == 1057 && request.FunctionType == 2)
                    {
                        List<Unit> units = UnitHelper.GetUnitList( scene, UnitType.Npc );
                        for (int i = units.Count - 1; i >= 0; i--)
                        {
                            if (units[i].ConfigId >= 20099007 && units[i].ConfigId <= 20099010)
                            {
                                scene.GetComponent<UnitComponent>().Remove(units[i].Id);
                            }
                        }

                        for (int i = 0; i < ConfigData.TurtleList.Count; i++)
                        {
                            UnitFactory.CreateNpc(scene, ConfigHelper.ConfigData[i]);
                        }
                    }
                    break;
                case SceneType.Happy:
                    if (request.FunctionId == 1055 && request.FunctionType == 1)
                    {
                        scene.GetComponent<HappySceneComponent>().OnHappyBegin();
                    }
                    if (request.FunctionId == 1055 && request.FunctionType == 2)
                    {
                        scene.GetComponent<HappySceneComponent>().OnHappyOver();
                    }
                    break;
                case SceneType.Rank:
                    //Log.Console($"排行榜定时刷新: {scene.DomainZone()} {hour}");
                    Log.Warning($"排行榜定时刷新: {scene.Zone()} {hour}");
                    if (hour == 0)
                    {
                        scene.GetComponent<RankSceneComponent>().OnZeroClockUpdate();
                    }
                    if (hour == 12)
                    {
                        scene.GetComponent<RankSceneComponent>().OnHour12Update();
                    }
                    if (request.FunctionId == 1052 && request.FunctionType == 1)
                    {
                        //Log.Console("OnShowLieBegin");
                        Log.Warning("OnShowLieBegin");
                        scene.GetComponent<RankSceneComponent>().OnShowLieBegin();
                    }
                    if (request.FunctionId == 1052 && request.FunctionType == 2)
                    {
                        //Log.Console("OnShowLieOver");
                        Log.Warning("OnShowLieOver");
                        scene.GetComponent<RankSceneComponent>().OnShowLieOver().Coroutine();
                    }
                    if(request.FunctionId == 1044 && request.FunctionType == 2)
                    {
                        //Log.Console("RankSceneComponent.OnUnionRaceOver");
                        scene.GetComponent<RankSceneComponent>().OnUnionRaceOver().Coroutine();
                    }
                    if (request.FunctionId == 1059 && request.FunctionType == 2)
                    {
                        Log.Warning("RankSceneComponent.OnDemonOver");
                        scene.GetComponent<RankSceneComponent>().OnDemonOver().Coroutine();
                    }
                    break;
                case SceneType.Arena:
                    //Log.Console($"Arena定时刷新: {scene.DomainZone()} {hour}");
                    Log.Warning($"Arena定时刷新: {scene.Zone()} {hour}");
                    if (hour == 0)
                    {
                        scene.GetComponent<ArenaSceneComponent>().OnZeroClockUpdate();
                    }
                    break;
                case SceneType.Union:
                    //Log.Console($"Union定时刷新: {scene.DomainZone()} {hour}");
                    Log.Warning($"Union定时刷新: {scene.Zone()} {hour}");
                    if (hour == 0)
                    {
                        scene.GetComponent<UnionSceneComponent>().OnZeroClockUpdate();
                    }
                    if (request.FunctionId == 1043 && request.FunctionType == 1)
                    {
                        //Log.Console("OnUnionBoss");
                        scene.GetComponent<UnionSceneComponent>().OnUnionBoss();
                    }
                    if (request.FunctionId == 1044 && request.FunctionType == 1)
                    {
                        //Log.Console("OnUnionRaceBegin");
                        scene.GetComponent<UnionSceneComponent>().OnUnionRaceBegin().Coroutine();
                    }
                    if (request.FunctionId == 1044 && request.FunctionType == 2)
                    {
                        //Log.Console("UnionSceneComponent.OnUnionRaceOver");
                        //scene.GetComponent<UnionSceneComponent>().OnUnionRaceOver().Coroutine();
                    }
                    break;
                case SceneType.Battle:
                    //Log.Console($"Battle定时刷新: {scene.DomainZone()} {hour}");
                    Log.Warning($"Battle定时刷新: {scene.Zone()} {hour}");
                    if (hour == 0)
                    {
                        scene.GetComponent<BattleSceneComponent>().OnZeroClockUpdate();
                    }
                    if (request.FunctionId == 1025 && request.FunctionType == 1)
                    {
                        //Log.Console("OnBattleOpen");
                        scene.GetComponent<BattleSceneComponent>().OnBattleOpen();
                    }
                    if (request.FunctionId == 1025 && request.FunctionType == 2)
                    {
                        // Log.Console("OnBattleOver");
                        scene.GetComponent<BattleSceneComponent>().OnBattleOver().Coroutine();
                    }
                    break;
                case SceneType.PaiMai:
                    //更新快捷购买列表价格
                    //Log.Console($"PaiMai定时刷新: {scene.DomainZone()} {hour}");
                    Log.Warning($"PaiMai定时刷新: {scene.Zone()} {hour}");
                    if (hour == 0)
                    {
                        scene.GetComponent<PaiMaiSceneComponent>().OnZeroClockUpdate();
                    }
                    break;
                case SceneType.DBCache:
                    if (!ComHelperS.IsInnerNet())
                    {
                        scene.GetComponent<DBCacheComponent>().CheckUnitCacheList();
                    }
                    break;
                case SceneType.Solo:

                    if (request.FunctionId == 1045 && request.FunctionType == 1)
                    {
                        scene.GetComponent<SoloSceneComponent>().OnSoloBegin().Coroutine();
                    }
                    if (request.FunctionId == 1045 && request.FunctionType == 2)
                    {
                        scene.GetComponent<SoloSceneComponent>().OnSoloOver().Coroutine();
                    }
                    break;
                case SceneType.FubenCenter:
                    if (hour == 0)
                    {
                        //Log.Console($"FubenCenter定时刷新: {scene.DomainZone()} {hour}");
                        LogHelper.LogWarning($"FubenCenter定时刷新: {scene.DomainZone()} {hour}", true);
                        FubenCenterComponent fubenCenter = scene.GetComponent<FubenCenterComponent>();
                        foreach (var item in fubenCenter.Children)
                        {
                            item.Value.GetComponent<YeWaiRefreshComponent>().OnZeroClockUpdate(request.OpenDay);
                        }
                    }
                    if (request.FunctionId > 0 && request.FunctionType == 1)
                    {
                        //Log.Console($"GenarateFuben.{request.FunctionId}");
                        FubenCenterComponent fubenCenter = scene.GetComponent<FubenCenterComponent>();
                        fubenCenter.OnActivityOpen(request.FunctionId);
                    }
                    if (request.FunctionId > 0 && request.FunctionType == 2)
                    {
                        //Log.Console($"DisposeFuben.{request.FunctionId}");
                        FubenCenterComponent fubenCenter = scene.GetComponent<FubenCenterComponent>();
                        fubenCenter.OnActivityClose(request.FunctionId);
                    }
                    break;
                case SceneType.AccountCenter:
                    if (hour == 0)
                    {
                        scene.GetComponent<FangChenMiComponent>().CheckHoliday().Coroutine();
                    }

                    LogHelper.CheckLogSize();
                    break;
                default:
                    break;
            }

            reply();
            await ETTask.CompletedTask;
        }

        private void PrintAllEntity()
        {
            Log.Info("PrintAllEntity");
            Log.Info(EventSystem.Instance.ToString());
            Log.Info(ObjectPool.Instance.ToString());
        }
    }
}
