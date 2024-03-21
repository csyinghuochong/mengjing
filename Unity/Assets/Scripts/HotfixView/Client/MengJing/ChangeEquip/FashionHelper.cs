using System.Collections.Generic;

namespace ET.Client
{
    public static class FashionHelper
    {
        public static Dictionary<int, List<string>> FashionBaseTemplate(int occ)
        {
            if (occ == 1)
            {
                return FashionData.FashionBaseTemplate_1;
            }

            if (occ == 2)
            {
                return FashionData.FashionBaseTemplate_2;
            }

            return FashionData.FashionBaseTemplate_3;
        }
    }
}

