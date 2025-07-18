using UnityEngine;

namespace ET.Client
{
    public static class LayerHelp
    {
        public static void ChangeLayer(Transform trans, LayerEnum targetLayer)
        {
            //if (LayerMask.NameToLayer(targetLayer.ToString()) == -1)
            //{
            //    Log.Debug("Layer中不存在，请手动添加LayerName");
            //    return;
            //}

            //遍历更改所有子物体layer
            trans.gameObject.layer = LayerMask.NameToLayer(targetLayer.ToString());

            //foreach (Transform child in trans)
            //{
            //    ChangeLayer(child, targetLayer);
            //}
        }

        public static void ChangeLayerAll(Transform trans, LayerEnum targetLayer)
        {
            //if (LayerMask.NameToLayer(targetLayer.ToString()) == -1)
            //{
            //    Log.Debug("Layer中不存在，请手动添加LayerName");
            //    return;
            //}

            //遍历更改所有子物体layer
            trans.gameObject.layer = LayerMask.NameToLayer(targetLayer.ToString());
            foreach (Transform child in trans)
            {
                ChangeLayerAll(child, targetLayer);
            }
        }
    }
}
