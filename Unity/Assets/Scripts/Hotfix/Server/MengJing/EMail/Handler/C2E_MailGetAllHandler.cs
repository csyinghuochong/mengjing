﻿using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.EMail)]
    public class C2E_MailGetAllHandler : MessageHandler<Scene, C2E_GetAllMailRequest, E2C_GetAllMailResponse>
    {
        protected override async ETTask Run(Scene scene, C2E_GetAllMailRequest request, E2C_GetAllMailResponse response )
        {
            long dbCacheId = DBHelper.GetDbCacheId(scene.DomainZone());
            D2G_GetComponent d2GGetUnit = (D2G_GetComponent)await ActorMessageSenderComponent.Instance.Call(dbCacheId, new G2D_GetComponent() { UnitId = request.ActorId, Component = DBHelper.DBMailInfo });
            if (d2GGetUnit.Component != null)
            {
                DBMailInfo dBMailInfo = d2GGetUnit.Component as DBMailInfo;

                for(int i = 0; i < dBMailInfo.MailInfoList.Count; i++)
                {
                    for (int item = 0; item < dBMailInfo.MailInfoList[i].ItemList.Count; item++)
                    {
                        if (dBMailInfo.MailInfoList[i].ItemList[item].ItemID == 110000164)
                        {
                            dBMailInfo.MailInfoList[i].ItemList[item].ItemID = 10000164;
                        }
                    }
                }
                
                response.MailInfos = dBMailInfo.MailInfoList;
            }
            reply();
        }

    }
}
