﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    public static class EUIHelper
    {
        #region UI辅助方法

        public static void SetText(this Text Label, string content)
        {
            if (null == Label)
            {
                Log.Error("label is null");
                return;
            }

            Label.text = content;
        }

        public static void SetVisibleWithScale(this UIBehaviour uiBehaviour, bool isVisible)
        {
            if (null == uiBehaviour)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == uiBehaviour.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            if (uiBehaviour.gameObject.activeSelf == isVisible)
            {
                return;
            }

            uiBehaviour.transform.localScale = isVisible ? Vector3.one : Vector3.zero;
        }

        public static void SetVisible(this UIBehaviour uiBehaviour, bool isVisible)
        {
            if (null == uiBehaviour)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == uiBehaviour.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            if (uiBehaviour.gameObject.activeSelf == isVisible)
            {
                return;
            }

            uiBehaviour.gameObject.SetActive(isVisible);
        }

        public static void SetVisible(this LoopScrollRect loopScrollRect, bool isVisible, int count, bool reStart = false)
        {
            int startItem = 0;
            if (!reStart)
            {
                startItem = loopScrollRect.ItemTypeStart;
            }

            RectTransform rectTransform = loopScrollRect.transform.Find("Content").GetComponent<RectTransform>();
            Vector2 pos = rectTransform.anchoredPosition;

            loopScrollRect.gameObject.SetActive(isVisible);
            loopScrollRect.totalCount = count;
            loopScrollRect.RefillCells(startItem > count ? count : startItem);

            if (!reStart)
            {
                loopScrollRect.transform.Find("Content").GetComponent<RectTransform>().anchoredPosition = pos;
            }
        }

        public static void SetVisibleWithScale(this Transform transform, bool isVisible)
        {
            if (null == transform)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == transform.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            transform.localScale = isVisible ? Vector3.one : Vector3.zero;
        }

        public static void SetVisible(this Transform transform, bool isVisible)
        {
            if (null == transform)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == transform.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            if (transform.gameObject.activeSelf == isVisible)
            {
                return;
            }

            transform.gameObject.SetActive(isVisible);
        }

        public static void SetTogglesInteractable(this ToggleGroup toggleGroup, bool isEnable)
        {
            var toggles = toggleGroup.transform.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].interactable = isEnable;
            }
        }

        public static (int, Toggle) GetSelectedToggle(this ToggleGroup toggleGroup)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                if (togglesList[i].isOn)
                {
                    return (i, togglesList[i]);
                }
            }

            Log.Error("none Toggle is Selected");
            return (-1, null);
        }

        public static void IsSelected(this Toggle toggle, bool isSelected)
        {
            // Toggle Group 的 Allow Switch Off 默认设置为false时，会自动设置一个Toggle.isOn = true，不触发回调
            // Toggle.isOn 只有改变才会触发回调，如果Toggle.isOn原本为true，那么isSelected=true不会触发回调
            // 所以这里要主动去触发下，但是要避免一种情况，Toggle.isOn由false->ture的时候不要主动触发，否则会触发2次
            if (toggle.isOn && isSelected)
            {
                toggle.onValueChanged?.Invoke(true);
            }

            toggle.isOn = isSelected;
        }

        public static void RemoveUIScrollItems<K, T>(this K self, ref Dictionary<int, EntityRef<T>> dictionary) where K : Entity, IUILogic
                where T : Entity, IAwake, IUIScrollItem<T>
        {
            if (dictionary == null)
            {
                return;
            }

            foreach (var item in dictionary)
            {
                T value = item.Value;
                value?.Dispose();
            }

            dictionary.Clear();
            dictionary = null;
        }

        public static void GetUIComponent<T>(this ReferenceCollector rf, string key, ref T t) where T : class
        {
            GameObject obj = rf.Get<GameObject>(key);

            if (obj == null)
            {
                t = null;
                return;
            }

            t = obj.GetComponent<T>();
        }

        #endregion

        #region UI按钮事件

        public static void AddListenerAsyncWithId(this Button button, Func<int, ETTask> action, int id)
        {
            button.onClick.RemoveAllListeners();

            async ETTask clickActionAsync()
            {
                UIEventComponent.Instance?.SetUIClicked(true);
                await action(id);
                UIEventComponent.Instance?.SetUIClicked(false);
            }

            button.onClick.AddListener(() =>
            {
                if (UIEventComponent.Instance == null)
                {
                    return;
                }

                if (UIEventComponent.Instance.IsClicked)
                {
                    return;
                }

                clickActionAsync().Coroutine();
            });
        }

        public static void AddListenerAsync(this Button button, Func<ETTask> action)
        {
            button.onClick.RemoveAllListeners();

            async ETTask clickActionAsync()
            {
                UIEventComponent.Instance?.SetUIClicked(true);
                await action();
                UIEventComponent.Instance?.SetUIClicked(false);
            }

            button.onClick.AddListener(() =>
            {
                if (UIEventComponent.Instance == null)
                {
                    return;
                }

                // 防止客户端短时间内频繁的发RPC消息
                // if (UIEventComponent.Instance.IsClicked)
                // {
                //     return;
                // }

                clickActionAsync().Coroutine();
            });
        }

        public static void AddListener(this Toggle toggle, UnityAction<bool> selectEventHandler)
        {
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener(selectEventHandler);
        }

        public static void AddListener(this Button button, UnityAction clickEventHandler)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(clickEventHandler);
        }

        public static void AddListenerWithId(this Button button, Action<int> clickEventHandler, int id)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(id); });
        }

        public static void AddListenerWithId(this Button button, Action<long> clickEventHandler, long id)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(id); });
        }

        public static void AddListenerWithParam<T>(this Button button, Action<T> clickEventHandler, T param)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(param); });
        }

        public static void AddListenerWithParam<T, A>(this Button button, Action<T, A> clickEventHandler, T param1, A param2)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(param1, param2); });
        }

        public static void AddListener(this ToggleGroup toggleGroup, UnityAction<int> selectEventHandler, Func<int, bool> checkHandler = null)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>(true);
            for (int i = 0; i < togglesList.Length; i++)
            {
                int index = i;
                togglesList[i].AddListener((isOn) =>
                {
                    if (isOn)
                    {
                        if (checkHandler != null && !checkHandler(index))
                        {
                            return;
                        }

                        selectEventHandler(index);
                        OnSelect(togglesList[index].transform);
                    }
                });
            }

            return;

            void OnSelect(Transform transform)
            {
                foreach (Toggle toggle in togglesList)
                {
                    toggle.transform.Find("Background/XuanZhong").gameObject.SetActive(toggle.transform == transform);
                    toggle.transform.Find("Background/WeiXuanZhong").gameObject.SetActive(toggle.transform != transform);
                }
            }
        }

        public static void OnSelectIndex(this ToggleGroup toggleGroup, int index)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                if (i != index)
                {
                    continue;
                }

                togglesList[i].IsSelected(true);
            }
        }

        public static void SetClickEnabled(this ToggleGroup toggleGroup, bool enabled)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                togglesList[i].interactable = enabled;
            }
        }

        public static int GetCurrentIndex(this ToggleGroup toggleGroup)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                if (togglesList[i].isOn)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 注册窗口关闭事件
        /// </summary>
        /// <OtherParam name="self"></OtherParam>
        /// <OtherParam name="closeButton"></OtherParam>
        public static void RegisterCloseEvent<T>(this Entity self, Button closeButton, bool isClose = false) where T : Entity, IAwake, IUILogic
        {
            closeButton.onClick.RemoveAllListeners();
            if (isClose)
            {
                closeButton.onClick.AddListener(() =>
                {
                    self.Scene().GetComponent<UIComponent>().CloseWindow(self.GetParent<UIBaseWindow>().WindowID);
                });
            }
            else
            {
                closeButton.onClick.AddListener(() =>
                {
                    self.Scene().GetComponent<UIComponent>().HideWindow(self.GetParent<UIBaseWindow>().WindowID);
                });
            }
        }

        public static void RegisterEvent(this EventTrigger trigger, EventTriggerType eventType, UnityAction<BaseEventData> callback)
        {
            EventTrigger.Entry entry = null;

            // 查找是否已经存在要注册的事件
            foreach (EventTrigger.Entry existingEntry in trigger.triggers)
            {
                if (existingEntry.eventID == eventType)
                {
                    entry = existingEntry;
                    break;
                }
            }

            // 如果这个事件不存在，就创建新的实例
            if (entry == null)
            {
                entry = new EventTrigger.Entry();
                entry.eventID = eventType;
            }

            // 添加触发回调并注册事件
            entry.callback.AddListener(callback);
            trigger.triggers.Add(entry);
        }

        #endregion
    }
}