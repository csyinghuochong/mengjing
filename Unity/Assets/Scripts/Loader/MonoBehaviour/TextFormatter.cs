using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TextFormatter : MonoBehaviour
{
    [Header("文本格式化设置")]
    [SerializeField] private UnityEngine.UI.Text targetText;
    [SerializeField] private int maxLineLength = 30; // 每行最大字符数
    [SerializeField] private bool formatOnStart = true;
    
    // 标点符号集合（可根据需要扩展）
    private static readonly HashSet<char> PunctuationMarks = new HashSet<char>
    {
        '。', '，', '！', '？', '；', '：', '、', '」', '』', '》', '）', '】', '〕', '〉',
        '.', ',', '!', '?', ';', ':', ')', ']', '}', '>', '"', '\'', '`', '~'
    };

    void Start()
    {
        if (formatOnStart && targetText != null)
        {
            FormatText(targetText.text);
        }
    }

    /// <summary>
    /// 格式化文本
    /// </summary>
    public void FormatText(string originalText)
    {
        if (targetText == null) return;
        
        string formattedText = FormatTextContent(originalText, maxLineLength);
        targetText.text = formattedText;
    }

    /// <summary>
    /// 核心文本格式化方法
    /// </summary>
    public static string FormatTextContent(string text, int lineLength)
    {
        if (string.IsNullOrEmpty(text)) return text;

        // 按原换行符分割文本
        string[] originalParagraphs = text.Split('\n');
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < originalParagraphs.Length; i++)
        {
            if (i > 0) result.Append('\n');
            
            string paragraph = originalParagraphs[i].Trim();
            if (string.IsNullOrEmpty(paragraph)) continue;
            
            string formattedParagraph = FormatSingleParagraph(paragraph, lineLength);
            result.Append(formattedParagraph);
        }

        return result.ToString();
    }

    /// <summary>
    /// 格式化单个段落
    /// </summary>
    private static string FormatSingleParagraph(string paragraph, int lineLength)
    {
        StringBuilder currentLine = new StringBuilder();
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < paragraph.Length; i++)
        {
            char currentChar = paragraph[i];
            
            // 如果当前字符是换行符，直接换行
            if (currentChar == '\n')
            {
                if (currentLine.Length > 0)
                {
                    result.AppendLine(currentLine.ToString());
                    currentLine.Clear();
                }
                continue;
            }

            currentLine.Append(currentChar);

            // 检查是否需要换行
            if (ShouldBreakLine(currentLine, paragraph, i, lineLength))
            {
                // 处理标点符号在行首的情况
                string line = HandlePunctuationAtLineStart(currentLine, paragraph, i);
                
                if (!string.IsNullOrEmpty(line))
                {
                    result.AppendLine(line);
                }
                
                currentLine.Clear();
                
                // 如果下一个字符是标点，提前添加到新行（避免标点出现在行首）
                if (i + 1 < paragraph.Length && IsPunctuation(paragraph[i + 1]))
                {
                    // 不添加，等待下一个循环处理
                }
            }
        }

        // 添加最后一行
        if (currentLine.Length > 0)
        {
            string lastLine = currentLine.ToString().Trim();
            if (!string.IsNullOrEmpty(lastLine))
            {
                result.Append(lastLine);
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// 判断是否应该换行
    /// </summary>
    private static bool ShouldBreakLine(StringBuilder currentLine, string paragraph, int currentIndex, int lineLength)
    {
        // 如果当前行长度达到限制
        if (currentLine.Length >= lineLength)
        {
            // 检查下一个字符是否是标点，如果是则提前换行
            if (currentIndex + 1 < paragraph.Length && IsPunctuation(paragraph[currentIndex + 1]))
            {
                return true;
            }
            
            // 如果当前字符是标点，也考虑换行
            if (IsPunctuation(paragraph[currentIndex]))
            {
                return true;
            }
            
            // 查找合适的分割点
            for (int j = currentLine.Length - 1; j > currentLine.Length - 10 && j > 0; j--)
            {
                if (IsNaturalBreakPoint(currentLine[j]))
                {
                    return true;
                }
            }
            
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// 处理行首标点符号
    /// </summary>
    private static string HandlePunctuationAtLineStart(StringBuilder currentLine, string paragraph, int currentIndex)
    {
        string line = currentLine.ToString();
        
        // 如果行长度很短，可能是标点符号导致的提前换行，尝试调整
        if (line.Length < 5 && currentIndex + 1 < paragraph.Length)
        {
            // 检查是否大部分字符都是标点
            int punctuationCount = 0;
            foreach (char c in line)
            {
                if (IsPunctuation(c)) punctuationCount++;
            }
            
            if (punctuationCount >= line.Length * 0.6f)
            {
                // 尝试将下一行的第一个字符（如果是文字）合并到当前行
                char nextChar = paragraph[currentIndex + 1];
                if (!IsPunctuation(nextChar))
                {
                    line += nextChar;
                    currentLine.Append(nextChar);
                }
            }
        }

        return line.Trim();
    }

    /// <summary>
    /// 判断字符是否是标点符号
    /// </summary>
    private static bool IsPunctuation(char c)
    {
        return PunctuationMarks.Contains(c) || char.IsPunctuation(c);
    }

    /// <summary>
    /// 判断是否是自然断点
    /// </summary>
    private static bool IsNaturalBreakPoint(char c)
    {
        return IsPunctuation(c) || c == ' ' || c == '\t';
    }

    /// <summary>
    /// 手动设置目标文本组件
    /// </summary>
    public void SetTargetText(UnityEngine.UI.Text textComponent)
    {
        targetText = textComponent;
    }

    /// <summary>
    /// 手动触发文本格式化
    /// </summary>
    public void TriggerFormat()
    {
        if (targetText != null)
        {
            FormatText(targetText.text);
        }
    }

    /// <summary>
    /// 静态方法：直接格式化字符串
    /// </summary>
    public static string FormatString(string text, int lineLength = 30)
    {
        return FormatTextContent(text, lineLength);
    }
}