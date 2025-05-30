﻿using System;
using System.Text.RegularExpressions;

namespace ET
{
    public class UnityLogger: ILog
    {
        
        private const int TraceLevel = 1;
        private const int DebugLevel = 2;
        private const int InfoLevel = 3;
        private const int WarningLevel = 4;
        
        public void Trace(string msg)
        {
            if (Options.Instance.LogLevel > TraceLevel)
            {
                return;
            }
            UnityEngine.Debug.Log(msg);
        }

        public void Debug(string msg)
        {
            if (Options.Instance.LogLevel > DebugLevel)
            {
                return;
            }
            UnityEngine.Debug.Log(msg);
        }

        public void Info(string msg)
        {
            if (Options.Instance.LogLevel > InfoLevel)
            {
                return;
            }
            UnityEngine.Debug.Log(msg);
        }

        public void Warning(string msg)
        {
            if (Options.Instance.LogLevel > WarningLevel)
            {
                return;
            }
            UnityEngine.Debug.LogWarning(msg);
        }

        public void Error(string msg)
        {
#if UNITY_EDITOR
            msg = Msg2LinkStackMsg(msg);
#endif
            UnityEngine.Debug.LogError(msg);
        }
        
        private static string Msg2LinkStackMsg(string msg)
        {
            msg = Regex.Replace(msg,@"at (.*?) in (.*?\.cs):(\w+)", match =>
            {
                string path = match.Groups[2].Value;
                string line = match.Groups[3].Value;
                return $"{match.Groups[1].Value}\n<a href=\"{path}\" line=\"{line}\">{path}:{line}</a>";
            });
            return msg;
        }

        public void Error(Exception e)
        {
            UnityEngine.Debug.LogException(e);
        }

        public void Trace(string message, params object[] args)
        {
            UnityEngine.Debug.LogFormat(message, args);
        }

        public void Warning(string message, params object[] args)
        {
            UnityEngine.Debug.LogWarningFormat(message, args);
        }

        public void Info(string message, params object[] args)
        {
            UnityEngine.Debug.LogFormat(message, args);
        }

        public void Debug(string message, params object[] args)
        {
            UnityEngine.Debug.LogFormat(message, args);
        }

        public void Error(string message, params object[] args)
        {
            UnityEngine.Debug.LogErrorFormat(message, args);
        }
    }
}