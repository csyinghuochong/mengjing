using System;
using System.Collections.Generic;
using System.IO;
using Luban;

namespace ET
{
    [Invoke]
    public class GetAllConfigBytes : AInvokeHandler<ConfigLoader.GetAllConfigBytes, ETTask<Dictionary<Type, ByteBuf>>>
    {
        public override async ETTask<Dictionary<Type, ByteBuf>> Handle(ConfigLoader.GetAllConfigBytes args)
        {
            Dictionary<Type, ByteBuf> output = new Dictionary<Type, ByteBuf>();
            List<string> startConfigs = new List<string>()
            {
                "StartMachineConfigCategory",
                "StartProcessConfigCategory",
                "StartSceneConfigCategory",
                "StartZoneConfigCategory",
            };
            HashSet<Type> configTypes = CodeTypes.Instance.GetTypes(typeof(ConfigAttribute));
            foreach (Type configType in configTypes)
            {
                string configFilePath;
                if (startConfigs.Contains(configType.Name))
                {
                    configFilePath = $"../Config/Excel/s/{Options.Instance.StartConfig}/{configType.Name.ToLower()}.bytes";
                }
                else
                {
                    configFilePath = $"../Config/Excel/s/{configType.Name.ToLower()}.bytes";
                }

                output[configType] = new ByteBuf(File.ReadAllBytes(configFilePath));
            }

            await ETTask.CompletedTask;
            return output;
        }
    }

    [Invoke]
    public class GetOneConfigBytes : AInvokeHandler<ConfigLoader.GetOneConfigBytes, ByteBuf>
    {
        public override ByteBuf Handle(ConfigLoader.GetOneConfigBytes args)
        {
            string configName = args.ConfigName;
            bool isStartConfig = configName is "StartMachineConfigCategory" or "StartProcessConfigCategory" or
                    "StartSceneConfigCategory" or "StartZoneConfigCategory";
            string configFilePath = isStartConfig
                    ? $"../Config/Excel/s/{Options.Instance.StartConfig}/{configName.ToLower()}.bytes"
                    : $"../Config/Excel/s/{configName.ToLower()}.bytes";
            byte[] configBytes = File.ReadAllBytes(configFilePath);
            return new ByteBuf(configBytes);
        }
    }
}
