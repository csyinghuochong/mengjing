using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Code]
    public class BuffDispatcherComponentC : Singleton<BuffDispatcherComponentC>, ISingletonAwake
    {
        private readonly Dictionary<string, BuffHandlerC> handlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(BuffHandlerCAttribute));
            foreach (Type type in types)
            {
                BuffHandlerC handler = Activator.CreateInstance(type) as BuffHandlerC;
                if (handler == null)
                {
                    Log.Error($"not BuffHandlerC: {type.Name}");
                    continue;
                }

                this.handlers.Add(type.Name, handler);
            }
        }

        public BuffHandlerC Get(string key)
        {
            this.handlers.TryGetValue(key, out var handler);
            return handler;
        }
    }
}