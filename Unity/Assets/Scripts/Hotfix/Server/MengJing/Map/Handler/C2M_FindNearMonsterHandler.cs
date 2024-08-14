namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_FindNearMonsterHandler : MessageLocationHandler<Unit, C2M_FindNearMonsterRequest, M2C_FindNearMonsterResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FindNearMonsterRequest request, M2C_FindNearMonsterResponse response)
        {
            Unit listUnit = GetTargetHelpS.GetNearestEnemy(unit,  50f, true);
            if (listUnit !=null)
            {
                response.IfFindStatus = true;
                response.x = listUnit.Position.x;
                response.y = listUnit.Position.y;
                response.z = listUnit.Position.z;
                response.MonsterID = listUnit.Id;
            }
            else 
            {
                response.IfFindStatus = false;
            }
            
            await ETTask.CompletedTask;

        }
    }
}
