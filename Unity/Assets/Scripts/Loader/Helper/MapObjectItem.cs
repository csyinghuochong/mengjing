using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    
    public class MapObjectItem
    {
        public string AssetPath;

        public List<Vector3> PositionList = new List<Vector3>();
        
        public List<Vector3> ScaleList = new List<Vector3>();

        public List<Quaternion> RotationList = new List<Quaternion>();
        
        public List<string> TagList = new List<string>();
        
        public List<int> LayerList = new List<int>();

        public static List<MapObjectItem> ToMapObjectItem(string mapObjectConfig)
        {
            //HCFX_Beam_04&0:0:0:10:10:10:0:0:0|-17:0:0:10:10:10:0:0:0|-85.03:0:0:10:10:10:326.21:124.1:0@HCFX_Appear_02_Start&0:0:0:10:10:10:0:0:0@HCFX_Appear_03&0:0:0:10:10:10:0:0:0|16:0:-30:10:10:10:0:0:0@

            List<MapObjectItem> mapObjectItems = new List<MapObjectItem>();

            string[] objectlist = mapObjectConfig.Split('@');
            for ( int i = 0; i < objectlist.Length; i++ )
            {
                if (string.IsNullOrEmpty(objectlist[i]))
                {
                    continue;
                }
                
                //HCFX_Beam_04&0:0:0:10:10:10:0:0:0|-17:0:0:10:10:10:0:0:0|-85.03:0:0:10:10:10:326.21:124.1:0
                string[] objectInfo = objectlist[i].Split('&');

                if (objectInfo.Length < 2)
                {
                    continue;
                }


                string[] iteminfolist = objectInfo[1].Split('|');
                MapObjectItem mapObjectItem = new MapObjectItem();

                mapObjectItem.AssetPath = objectInfo[0];

                for (int item = 0; item < iteminfolist.Length; item++)
                {
                    string[] positioninfo = iteminfolist[item].Split(':');

                    mapObjectItem.PositionList .Add(  new Vector3(float.Parse(positioninfo[0]),float.Parse(positioninfo[1]),float.Parse(positioninfo[2]))  ); 
                    mapObjectItem.ScaleList.Add(  new Vector3 (float.Parse(positioninfo[3]),float.Parse(positioninfo[4]),float.Parse(positioninfo[5]) )   ); 
                    mapObjectItem.RotationList.Add( Quaternion.Euler(float.Parse(positioninfo[6]),float.Parse(positioninfo[7]),float.Parse(positioninfo[8]) )  ); 
                    mapObjectItem.TagList.Add( positioninfo[9] );
                    mapObjectItem.LayerList.Add( int.Parse(positioninfo[10]) );
                }

                mapObjectItems.Add(mapObjectItem);
            }

            return mapObjectItems;
        }
    }

}