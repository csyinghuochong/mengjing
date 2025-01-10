using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{

    public static class CellGenerateHelper
    {

        public static int GetCellIndex(CellGenerateConfig chapterConfig, int row, int line)
        {
            int rowTotal = chapterConfig.InitSize[0];
            return line * rowTotal + row;
        }

    }

}

