namespace ET.Client
{
    [FriendOf(typeof (JiaYuanComponentC))]
    [EntitySystemOf(typeof (JiaYuanComponentC))]
    public static partial class JiaYuanComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanComponentC self)
        {
        }

        public static JiaYuanPet GetJiaYuanPetGetPosition(this JiaYuanComponentC self, int position)
        {
            for (int i = 0; i < self.JiaYuanPetList_2.Count; i++)
            {
                if (self.JiaYuanPetList_2[i].Position == position)
                {
                    return self.JiaYuanPetList_2[i];
                }
            }

            return null;
        }
    }
}