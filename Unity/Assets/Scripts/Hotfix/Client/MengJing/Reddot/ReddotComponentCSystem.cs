namespace ET.Client
{
    [FriendOf(typeof(ReddotComponentC))]
    [EntitySystemOf(typeof(ReddotComponentC))]
    public static partial class ReddotComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ReddotComponentC self)
        {
        }

        public static void UpdateReddont(this ReddotComponentC self, int reddotType)
        {
            bool showReddot = false;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            switch (reddotType)
            {
                case ReddotType.SingleRecharge:
                    UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                    showReddot = userInfoComponent.UserInfo.SingleRechargeIds.Count > userInfoComponent.UserInfo.SingleRewardIds.Count;
                    break;
                case ReddotType.WelfareLogin:
                    showReddot = self.Root().GetComponent<ActivityComponentC>().HaveLoginReward();
                    break;
                case ReddotType.WelfareTask:
                    showReddot = self.Root().GetComponent<TaskComponentC>().HaveWelfareReward();
                    break;
                case ReddotType.WelfareDraw:
                    NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
                    int drawReward = numericComponent.GetAsInt(NumericType.DrawReward);
                    long haveHuoyue = self.Root().GetComponent<TaskComponentC>().GetHuoYueDu();
                    showReddot = drawReward == 0 && haveHuoyue >= 60;
                    break;
                case ReddotType.RolePoint:
                    int pointRemain = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PointRemain);
                    showReddot = pointRemain > 0;
                    break;
                case ReddotType.SkillUp:
                    int skillpoint = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Sp;
                    showReddot = self.Root().GetComponent<SkillSetComponentC>().GetCanUpSkill(skillpoint).Count > 0;
                    break;
                case ReddotType.FriendChat:
                    FriendComponent friendComponent = self.Root().GetComponent<FriendComponent>();
                    showReddot = friendComponent.FriendChatId.Count > 0;
                    break;
                case ReddotType.FriendApply:
                    friendComponent = self.Root().GetComponent<FriendComponent>();
                    showReddot = friendComponent.ApplyList.Count > 0;
                    break;
                default:
                    return;
            }

            if (showReddot)
            {
                self.AddReddont(reddotType);
            }
            else
            {
                self.RemoveReddont(reddotType);
            }
        }

        public static void AddReddont(this ReddotComponentC self, int reddotType)
        {
            bool have = false;
            for (int i = self.ReddontList.Count - 1; i >= 0; i--)
            {
                if (self.ReddontList[i].KeyId == reddotType)
                {
                    have = true;
                    break;
                }
            }

            if (!have)
            {
                self.ReddontList.Add(new KeyValuePair() { KeyId = reddotType, Value = "1" });
            }

            EventSystem.Instance.Publish(self.Root(), new ReddotChange() { ReddotType = reddotType, Number = 1 });
        }

        public static int GetReddot(this ReddotComponentC self, int reddotType)
        {
            for (int i = self.ReddontList.Count - 1; i >= 0; i--)
            {
                if (self.ReddontList[i].KeyId == reddotType)
                {
                    return 1;
                }
            }

            return 0;
        }

        public static void RemoveReddont(this ReddotComponentC self, int reddotType)
        {
            for (int i = self.ReddontList.Count - 1; i >= 0; i--)
            {
                if (self.ReddontList[i].KeyId == reddotType)
                {
                    self.ReddontList.RemoveAt(i);
                    break;
                }
            }

            EventSystem.Instance.Publish(self.Root(), new ReddotChange() { ReddotType = reddotType, Number = 0 });
        }
    }
}