using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace ET.Client
{
    
    
    [ComponentOf(typeof(Scene))]
    public class FallingFontComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        public List<FallingFontShowComponent> FallingFontShows = new List<FallingFontShowComponent>();
    }
    
}