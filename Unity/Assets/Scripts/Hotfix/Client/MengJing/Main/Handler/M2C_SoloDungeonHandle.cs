namespace ET.Client
{
    public class M2C_SoloDungeonHandle : MessageHandler<Scene, M2C_SoloDungeon>
    {
        protected override async ETTask Run(Scene root, M2C_SoloDungeon message)
        {
            Log.Debug("恭喜你！竞技场获胜...." + message.SoloResult + "并且获得奖励:" + message.RewardItem[0].ItemID + ";" + message.RewardItem[0].ItemNum);

            EventSystem.Instance.Publish(root, new UISoloReward() { m2C_SoloDungeon = message });

            await ETTask.CompletedTask;
        }
    }
}