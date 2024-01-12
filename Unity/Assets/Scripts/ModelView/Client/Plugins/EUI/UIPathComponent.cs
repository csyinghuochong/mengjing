﻿using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class UIPathComponent : Entity,IAwake,IDestroy
    {

        public  Dictionary<int, string> WindowPrefabPath = new Dictionary<int, string>();
        
        public  Dictionary<string,int> WindowTypeIdDict = new Dictionary<string, int>();
    }
}