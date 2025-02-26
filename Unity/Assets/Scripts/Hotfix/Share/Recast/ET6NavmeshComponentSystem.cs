using System;

namespace ET
{

    [EntitySystemOf(typeof(ET6NavmeshComponent))]
    [FriendOf(typeof(ET6NavmeshComponent))]
    public static partial class ET6NavmeshComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.ET6NavmeshComponent self, System.Func<string, byte[]> loader)
        {
            ET6NavmeshComponent.Instance = self;
            self.Loader = loader;
        }
        
        public static long Get(this ET6NavmeshComponent self, string name)
        {
            long ptr;
            if (self.Navmeshs.TryGetValue(name, out ptr))
            {
                return ptr;
            }

            byte[] buffer = self.Loader(name);
            if (buffer.Length == 0)
            {
                throw new Exception($"no nav data: {name}");
            }

            ptr = Recast.RecastLoadLong(name.GetHashCode(), buffer, buffer.Length);
            self.Navmeshs[name] = ptr;

            return ptr;
        }
        
    }

}