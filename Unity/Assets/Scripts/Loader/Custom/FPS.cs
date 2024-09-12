using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using ET;

[Obfuscation(Exclude = true)]
class FPS : MonoBehaviour
{
    void Update()
    {
        UpdateTick();
    }

    private void Awake()
    {
        TextFps = this.gameObject.GetComponent<Text>();
        mLastFrameTime = TimeHelper.ClientNow();
    }

    //void OnGUI()
    //{
    //    DrawFps();
    //}

    //private void DrawFps()
    //{
    //    GUI.color = new Color(0, 1, 0);
    //    GUI.Label(new Rect(500, 40, 64, 24), "帧数: " + mLastFps);
    //}

    private long mFrameCount = 0;
    private long mLastFrameTime = 0;
    static long mLastFps = 0;
    private static string fpsText_1 = "平均帧数: {0} ";
    private static string fpsText_2 = "帧数: {0}";
    private Text TextFps;

    private List<long> TickCount = new List<long>(); //三百帧取一个平均数

    private void UpdateTick()
    {
        mFrameCount++;
        long nCurTime = TimeHelper.ClientNow();
       
        if ((nCurTime - mLastFrameTime) >= 1000)
        {
            long fps = (long)(mFrameCount * 1.0f / ((nCurTime - mLastFrameTime) / 1000.0f));

            mLastFps = fps;

            mFrameCount = 0;

            mLastFrameTime = nCurTime;
            TickCount.Add(fps);
        }

        if (TickCount.Count > 60)
        {
            long totalFps = 0;
            for (int i = 0; i < TickCount.Count; i++)
            {
                totalFps += TickCount[i];
            }

            totalFps = totalFps / TickCount.Count;
            TickCount.Clear();

            using (zstring.Block())
            {
                this.TextFps.text = zstring.Format(fpsText_1, totalFps);
            }
        }
        else
        {
            using (zstring.Block())
            {
                this.TextFps.text  = zstring.Format(fpsText_2, mLastFps);
            }
        }
    }

    public static long TickToMilliSec(long tick)
    {
        return tick / (10 * 1000);
    }
}