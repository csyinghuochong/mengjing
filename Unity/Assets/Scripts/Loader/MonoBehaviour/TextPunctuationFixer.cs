using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextPunctuationFixer : MonoBehaviour
{
    [Tooltip("需要处理的标点符号列表")]
    public char[] punctuationMarks = { '，', '。', '、', '：', '；', '！', '？', '”', '’', '）' };

    private Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    private void OnEnable()
    {
        // 注册文本改变事件
        textComponent.RegisterDirtyVerticesCallback(FixPunctuation);
        // 初始修正一次
        FixPunctuation();
    }

    private void OnDisable()
    {
        // 取消注册事件
        textComponent.UnregisterDirtyVerticesCallback(FixPunctuation);
    }

    /// <summary>
    /// 修正文本中的标点符号位置
    /// </summary>
    public void FixPunctuation()
    {
        if (textComponent == null || string.IsNullOrEmpty(textComponent.text))
            return;

        string originalText = textComponent.text;
        string fixedText = FixLeadingPunctuation(originalText);

        // 只有当文本有变化时才更新，避免无限循环
        if (fixedText != originalText)
        {
            textComponent.text = fixedText;
        }
    }

    /// <summary>
    /// 处理文本中所有行首的标点符号，将其移动到前一行末尾
    /// </summary>
    private string FixLeadingPunctuation(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        // 使用换行符分割文本为行
        string[] lines = text.Split(new[] { '\n' }, System.StringSplitOptions.None);
        
        // 从第二行开始检查（第一行前面没有内容）
        for (int i = 1; i < lines.Length; i++)
        {
            string currentLine = lines[i];
            if (string.IsNullOrEmpty(currentLine))
                continue;

            // 检查当前行首是否为需要处理的标点
            char firstChar = currentLine[0];
            if (System.Array.IndexOf(punctuationMarks, firstChar) != -1)
            {
                // 将标点从当前行移除
                string newCurrentLine = currentLine.Substring(1).TrimStart();
                
                // 将标点添加到前一行末尾
                lines[i - 1] = lines[i - 1].TrimEnd() + firstChar;
                lines[i] = newCurrentLine;
            }
        }

        // 重新组合所有行
        return string.Join("\n", lines);
    }
}
