using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class CanvasWillRender: MonoBehaviour
    {
        IList<ICanvasElement> m_LayoutRebuildQueue;
        IList<ICanvasElement> m_GraphicRebuildQueue;

        private void Awake()
        {
            Type type = typeof (CanvasUpdateRegistry);
            FieldInfo field = type.GetField("m_LayoutRebuildQueue", BindingFlags.NonPublic | BindingFlags.Instance);
            m_LayoutRebuildQueue = (IList<ICanvasElement>)field.GetValue(CanvasUpdateRegistry.instance);
            field = type.GetField("m_GraphicRebuildQueue", BindingFlags.NonPublic | BindingFlags.Instance);
            m_GraphicRebuildQueue = (IList<ICanvasElement>)field.GetValue(CanvasUpdateRegistry.instance);
        }

        private void Update()
        {
            for (int j = 0; j < m_LayoutRebuildQueue.Count; j++)
            {
                var rebuild = m_LayoutRebuildQueue[j];
                if (ObjectValidForUpdate(rebuild))
                {
                    Log.Debug($"{rebuild.transform.name}引起{rebuild.transform.GetComponent<Graphic>().canvas.name}网格重建");
                }
            }

            for (int j = 0; j < m_GraphicRebuildQueue.Count; j++)
            {
                var element = m_GraphicRebuildQueue[j];
                if (ObjectValidForUpdate(element))
                {
                    Log.Debug($"{element.transform.name}引起{element.transform.GetComponent<Graphic>().canvas.name}网格重建");
                }
            }
        }

        private bool ObjectValidForUpdate(ICanvasElement element)
        {
            var valid = element != null;

            var isUnityObject = element is Object;
            if (isUnityObject)
                valid = (element as Object) !=
                        null; //Here we make use of the overloaded UnityEngine.Object == null, that checks if the native object is alive.

            return valid;
        }
    }
}