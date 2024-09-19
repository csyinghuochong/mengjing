using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public class MaterialManager : MonoBehaviour
    {
        private Renderer renderer;
        private Material[] originalMaterials;
        public List<MaterialGroup> MaterialGroups = new();

        private void Start()
        {
            this.renderer = GetComponent<Renderer>();
            originalMaterials = this.renderer.materials;
        }

        /// <summary>
        /// 切换材质
        /// </summary>
        /// <param name="name"></param>
        public void Switch(string name)
        {
            foreach (MaterialGroup materialGroup in this.MaterialGroups)
            {
                if (materialGroup.Name != name)
                {
                    continue;
                }

                this.renderer.materials = materialGroup.Materials;
            }
        }

        /// <summary>
        /// 恢复到原始材质
        /// </summary>
        public void RestoreOriginalMaterials()
        {
            this.renderer.materials = this.originalMaterials;
        }
    }

    [System.Serializable]
    public class MaterialGroup
    {
        public string Name;
        public Material[] Materials;
    }
}