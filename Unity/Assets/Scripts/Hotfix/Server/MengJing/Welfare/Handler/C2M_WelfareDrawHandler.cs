using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_WelfareDrawHandler : MessageLocationHandler<Unit, C2M_WelfareDrawRequest, M2C_WelfareDrawResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareDrawRequest request, M2C_WelfareDrawResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            //已经领取过抽奖奖励
            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.DrawReward) == 1)
            {
                return;
            }

            //已经生成了奖励格子
            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.DrawIndex) > 0)
            {
                return;
            }          
           
            int openDay = unit.GetComponent<UserInfoComponentS>().GetCrateDay();
            int index = CommonHelp.GetWelfareDrawIndex( openDay );

            if (index == -1)
            {
                List<int> weights = new List<int>();

                List<KeyValuePair> drawlist = ConfigData.WelfareDrawList;
                for (int i = 0; i < drawlist.Count; i++)
                {
                    weights.Add(drawlist[i].KeyId);
                }
                index = RandomHelper.RandomByWeight(weights) + 1;
            }
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.DrawIndex, index);
            await ETTask.CompletedTask;
        }
    }
}
