using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Code]
    public class SkillDispatcherComponentC: Singleton<SkillDispatcherComponentC>, ISingletonAwake
    {
        private readonly Dictionary<string, SkillHandlerC> aiHandlers = new();
        
        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof (SkillHandlerCAttribute));
            foreach (Type type in types)
            {
                SkillHandlerC aaiHandler = Activator.CreateInstance(type) as SkillHandlerC;
                if (aaiHandler == null)
                {
                    Log.Error($"robot ai is not AAIHandler: {type.Name}");
                    continue;
                }
                this.aiHandlers.Add(type.Name, aaiHandler);
            }
        }

        public SkillHandlerC Get(string key)
        {
            this.aiHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    }
}