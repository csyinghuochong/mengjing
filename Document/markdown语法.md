# MarkDown基本语法

正式开始语法部分～

## 标题

```
# 标题名字（井号的个数代表标题的级数）
# 一级标题
## 二级标题
### 三级标题
#### 四级标题
##### 五级标题
###### 六级标题
####### 最多支持六级标题
```

## 段落

段落没有特殊的格式，直接用一个空行来表示重新开始一个段落。

## 文字

### 斜体

```markdown
这是用来 *斜体* 的 _文本_
```

这是用来 *斜体* 的 *文本*

### 加粗

```markdown
这是用来 **加粗** 的 __文本__
```

这是用来 **加粗** 的 **文本**

### 斜体+加粗

```markdown
这是用来 ***斜体+加粗*** 的 ___文本___
```

这是用来 ***斜体+加粗*** 的 ***文本***

### 删除线

```markdown
这就是 ~~删除线~~ (使用波浪号)
```

这就是 ~~删除线~~ (使用波浪号)

### 下划线

下划线是HTML语法

`下划线` 下划线(快捷键`command`+`u`，视频中所有的快捷键都是针对Mac系统，其他系统可自行查找)

## 分隔线

可以在一行中使用三个或更多的 `*`、`-` 或 `_` 来添加分隔线

```markdown
***
------
___
```

------

------

------

## 扩展语法的说明

部分渲染器可能不支持该效果，若不在意跨软件性可以使用（意思就是换了个别的支持markdown语法的地方敲字，某些样式可能识别不出来）

## 高亮（需勾选扩展语法）

```markdown
这是用来 ==高亮== 的文本
```

这是用来 ==高亮== 的文本

## 下标（需勾选扩展语法）

```markdown
水 H~2~O 
双氧水 H~2~O~2~ 
```

水 H~~2~~O

双氧水 H~~2~~O~~2~~

## 上标（需勾选扩展语法）

```markdown
面积 m^2^ 
体积 m^3^
```

面积 m^2^
体积 m^3^

## 表情符号

Emoji 支持表情符号，你可以用系统默认的 Emoji 符号。

输入方式

