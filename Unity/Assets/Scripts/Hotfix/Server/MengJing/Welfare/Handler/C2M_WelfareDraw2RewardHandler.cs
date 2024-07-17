using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_WelfareDraw2RewardHandler : MessageLocationHandler<Unit, C2M_WelfareDraw2RewardRequest, M2C_WelfareDraw2RewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareDraw2RewardRequest request, M2C_WelfareDraw2RewardResponse response)
        {
            int index = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.DrawIndex2);
            if (index == 0 || index > ConfigData.WelfareChouKaList.Count)
            {
                return;
            }

            List<string> rewardItems = ActivityHelper.GetWelfareChouKaReward(unit.GetComponent<BagComponentS>().GetAllItems());
            string reward = rewardItems[index - 1];

            unit.GetComponent<BagComponentS>().OnAddItemData(reward, $"{ItemGetWay.Welfare}_{TimeHelper.ServerNow()}");
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.DrawIndex2, 0);
            await ETTask.CompletedTask;
        }
    }
}