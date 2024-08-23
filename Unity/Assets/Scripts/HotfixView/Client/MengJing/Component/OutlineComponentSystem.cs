using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(OutlineComponent))]
    [EntitySystemOf(typeof(OutlineComponent))]
    public static partial class OutlineComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OutlineComponent self)
        {
            GameObject gameObject = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
            self.GameObject = gameObject;

            // Cache renderers
            self.renderers = self.GameObject.GetComponentsInChildren<Renderer>();

            // Instantiate outline materials
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.outlineMaskMaterial =
                    UnityEngine.Object.Instantiate(resourcesLoaderComponent.LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("OutlineMask")));
            self.outlineFillMaterial =
                    UnityEngine.Object.Instantiate(resourcesLoaderComponent.LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("OutlineFill")));

            self.outlineMaskMaterial.name = "OutlineMask (Instance)";
            self.outlineFillMaterial.name = "OutlineFill (Instance)";

            // Retrieve or generate smooth normals
            self.LoadSmoothNormals();

            // Apply material properties immediately
            self.needsUpdate = true;

            self.OnEnable();
        }

        [EntitySystem]
        private static void Update(this OutlineComponent self)
        {
            if (self.needsUpdate)
            {
                self.needsUpdate = false;

                self.UpdateMaterialProperties();
            }
        }

        [EntitySystem]
        private static void Destroy(this OutlineComponent self)
        {
            UnityEngine.Object.Destroy(self.outlineMaskMaterial);
            UnityEngine.Object.Destroy(self.outlineFillMaterial);
        }

        public static void OnEnable(this OutlineComponent self)
        {
            foreach (var renderer in self.renderers)
            {
                // Append outline shaders
                var materials = renderer.sharedMaterials.ToList();

                materials.Add(self.outlineMaskMaterial);
                materials.Add(self.outlineFillMaterial);

                renderer.materials = materials.ToArray();
            }
        }

        public static void OnDisable(this OutlineComponent self)
        {
            foreach (var renderer in self.renderers)
            {
                // Remove outline shaders
                var materials = renderer.sharedMaterials.ToList();

                materials.Remove(self.outlineMaskMaterial);
                materials.Remove(self.outlineFillMaterial);

                renderer.materials = materials.ToArray();
            }
        }

        private static void OnValidate(this OutlineComponent self)
        {
            // Update material properties
            self.needsUpdate = true;

            // Clear cache when baking is disabled or corrupted
            if (!self.precomputeOutline && self.bakeKeys.Count != 0 || self.bakeKeys.Count != self.bakeValues.Count)
            {
                self.bakeKeys.Clear();
                self.bakeValues.Clear();
            }

            // Generate smooth normals when baking is enabled
            if (self.precomputeOutline && self.bakeKeys.Count == 0)
            {
                self.Bake();
            }
        }

        private static void Bake(this OutlineComponent self)
        {
            // Generate smooth normals for each mesh
            var bakedMeshes = new HashSet<Mesh>();

            foreach (var meshFilter in self.GameObject.GetComponentsInChildren<MeshFilter>())
            {
                // Skip duplicates
                if (!bakedMeshes.Add(meshFilter.sharedMesh))
                {
                    continue;
                }

                // Serialize smooth normals
                var smoothNormals = self.SmoothNormals(meshFilter.sharedMesh);

                self.bakeKeys.Add(meshFilter.sharedMesh);
                self.bakeValues.Add(new OutlineComponent.ListVector3() { data = smoothNormals });
            }
        }

        private static void LoadSmoothNormals(this OutlineComponent self)
        {
            // Retrieve or generate smooth normals
            foreach (var meshFilter in self.GameObject.GetComponentsInChildren<MeshFilter>())
            {
                // Skip if smooth normals have already been adopted
                if (!self.registeredMeshes.Add(meshFilter.sharedMesh))
                {
                    continue;
                }

                // Retrieve or generate smooth normals
                var index = self.bakeKeys.IndexOf(meshFilter.sharedMesh);
                var smoothNormals = (index >= 0) ? self.bakeValues[index].data : self.SmoothNormals(meshFilter.sharedMesh);

                // Store smooth normals in UV3
                meshFilter.sharedMesh.SetUVs(3, smoothNormals);

                // Combine submeshes
                var renderer = meshFilter.GetComponent<Renderer>();

                if (renderer != null)
                {
                    self.CombineSubmeshes(meshFilter.sharedMesh, renderer.sharedMaterials);
                }
            }

            // Clear UV3 on skinned mesh renderers
            foreach (var skinnedMeshRenderer in self.GameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                // Skip if UV3 has already been reset
                if (!self.registeredMeshes.Add(skinnedMeshRenderer.sharedMesh))
                {
                    continue;
                }

                // Clear UV3
                skinnedMeshRenderer.sharedMesh.uv4 = new Vector2[skinnedMeshRenderer.sharedMesh.vertexCount];

                // Combine submeshes
                self.CombineSubmeshes(skinnedMeshRenderer.sharedMesh, skinnedMeshRenderer.sharedMaterials);
            }
        }

        private static List<Vector3> SmoothNormals(this OutlineComponent self, Mesh mesh)
        {
            // Group vertices by location
            var groups = mesh.vertices.Select((vertex, index) => new KeyValuePair<Vector3, int>(vertex, index)).GroupBy(pair => pair.Key);

            // Copy normals to a new list
            var smoothNormals = new List<Vector3>(mesh.normals);

            // Average normals for grouped vertices
            foreach (var group in groups)
            {
                // Skip single vertices
                if (group.Count() == 1)
                {
                    continue;
                }

                // Calculate the average normal
                var smoothNormal = Vector3.zero;

                foreach (var pair in group)
                {
                    smoothNormal += smoothNormals[pair.Value];
                }

                smoothNormal.Normalize();

                // Assign smooth normal to each vertex
                foreach (var pair in group)
                {
                    smoothNormals[pair.Value] = smoothNormal;
                }
            }

            return smoothNormals;
        }

        private static void CombineSubmeshes(this OutlineComponent self, Mesh mesh, Material[] materials)
        {
            // Skip meshes with a single submesh
            if (mesh.subMeshCount == 1)
            {
                return;
            }

            // Skip if submesh count exceeds material count
            if (mesh.subMeshCount > materials.Length)
            {
                return;
            }

            // Append combined submesh
            mesh.subMeshCount++;
            mesh.SetTriangles(mesh.triangles, mesh.subMeshCount - 1);
        }

        private static void UpdateMaterialProperties(this OutlineComponent self)
        {
            // Apply properties according to mode
            self.outlineFillMaterial.SetColor("_OutlineColor", self.outlineColor);

            switch (self.outlineMode)
            {
                case OutlineComponent.Mode.OutlineAll:
                    self.outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    self.outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    self.outlineFillMaterial.SetFloat("_OutlineWidth", self.outlineWidth);
                    break;

                case OutlineComponent.Mode.OutlineVisible:
                    self.outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    self.outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.LessEqual);
                    self.outlineFillMaterial.SetFloat("_OutlineWidth", self.outlineWidth);
                    break;

                case OutlineComponent.Mode.OutlineHidden:
                    self.outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    self.outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Greater);
                    self.outlineFillMaterial.SetFloat("_OutlineWidth", self.outlineWidth);
                    break;

                case OutlineComponent.Mode.OutlineAndSilhouette:
                    self.outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.LessEqual);
                    self.outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    self.outlineFillMaterial.SetFloat("_OutlineWidth", self.outlineWidth);
                    break;

                case OutlineComponent.Mode.SilhouetteOnly:
                    self.outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.LessEqual);
                    self.outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Greater);
                    self.outlineFillMaterial.SetFloat("_OutlineWidth", 0f);
                    break;
            }
        }
    }
}