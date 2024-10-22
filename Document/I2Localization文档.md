# 使用方式

## 1. 添加语言类型

如：中文、英文等

![屏幕截图 2024-10-22 110439](.\Images\屏幕截图 2024-10-22 110439.png)

## 2. 添加、修改、删除需要翻译的内容

![image-20241022110822705](C:\Users\FortuneCat0v0\AppData\Roaming\Typora\typora-user-images\image-20241022110822705.png)

## 3. 为Text添加多语言脚本

添加I2Localize脚本

![屏幕截图 2024-10-22 111117](.\Images\屏幕截图 2024-10-22 111117.png)

这里可以点击Add Term To Source自动添加Term，也可以选择之前添加好的

![屏幕截图 2024-10-22 111448](.\Images\屏幕截图 2024-10-22 111448.png)

## 4. 为Image添加多语言脚本

选择或生成Term后，***选择Sprite***，添加图片的引用***(选择Bundle文件以外的)***

![屏幕截图 2024-10-22 111641](.\Images\屏幕截图 2024-10-22 111641.png)

## 5. Ctrl + S，Ctrl + R 保存刷新一下



# 打包相关

1. 编辑器运行时，多语言配置是在Editor/I2Location/I2Languages中。

2. 真机运行时，多语言配置是加载Bundles/Text/I2_???.csv等文件。

3. YooAsset打资源包前，要先点击ET/Build Tool/I2Localization 配置导出。

4. 如果想要在编辑器下测试能否成功加载.csv，在配置导出后，修改该字段为True。

   ![屏幕截图 2024-10-22 113257](.\Images\屏幕截图 2024-10-22 113257.png)