namespace ET.Server
{

    [MessageHandler(SceneType.Chat)]
    public class C2Chat_SendJinYanHandler : MessageLocationHandler<ChatInfoUnit, C2C_ChatJinYanRequest, C2C_ChatJinYanResponse>
    {

        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2C_ChatJinYanRequest request, C2C_ChatJinYanResponse response)
        {

            ChatSceneComponent chatInfoUnitsComponent = chatInfoUnit.Root().GetComponent<ChatSceneComponent>();

            BeReportedInfo bePortedNumber;
            chatInfoUnitsComponent.BeReportedNumber.TryGetValue(request.JinYanId, out bePortedNumber);

            if (bePortedNumber == null)
            {
                bePortedNumber = new BeReportedInfo();
                chatInfoUnitsComponent.BeReportedNumber.Add(request.JinYanId, bePortedNumber);
            }

            if (bePortedNumber.ReportedList.Contains(request.UnitId))
            {
                return;
            }
            if (bePortedNumber.ReportedList.Count >= 5)
            {
                return;
            }

            bePortedNumber.ReportedList.Add(request.UnitId);
            if (bePortedNumber.ReportedList.Count == 5)
            {
                for (int i = chatInfoUnitsComponent.WordChatInfos.Count - 1; i >= 0; i--)
                {
                    if (chatInfoUnitsComponent.WordChatInfos[i].UserId == request.JinYanId)
                    {
                        chatInfoUnitsComponent.WordChatInfos.RemoveAt(i);   
                    }
                }

                bePortedNumber.JinYanTime = TimeHelper.ServerNow() + TimeHelper.OneDay;
            }
            Log.Warning($"{chatInfoUnit.Zone()}   {request.JinYanId}  {request.JinYanPlayer} 被举报");
            await ETTask.CompletedTask;
        }
    }
}
