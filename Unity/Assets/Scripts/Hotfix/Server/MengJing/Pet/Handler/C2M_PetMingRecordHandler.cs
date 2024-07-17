namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMingRecordHandler : MessageLocationHandler<Unit, C2M_PetMingRecordRequest, M2C_PetMingRecordResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMingRecordRequest request, M2C_PetMingRecordResponse response)
        {
            response.PetMingRecords .AddRange(unit.GetComponent<PetComponentS>().PetMingRecordList); 
            await ETTask.CompletedTask;
        } 
    }
}
