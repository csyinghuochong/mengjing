using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public class MaterialManager : MonoBehaviour
    {
        private Renderer Renderer;
        private Material[] OriginalMaterials;
        public List<MaterialGroup> MaterialGroups = new();

        private void Start()
        {
            this.Renderer = GetComponent<Renderer>();
            this.OriginalMaterials = this.Renderer.materials;
            // this.OriginalMaterials = this.Renderer.sharedMaterials;
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

                this.Renderer.materials = materialGroup.Materials;
            }
        }

        /// <summary>
        /// 恢复到原始材质
        /// </summary>
        public void RestoreOriginalMaterials()
        {
            this.Renderer.materials = this.OriginalMaterials;
        }
    }

    [System.Serializable]
    public class MaterialGroup
    {
        public string Name;
        public Material[] Materials;
    }
}