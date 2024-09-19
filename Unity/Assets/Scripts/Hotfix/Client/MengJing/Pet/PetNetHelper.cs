using System.Collections.Generic;

namespace ET.Client
{
    public static class PetNetHelper
    {
        public static async ETTask RequestPetInfo(Scene root)
        {
            M2C_RolePetList response = (M2C_RolePetList)await root.GetComponent<ClientSenderCompnent>().Call(C2M_RolePetList.Create());

            root.GetComponent<PetComponentC>().RequestAllPets(response);
        }

        public static async ETTask<int> RequestPetMingChanChu(Scene root)
        {
            C2A_PetMingChanChuRequest request = C2A_PetMingChanChuRequest.Create();

            A2C_PetMingChanChuResponse respone = (A2C_PetMingChanChuResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return respone.Error;
        }

        public static async ETTask<A2C_PetMingListResponse> RequestPetMingList(Scene root)
        {
            C2A_PetMingListRequest request = C2A_PetMingListRequest.Create();

            A2C_PetMingListResponse response = (A2C_PetMingListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> RequestPetFubenReward(Scene root)
        {
            C2M_PetFubenRewardRequest request = C2M_PetFubenRewardRequest.Create();

            M2C_PetFubenRewardResponse response = (M2C_PetFubenRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestPetFightSwitch(Scene root, int fightindex)
        {
            C2M_PetFightSwitch c2MPetFightSwitch = C2M_PetFightSwitch.Create();
            c2MPetFightSwitch.PetFightIndex = fightindex;
            M2C_PetFightSwitch m2CPetFightSwitch =   (M2C_PetFightSwitch)await root.GetComponent<ClientSenderCompnent>().Call(c2MPetFightSwitch);
            return m2CPetFightSwitch.Error;
        }

        public static async ETTask<int> RequestPetFight(Scene root, long petId, int fight)
        {
            C2M_RolePetFight request = C2M_RolePetFight.Create();
            request.PetInfoId = petId;
            request.PetStatus = fight;

            M2C_RolePetFight response = (M2C_RolePetFight)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RequestPetFight(petId, fight);
                EventSystem.Instance.Publish(root, new OnPetFightSet());
            }

            return response.Error;
        }

        public static async ETTask<int> RequestUpStar(Scene root, long mainId, List<long> costIds)
        {
            C2M_RolePetUpStar request = C2M_RolePetUpStar.Create();
            request.PetInfoId = mainId;
            request.CostPetInfoIds = costIds;

            M2C_RolePetUpStar response = (M2C_RolePetUpStar)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RequestUpStar(mainId, costIds, response.rolePetInfo);
            }

            return response.Error;
        }

        public static async ETTask RequestFenJie(Scene root, long petId)
        {
            C2M_RolePetFenjie request = C2M_RolePetFenjie.Create();
            request.PetInfoId = petId;

            M2C_RolePetFenjie response = (M2C_RolePetFenjie)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RemovePet(petId);
            }

            EventSystem.Instance.Publish(root, new PetFenJieUpdate());
        }

        public static async ETTask<M2C_RolePetXiLian> RequestXiLian(Scene root, long bagInfoID, long petInfoId, int costItemNum = 0,
        string paramInfo = null)
        {
            C2M_RolePetXiLian request = C2M_RolePetXiLian.Create();
            request.BagInfoID = bagInfoID;
            request.PetInfoId = petInfoId;
            request.CostItemNum = costItemNum;
            request.ParamInfo = paramInfo;

            M2C_RolePetXiLian response = (M2C_RolePetXiLian)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RequestXiLian(bagInfoID, petInfoId, response.rolePetInfo);
            }

            HintHelp.ShowHint(root, "道具在宠物身上发生了作用！");
            EventSystem.Instance.Publish(root, new PetXiLianUpdate());

            return response;
        }

        public static async ETTask<int> RequestChangePos(Scene root, int index1, int index2)
        {
            C2M_PetChangePosRequest request = C2M_PetChangePosRequest.Create();
            request.Index1 = index1;
            request.Index2 = index2;

            M2C_PetChangePosResponse response = (M2C_PetChangePosResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<RolePetInfo> RequestRolePetHeXin(Scene root, int operateType, long bagInfoId, long PetInfoId, int position)
        {
            C2M_RolePetHeXin request = C2M_RolePetHeXin.Create();
            request.OperateType = operateType;
            request.BagInfoId = bagInfoId;
            request.PetInfoId = PetInfoId;
            request.Position = position;

            M2C_RolePetHeXin response = (M2C_RolePetHeXin)await root.GetComponent<ClientSenderCompnent>().Call(request);
            root.GetComponent<PetComponentC>().OnRolePetUpdate(response.RolePetInfo);
            return response.RolePetInfo;
        }

        public static async ETTask<int> RequestPetHeXinHeCheng(Scene root, long bagInfoID_1, long bagInfoID_2)
        {
            C2M_PetHeXinHeChengRequest request = C2M_PetHeXinHeChengRequest.Create();
            request.BagInfoID_1 = bagInfoID_1;
            request.BagInfoID_2 = bagInfoID_2;

            M2C_PetHeXinHeChengResponse response = (M2C_PetHeXinHeChengResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestPetHeXinHeChengQuick(Scene root)
        {
            C2M_PetHeXinHeChengQuickRequest request = C2M_PetHeXinHeChengQuickRequest.Create();

            M2C_PetHeXinHeChengQuickResponse response =
                    (M2C_PetHeXinHeChengQuickResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<RolePetInfo> RequestRolePetJiadian(Scene root, long petInfoId, List<int> addPropretyValue)
        {
            C2M_RolePetJiadian request = C2M_RolePetJiadian.Create();
            request.PetInfoId = petInfoId;
            request.AddPropretyValue = addPropretyValue;

            M2C_RolePetJiadian response = (M2C_RolePetJiadian)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<PetComponentC>().OnRolePetUpdate(response.RolePetInfo);

            return response.RolePetInfo;
        }

        public static async ETTask<int> RequestRolePetRName(Scene root, long petInfoId, string petName)
        {
            C2M_RolePetRName request = C2M_RolePetRName.Create();
            request.PetInfoId = petInfoId;
            request.PetName = petName;

            M2C_RolePetRName response = (M2C_RolePetRName)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_RolePetHeCheng> RequestRolePetHeCheng(Scene root, long petInfoId1, long petInfoId2)
        {
            C2M_RolePetHeCheng request = C2M_RolePetHeCheng.Create();
            request.PetInfoId1 = petInfoId1;
            request.PetInfoId2 = petInfoId2;

            M2C_RolePetHeCheng response = (M2C_RolePetHeCheng)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == 0 && response.rolePetInfo != null)
            {
                root.GetComponent<PetComponentC>().OnRecvHeCheng(response);
            }

            return response;
        }

        public static async ETTask<int> RequestPetShouHuActive(Scene root, int petShouHuActive)
        {
            C2M_PetShouHuActiveRequest request = C2M_PetShouHuActiveRequest.Create();
            request.PetShouHuActive = petShouHuActive;

            M2C_PetShouHuActiveResponse response = (M2C_PetShouHuActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            root.GetComponent<PetComponentC>().PetShouHuActive = response.PetShouHuActive;

            return response.Error;
        }

        public static async ETTask<int> RequestPetShouHu(Scene root, long petInfoId, int position)
        {
            C2M_PetShouHuRequest request = C2M_PetShouHuRequest.Create();
            request.PetInfoId = petInfoId;
            request.Position = position;

            M2C_PetShouHuResponse response = (M2C_PetShouHuResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            root.GetComponent<PetComponentC>().PetShouHuList = response.PetShouHuList;

            return response.Error;
        }

        public static async ETTask<int> RequestPetEggPut(Scene root, int index, long bagInfoID)
        {
            C2M_RolePetEggPut request = C2M_RolePetEggPut.Create();
            request.Index = index;
            request.BagInfoId = bagInfoID;

            M2C_RolePetEggPut response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_RolePetEggPut;

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            petComponent.RolePetEggs[index] = response.RolePetEgg;

            return response.Error;
        }

        public static async ETTask<int> RequestPetEggPutOut(Scene root, int index)
        {
            C2M_RolePetEggPutOut request = C2M_RolePetEggPutOut.Create();
            request.Index = index;

            M2C_RolePetEggPutOut response = (M2C_RolePetEggPutOut)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            petComponent.RolePetEggs[index] = response.RolePetEgg;

            return response.Error;
        }

        public static async ETTask<int> RequestPetEggHatch(Scene root, int index)
        {
            C2M_RolePetEggHatch request = C2M_RolePetEggHatch.Create();
            request.Index = index;

            M2C_RolePetEggHatch response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_RolePetEggHatch;

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            petComponent.RolePetEggs[index] = response.RolePetEgg;

            return response.Error;
        }

        public static async ETTask<int> RequestPetEggOpen(Scene root, int index)
        {
            C2M_RolePetEggOpen request = C2M_RolePetEggOpen.Create();
            request.Index = index;

            M2C_RolePetEggOpen response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_RolePetEggOpen;

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            petComponent.RolePetEggs[index].KeyId = 0;
            petComponent.RolePetEggs[index].Value = 0;

            return response.Error;
        }

        public static async ETTask<M2C_PetEggDuiHuanResponse> RequestPetEggDuiHuan(Scene root, int index)
        {
            C2M_PetEggDuiHuanRequest request = C2M_PetEggDuiHuanRequest.Create();
            request.ChouKaId = index;

            M2C_PetEggDuiHuanResponse response = (M2C_PetEggDuiHuanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_PetEggChouKaResponse> RequestPetEggChouKa(Scene root, int chouKaType)
        {
            C2M_PetEggChouKaRequest request = C2M_PetEggChouKaRequest.Create();
            request.ChouKaType = chouKaType;

            M2C_PetEggChouKaResponse response = (M2C_PetEggChouKaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_PetHeXinChouKaResponse> RequestPetHeXinChouKa(Scene root, int chouKaType)
        {
            C2M_PetHeXinChouKaRequest request = C2M_PetHeXinChouKaRequest.Create();
            request.ChouKaType = chouKaType;

            M2C_PetHeXinChouKaResponse response = (M2C_PetHeXinChouKaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RequestPetTakeOutBag(Scene root, long id)
        {
            C2M_PetTakeOutBag request = C2M_PetTakeOutBag.Create();
            request.PetInfoId = id;

            M2C_PetTakeOutBag response = (M2C_PetTakeOutBag)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestRolePetFenjie(Scene root, long id)
        {
            C2M_RolePetFenjie request = C2M_RolePetFenjie.Create();
            request.PetInfoId = id;

            M2C_RolePetFenjie response = (M2C_RolePetFenjie)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
        
        public static async ETTask<int> RequestRolePetFormationSet(Scene root, int sceneType, List<long> petList, List<long> positionList)
        {
            C2M_RolePetFormationSet request = C2M_RolePetFormationSet.Create();
            request.SceneType = sceneType;
            request.PetFormat = petList;
            request.PetPosition = positionList;

            M2C_RolePetFormationSet response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_RolePetFormationSet;
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            root.GetComponent<PetComponentC>().RequestPetFormationSet(sceneType, petList, positionList);

            return response.Error;
        }

        public static async ETTask<int> PetFragmentDuiHuan(Scene root)
        {
            C2M_PetFragmentDuiHuan request = C2M_PetFragmentDuiHuan.Create();
            M2C_PetFragmentDuiHuan response = (M2C_PetFragmentDuiHuan)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RolePetProtect(Scene root, long petInfoId, bool isProtect)
        {
            C2M_RolePetProtect request = C2M_RolePetProtect.Create();
            request.PetInfoId = petInfoId;
            request.IsProtect = isProtect;

            M2C_RolePetProtect response = (M2C_RolePetProtect)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().OnPetProtect(petInfoId, isProtect);
            }

            return response.Error;
        }

        public static async ETTask<int> RequestPetMingReset(Scene root)
        {
            C2M_PetMingResetRequest reuqest = C2M_PetMingResetRequest.Create();

            M2C_PetMingResetResponse response = (M2C_PetMingResetResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);
            if (response.Error == ErrorCode.ERR_Success)
            {
                int sceneid = BattleHelper.GetSceneIdByType(SceneTypeEnum.PetMing);
                root.GetComponent<UserInfoComponentC>().AddFubenTimes(sceneid, 5);
            }

            return response.Error;
        }

        public static async ETTask<int> OpenBoxRequest(Scene root, long unitId)
        {
            C2M_OpenBoxRequest request = C2M_OpenBoxRequest.Create();
            request.UnitId = unitId;

            M2C_OpenBoxResponse response = (M2C_OpenBoxResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> PetFubenBeginRequest(Scene root)
        {
            C2M_PetFubenBeginRequest request = C2M_PetFubenBeginRequest.Create();

            M2C_PetFubenBeginResponse response = (M2C_PetFubenBeginResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_PetDuiHuanResponse> PetDuiHuanRequest(Scene root, int operateId)
        {
            C2M_PetDuiHuanRequest request = C2M_PetDuiHuanRequest.Create();
            request.OperateId = operateId;

            M2C_PetDuiHuanResponse response = (M2C_PetDuiHuanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static void PetFubenOverRequest(Scene root)
        {
            root.GetComponent<ClientSenderCompnent>().Send(C2M_PetFubenOverRequest.Create());
        }
    }
}