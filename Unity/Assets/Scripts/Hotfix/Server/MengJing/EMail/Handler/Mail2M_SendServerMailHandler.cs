namespace ET.Server
{

    [MessageHandler(SceneType.EMail)]
    public class Mail2M_SendServerMailHandler : MessageLocationHandler<Unit, Mail2M_SendServerMailItem>
    {

        protected override async ETTask Run(Unit unit, Mail2M_SendServerMailItem message)
        {
            //Log.Console($"asdsadada : 全服邮件{message.ServerMailItem.ServerMailIId}");
            if (message.ServerMailItem.ServerMailIId > unit.GetComponent<UserInfoComponentS>().UserInfo.ServerMailIdCur)
            {
                unit.GetComponent<UserInfoComponentS>().UserInfo.ServerMailIdCur = message.ServerMailItem.ServerMailIId;
            }
            await ETTask.CompletedTask;
        }
    }
}
