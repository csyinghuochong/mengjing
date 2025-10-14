using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;

/// <summary>
/// 改进的 Text 组件，解决中文排版中空格导致错误换行及行首出现标点符号的问题
/// 避免了图形重建循环和无限处理循环
/// </summary>
public class ImprovedText : Text
{
    /// <summary>
    /// 用于匹配常见的中文标点符号（正则表达式）
    /// 可根据需要增删标点
    /// </summary>
    private readonly string punctuationRegex = @"[，。！？；：""''""""（）【】《》…、]";
    
    private bool isProcessingText = false;
    private string lastProcessedText = "";
    private Vector2 lastSize;
    private bool isLayoutDirty = true;
    private Coroutine delayedProcessingCoroutine;
    private int processingIterations = 0;
    private const int MAX_PROCESSING_ITERATIONS = 3;

    // 公共属性，允许外部设置文本
    public new string text
    {
        get => base.text;
        set
        {
            if (base.text != value)
            {
                base.text = value;
                isLayoutDirty = true;
                processingIterations = 0;
                MarkLayoutForRebuild();
            }
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        isLayoutDirty = true;
        processingIterations = 0;
        // 延迟一帧确保布局已计算
        if (gameObject.activeInHierarchy)
        {
            delayedProcessingCoroutine = StartCoroutine(DelayedProcessText());
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (delayedProcessingCoroutine != null)
        {
            StopCoroutine(delayedProcessingCoroutine);
            delayedProcessingCoroutine = null;
        }
        processingIterations = 0;
    }

    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
        // 当RectTransform尺寸变化时，标记需要重新处理文本
        if (!isProcessingText)
        {
            isLayoutDirty = true;
            processingIterations = 0;
        }
    }

    private void MarkLayoutForRebuild()
    {
        if (isProcessingText) return;
        
        isLayoutDirty = true;
        
        // 如果已经在活动状态，立即处理
        if (gameObject.activeInHierarchy && isActiveAndEnabled)
        {
            if (delayedProcessingCoroutine != null)
            {
                StopCoroutine(delayedProcessingCoroutine);
            }
            delayedProcessingCoroutine = StartCoroutine(DelayedProcessText());
        }
    }

    private IEnumerator DelayedProcessText()
    {
        // 等待一帧，确保布局已计算
        yield return null;
        
        if (isLayoutDirty && !isProcessingText && processingIterations < MAX_PROCESSING_ITERATIONS)
        {
            ProcessTextLayout();
        }
        
        delayedProcessingCoroutine = null;
    }

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        // 如果正在处理文本，使用基类方法避免干扰
        if (isProcessingText)
        {
            base.OnPopulateMesh(toFill);
            return;
        }

        // 检查是否需要重新处理文本布局
        Vector2 currentSize = rectTransform.rect.size;
        if (isLayoutDirty || lastSize != currentSize)
        {
            lastSize = currentSize;
            
            // 使用协程延迟处理，避免在OnPopulateMesh中直接修改
            if (gameObject.activeInHierarchy && isActiveAndEnabled && delayedProcessingCoroutine == null)
            {
                delayedProcessingCoroutine = StartCoroutine(DelayedProcessText());
            }
        }

        base.OnPopulateMesh(toFill);
    }

    /// <summary>
    /// 处理文本布局，确保标点符号不在行首
    /// </summary>
    private void ProcessTextLayout()
    {
        if (isProcessingText || string.IsNullOrEmpty(text))
            return;

        // 检查是否达到最大处理迭代次数
        if (processingIterations >= MAX_PROCESSING_ITERATIONS)
        {
            Debug.LogWarning("ImprovedText: 达到最大处理迭代次数，停止处理以避免无限循环");
            isLayoutDirty = false;
            return;
        }

        // 检查文本和尺寸是否与上次处理时相同
        Vector2 currentSize = rectTransform.rect.size;
        if (!isLayoutDirty && lastProcessedText == text && lastSize == currentSize)
            return;

        isProcessingText = true;
        processingIterations++;
        
        try
        {
            // 获取文本生成器设置
            var settings = GetGenerationSettings(currentSize);
            
            // 使用TextGenerator预计算文本布局
            TextGenerator generator = new TextGenerator();
            bool success = generator.Populate(text, settings);
            
            if (!success)
            {
                // 如果预计算失败，直接使用原始文本
                lastProcessedText = text;
                isLayoutDirty = false;
                return;
            }
            
            IList<UILineInfo> lines = generator.lines;
            
            // 如果只有一行，不需要处理
            if (lines.Count <= 1)
            {
                lastProcessedText = text;
                isLayoutDirty = false;
                return;
            }

            StringBuilder processedText = new StringBuilder(text);
            bool textModified = false;
            bool foundLineStartPunctuation = false;

            // 从第二行开始检查（第一行不需要检查行首标点）
            for (int i = 1; i < lines.Count; i++)
            {
                int lineStartIndex = lines[i].startCharIdx;

                // 确保索引在文本范围内
                if (lineStartIndex >= processedText.Length || lineStartIndex < 0)
                    continue;

                // 检查行首字符是否为标点
                if (Regex.IsMatch(processedText[lineStartIndex].ToString(), punctuationRegex))
                {
                    foundLineStartPunctuation = true;
                    
                    // 找到前一行最后一个非空格、非换行符的字符位置
                    int prevLineEndIndex = FindPreviousLineEnd(processedText, lineStartIndex);
                    
                    if (prevLineEndIndex > 0 && prevLineEndIndex < processedText.Length - 1)
                    {
                        // 检查是否已经在正确位置有换行符
                        bool hasNewlineAtCorrectPosition = false;
                        for (int j = prevLineEndIndex + 1; j < processedText.Length && j <= prevLineEndIndex + 2; j++)
                        {
                            if (j < processedText.Length && processedText[j] == '\n')
                            {
                                hasNewlineAtCorrectPosition = true;
                                break;
                            }
                        }
                        
                        if (!hasNewlineAtCorrectPosition)
                        {
                            // 在合适位置插入换行符，强制提前换行
                            processedText.Insert(prevLineEndIndex + 1, '\n');
                            textModified = true;
                            
                            // 修改后需要重新计算，所以跳出循环
                            break;
                        }
                    }
                }
            }

            // 如果修改了文本，重新设置
            if (textModified)
            {
                string newText = processedText.ToString();
                if (newText != base.text)
                {
                    base.text = newText;
                    // 如果仍然发现行首标点，可能需要再次检查
                    isLayoutDirty = foundLineStartPunctuation;
                }
                else
                {
                    isLayoutDirty = false;
                }
                
                lastProcessedText = base.text;
                
                // 如果需要继续处理，再次调度
                if (isLayoutDirty && gameObject.activeInHierarchy && isActiveAndEnabled)
                {
                    if (delayedProcessingCoroutine != null)
                    {
                        StopCoroutine(delayedProcessingCoroutine);
                    }
                    delayedProcessingCoroutine = StartCoroutine(DelayedProcessText());
                }
            }
            else
            {
                isLayoutDirty = false;
                lastProcessedText = text;
            }
        }
        finally
        {
            isProcessingText = false;
        }
    }

    /// <summary>
    /// 查找前一行的结尾位置（最后一个非空白字符）
    /// </summary>
    private int FindPreviousLineEnd(StringBuilder text, int currentLineStart)
    {
        // 从当前行起始位置向前搜索，找到前一行的结尾
        int lineStart = currentLineStart;
        
        // 跳过当前行开头的空白字符
        while (lineStart > 0 && char.IsWhiteSpace(text[lineStart - 1]))
        {
            lineStart--;
        }
        
        // 继续向前找到前一行的最后一个非空白字符
        for (int i = lineStart - 1; i >= 0; i--)
        {
            if (!char.IsWhiteSpace(text[i]))
            {
                // 确保我们不会在单词中间断开
                // 向前查找一个合适的断开位置（空格或标点）
                for (int j = i; j >= 0; j--)
                {
                    if (char.IsWhiteSpace(text[j]) || Regex.IsMatch(text[j].ToString(), punctuationRegex))
                    {
                        return j;
                    }
                }
                return i;
            }
        }
        
        return -1;
    }

    /// <summary>
    /// 强制立即重新处理文本布局
    /// </summary>
    public void ForceRebuildLayout()
    {
        isLayoutDirty = true;
        processingIterations = 0;
        if (gameObject.activeInHierarchy && isActiveAndEnabled)
        {
            if (delayedProcessingCoroutine != null)
            {
                StopCoroutine(delayedProcessingCoroutine);
            }
            delayedProcessingCoroutine = StartCoroutine(DelayedProcessText());
        }
    }

    /// <summary>
    /// 添加标点符号到避头规则
    /// </summary>
    public void AddPunctuation(string punctuation)
    {
        if (!punctuationRegex.Contains(punctuation))
        {
            // 这里可以扩展实现动态添加标点符号
            // 当前版本使用固定的正则表达式
            Debug.LogWarning("动态添加标点符号功能需要扩展实现");
        }
    }
    
    /// <summary>
    /// 重置处理状态，用于调试
    /// </summary>
    public void ResetProcessingState()
    {
        processingIterations = 0;
        isLayoutDirty = true;
        lastProcessedText = "";
    }
}