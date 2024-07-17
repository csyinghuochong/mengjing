namespace ET.Server
{


    [EntitySystemOf(typeof(ReddotComponentS))]
    [FriendOf(typeof(ReddotComponentS))]
    public static partial class ReddotComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this ReddotComponentS self)
        {
            self.ReddontList.Clear();
        }
        [EntitySystem]
        private static void Destroy(this ReddotComponentS self)
        {

        }

        /// <summary>
        /// 显示红点
        /// </summary>
        /// <param name="self"></param>
        /// <param name="reddotType"></param>
        public static void AddReddont(this ReddotComponentS self, int reddotType)
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
        }
        
        public static int GetReddot(this ReddotComponentS self, int reddotType)
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

        /// <summary>
        /// 移除红点
        /// </summary>
        /// <param name="self"></param>
        /// <param name="reddotType"></param>
        /// <returns></returns>
        public static void RemoveReddont(this ReddotComponentS self, int reddotType)
        {
            for (int i = self.ReddontList.Count - 1; i >= 0; i--)
            {
                if (self.ReddontList[i].KeyId == reddotType)
                {
                    self.ReddontList.RemoveAt(i);
                    break;
                }
            }
        }
    }

}