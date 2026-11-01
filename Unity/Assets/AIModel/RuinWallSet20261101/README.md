# 遗迹石墙四件套

四件独立预制件在 `Prefabs` 下。单位为米，Y 轴向上，墙脚为摆放基准；C 款以转角柱脚为原点。

| 预制件 | 用途 | LOD0 三角面 | LOD1 三角面 |
|---|---|---:|---:|
| A_Mossy_Straight_Wall | 苔藓残墙 | 960 | 624 |
| B_Ruined_Arch_Gateway | 破损拱门 | 1280 | 864 |
| C_L_Shaped_Ruin_Corner | 转角残墙 | 1020 | 668 |
| D_Crystal_Fractured_Wall | 水晶侵蚀石墙 | 1214 | 826 |

石块、断口、倒角与水晶保留实体几何；苔藓和细雕纹由颜色贴图、法线贴图表现，控制面数。每件配有两档 LOD 和静态网格碰撞。B 款的碰撞保留门洞，已检查两侧立柱与中央通路。

`Models` 保留 OBJ/MTL 源文件，`Meshes` 是 Unity 使用的网格，`Materials` 与 `Textures` 是共享 URP 材质和贴图。模型不依赖额外运行时代码；场景摆放另行管理。

实际预览图和检查记录位于工程外 `outputs/RuinWalls20261101`。
