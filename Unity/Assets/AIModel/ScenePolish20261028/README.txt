Scene polish — 2026-10-28

Scenes: Assets/Bundles/Scenes/10003a.unity, 10004a.unity
Owned resources: Assets/AIModel/ScenePolish20261028

120m x 120m horizontal terrain; V2 route relationships retained.
10003a: detailed ancient ruins BOSS court.
10004a: command camp BOSS court with russet main tent.
Old crude triangular foliage groups removed; curved closed leaf meshes,
repaired textured ferns and shrubs added.

Folders:
Meshes: curved leaf meshes, vein texture
Materials: independent repaired/tinted materials
Prefabs: curved leaf asset and complete 120m scene assemblies
Terrain: independent expanded terrain copies
Navigation: rebuilt editor NavMesh data

Original source scenes and source assets are read-only for this iteration.
10003a derives from 10002a; 10004a derives from 10002b.

Validation: 14 + 15 complete navigation paths; both BOSS spawn locations on
walkable ground; no missing scripts/materials or non-finite geometry.
This does not constitute an on-device performance or BOSS combat test.

The temporary editor builder is archived outside the Unity project.
Reproduction order, if reinstalled: build, visibility, capture.
Do not run build over later user edits: it restores the stored V2 scenes first.
