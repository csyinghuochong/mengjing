using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ET.Client
{
    public static class PunctuationCheckHelper
    {

        /// <summary>
        /// 获取指定行的文本内容
        /// </summary>
        private static string GetLineText(string fullText, int startIndex, int endIndex)
        {
            if (endIndex < startIndex || startIndex < 0 || endIndex >= fullText.Length)
                return "";

            int length = endIndex - startIndex + 1;
            return fullText.Substring(startIndex, length);
        }

        /// <summary>
        /// 判断一行是否只包含标点符号
        /// </summary>
        private static bool IsPunctuationOnlyLine(string line, string punctuationCharacters)
        {
            // 移除空白字符（空格、制表符等）
            string trimmedLine = RemoveWhiteSpaces(line);

            // 空行不算问题
            if (string.IsNullOrEmpty(trimmedLine))
                return false;

            // 检查每个字符是否都是标点符号
            foreach (char c in trimmedLine)
            {
                if (!punctuationCharacters.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 移除字符串中的所有空白字符
        /// </summary>
        private static string RemoveWhiteSpaces(string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }


        public static bool PunctuationCheck(Text uiText)
        {

            // 定义需要处理的标点符号
            string punctuations = "，。、！？；：（）「」『』【】《》.,!?;:()[]{}<>\"'";
            int problemLineCount = 0;
            List<string> problematicLines = new List<string>();

            // 确保文本布局更新
            Canvas.ForceUpdateCanvases();

            // 获取文本生成器信息
            TextGenerator generator = uiText.cachedTextGenerator;
            List<UILineInfo> lines = generator.lines as List<UILineInfo>;

            if (lines == null || lines.Count == 0)
                return false;

            // 遍历所有行
            for (int i = 0; i < lines.Count; i++)
            {
                // 获取当前行的起始索引和结束索引
                int startIndex = lines[i].startCharIdx;
                int endIndex = (i < lines.Count - 1) ?
                    lines[i + 1].startCharIdx - 1 :
                    uiText.text.Length - 1;

                // 提取当前行文本
                string lineText = GetLineText(uiText.text, startIndex, endIndex);

                // 检测是否整行只有标点符号
                if (IsPunctuationOnlyLine(lineText, punctuations))
                {
                    problemLineCount++;
                    problematicLines.Add(lineText);
                }
            }

            if ( problemLineCount > 0)
            {
                Debug.LogWarning($"检测到 {problemLineCount} 行纯标点符号行");
                foreach (string line in problematicLines)
                {
                    Debug.Log($"问题行: '{line}'");
                }
            }
            // 应用处理后的文本
            return problematicLines.Count > 0;
        }



        /// <summary>
        /// 检测单行中的中间空白
        /// </summary>
        private static void DetectWhitespaceInLine(string lineText, int globalStartIndex, int lineIndex, List<string> whitespaceLocations)
        {
            // 移除行首和行尾空白
            string trimmedLine = lineText.TrimStart().TrimEnd();
            int trimStartCount = lineText.Length - lineText.TrimStart().Length;
            int trimEndCount = lineText.Length - lineText.TrimEnd().Length;

            // 计算中间内容的起始和结束位置
            int middleStart = trimStartCount;
            int middleEnd = lineText.Length - trimEndCount - 1;

            // 遍历行中间部分
            for (int i = middleStart; i <= middleEnd; i++)
            {
                char c = lineText[i];

                // 检查是否是目标空白字符
                if (IsTargetWhitespace(c))
                {
                    // 记录位置信息
                    whitespaceLocations.Add(lineText);
                }
            }
        }

        /// <summary>
        /// 判断字符是否是目标空白类型
        /// </summary>
        private static bool IsTargetWhitespace(char c)
        {
            if (c == ' ') return true;
            if (c == '\t' ) return true;
            if (c == '\u00A0' ) return true; // 不换行空格
            return false;
        }

        /// <summary>
        /// 获取空白字符的名称
        /// </summary>
        private static string GetWhitespaceName(char c)
        {
            switch (c)
            {
                case ' ': return "空格";
                case '\t': return "制表符";
                case '\u00A0': return "不换行空格";
                default: return c.ToString();
            }
        }

      
        public static bool DetectMiddleWhitespace(Text uiText)
        {
            int problemCount = 0;
            List<string> whitespaceLocations = new List<string>();
            whitespaceLocations.Clear();

            if (string.IsNullOrEmpty(uiText.text))
                return false;

            // 确保文本布局更新
            Canvas.ForceUpdateCanvases();

            // 获取文本生成器信息
            TextGenerator generator = uiText.cachedTextGenerator;
            List<UILineInfo> lines = generator.lines as List<UILineInfo>;

            if (lines == null || lines.Count == 0)
                return false;

            // 遍历所有行
            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                // 获取当前行的起始索引和结束索引
                int startIndex = lines[lineIndex].startCharIdx;
                int endIndex = (lineIndex < lines.Count - 1) ?
                    lines[lineIndex + 1].startCharIdx - 1 :
                    uiText.text.Length - 1;

                // 获取行文本
                string lineText = GetLineText(uiText.text, startIndex, endIndex);

                // 跳过空行
                if (string.IsNullOrWhiteSpace(lineText))
                    continue;

                // 检测行内空白
                DetectWhitespaceInLine(lineText, startIndex, lineIndex, whitespaceLocations);
            }

            // 输出检测结果
            if ( problemCount > 0)
            {
                Debug.LogWarning($"检测到 {problemCount} 处行内空白问题");
                foreach (var location in whitespaceLocations)
                {
                    Debug.Log($"位置 {location} ");
                }
            }
            return problemCount > 0;
        }
    }
}