1. 输入 `:` 将会出现智能提示`:smile:`😄![img](https://github.githubassets.com/images/icons/emoji/unicode/1f604.png?v8)
2. 直接输入法选入
3. 快捷键后点选：
   - Mac: control+command+space点选
   - Window:使用 Win键+. 或者Win键+. 点选

不同方式输入的emoji可能最后渲染的会不一样😄，影响不大

```markdown
:smile: :laughing: :dizzy_face: :sob: :cold_sweat: :sweat_smile:  :cry: :triumph: :heart_eyes: :relaxed: :sunglasses: :weary: :100: :clap: :bell: :gift: :question: :bomb: :heart: :coffee: :cyclone: :bow: :kiss: :pray: :sweat_drops: :hankey: :exclamation: :anger:
```

😄![img](https://github.githubassets.com/images/icons/emoji/unicode/1f604.png?v8) 😆![img](https://github.githubassets.com/images/icons/emoji/unicode/1f606.png?v8) 😵![img](https://github.githubassets.com/images/icons/emoji/unicode/1f635.png?v8) 😭![img](https://github.githubassets.com/images/icons/emoji/unicode/1f62d.png?v8) 😰![img](https://github.githubassets.com/images/icons/emoji/unicode/1f630.png?v8) 😅![img](https://github.githubassets.com/images/icons/emoji/unicode/1f605.png?v8) 😢![img](https://github.githubassets.com/images/icons/emoji/unicode/1f622.png?v8) 😤![img](https://github.githubassets.com/images/icons/emoji/unicode/1f624.png?v8) 😍![img](https://github.githubassets.com/images/icons/emoji/unicode/1f60d.png?v8) ☺![img](https://github.githubassets.com/images/icons/emoji/unicode/263a.png?v8) 😎![img](https://github.githubassets.com/images/icons/emoji/unicode/1f60e.png?v8) 😩![img](https://github.githubassets.com/images/icons/emoji/unicode/1f629.png?v8) 💯![img](https://github.githubassets.com/images/icons/emoji/unicode/1f4af.png?v8) 👏![img](https://github.githubassets.com/images/icons/emoji/unicode/1f44f.png?v8) 🔔![img](https://github.githubassets.com/images/icons/emoji/unicode/1f514.png?v8) 🎁![img](https://github.githubassets.com/images/icons/emoji/unicode/1f381.png?v8) ❓![img](https://github.githubassets.com/images/icons/emoji/unicode/2753.png?v8) 💣![img](https://github.githubassets.com/images/icons/emoji/unicode/1f4a3.png?v8) ❤![img](https://github.githubassets.com/images/icons/emoji/unicode/2764.png?v8) ☕![img](https://github.githubassets.com/images/icons/emoji/unicode/2615.png?v8) 🌀![img](https://github.githubassets.com/images/icons/emoji/unicode/1f300.png?v8) 🙇![img](https://github.githubassets.com/images/icons/emoji/unicode/1f647.png?v8) 💋![img](https://github.githubassets.com/images/icons/emoji/unicode/1f48b.png?v8) 🙏![img](https://github.githubassets.com/images/icons/emoji/unicode/1f64f.png?v8) 💦![img](https://github.githubassets.com/images/icons/emoji/unicode/1f4a6.png?v8) 💩![img](https://github.githubassets.com/images/icons/emoji/unicode/1f4a9.png?v8) ❗![img](https://github.githubassets.com/images/icons/emoji/unicode/2757.png?v8) 💢![img](https://github.githubassets.com/images/icons/emoji/unicode/1f4a2.png?v8)

## 列表

### 无序列表

符号 空格

```markdown
* 可以使用 `*` 作为标记
+ 也可以使用 `+`
- 或者 `-`
```

- 可以使用 `*` 作为标记

- 也可以使用 `+`

- 或者 `-`

### 有序列表

数字 `.` 空格

```markdown
1. 有序列表以数字和 `.` 开始；
3. 数字的序列并不会影响生成的列表序列；
4. 但仍然推荐按照自然顺序（1.2.3...）编写。
```

1. 有序列表以数字和 `.` 开始；
2. 数字的序列并不会影响生成的列表序列；
3. 但仍然推荐按照自然顺序（1.2.3…）编写

```markdown
可以使用：数字\. 来取消显示为列表（用反斜杠进行转义）
```

## 表格

使用 `|` 来分隔不同的单元格，使用 `-` 来分隔表头和其他行：

```markdown
name | price
--- | ---
fried chicken | 19
cola|5
```

> 为了使 Markdown 更清晰，`|` 和 `-` 两侧需要至少有一个空格（最左侧和最右侧的 `|` 外就不需要了）。

| name          | price |
| ------------- | ----- |
| fried chicken | 19    |
| cola          | 5     |

为了美观，可以使用空格对齐不同行的单元格，并在左右两侧都使用 `|` 来标记单元格边界，在表头下方的分隔线标记中加入 `:`，即可标记下方单元格内容的对齐方式：

```markdown
|    name       | price |
| :------------ | :---: |
| fried chicken | 19    |
| cola          |  32   |
```

| name          | price |
| ------------- | ----- |
| fried chicken | 19    |
| cola          | 32    |

==使用快捷键`command`+`opt`+`T`更方便(段落→表格→插入表格，即可查看快捷键)==

## 引用

开头使用 **>** 符号 ，然后后面紧跟一个**空格**符号

```markdown
> “后悔创业”
```

> “后悔创业”

```markdown
> 也可以在引用中
>> 使用嵌套的引用
```

> 也可以在引用中
>
> > 使用嵌套的引用

## 代码

### 代码块

代码块中的文本（包括 Markdown 语法）都会显示为原始内容

~~~markdown
```语言名称（也可以不指定）
public static void main(String[] args) {
   }
~~~

### 行内代码

也可以通过反引号（``），插入行内代码

![image-20210306171044147](https://jojo-995.gitee.io/2021/03/06/markdown-tutorial/image-20210306171044147.png)

```markdown
例如 `Markdown`
```

例如 `Markdown`

## 跳转

### 外部跳转–超链接

格式为 `[link text](link)`。

```markdown
[帮助文档](https://support.typora.io/Links/#faq)
```

[帮助文档](https://support.typora.io/Links/#faq)

### 内部跳转–本文件内跳-Typora支持

格式为 `[link text](#要去的目的地-标题名称）`。

不管标题有几个#，设置链接时*只有一个#\*，标题里的\*空格*可以用’-‘代替，开头结尾的空格无所谓。

```markdown
[我想跳转](#完结)
```

> Open Links in Typora
>
> You can use `command+click` (macOS), or `ctrl+click` (Linux/Windows) on links in Typora to jump to target headings, or open them in Typora, or open in related apps.

[我想跳转](https://jojo-995.gitee.io/2021/03/06/markdown-tutorial/#完结)

如果不想跳到标题，则可以自定义锚点

```html
<a href="#anchor">不，你不想跳，你要回去</a>
<a name="anchor">锚点</a> 
```

### 自动链接

使用 `<>` 包括的 URL 或邮箱地址会被自动转换为超链接：

```markdown
<https://www.baidu.com>

<123@email.com>
```

[https://www.baidu.com](https://www.baidu.com/)

[123@email.com](mailto:123@email.com)

### 重复链接

当在一个文章==重复使用同一个链接（对下面的图片也是一样的适用）==时，我们可以通过变量来设置一个链接，相当于给这个链接起了个名字，方便统一修改，变量赋值在文档引用的下面进行：

```markdown
这个链接用 1 作为网址变量名字 [百度][1]
这个链接用 jojo 作为网址变量名字 [JoJo的博客][jojo]
然后在文档的结尾为变量赋值（网址）

  [1]: http://www.baidu.com/
  [jojo]: http://jojo-995.gitee.io/
```

这个链接用 1 作为网址变量名字 [百度](http://www.baidu.com/)
这个链接用 jojo 作为网址变量名字 [JoJo的博客](http://jojo-995.gitee.io/)
然后在文档的结尾为变量赋值（网址）

## 图片

```markdown
![自己起的图片名字](图片地址或者图片本地存储的路径)
```

### 网上的图片

```markdown
![我爱的🍗](https://ss0.bdstatic.com/94oJfD_bAAcT8t7mm9GUKT-xh_/timg?image&quality=100&size=b4000_4000&sec=1580814517&di=2630beac440e5dab0e44c7286a3b2b61&src=http://imgsrc.baidu.com/forum/w=580/sign=12c730c4ff03738dde4a0c2a831ab073/9497794f9258d1091818e6d6d858ccbf6d814d1b.jpg)
```

![炸鸡](https://jojo-995.gitee.io/2021/03/06/markdown-tutorial/9497794f9258d1091818e6d6d858ccbf6d814d1b.jpg)

### 本地图片

在同一个文件夹里（用相对路径）或者直接拷贝（配合snipaste截屏工具使用效果一级棒）[点击下载sinapste](https://zh.snipaste.com/)

```markdown
![我爱的🍗](markdown-tutorial/image-20210306172630754.png)
```

![我爱的🍗](https://jojo-995.gitee.io/2021/03/06/markdown-tutorial/image-20210306172630754.png)

# 利用Markdown画图（需勾选扩展语法）

==~~我觉得这玩意不如直接用[processon](https://www.processon.com/)或[Draw.io](https://app.diagrams.net/)在线画了然后截截图~~==（draw.io还有客户端，**强烈安利** 下面有关的资料除了饼图都可以不用看了，怪我当初太年轻🐶

------

markdown画图也是轻量级的，功能并不全。

Mermaid 是一个用于画流程图、状态图、时序图、甘特图的库，使用 JS 进行本地渲染，广泛集成于许多 Markdown 编辑器中。（不同的编辑器渲染的可能不一样,也非常有可能直接渲染不出来🐶🐶）

## 饼图(Pie)

```markdown
pie title 我的身体
 "奶茶" : 10
 "炸鸡" : 20
 "水" : 70

```

> [Typora支持mermaid的官方链接](http://support.typora.io/Draw-Diagrams-With-Markdown/)

## 流程图(graph)

### 概述

```markdown
graph 方向描述
    图表中的其他语句...
```

关键字graph表示一个流程图的开始，同时需要指定该图的方向。

其中“方向描述”为：

| 用词 | 含义     |
| ---- | -------- |
| TB   | 从上到下 |
| BT   | 从下到上 |
| RL   | 从右到左 |
| LR   | 从左到右 |

> T = TOP，B = BOTTOM，L = LEFT，R = RIGHT，D = DOWN

最常用的布局方向是TB、LR。

```markdown
graph TB;
  A-->B
  B-->C
  C-->A
 
Syntax error in graphmermaid version 8.9.1
graph LR;
  A-->B
  B-->C
  C-->A
Syntax error in graphmermaid version 8.9.1
```

### 流程图常用符号及含义

#### 节点形状

| 表述       | 说明           | 含义                                                 |
| ---------- | -------------- | ---------------------------------------------------- |
| id[文字]   | 矩形节点       | 表示过程，也就是整个流程中的一个环节                 |
| id(文字)   | 圆角矩形节点   | 表示开始和结束                                       |
| id((文字)) | 圆形节点       | 表示连接。为避免流程过长或有交叉，可将流程切开。成对 |
| id{文字}   | 菱形节点       | 表示判断、决策                                       |
| id>文字]   | 右向旗帜状节点 |                                                      |

**单向箭头线段**：表示流程进行方向

> id即为节点的唯一标识，A~F 是当前节点名字，类似于变量名，画图时便于引用
>
> 括号内是节点中要显示的文字，默认节点的名字和显示的文字都为A

```markdown
graph TB
  A
  B(圆角矩形节点)
  C[矩形节点]
  D((圆形节点))
  E{菱形节点}
  F>右向旗帜状节点] 
Syntax error in graphmermaid version 8.9.1
graph TB
    begin(出门)--> buy[买炸鸡]
    buy --> IsRemaining{"还有没有炸鸡？"}
    IsRemaining -->|有|happy[买完炸鸡开心]--> goBack(回家)
    IsRemaining --没有--> sad["伤心"]--> goBack
    
Syntax error in graphmermaid version 8.9.1
```

#### 连线

```markdown
graph TB
  A1-->B1
  A2---B2
  A3--text---B3
  A4--text-->B4
  A5-.-B5
  A6-.->B6
  A7-.text.-B7
  A8-.text.->B8
  A9===B9
  A10==>B10
  A11==text===B11
  A12==text==>B12
Syntax error in graphmermaid version 8.9.1
Syntax error in graphmermaid version 8.9.1
```

### 子图表

使用以下语法添加子图表

```markdown
subgraph 子图表名称
    子图表中的描述语句...
end
graph TB
	  subgraph 买炸鸡前
   			 begin(出门)--> buy[出门买炸鸡]
    end
    buy --> IsRemaining{"还有没有炸鸡？"}
    IsRemaining --没有--> sad["伤心"]--> goBack(回家)
    IsRemaining -->|有|happy[买完炸鸡开心]--> goBack
Syntax error in graphmermaid version 8.9.1
```

## 序列图(sequence diagram)

### 概述

```markdown
sequenceDiagram 
	[参与者1][消息线][参与者2]:消息体
    ...
```

> `sequenceDiagram` 为每幅时序图的固定开头

```markdown
sequenceDiagram
		Title: 买炸鸡
    救救->>炸鸡店小哥: 还有炸鸡吗？
    炸鸡店小哥-->>救救: 没有，要现炸
救救炸鸡店小哥还有炸鸡吗？没有，要现炸<div class="copy-btn"><i class="fa fa-copy fa-fw"></i></div>救救炸鸡店小哥买炸鸡
```

### 参与者（participant）

传统时序图概念中参与者有角色和类对象之分，但这里我们不做此区分，用参与者表示一切参与交互的事物，可以是人、类对象、系统等形式。中间竖直的线段从上至下表示时间的流逝。

```markdown
sequenceDiagram
    participant 参与者 1
    participant 参与者 2
    ...
    participant 简称 as 参与者 3 #该语法可以在接下来的描述中使用简称来代替参与者 3
```

> `participant <参与者名称>` 声明参与者，语句次序即为参与者横向排列次序。

### 消息线

| 类型 | 描述                         |
| ---- | ---------------------------- |
| ->   | 无箭头的实线                 |
| –>   | 无箭头的虚线                 |
| ->>  | 有箭头的实线（主动发出消息） |
| –->> | 有箭头的虚线（响应）         |
| -x   | 末端为叉的实线（表示异步）   |
| –x   | 末端为叉的虚线（表示异步）   |

### 处理中-激活框

从消息接收方的时间线上标记一小段时间，表示对消息进行处理的时间间隔。

在消息线末尾增加 `+` ，则消息接收者进入当前消息的“处理中”状态；
在消息线末尾增加 `-` ，则消息接收者离开当前消息的“处理中”状态。

```markdown
sequenceDiagram
    participant 99 as 救救
    participant seller as 炸鸡店小哥
    99 ->> seller: 还有炸鸡吗？
    seller -->> 99: 没有，要现炸。
    99 -x +seller:给我炸！
    seller -->> -99: 您的炸鸡好了！
救救炸鸡店小哥还有炸鸡吗？没有，要现炸。给我炸！您的炸鸡好了！<div class="copy-btn"><i class="fa fa-copy fa-fw"></i></div>救救炸鸡店小哥买炸鸡
```

### 注解（note）

语法如下

```markdown
Note 位置表述 参与者: 标注文字
```

其中位置表述可以为

| 表述     | 含义                       |
| -------- | -------------------------- |
| right of | 右侧                       |
| left of  | 左侧                       |
| over     | 在当中，可以横跨多个参与者 |

```markdown
sequenceDiagram
    participant 99 as 救救
    participant seller as 炸鸡店小哥
    Note over 99,seller : 热爱炸鸡
    Note left of 99 : 女
    Note right of seller : 男
    99 ->> seller: 还有炸鸡吗？
    seller -->> 99: 没有，要现炸。
    99 -x +seller : 给我炸！
    seller -->> -99: 您的炸鸡好了！
救救炸鸡店小哥热爱炸鸡女男还有炸鸡吗？没有，要现炸。给我炸！您的炸鸡好了！<div class="copy-btn"><i class="fa fa-copy fa-fw"></i></div>救救炸鸡店小哥买炸鸡
```

### 循环（loop）

在条件满足时，重复发出消息序列。（相当于编程语言中的 while 语句。）

```markdown
sequenceDiagram
    participant 99 as 救救
    participant seller as 炸鸡店小哥
   
    99 ->> seller: 还有炸鸡吗？
    seller -->> 99: 没有，要现炸。
    99 ->> +seller:给我炸！
    loop 三分钟一次
        99 ->> seller : 我的炸鸡好了吗？
        seller -->> 99 : 正在炸
    end
    seller -->> -99: 您的炸鸡好了！
救救炸鸡店小哥还有炸鸡吗？没有，要现炸。给我炸！我的炸鸡好了吗？正在炸loop[三分钟一次]您的炸鸡好了！<div class="copy-btn"><i class="fa fa-copy fa-fw"></i></div>救救炸鸡店小哥买炸鸡
```

### 选择（alt）

在多个条件中作出判断，每个条件将对应不同的消息序列。（相当于 if 及 else if 语句。）

```markdown
sequenceDiagram    
    participant 99 as 救救
    participant seller as 炸鸡店小哥
    99 ->> seller : 现在就多少只炸好的炸鸡？
    seller -->> 99 : 可卖的炸鸡数
    
    alt 可卖的炸鸡数 > 3
        99 ->> seller : 买三只！
    else 1 < 可卖的炸鸡数 < 3
        99 ->> seller : 有多少买多少
    else 可卖的炸鸡数 < 1
        99 ->> seller : 那我明天再来
    end

    seller -->> 99 : 欢迎下次光临
救救炸鸡店小哥现在就多少只炸好的炸鸡？可卖的炸鸡数买三只！有多少买多少那我明天再来alt[可卖的炸鸡数 > 3][1 < 可卖的炸鸡数 < 3][可卖的炸鸡数 < 1]欢迎下次光临<div class="copy-btn"><i class="fa fa-copy fa-fw"></i></div>救救炸鸡店小哥买炸鸡
```

### 可选（opt）

在某条件满足时执行消息序列，否则不执行。相当于单个分支的 if 语句。

```markdown
sequenceDiagram
    participant 99 as 救救
    participant seller as 炸鸡店小哥
    99 ->> seller : 买炸鸡
    opt 全都卖完了
        seller -->> 99 : 下次再来
    end
Syntax error in graphmermaid version 8.9.1
```

### 并行（Par）

将消息序列分成多个片段，这些片段并行执行。

```markdown
sequenceDiagram
   participant 99 as 救救
   participant seller as 炸鸡店小哥
   
    99 ->> seller : 一个炸鸡，一杯可乐！

    par 并行执行
        seller ->> seller : 装可乐
    and
        seller ->> seller : 炸炸鸡
    end

    seller -->> 99 : 您的炸鸡好了！
救救炸鸡店小哥一个炸鸡，一杯可乐！装可乐炸炸鸡par[并行执行]您的炸鸡好了！<div class="copy-btn"><i class="fa fa-copy fa-fw"></i></div>救救炸鸡店小哥买炸鸡
```

## 甘特图（gantt）

```markdown
 title 标题
dateFormat 日期格式
section 部分名
任务名:参数一, 参数二, 参数三, 参数四，参数五

 //参数一：crit（是否重要，红框框） 或者 不填
 //参数二：done（已完成）、active（正在进行） 或者 不填(表示为待完成状态)
 //参数三：取小名 或者 不填
 //参数四：任务开始时间
 //参数五：任务结束时间
```

> [官方教程](https://mermaid-js.github.io/mermaid/#/gantt)

```none
gantt
       dateFormat  YYYY-MM-DD
       title Adding GANTT diagram functionality to mermaid

       section A section
       Completed task            :done,    des1, 2014-01-06,2014-01-08
       Active task               :active,  des2, 2014-01-09, 3d
       Future task               :         des3, after des2, 5d
       Future task2              :         des4, after des3, 5d

       section Critical tasks
       Completed task in the critical line :crit, done, 2014-01-06,24h
       Implement parser and jison          :crit, done, after des1, 2d
       Create tests for parser             :crit, active, 3d
       Future task in critical line        :crit, 5d
       Create tests for renderer           :2d
       Add to mermaid                      :1d

       section Documentation
       Describe gantt syntax               :active, a1, after des1, 3d
       Add gantt diagram to demo page      :after a1  , 20h
       Add another diagram to demo page    :doc1, after a1  , 48h

       section Last section
       Describe gantt syntax               :after doc1, 3d
       Add gantt diagram to demo page      :20h
       Add another diagram to demo page    :48h
2014-01-072014-01-092014-01-112014-01-132014-01-152014-01-172014-01-192014-01-21Completed taskCompleted task in the critical lineImplement parser and jisonDescribe gantt syntaxActive taskCreate tests for parserAdd gantt diagram to demo pageAdd another diagram to demo pageFuture taskFuture task in critical lineDescribe gantt syntaxAdd gantt diagram to demo pageAdd another diagram to demo pageFuture task2Create tests for rendererAdd to mermaidA sectionCritical tasksDocumentationLast sectionAdding GANTT diagram functionality to mermaid
```

# 完结

[不，你不想跳，你要回去](https://jojo-995.gitee.io/2021/03/06/markdown-tutorial/#anchor)

🎉🎉愿一年后的我不会再来重做

- **本文作者：** JoJo
- **本文链接：** https://jojo-995.gitee.io/2021/03/06/markdown-tutorial/
- **版权声明：** 本博客所有文章除特别声明外，均采用 [BY-NC-SA](https://creativecommons.org/licenses/by-nc-sa/4.0/en) 许可协议。转载请注明出处！