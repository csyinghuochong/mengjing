using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_UnionOperationHandler : MessageHandler<Scene, M2U_UnionOperationRequest, U2M_UnionOperationResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionOperationRequest request, U2M_UnionOperationResponse response)
        {
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnionOperate, request.UnionId))
            {
                DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
                if (dBUnionInfo == null)
                {
                    response.Error = ErrorCode.ERR_Union_Not_Exist;
                    return;
                }
               
                switch (request.OperateType)
                {
                    case 1:
                        //Par = $"{getWay}_{dataType}_{dataValue}_{playerName or params}
                        UnionConfig unionConfig = null;
                        string[] valuePararm = request.Par.Split('_');
                        int addExp = int.Parse(valuePararm[2]);
                        if (valuePararm[1] == "17") // UserDataType.UnionExp
                        {
                            //增加经验
                            if (dBUnionInfo.UnionInfo.Level == 0)
                            {
                                dBUnionInfo.UnionInfo.Level = 1;
                            }
                            dBUnionInfo.UnionInfo.Exp += addExp;
                            
                            dBUnionInfo.UnionInfo.ActiveRecord.Add($"{request.Par} 为公会增加经验 {addExp}");
                        }
                        else if (valuePararm[1] == "35") //UserDataType.UnionGold
                        {
                            unionConfig = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                            dBUnionInfo.UnionInfo.UnionGold += addExp;
                            dBUnionInfo.UnionInfo.UnionGold = Math.Min(unionConfig.UnionGoldLimit, dBUnionInfo.UnionInfo.UnionGold);
                            
                            dBUnionInfo.UnionInfo.ActiveRecord.Add($"{request.Par} 为公会增加资金 {addExp}");
                        }
                        else
                        {
                            return;
                        }
                        
                        if (dBUnionInfo.UnionInfo.ActiveRecord.Count >= 100)
                        {
                            dBUnionInfo.UnionInfo.ActiveRecord.RemoveAt(0);
                        }

                        await  UnitCacheHelper.SaveComponent(scene.Root(),dBUnionInfo.Id,  dBUnionInfo);
                        break;
                    case 2:  //获取等级
                        response.Par = dBUnionInfo.UnionInfo.Level.ToString();
                        break;
                    case 3:  //金币捐献
                        dBUnionInfo.UnionInfo.Level = Math.Max(dBUnionInfo.UnionInfo.Level, 1);
                        response.Par = dBUnionInfo.UnionInfo.Level.ToString();
                        unionConfig = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                        long selfgold = long.Parse(request.Par);
                        if (selfgold < unionConfig.DonateGold)
                        {
                            response.Error = ErrorCode.ERR_GoldNotEnoughError;
                            return;
                        }
                        if (dBUnionInfo.UnionInfo.DonationRecords.Count >= 100)
                        {
                            dBUnionInfo.UnionInfo.DonationRecords.RemoveAt(0);
                        }

                        DonationRecord DonationRecord = DonationRecord.Create();
                        DonationRecord.Gold = unionConfig.DonateGold;
                        DonationRecord.Time = TimeHelper.ServerNow();
                        DonationRecord.UnitId = request.UnitId;
                        dBUnionInfo.UnionInfo.DonationRecords.Add( DonationRecord);
                        await  UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo);
                        break;
                    case 4: //钻石捐献
                        dBUnionInfo.UnionInfo.Level = Math.Max(dBUnionInfo.UnionInfo.Level, 1);
                        response.Par = dBUnionInfo.UnionInfo.Level.ToString();
                        unionConfig = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                        long selfDiamond = long.Parse(request.Par);
                        if (selfDiamond < unionConfig.DonateDiamond)
                        {
                            response.Error = ErrorCode.ERR_DiamondNotEnoughError;

                            return;
                        }
                        if (dBUnionInfo.UnionInfo.DonationRecords.Count >= 100)
                        {
                            dBUnionInfo.UnionInfo.DonationRecords.RemoveAt(0);
                        }

                        DonationRecord = DonationRecord.Create();
                        DonationRecord.Diamond = unionConfig.DonateDiamond;
                        DonationRecord.Time = TimeHelper.ServerNow();
                        DonationRecord.UnitId = request.UnitId;
                        dBUnionInfo.UnionInfo.DonationRecords.Add(DonationRecord);
                        await UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo);
                        break;
                    case 5: //增加金币
                        dBUnionInfo.UnionInfo.UnionGold += int.Parse(request.Par);
                        await UnitCacheHelper.SaveComponent(scene.Root(),dBUnionInfo.Id,  dBUnionInfo);
                        break;
                    default:
                        break;
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
