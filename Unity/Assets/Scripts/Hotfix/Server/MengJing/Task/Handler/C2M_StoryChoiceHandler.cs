namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_StoryChoiceHandler : MessageLocationHandler<Unit, C2M_StoryChoiceRequest, M2C_StoryChoiceResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_StoryChoiceRequest request, M2C_StoryChoiceResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            response.Error = taskComponent.OnStoryChoice(request.StoryId, request.ChoiceId);
            if (response.Error == ErrorCode.ERR_Success)
            {
                response.StoryInfoList.AddRange(taskComponent.StoryInfoList);
            }

            await ETTask.CompletedTask;
        }
    }
}
