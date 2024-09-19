using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ET.Client
{
    public class MaterialManager : MonoBehaviour
    {
        public Renderer Renderer;
        public Material[] OriginalMaterials;
        public List<MaterialGroup> MaterialGroups = new();

        private void Start()
        {
            this.Renderer = GetComponent<Renderer>();
            // this.OriginalMaterials = this.Renderer.materials;// 访问时自动生成材质的实例
            this.OriginalMaterials = this.Renderer.sharedMaterials;
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