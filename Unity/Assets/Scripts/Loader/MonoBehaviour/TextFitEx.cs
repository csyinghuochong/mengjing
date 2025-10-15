using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TextFitEx : MonoBehaviour
{
    /// 标记不换行的空格（换行空格Unicode编码为/u0020，不换行的/u00A0）
    public static readonly string Non_breaking_space = "\u00A0";

    /// 用于匹配标点符号（正则表达式）
    private readonly string strPunctuation =  @"[.,。，、;；]" ;//@"\p{P}";

    /// 用于存储text组件中的内容
    private System.Text.StringBuilder TempText = null;
    
    private System.Text.StringBuilder OldTempText = null;

    /// 用于存储text生成器中的内容
    private IList<UILineInfo> TextLine;

    [SerializeField]
    private Text targetText;
    
    // 用于标记是否正在处理文本，避免无限循环
    private bool isProcessingText = false;

    private float lastUpdateTime = 0f;
    
    private Vector2 localposition = Vector2.zero;
    
    [SerializeField]
    private bool removeHuanHang = false;
    
    [SerializeField]
    private bool setposition = false;

    private int updateNumber = 0;
    
    [SerializeField]
    private bool onenableUpdate = false;

    void Awake()
    {
        if (this.enabled && this.setposition)
        {
            this.localposition = this.transform.localPosition;
            this.transform.localPosition = new Vector2( localposition.x, this.localposition.y + 1000 );
        }
        // 如果没有手动指定Text组件，自动获取
        if (targetText == null)
        {
            targetText = GetComponent<Text>();
        }
        
        if (targetText != null)
        {
            // 监听Text组件的顶点更新  [这个有问题 ，隐藏再打开刷新错乱]
            //targetText.RegisterDirtyVerticesCallback(OnTextChange);
        }
        else
        {
            Debug.LogError("TextFit: No Text component found!");
        }
    }

    void OnEnable()
    {
        if (targetText != null && this.onenableUpdate)
        {
            // 启用时立即处理一次文本
            StartCoroutine(ProcessTextAfterFrame());
        }
    }
    
    // 解决换行空格问题
    public void OnTextChange()
    {
        if (!this.enabled)
        {
           return;
        }
        
        if (isProcessingText) return;
        
        if (targetText != null && targetText.text.Contains(" "))
        {
            //targetText.text = targetText.text.Replace(" ", Non_breaking_space);
        }
        
        // 在文本变化后开始处理标点符号
        if (gameObject.activeInHierarchy)
        {
            this.lastUpdateTime = Time.time;
            StartCoroutine(ProcessTextAfterFrame());
        }
    }

    IEnumerator ProcessTextAfterFrame()
    {
        yield return new WaitForEndOfFrame();
        StartCoroutine(ClearUpPunctuationMode());
    }

    // 解决首字符出现标点问题
    IEnumerator ClearUpPunctuationMode()
    {
        if (isProcessingText || targetText == null) yield break;
        
        isProcessingText = true;

        // 必须等当前帧跑完后，不然如果在运行text显示的时候对显示内容进行修改会报错
        yield return new WaitForEndOfFrame();
        
        bool debuglog = false;
        if (this.targetText.text.Contains(("若用户继续使用长沙萤火信息科技有限公司所提供的相关产品或服务")))
        {
            //debuglog = true;
            //Debug.LogError("this.targetText.text: " +  this.targetText.text);
        }

        // 清除上一次添加的换行符号
        if (removeHuanHang)
        {
            targetText.text = targetText.text.Replace("\n", string.Empty);
        }

        // 获取TextGenerator的行信息
        var textGenerator = targetText.cachedTextGenerator;
        if (textGenerator == null)
        {
            isProcessingText = false;
            yield break;
        }

        TextLine = textGenerator.lines;
        
        // 需要改变的字符序号
        int ChangeIndex = -1;
        TempText = new System.Text.StringBuilder(targetText.text);
        
        for (int i = 1; i < TextLine.Count; i++)
        {
            // 检查索引是否有效
            if (TextLine[i].startCharIdx >= TempText.Length) continue;

            string lingsterr = string.Empty;
            if (i < this.TextLine.Count - 1)
            {
                int startchatindex = TextLine[i].startCharIdx;
                int endchatindex = TextLine[i + 1].startCharIdx;
                for (int linexxx =startchatindex; linexxx< endchatindex; linexxx++ )
                {
                    lingsterr += TempText[linexxx];
                }
            }

            string ccc = TempText[TextLine[i].startCharIdx].ToString();
            
            // 首位是否有标点
            bool IsPunctuation = Regex.IsMatch(ccc, strPunctuation);
            
            if (debuglog)
            {
                //Debug.LogError($"行： {i}   {lingsterr}");
            }
            if (debuglog && IsPunctuation)
            {
                //Debug.LogError($"行首符号： {i}    {ccc}");
            }

            // 因为将换行空格都改成不换行空格后需要另外判断下如果首字符是不换行空格那么还是需要调整换行字符的下标
            if (TempText[TextLine[i].startCharIdx].ToString() == Non_breaking_space)
            {
                IsPunctuation = true;
            }

            // 没有标点就跳过本次循环
            if (!IsPunctuation)
            {
                continue;
            }
            else
            {
                //Debug.LogError($"句首有符号： {targetText.text}");
                
                // 有标点时保存当前下标
                ChangeIndex = TextLine[i].startCharIdx;
                
                // 下面这个循环是为了判断当已经提前一个字符后当前这个的首字符还是标点时做的继续提前字符的处理
                while (IsPunctuation)
                {
                    ChangeIndex = ChangeIndex - 1;
                    if (ChangeIndex < 0) break;

                    IsPunctuation = Regex.IsMatch(TempText[ChangeIndex].ToString(), strPunctuation);
                    
                    // 因为将换行空格都改成不换行空格后需要另外判断下如果首字符是不换行空格那么还是需要调整换行字符的下标
                    if (TempText[ChangeIndex].ToString() == Non_breaking_space)
                    {
                        IsPunctuation = true;
                    }
                }
                
                if (ChangeIndex < 0) continue;

                // 确保索引有效且不在行首插入换行
                if (ChangeIndex > 0 && TempText[ChangeIndex - 1] != '\n')
                {
                    TempText.Insert(ChangeIndex, "\n");
                    
                    break;
                }
            }
        }

        targetText.text = TempText.ToString();
        isProcessingText = false;
        if (this.updateNumber <= 1)
        {
            this.OnTextChange();
            this.updateNumber++;
        }

        if (this.setposition)
        {
            this.transform.localPosition = this.localposition;
        }

    }

    // 公开方法用于手动刷新文本
    public void RefreshText()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ProcessTextAfterFrame());
        }
    }

    // 设置目标文本内容
    public void SetText(string text)
    {
        if (targetText != null)
        {
            targetText.text = text;
            RefreshText();
        }
    }

    // 获取目标文本内容
    public string GetText()
    {
        return targetText != null ? targetText.text : string.Empty;
    }

    void OnDestroy()
    {
        if (targetText != null)
        {
            // 清理注册的回调
            targetText.UnregisterDirtyVerticesCallback(OnTextChange);
        }
    }
}