using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_PetMingBattleWinHandler : MessageHandler<Scene, M2A_PetMingBattleWinRequest, A2M_PetMingBattleWinResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_PetMingBattleWinRequest request, A2M_PetMingBattleWinResponse response)
        {
            long oldUnitid = 0;
            long serverTime = TimeHelper.ServerNow();

            List<PetMingPlayerInfo> petMingPlayerInfos = scene.GetComponent<ActivitySceneComponent>().DBDayActivityInfo.PetMingList;

            //移除改队伍之前占领
            for (int i = petMingPlayerInfos.Count - 1; i >= 0; i--)
            {
                if (petMingPlayerInfos[i].UnitId == request.UnitID
                 && petMingPlayerInfos[i].TeamId == request.TeamId)
                {
                    petMingPlayerInfos.RemoveAt(i);
                    break;
                }
            }

            for (int i = petMingPlayerInfos.Count - 1; i >= 0; i--)
            {
                if (petMingPlayerInfos[i].MineType == request.MingType
                 && petMingPlayerInfos[i].Postion == request.Postion)
                {
                    oldUnitid = petMingPlayerInfos[i].UnitId;
                    petMingPlayerInfos.RemoveAt(i);
                    break;
                }
            }
            if (request.UnitID != 0)
            {
                PetMingPlayerInfo PetMingPlayerInfo = PetMingPlayerInfo.Create();
                PetMingPlayerInfo.MineType = request.MingType;
                PetMingPlayerInfo.Postion = request.Postion;
                PetMingPlayerInfo.UnitId = request.UnitID;
                PetMingPlayerInfo.TeamId = request.TeamId;
                PetMingPlayerInfo.OccupyTime = serverTime;
                petMingPlayerInfos.Add(PetMingPlayerInfo);
            }

            if (oldUnitid != 0)
            {
                PetMingRecord petMingRecord = PetMingRecord.Create();
                petMingRecord.UnitID = request.UnitID;
                petMingRecord.Position = request.Postion;
                petMingRecord.MineType = request.MingType;
                petMingRecord.Time = serverTime;
                petMingRecord.WinPlayer = request.WinPlayer;    

                //通知玩家
                //long gateServerId = DBHelper.GetGateServerId(scene.DomainZone());
                //G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await ActorMessageSenderComponent.Instance.Call
                //   (gateServerId, new T2G_GateUnitInfoRequest()
                //   {
                //       UserID = oldUnitid
                //   });
                //if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                //{
                   
                //}
                //else
                //{
                    
                //}
                A2M_PetMingRecordRequest a2M_PetMing = A2M_PetMingRecordRequest.Create();
                a2M_PetMing.UnitID = oldUnitid;
                a2M_PetMing.PetMingRecord = petMingRecord;
                
                // root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitId, actorLocationMessage);
                M2A_PetMingRecordResponse m2G_RechargeResponse =  (M2A_PetMingRecordResponse) await scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(oldUnitid, a2M_PetMing);
                if (m2G_RechargeResponse.Error != ErrorCode.ERR_Success)
                {
                    ActorId dbCacheId = UnitCacheHelper.GetDbCacheId(scene.Zone());
                    PetComponentS petComponent = await UnitCacheHelper.GetComponentCache<PetComponentS>(scene.Root(), oldUnitid);
                    petComponent.OnPetMingRecord(petMingRecord);
                    await UnitCacheHelper.SaveComponentCache(scene.Root(), petComponent);
                    
                    ReddotComponentS roReddotComponentS = await UnitCacheHelper.GetComponentCache<ReddotComponentS>(scene.Root(), oldUnitid);
                    roReddotComponentS.AddReddont((int)ReddotType.PetMine);
                    await UnitCacheHelper.SaveComponentCache(scene.Root(), roReddotComponentS);
                    
                    NumericComponentS numericComponentS = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), oldUnitid);
                    numericComponentS.ApplyValue( NumericType.PetMineCDTime, 0, false );
                    await UnitCacheHelper.SaveComponentCache(scene.Root(), numericComponentS);
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
