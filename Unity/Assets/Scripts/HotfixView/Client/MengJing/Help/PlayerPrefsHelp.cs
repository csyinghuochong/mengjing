﻿using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static class PlayerPrefsHelp
    {
        public const string MyServerID = "WJa_MyServerID";
        public const string LastUserID = "WJa_LastUserID";
        public const string LastGuide = "WJa_LastGuide_0";
        public const string LastFrame = "WJa_LastFrame_0";
        public const string MusicVolume = "MusicVolume";
        public const string SoundVolume = "SoundVolume";
        public const string SkillPostion = "WJa_SkillPostion";
        public const string WJa_LastNotice = "WJa_LastNotice";
        public const string MyOldServerID = "WJa_MyOldServerID";
        public const string LastLoginType = "WJa_LastLoginType";
        public const string LoginErrorTime = "WJa_LoginErrorTime";
        public const string ChapterDifficulty = "WJa_ChapterDifficulty";
        public const string LenDepth = "WJa_LenDepth";
        public const string RotaAngle = "WJa_RotaAngle";
        public const string ZhuBo = "WJa_ZhuBo";

        public static string LastAccount(string loginType)
        {
            return $"WJa_LastAccount_{loginType}";
        }

        public static string LastPassword(string loginType)
        {
            return $"WJa_LastPassword_{loginType}";
        }

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public static int GetInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        public static float GetFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }

        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public static string GetString(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public static List<int> GetOldServerIds()
        {
            List<int> serverids = new List<int>();
            string oldservers = GetString(MyOldServerID);
            if (string.IsNullOrEmpty(oldservers))
            {
                return serverids;
            }

            string[] serverstr = oldservers.Split('@');
            for (int i = 0; i < serverstr.Length; i++)
            {
                serverids.Add(int.Parse(serverstr[i]));
            }

            return serverids;
        }

        public static void SetOldServerIds(int serverid)
        {
            string oldservers = GetString(MyOldServerID);
            if (string.IsNullOrEmpty(oldservers))
            {
                oldservers = serverid.ToString();
            }
            else
            {
                List<int> serveridlist = new List<int>();
                string[] serverstr = oldservers.Split('@');
                for (int i = 0; i < serverstr.Length; i++)
                {
                    serveridlist.Add(int.Parse(serverstr[i]));
                }

                if (serveridlist.Contains(serverid))
                {
                    serveridlist.Remove(serverid);
                }

                serveridlist.Add((int)serverid);
                if (serveridlist.Count > 6)
                {
                    serveridlist.RemoveAt(0);
                }

                oldservers = string.Empty;
                for (int i = 0; i < serveridlist.Count; i++)
                {
                    oldservers = $"{oldservers}{serveridlist[i]}@";
                }

                oldservers = oldservers.Substring(0, oldservers.Length - 1);
            }

            SetString(MyOldServerID, oldservers);
        }

        public static int GetChapterDifficulty(string chapterid)
        {
            string difficultyinfo = GetString(ChapterDifficulty);
            if (string.IsNullOrEmpty(difficultyinfo))
            {
                return 1;
            }

            string[] difficultylist = difficultyinfo.Split('@');
            for (int i = 0; i < difficultylist.Length; i++)
            {
                string[] chapterinfo = difficultylist[i].Split(';');
                if (chapterinfo[0] == chapterid)
                {
                    return int.Parse(chapterinfo[1]);
                }
            }

            return 1;
        }

        public static void SetChapterDifficulty(string chapterid, int difficulty)
        {
            string difficultyinfo = GetString(ChapterDifficulty);
            if (string.IsNullOrEmpty(difficultyinfo))
            {
                difficultyinfo = $"{chapterid};{difficulty}";
                SetString(ChapterDifficulty, difficultyinfo);
                return;
            }

            string[] difficultylist = difficultyinfo.Split('@');
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            for (int i = 0; i < difficultylist.Length; i++)
            {
                string[] chapterinfo = difficultylist[i].Split(';');
                keyValuePairs.Add(chapterinfo[0], int.Parse(chapterinfo[1]));
            }

            if (!keyValuePairs.ContainsKey(chapterid))
            {
                keyValuePairs.Add(chapterid, difficulty);
            }
            else
            {
                keyValuePairs[chapterid] = difficulty;
            }

            difficultyinfo = string.Empty;
            foreach (var item in keyValuePairs)
            {
                difficultyinfo += $"{item.Key};{item.Value}@";
            }

            if (difficultyinfo.Length > 0)
            {
                difficultyinfo = difficultyinfo.Substring(0, difficultyinfo.Length - 1);
            }

            SetString(ChapterDifficulty, difficultyinfo);
        }
    }
}