namespace ET.Client
{
    [EntitySystemOf(typeof(GuideInfo))]
    [FriendOf(typeof(GuideInfo))]
    public static partial class GuideInfoSystem
    {
        [EntitySystem]
        private static void Awake(this GuideInfo self, int guideId)
        {
            self.GuideId = guideId;
            self.Step = 0;
            self.Ids.Clear();

            self.Ids.Add(guideId);
        }

        public static bool IsDone(this GuideInfo self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            return userInfoComponent.UserInfo.CompleteGuideIds.Contains(self.GuideId);
        }

        public static void OnUpdate(this GuideInfo self)
        {
            if (self.Step >= self.Ids.Count)
            {
                Log.Error($"{self.Step}_{self.Ids.Count}");
                return;
            }

            int guideId = self.Ids[self.Step];
            EventSystem.Instance.Publish(self.Root(), new ShowGuide() { GroupId = self.GuideId, GuideId = guideId });
        }

        public static void OnNext(this GuideInfo self)
        {
            self.Step++;
            if (self.Step >= self.Ids.Count)
            {
                //发协议给后端记录
                self.Root().GetComponent<GuideComponent>().SendUpdateGuide(self.GuideId);
                return;
            }

            self.OnUpdate();
        }
    }
}