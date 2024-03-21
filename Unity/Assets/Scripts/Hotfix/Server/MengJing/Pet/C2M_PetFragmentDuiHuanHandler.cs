
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFragmentDuiHuanHandler: MessageLocationHandler<Unit, C2M_PetFragmentDuiHuan, M2C_PetFragmentDuiHuan>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFragmentDuiHuan request, M2C_PetFragmentDuiHuan response)
        {

            
            await ETTask.CompletedTask;
        }
    }
}

