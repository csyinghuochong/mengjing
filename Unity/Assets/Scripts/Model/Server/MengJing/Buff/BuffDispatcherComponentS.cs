using System;
using System.Collections.Generic;

namespace ET.Server
{ 
    [Code]
    public class BuffDispatcherComponentS: Singleton<BuffDispatcherComponentS>, ISingletonAwake
    {
        private readonly Dictionary<string, BuffHandlerS> aiHandlers = new();
        
        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof (BuffHandlerSAttribute));
            foreach (Type type in types)
            {
                BuffHandlerS aaiHandler = Activator.CreateInstance(type) as BuffHandlerS;
                if (aaiHandler == null)
                {
                    Log.Error($"robot ai is not AAIHandler: {type.Name}");
                    continue;
                }
                this.aiHandlers.Add(type.Name, aaiHandler);
            }
        }

        public BuffHandlerS Get(string key)
        {
            this.aiHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    
    }
    
}