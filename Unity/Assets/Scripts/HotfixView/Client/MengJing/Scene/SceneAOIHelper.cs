using System.Collections.Generic;

namespace ET.Client
{
    
    
    
    [FriendOf(typeof(SceneAOIEntity))]
    public static partial class SceneAOIHelper
    {
            public static long CreateCellId(int x, int y)
            {
                return (long) ((ulong) x << 32) | (uint) y;
            }
    
            public static void CalcEnterAndLeaveCell(SceneAOIEntity aoiEntity, int cellX, int cellY, HashSet<long> enterCell, HashSet<long> leaveCell)
            {
                enterCell.Clear();
                leaveCell.Clear();
                int r = (aoiEntity.ViewDistance - 1) / SceneAOIManagerComponent.CellSize + 1;
                int leaveR = r;
                
                leaveR += 1;
    
                for (int i = cellX - leaveR; i <= cellX + leaveR; ++i)
                {
                    for (int j = cellY - leaveR; j <= cellY + leaveR; ++j)
                    {
                        long cellId = CreateCellId(i, j);
                        leaveCell.Add(cellId);
    
                        if (i > cellX + r || i < cellX - r || j > cellY + r || j < cellY - r)
                        {
                            continue;
                        }
    
                        enterCell.Add(cellId);
                    }
                }
            }
        }
    }