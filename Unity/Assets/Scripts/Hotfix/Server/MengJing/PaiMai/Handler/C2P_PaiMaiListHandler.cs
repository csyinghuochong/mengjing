﻿using System;
using System.Collections.Generic;

namespace ET
{
    [ActorMessageHandler]
    public class C2P_PaiMaiListHandler: AMActorRpcHandler<Scene, C2P_PaiMaiListRequest, P2C_PaiMaiListResponse>
    {
        protected override async ETTask Run(Scene scene, C2P_PaiMaiListRequest request, P2C_PaiMaiListResponse response, Action reply)
        {
            PaiMaiSceneComponent paiMaiComponent = scene.GetComponent<PaiMaiSceneComponent>();
            
            // 0自己 1-4道具分类
            if (request.PaiMaiType == 0) // 0自己的
            {
                List<PaiMaiItemInfo> paiMaiItemsTo = new List<PaiMaiItemInfo>();
                paiMaiItemsTo.AddRange(paiMaiComponent.GetItemListByUser(request.UserId, paiMaiComponent.dBPaiMainInfo_Consume.PaiMaiItemInfos ) );
                paiMaiItemsTo.AddRange(paiMaiComponent.GetItemListByUser(request.UserId, paiMaiComponent.dBPaiMainInfo_Material.PaiMaiItemInfos));
                paiMaiItemsTo.AddRange(paiMaiComponent.GetItemListByUser(request.UserId, paiMaiComponent.dBPaiMainInfo_Equipment.PaiMaiItemInfos));
                paiMaiItemsTo.AddRange(paiMaiComponent.GetItemListByUser(request.UserId, paiMaiComponent.dBPaiMainInfo_Gemstone.PaiMaiItemInfos));
                response.PaiMaiItemInfos = paiMaiItemsTo;
                reply();
                return;
            }
            else // 1-4道具
            {
                DBPaiMainInfo dBPaiMainInfo = paiMaiComponent.GetPaiMaiDBByType(request.PaiMaiType);
                if (dBPaiMainInfo == null)
                {
                    reply();
                    return;
                }

                List<PaiMaiItemInfo> paimaiListShow = dBPaiMainInfo.PaiMaiItemInfos;
                long nowTime = TimeHelper.ServerNow();

                // 拿到指定页数的物品
                int page = request.Page;
                int pagenum = int.Parse(GlobalValueConfigCategory.Instance.Get(104).Value); //每页的数量

                int maxpage = paimaiListShow.Count / pagenum;
                int extra = (paimaiListShow.Count % pagenum) > 0? 1 : 0;
                maxpage += extra;

                int startindex = (page - 1) * pagenum;
                if (startindex >= paimaiListShow.Count)
                {
                    startindex = paimaiListShow.Count - 1;
                }

                if (startindex < 0)
                {
                    startindex = 0;
                }

                //页数切换
                if (page >= maxpage)
                {
                    if (page == maxpage)
                    {
                        int getnumber = Math.Max(paimaiListShow.Count - startindex, 0);

                        response.PaiMaiItemInfos = paimaiListShow.GetRange(startindex, getnumber);
                        response.Message = "1"; //没有下一页
                        response.NextPage = maxpage;
                    }
                    else
                    {
                        if (paimaiListShow.Count > 0)
                        {
                            response.Error = ErrorCode.ERR_PaiMaiBuyMaxPage;
                        }
                    }
                }
                else
                {
                    int getnumber = Math.Min(paimaiListShow.Count - startindex, pagenum);
                    response.PaiMaiItemInfos = paimaiListShow.GetRange(startindex, getnumber);
                    response.Message = "0"; //有下一页
                    response.NextPage = maxpage;
                }
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}