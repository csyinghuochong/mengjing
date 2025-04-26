using System;
using System.Collections.Generic;

namespace ET
{
    [Code]
    public class ET6NavmeshComponent: Singleton<ET6NavmeshComponent>, ISingletonAwake
    {
 
        public struct RecastFileLoader
        {
            public string Name { get; set; }
        }
        
        private readonly  Dictionary<string, long> Navmeshs = new Dictionary<string, long>();
        
        public void Awake()
        {
            Log.Debug("ET6NavmeshComponent Awake");     
        }
        
        public long Get( string name)
        {
            long ptr;
            if (this.Navmeshs.TryGetValue(name, out ptr))
            {
                return ptr;
            }

            byte[] buffer =  EventSystem.Instance.Invoke<NavmeshComponent.RecastFileLoader, byte[]>(
                new NavmeshComponent.RecastFileLoader() { Name = name });
            if (buffer.Length == 0)
            {
                throw new Exception($"no nav data: {name}");
            }

            //ptr = Recast.RecastLoadLong(name.GetHashCode(), buffer, buffer.Length);
            this.Navmeshs[name] = ptr;

            return ptr;
        }
    }

}
