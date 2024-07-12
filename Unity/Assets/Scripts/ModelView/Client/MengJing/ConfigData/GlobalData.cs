using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static partial class GlobalData
    {
        [StaticField]
        public static Dictionary<string, Shader> ShaderList = new();
    }
}