namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetEchoOperateHandler : MessageLocationHandler<Unit, C2M_PetEchoOperateRequest, M2C_PetEchoOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetEchoOperateRequest request, M2C_PetEchoOperateResponse response)
        {
            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            
            switch (request.OperateType)
            {
                case 1:
                    petComponentS.PetEchoList[request.Position].KeyId = 1;
                    break;
                case 2:
                    int oldIndex = petComponentS.PetEchoList.FindIndex(p => p.Value == request.ParamId);
                    
                    petComponentS.PetEchoList[request.Position].Value = request.ParamId;

                    if (oldIndex != -1)
                    {
                        petComponentS.PetEchoList[oldIndex].Value = 0;
                    }

                    break;
            }
            response.PetEchoList .AddRange( petComponentS.PetEchoList );  
            await ETTask.CompletedTask;
        }
    }
}