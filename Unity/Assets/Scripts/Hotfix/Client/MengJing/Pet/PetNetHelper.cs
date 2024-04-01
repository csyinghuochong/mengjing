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

            C2M_RolePetFight c2M_RolePetFight = new C2M_RolePetFight() { PetInfoId = petId, PetStatus = fight };
            M2C_RolePetFight m2C_RolePetFight =
                    (M2C_RolePetFight)await root.GetComponent<ClientSenderCompnent>().Call(c2M_RolePetFight);

            if (m2C_RolePetFight.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<PetComponentC>().RequestPetFight(petId, fight);
            }

            return m2C_RolePetFight.Error;
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
    }
}