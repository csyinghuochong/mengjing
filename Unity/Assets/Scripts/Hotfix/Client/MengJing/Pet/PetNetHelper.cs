using System;
using System.Linq;
using System.Collections.Generic;

namespace ET.Client
{
    public static class PetNetHelper
    {
        public static async ETTask RequestPetInfo(Scene root)
        {
            M2C_RolePetList response =
                    (M2C_RolePetList)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_RolePetList());

            root.GetComponent<PetComponentC>().RequestAllPets(response);
        }

        public static async ETTask<int> RequestPetMingChanChu(Scene root)
        {
            C2A_PetMingChanChuRequest request = new C2A_PetMingChanChuRequest();
            A2C_PetMingChanChuResponse respone = (A2C_PetMingChanChuResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return respone.Error;
        }

        public static async ETTask<A2C_PetMingListResponse> RequestPetMingList(Scene root)
        {
            C2A_PetMingListRequest request = new C2A_PetMingListRequest() { };
            A2C_PetMingListResponse response = (A2C_PetMingListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> RequestPetFubenReward(Scene root)
        {
            C2M_PetFubenRewardRequest request = C2M_PetFubenRewardRequest.Create();
            M2C_PetFubenRewardResponse response = (M2C_PetFubenRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestPetSet(Scene root, int sceneType, List<long> petList, List<long> positionList)
        {
            C2M_RolePetFormationSet c2M_RolePetFormationSet = new C2M_RolePetFormationSet()
            {
                SceneType = sceneType, PetFormat = petList, PetPosition = positionList
            };
            M2C_RolePetFormationSet m2C_RolePetFormationSet =
                    await root.GetComponent<ClientSenderCompnent>().Call(c2M_RolePetFormationSet) as M2C_RolePetFormationSet;
            if (m2C_RolePetFormationSet.Error != ErrorCode.ERR_Success)
            {
                return m2C_RolePetFormationSet.Error;
            }

            root.GetComponent<PetComponentC>().RequestPetFormationSet(sceneType, petList, positionList);
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestPetFight(Scene root, long petId, int fight)
        {
            //简单写一下，有其他出战的则不能出战。
            //for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            //{
            //    if (self.RolePetInfos[i].PetStatus == 1 && self.RolePetInfos[i].Id != petId && fight == 1)
            //    {
            //        return;
            //    }
            //}

            C2M_RolePetFight request = new() { PetInfoId = petId, PetStatus = fight };
            M2C_RolePetFight response = (M2C_RolePetFight)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RequestPetFight(petId, fight);
            }

            EventSystem.Instance.Publish(root, new DataUpdate_OnPetFightSet());
            return response.Error;
        }

        public static async ETTask<int> RequestUpStar(Scene root, long mainId, List<long> costIds)
        {
            C2M_RolePetUpStar c2M_RolePetXiLian = new C2M_RolePetUpStar() { PetInfoId = mainId, CostPetInfoIds = costIds };
            M2C_RolePetUpStar m2C_RolePetXiLian =
                    (M2C_RolePetUpStar)await root.GetComponent<ClientSenderCompnent>().Call(c2M_RolePetXiLian);

            if (m2C_RolePetXiLian.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RequestUpStar(mainId, costIds, m2C_RolePetXiLian.rolePetInfo);
            }

            return m2C_RolePetXiLian.Error;
        }

        public static async ETTask RequestFenJie(Scene root, long petId)
        {
            C2M_RolePetFenjie c2M_RolePetXiLian = new C2M_RolePetFenjie() { PetInfoId = petId };
            M2C_RolePetFenjie m2C_RolePetXiLian = (M2C_RolePetFenjie)await root.GetComponent<ClientSenderCompnent>().Call(c2M_RolePetXiLian);

            if (m2C_RolePetXiLian.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RemovePet(petId);
                ;
            }
            //HintHelp.GetInstance().DataUpdate(DataType.PetFenJieUpdate);
        }

        public static async ETTask<int> RequestXiLian(Scene root, long itemId, long petId)
        {
            C2M_RolePetXiLian c2M_RolePetXiLian = new C2M_RolePetXiLian() { BagInfoID = itemId, PetInfoId = petId };
            M2C_RolePetXiLian m2C_RolePetXiLian = (M2C_RolePetXiLian)await root.GetComponent<ClientSenderCompnent>().Call(c2M_RolePetXiLian);

            if (m2C_RolePetXiLian.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RequestXiLian(itemId, petId, m2C_RolePetXiLian.rolePetInfo);
            }

            EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = "道具在宠物身上发生了作用！" });
            EventSystem.Instance.Publish(root, new DataUpdate_PetXiLianUpdate());

            return m2C_RolePetXiLian.Error;
        }

        public static async ETTask<int> RequestChangePos(Scene root, int index1, int index2)
        {
            C2M_PetChangePosRequest request = new() { Index1 = index1, Index2 = index2 };
            M2C_PetChangePosResponse response = (M2C_PetChangePosResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<RolePetInfo> RequestRolePetHeXin(Scene root, int operateType, long bagInfoId, long PetInfoId, int position)
        {
            C2M_RolePetHeXin request = new() { OperateType = operateType, BagInfoId = bagInfoId, PetInfoId = PetInfoId, Position = position };
            M2C_RolePetHeXin response = (M2C_RolePetHeXin)await root.GetComponent<ClientSenderCompnent>().Call(request);
            root.GetComponent<PetComponentC>().OnRolePetUpdate(response.RolePetInfo);
            return response.RolePetInfo;
        }

        public static async ETTask<int> RequestPetHeXinHeCheng(Scene root, long bagInfoID_1, long bagInfoID_2)
        {
            C2M_PetHeXinHeChengRequest request = new() { BagInfoID_1 = bagInfoID_1, BagInfoID_2 = bagInfoID_2 };
            M2C_PetHeXinHeChengResponse response = (M2C_PetHeXinHeChengResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestPetHeXinHeChengQuick(Scene root)
        {
            C2M_PetHeXinHeChengQuickRequest request = new();
            M2C_PetHeXinHeChengQuickResponse response =
                    (M2C_PetHeXinHeChengQuickResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<RolePetInfo> RequestRolePetJiadian(Scene root, long petInfoId, List<int> addPropretyValue)
        {
            C2M_RolePetJiadian request = new() { PetInfoId = petInfoId, AddPropretyValue = addPropretyValue };
            M2C_RolePetJiadian response =
                    (M2C_RolePetJiadian)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<PetComponentC>().OnRolePetUpdate(response.RolePetInfo);

            return response.RolePetInfo;
        }

        public static async ETTask<int> RequestRolePetRName(Scene root, long petInfoId, string petName)
        {
            C2M_RolePetRName request = new() { PetInfoId = petInfoId, PetName = petName };
            M2C_RolePetRName response = (M2C_RolePetRName)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_RolePetHeCheng> RequestRolePetHeCheng(Scene root, long petInfoId1, long petInfoId2)
        {
            C2M_RolePetHeCheng request = new() { PetInfoId1 = petInfoId1, PetInfoId2 = petInfoId2 };
            M2C_RolePetHeCheng response = (M2C_RolePetHeCheng)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RequestPetShouHuActive(Scene root, int petShouHuActive)
        {
            C2M_PetShouHuActiveRequest request = new() { PetShouHuActive = petShouHuActive };
            M2C_PetShouHuActiveResponse response =
                    (M2C_PetShouHuActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            root.GetComponent<PetComponentC>().PetShouHuActive = response.PetShouHuActive;

            return response.Error;
        }

        public static async ETTask<int> RequestPetShouHu(Scene root, long petInfoId, int position)
        {
            C2M_PetShouHuRequest request = new() { PetInfoId = petInfoId, Position = position };
            M2C_PetShouHuResponse response =
                    (M2C_PetShouHuResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            root.GetComponent<PetComponentC>().PetShouHuList = response.PetShouHuList;

            return response.Error;
        }

        public static async ETTask<int> RequestPetEggPut(Scene root, int index, long bagInfoID)
        {
            C2M_RolePetEggPut request = new() { Index = index, BagInfoId = bagInfoID };
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
            C2M_RolePetEggPutOut request = new() { Index = index };
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
            C2M_RolePetEggHatch request = new() { Index = index };
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
            C2M_RolePetEggOpen request = new() { Index = index };
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
            C2M_PetEggDuiHuanRequest request = new() { ChouKaId = index };
            M2C_PetEggDuiHuanResponse response = (M2C_PetEggDuiHuanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_PetEggChouKaResponse> RequestPetEggChouKa(Scene root, int chouKaType)
        {
            C2M_PetEggChouKaRequest request = new() { ChouKaType = chouKaType };
            M2C_PetEggChouKaResponse response = (M2C_PetEggChouKaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_PetHeXinChouKaResponse> RequestPetHeXinChouKa(Scene root, int chouKaType)
        {
            C2M_PetHeXinChouKaRequest request = new() { ChouKaType = chouKaType };
            M2C_PetHeXinChouKaResponse response =
                    (M2C_PetHeXinChouKaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RequestPetTakeOutBag(Scene root, long id)
        {
            C2M_PetTakeOutBag request = new() { PetInfoId = id };
            M2C_PetTakeOutBag response = (M2C_PetTakeOutBag)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestRolePetFenjie(Scene root, long id)
        {
            C2M_RolePetFenjie request = new() { PetInfoId = id };
            M2C_RolePetFenjie response = (M2C_RolePetFenjie)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestRolePetFormationSet(Scene root, int sceneType, List<long> petList, List<long> positionList)
        {
            C2M_RolePetFormationSet request = new() { SceneType = sceneType, PetFormat = petList, PetPosition = positionList };
            M2C_RolePetFormationSet response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_RolePetFormationSet;

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            root.GetComponent<PetComponentC>().RequestPetFormationSet(sceneType, petList, null);

            return response.Error;
        }

        public static async ETTask<int> PetFragmentDuiHuan(Scene root)
        {
            C2M_PetFragmentDuiHuan request = new();
            M2C_PetFragmentDuiHuan response = (M2C_PetFragmentDuiHuan)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RolePetProtect(Scene root, long petInfoId, bool isProtect)
        {
            C2M_RolePetProtect request = new() { PetInfoId = petInfoId, IsProtect = isProtect };
            M2C_RolePetProtect response = (M2C_RolePetProtect)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestPetMingReset(Scene root)
        {
            C2M_PetMingResetRequest reuqest = new();
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
            C2M_OpenBoxRequest request = new() { UnitId = unitId };
            M2C_OpenBoxResponse response = (M2C_OpenBoxResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
    }
}