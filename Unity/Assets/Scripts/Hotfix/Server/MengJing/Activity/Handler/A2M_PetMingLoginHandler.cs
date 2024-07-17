namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class A2M_PetMingLoginHandler : MessageHandler<Unit, A2M_PetMingLoginRequest, M2A_PetMingLoginResponse>
    {
        protected override async ETTask Run(Unit unit, A2M_PetMingLoginRequest request, M2A_PetMingLoginResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (1 == numericComponent.GetAsInt(NumericType.PetMineLogin))
            {
                return;
            }
            //numericComponent.ApplyValue(NumericType.PetMineLogin, 1);
            unit.GetComponent<TaskComponentS>().OnPetMineLogin(request.PetMineList, request.PetMingExtend);

            await ETTask.CompletedTask;
        }
    }
}
