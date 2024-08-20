using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Code]
    public class SkillDispatcherComponentC : Singleton<SkillDispatcherComponentC>, ISingletonAwake
    {
        private readonly Dictionary<string, SkillHandlerC> handlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(SkillHandlerCAttribute));
            foreach (Type type in types)
            {
                SkillHandlerC handler = Activator.CreateInstance(type) as SkillHandlerC;
                if (handler == null)
                {
                    Log.Error($"]not SkillHandlerC: {type.Name}");
                    continue;
                }

                this.handlers.Add(type.Name, handler);
            }
        }

        public SkillHandlerC Get(string key)
        {
            this.handlers.TryGetValue(key, out var handler);
            return handler;
        }
    }
}