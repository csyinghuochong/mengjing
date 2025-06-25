using System;
using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public static class CommonViewHelper
    {

        public static string GetMonsterShowName(int babaType)
        {
            if (babaType == 1)
            {
                return "(宝宝)";
            }
            
            if (babaType == 2)
            {
                return "(变异宝宝)";
            }
            
            return  string.Empty;
        }

          public static string ZhuaPuProToStr(int par)
          {
              float pro = (float)par / 10000f;
              string str = "抓捕难度:";
              if (pro <= 0.05f) {
                  str += "万里挑一";
              }
              if (pro > 0.05f && pro <= 0.1f)
              {
                  str += "千载难逢";
              }
              if (pro > 0.1f && pro <= 0.2f)
              {
                  str += "百不一遇";
              }
              if (pro > 0.2f && pro <= 0.3f)
              {
                  str += "一般";
              }
              if (pro > 0.3f)
              {
                  str += "容易";
              }
              return str;
          }
        
        /// <summary>
        /// 打印机效果
        /// </summary>
        /// <param name="root"></param>
        /// <param name="text"></param>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="time">间隔多少ms出现一个字</param>
        public static async ETTask TextPrinter(Scene root, Text text, string content, ETCancellationToken cancellationToken, long time)
        {
            for (int i = 0; i <= content.Length; ++i)
            {
                if (text == null)
                {
                    return;
                }

                text.text = content.Substring(0, i);

                await root.GetComponent<TimerComponent>().WaitAsync(time, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    if (text == null)
                    {
                        return;
                    }

                    text.text = content;
                    return;
                }
            }
        }

        public static void ShowOccIcon(Scene root, GameObject gameObject, int occ)
        {
            gameObject.GetComponent<Image>().sprite = root.GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, occ.ToString()));
        }

        //播放UI音效
        public static void PlayUIMusic(string music)
        {
            if (!string.IsNullOrEmpty(music))
            {
                SoundComponent.Instance.PlayClip("UI/" + music, "mp3").Coroutine();
            }
        }

        public static void DOScale(Transform transform, Vector3 vector3, float time)
        {
            transform.DOScale(vector3, time).SetEase(Ease.OutCubic);
        }

        public static void TargetFrameRate(int frame)
        {
            Application.targetFrameRate = frame;
        }

        public static string GetNeedItemDesc(string needitems)
        {
            string itemDesc = "";
            string[] needList = needitems.Split('@');

            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
                itemDesc += $"{itemConfig.ItemName} x {itemNum} ";
            }

            return itemDesc;
        }

        public static string ShowFloatValue(float value)
        {
            string svalue = value.ToString("0.##");
            return svalue;
        }

        public static string GetPetQualityName(int quality)
        {
            switch (quality)
            {
                case 1:
                    return "大众";
                //break;
                case 2:
                    return "优秀";
                //break;
                case 3:
                    return "百里挑一";
                //break;
                case 4:
                    return "千载难逢";
                //break;
                case 5:
                    return "万众瞩目";
                //break;
            }

            return "";
        }

        //数字转换万
        public static string NumToWString(long num)
        {
            //超过10万才显示
            if (num >= 100000)
            {
                if (num % 10000 == 0)
                {
                    return (num / 10000).ToString() + "万";
                }
                else
                {
                    return ((float)num / 10000f).ToString("F2") + "万";
                }
            }
            else
            {
                return num.ToString();
            }
        }

        // 根据品质返回一个Color
        public static Color QualityReturnColor(int ItenQuality)
        {
            Color color = new Color(1, 1, 1);
            switch (ItenQuality)
            {
                case 1:
                    color = new Color(1, 1, 1);
                    break;

                case 2:
                    color = new Color(0, 1, 0);
                    break;
                case 3:
                    color = new Color(0.047f, 0.76f, 0.847f);
                    break;

                case 4:
                    color = new Color(0.937f, 0.5f, 1.0f);
                    break;
                case 5:
                    color = new Color(1, 0.49f, 0);
                    break;
                case 6:
                    color = new Color(0.80f, 0.49f, 0.19f);
                    break;
            }

            return color;
        }

        public static void SetParent(GameObject son, GameObject parent)
        {
            if (son == null || parent == null)
                return;
            son.transform.SetParent(parent.transform);
            son.transform.localPosition = Vector3.zero;
            son.transform.localScale = Vector3.one;
        }

        public static void DestoryChild(GameObject go)
        {
            if (go == null)
                return;

            for (int i = go.transform.childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.Destroy(go.transform.GetChild(i).gameObject);
            }
        }

        public static void HideChildren(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        public static void SetImageGray(Scene root, GameObject obj, bool val)
        {
            // 方案一
            if (val)
             {
                 Material mat = root.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
                 obj.GetComponent<Image>().material = mat;
             }
             else
             {
                 obj.GetComponent<Image>().material = null;
             }
            
            // 方案2
            //UIEffect effect = obj.GetComponent<UIEffect>();
            //if (effect == null)
            //{
            //    effect = obj.AddComponent<UIEffect>();
            //}
            //if (val)
            //{
            //    effect.toneFilter = ToneFilter.Grayscale;
            //    effect.toneIntensity = 1f;
            //}
            //else
            //{
            //    effect.toneFilter = ToneFilter.None;
            //}
            //effect.SetVerticesDirty();
        }

        public static void SetImageGrayAllChild(Scene root, GameObject obj, bool val)
        {
            // 方案一
            // if (val)
            // {
            //     Material mat = root.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
            //     obj.GetComponent<Image>().material = mat;
            // }
            // else
            // {
            //     obj.GetComponent<Image>().material = null;
            // }

            SetImageGray(root, obj, val);
            
            // 方案2
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                Transform child = obj.transform.GetChild(i);

                SetImageGray(root, child.gameObject, val);
                
                Log.Debug($" child.gameObject:  { child.gameObject.name}");
                
                // 递归遍历子对象的子对象
                SetImageGrayAllChild(root, child.gameObject, val);
            }
        }
        
        public static void SetImageOutline(GameObject gameObject, bool val)
        {
            UIEffect effect = gameObject.GetComponent<UIEffect>();
            if (effect == null)
            {
                effect = gameObject.AddComponent<UIEffect>();
            }
            UIEffectTweener tweener = effect.GetComponent<UIEffectTweener>();

            if (val)
            {
                // 描边
                effect.shadowMode = ShadowMode.Outline8;
                effect.shadowDistance = new Vector2(2, -2);
                effect.shadowIteration = 2;
                effect.shadowColorFilter = ColorFilter.Replace;
                effect.shadowColor = new Color(255 / 255f, 235 / 255f, 0 / 255f, 1f);
                effect.shadowFade = 0.25f;
                
                // 一闪一闪
                effect.colorFilter = ColorFilter.Additive;
                effect.color = new Color(225 / 255f, 225 / 255f, 225 / 255f, 1f);
                if (tweener == null)
                {
                    tweener = gameObject.AddComponent<UIEffectTweener>();
                }
                tweener.enabled = true;
                tweener.cullingMask = UIEffectTweener.CullingMask.Color;
                tweener.curve = AnimationCurve.Linear(0.0f, 0.0f, 1f, 0.25f);
                tweener.interval = 0.5f;
                tweener.wrapMode = UIEffectTweener.WrapMode.PingPongLoop;
                effect.toneIntensity = 1f;
            }
            else
            {
                effect.shadowMode = ShadowMode.None;

                effect.colorFilter = ColorFilter.None;
                if (tweener != null)
                {
                    tweener.enabled = false;
                }
            }
            effect.SetVerticesDirty();
        }
        
        public static void SetRawImageGray(Scene root, GameObject obj, bool val)
        {
            // 方案1
            // if (val)
            // {
            //     Material mat = root.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
            //     obj.GetComponent<RawImage>().material = mat;
            // }
            // else
            // {
            //     obj.GetComponent<RawImage>().material = null;
            // }
            
            // 方案2
            UIEffect effect = obj.GetComponent<UIEffect>();
            if (effect == null)
            {
                effect = obj.AddComponent<UIEffect>();
            }
            if (val)
            {
                effect.toneFilter = ToneFilter.Grayscale;
            }
            else
            {
                effect.toneFilter = ToneFilter.None;
            }
            effect.SetVerticesDirty();
        }

        public static void CrossFadeAlpha(Transform transform, float alpha, float duration)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.GetComponent<Text>() != null)
                {
                    child.GetComponent<Text>().CrossFadeAlpha(alpha, duration, false);
                }

                if (child.GetComponent<Image>() != null)
                {
                    child.GetComponent<Image>().CrossFadeAlpha(alpha, duration, false);
                }
            }
        }

        public static async ETTask DOLocalMove(Scene root, Transform transform, Vector3 vector3, float totalTime)
        {
            Vector3 oldPostition = transform.localPosition;
            float passTime = 0;
            float starTime = Time.time;

            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            while (passTime < totalTime)
            {
                passTime = Time.time - starTime;
                float rate = passTime / totalTime;
                Vector3 curPostion = rate * (vector3 - oldPostition) + oldPostition;
                transform.transform.localPosition = curPostion;
                await timerComponent.WaitFrameAsync();
                if (transform == null)
                {
                    break;
                }
            }
        }
    }
}