namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class A2M_PetMingRecordHandler : MessageHandler<Unit, A2M_PetMingRecordRequest, M2A_PetMingRecordResponse>
    {
        protected override async ETTask Run(Unit unit, A2M_PetMingRecordRequest request, M2A_PetMingRecordResponse response)
        {
            unit.GetComponent<PetComponentS>().OnPetMingRecord( request.PetMingRecord );

            unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.PetMineCDTime, 0 );

            ///红点
            unit.GetComponent<ReddotComponentS>().AddReddont(ReddotType.PetMine);
            
            await ETTask.CompletedTask;
        }
    }
}
