using System;
using System.Collections.Generic;

namespace ET.Server
{

    [Code]
    public class SkillDispatcherComponentS: Singleton<SkillDispatcherComponentS>, ISingletonAwake
    {
        private readonly Dictionary<string, SkillHandlerS> aiHandlers = new();
        
        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof (SkillHandlerSAttribute));
            foreach (Type type in types)
            {
                SkillHandlerS aaiHandler = Activator.CreateInstance(type) as SkillHandlerS;
                if (aaiHandler == null)
                {
                    Log.Error($"robot ai is not AAIHandler: {type.Name}");
                    continue;
                }
                this.aiHandlers.Add(type.Name, aaiHandler);
            }
        }

        public SkillHandlerS Get(string key)
        {
            this.aiHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    }
}